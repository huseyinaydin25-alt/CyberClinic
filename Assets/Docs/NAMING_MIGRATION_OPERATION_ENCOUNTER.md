# Naming Migration — Operation Encounter

**Date:** 2026-05-29  
**Status:** Active naming migration  
**Reason:** Cyber Clinic has evolved from a puzzle slice into a 3D MMO-lite clinic RPG.

---

## Core decision

The canonical name for the core gameplay module is now:

```text
Operation Encounter
```

The old name:

```text
Patient Puzzle
```

is now considered legacy terminology.

---

## Naming mapping

```text
PatientPuzzle -> OperationEncounter
Patient Puzzle -> Operation Encounter
patient_puzzle -> operation_encounter
patient puzzle -> operation encounter
Puzzle Session -> Operation Session
Primary Action -> Operation Action
Preview -> Plan / Preview Operation
Commit -> Execute Operation
```

---

## Architectural meaning

The former Patient Puzzle systems are not discarded.

They are now interpreted as:

```text
Operation encounter logic foundation
3D gameplay state foundation
UI overlay / debug shell foundation
Validator-driven safety net
```

---

## Migration rule

Do not delete or mass-rename working legacy classes blindly.

Use safe phased migration:

```text
Phase 1 — Declare canonical Operation Encounter naming
Phase 2 — Add OperationEncounter facade/wrapper layer
Phase 3 — Add new validators and menu entries using canonical naming
Phase 4 — Mark PatientPuzzle terminology as legacy/deprecated in docs
Phase 5 — Rename internal classes only when regression coverage is strong
Phase 6 — Remove legacy aliases only after all references are migrated
```

---

## Why phased migration is required

The existing PatientPuzzle classes are part of the validated safety net.

A large rename can break:

```text
Unity serialization
Editor menu references
Scene object references
Validator references
Documentation history
Regression confidence
```

Therefore, the canonical naming should be introduced without destroying the currently validated foundation.

---

## New naming policy

All new gameplay-facing systems should use OperationEncounter naming unless there is a strong compatibility reason not to.

Examples:

```text
OperationEncounterSessionState
OperationEncounterSessionController
OperationEncounterPreviewResultBinding
OperationEncounterCommitResultBinding
OperationEncounterCalculation
OperationEncounterModifierBreakdown
OperationEncounter3DBinding
```

---

## Legacy policy

Existing PatientPuzzle names remain valid only as temporary compatibility names.

They should be treated as:

```text
Legacy compatibility layer
```

not as the conceptual product direction.

---

## Documentation policy

New milestone documents should state the new meaning clearly:

```text
PatientPuzzle legacy name = OperationEncounter current concept
```

Eventually, milestone names should move fully to Operation Encounter.

---

## Current next step

Before M15.4, introduce canonical OperationEncounter wrapper types around the current validated M15 session / preview binding layer.

This lets future work proceed with correct naming while preserving regression safety.
