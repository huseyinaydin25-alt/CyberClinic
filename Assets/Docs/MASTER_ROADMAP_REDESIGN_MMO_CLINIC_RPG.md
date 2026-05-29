# Cyber Clinic — Redesigned Master Roadmap

**Date:** 2026-05-29  
**Status:** Strategic roadmap redesign  
**Direction:** MMO-style cyber-medical clinic RPG with procedural surgery puzzle core, itemization, live-ops, alliance systems, premium art/effects, and monetizable cosmetics.

---

## New product definition

Cyber Clinic is no longer just a small patient puzzle or clinic simulator.

Cyber Clinic should be treated as:

```text
Cyber-medical clinic management
+ procedural surgery decision puzzle
+ MMO-style itemization and equipment progression
+ premium cosmetic customization
+ live-ops retention systems
+ social alliance / league systems
+ co-op high-difficulty operations
+ long-term collectible economy
```

---

## Core design fantasy

The player is a clinic owner building a powerful cyber-medical operation.

The player should:

```text
Treat procedurally generated patients
Make risky surgery decisions
Collect and upgrade medical items
Build optimized surgical loadouts
Customize clinic, tools, avatars, and effects
Join alliances / leagues with other clinic owners
Contribute to group surgeries and raid operations
Compete in leaderboards and seasonal events
Chase rare, legendary, and mythic items
Return daily and weekly for missions, streaks, events, and rewards
```

---

## Important correction to previous roadmap

Earlier roadmap additions placed LiveOps, cosmetics, social systems, and MMO itemization after M30.

That is no longer ideal.

These systems should not feel like late add-ons. They should become major architectural pillars from the start, while still being implemented safely in small, testable, offline-first foundations.

---

## What happens to completed work?

Nothing should be discarded.

Current completed M3-M15 work becomes:

```text
Operation Microgame / Patient Puzzle Core Foundation
```

This is the core surgery decision loop used inside the larger MMO clinic RPG.

The existing systems remain valuable:

```text
Procedural patient generation
Implant / procedure foundation
Operation calculation
Visual / audio feedback foundations
Economy / reputation / day flow
Save foundation
Platform services abstraction
Playable slice
Patient puzzle shell
Primary action interaction flow
Session state / controller
```

These are the foundation of the surgical encounter layer.

---

## New pillar-based roadmap structure

Instead of a simple linear feature list, the project should be organized around pillars.

```text
Pillar A — Operation Microgame Core
Pillar B — Clinic RPG Progression
Pillar C — MMO Itemization / Equipment / Loot
Pillar D — Premium Art / VFX / Audio / Cosmetic Identity
Pillar E — LiveOps / Missions / Events / Seasons
Pillar F — Social / Friends / Alliance / League
Pillar G — Co-op / Raid Surgery / Group Operations
Pillar H — Monetization / Shop / Offers / Battle Pass-like Tracks
Pillar I — Backend / Sync / Platform Services
Pillar J — Production UI / UX / Store Readiness
```

---

# Phase 0 — Existing Foundation Reframing

## P0.1 — Operation Microgame Foundation

Previously completed and in progress milestones are reclassified here.

```text
M3-M15 current work -> Operation Microgame Foundation
```

Includes:

```text
Patient generation
Procedure selection
Risk calculation
Preview / commit action flow
Operation result feedback
Session state and session controller
Shell runtime and validators
```

### Required backward adjustment

Add explicit documentation that Patient Puzzle is not the whole game; it is the operation encounter module.

---

# Phase 1 — Core Surgery Loop Completion

## M15 — Patient Puzzle Decision Loop Foundation

Continue current work, but rename mentally as:

```text
Operation Encounter Decision Loop Foundation
```

Remaining near-term goals:

```text
Preview result binding
Commit result binding
Outcome lock
Reset / retry debug flow
Decision loop aggregate validator
```

---

## M16 — Operation Encounter UI Structure

```text
M16.1 — Encounter Region Hierarchy
M16.2 — Patient Dossier Panel
M16.3 — Procedure / Implant Decision Panel
M16.4 — Risk / Modifier Breakdown Panel
M16.5 — Result / Reward Panel
M16.6 — Action Bar Placeholder
M16.7 — Encounter UI Aggregate Validator
```

Goal: Turn the operation shell into a real production-intent encounter screen.

---

## M17 — Operation Result and Reward Loop

```text
M17.1 — Result Summary Model
M17.2 — Credit Delta Binding
M17.3 — Reputation Delta Binding
M17.4 — Item Drop Placeholder Binding
M17.5 — XP / Clinic Progress Binding
M17.6 — Result Presentation
M17.7 — Result Loop Validator
```

Goal: Make every surgery feed progression, rewards, and item chase.

---

# Phase 2 — Clinic RPG Progression

## M18 — Clinic Owner Progression Foundation

```text
M18.1 — Clinic Owner Level Model
M18.2 — Clinic XP Rules
M18.3 — Reputation Tier Model
M18.4 — Unlock Rules
M18.5 — Progression Reward Rules
M18.6 — Progression Save Binding
M18.7 — Progression Validator
```

---

## M19 — Clinic Facility Upgrade Foundation

```text
M19.1 — Facility Definition Model
M19.2 — Upgrade Slot Model
M19.3 — Treatment Room Upgrade Rules
M19.4 — Diagnostic Lab Upgrade Rules
M19.5 — Recovery Unit Upgrade Rules
M19.6 — Facility Modifier Binding
M19.7 — Facility Upgrade Validator
```

Goal: Clinic upgrades should affect surgery, item drops, patient quality, and economy.

---

## M20 — Patient Queue and Day Loop

```text
M20.1 — Day Session Model
M20.2 — Patient Queue Model
M20.3 — Case Difficulty Distribution
M20.4 — Daily Summary
M20.5 — End-of-Day Rewards
M20.6 — Day Save Binding
M20.7 — Day Loop Validator
```

---

# Phase 3 — MMO Itemization / Equipment / Loot

## M21 — Item Definition Foundation

```text
M21.1 — Item Definition Model
M21.2 — Item Category Contract
M21.3 — Item Rarity Model
M21.4 — Item Power Value Model
M21.5 — Item Flavor / Lore Text Model
M21.6 — Item Registry Mock
M21.7 — Item Definition Validator
```

---

## M22 — Inventory and Ownership Foundation

```text
M22.1 — Owned Item Instance Model
M22.2 — Inventory Slot Model
M22.3 — Stackable / Non-Stackable Rules
M22.4 — Locked / Favorite / New Item Flags
M22.5 — Inventory Save Binding
M22.6 — Inventory Presentation Model
M22.7 — Inventory Validator
```

---

## M23 — Equipment Loadout Foundation

```text
M23.1 — Equipment Loadout Model
M23.2 — Surgical Tool Slot
M23.3 — Diagnostic Device Slot
M23.4 — Implant Calibration Slot
M23.5 — AI Module Slot
M23.6 — Clinic Facility Slot
M23.7 — Equipment Slot Validator
```

---

## M24 — Item Stat and Operation Modifier Foundation

```text
M24.1 — Stat Definition Model
M24.2 — Success Chance Modifier Stat
M24.3 — Risk Reduction Modifier Stat
M24.4 — Reward Modifier Stat
M24.5 — Reputation Modifier Stat
M24.6 — Operation Modifier Breakdown
M24.7 — Item Stat Modifier Validator
```

Goal: Items must affect operation preview and commit results.

---

## M25 — Loot Table and Drop Source Foundation

```text
M25.1 — Loot Table Model
M25.2 — Operation Loot Source
M25.3 — Mission Loot Source
M25.4 — Event Loot Source
M25.5 — Alliance / Raid Loot Source
M25.6 — Drop Chance Rules
M25.7 — Loot Validator
```

---

## M26 — Upgrade / Crafting / Research Foundation

```text
M26.1 — Upgrade Level Model
M26.2 — Upgrade Cost Rules
M26.3 — Crafting Material Model
M26.4 — Research Blueprint Model
M26.5 — Recipe Requirement Rules
M26.6 — Upgrade Preview Binding
M26.7 — Upgrade / Crafting Validator
```

---

## M27 — Item Sets and Builds

```text
M27.1 — Item Set Definition Model
M27.2 — Set Bonus Rules
M27.3 — Build Snapshot Model
M27.4 — High-Success Build Rules
M27.5 — Low-Risk Build Rules
M27.6 — Build Summary Presentation
M27.7 — Build Validator
```

---

# Phase 4 — Premium Art / Effects / Cosmetic Identity

## M28 — Art Direction Bible and Visual Language

```text
M28.1 — Art Direction Bible
M28.2 — Noir Cyber-Medical Visual Rules
M28.3 — Color / Material Language
M28.4 — UI Art Rules
M28.5 — Character / Patient Visual Rules
M28.6 — Clinic Environment Visual Rules
M28.7 — Art Direction Checklist
```

---

## M29 — Modular Skin System

```text
M29.1 — Skin Definition Model
M29.2 — Skin Category Contract
M29.3 — Skin Slot Model
M29.4 — Skin Compatibility Rules
M29.5 — Owned / Equipped Skin State
M29.6 — Skin Save Binding
M29.7 — Skin Validator
```

---

## M30 — Clinic / Avatar / Tool Cosmetics

```text
M30.1 — Clinic Room Theme Model
M30.2 — Doctor / Assistant / AI Avatar Skin Model
M30.3 — Tool Skin Model
M30.4 — Implant Visual Skin Model
M30.5 — Cosmetic Rarity Model
M30.6 — Cosmetic Preview Binding
M30.7 — Cosmetic Validator
```

---

## M31 — Premium VFX / SFX Feedback Layer

```text
M31.1 — VFX Token Model
M31.2 — Preview / Commit VFX Token Binding
M31.3 — Success / Failure / Critical Result VFX
M31.4 — Rarity-Based VFX Rules
M31.5 — Audio Identity Rules
M31.6 — Audio Cue Expansion
M31.7 — VFX / SFX Validator
```

---

# Phase 5 — LiveOps / Missions / Events / Seasons

## M32 — Daily / Weekly Mission Foundation

```text
M32.1 — Mission Definition Model
M32.2 — Daily Mission Slot Model
M32.3 — Weekly Mission Slot Model
M32.4 — Mission Progress Tracking
M32.5 — Mission Reward Rules
M32.6 — Mission Save Binding
M32.7 — Mission Validator
```

---

## M33 — Streak System Foundation

```text
M33.1 — Login Streak Model
M33.2 — Treatment Streak Model
M33.3 — Streak Reward Rules
M33.4 — Grace Rules
M33.5 — Streak Bar Presentation
M33.6 — Streak Save Binding
M33.7 — Streak Validator
```

---

## M34 — Event / Season Foundation

```text
M34.1 — Event Definition Model
M34.2 — Event Calendar Model
M34.3 — Season Definition Model
M34.4 — Season Progress Model
M34.5 — Event Mission Binding
M34.6 — Seasonal Reward Track
M34.7 — Event / Season Validator
```

---

# Phase 6 — Social / Alliance / League

## M35 — Friend and Clinic Owner Profile Foundation

```text
M35.1 — Friend Profile Snapshot Model
M35.2 — Friend List Mock Service
M35.3 — Clinic Owner Profile Model
M35.4 — Public Clinic Stats Snapshot
M35.5 — Prestige Badge Model
M35.6 — Social Profile Presentation
M35.7 — Friend / Profile Validator
```

---

## M36 — Alliance / Legion Foundation

```text
M36.1 — Alliance Definition Model
M36.2 — Alliance Member Model
M36.3 — Alliance Role Model
M36.4 — Join / Leave Rules
M36.5 — Alliance Capacity Rules
M36.6 — Alliance Mock Service
M36.7 — Alliance Validator
```

---

## M37 — Alliance Quest / Event Foundation

```text
M37.1 — Alliance Quest Definition Model
M37.2 — Shared Progress Model
M37.3 — Member Contribution Model
M37.4 — Alliance Event Definition
M37.5 — Alliance Reward Tier Rules
M37.6 — Alliance Event Presentation
M37.7 — Alliance Quest / Event Validator
```

---

## M38 — League / Leaderboard Foundation

```text
M38.1 — Player Leaderboard Score Model
M38.2 — Alliance Score Model
M38.3 — League Tier Model
M38.4 — Promotion / Demotion Rules
M38.5 — Weekly / Seasonal Ranking Rules
M38.6 — Leaderboard Presentation
M38.7 — League Validator
```

---

# Phase 7 — Co-op / Raid Surgery / Endgame

## M39 — Group Surgery Foundation

```text
M39.1 — Group Surgery Case Model
M39.2 — Required Specialist Slot Model
M39.3 — Member Contribution Slot Model
M39.4 — Group Surgery Progress Rules
M39.5 — Contribution Quality Rules
M39.6 — Group Surgery Result Model
M39.7 — Group Surgery Validator
```

---

## M40 — Raid Surgery / Elite Operation Foundation

```text
M40.1 — Raid Operation Definition Model
M40.2 — Difficulty Tier Rules
M40.3 — Required Team Power Rules
M40.4 — Phase-Based Operation Progress
M40.5 — Failure / Partial Success Rules
M40.6 — Raid Reward Rules
M40.7 — Raid Validator
```

---

## M41 — Endgame Item Chase Foundation

```text
M41.1 — Elite Operation Drop Rules
M41.2 — Raid Surgery Drop Rules
M41.3 — Legendary Item Source Rules
M41.4 — Mythic Item Source Rules
M41.5 — Time-Limited Prestige Item Rules
M41.6 — Endgame Collection Presentation
M41.7 — Endgame Item Validator
```

---

# Phase 8 — Monetization and Store Foundation

## M42 — Cosmetic Shop and Offer Foundation

```text
M42.1 — Cosmetic Shop Item Model
M42.2 — Shop Rotation Placeholder
M42.3 — Bundle / Offer Model
M42.4 — Price Intent Model
M42.5 — Preview-Before-Buy Model
M42.6 — Mock Purchase Intent Binding
M42.7 — Cosmetic Shop Validator
```

---

## M43 — Battle Pass-like Progression Track

```text
M43.1 — Free Track Model
M43.2 — Premium Track Placeholder Model
M43.3 — Tier Progression Rules
M43.4 — Claim State Model
M43.5 — Reward Preview Presentation
M43.6 — Track Save Binding
M43.7 — Progression Track Validator
```

---

## M44 — Monetization Intent and Placement Foundation

```text
M44.1 — Rewarded Ad Placement Contract
M44.2 — Cosmetic Purchase Intent Contract
M44.3 — Season Pass Intent Contract
M44.4 — Offer Surface Contract
M44.5 — Platform Service Mock Extension
M44.6 — Monetization Validator
```

---

# Phase 9 — Backend / Online / Platform

## M45 — Online Sync Foundation

```text
M45.1 — Player Cloud Profile Model
M45.2 — Inventory Sync Contract
M45.3 — Leaderboard Sync Contract
M45.4 — Alliance Sync Contract
M45.5 — Event Calendar Sync Contract
M45.6 — Conflict / Migration Placeholder Rules
M45.7 — Online Sync Validator
```

---

## M46 — Platform SDK Integration Preparation

```text
M46.1 — Apple / Google Platform Contracts
M46.2 — RevenueCat / IAP Contract
M46.3 — AdMob Placement Contract
M46.4 — Push Notification Placeholder
M46.5 — Analytics Event Contract
M46.6 — Remote Config Contract
M46.7 — Platform SDK Readiness Validator
```

---

# Phase 10 — Production UI / UX / Marketing Readiness

## M47 — Premium UI Motion and Microinteraction

```text
M47.1 — Microinteraction Rules
M47.2 — Button Press Motion Tokens
M47.3 — Panel Transition Motion Tokens
M47.4 — Card Select Motion Tokens
M47.5 — Reward Claim Motion Tokens
M47.6 — Motion Debug Toggle
M47.7 — Motion Validator
```

---

## M48 — Store / Screenshot / Trailer Readiness

```text
M48.1 — Screenshot Composition Rules
M48.2 — Trailer Moment Token List
M48.3 — Hero Operation Scene Placeholder
M48.4 — Cosmetic Showcase Scene Placeholder
M48.5 — Event Showcase Scene Placeholder
M48.6 — Marketing Capture Validator
```

---

# Near-term implementation decision

Even with the redesigned roadmap, the next implementation step should not jump directly to alliances or legendary loot.

The correct next step is still to finish M15 because it is the operation microgame core.

Immediate continuation:

```text
M15.3 — Preview Result Binding
M15.4 — Commit Result Binding
M15.5 — Outcome State Locking
M15.6 — Retry / Reset Debug Flow
M15.7 — Patient Puzzle Decision Loop Validator
```

After M15 is complete, we should introduce itemization earlier than the old roadmap did.

Recommended next strategic sequence:

```text
Finish M15 Operation Encounter Decision Loop
Then M16/M17 Operation Result + Rewards
Then jump into Item Definition / Inventory / Equipment foundation earlier
Then connect item stats to operation modifiers
```

---

# Development rule

Everything must remain:

```text
small-step
validator-driven
mock/offline-first
deterministic
testable in Unity locally
safe before backend / SDK / monetization integration
```

This lets the game grow to MMO-scale without collapsing under complexity.
