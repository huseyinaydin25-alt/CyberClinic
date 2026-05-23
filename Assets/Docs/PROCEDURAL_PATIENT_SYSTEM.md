# Procedural Patient System — Design Memory

Authoritative specification for **procedural patient generation** in Cyber Clinic. Implementation belongs in `Scripts/Patients/` with definitions in `ScriptableObjects/Patients/`. UI only displays runtime patient models.

**Related:** `GAME_DESIGN_MEMORY.md`, `OPERATION_MATH.md`, `LOCALIZATION_PLAN.md`

---

## Generation formula

A **Generated Patient** is composed of:

```
Generated Patient =
  Archetype
+ Motivation
+ Body Problem
+ Requested Upgrade
+ Budget Profile
+ Risk Profile
+ Hidden Condition
+ Visual Trait
+ Dialogue Tone
+ Legal Status
+ Urgency
```

Each component draws from **ScriptableObject pools** weighted by day, reputation, clinic level, and **deterministic seed**.

---

## Deterministic seed support

| Input | Role |
|-------|------|
| `runSeed` | Campaign/session seed (persisted in save) |
| `dayIndex` | Current clinic day |
| `patientSlotIndex` | Queue position for the day |
| `optionalChallengeSeed` | Events, daily modifiers |

**Generation rule:**  
`patientSeed = Hash(runSeed, dayIndex, patientSlotIndex, [eventSalt])`

All random draws for that patient use `patientSeed` (Unity `Random.State` scoped or custom PRNG). **Same inputs → same patient** on all platforms.

Replay/debug: expose seed in dev overlay (Editor only, non-shipping UI).

---

## Patient archetypes

Archetypes define base weights, visual deck, and dialogue tone pool.

| ID (concept) | Description | Typical motivation | Legal lean |
|--------------|-------------|-------------------|------------|
| `underground_fighter` | Arena debt, combat chrome | Performance | Illegal-friendly |
| `corporate_exile` | Fell from corp, hiding | Disguise / power | Mixed |
| `street_netrunner` | Deck junkies, neural hacks | Performance | Gray |
| `fashion_hacker` | Aesthetic chrome trend | Status | Legal-gray |
| `black_market_dealer` | Reselling parts | Profit | Illegal |
| `burnout_medic` | Self-surgery desperation | Survival | Gray |
| `gang_enforcer` | Intimidation, armor skin | Dominance | Illegal |
| `celebrity_shadow` | Anonymous upgrade | Anonymity | Legal facade |

Localization: `patient.archetype.<id>.name`, `.description`, `.flavor`

---

## Motivations

Motivation affects dialogue tone weights and accept/reject reputation hints—not direct operation math unless wired via hidden condition synergy.

| Motivation | Player-readable hint key | Hidden bias |
|------------|--------------------------|-------------|
| `performance` | Wants edge in combat/work | Tolerates neural load |
| `survival` | Desperate health fix | Low budget flexibility |
| `status` | Visible chrome | Aesthetic implants |
| `profit` | Resell or job-related | May lie on budget |
| `secrecy` | Hiding identity | Extra hidden conditions |
| `vengeance` | Risk-blind | High panic baseline |
| `addiction` | Cyber dependency | CyberTox sensitivity |

---

## Body slots

Canonical slots for implants and procedures:

| Slot | Notes |
|------|-------|
| `head` | Neural, ocular, cranial |
| `torso` | Core, spine interface |
| `arm_left` / `arm_right` | Reflex, strength, tools |
| `leg_left` / `leg_right` | Mobility, stability |
| `spine` | Neural highway—high risk |
| `skin` | Aesthetic, armor mesh |
| `internal` | Organ-adjacent illegal |

**Body problem** occupies or damages a slot; **requested upgrade** targets a slot (may conflict).

---

## Request types

| Request type | Example upgrade | Procedure family |
|--------------|-----------------|------------------|
| `reflex_booster` | Arm nerve accelerator | `neural_tune` |
| `aesthetic_chrome` | Skin mesh | `surface_graft` |
| `neural_spine` | Spine lane | `deep_neural` |
| `ocular_hud` | Head ocular | `cranial` |
| `toxin_filter` | Internal filter | `internal` |
| `illegal_overclock` | Multi-slot | `black_ops` |

Localization: `patient.request.<id>.description`

---

## Budget profile

| Band | Stated range (UI) | True ceiling | Notes |
|------|-------------------|--------------|-------|
| `broke` | Low–low | May be 0% of quality implant | Hidden: may not afford scan |
| `tight` | Low–mid | 70–90% stated max | |
| `standard` | Mid | Matches stated | |
| `flush` | Mid–high | 110% stated | Hidden surplus possible |
| `suspicious` | High stated | Lower true | Motivation `profit` |

**Known:** Stated band on file.  
**Unknown until scan/deep scan:** `trueBudgetCeiling`, `willWalkIfOverBudget`.

---

## Tolerance ranges

Part of **Risk Profile**:

| Stat | Range (typical) | Affects |
|------|-----------------|---------|
| `cyberToxResistance` | 0.0–1.0 | CyberTox pressure tolerance |
| `neuralStability` | 0.0–1.0 | Neural load pressure |
| `bodyStressBaseline` | 0.0–1.0 | Body stress in operation math |
| `panicLevel` | 0–100 | Panic penalty, dialogue |
| `painThreshold` | 0.0–1.0 | Flavor, complication weights |

**Known:** Vague labels (“Low”, “Unknown”) via localization bands.  
**Unknown:** Exact floats until scan.

---

## Neural stability & CyberTox resistance

- **Neural stability** — Lower values increase `Neural Load Pressure` in `OPERATION_MATH.md`.
- **CyberTox resistance** — Lower values increase effective `CyberTox Pressure`.

Displayed as qualitative bands in UI; exact values in runtime model for calculator.

---

## Panic level

- Base from archetype + motivation + urgency.
- Rises when player delays intake or when risk preview shows Dangerous/Critical.
- Feeds `Patient Panic Penalty` in operation math.

---

## Urgency

| Level | Patience decay | Leave chance |
|-------|----------------|--------------|
| `low` | Slow | Rare |
| `medium` | Moderate | Possible end of day |
| `high` | Fast | Timer visible |
| `critical` | Very fast | Must accept quickly |

Localization: `patient.urgency.<level>.label`

---

## Legal risk

| Status | Clinic exposure | Patient behavior |
|--------|-----------------|------------------|
| `legal` | Low | Pays premium for quality |
| `gray` | Medium | Default underground clinic |
| `illegal` | High | Illegal implant risk++, event hooks |

**Known:** Declared status on file (may be lie—hidden condition `false_papers`).

---

## Hidden conditions

Drawn 0–2 per patient from weighted pool; **never** shown until scan/deep scan/event.

| Condition | Effect (concept) |
|-----------|------------------|
| `neural_fragile` | Hidden neural penalty |
| `cybertox_sensitive` | CyberTox multiplier |
| `slot_conflict` | Implant compatibility − |
| `false_papers` | Legal status wrong |
| `budget_lie` | True ceiling lower |
| `implant_rejection` | Post-op complication weight |
| `panic_disorder` | Panic rises faster |
| `blacklisted` | Reputation hit on fail |

Localization: `patient.condition.<id>.revealed_name`, `.scan_hint`

---

## Visual traits

Procedural assembly of sprites/tints (Art: `Patients/`), no text in assets.

| Trait | Source |
|-------|--------|
| Silhouette variant | Archetype |
| Scar/cyberware overlays | Body problem |
| Neon accent color | Motivation |
| Glitch intensity | Hidden severity proxy (UI only pre-scan) |

---

## Dialogue tone

Maps to localized line pools:

| Tone | Use |
|------|-----|
| `aggressive` | Fighter, gang |
| `nervous` | Survival, high panic |
| `clinical` | Corp exile, medic |
| `smug` | Dealer, celebrity |
| `fragmented` | Netrunner glitch speak |

Keys: `dialogue.patient.<tone>.<###>`

---

## Known vs unknown information

| Field | Default known? | Reveal method |
|-------|----------------|---------------|
| Archetype name | Yes | — |
| Request description | Yes | — |
| Stated budget band | Yes | Scan → true ceiling |
| Urgency | Yes | — |
| Declared legal status | Yes | Scan → `false_papers` |
| Visual traits (surface) | Yes | — |
| Motivation (explicit) | Partial hint | Deep scan |
| Hidden conditions | No | Scan / deep scan |
| Exact tolerances | No | Scan |
| Slot conflict | No | Deep scan / operation preview |
| True panic baseline | No | Scan |

---

## How scanning reveals information

```
ScanRequest(patient, scanTier)
  → costs economy (money + time) via Economy module event
  → PatientRevealService applies reveal rules from SO tables
  → emits PatientInfoRevealed event
  → UI updates file; Risk preview module refreshes breakdown
```

| Tier | Typical reveals |
|------|-----------------|
| `basic` | 1 hidden condition OR tolerance band |
| `deep` | Remaining hidden + compatibility warning flag |

Scan does **not** mutate generation seed—it only flips visibility flags on runtime instance.

---

## Example generated patients

### Seed example 1

- `runSeed=84921`, `dayIndex=3`, `slot=0`
- **Output:** Underground fighter, motivation performance, arm_right reflex_booster, budget tight, hidden `neural_fragile`, urgency high, illegal gray.

### Seed example 2

- Same seed, `slot=1`
- **Output:** Corporate exile, aesthetic chrome, budget flush (true lower), hidden `false_papers`, urgency low.

---

## Data model notes (future ScriptableObjects)

### Definition assets (SO)

| Asset | Fields (conceptual) |
|-------|---------------------|
| `PatientArchetypeSO` | id, weights, visual deck refs, tone pool |
| `MotivationSO` | id, dialogue weights, reputation deltas |
| `BodyProblemSO` | slot, severity, visual overlay |
| `RequestTypeSO` | slot, procedure link, localization keys |
| `BudgetProfileSO` | band, stated range, ceiling distribution |
| `HiddenConditionSO` | id, math modifiers, reveal keys |
| `VisualTraitSO` | sprite refs, tint rules |
| `PatientGenerationConfigSO` | day weights, reputation gates |

### Runtime instance (plain C#)

| Field | Type |
|-------|------|
| `PatientId` | Guid |
| `Seed` | int |
| `ArchetypeId` | string |
| Components | Resolved refs + rolled values |
| `KnownFacts` | Bitset / dictionary |
| `RevealedFacts` | Bitset / dictionary |
| `DialogueState` | Runtime only |

**Never** store display strings on instance—keys only.

---

## Module boundaries

| Responsibility | Owner |
|----------------|-------|
| Generation from seed | `Patients/` generator |
| Reveal rules | `Patients/` + scan config SO |
| Display | `UI/` |
| Operation inputs | `Procedures/` reads patient DTO |
| Money for scan | `Economy/` listens to command |

---

## Acceptance criteria (Milestone 3)

- [ ] Deterministic patient from seed inputs
- [ ] All display via localization keys
- [ ] Known/unknown model with scan reveals
- [ ] SO pools for archetypes, motivations, conditions
- [ ] No UI in generator module
