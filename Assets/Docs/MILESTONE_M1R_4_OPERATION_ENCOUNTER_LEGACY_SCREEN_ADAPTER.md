# M1.R.4 — Operation Encounter Legacy Screen Adapter

**Date:** 2026-05-29  
**Status:** Implemented, pending local Unity validation  
**Scope:** Bridge modular Operation Encounter definitions into the existing validated screen/shell model.

---

## Goal

M1.R.4 connects the new data-driven Operation Encounter foundation to the currently working legacy debug screen model.

This protects previous M1-M15 work while moving the architecture toward the new RPG/MMO-lite vision.

---

## Architecture bridge

```text
OperationEncounterDefinition
-> OperationEncounterLegacyScreenAdapter
-> PatientPuzzleSliceScreenModel
-> Existing shell / presenter / runtime validators
```

The old screen model remains temporarily as a compatibility layer.

---

## Added systems

- `OperationEncounterLegacyScreenAdapter`

---

## Added validator

- `OperationEncounterLegacyScreenAdapterValidator`

---

## New editor menu

```text
Cyber Clinic/Operation Encounter/Run M1.R Legacy Screen Adapter Debug
```

---

## Expected validator output

```text
OperationEncounterLegacyScreenAdapterDebug OK
encounterId=debug_encounter_street_netrunner_optic_tune
participantId=debug_participant_street_netrunner
procedureId=debug_procedure_micro_install
riskTier=risk.uncertain
previewChance=<deterministic value>
executeChance=<deterministic value>
creditsDelta=90
reputationDelta=5
legacyShellCompatible=True
dataDrivenBridgeReady=True
uiBinding=operation_encounter_legacy_screen_adapter_ready
```

---

## Why this matters

This is the first point where the new modular content architecture feeds the old validated presentation foundation.

This prevents the old work from becoming waste while avoiding a risky rewrite.

---

## Temporary compatibility notes

The adapter still outputs `PatientPuzzleSliceScreenModel` because the current shell/presenter/runtime foundation is still based on that model.

Future refactor passes will gradually replace this with canonical Operation Encounter screen/presentation models.

---

## Not included yet

- final OperationEncounterScreenModel
- deterministic operation calculation engine v2
- item/equipment modifiers
- 3D scene binding
- admin panel content publishing

---

## Completion criteria

M1.R.4 is complete when the adapter validator passes locally in Unity and existing shell/presenter/runtime validators still pass.
