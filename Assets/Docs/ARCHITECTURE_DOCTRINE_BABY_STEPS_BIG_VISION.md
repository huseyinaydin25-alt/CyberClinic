# Cyber Clinic — Architecture Doctrine

**Date:** 2026-05-29  
**Status:** Active project doctrine  
**Principle:** Baby steps implementation, big vision architecture.

---

## Core statement

Cyber Clinic is a large long-term vision, but it must be built in small, safe, validated steps.

```text
Baby steps implementation.
Big vision architecture.
Never paint ourselves into a corner.
```

---

## Product vision

Cyber Clinic is now planned as:

```text
3D cyber-medical RPG / MMO-lite clinic RPG
+ operation encounter gameplay
+ MMO-style itemization
+ inventory / equipment / builds
+ premium cosmetics / skins / VFX / SFX
+ data-driven admin-configurable content
+ daily / weekly missions
+ live events / seasons
+ friends / alliances / leagues
+ group surgeries / raid surgeries
+ leaderboards and long-term retention loops
```

---

## Development rule

The project must always move in small steps:

```text
One small system
One validator
One local Unity test
One documented milestone
Then continue
```

Large features must be decomposed into small foundations.

---

## Lego architecture rule

Every system must be designed like a Lego block.

A new feature should be attachable later without destroying existing work.

Examples:

```text
Item stats should attach to operation success calculations later.
3D presentation should attach to existing operation state later.
Admin data should replace hardcoded values later.
Alliance quests should reuse mission/reward systems later.
Raid surgery should reuse operation/session/item systems later.
Cosmetic skins should attach to existing item/avatar/clinic slots later.
```

---

## No dead-end rule

Do not build systems in a way that blocks the future vision.

Avoid:

```text
Hardcoded content where IDs/data definitions are needed
UI-only logic that cannot drive 3D gameplay later
Single-use classes that cannot be extended by item/equipment/liveops systems
Backend-dependent logic before local/mock logic exists
SDK-dependent monetization before mock purchase intent exists
Feature-specific hacks that make later admin configuration impossible
```

---

## Data-driven rule

Code should define systems. Data should define content.

```text
Code defines behavior and contracts.
Admin/local content defines items, cases, drops, events, missions, rewards, skins, shops, and balance.
```

Future content should be configurable without app updates whenever possible.

---

## Mock-first rule

Every large online/live system should be built offline-first before real backend integration.

```text
Local mock first
Schema validation second
Runtime binding third
Backend/admin panel later
```

Applies to:

```text
Inventory
Items
Loot
Missions
Events
Seasons
Shop
Alliance
Leaderboard
PvP
Raid surgery
Remote config
Admin panel
```

---

## Validator-first rule

Every milestone should include validation.

A feature is not complete because code exists. It is complete when its validator passes locally in Unity and regression checks do not fail.

```text
Implemented != Validated
Validated = local Unity proof + no regression
```

---

## Naming evolution rule

Earlier systems may have names from the original puzzle direction.

They should not be deleted just because the product vision changed.

Instead, they should be gradually reinterpreted or refactored:

```text
PatientPuzzle -> OperationEncounter
PuzzleSession -> OperationSession
PrimaryAction -> OperationAction
Preview -> Surgical Planning / Preview
Commit -> Execute Operation
```

Do not perform large renames unless the system is stable and the refactor is low-risk.

---

## Current foundation interpretation

Existing M3-M15 work should be treated as:

```text
Operation encounter logic foundation
3D gameplay state foundation
UI overlay / debug shell foundation
Validator-driven safety net
```

It is not wasted work.

It is the logic layer that future 3D RPG gameplay can use.

---

## Scope discipline rule

New ideas are welcome, but implementation order must remain disciplined.

```text
New idea -> roadmap/doc
Current milestone -> continue
Large system -> decomposed into small validated foundations
```

Do not abandon the current small step just because a larger future system is exciting.

---

## Near-term priority

Continue M15 as the operation encounter decision loop foundation.

Immediate path:

```text
M15.3 — Preview Result Binding
M15.4 — Commit Result Binding
M15.5 — Outcome State Locking
M15.6 — Retry / Reset Debug Flow
M15.7 — Decision Loop Aggregate Validator
```

This work remains valid because it will drive:

```text
3D operation state
3D patient feedback
3D surgical tool feedback
item stat modifiers
operation reward flow
loot and progression
```

---

## Final doctrine

```text
Think like a AAA/MMO live RPG.
Build like a careful solo/small-team engineering project.
Validate every brick.
Never make a brick that prevents the next brick from attaching.
```
