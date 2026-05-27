# Cyber Clinic — Premium UI Direction

**Date:** 2026-05-27  
**Status:** Direction document  
**Scope:** UI direction for future production-intent Cyber Clinic screens. This is not an implementation task and does not add production assets.

---

## Purpose

Cyber Clinic needs a UI language that matches its original product vision: a high-quality cyberpunk clinic game built around procedural cases, risk evaluation, implant work, clinic progression, and player desire.

The current UGUI playable slice is a debug foundation only. It proves the loop works, but it is not the intended final user experience.

This document defines the direction for future production-intent UI work before code, prefabs, animations, or art are expanded.

---

## Core UI fantasy

The player should feel like they are operating inside a high-end underground cyber-clinic interface.

The UI should feel:

- clinical but stylish
- technical but readable
- premium but not decorative for its own sake
- tense when risk is involved
- satisfying when a procedure succeeds
- systemic, layered, and procedural
- original to Cyber Clinic

The UI must not look like a generic mobile form, spreadsheet, or simple debug dashboard.

---

## Main screen pillars

Future production-intent UI should be organized around clear screen pillars:

### Patient intake

Purpose:

- reveal patient identity, case type, constraints, urgency, and procedural context
- present generated patient details as authored-feeling case material

Core UI needs:

- patient dossier
- clinical notes
- procedural constraints
- risk modifiers
- case rarity or special flags

### Implant / procedure selection

Purpose:

- make implant and procedure choices feel tactical and meaningful
- communicate compatibility, cost, risk, and expected payoff

Core UI needs:

- implant card
- procedure card
- compatibility indicators
- cost and projected reward
- requirements and warnings

### Risk analysis

Purpose:

- turn calculation results into readable decision pressure
- make the player understand what they are risking before committing

Core UI needs:

- preview success chance
- commit success chance
- risk band
- modifiers
- warning states
- confidence / uncertainty presentation

### Operation result

Purpose:

- make the outcome satisfying, readable, and emotionally clear

Core UI needs:

- outcome reveal
- credit delta
- reputation delta
- visual/audio cue presentation
- saved state summary when needed
- next-step affordance

### Clinic progression

Purpose:

- create long-term desire to continue, improve, customize, and return

Core UI needs:

- clinic status
- reputation track
- day flow
- upgrades
- cosmetics
- equipment and room identity
- collection/progression surfaces

---

## Visual direction principles

The future UI should use:

- layered panels rather than flat blocks
- strong hierarchy between primary decisions and supporting data
- restrained but expressive color coding
- dark premium base with controlled glow accents
- clinical spacing and precision
- subtle cyberpunk texture without reducing readability
- meaningful warning and success states
- strong typography scale
- high contrast for mobile readability

Debug keys may remain visible only in debug tools. Production-facing UI must use localized strings and readable labels.

---

## Motion and feedback principles

Every important action should eventually have feedback.

Examples:

- Preview: quick scan / calculation feedback
- Commit: stronger confirmation and operation sequence feedback
- Risk change: warning pulse or focused highlight
- Outcome reveal: deliberate reveal timing
- Credit/reputation delta: animated value change
- Visual cue: routed to appropriate UI/VFX layer
- Audio cue: routed to SFX feedback layer

Motion should support comprehension. It should not slow the player down or hide information.

---

## Layout principles

The production UI should avoid simply expanding the current debug layout.

Preferred direction:

- a focused patient dossier area
- a tactical decision area for implant/procedure
- a dedicated risk analysis area
- a dramatic operation/result area
- persistent economy/reputation/day context
- clear primary action affordance

The player should always know:

1. who the patient is
2. what procedure is being considered
3. what the risk is
4. what the potential result is
5. what action is available now

---

## Localization discipline

Player-facing strings should be represented as localization keys or wired through localization-ready structures.

Debug-only tooling may show raw ids or keys when useful.

Production-intent UI must avoid hardcoded player-facing English/Turkish labels unless the relevant localization plan explicitly allows temporary placeholders.

---

## Technical direction

Before creating production prefabs, future implementation should decide:

- UGUI vs UI Toolkit for production screens
- whether a tween/animation package will be used
- how localization keys are bound to UI labels
- how patient/procedure/result view models are structured
- how UI validators will confirm required bindings
- how mobile resolution and safe areas are handled

For now, UGUI remains acceptable for debug and early playable slice validation.

---

## Do not do yet

Do not jump directly into:

- final production screen prefabs
- final art pass
- large animation systems
- SDK integration
- backend calls
- monetization screens
- store screens
- content scale-up

The next code milestone should still be small and validated.

---

## Recommended next implementation milestone

M13.2 should be a production-intent UI architecture probe, not final UI.

Possible scope:

- create a small view-model layer for the playable slice result
- keep the existing debug UI intact
- add tests/validators for the view-model
- prove that patient/risk/result data can drive a cleaner future UI without binding directly to raw debug strings

This would bridge the current debug slice and future premium UI without prematurely building final screens.
