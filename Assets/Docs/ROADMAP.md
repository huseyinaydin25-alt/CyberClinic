# Cyber Clinic — Living Roadmap

> **This file is the main living roadmap and project memory.**  
> Update after **every major milestone**. Sync with `CHANGELOG.md`, `DECISIONS.md`, and relevant design memory docs.

**Last updated:** 2026-05-27  
**Current milestone:** **8 — Audio Feedback Foundation** (next)  
**Doc version:** 0.7.0

---

## Project identity

| Field | Value |
|-------|-------|
| **Game** | Cyber Clinic |
| **Engine** | Unity 6.3 LTS |
| **Template** | Universal 2D (URP) |
| **Genre** | 2D cyberpunk medical management puzzle |
| **Orientation** | **Landscape / yatay mobile gameplay** |
| **First test platform** | Android |
| **Commercial platforms** | Android + iOS |
| **iOS CI/CD** | CodeMagic → TestFlight |
| **Implementation** | User does not write code; **Cursor + ChatGPT** guide implementation |

---

## Project philosophy

Cyber Clinic will not be developed with a “fix it later” mindset. The previous project taught that late architecture, late localization, late visual polish, and weak docs create expensive regressions. Cyber Clinic will move slowly, with baby steps, but on a strong foundation.

1. **Design memory before code** — Permanent docs in `Assets/Docs/` define behavior; code follows.
2. **Landscape-first** — UI, clinic layout, patient screen, scan screen, and operation panels are designed for horizontal mobile play.
3. **Incomplete-information puzzle** — Players solve risk/economy/reputation tradeoffs, not “pick best implant.”
4. **Feel is gameplay** — Visuals, animation, UI motion, SFX, ambience, haptics, scanlines, glitch, and result reveals teach consequences.
5. **Data-driven content** — Patients, implants, procedures, events, cosmetics, clinic themes, dialogue, economy, VFX and audio mappings must be content-driven.
6. **Decoupled modules** — Patients, implants, procedures, math, economy, events, UI, feedback, save, platform, backend, tutorial, cosmetics—separate.
7. **Deterministic core** — Procedural generation and operation math are seed-stable and reproducible.
8. **Shippable i18n** — No hardcoded player-facing text, ever on `main`.
9. **Long-term visual evolution** — The clinic must not remain visually static; progression, reputation, cosmetics, and events change the look and feel over time.
10. **Offline-first gameplay** — Supabase can enhance the game, but the core loop must work without backend connection.

---

## Current milestone status

| Area | State |
|------|-------|
| Unity project | Created, Universal 2D |
| Design memory | Done |
| Data architecture (M1) | Done |
| Localization (M2) | Done |
| First-time tutorial design (M1.5) | Done |
| Cosmetic / clinic visual progression design (M1.6) | **Done** |
| Procedural patients (M3) | **Done** — deterministic generator validated with Patient*Data test assets |
| Implant / procedure data (M4) | **Done** — data foundation and debug validation complete |
| Operation calculation (M5) | **Done** — pure deterministic calculator and debug validation complete |
| First landscape UI skeleton (M6) | **Done** — skeleton prefab, builder, and validator complete |
| Visual feedback foundation (M7) | **Done** — semantic cue routing and debug validation complete |
| Gameplay logic | Generator, data foundations, pure operation math, first UI skeleton, and feedback routing only |
| Unity packages | Localization + Addressables installed |
| Orientation | Landscape decided |
| Supabase | Interfaces only; no integration |
| AdMob | Pending approval; `IAdService` only |
| Next practical step | Milestone 8 — Audio Feedback Foundation |

---

## Development workflow

| Tool | Role |
|------|------|
| **Unity 6.3 LTS** | Editor, builds, assets, scenes, prefabs, visual/audio work |
| **Cursor** | Primary implementation agent for code and generated files |
| **ChatGPT** | Design memory owner, docs updates, planning, review, architectural control |
| **GitHub Desktop + GitHub** | Version control, commits, push/pull |
| **CodeMagic** | iOS builds later (Milestone 12) |
| **Supabase** | Planned online service layer, not core gameplay dependency |

**Process:** milestone goal → read design docs → Cursor implements → Unity validates → user pushes → ChatGPT updates docs → user pulls.

---

## Documentation responsibility

`Assets/Docs/` is the project memory. Cursor may create or draft docs, but the final responsibility for roadmap, design memory, changelog, and decisions belongs to ChatGPT.

Working rule:

1. User works locally in Unity/Cursor.
2. User commits and pushes through GitHub Desktop.
3. ChatGPT checks GitHub state.
4. ChatGPT updates `Assets/Docs/` when needed.
5. User pulls the doc updates.

---

## Platform and service strategy

- **Android first** for daily testing and iteration.
- **iOS parity** in architecture from day one.
- **CodeMagic** for iOS signing and TestFlight when vertical slice is stable.
- **Apple Developer:** ready.
- **Google Play Console:** ready.
- **RevenueCat / RevenueKit:** ready.
- **AdMob:** pending approval; use mocks until active.
- **Supabase:** planned as online service layer; empty project can be created later.

See `PLATFORM_SERVICES_PLAN.md` and `SUPABASE_BACKEND_PLAN.md`.

---

## Core design rules

| Rule | Doc |
|------|-----|
| No hardcoded player-facing text | `LOCALIZATION_PLAN.md`, `DEVELOPMENT_RULES.md` |
| Localization keys only | `LOCALIZATION_PLAN.md` |
| ScriptableObject content | `README_ARCHITECTURE.md`, `DEVELOPMENT_RULES.md` |
| Modular systems | `README_ARCHITECTURE.md` |
| Deterministic procedural generation | `PROCEDURAL_PATIENT_SYSTEM.md`, `DECISIONS.md` |
| OperationCalculator is pure | `OPERATION_MATH.md` |
| Visual/audio as core feedback | `VISUAL_AUDIO_DIRECTION.md` |
| First tutorial is critical | `TUTORIAL_DESIGN.md` |
| Cosmetics and visual progression are long-term retention systems | `COSMETIC_SYSTEM.md`, `CLINIC_VISUAL_PROGRESSION.md` |
| Platform SDKs behind interfaces | `PLATFORM_SERVICES_PLAN.md` |
| Backend behind interfaces | `SUPABASE_BACKEND_PLAN.md` |
| Git discipline — commit per milestone | `DEVELOPMENT_RULES.md` |

---

## Core game loop

```text
Day Start
  → Clinic state loaded (save/progression)
  → Procedural patient queue generated (seeded)
  → For each patient slot:
       Intake: Accept / Reject
       Investigate: Scan / Deep scan / Skip
       Plan: Implant tier + procedure + risk preview
       Operate: Commit → deterministic result
       Consequences: Economy, reputation, complications, feedback
  → Day End Report
  → Save
```

**Core question:**  
Given this patient's request, budget, tolerance, hidden conditions, clinic capabilities, and legal risk, what plan balances profit, safety, and reputation?

Detail: `GAME_DESIGN_MEMORY.md`

---

## First-time tutorial priority

Cyber Clinic is niche and can look complex. The first tutorial must be a controlled, enjoyable, atmospheric first case—not a dry popup sequence.

Tutorial design is now anchored around:

- **Case 001 — The Runner at the Door**
- a street courier/netrunner first patient
- mild neural instability revealed by scan
- a safe guided but real implant decision
- beat-by-beat tutorial flow from clinic boot to first success
- short localized prompts and no hardcoded tutorial copy
- skip/replay policy draft
- required VFX/SFX feedback map

Detail: `TUTORIAL_DESIGN.md`

---

## Cosmetic and interchangeable visual strategy

Cyber Clinic must not use one static clinic and one static UI forever. The player should see clinic growth through environment, UI, scan effects, result reveals, operation equipment, and ambience.

M1.6 finalized these principles:

- cosmetics must be visible or meaningfully felt in the core loop
- premium visuals must not create unfair core math advantage
- visual packs must be swappable by data/configuration
- clinic tiers must preserve landscape readability
- seasonal/special-day visuals should be data overlays, not separate hardcoded scenes
- cosmetic names/descriptions/store labels must use localization keys
- ownership must be save-safe and cloud-sync-ready later

Detail: `COSMETIC_SYSTEM.md` and `CLINIC_VISUAL_PROGRESSION.md`

---

## Milestone plan

### Milestone 0 — Project Foundation `Done`

- Unity project creation
- GitHub repo
- Folder structure
- Initial docs

---

### Milestone 0.5 — Design Memory Foundation `Done`

- Permanent design memory docs
- Full roadmap
- Core design memory docs created

---

### Milestone 1 — Architecture and Data Foundation `Done`

- ScriptableObject data model classes created.
- Runtime model classes created.
- Core deterministic utility contracts created.
- Localization reference types created.
- Backend and platform service interfaces created.
- Save/progression/cosmetic/tutorial data contracts created.
- Unity compile confirmed with no Console errors.
- Architecture review pass completed with serialization and determinism fixes.
- No gameplay UI, scenes, prefabs, packages, SDK integrations, patient generator, or OperationCalculator were created.

---

### Milestone 1.5 — First-Time Tutorial Design `Done`

- Canonical first case documented: **Case 001 — The Runner at the Door**.
- Tutorial beat map documented from clinic boot to first success.
- UI guidance/highlight rules drafted.
- Skip and replay policy drafted.
- VFX/SFX requirements listed.
- Tutorial localization key gaps identified and added to `Tutorial.csv`.
- Unity localization setup re-run successfully: 96 keys across 11 tables.
- Validator returned no suspicious hardcoded player-facing strings.
- No gameplay implementation was created.

---

### Milestone 1.6 — Cosmetic, Clinic Progression and Interchangeable Visual Design `Done`

- Cosmetic categories documented.
- Clinic tier visual language expanded.
- Landscape visual composition constraints documented.
- Data-driven visual pack approach documented.
- Premium/progression/event reward boundaries documented.
- Functional cosmetic limits documented.
- Ownership/save/cloud-sync implications documented.
- Cosmetic and clinic localization seed keys expanded.
- Unity localization setup re-run successfully after key additions.
- No store implementation, gameplay UI, SDK integration, backend implementation, or scene work was created.

---

### Milestone 2 — Localization Foundation `Done`

- Unity Localization package (`com.unity.localization`) and Addressables dependency added.
- English (`en`) base locale and Turkish (`tr`) secondary locale created.
- String table collections created: UI, Tutorial, Patients, Implants, Procedures, Economy, Events, Cosmetics, Clinic, Errors, System.
- CSV seed data created under `Assets/_CyberClinic/Localization/StringTables/Seed/` with en/tr values.
- Setup menu and hardcoded text validator created.
- Initial setup imported 85 keys; later milestone key expansions increased the imported key count.

---

### Milestone 3 — Procedural Patient Generator `Done`

- Deterministic `PatientGenerator` + `CyberClinicRandom` / `SeedContext`.
- Weighted pool selection from Patient*Data ScriptableObjects.
- Known vs hidden info on runtime `GeneratedPatient`.
- `PatientIdFactory` creates deterministic ids; no `Guid.NewGuid` is used for generated patients.
- Tutorial-safe mode constraints in `PatientGenerationConfig`.
- Editor debug menu: **Cyber Clinic/Patients/Generate Debug Patient**.
- Minimal editor-only Patient*Data assets created under `Assets/_CyberClinic/Data/Patients/TestSeed/`.
- Debug generation validated twice with seed `84921`, day `3`, slot `0`; output was identical across runs.
- Completion details recorded in `MILESTONE_3_COMPLETION.md`.
- No UI, operation calculator, save, backend, platform SDK, scan reveal service, scene, or prefab work was created.

---

### Milestone 4 — Implant and Procedure System `Done`

- Implant compatibility relation types added.
- `ImplantCompatibilityRuleData` expanded into data-driven compatibility rules.
- `ImplantVisualVariantData` added for visual variant links.
- `ProcedureImplantCompatibilityData` added for procedure + implant compatibility metadata.
- Implant and procedure localization key convention helpers added.
- Minimal editor-only test assets created for implants, procedures, compatibility rules, visual variants, and procedure compatibility.
- Editor debug menu: **Cyber Clinic/Implants/Validate Debug Data**.
- Debug validation confirmed 2 implants, 2 procedures, 2 compatibility rules, 2 visual variants, and 2 procedure compatibility assets.
- Completion details recorded in `MILESTONE_4_COMPLETION.md`.
- No UI, operation calculator, save, backend, platform SDK, scene, prefab, economy, reputation, or day-flow work was created.

---

### Milestone 5 — Operation Calculation System `Done`

- Pure deterministic `OperationCalculator` added.
- `OperationBreakdownEntry` DTO added for localized breakdown terms.
- `OperationResult` DTO added for calculation output.
- `OperationOutcomeType.PreviewOnly` added for preview calculations.
- `ProcedurePlan` expanded with calculation fields.
- Editor debug menu: **Cyber Clinic/Procedures/Run Operation Calculator Debug**.
- Debug validation confirmed deterministic preview and commit output with seeded variance.
- Completion details recorded in `MILESTONE_5_COMPLETION.md`.
- No UI, save, backend, platform SDK, scene, prefab, economy, reputation, day-flow, VFX, or audio feedback work was created.

---

### Milestone 6 — First Landscape UI Skeleton `Done`

- First landscape UI skeleton prefab created.
- `LandscapeUIScreenId` added for first four screen ids.
- `LandscapeUIPanel` technical marker component added.
- `CyberLocalizedText` localization-key placeholder marker added.
- Editor builder menu: **Cyber Clinic/UI/Create Landscape Skeleton Prefab**.
- Editor validator menu: **Cyber Clinic/UI/Validate Landscape Skeleton Prefab**.
- Validation confirmed 4 panels, 4 localized placeholder labels, 1920x1080 reference resolution, and ScreenSpaceOverlay render mode.
- Completion details recorded in `MILESTONE_6_COMPLETION.md`.
- No save, backend, platform SDK, economy, reputation, day-flow, VFX/audio implementation, or production content expansion was created.

---

### Milestone 7 — Visual Feedback Foundation `Done`

- Semantic feedback event ids added.
- Feedback categories added.
- `ClinicFeedbackRequest` DTO added.
- `ClinicFeedbackCueData` ScriptableObject cue data added.
- `ClinicFeedbackRouter` added for request-to-cue routing.
- Minimal test cue assets created under `Assets/_CyberClinic/Data/Feedback/TestSeed/`.
- Editor debug menu: **Cyber Clinic/Feedback/Validate Debug Cues**.
- Debug validation confirmed scan, warning pulse, and result reveal cue routing.
- Completion details recorded in `MILESTONE_7_COMPLETION.md`.
- No gameplay math, save, backend, platform SDK, economy, reputation, day-flow, audio implementation, or production VFX assets were created.

---

### Milestone 8 — Audio Feedback Foundation `Next`

- AudioManager
- SFX library
- Ambience
- Scan / warning / success / failure sounds
- Music state hooks

---

### Milestone 9 — Economy, Reputation and Day Flow `Planned`

- Money
- Reputation
- Day manager
- Clinic state
- Day end report

---

### Milestone 10 — Save System Foundation `Planned`

- Versioned save format
- Save / load
- Platform-independent persistence
- Cosmetic ownership and clinic tier save fields planned

---

### Milestone 10.5 — Platform Services Abstraction `Planned`

- RevenueCat abstraction
- AdMob abstraction and mocks
- Notifications abstraction
- Haptics abstraction
- No SDK calls outside platform services

---

### Milestone 10.6 — Supabase Backend Foundation `Planned`

- Empty Supabase project
- SQL schema draft
- RLS planning
- Backend interfaces and mocks
- Remote config / cloud save / leaderboard / live events plan

---

### Milestone 11 — Visual Patient Puzzle Slice `Planned`

- One procedural patient
- Three implant choices
- Scan screen
- Operation result
- Money / reputation change
- Glitch / scan / warning / success / fail feedback
- Landscape UI validation

---

### Milestone 12 — CodeMagic iOS Build Pipeline `Planned`

- CodeMagic setup
- GitHub connection
- App Store Connect API
- Signing / provisioning
- TestFlight build

---

## Immediate next steps

1. User pulls latest documentation updates.
2. Start Milestone 8 — Audio Feedback Foundation planning.
3. Read `VISUAL_AUDIO_DIRECTION.md`, `GAME_DESIGN_MEMORY.md`, `LOCALIZATION_PLAN.md`, M7 feedback contracts, and existing service abstraction rules before audio work.
4. Build only audio feedback foundation components needed by M8.
5. Do not add save, backend, platform SDK, economy, reputation, day-flow, production VFX expansion, or production content expansion during M8.

---

## Version history

| Version | Date | Milestone | Notes |
|---------|------|-----------|-------|
| 0.0.0 | 2026-05-23 | M0 | Folder architecture + initial docs |
| 0.0.1 | 2026-05-23 | M0.5 | Full design memory + living roadmap |
| 0.0.2 | 2026-05-23 | M0.5 | Added landscape, tutorial, cosmetics, clinic visual progression, Supabase strategy, and ChatGPT docs ownership |
| 0.1.0 | 2026-05-23 | M1 | Architecture and data foundation compiled and reviewed |
| 0.2.0 | 2026-05-23 | M2 | Localization foundation installed, seeded, and validated |
| 0.2.5 | 2026-05-23 | M1.5 | First tutorial design finalized and tutorial localization keys imported |
| 0.2.6 | 2026-05-23 | M1.6 | Cosmetic and clinic visual progression design finalized |
| 0.3.0 | 2026-05-27 | M3 | Procedural Patient Generator completed and deterministic debug generation validated |
| 0.4.0 | 2026-05-27 | M4 | Implant and Procedure System data foundation completed and debug validation confirmed |
| 0.5.0 | 2026-05-27 | M5 | Operation Calculation System completed and deterministic calculator debug validation confirmed |
| 0.6.0 | 2026-05-27 | M6 | First Landscape UI Skeleton completed and prefab validation confirmed |
| 0.7.0 | 2026-05-27 | M7 | Visual Feedback Foundation completed and cue routing validation confirmed |

---

## Milestone log

| Date | Milestone | Notes |
|------|-----------|-------|
| 2026-05-23 | M0 — Project Foundation | Initial structure |
| 2026-05-23 | M0.5 — Design Memory Foundation | Expanded project memory |
| 2026-05-23 | M1 — Architecture and Data Foundation | Data contracts, SO definitions, runtime models, interfaces; no gameplay logic |
| 2026-05-23 | M2 — Localization Foundation | Unity Localization package, en/tr locales, 11 string table collections, validator |
| 2026-05-23 | M1.5 — First-Time Tutorial Design | Case 001, beat map, tutorial localization keys, no gameplay implementation |
| 2026-05-23 | M1.6 — Cosmetic / Clinic Visual Progression | Cosmetic system, clinic tiers, visual packs, localization keys, no store implementation |
| 2026-05-27 | M3 — Procedural Patient Generator | Deterministic generator, Patient*Data test assets, debug validation; no UI, OperationCalculator, save, backend, SDK, scene, or prefab work |
| 2026-05-27 | M4 — Implant and Procedure System | Implant/procedure data foundation, compatibility rules, visual variants, debug validation; no UI, OperationCalculator, save, backend, SDK, scene, or prefab work |
| 2026-05-27 | M5 — Operation Calculation System | Pure deterministic calculator, risk bands, outcome type, breakdown DTO, debug validation; no UI, save, backend, SDK, economy, day-flow, VFX, or audio work |
| 2026-05-27 | M6 — First Landscape UI Skeleton | Landscape skeleton prefab, panel markers, localization-key placeholders, builder and validator; no save, backend, SDK, economy, day-flow, VFX/audio work |
| 2026-05-27 | M7 — Visual Feedback Foundation | Semantic feedback routing, cue data, test cue assets, debug validation; no gameplay math, save, backend, SDK, economy, day-flow, audio, or production VFX work |
