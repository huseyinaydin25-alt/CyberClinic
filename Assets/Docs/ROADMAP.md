# Cyber Clinic — Living Roadmap

> **This file is the main living roadmap and project memory.**  
> Update after **every major milestone**. Sync with `CHANGELOG.md`, `DECISIONS.md`, and relevant design memory docs.

**Last updated:** 2026-05-23  
**Current milestone:** **3 — Procedural Patient Generator** (next)  
**Doc version:** 0.2.6

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
| Gameplay logic | Not started |
| Unity packages | Localization + Addressables installed |
| Orientation | Landscape decided |
| Supabase | Interfaces only; no integration |
| AdMob | Pending approval; `IAdService` only |
| Next practical step | Milestone 3 — Procedural Patient Generator |

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

### Milestone 3 — Procedural Patient Generator `Next`

- Deterministic seed support
- Archetypes, motivations, hidden conditions
- Visual traits, known/unknown model
- Scan reveal rules
- No UI, operation calculator, save, backend, or platform SDK implementation

---

### Milestone 4 — Implant and Procedure System `Planned`

- Implant compatibility matrix
- Body slots
- Procedure difficulty
- Legal status tiers
- Quality tiers
- Visual variant links

---

### Milestone 5 — Operation Calculation System `Planned`

- Deterministic OperationCalculator
- Risk breakdown DTO
- Success chance + risk bands
- CyberTox / neural load / hidden penalty / panic / illegal risk
- No money/reputation/save side effects

---

### Milestone 6 — First Landscape UI Skeleton `Planned`

- Landscape patient file UI
- Implant selection UI
- Risk preview UI
- Result panel UI
- All localized

---

### Milestone 7 — Visual Feedback Foundation `Planned`

- Scan effect
- Glitch effect
- Warning pulse
- Result reveal
- UI transitions
- Event-driven VisualFeedbackManager stack

---

### Milestone 8 — Audio Feedback Foundation `Planned`

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
2. Start Milestone 3 with procedural patient generator planning/implementation.
3. Read `PROCEDURAL_PATIENT_SYSTEM.md`, `GAME_DESIGN_MEMORY.md`, `LOCALIZATION_PLAN.md`, `TUTORIAL_DESIGN.md`, and M1 data contracts before coding.
4. Build only deterministic patient generation logic and related tests/debug helpers.
5. Do not add gameplay UI, OperationCalculator, SDK integrations, backend implementation, or scene work during M3.

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
