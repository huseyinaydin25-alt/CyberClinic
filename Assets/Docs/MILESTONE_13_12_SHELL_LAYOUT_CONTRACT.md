# Milestone 13.12 — Patient Puzzle Shell Layout Contract

**Date:** 2026-05-27  
**Status:** Implemented, pending local Unity validation  
**Scope:** Centralize shell root names, section names, reference resolution, and layout anchors.

---

## Goal

M13.12 moves shell layout identifiers and anchor values into a small layout contract.

This keeps runtime UI construction and validators aligned around the same names and layout data.

---

## Added systems

- `PatientPuzzleShellLayout`
- `ShellAnchorRect`
- `PatientPuzzleShellLayoutValidator`

---

## Updated systems

- `PatientPuzzleShellRuntime`
- `PatientPuzzleShellDebugValidator`

---

## New editor menu

```text
Cyber Clinic/Slices/Run Patient Puzzle Shell Layout Debug
```

---

## Expected validator output

```text
PatientPuzzleShellLayoutDebug OK
contractOk=True
rootName=PatientPuzzleShellRoot
patientAreaName=PatientDossierArea
procedureAreaName=ProcedureDecisionArea
riskAreaName=RiskAnalysisArea
resultAreaName=OperationResultArea
feedbackAreaName=ActionFeedbackArea
referenceResolution=1920x1080
uiBinding=shell_layout_contract_ready
```

---

## Regression checks

After the layout validator passes, these should still pass:

```text
Cyber Clinic/Slices/Run Patient Puzzle Shell Debug
Cyber Clinic/Slices/Run Patient Puzzle Shell Presenter Debug
Cyber Clinic/Slices/Run Patient Puzzle Shell Localization Keys Debug
```

---

## Not included

- final UI
- final art
- animation system
- backend
- SDKs
- monetization
- content expansion

---

## Completion criteria

M13.12 is complete when the layout validator passes and existing shell debug/presenter/localization validators still pass.
