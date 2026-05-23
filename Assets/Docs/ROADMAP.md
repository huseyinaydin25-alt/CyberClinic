# Cyber Clinic — Living Roadmap

> **This file is the main living roadmap and project memory.**  
> Update after **every major milestone**. Sync with `CHANGELOG.md`, `DECISIONS.md`, and relevant design memory docs.

**Last updated:** 2026-05-23  
**Current milestone:** **0.5 — Design Memory Foundation** (in progress → complete when docs merged)  
**Doc version:** 0.0.1

---

## Project identity

| Field | Value |
|-------|-------|
| **Game** | Cyber Clinic |
| **Engine** | Unity 6.3 LTS |
| **Template** | Universal 2D (URP) |
| **Genre** | 2D cyberpunk medical management puzzle |
| **First test platform** | Android |
| **Commercial platforms** | Android + iOS |
| **iOS CI/CD** | CodeMagic → TestFlight |
| **Implementation** | User does not write code; **Cursor + ChatGPT** guide all implementation |

---

## Project philosophy

1. **Design memory before code** — Permanent docs in `Assets/Docs/` define behavior; code follows.
2. **Incomplete-information puzzle** — Players solve risk/economy/reputation tradeoffs, not “pick best implant.”
3. **Feel is gameplay** — Visual, animation, UI motion, SFX, and ambience teach consequences.
4. **Data-driven** — ScriptableObjects for content; runtime instances for state.
5. **Decoupled modules** — Patients, implants, procedures, math, economy, events, UI, feedback, save, platform—separate.
6. **Deterministic core** — Procedural generation and operation math are seed-stable.
7. **Shippable i18n** — No hardcoded player-facing text, ever on `main`.

---

## Development workflow

| Tool | Role |
|------|------|
| **Unity 6.3 LTS** | Editor, builds, assets |
| **Cursor** | Primary implementation agent |
| **ChatGPT** | Design review, planning, spec refinement |
| **GitHub Desktop + GitHub** | Version control, PRs |
| **CodeMagic** | iOS builds (Milestone 12) |

**Process:** Milestone goal → read design docs → implement in Cursor → test on Android → commit → update this file + `CHANGELOG.md`.

---

## Platform strategy

- **Android first** for daily device testing and iteration.
- **iOS parity** in architecture from day one (interfaces, no Android-only gameplay APIs).
- **CodeMagic** for iOS signing and TestFlight when vertical slice is stable.
- **Accounts ready:** Apple Developer, Google Play Console, RevenueCat; **AdMob pending**—mocks until approved.

See `PLATFORM_SERVICES_PLAN.md`.

---

## Existing accounts & services

| Service | Status |
|---------|--------|
| Apple Developer | Active |
| Google Play Console | Active |
| RevenueCat / RevenueKit | Active |
| AdMob | Pending approval — use `MockAdService` |
| GitHub repo | Active |
| CodeMagic | Planned (M12) |

---

## Core design rules

| Rule | Doc |
|------|-----|
| No hardcoded player-facing text | `LOCALIZATION_PLAN.md`, `DEVELOPMENT_RULES.md` |
| Localization keys only | `LOCALIZATION_PLAN.md` |
| ScriptableObject content | `README_ARCHITECTURE.md`, `DEVELOPMENT_RULES.md` |
| Modular systems | `README_ARCHITECTURE.md` |
| Deterministic procedural generation | `PROCEDURAL_PATIENT_SYSTEM.md`, `DECISIONS.md` |
| Visual/audio as core feedback | `VISUAL_AUDIO_DIRECTION.md` |
| Git discipline — commit per milestone | `DEVELOPMENT_RULES.md` |
| Design memory before coding | `GAME_DESIGN_MEMORY.md`, `DEVELOPMENT_RULES.md` |
| Platform SDKs behind interfaces | `PLATFORM_SERVICES_PLAN.md` |
| OperationCalculator is pure | `OPERATION_MATH.md` |

---

## Core game loop

```
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

**Core question (every patient):**  
*Given request, budget, tolerance, hidden conditions, clinic capabilities, and legal risk—what plan balances profit, safety, and reputation?*

Detail: `GAME_DESIGN_MEMORY.md`

---

## System concepts (summary)

| System | Summary | Design doc |
|--------|---------|------------|
| **Procedural patient** | Archetype + motivation + problems + hidden traits; seed-stable | `PROCEDURAL_PATIENT_SYSTEM.md` |
| **Implants** | Slots, tiers (cheap/quality/illegal), compatibility, legality | M4; `GAME_DESIGN_MEMORY.md` |
| **Procedures** | Difficulty, body stress, links to requests | M4–5 |
| **Operation math** | Deterministic success chance + risk bands + breakdown | `OPERATION_MATH.md` |
| **Economy & reputation** | Money, day flow, clinic brand | M9 |
| **Complications** | Post-op secondary rolls | M5+ |
| **Clinic events** | Blackouts, raids, supply shocks | M9+ |
| **Localization** | en base, tr secondary; key groups | `LOCALIZATION_PLAN.md` |
| **Visual / VFX** | Scan, glitch, warning, reveal, transitions | `VISUAL_AUDIO_DIRECTION.md` |
| **Audio** | Ambience, SFX, music states, blips | `VISUAL_AUDIO_DIRECTION.md` |
| **Platform services** | Revenue, ads, notifications, haptics | `PLATFORM_SERVICES_PLAN.md` |

---

## Folder architecture

```
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
  Docs/           All design memory + this roadmap
```

Full module rules: `README_ARCHITECTURE.md`

---

## Design memory index

| Document | Purpose |
|----------|---------|
| `GAME_DESIGN_MEMORY.md` | Creative pillar, core puzzle, replayability |
| `PROCEDURAL_PATIENT_SYSTEM.md` | Patient generation formula & data |
| `OPERATION_MATH.md` | Success chance, bands, calculator purity |
| `VISUAL_AUDIO_DIRECTION.md` | Style, VFX/audio modules, feedback table |
| `LOCALIZATION_PLAN.md` | Locales, keys, smart strings |
| `PLATFORM_SERVICES_PLAN.md` | Interfaces, mocks, CodeMagic |
| `README_ARCHITECTURE.md` | Code layout & decoupling |
| `DEVELOPMENT_RULES.md` | Mandatory coding rules |
| `DECISIONS.md` | ADRs |
| `CHANGELOG.md` | Version history |

---

## Documentation update protocol

1. **Before implementing a system** — Read the relevant doc(s); do not invent behavior in code alone.
2. **If behavior changes** — Update the design doc first (or in the same PR), then code.
3. **After milestone** — Update this roadmap status, `CHANGELOG.md`, and `DECISIONS.md` if architectural.
4. **Cursor sessions** — Treat `Assets/Docs/` as mandatory context.

---

## Milestone plan

### Milestone 0 — Project Foundation `Done`

| Deliverable | Status |
|-------------|--------|
| Unity project creation | Done |
| GitHub repo | Done |
| Folder structure `Assets/_CyberClinic` | Done |
| Initial docs (`README_ARCHITECTURE`, `DEVELOPMENT_RULES`, `DECISIONS`, `CHANGELOG`) | Done |

---

### Milestone 0.5 — Design Memory Foundation `In progress`

| Deliverable | Status |
|-------------|--------|
| Permanent design memory docs | Done |
| `GAME_DESIGN_MEMORY.md` | Done |
| `PROCEDURAL_PATIENT_SYSTEM.md` | Done |
| `OPERATION_MATH.md` | Done |
| `VISUAL_AUDIO_DIRECTION.md` | Done |
| `LOCALIZATION_PLAN.md` | Done |
| `PLATFORM_SERVICES_PLAN.md` | Done |
| Full living `ROADMAP.md` | Done |
| Expanded architecture & dev rules | Done |

**Exit:** All docs reviewed; no gameplay C#; team aligned on puzzle + math + feedback.

---

### Milestone 1 — Architecture and Data Foundation `Planned`

- ScriptableObject data models (definitions)
- Runtime models (instances)
- Module assembly boundaries
- **No UI code**

---

### Milestone 2 — Localization Foundation `Planned`

- Unity Localization package
- English base locale
- Turkish secondary locale
- Key naming rules enforced
- No-hardcoded-text checks / PR checklist

---

### Milestone 3 — Procedural Patient Generator `Planned`

- Deterministic seed support
- Archetypes, motivations, hidden conditions
- Visual traits, known/unknown info model
- Scan reveal rules (logic only; UI later)

---

### Milestone 4 — Implant and Procedure System `Planned`

- Implant compatibility matrix
- Body slots
- Procedure difficulty
- Legal status tiers
- Quality tiers (cheap / quality / illegal)

---

### Milestone 5 — Operation Calculation System `Planned`

- Deterministic `OperationCalculator`
- Risk breakdown DTO
- Success chance + risk bands
- CyberTox / neural load / hidden penalty / panic / illegal risk
- **No** money/reputation/save side effects

---

### Milestone 6 — First UI Skeleton `Planned`

- Patient file UI
- Implant selection UI
- Risk preview UI
- Result panel UI
- **All localized** (en + tr)

---

### Milestone 7 — Visual Feedback Foundation `Planned`

- Scan effect
- Glitch effect
- Warning pulse
- Result reveal
- UI transitions
- Event-driven `VisualFeedbackManager` stack

---

### Milestone 8 — Audio Feedback Foundation `Planned`

- AudioManager
- SFX library
- Ambience (rain/clinic)
- Scan / warning / success / failure sounds
- Music state hooks

---

### Milestone 9 — Economy, Reputation and Day Flow `Planned`

- Money
- Reputation
- Day manager
- Clinic state
- Day end report (localized)

---

### Milestone 10 — Save System Foundation `Planned`

- Versioned save format
- Save / load
- Platform-independent persistence

---

### Milestone 10.5 — Platform Services Abstraction `Planned`

- `IRevenueService` + RevenueCat adapter stub
- `IAdService` + AdMob adapter stub + **mocks**
- `INotificationService`, `IHapticService`
- Boot registration; **no SDK calls outside module**

---

### Milestone 11 — Visual Patient Puzzle Slice `Planned`

First playable vertical slice:

- One procedural patient (seeded)
- Three implant choices
- Scan screen
- Operation result
- Money / reputation change
- Glitch / scan / warning / success / fail feedback

**Target:** Prove core puzzle + feel on Android device.

---

### Milestone 12 — CodeMagic iOS Build Pipeline `Planned`

- CodeMagic project setup
- GitHub connection
- App Store Connect API
- Signing / provisioning
- TestFlight build

---

## Current status

| Area | State |
|------|-------|
| Unity project | Created (URP 2D) |
| Repo & folders | Done (M0) |
| Design memory | Done (M0.5) |
| Gameplay C# | **Not started** (intentional) |
| Unity packages | **Not installed** (Localization at M2) |
| AdMob | Pending — mocks per platform plan |
| Next milestone | **M1 — Architecture and Data Foundation** |

---

## Immediate next steps

1. Mark Milestone 0.5 complete in git after doc review.
2. Begin **Milestone 1** planning: list SO schemas from procedural + operation docs.
3. Do **not** add gameplay scripts until M1 scope is agreed in Cursor session.
4. Prepare Unity Localization install checklist for M2 (no install until milestone starts).

---

## Version history

| Version | Date | Milestone | Notes |
|---------|------|-----------|-------|
| 0.0.0 | 2026-05-23 | M0 | Folder architecture + initial docs |
| 0.0.1 | 2026-05-23 | M0.5 | Full design memory + living roadmap |

See `CHANGELOG.md` for detailed change lists.

---

## Milestone log

| Date | Milestone | Changelog |
|------|-----------|-----------|
| 2026-05-23 | M0 — Project Foundation | [0.0.0] |
| 2026-05-23 | M0.5 — Design Memory Foundation | [0.0.1] |
