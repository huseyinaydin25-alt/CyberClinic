# Milestone 13.6 — Patient Puzzle Slice Data Consistency Validator

**Date:** 2026-05-27  
**Status:** Implemented, pending local Unity validation  
**Scope:** Add a validator that confirms the ViewModel and ScreenModel carry the same deterministic patient puzzle slice data.

---

## Goal

M13.6 locks the data chain before moving toward production-intent UI shell work.

It verifies that:

- `PatientPuzzleSliceViewModel` is valid
- `PatientPuzzleSliceScreenModel` is valid
- patient fields match between ViewModel and ScreenModel
- procedure fields match
- risk fields match
- result fields match
- feedback cue fields match
- deterministic debug slice values remain stable

---

## Added system

- `PatientPuzzleSliceDataConsistencyValidator`

---

## New editor menu

```text
Cyber Clinic/Slices/Run Patient Puzzle Slice Data Consistency
```

---

## Expected validator output

```text
PatientPuzzleSliceDataConsistency OK
viewModel=valid
screenModel=valid
patientMatch=True
procedureMatch=True
riskMatch=True
resultMatch=True
feedbackMatch=True
deterministicMatch=True
patientId=test_street_netrunner
selectedImplantId=test_implant_optic_tune
selectedProcedureId=test_proc_micro_install
riskBand=Uncertain
outcomeType=StableSuccess
creditsDelta=90
reputationDelta=5
visualCueId=test_cue_result_reveal
audioCueId=test_audio_operation_success
uiBinding=viewmodel_screenmodel_consistent
```

---

## Why this matters

The project now has multiple validated layers:

```text
Runner
Report
ViewModel
ScreenModel
Debug UGUI
```

Before building more UI, M13.6 ensures the intermediate UI-facing data layers remain synchronized and deterministic.

This protects future premium UI work from binding to mismatched or drifting data.

---

## Explicitly not added

- production UI
- UI prefabs
- final art
- animation/tween system
- VFX
- audio mixer
- backend
- SDKs
- monetization
- new content

---

## Next step after validation

After this validator passes locally, the next step can be a minimal production-intent UI shell plan or adapter that consumes `PatientPuzzleSliceScreenModel` without final art or animation.
