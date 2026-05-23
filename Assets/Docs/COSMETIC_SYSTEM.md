# Cosmetic System — Design Memory

This document defines Cyber Clinic's cosmetic, visual upgrade, and long-term personalization strategy.

---

## Core idea

Cyber Clinic should not remain visually static. The player should feel that the clinic, interface, scan systems, operation space, and feedback language evolve as reputation and progression increase.

Cosmetics are not only decorative skins. They are part of the player’s long-term attachment to the clinic.

---

## Design principle

> The player should see and feel what they unlock.

If the player earns or buys a visual upgrade, it should appear somewhere meaningful in the game loop:

- clinic environment
- operation table
- UI panels
- scan effect
- patient file cards
- risk overlay
- result animation
- ambient sound
- special event theme

---

## Cosmetic categories

Potential cosmetic and upgrade categories:

- clinic room themes
- clinic tier visual packs
- operation table skins
- holographic UI themes
- scan effect variants
- glitch effect packs
- risk panel skins
- patient file card themes
- implant preview visual variants
- clinic equipment visuals
- neon signage / background city elements
- result reveal animation packs
- UI sound packs
- ambience packs
- seasonal visual themes
- special event rewards

---

## Functional cosmetic boundaries

Some cosmetic upgrades may provide small functional or quality-of-life benefits, but Cyber Clinic must avoid pay-to-win perception.

Allowed or safer effects:

- improved readability
- clearer risk feedback
- alternate scan visualization
- stronger warning animation
- thematic patient/event compatibility
- prestige or identity expression
- non-critical convenience

Dangerous effects that require caution:

- direct large success chance bonus
- direct major money multiplier
- removing critical risks entirely
- locking core readability behind payment
- punishing non-paying players

---

## Progression vs purchase

Cosmetics can come from multiple sources:

- reputation unlocks
- clinic tier progression
- event rewards
- achievements
- IAP / RevenueCat purchases
- bundles
- seasonal events

The best long-term structure is mixed:

- some strong visuals earned through gameplay
- some premium visual packs sold through IAP
- some event-limited cosmetics for retention
- some starter upgrades to teach the system

---

## Data-driven model

Future data types:

- `CosmeticData`
- `VisualPackData`
- `ClinicThemeData`
- `ClinicTierVisualData`
- `ScanVisualData`
- `UIThemeData`
- `ResultAnimationData`
- `SeasonalThemeData`

Potential `CosmeticData` fields:

- `cosmeticId`
- `nameLocalizationKey`
- `descriptionLocalizationKey`
- `category`
- `rarity`
- `targetSystem`
- `visualThemeId`
- `unlockCondition`
- `purchaseType`
- `entitlementKey`
- `eventTag`
- `previewAssetRef`
- `functionalEffectType`
- `functionalEffectValue`

All display names and descriptions must use localization keys.

---

## RevenueCat relationship

RevenueCat may manage premium entitlement ownership later, but gameplay systems must not call RevenueCat directly.

Correct flow:

1. Player opens cosmetic store UI.
2. UI requests product/entitlement info through `IRevenueService`.
3. Purchase succeeds or entitlement is restored.
4. Progression/cosmetic ownership system receives entitlement result.
5. Cosmetic becomes available in the visual selection system.

Gameplay and visual systems query owned cosmetics through a local ownership/progression service, not directly through the store SDK.

---

## Special event cosmetics

Seasonal and holiday events can provide temporary or permanent cosmetics:

- event clinic background
- limited UI frame
- scan color/effect variant
- special patient card style
- ambient sound layer
- event reward badge

Event cosmetics must be data-driven and should be attachable to `SeasonalThemeData` or event definitions.

---

## Non-negotiable rules

1. Cosmetics must be visible or meaningfully felt.
2. Premium cosmetics must not break core balance.
3. Visual packs must not require core UI rewrites.
4. Cosmetic names/descriptions must be localized.
5. Ownership must be save-safe and cloud-sync-ready later.
6. Store SDKs must stay behind platform service interfaces.
7. Cosmetic systems must support future content additions without code rewrites.
