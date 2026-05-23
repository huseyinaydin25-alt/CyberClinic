# Cyber Clinic — Development Rules

Binding rules for all contributors and automation. When in doubt, prefer **decoupling**, **data-driven content**, and **localization keys** over convenience shortcuts.

---

## 1. Localization — no hardcoded player-facing text

### Rule

**No hardcoded UI or player-facing text anywhere** in:

- C# scripts
- Prefabs (Text, TextMeshPro, UI Toolkit labels)
- ScriptableObject string fields meant for display
- Animation events, timeline captions, or debug overlays shown to players

### Required approach

- Use the **Unity Localization** package.
- Store copy in `Assets/_CyberClinic/Localization/StringTables/`.
- Reference entries by **localization keys** (stable IDs), not by English fallback in code.
- Localized assets (if any) use `Localization/AssetTables/`.

### Key naming

- Use a consistent hierarchy: e.g. `ui.clinic.title`, `dialogue.patient.greeting.01`, `error.save.failed`.
- Keys are **stable contracts**; changing English copy must not require renaming keys.
- Code and ScriptableObjects store **keys only** for display strings.

### Exceptions (non–player-facing)

- Editor-only logs and menu items
- Developer console in **Editor** builds only, clearly marked non-shipping
- `[SerializeField]` technical IDs, asset addresses, analytics event names (not shown to players)

If a string might ever appear on screen—even as “temporary” text—it must use a key from day one.

---

## 2. ScriptableObjects — content is data

### Rule

Game content is defined in **ScriptableObjects** under `Assets/_CyberClinic/ScriptableObjects/<Domain>/`.

### Required approach

- Patients, implants, procedures, complications, events, dialogue, economy tuning, visual feedback maps, and audio feedback maps are **SO-backed**.
- Designers tune gameplay without recompiling.
- Version SO assets in Git; review balance changes like code.

### Runtime vs definition

| Layer | What it is |
|-------|------------|
| **Definition** | ScriptableObject asset (shared, read-only at runtime) |
| **Instance** | Plain C# runtime object created from one or more definitions |

Never mutate SO assets at runtime. Clone or build instances when state must change (patient health, run modifiers, etc.).

---

## 3. Modularity — one domain per folder

### Rule

Each system lives in its module folder under `Scripts/` and owns its contracts.

| Module | Owns | Must not own |
|--------|------|----------------|
| `Patients/` | Procedural patient orchestration | UI layout, AdMob |
| `Implants/` | Implant rules | String tables |
| `Procedures/` | Procedure flow | Direct particle spawn |
| `Complications/` | Complication logic | Save file format |
| `Economy/` | Calculations | TextMeshPro bindings |
| `Events/` | Clinic events | Platform IAP UI |
| `UI/` | Presentation | Economy formulas |
| `Visual/` | VFX presentation | Damage/reward math |
| `Audio/` | SFX/music presentation | Procedure rules |
| `Localization/` | Key/table helpers | Gameplay state |
| `Save/` | Persistence | Business rules |
| `Progression/` | Meta unlocks | Ad SDK calls |
| `PlatformServices/` | Platform adapters | Surgery simulation |

### Cross-module communication

- Prefer **interfaces + events** over concrete type references across modules.
- `Core/` may define shared abstractions (e.g. `IGameEventBus`, `ISaveGateway`).
- Avoid static singletons that hide dependencies; explicit injection or service registry in boot is acceptable.

### Adding features

1. Identify the owning module.
2. Add SO definitions if content is involved.
3. Add localization keys before UI is wired.
4. Expose events or DTOs for other modules—do not reach into their internals.

---

## 4. UI separation

### Rule

**UI does not perform calculation logic.**

- UI displays models and sends **commands** (user intent).
- Domain modules validate commands and return **results** or **events**.
- Formatting of numbers for display may use UI helpers; **authoritative values** come from domain code.

### Localization in UI

- UI components bind to localized strings via keys or Unity Localization components—never assign `.text = "..."` with user-visible literals.

---

## 5. Visual and audio feedback separation

### Rule

**Visual and audio feedback do not perform gameplay calculations.**

- Gameplay emits **semantic events** (what happened).
- `Scripts/Visual/` and `Scripts/Audio/` map events to presentation using `ScriptableObjects/Visual` and `ScriptableObjects/Audio`.
- Changing a sound or particle must not change economy or procedure outcomes.

---

## 6. Platform services abstraction

### Rule

Gameplay and UI **must not** call platform SDKs directly:

- Google AdMob
- RevenueCat (or store IAP APIs)
- Push notifications
- Haptics / vibration APIs
- Store review prompts
- ATT / privacy flows (except via dedicated platform module)

### Required approach

1. Define interfaces in `Scripts/PlatformServices/` (e.g. `IAdsService`, `IPurchaseService`, `INotificationService`, `IHapticsService`).
2. Implement adapters per platform (Android, iOS) in the same module or platform-specific assemblies.
3. Register implementations during **Boot** scene initialization.
4. Gameplay depends only on interfaces.

### Testing

- Provide null/no-op or fake implementations for Editor and headless tests.
- Feature flags for ads/IAP live in platform or config SO—not scattered `#if` in procedure code.

---

## 7. Save system

- Save format and IO live in `Scripts/Save/`.
- Domain modules expose serializable snapshots; Save module orchestrates write/read/migration.
- No player-facing strings in save files—use keys if UI must show save errors.

---

## 8. Git workflow

### Commits

- **Commit after every meaningful milestone** (feature slice, doc update, content batch, refactor boundary).
- One logical change per commit when possible.
- Write clear messages: imperative mood, scope prefix optional (e.g. `docs:`, `content:`, `architecture:`).

### What to commit

- ScriptableObject assets, localization tables, prefabs, scenes under `_CyberClinic`
- Documentation in `Assets/Docs/`
- Do **not** commit secrets, keystore passwords, API keys, or `Library/`, `Temp/`, `Logs/`

### Branches and PRs

- Keep `main` releasable.
- Use short-lived branches for features; document breaking decisions in `DECISIONS.md`.

### Reviews

- Reject PRs that introduce hardcoded player-facing strings.
- Reject PRs that call platform SDKs from non-platform modules.
- Reject PRs that put gameplay math inside UI or feedback scripts.

---

## 9. Unity and packages (phase zero)

Until explicitly scheduled on the roadmap:

- Do not add gameplay scripts ahead of module design.
- Do not install packages without a `DECISIONS.md` entry and `CHANGELOG.md` note.
- Do not change project settings without documenting why in `DECISIONS.md`.

When Unity Localization is installed, all new UI work must use it immediately—no legacy string path.

---

## 10. Documentation discipline

| Event | Update |
|-------|--------|
| Major milestone shipped | `ROADMAP.md` (status), `CHANGELOG.md` (entry) |
| Architectural choice | `DECISIONS.md` |
| Folder or module boundary change | `README_ARCHITECTURE.md` |
| New mandatory rule | This file |

---

## Quick checklist (before merge)

- [ ] No player-facing string literals in code or prefabs
- [ ] New copy has localization keys in String Tables
- [ ] New content uses ScriptableObjects, not magic numbers in scenes
- [ ] UI has no economy/procedure/reputation math
- [ ] Visual/audio only react to events, no outcome changes
- [ ] Platform calls only in `PlatformServices` adapters
- [ ] `CHANGELOG.md` updated if user-visible or structural change
- [ ] Milestone reflected in `ROADMAP.md` if applicable
