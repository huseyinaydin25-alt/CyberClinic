# M1.R — Operation Encounter Modular Foundation

**Date:** 2026-05-29  
**Status:** Implemented, pending local Unity validation  
**Scope:** Restart M1 under the new RPG/MMO-lite vision with a modular, data-driven Operation Encounter foundation.

---

## Strategic context

Cyber Clinic is now a 3D cyber-medical RPG / MMO-lite clinic RPG.

The old Patient Puzzle foundation is not discarded, but M1-M15 must be revised under the new architecture rule:

```text
Code defines systems.
Data defines content, balance, cases, rewards, items, missions, events, and admin configuration.
```

M1.R begins that revision from the beginning.

---

## Goal

Create a modular encounter definition model that can later be sourced from:

```text
local JSON
ScriptableObject bridge
remote content manifest
admin panel
live config
```

This replaces the idea of a hardcoded puzzle case with a data-driven Operation Encounter definition.

---

## Added systems

- `OperationEncounterParticipantDefinition`
- `OperationEncounterProcedureDefinition`
- `OperationEncounterRiskProfile`
- `OperationEncounterRewardProfile`
- `OperationEncounterDefinition`
- `OperationEncounterDefinitionRegistry`

---

## Why this matters

Future systems can attach to this foundation without rewriting the core:

```text
item stats
equipment loadout
clinic progression
facility upgrades
deterministic calculation engine
loot tables
reward tables
admin-defined cases
3D encounter presentation
raid/group encounter requirements
```

---

## Added validator

- `OperationEncounterModularFoundationValidator`

---

## New editor menu

```text
Cyber Clinic/Operation Encounter/Run M1.R Modular Foundation Debug
```

---

## Expected validator output

```text
OperationEncounterModularFoundationDebug OK
participantDefinition=True
procedureDefinition=True
riskProfile=True
rewardProfile=True
encounterDefinition=True
registryCount=1
loadedEncounterId=debug_encounter_street_netrunner_optic_tune
contentVersion=debug.v1
dataDrivenReady=True
adminConfigReady=True
uiBinding=operation_encounter_modular_foundation_ready
```

---

## Not included yet

- deterministic calculation formula
- inventory
- item stat modifiers
- equipment loadout
- 3D scene
- admin panel UI
- remote config
- real backend

---

## Completion criteria

M1.R is complete when the modular foundation validator passes locally in Unity and no previous M1-M15 regression validators fail.
