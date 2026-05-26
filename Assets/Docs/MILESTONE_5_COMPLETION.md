# Milestone 5 Completion — Operation Calculation System

**Date:** 2026-05-27  
**Status:** Completed  
**Scope:** Pure deterministic operation calculation, risk bands, outcome typing, breakdown DTO, and editor-only validation.

---

## Completed

- `OperationCalculator` was added as a pure deterministic calculation layer.
- `OperationBreakdownEntry` DTO was added for localized breakdown terms.
- `OperationResult` DTO was added for calculation output.
- `OperationOutcomeType` now supports `PreviewOnly` for non-commit previews.
- `ProcedurePlan` was expanded with calculation-only fields:
  - `BaseSuccess`
  - `ProcedureDifficulty`
- Editor-only debug menu was added:

```text
Cyber Clinic/Procedures/Run Operation Calculator Debug
```

---

## Calculator behavior

The calculator supports:

- preview calculation without seeded random variance
- commit calculation with deterministic seeded random variance
- success chance clamping to `0..1`
- risk band mapping:
  - `Safe`
  - `Stable`
  - `Uncertain`
  - `Dangerous`
  - `Critical`
- outcome typing:
  - `PreviewOnly`
  - `CriticalSuccess`
  - `StableSuccess`
  - `UnstableSuccess`
  - `Failure`
  - `Catastrophe`
- technical breakdown entries using localization keys only, such as:
  - `math.term.base_success`
  - `math.term.implant_compatibility`
  - `math.term.cybertox_pressure`
  - `math.term.neural_load_pressure`
  - `math.term.patient_panic_penalty`
  - `math.term.seeded_random_variance`

---

## Deterministic validation

The debug validator was run successfully in Unity:

```text
OperationCalculatorDebug OK
operationSeed=-1749383045
previewSuccessChance=0,675
previewRiskBand=Uncertain
previewOutcome=PreviewOnly
commitSuccessChance=0,690
commitRiskBand=Uncertain
commitOutcome=StableSuccess
commitRandomVariance=0,015
rawScore=0,690
breakdownCount=13
```

The debug menu runs preview twice and commit twice with the same input and confirms matching output fields.

---

## Explicitly not created

The following systems were not created or modified as part of Milestone 5 closure:

- gameplay UI
- prefabs
- scenes
- operation gameplay flow
- save system
- backend implementation
- platform SDK integration
- AdMob / RevenueCat implementation
- economy, reputation, or day flow
- VFX/audio feedback

---

## Next milestone

Milestone 6 should start with the first landscape UI skeleton.

Do not add save, backend, platform SDK integration, economy, reputation, day-flow, or non-UI gameplay expansion before the relevant milestone.
