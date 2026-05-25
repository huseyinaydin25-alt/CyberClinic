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

## Tutorial design pillars

1. **Atmosphere first** — The first thirty seconds must sell the clinic: rain, neon, old medical hardware, unstable UI boot, and a patient at the door.
2. **One concept at a time** — Do not expose every stat, button, risk, and system at once.
3. **Controlled real decision** — The player must make a real choice, but the first case should be tuned so a reasonable player reaches a stable result.
4. **Minimal text, strong feedback** — Short prompts, UI highlights, scan animation, warning pulse, and audio cues do most of the teaching.
5. **No fake tutorial-only rules** — The tutorial should use the same system concepts as the real game, only with constrained data.
6. **Replayable and localizable** — Tutorial must be replayable and every player-facing line must use localization keys.

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

## First tutorial case — canonical draft

### Case name

**Case 001 — The Runner at the Door**

This is the first real patient interaction.

### Patient concept

A young street courier/netrunner arrives during a rainstorm. They need a reflex upgrade before dawn. They are not a corporate VIP and not a full illegal case; they are street-level, readable, urgent, and visually compatible with the back-alley clinic fantasy.

### Patient data draft

| Field | Tutorial value |
|------|----------------|
| Archetype | `street_netrunner` or `street_courier` |
| Request | reflex booster / neural stabilizer |
| Body slot | arm or spine-adjacent neural slot, depending on final implant set |
| Budget | low-to-medium; enough for safe tutorial implant, not enough for luxury option |
| Visible urgency | medium-high |
| Legal status | gray-market, not full illegal |
| Visible trait | rain-soaked coat, trembling hand, old cable scar |
| Hidden condition | mild neural instability |
| Scan reveal | neural load warning |
| Target lesson | scanning reveals hidden risk; safer implant is better than maximum profit |
| Expected outcome | stable success if player follows guidance |

### Why this patient works

- Introduces cyber body upgrade fantasy.
- Shows that patient statements are incomplete.
- Teaches scan value without harsh punishment.
- Shows risk preview in a readable way.
- Introduces profit vs safety without overwhelming economy.
- Can succeed with strong feedback and give the player confidence.

---

## Tutorial beat map

### Beat 0 — Cold open / clinic boot

**Purpose:** establish atmosphere and UI identity.

What happens:

- Landscape screen starts dark.
- Rain ambience fades in.
- Clinic machine boot sound plays.
- Holographic UI flickers on.
- System line appears briefly: clinic initializing.

Player action:

- None or tap to continue after boot.

Teaching:

- This is a cyberpunk medical interface.
- The game will communicate through UI and feedback.

Localization keys:

- `tutorial.intro.clinic_boot.001`
- `system.boot.initializing`
- `system.boot.ready`

Visual/audio:

- boot glitch
- neon pulse
- low electrical hum
- rain ambience

---

### Beat 1 — First patient arrives

**Purpose:** introduce the patient queue and intake.

What happens:

- Door/notification sound.
- Patient card slides in from side.
- Patient portrait/body silhouette appears.
- Patient says a short line.

Player action:

- Tap patient card / open patient file.

Teaching:

- Patients arrive as cases.
- Each case has a file.

Localization keys:

- `tutorial.prompt.open_patient_file`
- `dialogue.tutorial.runner.arrival.001`

Visual/audio:

- patient card slide-in
- soft highlight on file button/card
- door chime or clinic buzzer

---

### Beat 2 — Patient file overview

**Purpose:** introduce visible information only.

Visible fields:

- request
- budget band
- urgency
- legal status
- obvious visual trait

Hidden fields are not yet shown.

Player action:

- Read file, then tap Accept.

Teaching:

- The patient file is not the whole truth.
- Visible info is enough to start, not enough to operate safely.

Localization keys:

- `tutorial.prompt.review_patient_file`
- `ui.button.accept_patient`
- `patient.status.gray_market`

Visual/audio:

- file panel opens with paper/hologram hybrid animation
- important fields pulse one by one

---

### Beat 3 — Accept patient

**Purpose:** introduce intake decision.

What happens:

- Player accepts the tutorial patient.
- Patient moves from queue to active case area.
- UI unlocks Scan action.

Player action:

- Tap Accept.

Teaching:

- Accepting a patient commits clinic time.
- Later patients may be rejected, but tutorial focuses on accepting.

Localization keys:

- `tutorial.prompt.accept_patient`
- `ui.button.accept_patient`

Visual/audio:

- case accepted stamp animation
- low confirmation beep

---

### Beat 4 — Basic scan

**Purpose:** teach investigation and hidden information reveal.

What happens:

- Scan button is highlighted.
- Player starts Basic Scan.
- Scanline passes over patient silhouette/body area.
- One hidden risk is revealed: mild neural instability.

Player action:

- Tap Scan.

Teaching:

- Scans cost time/resources later, but reveal crucial hidden information.
- Hidden risk changes the operation plan.

Localization keys:

- `tutorial.prompt.scan_patient`
- `ui.operation.scan`
- `warning.neural_load.detected`

Visual/audio:

- scanline sweep
- body slot glow
- risk panel unlock
- scan complete beep

---

### Beat 5 — Choose implant

**Purpose:** introduce choice between profit and safety.

Options should be constrained to three choices:

1. **Cheap Reflex Booster** — high margin, higher neural load.
2. **Standard Neural Stabilizer** — safer, lower profit.
3. **Prototype/Locked/Unavailable option** — visible but not selectable or clearly not recommended.

Player action:

- Choose one implant.

Tutorial behavior:

- The standard option is recommended by scan results.
- Cheap option remains selectable if we want player agency, but the first tutorial may softly warn instead of hard-locking.
- Illegal option is not introduced yet unless visually teased as locked for later.

Teaching:

- Best profit is not always best plan.
- Risk preview helps interpret the decision.

Localization keys:

- `tutorial.prompt.choose_implant`
- `implant.tier.cheap`
- `implant.tier.quality`
- `ui.operation.success_chance`

Visual/audio:

- implant cards slide in
- selected card glows
- risk meter changes as selection changes

---

### Beat 6 — Risk preview

**Purpose:** teach operation math without showing all math.

What happens:

- Risk preview panel shows simplified bands.
- The player sees neural load and success chance trend.
- The tutorial points to the safer plan.

Player action:

- Review risk panel, then continue.

Teaching:

- Operation result is based on patient condition + implant choice + procedure risk.
- Risk is readable through bands, not raw formulas.

Localization keys:

- `tutorial.prompt.review_risk`
- `ui.operation.risk`
- `operation.risk.safe`
- `operation.risk.uncertain`
- `operation.risk.dangerous`

Visual/audio:

- risk band pulse
- warning color shift
- subtle heartbeat if risk rises

---

### Beat 7 — Operation commit

**Purpose:** teach commitment moment.

What happens:

- Player taps Operate.
- Operation sequence begins.
- UI dims; operation panel takes focus.
- Result is deterministic and tuned to success if recommended path was followed.

Player action:

- Tap Operate.

Teaching:

- After commit, decision is locked.
- The operation result is a dramatic reveal.

Localization keys:

- `tutorial.prompt.start_operation`
- `ui.operation.operate`

Visual/audio:

- operation table light surge
- sound drop
- mechanical hum
- short anticipation pause

---

### Beat 8 — Result reveal

**Purpose:** reward, feedback, and clarity.

What happens:

- Operation succeeds.
- Stable status appears.
- Patient reaction/short line.
- Money and reputation update gently.

Player action:

- Tap continue after result.

Teaching:

- Decisions produce consequences.
- Success affects money and reputation.
- The loop is complete.

Localization keys:

- `tutorial.result.first_success`
- `operation.outcome.success`
- `economy.money.gained`
- `economy.reputation.gained`

Visual/audio:

- stable pulse
- clean success beep
- subtle positive UI animation
- money/reputation tick animation

---

### Beat 9 — Next patient hint

**Purpose:** transition from tutorial to normal gameplay.

What happens:

- UI shows day still has time.
- System hints that future patients may hide worse risks.
- Player is invited to continue.

Player action:

- Continue to main loop.

Teaching:

- The game will now open up gradually.
- More complex systems will appear later.

Localization keys:

- `tutorial.prompt.next_patient_hint`
- `ui.common.continue`

Visual/audio:

- queue indicator lights up
- ambience returns to normal

---

## What the first tutorial must NOT include

Do not include these in the first tutorial unless this document is deliberately revised:

- Deep scan
- Full complication chain
- Full illegal implant system
- Ad prompts
- IAP or cosmetic store
- Supabase/cloud save
- Daily events
- Leaderboards
- Multiple simultaneous patients
- Clinic upgrade shop
- Complex reputation tiers
- Advanced surgery minigames

These systems can be taught later through follow-up tutorial beats or contextual help.

---

## UI guidance system

Tutorial guidance should use:

- soft UI highlights
- animated arrows only when necessary
- scan pulses
- temporary interaction locks only when the wrong action would break tutorial flow
- short localized prompts
- diegetic system messages where possible
- patient dialogue lines for flavor
- audio confirmation for correct interactions

Avoid blocking the player with long modal text.

### Interaction locking rule

Lock only what must be locked.

Good:

- During Beat 4, only Scan is active because scan is the lesson.
- During operation reveal, input is paused until animation completes.

Bad:

- Locking every button for the entire tutorial.
- Forcing the player through long explanations before letting them inspect the UI.

---

## Skip and replay policy

Recommended policy:

- First launch: tutorial is strongly recommended and starts automatically after intro.
- Skip is available after the opening clinic boot, not before the player sees context.
- Skip button should not be visually dominant.
- Tutorial is replayable from Settings / Help.
- If skipped, baseline flags must be initialized safely:
  - tutorial seen flag
  - first day unlocked
  - first clinic state created
  - default localization state intact

Final skip policy remains a product decision, but replayability is required.

---

## Localization requirements

All tutorial text uses localization keys. No hardcoded tutorial copy.

String table group: `Tutorial`

Additional recommended keys beyond current seed:

- `tutorial.prompt.review_patient_file`
- `tutorial.prompt.accept_patient`
- `tutorial.prompt.next_patient_hint`
- `tutorial.warning.scan_revealed_neural_instability`
- `tutorial.explain.visible_info`
- `tutorial.explain.hidden_info`
- `tutorial.explain.risk_preview`
- `tutorial.explain.operation_locked`
- `tutorial.skip.confirm_title`
- `tutorial.skip.confirm_body`
- `tutorial.replay.description`

Dialogue keys can live in `Dialogue` later or in `Tutorial` initially:

- `dialogue.tutorial.runner.arrival.001`
- `dialogue.tutorial.runner.scan_reaction.001`
- `dialogue.tutorial.runner.success.001`

If a Dialogue table is created later, migrate dialogue keys deliberately and update docs.

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

### Required tutorial feedback map

| Tutorial beat | Required feedback |
|--------------|-------------------|
| Clinic boot | glitch, neon pulse, boot hum |
| Patient arrival | door/buzzer sound, card slide-in |
| File opened | panel unfold, field highlights |
| Scan | scanline, body slot glow, scan complete beep |
| Risk reveal | warning pulse, risk band color shift |
| Implant selected | card glow, risk preview change |
| Operation commit | dim UI, table light, mechanical hum |
| Success | stable pulse, clean beep, money/reputation tick |

---

## Data model implications

Milestone 1 already created tutorial data contracts. Later implementation should use:

- `TutorialCaseData`
- `TutorialSequenceData`
- `TutorialStepData`
- `TutorialProgressState`

Do not hardcode the tutorial flow into scene scripts. The sequence should be data-driven enough that future tutorial cases can be added.

---

## Acceptance criteria for Milestone 1.5

Milestone 1.5 is complete when:

- first tutorial case is accepted as canonical draft
- beat map is documented
- mechanics introduction order is clear
- what not to include in first tutorial is clear
- tutorial localization key gaps are listed
- visual/audio requirements are listed
- skip/replay policy is drafted
- no gameplay implementation is created

---

## Next implementation milestone dependency

Before implementing tutorial runtime, the following must exist:

1. Localization foundation — done in M2.
2. Basic patient generator — M3.
3. Basic implant/procedure definitions — M4.
4. Operation math — M5.
5. UI skeleton — M6.
6. Visual/audio foundations — M7/M8.

The tutorial runtime should not be implemented before enough real systems exist to avoid fake one-off tutorial code.
