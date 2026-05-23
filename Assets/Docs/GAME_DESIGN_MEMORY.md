# Cyber Clinic — Game Design Memory

**Permanent design memory** for the project. This document is the authoritative creative and systems reference before and during implementation. If code diverges from this memory, **update this document first** or fix the code—never silently drift.

**Related docs:** `ROADMAP.md`, `PROCEDURAL_PATIENT_SYSTEM.md`, `OPERATION_MATH.md`, `VISUAL_AUDIO_DIRECTION.md`, `LOCALIZATION_PLAN.md`, `PLATFORM_SERVICES_PLAN.md`

---

## High concept

**Cyber Clinic** is a **2D stylized cyberpunk medical management puzzle** for mobile (Android + iOS). The player runs an underground cyber-clinic in a rain-soaked neon city, accepting procedural patients who want illegal or borderline implants, diagnosing incomplete information, and performing high-stakes operations where **profit, safety, and reputation** constantly conflict.

---

## Player fantasy

You are not a hero doctor—you are a **clinic operator** surviving in a corrupt medical gray market:

- Read desperate patients like case files.
- Decide who enters your clinic and who you turn away.
- Investigate with scans when money and time allow.
- Choose cheap, quality, or illegal implants and live with the math.
- Watch your clinic reputation and bank account react to every call.

The fantasy is **control under uncertainty**: smart bets, brutal failures, and a clinic that remembers your reputation.

---

## Emotional tone

| Element | Direction |
|---------|-----------|
| Setting | Dark clinic, neon accents, rain, holographic UI |
| Mood | Medical noir—clinical, tense, slightly cynical |
| Humor | Dry, situational—not slapstick |
| Failure | Glitchy, alarming, consequential—not cartoon deaths |
| Success | Clean scan reveals, stable hums, earned relief |

Visual effects, animation, UI motion, SFX, and ambience are **core gameplay feedback**, not polish added at the end.

---

## Core gameplay question

> **Given this patient's request, budget, tolerance, hidden conditions, clinic capabilities, and legal risk, what operation plan creates the best balance between profit, safety, and reputation?**

The player is **not** simply picking an implant from a list. They are solving an **incomplete-information medical-risk-economy puzzle**.

---

## The core puzzle (canonical)

### What the player solves

An **incomplete-information medical-risk-economy puzzle** where every decision has second-order effects:

1. **Patient intake** — Accept or reject based on visible file, gut feel, and clinic capacity.
2. **Investigation** — Scan (cost/time) to reveal hidden traits, conditions, or contradictions.
3. **Planning** — Match requested upgrade to body slots, implant tier, legality, and procedure difficulty.
4. **Risk assessment** — Read operation math breakdown (CyberTox, neural load, panic, illegal risk).
5. **Execution** — Commit to operation; outcome is deterministic from inputs + seed variance band.
6. **Consequences** — Money, reputation, complications, and day flow update through separate modules.

### What information is visible (known)

Typically shown on the patient file without scanning:

- Archetype presentation (silhouette, card framing)
- Stated request (upgrade type, body region)
- Stated budget range (may be vague band)
- Stated urgency / patience meter
- Legal status flag (declared)
- Visible visual traits (scars, obvious cyberware)
- Dialogue tone samples (localized lines)
- Clinic-visible reputation impact hints

Exact fields are defined in `PROCEDURAL_PATIENT_SYSTEM.md` (Known vs Unknown).

### What information is hidden (unknown until revealed)

- True hidden conditions (allergy analogs, neural fragility, etc.)
- Exact budget ceiling vs stated range
- True tolerance for CyberTox / neural load
- Undeclared illegal history or implant conflicts
- Contradictions between request and body state
- Some motivation subtext (greed vs desperation)

### How the player investigates

| Action | Cost | Reveals |
|--------|------|---------|
| **No scan** | Time saved; higher risk | Only known file fields |
| **Basic scan** | Money + time | 1–2 hidden fields or risk hints |
| **Deep scan** | More money + time | Additional hidden condition probability, compatibility warnings |

Scan results feed **UI** and **risk preview**—they do not change operation math retroactively after commit; they inform the plan before operation lock-in.

---

## Decision layers

### Accept / reject patient

- **Accept** — Patient enters queue; slot consumed; opportunity cost for the day.
- **Reject** — Small reputation hit or none (by archetype); avoids risk; may forfeit profit.

Tradeoff: Fill clinic with high-profit risky patients vs protect reputation and resources.

### Scan / no scan

- **Scan** — Spend money and day time; reduce unknowns; better risk preview.
- **No scan** — Save resources; rely on visible info; higher catastrophe chance.

Tradeoff: Information vs economy vs day length.

### Cheap / quality / illegal implant

| Tier | Profit | Risk | Reputation | Legal |
|------|--------|------|------------|-------|
| Cheap | High margin | Higher failure, CyberTox | Neutral/low | Gray |
| Quality | Lower margin | Lower technical risk | Positive | Safer |
| Illegal | Highest margin | Illegal implant risk spike | High reward/loss | Raid/event risk |

Tradeoff: Short-term cash vs long-term clinic brand vs operation safety.

### Safety / profit / reputation

Every operation plan sits on a triangle:

```
        Safety
         /\
        /  \
       /    \
      /______\
   Profit    Reputation
```

No single “correct” answer—archetypes and day events shift optimal strategy.

---

## Patient pressure and urgency

- **Urgency** increases patience decay on the patient file.
- High urgency patients may leave if kept waiting (planned event).
- Panic rises during operation preview if risk band is Dangerous/Critical.
- Pressure forces imperfect decisions—scan everything and you may lose the patient.

---

## Long-term clinic progression

- Unlock better **equipment** (operation math modifier).
- Expand **clinic skills** (base success bonus).
- Reputation tiers unlock patient archetypes and event types.
- Meta economy: reinvest scans vs savings vs illegal windfalls.
- Save-backed day index and persistent reputation (Milestone 9–10).

---

## Example patient cases

### Case A — Underground fighter, reflex booster

- **Visible:** High urgency, medium budget band, arm slot request, aggressive dialogue tone.
- **Hidden (scan):** Neural stability lower than stated; cheap spine-adjacent implant risky.
- **Puzzle:** Quality implant eats margin; cheap risks Critical neural band; reject loses day profit.

### Case B — Corporate exile, aesthetic chrome

- **Visible:** High budget, low urgency, legal-looking request, polished visual traits.
- **Hidden:** Undeclared CyberTox sensitivity; illegal prior implant in same slot.
- **Puzzle:** Deep scan costly but reveals incompatibility; illegal tier tempting for margin.

### Case C — Street netrunner, neural spine

- **Visible:** Low budget, illegal-friendly archetype, holographic UI request flavor.
- **Hidden:** None severe—motivation is performance; tolerance high.
- **Puzzle:** Teaching case for safe profit; reputation gain if handled cleanly.

---

## Replayability

| Source | Why it varies |
|--------|----------------|
| **Deterministic procedural patients** | Seed + day index → different archetype mixes |
| **Hidden condition draws** | Same archetype, different reveals |
| **Implant/procedure combos** | Compatibility matrix choices |
| **Clinic events** | Blackouts, raids, supply shocks |
| **Economy/reputation state** | Optimal strategy shifts over campaign |
| **Risk variance band** | Same plan, edge outcomes in Uncertain band |

---

## What must never be lost during development

These are **non-negotiable** design pillars—regression here breaks the game identity:

1. **Incomplete-information puzzle** — Always ask the core gameplay question; never reduce to “pick best implant stat.”
2. **Accept / scan / implant / operate flow** — Distinct player beats with meaningful tradeoffs.
3. **Deterministic operation math** — Same inputs + seed → same outcome; see `OPERATION_MATH.md`.
4. **Visual + audio feedback on every major action** — See `VISUAL_AUDIO_DIRECTION.md`.
5. **No hardcoded player-facing text** — See `LOCALIZATION_PLAN.md`.
6. **Modular, data-driven systems** — ScriptableObjects + decoupled modules; see `README_ARCHITECTURE.md`.
7. **Platform SDK isolation** — See `PLATFORM_SERVICES_PLAN.md`.
8. **Separation of calculation vs presentation** — OperationCalculator does not touch money/reputation/save directly.

---

## Module map (design → code)

| Design area | Doc | Future module |
|-------------|-----|----------------|
| Patients | `PROCEDURAL_PATIENT_SYSTEM.md` | `Patients/`, `ScriptableObjects/Patients/` |
| Operations | `OPERATION_MATH.md` | `Procedures/`, `Complications/` |
| Implants | `ROADMAP.md` M4 | `Implants/` |
| Economy/day | `ROADMAP.md` M9 | `Economy/`, `Events/` |
| Feedback | `VISUAL_AUDIO_DIRECTION.md` | `Visual/`, `Audio/` |
| Copy | `LOCALIZATION_PLAN.md` | `Localization/` |
| Stores/ads | `PLATFORM_SERVICES_PLAN.md` | `PlatformServices/` |

---

## Update protocol

When changing a system design:

1. Edit the relevant design memory doc.
2. Note the change in `CHANGELOG.md` and `DECISIONS.md` if architectural.
3. Update `ROADMAP.md` milestone acceptance criteria if scope shifts.
4. Only then implement or instruct Cursor to implement.
