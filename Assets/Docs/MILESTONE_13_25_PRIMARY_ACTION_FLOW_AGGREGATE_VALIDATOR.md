# Milestone 13.25 — Primary Action Flow Aggregate Validator

**Date:** 2026-05-28  
**Status:** Implemented, pending local Unity validation  
**Scope:** Add one aggregate validator for the Primary Action foundation stack.

---

## Goal

M13.25 adds a single editor validation entry point for the Primary Action flow foundation.

It verifies the complete stack together:

```text
State Model
State Resolver
State-Aware Presenter
State-Aware Runtime
Controller
Controller -> Shell Flow
```

---

## Added validator

- `PatientPuzzlePrimaryActionFlowAggregateValidator`

---

## New editor menu

```text
Cyber Clinic/Slices/Run Patient Puzzle Primary Action Flow Aggregate Debug
```

---

## Expected validator output

```text
PatientPuzzlePrimaryActionFlowAggregateDebug OK
stateModelOk=True
resolverOk=True
presenterOk=True
runtimeOk=True
controllerOk=True
shellFlowOk=True
initialState=Available/Available
previewedState=Previewed/Available
committedState=Previewed/Committed
disabledState=Disabled/Disabled
uiBinding=primary_action_flow_aggregate_ready
```

---

## Regression checks

After this validator passes, run:

```text
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

M13.25 is complete when the aggregate validator passes and shell foundation / end-to-end regressions still pass locally in Unity.
