# Milestone 13.21 — State-Aware Shell Presenter

**Date:** 2026-05-28  
**Status:** Implemented, pending local Unity validation  
**Scope:** Add a state-aware presenter overload for primary action shell presentation.

---

## Goal

M13.21 connects `PatientPuzzlePrimaryActionState` to `PatientPuzzleShellPresenter` in a controlled way.

The default presenter path still uses the initial `Available/Available` state, but a new overload can render `Previewed`, `Committed`, and `Disabled` state combinations for future UI interaction binding.

---

## Updated system

- `PatientPuzzleShellPresenter`

---

## Added presenter overload

```text
PatientPuzzleShellPresenter.Present(screenModel, primaryActionState)
```

---

## Default behavior remains

```text
PatientPuzzleShellPresenter.Present(screenModel)
-> Available/Available
```

---

## Added validator

- `PatientPuzzleShellPresenterStateValidator`

---

## New editor menu

```text
Cyber Clinic/Slices/Run Patient Puzzle Shell Presenter State Debug
```

---

## Expected validator output

```text
PatientPuzzleShellPresenterStateDebug OK
defaultState=Available/Available
initialState=Available/Available
previewedState=Previewed/Available
committedState=Previewed/Committed
disabledState=Disabled/Disabled
uiBinding=shell_presenter_state_aware_ready
```

---

## Regression checks

After this validator passes, run:

```text
Cyber Clinic/Slices/Run Patient Puzzle Primary Action State Resolver Debug
Cyber Clinic/Slices/Run Patient Puzzle Primary Action State Debug
Cyber Clinic/Slices/Run Patient Puzzle Shell Primary Action Debug
Cyber Clinic/Slices/Run Patient Puzzle Shell Foundation Debug
Cyber Clinic/Slices/Run Patient Puzzle Shell End To End Debug
```

---

## Not included

- final buttons
- runtime click handling
- final UI
- final art
- animation system
- backend
- SDKs
- monetization
- content expansion

---

## Completion criteria

M13.21 is complete when the state-aware presenter validator passes and existing primary action / shell regression validators still pass locally in Unity.
