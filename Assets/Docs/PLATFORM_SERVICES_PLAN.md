# Platform Services Plan — Design Memory

Strategy for **Android + iOS** platform capabilities without coupling gameplay to SDKs. Implementation lives in `Scripts/PlatformServices/` with mock adapters until production SDKs connect.

**Related:** `DEVELOPMENT_RULES.md`, `ROADMAP.md` (Milestone 10.5, 12)

---

## Platform strategy

| Aspect | Decision |
|--------|----------|
| **First test platform** | Android (local device + emulator) |
| **Commercial targets** | Android + iOS from architecture day one |
| **iOS builds** | **CodeMagic** CI/CD → TestFlight (Milestone 12) |
| **Workflow** | Unity + Cursor + GitHub Desktop + GitHub + ChatGPT |

Gameplay code assumes **platform-agnostic** behavior; adapters swap per build target.

---

## Existing accounts & services

| Service | Status | Notes |
|---------|--------|-------|
| **Apple Developer** | Exists | Signing for iOS / TestFlight |
| **Google Play Console** | Exists | Android distribution |
| **RevenueCat / RevenueKit** | Exists | IAP/subscription abstraction target |
| **AdMob** | **Pending approval** | Do not block development—use mock ads |
| **CodeMagic** | Planned M12 | GitHub-connected pipeline |

Secrets (API keys, keystore passwords) **never** in repo—CodeMagic / GitHub Secrets.

---

## Core rule

**Do not call SDKs from gameplay systems.**

Forbidden direct calls from `Patients/`, `Procedures/`, `Economy/`, `UI/`, etc.:

- `GoogleMobileAds.*`
- RevenueCat SDK entry points
- `AndroidJavaObject` notification APIs
- iOS `UIImpactFeedbackGenerator` / hand-tuned haptics
- Store review, ATT, billing intents

All access via **interfaces** registered at boot.

---

## Interface contracts (canonical)

Planned in `Scripts/PlatformServices/`:

### `IRevenueService`

- Initialize, fetch offerings, purchase, restore, subscription status
- Events: purchase success/fail, entitlement changed
- Implementation: RevenueCat adapter (M10.5+)

### `IAdService`

- Initialize, load interstitial/rewarded, show, consent state
- Implementation: AdMob adapter when approved; **MockAdService** until then

### `INotificationService`

- Schedule local notification, cancel, permission request
- Per-platform adapters + Editor no-op

### `IHapticService`

- Light/medium/heavy impact, success/warning/error patterns
- iOS Taptic + Android vibrator behind one API

### `IPlatformService` (facade optional)

- App version, store URL, platform enum, safe area hints
- Device tier for quality settings (future)

---

## Mock services until real SDKs connect

| Service | Mock behavior |
|---------|----------------|
| `MockRevenueService` | Log purchase, grant test entitlement in dev |
| `MockAdService` | Instant “ad finished” callback, UI placeholder |
| `MockNotificationService` | Log schedule only |
| `MockHapticService` | Log pattern; Editor silent |

Register mocks in **Boot** when `USE_MOCK_PLATFORM=true` or AdMob unavailable.

**Milestone 10.5 deliverable:** Interfaces + mocks + wiring hooks—no required store approval.

---

## Boot registration flow

```
Boot Scene
  → PlatformServiceInstaller
    → if Editor or MockFlag → register mocks
    → else Android → AndroidAdapters / RevenueCat / …
    → else iOS → iOSAdapters
  → Gameplay resolves IAdService via registry only
```

Feature flags in `ScriptableObjects` or build scripting define which adapter loads.

---

## Why interfaces prevent regressions

| Without interfaces | With interfaces |
|--------------------|-----------------|
| Ad call in UI button breaks iOS compile | UI calls `IAdService.ShowRewarded` |
| RevenueCat upgrade rewrites surgery code | Swap adapter in one folder |
| AdMob denial blocks milestone | Ship with mock; swap adapter later |
| Unit tests need devices | Inject mocks |

---

## RevenueCat / AdMob specifics

### RevenueCat

- Single `IRevenueService` implementation wrapping RevenueCat SDK
- Gameplay requests **entitlements** (e.g. `no_ads`, `premium_clinic`) not SKU strings
- SKU mapping in platform config SO

### AdMob (pending)

- **Do not** gate Milestones 6–11 on approval
- `MockAdService` satisfies rewarded flow for economy bonuses if designed
- When approved: `AdMobAdService` implements `IAdService`; enable via config flag
- COPPA/consent flows live in adapter, not scattered in UI

---

## Notifications & haptics

- **Notifications:** clinic idle reminders, daily reward—scheduled through `INotificationService`
- **Haptics:** sync to `WarningPulse`, operation result, implant install—via `IHapticService` from Visual/Audio event handlers **only** (not from calculator)

---

## CodeMagic iOS pipeline (Milestone 12)

| Step | Action |
|------|--------|
| 1 | Connect GitHub repo to CodeMagic |
| 2 | Unity 6.3 LTS build workflow (iOS) |
| 3 | App Store Connect API key in secrets |
| 4 | Automatic signing / provisioning profiles |
| 5 | Build → TestFlight upload |
| 6 | Artifact retention + version tagging |

Document build numbers in `CHANGELOG.md` per release.

---

## Module boundaries

| Module | May use platform APIs? |
|--------|------------------------|
| `PlatformServices/` | Yes (adapters only) |
| `UI/` | Interfaces only (show ad button → command) |
| `Economy/` | Listens to `IRevenueService` events |
| `Procedures/` | **No** |
| `Visual/` / `Audio/` | Haptics via `IHapticService` on events |

---

## Acceptance criteria (Milestone 10.5)

- [ ] `IRevenueService`, `IAdService`, `INotificationService`, `IHapticService`, `IPlatformService` defined
- [ ] Mock implementations for Editor/Android dev
- [ ] Boot installer selects implementation
- [ ] Zero SDK references outside `PlatformServices/`
- [ ] `DECISIONS.md` updated when AdMob approved

---

## Acceptance criteria (Milestone 12)

- [ ] CodeMagic builds iOS from `main`
- [ ] TestFlight install verified
- [ ] Signing documented outside repo
