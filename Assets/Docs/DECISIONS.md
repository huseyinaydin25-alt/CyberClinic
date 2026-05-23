# Architecture & Product Decisions

Record of significant decisions for **Cyber Clinic**. Add a new entry when a choice is hard to reverse or affects multiple modules.

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

**Consequences:** Android SDK setup, keystore, and permissions are prioritized in platform milestones; iOS follows with parity requirements from the start.

---

### 4. iOS builds via CodeMagic later

**Status:** Accepted (2026-05-23)

**Decision:** iOS CI/build distribution will use **CodeMagic** when the iOS pipeline milestone is reached.

**Consequences:** Signing, provisioning, and build scripts should be CodeMagic-friendly; secrets stay outside the repo.

---

### 5. Dual-platform from the beginning

**Status:** Accepted (2026-05-23)

**Decision:** Architecture and platform abstractions must support **Android and iOS from day one**, even when Android is tested first.

**Consequences:** No Android-only APIs in gameplay; platform code behind interfaces in `Scripts/PlatformServices/`.

---

### 6. Localization keys for all player-facing text

**Status:** Accepted (2026-05-23)

**Decision:** **All player-facing text** uses localization keys via the Unity Localization package. No hardcoded display strings in code, prefabs, or content data.

**Consequences:** String Tables under `Assets/_CyberClinic/Localization/StringTables/` are mandatory for UI and dialogue.

---

### 7. Data-driven ScriptableObject content

**Status:** Accepted (2026-05-23)

**Decision:** Game content is data-driven and defined with ScriptableObjects, separate from runtime instances.

**Consequences:** Designers tune content in assets; runtime state must not mutate ScriptableObject definitions.

---

## Design memory and process decisions

### 8. Design memory before coding

**Status:** Accepted (2026-05-23)

**Decision:** Create and maintain design memory under `Assets/Docs/` before gameplay C#.

**Consequences:** Code must follow docs; docs update when plans change.

---

### 9. Living roadmap as project memory

**Status:** Accepted (2026-05-23)

**Decision:** `ROADMAP.md` is the authoritative milestone and status tracker.

**Consequences:** `CHANGELOG.md` and milestone log stay in sync.

---

### 10. Visual and audio as core gameplay feedback

**Status:** Accepted (2026-05-23)

**Decision:** Visual effects, UI motion, SFX, ambience, and music are core systems, not late polish.

**Consequences:** Milestones 7 and 8 are required before vertical slice.

---

### 11. Deterministic seed-based procedural generation

**Status:** Accepted (2026-05-23)

**Decision:** Patient generation and operation variance use deterministic seeds.

**Consequences:** Same inputs plus seed should reproduce the same case and result on Android, iOS, and Editor.

---

### 12. Platform SDKs behind service interfaces

**Status:** Accepted (2026-05-23)

**Decision:** RevenueCat, AdMob, notifications, and haptics are accessed only through PlatformServices interfaces with mock implementations until real adapters ship.

**Consequences:** AdMob pending does not block milestones; gameplay never references SDK types.

---

### 13. CodeMagic for iOS builds

**Status:** Accepted (2026-05-23)

**Decision:** Production iOS builds use CodeMagic CI/CD connected to GitHub.

**Consequences:** Build scripts and signing secrets live in CI, not in repo.

---

### 14. Landscape-first gameplay

**Status:** Accepted (2026-05-23)

**Decision:** Cyber Clinic targets landscape mobile gameplay, not portrait-first UI.

**Consequences:** Patient file, clinic view, scan panel, operation panel, and result screen must be composed for horizontal screens from the beginning.

---

### 15. ChatGPT owns project memory docs

**Status:** Accepted (2026-05-23)

**Decision:** `Assets/Docs/` project memory updates are ultimately controlled by ChatGPT. Cursor may draft or generate files, but docs are reviewed and finalized through ChatGPT.

**Consequences:** After user pushes implementation changes, ChatGPT checks GitHub and updates roadmap, changelog, decisions, and relevant design docs.

---

### 16. First tutorial is a core retention system

**Status:** Accepted (2026-05-23)

**Decision:** The first-time tutorial must be an enjoyable, atmospheric, controlled first case rather than a generic popup sequence.

**Consequences:** Tutorial design receives its own doc and milestone before complex UI/gameplay work.

---

### 17. Interchangeable visual and clinic progression system

**Status:** Accepted (2026-05-23)

**Decision:** Cyber Clinic must support long-term visual evolution through clinic tiers, themes, UI packs, scan styles, VFX variants, result animations, seasonal visuals, and premium cosmetics.

**Consequences:** Visual systems must be data-driven; the game should not rely on one static clinic or one static UI throughout its lifetime.

---

### 18. Supabase as online service layer, not core gameplay dependency

**Status:** Accepted (2026-05-23)

**Decision:** Supabase may be used for remote config, cloud save, live events, leaderboards, telemetry, and backend support, but the core gameplay loop remains offline-first.

**Consequences:** Gameplay systems do not call Supabase directly. Backend access goes through service interfaces and mockable adapters.

---

## Pending decisions

- Unity Localization package install and default locale setup
- Addressables vs Resources for content delivery
- Save format and cloud sync model
- Analytics and attribution SDK choice
- Exact ad and IAP SDK versions behind platform interfaces
- Supabase schema and RLS policies
- Tutorial skip/replay policy
- Clinic tier unlock rules
