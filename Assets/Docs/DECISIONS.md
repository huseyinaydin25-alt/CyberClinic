# Architecture & Product Decisions

Record of significant decisions for **Cyber Clinic**. Add a new entry when a choice is hard to reverse or affects multiple modules.

Format for new entries:

```markdown
## ADR-NNN: Title (YYYY-MM-DD)

**Status:** Accepted | Superseded | Deprecated

**Context:** …

**Decision:** …

**Consequences:** …
```

---

## Initial decisions (project foundation)

### 1. Unity 6.3 LTS

**Status:** Accepted (2026-05-23)

**Decision:** The project targets **Unity 6.3 LTS** for editor, runtime, and build pipeline stability.

**Consequences:** Features and packages must be compatible with 6.3 LTS; upgrade path documented before editor bump.

---

### 2. Universal 2D template

**Status:** Accepted (2026-05-23)

**Decision:** Use the **Universal Render Pipeline (URP) 2D** template as the rendering baseline.

**Consequences:** Art and shaders assume 2D URP; 3D-only workflows are out of scope unless explicitly decided later.

---

### 3. Android first for local testing

**Status:** Accepted (2026-05-23)

**Decision:** **Android** is the primary platform for day-to-day device testing and iteration.

**Consequences:** Android SDK setup, keystore, and permissions are prioritized in platform milestones; iOS follows with parity requirements from the start (see #5).

---

### 4. iOS builds via CodeMagic (later)

**Status:** Accepted (2026-05-23)

**Decision:** **iOS** CI/build distribution will use **CodeMagic** when the iOS pipeline milestone is reached—not ad-hoc local-only releases for production.

**Consequences:** Signing, provisioning, and build scripts should be CodeMagic-friendly; document secrets handling outside the repo.

---

### 5. Dual-platform from the beginning

**Status:** Accepted (2026-05-23)

**Decision:** Architecture and platform abstractions must support **Android and iOS from day one**, even when Android is tested first.

**Consequences:** No Android-only APIs in gameplay; platform code behind interfaces in `Scripts/PlatformServices/`; test with Editor fakes until both adapters exist.

---

### 6. Localization keys for all player-facing text

**Status:** Accepted (2026-05-23)

**Decision:** **All player-facing text** uses **localization keys** via the **Unity Localization** package. No hardcoded display strings in code, prefabs, or content SO fields.

**Consequences:** String Tables under `Assets/_CyberClinic/Localization/StringTables/` are mandatory for shipping UI and dialogue; keys are stable API for writers and translators.

---

### 7. Data-driven ScriptableObject content

**Status:** Accepted (2026-05-23)

**Decision:** Game content (patients, implants, procedures, complications, events, dialogue references, economy tuning, visual/audio feedback mappings) is **data-driven** and defined with **ScriptableObjects**, separate from runtime instances.

**Consequences:** Designers own balance in `ScriptableObjects/`; programmers implement systems that consume definitions; runtime state must not mutate SO assets.

---

## Design memory & process decisions

### 8. Design memory before coding

**Status:** Accepted (2026-05-23)

**Context:** Implementation is led by Cursor/ChatGPT; the user does not write code. Without permanent specs, agents drift from the core puzzle and coupling rules.

**Decision:** Create and maintain **design memory** under `Assets/Docs/` (`GAME_DESIGN_MEMORY.md`, `PROCEDURAL_PATIENT_SYSTEM.md`, `OPERATION_MATH.md`, etc.) **before** gameplay C#. Code must follow docs; docs update when plans change.

**Consequences:** Milestone 0.5 completes before Milestone 1 scripts; PRs reject behavior not reflected in docs.

---

### 9. Living roadmap as project memory

**Status:** Accepted (2026-05-23)

**Decision:** `ROADMAP.md` is the authoritative milestone and status tracker—updated after every major milestone, not a one-time placeholder.

**Consequences:** `CHANGELOG.md` and milestone log stay in sync; “current milestone” always visible at top of roadmap.

---

### 10. Visual and audio as core gameplay feedback

**Status:** Accepted (2026-05-23)

**Decision:** Visual effects, UI motion, SFX, ambience, and music are **core systems**, not late polish. Every major player action has paired visual + audio feedback per `VISUAL_AUDIO_DIRECTION.md`.

**Consequences:** Milestones 7–8 are required before vertical slice; event-driven `Visual/` and `Audio/` modules.

---

### 11. Deterministic seed-based procedural generation

**Status:** Accepted (2026-05-23)

**Decision:** Patient generation and operation variance use **deterministic seeds** (`runSeed`, day index, slot, operation hash) so results replay identically on Android, iOS, and Editor.

**Consequences:** No unscoped global random in domain logic; debug/replay can reproduce cases from seed.

---

### 12. Platform SDKs behind service interfaces

**Status:** Accepted (2026-05-23)

**Decision:** RevenueCat, AdMob (when approved), notifications, and haptics are accessed only through `PlatformServices` interfaces with **mock implementations** until real adapters ship.

**Consequences:** AdMob pending does not block milestones; gameplay never references SDK types.

---

### 13. CodeMagic for iOS builds

**Status:** Accepted (2026-05-23)

**Decision:** Production **iOS** builds use **CodeMagic** CI/CD connected to GitHub, with App Store Connect API and TestFlight distribution (Milestone 12).

**Consequences:** Build scripts and signing secrets live in CI, not in repo; Apple Developer account already exists.

---

## Pending decisions

_Items to resolve as milestones land on `ROADMAP.md`:_

- Unity Localization package install and default locale setup
- Addressables vs Resources for content delivery
- Save format (JSON, binary, cloud sync)
- Analytics and attribution SDK choice
- Exact ad and IAP SDK versions (behind platform interfaces)
