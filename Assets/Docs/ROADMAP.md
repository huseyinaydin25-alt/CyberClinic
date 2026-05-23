# Cyber Clinic — Roadmap

> **This file is the main living roadmap for the project.**  
> Update it after **every major milestone** (feature complete, release candidate, architecture shift, or sprint goal reached). Keep dates, status, and links to `CHANGELOG.md` / `DECISIONS.md` entries in sync.

---

## Status legend

| Status | Meaning |
|--------|---------|
| `Planned` | Not started |
| `In progress` | Active work |
| `Done` | Shipped or merged to main |
| `Blocked` | Waiting on dependency or decision |

---

## Phase 0 — Foundation

| Item | Status | Notes |
|------|--------|-------|
| Modular folder architecture (`Assets/_CyberClinic`) | Done | 2026-05-23 |
| Architecture & development documentation | Done | `README_ARCHITECTURE.md`, `DEVELOPMENT_RULES.md` |
| Initial decisions & changelog | Done | `DECISIONS.md`, `CHANGELOG.md` |
| Unity Localization package setup | Planned | Requires package install + String Tables |
| Boot scene & service registration skeleton | Planned | No gameplay logic yet |
| Platform service interfaces (no SDK wiring) | Planned | `Scripts/PlatformServices/` contracts only |

---

## Phase 1 — Core loop (placeholder)

_Detail milestones here as design locks. Do not duplicate full GDD—link external docs if needed._

| Item | Status | Notes |
|------|--------|-------|
| Patient procedural generation (data + module) | Planned | |
| Implant & procedure systems | Planned | |
| Complications & clinic events | Planned | |
| Economy & reputation | Planned | |
| Save & progression | Planned | |
| UI shell with localization | Planned | |
| Visual & audio feedback maps | Planned | |

---

## Phase 2 — Mobile production (placeholder)

| Item | Status | Notes |
|------|--------|-------|
| Android release pipeline | Planned | First test platform |
| iOS parity & CodeMagic pipeline | Planned | See `DECISIONS.md` #4 |
| Platform adapters (ads, IAP, notifications, haptics) | Planned | Behind interfaces only |
| Store assets & compliance | Planned | |

---

## Milestone log

| Date | Milestone | Changelog |
|------|-----------|-----------|
| 2026-05-23 | Project foundation — folder architecture & docs | `CHANGELOG.md` [0.0.0] |

---

## How to update this file

1. Move completed rows to `Done` and add the date in **Milestone log**.
2. Add a `CHANGELOG.md` entry under `[Unreleased]` or a version tag.
3. Record irreversible choices in `DECISIONS.md` (new ADR-style section).
4. If modules or folders change, update `README_ARCHITECTURE.md`.
