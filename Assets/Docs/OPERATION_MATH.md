# Operation Math — Design Memory

Authoritative specification for **operation success calculation** in Cyber Clinic. The calculator lives in the **Procedures** module (or dedicated `OperationCalculator` type in that module). It must remain **pure**: inputs → outputs, no side effects.

**Related:** `GAME_DESIGN_MEMORY.md`, `PROCEDURAL_PATIENT_SYSTEM.md`, `VISUAL_AUDIO_DIRECTION.md`

---

## Design goal

Provide **transparent, deterministic risk** the player can learn and master:

- Same operation plan + same patient state + same seed → **same numeric outcome**.
- UI shows a **breakdown** of every term so players understand why Critical risk appeared.
- Math creates tension between profit (cheap/illegal) and safety—not hidden RNG cheating.

**OperationCalculator must NOT:**

- Update money, reputation, or inventory
- Write save data
- Spawn VFX or play audio
- Show UI

Those react to **`OperationResolved`** events from orchestration layers.

---

## Inputs

| Input | Source | Description |
|-------|--------|-------------|
| `baseSuccess` | Procedure SO | Procedure baseline |
| `clinicSkillBonus` | Progression/clinic state | Meta upgrade |
| `equipmentBonus` | Clinic equipment SO | Hardware modifier |
| `preparationBonus` | Player prep choices (future) | Pre-op minigame or spend |
| `implantCompatibility` | Implant + slot + patient | −1..+1 normalized |
| `procedureDifficulty` | Procedure SO | 0..1+ |
| `cyberToxPressure` | Derived from implant + patient resistance | ≥ 0 |
| `neuralLoadPressure` | Derived from implant + patient stability | ≥ 0 |
| `bodyStress` | Patient baseline + procedure | ≥ 0 |
| `hiddenConditionPenalty` | Sum of revealed/active hidden mods | ≥ 0 |
| `illegalImplantRisk` | Implant legality tier | ≥ 0 |
| `patientPanicPenalty` | Current panic level | ≥ 0 |
| `seededRandomVariance` | PRNG from operation seed | Small swing |

### Derived pressures (concept)

```
cyberToxPressure = implant.cyberToxLoad * (1 - patient.cyberToxResistance) * procedure.cyberToxMultiplier
neuralLoadPressure = implant.neuralLoad * (1 - patient.neuralStability) * procedure.neuralMultiplier
bodyStress = patient.bodyStressBaseline + procedure.bodyStressAdd
```

Coefficients live in ScriptableObjects, not magic numbers in code.

---

## Outputs

| Output | Use |
|--------|-----|
| `successChance` | 0.0–1.0 clamped |
| `riskBand` | Safe / Stable / Uncertain / Dangerous / Critical |
| `outcomeType` | See outcome types |
| `breakdown` | List of labeled terms for UI localization |
| `operationSeed` | Audit / replay |

---

## Success chance formula (canonical)

```
Operation Success Chance =
  Base Success
+ Clinic Skill Bonus
+ Equipment Bonus
+ Preparation Bonus
+ Implant Compatibility
- Procedure Difficulty
- CyberTox Pressure
- Neural Load Pressure
- Body Stress
- Hidden Condition Penalty
- Patient Panic Penalty
- Illegal Implant Risk
+ Seeded Random Variance
```

Then: `successChance = Clamp01(raw)`

**Breakdown UI** shows each term with signed contribution and localized label keys (`math.term.<id>`).

---

## Seeded random variance

- Scope: **one draw** per committed operation from `operationSeed = Hash(patientSeed, implantId, procedureId, clinicDay)`.
- Typical range: **−0.05 .. +0.05** (tune in SO)—never overrides a clearly Safe plan into Critical alone.
- Purpose: Slight replay texture at band edges; teachable once players read breakdown.

---

## Risk bands

| Band | successChance | UI color (concept) | Audio |
|------|---------------|-------------------|-------|
| `Safe` | ≥ 0.85 | Green/cyan | Soft stable tone |
| `Stable` | 0.70–0.84 | Blue | Neutral hum |
| `Uncertain` | 0.50–0.69 | Amber | Low warning |
| `Dangerous` | 0.30–0.49 | Orange | Warning pulse |
| `Critical` | < 0.30 | Red + glitch | Alarm + heartbeat |

Localization: `risk.band.<id>.label`, `risk.band.<id>.description`

---

## Operation outcome types

After success chance is computed, map to outcome (thresholds in SO):

| Outcome | Condition (concept) | Follow-up module |
|---------|---------------------|------------------|
| `critical_success` | Roll high in Safe/Stable | Economy+, reputation+ |
| `stable_success` | Roll ≥ successChance | Standard rewards |
| `unstable_success` | Roll slightly below | Minor complication check |
| `failure` | Roll far below | Complications, reputation− |
| `catastrophe` | Critical band + bad roll | Heavy rep, event hooks |

**Complication module** rolls secondary tables—not inside calculator.

---

## Implant compatibility

| Score | Meaning |
|-------|---------|
| +0.15 | Perfect slot + tier match |
| 0 | Acceptable |
| −0.10 | Slot stress |
| −0.25 | Conflict with body problem |
| −0.40 | Hidden `slot_conflict` |

Compatibility is **input** only; calculator does not read SO directly at runtime if passed as DTO.

---

## Clinic equipment modifier

Flat or scaled `equipmentBonus` from clinic level:

| Tier | Bonus (example) |
|------|-----------------|
| Street | 0 |
| Upgraded | +0.05 |
| Pro | +0.10 |
| Black clinic | +0.15, illegal risk handling |

---

## Preparation modifier

Future: spend time/money before op for `preparationBonus` 0..0.10. Documented for UI slot in Milestone 6.

---

## Hidden condition penalty

Sum penalties from **revealed** hidden conditions only at commit time (design choice: fair player knowledge).

| Condition | Penalty (example) |
|-----------|-------------------|
| `neural_fragile` | +0.12 neural effective |
| `cybertox_sensitive` | +0.10 cyber effective |
| `slot_conflict` | +0.15 compatibility− |
| `panic_disorder` | +0.08 panic |

Unrevealed conditions still apply to math at operation commit (player chose not to scan)—document in tutorial keys.

---

## Illegal implant risk

| Tier | Risk add |
|------|----------|
| Legal | 0 |
| Gray | +0.03 |
| Illegal | +0.12 (+ event weight) |

Separate from post-op raid events (Events module).

---

## Patient panic penalty

```
patientPanicPenalty = (panicLevel / 100) * panicScale
```

`panicScale` from global tuning SO (e.g. 0.20 max).

---

## Breakdown system for UI

`OperationBreakdown` DTO:

```text
entries[]: { termKey, value, sign, sortOrder }
successChance, riskBand, outcomeType (preview vs final)
```

UI module maps `termKey` → localized string. **No formatted numbers in calculator**—UI localizes `{0}` via smart strings.

Preview mode: before commit, show breakdown without final roll.  
Commit mode: orchestrator calls calculator → emits result → Visual/Audio/Economy subscribe.

---

## Why calculator must not update money/reputation/save

| Reason | Explanation |
|--------|-------------|
| **Testability** | Pure function unit tests |
| **Replay** | Same DTO → same result for bug reports |
| **Decoupling** | Economy applies rewards from outcome event |
| **UI honesty** | Preview uses same code path without side effects flag |

**Flow:**

```
UI Commit
  → ProceduresOrchestrator
    → OperationCalculator.Calculate(dto) → result
    → EventBus.Publish(OperationResolved, result)
      → Economy applies money
      → Progression applies reputation
      → Complications maybe roll
      → Visual/Audio play feedback
      → Save marks dirty (later)
```

---

## Example calculation scenarios

### Scenario 1 — Safe quality arm job

- Base 0.75, skill +0.05, equip +0.05, compat +0.10, prep +0.05  
- Difficulty −0.10, cyber −0.05, neural −0.05, body −0.03, hidden 0, panic −0.02, illegal 0, variance +0.02  
- **Raw ≈ 0.77 → Stable band**

### Scenario 2 — Cheap illegal spine

- Base 0.60, compat −0.25, difficulty −0.25, cyber −0.18, neural −0.22, hidden −0.12, illegal −0.12, panic −0.08, variance −0.03  
- **Raw ≈ 0.15 → Critical band** (player should have scanned)

### Scenario 3 — Same as 2 after deep scan

- Player switches to quality implant: compat +0.10, illegal 0, cyber/neural reduced  
- **Raw ≈ 0.52 → Uncertain** — meaningful decision, not auto-win

---

## Data model notes (future SO)

| Asset | Purpose |
|-------|---------|
| `ProcedureSO` | difficulty, base success, multipliers |
| `ImplantSO` | loads, legality, slot |
| `OperationTuningSO` | band thresholds, variance range, panic scale |
| `HiddenConditionModifierSO` | penalty terms |

---

## Acceptance criteria (Milestone 5)

- [ ] Pure calculator with breakdown DTO
- [ ] Deterministic with operation seed
- [ ] Risk bands from SO thresholds
- [ ] No economy/reputation/save/UI references in calculator assembly
- [ ] Unit-testable scenarios 1–3
