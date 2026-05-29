# Milestone 13.22 — State-Aware Shell Runtime

**Date:** 2026-05-28  
**Status:** Implemented, pending local Unity validation  
**Scope:** Add a state-aware runtime build overload for primary action shell presentation.

---

## Goal

M13.22 connects `PatientPuzzlePrimaryActionState` to `PatientPuzzleShellRuntime` in a controlled way.

The default runtime path still builds the shell with the initial `Available/Available` state, but a new overload can render `Previewed`, `Committed`, and `Disabled` state combinations in `PrimaryActionArea`.

---

## Updated system

- `PatientPuzzleShellRuntime`

---

## Added runtime overload

```text
PatientPuzzleShellRuntime.BuildShell(screenModel, primaryActionState)
```

---

## Default behavior remains

```text
PatientPuzzleShellRuntime.BuildShell(screenModel)
-> Available/Available
```

---

## Added validator

- `PatientPuzzleShellRuntimeStateValidator`

---

## New editor menu

```text
Cyber Clinic/Slices/Run Patient Puzzle Shell Runtime State Debug
```

---

## Expected validator output

```text
PatientPuzzleShellRuntimeStateDebug OK
initialState=Available/Available
previewedState=Previewed/Available
committedState=Previewed/Committed
disabledState=Disabled/Disabled
uiBinding=shell_runtime_state_aware_ready
```

---

## Regression checks

After this validator passes, run:

```text
Cyber Clinic/Slices/Run Patient Puzzle Shell Presenter State Debug
Cyber Clinic/Slices/Run Patient Puzzle Primary Action State Resolver Debug
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

M13.22 is complete when the state-aware runtime validator passes and existing presenter / primary action / shell regression validators still pass locally in Unity.
