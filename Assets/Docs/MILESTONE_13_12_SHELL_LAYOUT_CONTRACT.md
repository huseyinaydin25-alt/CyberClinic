# Milestone 13.12 — Patient Puzzle Shell Layout Contract

**Date:** 2026-05-27  
**Status:** Validated locally in Unity  
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

## Validated layout output

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

## Existing shell validator still passes

```text
PatientPuzzleShellDebug OK
rootExists=True
canvasCount=1
eventSystemCount=1
patientArea=True
procedureArea=True
riskArea=True
resultArea=True
feedbackArea=True
patientBinding=True
procedureBinding=True
riskBinding=True
resultBinding=True
feedbackBinding=True
uiBinding=production_intent_shell_placeholder
```

---

## Existing presenter validator still passes

```text
PatientPuzzleShellPresenterDebug OK
patientPresentation=True
procedurePresentation=True
riskPresentation=True
resultPresentation=True
feedbackPresentation=True
uiBinding=shell_presenter_decoupled
```

---

## Existing localization keys validator still passes

```text
PatientPuzzleShellLocalizationKeysDebug OK
keysOk=True
shellTitle=ui.shell.patient_puzzle.title
patientDossierTitle=ui.shell.patient_dossier.title
procedureDecisionTitle=ui.shell.procedure_decision.title
riskAnalysisTitle=ui.shell.risk_analysis.title
operationResultTitle=ui.shell.operation_result.title
actionFeedbackTitle=ui.shell.action_feedback.title
uiBinding=shell_localization_keys_ready
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

## Completion result

M13.12 is complete because the layout validator passed and existing shell debug, presenter, and localization validators still passed locally in Unity.
