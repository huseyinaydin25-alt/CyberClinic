# M1.R.5 — Operation Encounter Screen Model

**Date:** 2026-05-29  
**Status:** Implemented, pending local Unity validation  
**Scope:** Add the canonical Operation Encounter screen model for the revised RPG/MMO-lite architecture.

---

## Goal

M1.R.5 introduces a canonical screen/data model for Operation Encounter.

The old `PatientPuzzleSliceScreenModel` remains temporarily as a compatibility layer, but new systems should move toward:

```text
OperationEncounterScreenModel
```

---

## Added systems

- `OperationEncounterIdentitySection`
- `OperationEncounterSubjectSection`
- `OperationEncounterActionSection`
- `OperationEncounterRiskSection`
- `OperationEncounterRewardSection`
- `OperationEncounterScreenModel`
- `OperationEncounterScreenModelBuilder`

---

## Builder path

```text
OperationEncounterDebugContentSource
-> OperationEncounterContentLoader
-> OperationEncounterDefinitionRegistry
-> OperationEncounterScreenModelBuilder
-> OperationEncounterScreenModel
```

---

## Why this matters

This model is the future-facing foundation for:

```text
3D operation HUD
operation planning panel
operation execution panel
item modifier breakdown
risk/reward preview
deterministic calculation output
admin-defined operation content
loot/reward preview
```

---

## Added validator

- `OperationEncounterScreenModelValidator`

---

## New editor menu

```text
Cyber Clinic/Operation Encounter/Run M1.R Screen Model Debug
```

---

## Expected validator output

```text
OperationEncounterScreenModelDebug OK
encounterId=debug_encounter_street_netrunner_optic_tune
contentVersion=debug.v1
sourceId=local.debug.operation_encounter
participantId=debug_participant_street_netrunner
procedureId=debug_procedure_micro_install
riskTier=risk.uncertain
rewardTableId=reward_table.debug_operation_basic
canonicalScreenModel=True
missingLookupSafe=True
uiBinding=operation_encounter_screen_model_ready
```

---

## Compatibility note

M1.R.4 still bridges to `PatientPuzzleSliceScreenModel` for existing shell/presenter/runtime validation.

M1.R.5 creates the canonical replacement model that future milestones should use directly.

---

## Not included yet

- final Operation Encounter presenter
- final Operation Encounter runtime shell
- deterministic operation calculation v2
- item/equipment modifiers
- 3D HUD binding

---

## Completion criteria

M1.R.5 is complete when the screen model validator passes locally in Unity and M1.R.1-M1.R.4 still pass.
