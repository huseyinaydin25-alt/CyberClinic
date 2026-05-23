# Cyber Clinic — Living Roadmap

> **This file is the main living roadmap and project memory.**  
> Update after **every major milestone**. Sync with `CHANGELOG.md`, `DECISIONS.md`, and relevant design memory docs.

**Last updated:** 2026-05-23  
**Current milestone:** **0.5 — Design Memory Foundation** (expanded; docs review in progress)  
**Doc version:** 0.0.2

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

Tutorial goals:

- teach one mechanic at a time
- use the first patient as a story/teaching case
- show scan, hidden risk, implant choice, risk preview, operation commit, and result reveal
- make the player feel the clinic atmosphere immediately
- avoid overwhelming UI density
- use localization keys for all tutorial copy
- remain replayable later

Detail: `TUTORIAL_DESIGN.md`

---

## Cosmetic and interchangeable visual strategy

Cyber Clinic must not use one static clinic and one static UI forever. The player should see clinic growth through environment, UI, scan effects, result reveals, operation equipment, and ambience.

Visual progression and cosmetic systems can support:

- reputation progression
- clinic tier upgrades
- event rewards
- premium visual packs
- seasonal themes
- UI/scan/VFX personalization
- long-term retention

Detail: `COSMETIC_SYSTEM.md` and `CLINIC_VISUAL_PROGRESSION.md`

---

## System concepts

| System | Summary | Design doc |
|--------|---------|------------|
| Procedural patient | Archetype + motivation + problems + hidden traits; seed-stable | `PROCEDURAL_PATIENT_SYSTEM.md` |
| Implants | Slots, tiers, compatibility, legality, visual variants | M4; `GAME_DESIGN_MEMORY.md` |
| Procedures | Difficulty, body stress, request links | M4–5 |
| Operation math | Deterministic success chance + risk bands + breakdown | `OPERATION_MATH.md` |
| Tutorial | First controlled atmospheric learning case | `TUTORIAL_DESIGN.md` |
| Economy & reputation | Money, clinic brand, long-term progression | M9 |
| Cosmetics | Visual packs, UI themes, scan styles, premium/event rewards | `COSMETIC_SYSTEM.md` |
| Clinic visual progression | Back-alley to elite clinic visual evolution | `CLINIC_VISUAL_PROGRESSION.md` |
| Clinic events | Special days, seasons, supply shocks, raids | M9+, `SUPABASE_BACKEND_PLAN.md` |
| Localization | en base, tr secondary; key groups | `LOCALIZATION_PLAN.md` |
| Visual / VFX | Scan, glitch, warning, reveal, transitions | `VISUAL_AUDIO_DIRECTION.md` |
| Audio | Ambience, SFX, music states, blips | `VISUAL_AUDIO_DIRECTION.md` |
| Platform services | Revenue, ads, notifications, haptics | `PLATFORM_SERVICES_PLAN.md` |
| Backend | Supabase remote config, cloud save, events, leaderboard | `SUPABASE_BACKEND_PLAN.md` |

---

## Folder architecture

```text
Assets/
  _CyberClinic/
    Art/          Characters, Patients, Implants, Backgrounds, UI, VFX
    Audio/        SFX, Ambience, Music
    Prefabs/      Patients, Implants, UI, VFX
    Scenes/       Boot, MainClinic, SurgeryRoom
    Scripts/      Core, Patients, Implants, Procedures, Complications,
                  Economy, Events, UI, Visual, Audio, Localization,
                  Save, Progression, PlatformServices, Utilities
    ScriptableObjects/  Patients, Implants, Procedures, Complications,
                  Events, Dialogue, Economy, Visual, Audio
    Localization/ StringTables, AssetTables
    Settings/
  Docs/           All design memory + roadmap
```

Full rules: `README_ARCHITECTURE.md`

---

## Design memory index

| Document | Purpose |
|----------|---------|
| `GAME_DESIGN_MEMORY.md` | Creative pillar, core puzzle, replayability |
| `PROCEDURAL_PATIENT_SYSTEM.md` | Patient generation formula & data |
| `OPERATION_MATH.md` | Success chance, bands, calculator purity |
| `VISUAL_AUDIO_DIRECTION.md` | Style, VFX/audio modules, feedback table |
| `LOCALIZATION_PLAN.md` | Locales, keys, smart strings |
| `PLATFORM_SERVICES_PLAN.md` | Platform interfaces, mocks, CodeMagic |
| `SUPABASE_BACKEND_PLAN.md` | Supabase backend strategy and offline-first rules |
| `TUTORIAL_DESIGN.md` | First-time tutorial design |
| `COSMETIC_SYSTEM.md` | Cosmetic and visual upgrade economy |
| `CLINIC_VISUAL_PROGRESSION.md` | Clinic tier visual evolution |
| `README_ARCHITECTURE.md` | Code layout & decoupling |
| `DEVELOPMENT_RULES.md` | Mandatory coding rules |
| `DECISIONS.md` | ADRs |
| `CHANGELOG.md` | Version history |

---

## Milestone plan

### Milestone 0 — Project Foundation `Done`

- Unity project creation
- GitHub repo
- Folder structure
- Initial docs

---

### Milestone 0.5 — Design Memory Foundation `In progress`

- Permanent design memory docs
- Full roadmap
- Game design memory
- Procedural patient docs
- Operation math docs
- Visual/audio docs
- Localization plan
- Platform services plan
- Supabase backend plan
- Tutorial design
- Cosmetic system design
- Clinic visual progression docs

**Exit:** all docs reviewed; no gameplay C#; team aligned on puzzle, tutorial, visual progression, math, backend boundaries, and localization.

---

### Milestone 1 — Architecture and Data Foundation `Planned`

- ScriptableObject data models
- Runtime models
- Module assembly boundaries
- Domain interfaces
- No UI implementation yet

---

### Milestone 1.5 — First-Time Tutorial Design `Planned`

- Tutorial case finalized
- Tutorial UI highlight rules
- Tutorial localization keys
- Replay/skip policy
- VFX/SFX needs

---

### Milestone 1.6 — Cosmetic, Clinic Progression and Interchangeable Visual Design `Planned`

- Clinic theme data model
- Cosmetic data model
- Visual pack data model
- Clinic tier visual definitions
- RevenueCat entitlement boundaries
- Pay-to-win risk limits

---

### Milestone 2 — Localization Foundation `Planned`

- Unity Localization package
- English base locale
- Turkish secondary locale
- Key naming rules
- No-hardcoded-text checks

---

### Milestone 3 — Procedural Patient Generator `Planned`

- Deterministic seed support
- Archetypes, motivations, hidden conditions
- Visual traits, known/unknown model
- Scan reveal rules

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

## Current status

| Area | State |
|------|-------|
| Unity project | Created, Universal 2D |
| Repo & folders | Done |
| Design memory | Expanded |
| Gameplay C# | Not started intentionally |
| Unity packages | Not installed yet |
| Orientation | Landscape decided |
| Supabase | Planned, not created in repo |
| AdMob | Pending approval |
| Next practical step | Review docs, then plan M1 data architecture |

---

## Immediate next steps

1. User pulls latest documentation changes.
2. Review all docs for alignment.
3. Decide whether Milestone 0.5 is complete.
4. Prepare Cursor prompt for Milestone 1 data architecture only.
5. Still no gameplay UI/scene work until M1 is scoped.

---

## Version history

| Version | Date | Milestone | Notes |
|---------|------|-----------|-------|
| 0.0.0 | 2026-05-23 | M0 | Folder architecture + initial docs |
| 0.0.1 | 2026-05-23 | M0.5 | Full design memory + living roadmap |
| 0.0.2 | 2026-05-23 | M0.5 | Added landscape, tutorial, cosmetics, clinic visual progression, Supabase strategy, and ChatGPT docs ownership |

---

## Milestone log

| Date | Milestone | Notes |
|------|-----------|-------|
| 2026-05-23 | M0 — Project Foundation | Initial structure |
| 2026-05-23 | M0.5 — Design Memory Foundation | Expanded project memory |
