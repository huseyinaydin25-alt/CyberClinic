# Milestone 13.11 — Patient Puzzle Shell Localization Keys

**Date:** 2026-05-27  
**Status:** Implemented, pending local Unity validation  
**Scope:** Centralize placeholder shell localization keys.

---

## Goal

M13.11 moves shell UI key strings into a small constants class so future localization binding has a cleaner base.

This does not add final localization tables or final player-facing copy.

---

## Added systems

- `PatientPuzzleShellLocalizationKeys`
- `PatientPuzzleShellLocalizationKeysValidator`

---

## Updated systems

- `PatientPuzzleShellRuntime`
- `PatientPuzzleShellPresenter`

---

## New editor menu

```text
Cyber Clinic/Slices/Run Patient Puzzle Shell Localization Keys Debug
```

---

## Expected validator output

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

- final localized copy
- localization table editing
- production UI
- final art
- animation system
- backend
- SDKs
- monetization
- content expansion

---

## Completion criteria

M13.11 is complete when the localization keys validator passes and existing shell presenter/runtime validators still pass.
