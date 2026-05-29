# Milestone 14.7 — Playable Shell Interaction Aggregate Validator

**Date:** 2026-05-29  
**Status:** Implemented, pending local Unity validation  
**Scope:** Add one aggregate validator for M14 Playable Shell Interaction Foundation.

---

## Goal

M14.7 adds a single validation entry point for the current Playable Shell Interaction foundation.

It verifies the complete M14 interaction stack together:

```text
Interaction Bridge
Preview Debug Interaction
Commit Debug Interaction
State Readout
Feedback Router
Preview / Commit Runtime Smoke
```

---

## Added validator

- `PatientPuzzlePlayableShellInteractionAggregateValidator`

---

## New editor menu

```text
Cyber Clinic/Slices/Run Patient Puzzle Playable Shell Interaction Aggregate Debug
```

---

## Expected validator output

```text
PatientPuzzlePlayableShellInteractionAggregateDebug OK
bridgeOk=True
previewOk=True
commitOk=True
readoutOk=True
feedbackOk=True
runtimeSmokeOk=True
previewState=Previewed/Available
commitState=Previewed/Committed
previewRoute=primary_action.feedback.previewed
commitRoute=primary_action.feedback.committed
uiBinding=playable_shell_interaction_aggregate_ready
```

---

## Regression checks

After this validator passes, run:

```text
Cyber Clinic/Slices/Run Patient Puzzle Primary Action Flow Aggregate Debug
Cyber Clinic/Slices/Run Patient Puzzle Shell Foundation Debug
Cyber Clinic/Slices/Run Patient Puzzle Shell End To End Debug
```

---

## Not included

- final UI
- final visual effects
- final audio effects
- final buttons
- runtime click handling
- final art
- animation system
- backend
- SDKs
- monetization
- content expansion

---

## Completion criteria

M14.7 is complete when the playable shell interaction aggregate validator passes and existing primary action flow / shell regressions still pass locally in Unity.
