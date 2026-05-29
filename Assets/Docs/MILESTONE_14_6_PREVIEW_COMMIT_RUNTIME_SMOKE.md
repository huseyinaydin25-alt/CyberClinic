# Milestone 14.6 — Preview / Commit Runtime Smoke Validator

**Date:** 2026-05-29  
**Status:** Implemented, pending local Unity validation  
**Scope:** Add one smoke validator for Preview and Commit runtime interaction flow.

---

## Goal

M14.6 verifies Preview and Commit debug interactions together against state-aware shell runtime rendering, feedback routing, and readout tokens.

This is the final smoke layer before grouping M14 primary action interaction foundation into an aggregate validator.

---

## Added validator

- `PatientPuzzlePreviewCommitRuntimeSmokeValidator`

---

## New editor menu

```text
Cyber Clinic/Slices/Run Patient Puzzle Preview Commit Runtime Smoke Test
```

---

## Smoke coverage

```text
Preview debug interaction -> Previewed/Available
Preview shell runtime     -> renders Previewed/Available
Preview feedback route    -> primary_action.feedback.previewed
Preview readout token     -> primary_action.visual.previewed

Commit debug interaction  -> Previewed/Committed
Commit shell runtime      -> renders Previewed/Committed
Commit feedback route     -> primary_action.feedback.committed
Commit readout token      -> primary_action.visual.committed
```

---

## Expected validator output

```text
PatientPuzzlePreviewCommitRuntimeSmoke OK
previewInteractionId=primary_action.preview
previewState=Previewed/Available
previewRoute=primary_action.feedback.previewed
previewToken=primary_action.visual.previewed
previewRuntimeOk=True
commitInteractionId=primary_action.commit
commitState=Previewed/Committed
commitRoute=primary_action.feedback.committed
commitToken=primary_action.visual.committed
commitRuntimeOk=True
uiBinding=preview_commit_runtime_smoke_ready
```

---

## Regression checks

After this validator passes, run:

```text
Cyber Clinic/Slices/Run Patient Puzzle Primary Action Feedback Router Debug
Cyber Clinic/Slices/Run Patient Puzzle Primary Action State Readout Debug
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

M14.6 is complete when the Preview / Commit runtime smoke validator passes and existing feedback router / readout / primary action flow / shell regressions still pass locally in Unity.
