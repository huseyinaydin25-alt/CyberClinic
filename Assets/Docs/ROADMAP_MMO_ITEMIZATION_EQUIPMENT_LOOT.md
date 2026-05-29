# Roadmap Addendum — MMO-Style Itemization, Equipment, Loot, and Build Systems

**Date:** 2026-05-29  
**Status:** Added to roadmap  
**Scope:** Expand Cyber Clinic roadmap with MMORPG-style item ownership, item value, equipment stats, loot chase, upgrade paths, builds, set bonuses, and operation success impact.

---

## Strategic reminder

Cyber Clinic should be planned with an MMORPG-style itemization mindset.

Players should not only complete operations. They should chase items, optimize builds, compare equipment, upgrade tools, collect rare drops, prepare for difficult surgeries, and feel long-term ownership over their clinic power.

The item system is one of the most important long-term retention systems in the game.

---

## Core fantasy

```text
I own a clinic.
I build my surgical power over time.
I chase rare medical devices, implants, tools, AI modules, specialists, and clinic upgrades.
My item choices affect success chance, risk, speed, rewards, reputation, and eligibility for difficult operations.
I need better gear to handle elite cases, raid surgeries, and alliance operations.
```

---

## Added roadmap pillars

```text
Item Ownership
Equipment Slots
Item Rarity
Item Power / Value
Item Stats
Operation Success Modifiers
Risk Reduction Modifiers
Specialist / Role Builds
Tool Upgrade Paths
Implant Modifier Items
Loot Tables
Drop Sources
Crafting / Research
Enhancement / Upgrade System
Item Sets and Set Bonuses
Legendary / Mythic Items
Endgame Item Chase
Alliance / Raid Item Requirements
Item Economy and Balance
Inventory / Collection UI
```

---

## M66 — Item Definition Foundation

```text
M66.1 — Item Definition Model
M66.2 — Item Category Contract
M66.3 — Item Rarity Model
M66.4 — Item Power Value Model
M66.5 — Item Flavor / Lore Text Model
M66.6 — Item Registry Mock
M66.7 — Item Definition Validator
```

Goal: Create the base item identity layer.

---

## M67 — Inventory and Ownership Foundation

```text
M67.1 — Owned Item Instance Model
M67.2 — Inventory Slot Model
M67.3 — Stackable / Non-Stackable Rules
M67.4 — Locked / Favorite / New Item Flags
M67.5 — Inventory Save Binding
M67.6 — Inventory Presentation Model
M67.7 — Inventory Validator
```

Goal: Let players own, view, manage, and persist items.

---

## M68 — Equipment Slot Foundation

```text
M68.1 — Equipment Loadout Model
M68.2 — Surgical Tool Slot
M68.3 — Diagnostic Device Slot
M68.4 — Implant Calibration Slot
M68.5 — AI Module Slot
M68.6 — Clinic Facility Slot
M68.7 — Equipment Slot Validator
```

Goal: Let players equip items into meaningful gameplay slots.

---

## M69 — Item Stat System Foundation

```text
M69.1 — Stat Definition Model
M69.2 — Success Chance Modifier Stat
M69.3 — Risk Reduction Modifier Stat
M69.4 — Credit Reward Modifier Stat
M69.5 — Reputation Modifier Stat
M69.6 — Procedure Speed / Efficiency Stat
M69.7 — Item Stat Validator
```

Goal: Define how items affect operation outcomes.

---

## M70 — Operation Modifier Binding

```text
M70.1 — Equipment-to-Operation Modifier Model
M70.2 — Preview Success Chance Modifier Binding
M70.3 — Commit Success Chance Modifier Binding
M70.4 — Risk Band Modifier Binding
M70.5 — Outcome Modifier Rules
M70.6 — Modifier Breakdown Presentation
M70.7 — Operation Modifier Validator
```

Goal: Make equipped items visibly and mathematically affect surgery preview/commit results.

---

## M71 — Build System Foundation

```text
M71.1 — Player Build Snapshot Model
M71.2 — High-Success Build Rules
M71.3 — Low-Risk Build Rules
M71.4 — High-Profit Build Rules
M71.5 — Reputation Build Rules
M71.6 — Build Summary Presentation
M71.7 — Build Validator
```

Goal: Let players create different clinic builds and strategies.

---

## M72 — Item Rarity and Value System

```text
M72.1 — Common / Uncommon / Rare / Epic / Legendary / Mythic Rules
M72.2 — Item Value Score Model
M72.3 — Rarity Stat Budget Rules
M72.4 — Rarity Visual Token Rules
M72.5 — Rarity Audio / VFX Reward Rules
M72.6 — Item Comparison Rules
M72.7 — Rarity Validator
```

Goal: Make rare items feel powerful, prestigious, and desirable.

---

## M73 — Loot Table Foundation

```text
M73.1 — Loot Table Model
M73.2 — Operation Reward Loot Source
M73.3 — Daily / Weekly Mission Loot Source
M73.4 — Event Loot Source
M73.5 — Alliance / Raid Loot Source
M73.6 — Drop Chance Rules
M73.7 — Loot Table Validator
```

Goal: Create item chase loops from multiple game systems.

---

## M74 — Item Upgrade / Enhancement Foundation

```text
M74.1 — Upgrade Level Model
M74.2 — Upgrade Cost Rules
M74.3 — Upgrade Success / Failure Placeholder Rules
M74.4 — Stat Growth Rules
M74.5 — Upgrade Material Requirements
M74.6 — Upgrade Preview Binding
M74.7 — Upgrade Validator
```

Goal: Give owned items long-term growth value.

---

## M75 — Crafting / Research Foundation

```text
M75.1 — Research Blueprint Model
M75.2 — Crafting Material Model
M75.3 — Recipe Requirement Rules
M75.4 — Research Time Placeholder Rules
M75.5 — Craft Result Rules
M75.6 — Crafting Save Binding
M75.7 — Crafting Validator
```

Goal: Let players work toward specific equipment goals instead of relying only on drops.

---

## M76 — Item Set Bonus Foundation

```text
M76.1 — Item Set Definition Model
M76.2 — Equipped Set Count Rules
M76.3 — 2-Piece / 4-Piece / Full Set Bonuses
M76.4 — Specialty Set Rules
M76.5 — Set Bonus Operation Modifier Binding
M76.6 — Set Presentation Model
M76.7 — Set Bonus Validator
```

Goal: Create deeper build optimization and long-term collection goals.

---

## M77 — Specialist Role Equipment Foundation

```text
M77.1 — Specialist Role Model
M77.2 — Surgeon / Engineer / Analyst / AI-Tech Role Rules
M77.3 — Role-Compatible Item Rules
M77.4 — Role Bonus Rules
M77.5 — Group Surgery Role Requirement Binding
M77.6 — Role Build Presentation
M77.7 — Specialist Role Validator
```

Goal: Prepare item/build requirements for co-op group surgeries and raid operations.

---

## M78 — Endgame Item Chase Foundation

```text
M78.1 — Elite Operation Drop Rules
M78.2 — Raid Surgery Drop Rules
M78.3 — Legendary Item Source Rules
M78.4 — Mythic Item Source Rules
M78.5 — Time-Limited Prestige Item Rules
M78.6 — Endgame Collection Presentation
M78.7 — Endgame Item Validator
```

Goal: Give committed players aspirational long-term goals.

---

## M79 — Item Economy and Balance Layer

```text
M79.1 — Item Power Budget Rules
M79.2 — Upgrade Cost Curve Rules
M79.3 — Drop Rate Balance Placeholder
M79.4 — Duplicate Item Conversion Rules
M79.5 — Soft Currency Sink Binding
M79.6 — Economy Exploit Check Placeholder
M79.7 — Item Economy Validator
```

Goal: Prevent item systems from breaking progression, economy, or competitive fairness.

---

## M80 — Inventory / Equipment UI Foundation

```text
M80.1 — Inventory Screen Model
M80.2 — Item Card Presentation Model
M80.3 — Stat Comparison Presentation
M80.4 — Equip / Unequip Intent Model
M80.5 — Upgrade Preview Presentation
M80.6 — Rarity Visual Binding
M80.7 — Inventory UI Validator
```

Goal: Make item ownership and equipment decisions understandable and satisfying.

---

## Roadmap placement

These systems extend the roadmap after social/alliance foundations:

```text
M15-M30 -> Core game loop, UI, progression, save, art pipeline, monetization prep
M31-M40 -> LiveOps, retention, competition, seasons, events, PvP, leaderboard
M41-M53 -> Premium art, effects, modular skins, cosmetics, shop, reward presentation
M54-M65 -> Friends, alliances, leagues, co-op operations, raid surgeries, social systems
M66-M80 -> MMO-style itemization, equipment, stats, loot, builds, endgame chase
```

---

## Design rule

Items may affect operation success, risk, rewards, and eligibility for elite content.

However, competitive fairness must be protected:

```text
Items create progression, strategy, specialization, and long-term goals.
Competitive modes need bracket, power normalization, or separate ranking rules where necessary.
```

---

## Monetization rule

The item system must be designed carefully.

Preferred monetization-safe approach:

```text
Cosmetics, skins, convenience, season tracks, event rewards, and prestige presentation are monetizable.
Direct pay-to-win item power should be avoided or heavily constrained.
Item progression should reward play, consistency, events, alliances, and skillful planning.
```

---

## Implementation rule

All item systems must be built mock/offline-first before real backend or economy services are integrated.

This keeps item drops, upgrades, builds, and operation modifiers deterministic, testable, and safe during development.
