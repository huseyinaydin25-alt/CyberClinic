# Milestone 13 — Premium Vertical Slice Direction Plan

**Date:** 2026-05-27  
**Status:** Planned  
**Scope:** Direction and immediate next steps after the validated UGUI debug playable slice.

---

## Goal

Milestone 13 starts the transition from a validated debug playable slice toward a premium-feeling Cyber Clinic vertical slice.

This is not a move into final production art, SDKs, backend, monetization, or large content expansion. It is the beginning of turning the validated systems into a readable, satisfying, commercially serious game-feel layer.

---

## Product direction constraint

Cyber Clinic remains its own original game.

The target quality bar is large-budget production seriousness: polish, discipline, readability, atmosphere, systemic depth, and long-term scalability. This is a scale and quality reference only, not a creative imitation reference.

---

## M13 priorities

1. Make the current playable UGUI slice more readable.
2. Add clear action feedback for Preview and Commit.
3. Add debug-only readouts that expose outcome, economy delta, reputation delta, and cue routing.
4. Preserve deterministic testability.
5. Preserve localization-key discipline for player-facing text.
6. Avoid production art, SDK, backend, monetization, and large content expansion.

---

## Immediate implementation steps

### M13.1 — Debug action readout

Add a UGUI readout that shows the last action result in a compact, readable form:

- lastAction
- stateId
- outcomeType
- riskBand
- credits delta
- reputation delta
- visualCueId
- audioCueId

This should remain debug-only and runtime-generated.

### M13.2 — Smoke-test action readout

Extend the UGUI runtime smoke validator so it verifies the readout updates after Preview and Commit.

### M13.3 — Production UI direction document

Before adding real production UI assets, create a UI direction document covering:

- screen hierarchy
- cyber-clinic visual language
- panel rhythm
- motion principles
- feedback rules
- localization approach
- mobile readability constraints

### M13.4 — First premium-style UI foundation

Only after M13.1–M13.3 are validated, start a separate production-intent UI foundation. It should still use placeholders, but with cleaner layout architecture and better screen intent.

---

## Explicitly out of scope for M13.1

- production UI
- final art
- animation system
- VFX Graph
- real audio mixer setup
- Supabase SDK
- RevenueCat SDK
- AdMob SDK
- save slot UI
- large patient/implant/procedure content expansion
- store configuration

---

## Validation target for M13.1

Expected editor validation:

```text
PlayableSliceUguiRuntimeSmokeValidator OK
rootExists=True
canvasCount=1
eventSystemCount=1
cameraExists=True
previewButtonCount=1
commitButtonCount=1
previewStateAfterPreview=ui.slice.preview.state.active
commitStateAfterCommit=ui.slice.commit.state.active
actionReadoutAfterCommitContains=lastAction=commit
uiMode=UGUI
```

Expected manual validation:

- UGUI scene opens in Play Mode.
- Preview and Commit buttons still work.
- State chips still change.
- A clear debug readout displays the latest action result.
- No Unity Console errors.

---

## Completion criteria

M13.1 is complete when:

- action readout exists in the UGUI debug scene
- Preview updates the readout
- Commit updates the readout
- smoke validator confirms Commit readout update
- documentation is updated
- no production scope has been added
