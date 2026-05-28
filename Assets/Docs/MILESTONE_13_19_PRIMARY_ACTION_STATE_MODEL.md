# Milestone 13.19 — Primary Action State Model

**Date:** 2026-05-28  
**Status:** Implemented, pending local Unity validation  
**Scope:** Add and validate a small state model for the shell primary action area.

---

## Goal

M13.19 gives `PrimaryActionArea` a dedicated state model for future Preview and Commit visual state binding.

This keeps action state separate from final buttons, final UI, animation, backend, SDKs, and monetization.

---

## Added model

```text
PreviewActionState
- Available
- Previewed
- Disabled

CommitActionState
- Available
- Committed
- Disabled

PatientPuzzlePrimaryActionState
- PreviewState
- CommitState
- DefaultAvailable
```

---

## Updated systems

- `PatientPuzzleShellPresentation`
- `PatientPuzzleShellPresenter`
- `PatientPuzzleShellPrimaryActionValidator`
- `PatientPuzzleShellFoundationValidator`
- `PatientPuzzleShellSceneSmokeValidator`
- `PatientPuzzleShellEndToEndValidator`

---

## Added validator

- `PatientPuzzlePrimaryActionStateValidator`

---

## New editor menu

```text
Cyber Clinic/Slices/Run Patient Puzzle Primary Action State Debug
```

---

## Expected validator output

```text
PatientPuzzlePrimaryActionStateDebug OK
previewStatesOk=True
commitStatesOk=True
defaultPreviewState=Available
defaultCommitState=Available
previewedStateRepresentable=True
committedStateRepresentable=True
disabledStateRepresentable=True
presenterBindingOk=True
uiBinding=primary_action_state_model_ready
```

---

## Already observed regression outputs

```text
PatientPuzzleShellPrimaryActionDebug OK
previewActionState=Available
commitActionState=Available
uiBinding=shell_primary_action_placeholder_ready
```

```text
PatientPuzzleShellFoundationDebug OK
primaryActionIncluded=True
primaryActionStateIncluded=True
previewState=Available
commitState=Available
uiBinding=shell_foundation_aggregate_ready
```

```text
PatientPuzzleShellSceneSmoke OK
primaryActionIncluded=True
primaryActionStateIncluded=True
previewState=Available
commitState=Available
uiBinding=shell_scene_smoke_ready
```

```text
PatientPuzzleShellEndToEndDebug OK
primaryActionIncluded=True
primaryActionStateIncluded=True
previewState=Available
commitState=Available
uiBinding=shell_end_to_end_ready
```

---

## Not included

- final buttons
- final UI
- final art
- animation system
- backend
- SDKs
- monetization
- content expansion

---

## Completion criteria

M13.19 is complete when the primary action state validator passes and the existing shell primary action, foundation, scene smoke, and end-to-end validators still pass locally in Unity.
