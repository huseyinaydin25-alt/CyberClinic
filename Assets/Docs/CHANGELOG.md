# Changelog

All notable changes to the Cyber Clinic project are documented in this file.

---

## [Unreleased]

### Added

- **Milestone 5 — Operation Calculation System (completed):**
  - Pure deterministic `OperationCalculator`.
  - `OperationBreakdownEntry` DTO for localized breakdown terms.
  - `OperationResult` DTO for calculation output.
  - `OperationOutcomeType.PreviewOnly` for preview-mode calculations.
  - Calculation fields on `ProcedurePlan`: `BaseSuccess` and `ProcedureDifficulty`.
  - Editor menu: **Cyber Clinic/Procedures/Run Operation Calculator Debug** (technical log only).
  - `MILESTONE_5_COMPLETION.md` completion record.
- **Milestone 4 — Implant and Procedure System (completed):**
  - `ImplantCompatibilityRelation` enum.
  - Expanded `ImplantCompatibilityRuleData` for data-driven compatibility rules.
  - `ImplantVisualVariantData` for implant visual variant links.
  - `ProcedureImplantCompatibilityData` for procedure + implant compatibility metadata.
  - `ImplantLocalizationKeys` and `ProcedureLocalizationKeys` key convention helpers.
  - Minimal editor-only implant/procedure test assets under `Assets/_CyberClinic/Data/Implants/TestSeed/` and `Assets/_CyberClinic/Data/Procedures/TestSeed/`.
  - Editor menu: **Cyber Clinic/Implants/Validate Debug Data** (technical log only).
  - `MILESTONE_4_COMPLETION.md` completion record.
- **Milestone 3 — Procedural Patient Generator (completed):**
  - Deterministic `PatientGenerator` using `SeedContext` and `CyberClinicRandom`.
  - `PatientGenerationInput`, `PatientGenerationConfig`, `PatientGenerationResult`, `PatientGenerationError`.
  - `PatientGenerationValidator`, `PatientGenerationContextBuilder`, `PatientGenerationWeights`, `PatientIdFactory`.
  - Known vs hidden runtime population on `GeneratedPatient` (localization keys only).
  - Tutorial-safe generation constraints in config (no tutorial runtime flow).
  - Editor menu: **Cyber Clinic/Patients/Generate Debug Patient** (technical log only).
  - Minimal editor-only Patient*Data test assets under `Assets/_CyberClinic/Data/Patients/TestSeed/`.
  - `MILESTONE_3_COMPLETION.md` completion record.

### Changed

- `ROADMAP.md` — Milestone 5 marked **done** and Milestone 6 marked as the next practical step.

### Fixed

- _(none yet)_

### Verified

- M5 operation calculator debug validation was run successfully through **Cyber Clinic/Procedures/Run Operation Calculator Debug**.
- Validation confirmed:
  - `operationSeed=-1749383045`
  - `previewSuccessChance=0,675`
  - `previewRiskBand=Uncertain`
  - `previewOutcome=PreviewOnly`
  - `commitSuccessChance=0,690`
  - `commitRiskBand=Uncertain`
  - `commitOutcome=StableSuccess`
  - `commitRandomVariance=0,015`
  - `rawScore=0,690`
  - `breakdownCount=13`
- M4 debug validation was run successfully through **Cyber Clinic/Implants/Validate Debug Data**.
- M3 debug generation was run twice with seed `84921`, day `3`, slot `0`; both runs produced identical patient ids, numeric values, and Known/Hidden fields.
- No gameplay UI, scenes, prefabs, save system, backend implementation, platform SDK integration, economy/reputation/day-flow, VFX/audio feedback, or other out-of-scope systems were created.

---

## [0.2.6] — 2026-05-23

### Added

- **Milestone 1.6 — Cosmetic, Clinic Progression and Interchangeable Visual Design:**
  - Expanded cosmetic categories and examples.
  - Clinic tier visual language and landscape composition rules.
  - Data-driven visual pack and seasonal overlay strategy.
  - Premium/progression/event boundaries.
  - Functional cosmetic effect limits.
  - Cosmetic ownership and future save/cloud-sync implications.
  - Additional `Cosmetics.csv` and `Clinic.csv` localization seed keys.

### Changed

- `COSMETIC_SYSTEM.md` expanded with cosmetic design pillars, ownership model, visual pack composition, store UX principles, and RevenueCat entitlement rules.
- `CLINIC_VISUAL_PROGRESSION.md` expanded with tier-specific visual language, landscape layout constraints, progression unlock philosophy, and seasonal overlay rules.
- `ROADMAP.md` moved Milestone 1.6 to done and Milestone 3 to next.

### Verified

- Cosmetic and clinic localization keys were imported successfully through the localization setup.
- No gameplay UI, store implementation, SDK integration, backend implementation, patient generator, OperationCalculator, or scene work was created.

---

## [0.2.5] — 2026-05-23

### Added

- **Milestone 1.5 — First-Time Tutorial Design:**
  - Canonical first tutorial case: **Case 001 — The Runner at the Door**.
  - Beat-by-beat tutorial flow from clinic boot to first success.
  - Tutorial UI guidance, interaction locking, skip/replay, and visual/audio requirements.
  - Additional tutorial localization keys in `Tutorial.csv`.

### Changed

- `TUTORIAL_DESIGN.md` expanded with tutorial design pillars, first case details, beat map, and acceptance criteria.
- `ROADMAP.md` moved Milestone 1.5 to done and Milestone 1.6 to next.
- Localization setup was re-run after new tutorial keys; key count is now 96 across 11 tables.

### Verified

- Hardcoded text validator reported no suspicious player-facing strings.
- No gameplay implementation, scenes, prefabs, patient generator, OperationCalculator, SDK integration, or backend implementation was created.

---

## [0.2.0] — 2026-05-23

### Added

- **Milestone 2 — Localization Foundation:**
  - `com.unity.localization` and `com.unity.addressables` in `Packages/manifest.json`.
  - Localization folders: `Locales/`, `StringTables/`, `StringTables/Seed/`, `AssetTables/`.
  - Eleven CSV seed tables: UI, Tutorial, Patients, Implants, Procedures, Economy, Events, Cosmetics, Clinic, Errors, System.
  - English (`en`) and Turkish (`tr`) localization values.
  - Editor setup menu: **Cyber Clinic/Localization/Setup Foundation (M2)**.
  - Editor validator menu: **Cyber Clinic/Localization/Validate Hardcoded Text**.
  - `README_LOCALIZATION.md`, `CyberClinic.Localization.asmdef`, and `CyberClinic.Localization.Editor.asmdef`.

### Changed

- `ROADMAP.md` moved Milestone 2 to done and Milestone 1.5 to next.

### Fixed

- Updated `LocalizationFoundationSetup.cs` for Unity Localization 1.5.9 API compatibility.
- Replaced unsupported editor API calls with `ActiveLocalizationSettings` and shared-table key lookup.
- Setup is idempotent for locales, collections, and keys.

### Verified

- Unity setup ran successfully and imported/updated 85 keys across 11 tables.
- Hardcoded text validator reported no suspicious player-facing strings.
- No gameplay UI, scenes, prefabs, SDK integrations, backend implementations, patient generator, or OperationCalculator were created.

---

## [0.1.0] — 2026-05-23

### Added

- **Milestone 1 — Architecture and Data Foundation:**
  - Core utilities: `CyberClinicConstants`, `CyberClinicIds`, `IIdentifiable`, `IWeightedDefinition`, `WeightedEntry<T>`, `RangeFloat`, `RangeInt`, `Percentage01`, `SeedContext`, `CyberClinicRandom`.
  - Localization contracts: `LocalizationKey`, `LocalizedTextRef`.
  - Patient ScriptableObject definitions and runtime models.
  - Implant, procedure, complication, economy, and event data definitions.
  - Operation DTOs only; no `OperationCalculator` yet.
  - Visual and audio feedback data definitions.
  - Tutorial, cosmetics, and progression data contracts.
  - Backend interfaces and DTOs only.
  - Platform service interfaces only.
  - Save models and `ISaveService`.

### Changed

- `ROADMAP.md` moved Milestone 1 to done and Milestone 2 to next.

### Fixed

- Architecture review fixes for Unity serialization and deterministic replay safety:
  - `Percentage01`, `LocalizationKey`, and `SeedContext` are Unity-serializable.
  - `GeneratedPatient` no longer auto-generates non-deterministic ids.
  - `OperationInput` references selected implant/procedure by content id rather than direct ScriptableObject reference.
  - `INotificationService` uses localization keys for notification title/body.

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
