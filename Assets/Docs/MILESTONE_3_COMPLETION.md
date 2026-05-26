# Milestone 3 Completion — Procedural Patient Generator

**Date:** 2026-05-26  
**Status:** Completed  
**Scope:** Deterministic procedural patient generation foundation and minimal editor-only test data.

---

## Completed

- Deterministic `PatientGenerator` foundation is in place.
- Generation uses `SeedContext` and `CyberClinicRandom`.
- Weighted selection works from Patient*Data ScriptableObject pools.
- Runtime `GeneratedPatient` includes known and hidden patient fields.
- `PatientIdFactory` creates deterministic ids; no `Guid.NewGuid` is used for generated patients.
- No `UnityEngine.Random`, `DateTime.Now`, or non-deterministic runtime source is used for generation.
- Editor debug menu exists at **Cyber Clinic/Patients/Generate Debug Patient**.
- Minimal editor-only test assets were added under:

```text
Assets/_CyberClinic/Data/Patients/TestSeed/
```

---

## Test assets created

### PatientArchetypeData

- `test_street_netrunner`
  - `patient.archetype.test_street_netrunner.name`
  - `patient.archetype.test_street_netrunner.description`
  - `patient.archetype.test_street_netrunner.flavor`
- `test_corporate_exile`
  - `patient.archetype.test_corporate_exile.name`
  - `patient.archetype.test_corporate_exile.description`
  - `patient.archetype.test_corporate_exile.flavor`

### PatientMotivationData

- `test_status_pressure`
  - `patient.motivation.test_status_pressure.hint`
  - `patient.motivation.test_status_pressure.description`
- `test_urgent_fix`
  - `patient.motivation.test_urgent_fix.hint`
  - `patient.motivation.test_urgent_fix.description`

### PatientHiddenConditionData

- `test_neural_scar`
  - `patient.hidden.test_neural_scar.name`
  - `patient.hidden.test_neural_scar.scan_hint`
- `test_tox_sensitivity`
  - `patient.hidden.test_tox_sensitivity.name`
  - `patient.hidden.test_tox_sensitivity.scan_hint`

### PatientVisualTraitData

- `test_neon_eyes`
  - sprite address: `test/patient/neon_eyes`
- `test_chrome_jaw`
  - sprite address: `test/patient/chrome_jaw`

### PatientDialogueToneData

- `test_reserved`
  - `patient.dialogue.test_reserved.line_01`
  - `patient.dialogue.test_reserved.line_02`
- `test_nervous`
  - `patient.dialogue.test_nervous.line_01`
  - `patient.dialogue.test_nervous.line_02`

### PatientRequestTypeData

- `test_optic_tune`
  - `patient.request.test_optic_tune.description`
  - linked procedure id: `test_proc_optic_tune`
- `test_grip_upgrade`
  - `patient.request.test_grip_upgrade.description`
  - linked procedure id: `test_proc_grip_upgrade`

---

## Deterministic validation

Debug menu was run twice with the same input:

```text
seed: 84921
day: 3
slot: 0
```

Both runs produced identical output:

```text
instanceId=04e4fc25-4bb9-0001-0300-000022259d0e
patientSeed=82115621
archetypeId=test_street_netrunner
motivationId=test_urgent_fix
requestTypeId=test_optic_tune
bodyProblemId=body_problem.skin
bodyProblemSlot=Skin
requestedUpgradeSlot=Head
visualTraitId=test_chrome_jaw
dialogueToneId=test_nervous
declaredLegal=Legal
actualLegal=Legal
urgency=Medium
budgetRange=150-337
trueCeiling=249
neuralStability=0,431
cyberToxResistance=0,841
panic=29
hiddenConditionCount=1
slotConflictHidden=False
```

Result: same Patient ids, numeric values, and Known/Hidden fields were confirmed on repeated runs.

---

## Explicitly not created

The following systems were not created or modified as part of Milestone 3 closure:

- gameplay UI
- prefabs
- scenes
- operation flow
- `OperationCalculator`
- save system
- backend implementation
- platform SDK integration
- AdMob / RevenueCat implementation
- scan reveal service

---

## Next milestone

Milestone 4 should start with the Implant and Procedure System.

Do not begin operation calculation, gameplay UI, save, backend, platform SDK integration, or scene work before the relevant milestone.
