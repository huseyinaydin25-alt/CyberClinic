# Cyber Clinic — Architecture Overview

**Cyber Clinic** is a Unity 6.3 LTS Universal 2D mobile game. This document describes the production-minded modular layout under `Assets/_CyberClinic` and how systems must stay decoupled as the project grows.

---

## Why modular?

Mobile clinic games mix many concerns: procedural content, economy, reputation, surgery flow, dialogue, VFX/SFX, saves, ads/IAP, and platform APIs. A monolithic layout leads to hidden dependencies, hard-to-test logic, and strings scattered in prefabs.

This project is split into **feature modules** with clear boundaries:

- **Data** lives in ScriptableObjects and localization tables—not in scene-only magic values.
- **Logic** lives in small, focused script folders—one domain per folder.
- **Presentation** (UI, visual feedback, audio feedback) is separate from **simulation/calculation**.
- **Platform services** sit behind interfaces so gameplay never calls AdMob, RevenueCat, notifications, or haptics directly.

New work should extend an existing module or add a new module with the same rules—not bypass them.

---

## Top-level layout

All game-specific content lives under:

```
Assets/_CyberClinic/
```

Project documentation lives under:

```
Assets/Docs/
```

Default Unity template assets (URP settings, sample scene, etc.) may remain outside `_CyberClinic` until migrated intentionally.

---

## Major folders

### `Art/`

Authoring assets only—sprites, atlases, animations, materials used by 2D rendering. Organized by domain:

| Subfolder | Purpose |
|-----------|---------|
| `Characters/` | Staff, NPCs, shared character art |
| `Patients/` | Patient bodies, parts, procedural visual pieces |
| `Implants/` | Implant and cyberware visuals |
| `Backgrounds/` | Clinic rooms, surgery room, environment |
| `UI/` | Icons, frames, UI-specific art (not text strings) |
| `VFX/` | Particle textures, VFX sprites, sheets |

**Rule:** No player-facing text baked into art. Labels and copy use localization.

---

### `Audio/`

Audio clips and related authoring data (not gameplay mix logic).

| Subfolder | Purpose |
|-----------|---------|
| `SFX/` | Short feedback sounds (tools, UI, surgery) |
| `Ambience/` | Room tone, clinic atmosphere |
| `Music/` | Tracks and stems |

Playback and pooling logic belongs in `Scripts/Audio/`. Content definitions (which clip for which event) belong in `ScriptableObjects/Audio/`.

---

### `Prefabs/`

Reusable scene objects—wired in the Editor, driven at runtime by data and systems.

| Subfolder | Purpose |
|-----------|---------|
| `Patients/` | Patient presentation prefabs |
| `Implants/` | Implant visual prefabs |
| `UI/` | Screens, widgets, HUD elements |
| `VFX/` | Effect prefabs |

Prefabs reference **localization keys** and **ScriptableObject IDs**, not hardcoded display strings.

---

### `Scenes/`

Playable and bootstrap scenes.

| Subfolder | Purpose |
|-----------|---------|
| `Boot/` | Initialization, loading, service setup |
| `MainClinic/` | Clinic hub / management flow |
| `SurgeryRoom/` | Procedure gameplay space |

Scenes orchestrate modules; they should not contain business rules inline.

---

### `Scripts/`

Runtime code only—organized by **domain module**. Each folder is a bounded context.

| Subfolder | Module responsibility |
|-----------|----------------------|
| `Core/` | App lifecycle, service locator/DI hooks, shared contracts, bootstrapping |
| `Patients/` | Procedural patient generation orchestration (not SO data) |
| `Implants/` | Implant selection/application rules |
| `Procedures/` | Surgery/procedure flow |
| `Complications/` | Complication resolution |
| `Economy/` | Currency, costs, rewards (calculation only) |
| `Events/` | Clinic events scheduling and outcomes |
| `UI/` | Views, presenters, input routing—**no economy math** |
| `Visual/` | Visual feedback triggers (particles, highlights)—**no gameplay math** |
| `Audio/` | Audio feedback triggers—**no gameplay math** |
| `Localization/` | Key resolution, table loading helpers |
| `Save/` | Serialization, profiles, migration |
| `Progression/` | Unlocks, reputation tiers, meta progression |
| `PlatformServices/` | Interfaces + adapters for ads, IAP, analytics, notifications, haptics |
| `Utilities/` | Pure helpers with no domain knowledge |

**Do not** place cross-cutting gameplay in `Utilities/` to avoid “god helpers.”

---

### `ScriptableObjects/`

**Authoritative content definitions**—designer-tunable, versionable, data-driven.

| Subfolder | Content type |
|-----------|----------------|
| `Patients/` | Patient templates, trait pools, generation parameters |
| `Implants/` | Implant definitions, stats, compatibility |
| `Procedures/` | Procedure steps, durations, requirements |
| `Complications/` | Complication types, weights, outcomes |
| `Events/` | Clinic event definitions |
| `Dialogue/` | Dialogue graphs/lines referencing **localization keys only** |
| `Economy/` | Prices, payouts, economy curves |
| `Visual/` | Visual feedback mappings (event → VFX prefab/params) |
| `Audio/` | Audio feedback mappings (event → clip/params) |

Runtime **instances** (e.g. “Patient #7 in today’s queue”) are not ScriptableObjects—they are plain runtime objects built from SO definitions.

---

### `Localization/`

Unity Localization package assets.

| Subfolder | Purpose |
|-----------|---------|
| `StringTables/` | All player-visible strings |
| `AssetTables/` | Localized sprites/assets where needed |

Every UI label, dialogue line, tutorial, error, and notification body must resolve through a **localization key**—never a literal string in code or prefab text components.

---

### `Settings/`

Project-specific settings assets for Cyber Clinic (input maps, layer tags, addressable groups, module config ScriptableObjects, etc.)—distinct from root `Assets/Settings/` URP template files.

---

## Decoupling rules (mandatory)

These boundaries apply as soon as gameplay code is added:

1. **Gameplay ↔ UI**  
   Gameplay publishes state/events; UI subscribes and renders. UI never computes rewards, reputation, or procedure outcomes.

2. **Gameplay ↔ Visual / Audio feedback**  
   Gameplay raises semantic events (e.g. `ProcedureStepCompleted`). Visual and Audio modules map events to presentation via `ScriptableObjects/Visual` and `ScriptableObjects/Audio`.

3. **Gameplay ↔ Platform services**  
   Gameplay depends on interfaces in `Scripts/PlatformServices/`. Concrete AdMob, RevenueCat, push, and haptic implementations live in adapters—not in procedure or economy code.

4. **Gameplay ↔ Save**  
   Save module reads/writes DTOs; domain modules expose snapshot APIs. Avoid static “SaveManager everywhere” calls from UI.

5. **Content ↔ Code**  
   Balance and copy change in ScriptableObjects and string tables. Code defines *how* to apply data, not *what* the next implant costs.

6. **Localization ↔ Everything**  
   All visible text flows: key → Unity Localization → UI/TextMeshPro. No exceptions for “temporary” debug UI in builds.

---

## Data-driven workflow

1. Designers create/edit ScriptableObjects under `ScriptableObjects/<Domain>/`.
2. Translators edit `Localization/StringTables/` (and `AssetTables/` if needed).
3. Artists/audio attach assets under `Art/` and `Audio/`.
4. Prefabs bind references to SO assets and localization keys.
5. Runtime modules load definitions, spawn instances, and emit events.

---

## What not to put here (yet)

Per project phase zero:

- No gameplay logic scripts until modules are specified in the roadmap.
- No placeholder “manager” singletons that fake entire systems.
- No package installs or project setting changes documented here—those are tracked in `DECISIONS.md` and `CHANGELOG.md`.

When adding a feature, ask: **Which module owns this?** If two modules need it, extract a contract to `Core/` or a shared interface—not a shared static class.

---

## Related documents

| Document | Location |
|----------|----------|
| Coding & process rules | `Assets/Docs/DEVELOPMENT_RULES.md` |
| Product roadmap | `Assets/Docs/ROADMAP.md` |
| Architecture decisions | `Assets/Docs/DECISIONS.md` |
| Change history | `Assets/Docs/CHANGELOG.md` |
