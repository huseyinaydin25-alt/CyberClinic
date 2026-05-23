# Cyber Clinic — Architecture Overview

**Cyber Clinic** is a Unity 6.3 LTS Universal 2D mobile game. This document describes the production-minded modular layout under `Assets/_CyberClinic`, how systems stay decoupled, and how **design memory docs** govern implementation.

---

## Mandatory context for Cursor (read before coding)

Before implementing **any** system, read the relevant design memory in `Assets/Docs/`:

| If you are building… | Read first |
|----------------------|------------|
| Anything | `ROADMAP.md`, `DEVELOPMENT_RULES.md` |
| Patient flow / generation | `GAME_DESIGN_MEMORY.md`, `PROCEDURAL_PATIENT_SYSTEM.md` |
| Surgery / risk / outcomes | `OPERATION_MATH.md`, `GAME_DESIGN_MEMORY.md` |
| UI / copy | `LOCALIZATION_PLAN.md`, `DEVELOPMENT_RULES.md` |
| VFX / animation / juice | `VISUAL_AUDIO_DIRECTION.md` |
| Audio | `VISUAL_AUDIO_DIRECTION.md` |
| IAP / ads / push / haptics | `PLATFORM_SERVICES_PLAN.md` |
| Saves / day loop / economy | `ROADMAP.md` (M9–10), `GAME_DESIGN_MEMORY.md` |

These documents are **permanent design memory**—not suggestions. If implementation diverges, update the doc in the same change set or fix the code.

**Rule (see `DEVELOPMENT_RULES.md` §11):** Before implementing a new system, check the relevant `Assets/Docs/` file and update it if the plan changes.

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

## Design memory ↔ module map

| Design doc | `Scripts/` module | `ScriptableObjects/` |
|------------|-------------------|----------------------|
| `PROCEDURAL_PATIENT_SYSTEM.md` | `Patients/` | `Patients/` |
| Implants (ROADMAP M4) | `Implants/` | `Implants/` |
| Procedures (ROADMAP M4–5) | `Procedures/` | `Procedures/` |
| `OPERATION_MATH.md` | `Procedures/` (+ pure calculator type) | `Procedures/`, tuning SO |
| Complications | `Complications/` | `Complications/` |
| Clinic events | `Events/` | `Events/` |
| Dialogue | — (data) | `Dialogue/` |
| Economy / day | `Economy/` | `Economy/` |
| `VISUAL_AUDIO_DIRECTION.md` | `Visual/`, `Audio/` | `Visual/`, `Audio/` |
| `LOCALIZATION_PLAN.md` | `Localization/` | `Localization/StringTables/` |
| Save | `Save/` | — |
| Meta unlocks | `Progression/` | — |
| `PLATFORM_SERVICES_PLAN.md` | `PlatformServices/` | — |
| Shared boot/DI | `Core/` | `Settings/` |

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

**Style reference:** `VISUAL_AUDIO_DIRECTION.md` (cyberpunk medical noir, neon, rain, holographic UI).

---

### `Audio/`

Audio clips and related authoring data (not gameplay mix logic).

| Subfolder | Purpose |
|-----------|---------|
| `SFX/` | Short feedback sounds (tools, UI, surgery) |
| `Ambience/` | Room tone, clinic atmosphere, rain |
| `Music/` | Tracks and stems |

Playback and pooling logic belongs in `Scripts/Audio/`. Content definitions (which clip for which event) belong in `ScriptableObjects/Audio/`.

**Direction:** `VISUAL_AUDIO_DIRECTION.md`

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
| `Boot/` | Initialization, loading, **platform service registration** |
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
| `Procedures/` | Surgery/procedure flow, **pure operation calculator** |
| `Complications/` | Complication resolution |
| `Economy/` | Currency, costs, rewards (calculation only) |
| `Events/` | Clinic events scheduling and outcomes |
| `UI/` | Views, presenters, input routing—**no economy math** |
| `Visual/` | VFX feedback triggers—**no gameplay math** |
| `Audio/` | Audio feedback triggers—**no gameplay math** |
| `Localization/` | Key resolution, table loading helpers |
| `Save/` | Serialization, profiles, migration |
| `Progression/` | Unlocks, reputation tiers, meta progression |
| `PlatformServices/` | Interfaces + adapters (RevenueCat, AdMob, notifications, haptics) |
| `Utilities/` | Pure helpers with no domain knowledge |

**Do not** place cross-cutting gameplay in `Utilities/` to avoid “god helpers.”

---

### `ScriptableObjects/`

**Authoritative content definitions**—designer-tunable, versionable, data-driven.

| Subfolder | Content type |
|-----------|----------------|
| `Patients/` | Archetypes, trait pools, generation parameters |
| `Implants/` | Implant definitions, stats, compatibility |
| `Procedures/` | Procedure steps, durations, requirements |
| `Complications/` | Complication types, weights, outcomes |
| `Events/` | Clinic event definitions |
| `Dialogue/` | Dialogue graphs/lines referencing **localization keys only** |
| `Economy/` | Prices, payouts, economy curves |
| `Visual/` | Visual feedback mappings (event → VFX prefab/params) |
| `Audio/` | Audio feedback mappings (event → clip/params) |

Runtime **instances** (e.g. “Patient #7 in today’s queue”) are not ScriptableObjects—they are plain runtime objects built from SO definitions.

Schema guidance: `PROCEDURAL_PATIENT_SYSTEM.md`, `OPERATION_MATH.md`

---

### `Localization/`

Unity Localization package assets (install at Milestone 2).

| Subfolder | Purpose |
|-----------|---------|
| `StringTables/` | All player-visible strings |
| `AssetTables/` | Localized sprites/assets where needed |

Every UI label, dialogue line, tutorial, error, and notification body must resolve through a **localization key**—never a literal string in code or prefab text components.

**Plan:** `LOCALIZATION_PLAN.md`

---

### `Settings/`

Project-specific settings assets for Cyber Clinic (input maps, layer tags, addressable groups, module config ScriptableObjects, etc.)—distinct from root `Assets/Settings/` URP template files.

---

## Decoupling rules (mandatory)

These boundaries apply as soon as gameplay code is added:

1. **Gameplay ↔ UI**  
   Gameplay publishes state/events; UI subscribes and renders. UI never computes rewards, reputation, or procedure outcomes.

2. **Gameplay ↔ Visual / Audio feedback**  
   Gameplay raises semantic events (e.g. `OperationResolved`). Visual and Audio modules map events to presentation via `ScriptableObjects/Visual` and `ScriptableObjects/Audio`. See `VISUAL_AUDIO_DIRECTION.md`.

3. **Gameplay ↔ Platform services**  
   Gameplay depends on interfaces in `Scripts/PlatformServices/`. See `PLATFORM_SERVICES_PLAN.md`.

4. **Gameplay ↔ Save**  
   Save module reads/writes DTOs; domain modules expose snapshot APIs.

5. **Operation calculator purity**  
   `OperationCalculator` returns results only; Economy/Reputation/Save react to events. See `OPERATION_MATH.md`.

6. **Content ↔ Code**  
   Balance and copy change in ScriptableObjects and string tables.

7. **Localization ↔ Everything**  
   All visible text flows: key → Unity Localization → UI/TextMeshPro.

8. **Deterministic generation**  
   Patient and operation seeds produce identical results on all platforms. See `PROCEDURAL_PATIENT_SYSTEM.md`.

---

## Data-driven workflow

1. Designers create/edit ScriptableObjects under `ScriptableObjects/<Domain>/`.
2. Translators edit `Localization/StringTables/` (and `AssetTables/` if needed).
3. Artists/audio attach assets under `Art/` and `Audio/`.
4. Prefabs bind references to SO assets and localization keys.
5. Runtime modules load definitions, spawn instances, and emit events.

---

## What not to put here (yet)

Per roadmap before Milestone 1:

- No gameplay logic scripts until data models are defined.
- No placeholder “manager” singletons that fake entire systems.
- No package installs or project setting changes without `CHANGELOG.md` + `DECISIONS.md`.

When adding a feature, ask: **Which module owns this?** If two modules need it, extract a contract to `Core/` or a shared interface—not a shared static class.

---

## Related documents

| Document | Purpose |
|----------|---------|
| `ROADMAP.md` | Milestones, status, next steps |
| `GAME_DESIGN_MEMORY.md` | Core puzzle, tone, replayability |
| `PROCEDURAL_PATIENT_SYSTEM.md` | Patient generation |
| `OPERATION_MATH.md` | Operation calculator |
| `VISUAL_AUDIO_DIRECTION.md` | VFX/audio modules |
| `LOCALIZATION_PLAN.md` | Locales and keys |
| `PLATFORM_SERVICES_PLAN.md` | SDK abstraction |
| `DEVELOPMENT_RULES.md` | Coding rules |
| `DECISIONS.md` | ADRs |
| `CHANGELOG.md` | Version history |
