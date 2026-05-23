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

## Pending decisions

_Items to resolve as milestones land on `ROADMAP.md`:_

- Unity Localization package install and default locale setup
- Addressables vs Resources for content delivery
- Save format (JSON, binary, cloud sync)
- Analytics and attribution SDK choice
- Exact ad and IAP SDK versions (behind platform interfaces)
