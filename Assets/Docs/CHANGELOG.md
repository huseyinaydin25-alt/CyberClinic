# Changelog

All notable changes to the Cyber Clinic project are documented in this file.

---

## [Unreleased]

### Added

- **Milestone 1 — Architecture and Data Foundation (in progress):**
  - Core utilities: `CyberClinicConstants`, `CyberClinicIds`, `IIdentifiable`, `IWeightedDefinition`, `WeightedEntry<T>`, `RangeFloat`, `RangeInt`, `Percentage01`, `SeedContext`, `CyberClinicRandom`.
  - Localization contracts: `LocalizationKey`, `LocalizedTextRef` (keys only, no display text).
  - Patient SO definitions and runtime models (`GeneratedPatient`, known/hidden info, risk/budget/urgency profiles, enums).
  - Implant, Procedure, Complication, Economy, Event SO definitions and operation DTOs (no `OperationCalculator` yet).
  - Visual and Audio SO feedback mapping definitions.
  - Tutorial, Cosmetics, Progression SO definitions and runtime state models.
  - Backend interfaces (`IBackendService`, remote config, cloud save, leaderboard, live events, telemetry) + DTOs.
  - Platform service interfaces (`IRevenueService`, `IAdService`, `INotificationService`, `IHapticService`, `IPlatformService`).
  - Save models (`SaveGameSnapshot`, `SaveVersion`) and `ISaveService`.

### Changed

- `ROADMAP.md` — current milestone set to **M1 started** (not complete).

### Fixed

- _(none yet)_

---

## [0.0.2] — 2026-05-23

### Added

- `TUTORIAL_DESIGN.md` — first-time tutorial and onboarding design memory.
- `COSMETIC_SYSTEM.md` — cosmetic and visual upgrade system design memory.
- `CLINIC_VISUAL_PROGRESSION.md` — clinic tier and interchangeable visual progression design memory.
- `SUPABASE_BACKEND_PLAN.md` — Supabase backend strategy and offline-first rules.

### Changed

- Expanded `ROADMAP.md` to doc version 0.0.2.
- Added landscape mobile gameplay as a project identity rule.
- Added ChatGPT ownership of `Assets/Docs` project memory.
- Added Milestone 1.5 — First-Time Tutorial Design.
- Added Milestone 1.6 — Cosmetic, Clinic Progression and Interchangeable Visual Design.
- Added Milestone 10.6 — Supabase Backend Foundation.
- Clarified that Supabase is an online service layer, not a core gameplay dependency.

---

## [0.0.1] — 2026-05-23

### Added

- **Design Memory Foundation** (Milestone 0.5):
  - `GAME_DESIGN_MEMORY.md` — high concept, core puzzle, decisions, replayability pillars.
  - `PROCEDURAL_PATIENT_SYSTEM.md` — generation formula, archetypes, known/unknown, seeds, SO notes.
  - `OPERATION_MATH.md` — success chance formula, risk bands, breakdown, calculator purity rules.
  - `VISUAL_AUDIO_DIRECTION.md` — cyberpunk medical noir style, VFX/audio modules, feedback table.
  - `LOCALIZATION_PLAN.md` — en/tr locales, string table groups, key convention, Cursor rules.
  - `PLATFORM_SERVICES_PLAN.md` — interfaces, mocks, AdMob pending, CodeMagic iOS plan.
- Full living `ROADMAP.md` — milestones 0 through 12, platform strategy, design rules, current status.
- Expanded `README_ARCHITECTURE.md` — design memory index, mandatory Cursor read order.
- Expanded `DEVELOPMENT_RULES.md` — design-memory-first rule, deterministic sim, doc update protocol.
- New `DECISIONS.md` entries #8–13.

### Changed

- `ROADMAP.md` replaced placeholder phases with full milestone plan and version history.
- `README_ARCHITECTURE.md` now references all design memory documents.

---

## [0.0.0] — 2026-05-23

### Added

- **Project foundation** — Unity 6.3 LTS Universal 2D project structure and Cyber Clinic module layout established.
