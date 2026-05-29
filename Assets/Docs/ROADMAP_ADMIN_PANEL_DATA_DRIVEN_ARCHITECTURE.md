# Roadmap Addendum — Admin Panel and Data-Driven Architecture

**Date:** 2026-05-29  
**Status:** Added to roadmap  
**Scope:** Redefine Cyber Clinic as a no-code/admin-configurable RPG where live content, balance, economy, items, missions, events, cosmetics, and modular systems are managed without code changes.

---

## Strategic decision

Cyber Clinic is no longer a puzzle game.

Cyber Clinic is now a 3D cyber-medical RPG / MMO-lite clinic RPG.

The game must be designed as a data-driven live game where most gameplay content and balancing can be managed from an admin panel instead of requiring code changes.

---

## Core rule

```text
Code defines systems.
Admin data defines content, balance, events, rewards, items, missions, shops, and live operations.
```

The codebase should not require a new build every time the game needs:

```text
New item
New skin
New mission
New event
New season
New leaderboard rule
New drop table
New surgery case
New operation difficulty
New alliance quest
New shop bundle
New reward track
New balance adjustment
```

---

## Admin-configurable systems

The admin panel should eventually manage:

```text
Patient / case templates
Operation difficulty rules
Procedure rules
Risk modifiers
Item definitions
Item stats
Item rarity tiers
Loot tables
Drop chances
Equipment slots
Upgrade costs
Crafting recipes
Research blueprints
Mission definitions
Daily / weekly mission rotations
Streak rewards
Event calendar
Season definitions
Battle pass-like reward tracks
Leaderboard rules
Alliance quests
Alliance events
Group surgery requirements
Raid surgery phases
Cosmetic skins
Shop items
Bundles / offers
Remote config values
Economy balance
Reward tables
Feature flags
A/B test placeholders
Localization keys
Asset reference IDs
VFX / SFX tokens
3D prefab reference IDs
```

---

## M60 — Data Schema Foundation

```text
M60.1 — Content Schema Registry
M60.2 — Item Schema
M60.3 — Mission Schema
M60.4 — Event Schema
M60.5 — Operation Case Schema
M60.6 — Economy / Reward Schema
M60.7 — Schema Validator
```

Goal: Define the structure of all content data before building a real admin panel.

---

## M61 — Local Content Database Foundation

```text
M61.1 — Local Content Store Interface
M61.2 — JSON Content Source
M61.3 — ScriptableObject Bridge Placeholder
M61.4 — Content Version Model
M61.5 — Content Load Result Model
M61.6 — Content Validation Result Model
M61.7 — Local Content Database Validator
```

Goal: Make the game read content from data, not hardcoded values.

---

## M62 — Remote Config / Live Content Contract

```text
M62.1 — Remote Config Key Contract
M62.2 — Live Content Manifest Model
M62.3 — Content Version Compatibility Rules
M62.4 — Feature Flag Model
M62.5 — Rollout / Segment Placeholder Rules
M62.6 — Remote Config Mock Service
M62.7 — Remote Config Validator
```

Goal: Prepare for live changes without app updates.

---

## M63 — Admin Panel Foundation

```text
M63.1 — Admin Module List
M63.2 — Admin User Role Model
M63.3 — Draft / Published Content State
M63.4 — Content Approval Placeholder Rules
M63.5 — Admin Audit Log Model
M63.6 — Admin Export / Import Contract
M63.7 — Admin Foundation Validator
```

Goal: Design the no-code content management layer.

---

## M64 — Admin Item / Equipment Management

```text
M64.1 — Item Editor Contract
M64.2 — Stat Editor Contract
M64.3 — Rarity Editor Contract
M64.4 — Equipment Slot Editor Contract
M64.5 — Upgrade Cost Editor Contract
M64.6 — Loot Source Editor Contract
M64.7 — Admin Item Management Validator
```

Goal: Let items and equipment be created and balanced without code changes.

---

## M65 — Admin Mission / Event / Season Management

```text
M65.1 — Mission Editor Contract
M65.2 — Daily / Weekly Rotation Editor Contract
M65.3 — Event Calendar Editor Contract
M65.4 — Season Editor Contract
M65.5 — Reward Track Editor Contract
M65.6 — Publish Schedule Rules
M65.7 — Admin LiveOps Validator
```

Goal: Let live-ops systems run from admin configuration.

---

## M66 — Admin Operation / Surgery Management

```text
M66.1 — Operation Case Editor Contract
M66.2 — Difficulty Editor Contract
M66.3 — Risk Modifier Editor Contract
M66.4 — Required Equipment / Power Editor Contract
M66.5 — Group Surgery Editor Contract
M66.6 — Raid Surgery Phase Editor Contract
M66.7 — Admin Operation Management Validator
```

Goal: Let surgery content and difficulty evolve without app updates.

---

## M67 — Admin Economy / Reward / Shop Management

```text
M67.1 — Currency Editor Contract
M67.2 — Reward Table Editor Contract
M67.3 — Drop Rate Editor Contract
M67.4 — Shop Item Editor Contract
M67.5 — Bundle / Offer Editor Contract
M67.6 — Economy Simulation Placeholder
M67.7 — Admin Economy Validator
```

Goal: Let reward balance and monetization surfaces be tuned without code changes.

---

## M68 — Admin Cosmetic / Art / VFX Token Management

```text
M68.1 — Skin Editor Contract
M68.2 — Cosmetic Set Editor Contract
M68.3 — 3D Asset Reference Editor Contract
M68.4 — VFX Token Editor Contract
M68.5 — SFX Token Editor Contract
M68.6 — Preview Asset Validation Rules
M68.7 — Admin Cosmetic Validator
```

Goal: Make premium art and cosmetic systems modular and data-driven.

---

## M69 — Admin Alliance / League / Social Management

```text
M69.1 — Alliance Quest Editor Contract
M69.2 — Alliance Event Editor Contract
M69.3 — League Tier Editor Contract
M69.4 — Leaderboard Rule Editor Contract
M69.5 — Social Reward Editor Contract
M69.6 — Moderation Placeholder Contract
M69.7 — Admin Social Validator
```

Goal: Make social and competitive systems configurable from admin data.

---

## M70 — Content Validation and Safe Publishing

```text
M70.1 — Cross-Content Reference Validator
M70.2 — Missing Asset Reference Validator
M70.3 — Economy Balance Warning Rules
M70.4 — Drop Rate Sanity Validator
M70.5 — Publish Blocking Error Rules
M70.6 — Rollback Manifest Model
M70.7 — Safe Publishing Validator
```

Goal: Prevent broken live content from reaching players.

---

## Architecture rule

All major future systems must follow this pattern:

```text
Definition data
Runtime model
Presenter / binding
Validator
Admin schema
Mock local data
Remote/admin-ready contract
```

---

## Near-term impact

Current M15 work should continue, but future operation data must avoid hardcoded values where possible.

Near-term code should start preparing seams for:

```text
case definition IDs
item definition IDs
operation modifier IDs
reward table IDs
feedback token IDs
asset reference IDs
localization keys
```

---

## Implementation rule

Do not build the real admin panel immediately.

First build the game to consume admin-style data locally:

```text
local JSON / mock content
schema validation
content registry
runtime bindings
then backend admin panel
then remote config / publishing
```

This keeps the project moving while ensuring it can scale into a live RPG without constant code updates.
