# Tutorial Design — First-Time User Experience

This document defines the first-time tutorial for **Cyber Clinic**. The tutorial is a core retention system, not a disposable onboarding overlay.

---

## Why this matters

Cyber Clinic is a niche medical-management puzzle with incomplete information, risk math, implants, scans, economy, reputation, legal danger, and visual feedback. A new player can easily feel overwhelmed if all systems appear at once.

The first tutorial must prevent this by teaching the game through a controlled, atmospheric first case.

**Goal:** make the player feel, from the first minutes, that they are operating a cyberpunk clinic—not reading a manual.

---

## Core tutorial principle

> Teach one decision at a time, inside the fiction, with strong visual and audio feedback.

The tutorial should not feel like:

- a chain of generic popups
- a forced checklist
- a wall of explanatory text
- a separate fake mode disconnected from the real game

It should feel like the player’s first night in the clinic.

---

## First-time experience target

The first session should deliver these emotions in order:

1. **Atmosphere** — rain, neon, clinic hum, old machine boot.
2. **Curiosity** — first patient arrives with a clear request.
3. **Control** — player opens the patient file and sees understandable data.
4. **Discovery** — scan reveals one hidden risk.
5. **Tension** — player sees risk/profit/reputation tradeoff.
6. **Commitment** — player chooses an operation plan.
7. **Payoff** — operation result is revealed with strong VFX/SFX.
8. **Confidence** — player understands the loop and wants the next patient.

---

## Tutorial case design

### First patient profile

The first patient should be simple enough to teach, but atmospheric enough to sell the world.

Possible tutorial patient:

- Archetype: street netrunner / courier / underground runner
- Request: basic reflex booster or neural stabilizer
- Budget: limited but not impossible
- Hidden condition: mild neural instability revealed by scan
- Legal risk: low or gray-market, not full illegal
- Urgency: medium
- Outcome target: stable success if player follows scan guidance

### Why this works

- It introduces body upgrade fantasy.
- It introduces scan value without punishing the player harshly.
- It teaches cheap vs safer implant choice.
- It allows a controlled operation result.
- It can show CyberTox / neural load in a readable way.

---

## Mechanics introduction order

Do not introduce everything at once.

Recommended order:

1. Clinic boot / first patient arrives
2. Patient file panel
3. Visible request and budget
4. Accept patient
5. Basic scan
6. Hidden risk reveal
7. Implant choice
8. Risk preview
9. Operation commit
10. Result reveal
11. Money/reputation update
12. Day progression hint

Deep scan, illegal implants, complications, ads, IAP, event calendars, and advanced clinic progression are **not** part of the first tutorial unless explicitly redesigned later.

---

## UI guidance system

Tutorial guidance should use:

- soft UI highlights
- animated arrows or scan pulses
- temporary interaction locks only when necessary
- short localized prompts
- diegetic system messages where possible
- patient dialogue lines for flavor
- audio confirmation for correct interactions

Avoid blocking the player with long modal text.

---

## Localization requirements

All tutorial text uses localization keys. No hardcoded tutorial copy.

String table group: `Tutorial`

Example keys:

- `tutorial.intro.clinic_boot.001`
- `tutorial.prompt.open_patient_file`
- `tutorial.prompt.scan_patient`
- `tutorial.prompt.choose_implant`
- `tutorial.prompt.review_risk`
- `tutorial.prompt.start_operation`
- `tutorial.result.first_success`
- `tutorial.replay.title`

Tutorial dialogue should use the same localization system as normal patient dialogue.

---

## Skip and replay policy

- Tutorial should be replayable from settings or help menu.
- First-time skip may be allowed only after the player has seen the opening beat, but this is a product decision to confirm later.
- If skipped, the game must still initialize the same baseline progression flags safely.

---

## Visual/audio requirements

The tutorial must showcase the visual/audio identity early:

- clinic boot glitch
- patient card slide-in
- scanline reveal
- risk pulse
- operation commit sound
- result reveal animation
- success/failure tone
- rain/clinic ambience

These are not polish; they teach the player what matters.

---

## Done criteria for tutorial design milestone

- First patient tutorial case defined
- Tutorial flow mapped screen by screen
- UI highlight rules defined
- Tutorial localization keys planned
- Replay/skip policy decided
- VFX/SFX needs listed
- No gameplay implementation begins until this document is accepted
