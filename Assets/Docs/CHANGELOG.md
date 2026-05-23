# Changelog

All notable changes to the Cyber Clinic project are documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/), and this project adheres to semantic versioning for releases when versioning begins.

---

## [Unreleased]

### Added

- Initial production-minded folder architecture under `Assets/_CyberClinic/` (Art, Audio, Prefabs, Scenes, Scripts, ScriptableObjects, Localization, Settings).
- Project documentation under `Assets/Docs/`:
  - `README_ARCHITECTURE.md` — modular layout, decoupling rules, data-driven workflow.
  - `DEVELOPMENT_RULES.md` — localization, ScriptableObjects, modularity, Git, platform abstraction.
  - `DECISIONS.md` — foundational technology and design decisions.
  - `ROADMAP.md` — living product roadmap placeholder.
  - `CHANGELOG.md` — this file.
- Architecture rules: no hardcoded player-facing text; Unity Localization for all visible copy; ScriptableObject-driven content; decoupled modules for patients, implants, procedures, complications, events, dialogue, visual/audio feedback, economy, save, progression, and platform services.

### Changed

- _(none yet)_

### Fixed

- _(none yet)_

---

## [0.0.0] — 2026-05-23

### Added

- **Project foundation** — Unity 6.3 LTS Universal 2D project structure and Cyber Clinic module layout established (folders and docs only; no gameplay scripts, packages, or project setting changes in this milestone).
