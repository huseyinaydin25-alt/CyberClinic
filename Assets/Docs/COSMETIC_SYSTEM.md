# Cosmetic System — Design Memory

This document defines Cyber Clinic's cosmetic, visual upgrade, and long-term personalization strategy.

---

## Core idea

Cyber Clinic should not remain visually static. The player should feel that the clinic, interface, scan systems, operation space, and feedback language evolve as reputation and progression increase.

Cosmetics are not only decorative skins. They are part of the player’s long-term attachment to the clinic.

The purpose of this system is not simply to sell skins. It is to make the clinic feel owned, upgraded, personalized, and alive over long-term play.

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

A cosmetic that the player cannot notice during normal play has weak value. Cosmetic content should be designed around visibility, identity, and repeated exposure.

---

## Cosmetic design pillars

1. **Visible in the core loop**  
   Cosmetics should appear in screens the player sees repeatedly: clinic view, patient file, scan screen, operation screen, result reveal, day report.

2. **Interchangeable without rewrites**  
   Visual packs must be swappable by data/configuration, not by changing core UI code.

3. **Progression and ownership**  
   Some cosmetics are earned by reputation, clinic tier, achievements, or event participation. Premium purchases are additive, not the only path.

4. **No pay-to-win core math**  
   Cosmetic purchases must not directly break operation success chance, economy balance, or risk systems.

5. **Cyberpunk identity**  
   Cosmetic content should reinforce the world: medical noir, neon, glitch, rain, street clinics, corporate labs, luxury suites.

6. **Localization-first**  
   All cosmetic names, descriptions, unlock labels, rarity names, and store text must use localization keys.

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

## Player-facing cosmetic examples

### Clinic themes

Examples:

- Back-Alley Rain Clinic
- Neon Specialist Clinic
- Corporate Sterile Lab
- Elite Night Suite
- Rusted Underground Theatre
- Midnight Trauma Bay

Where visible:

- main clinic screen
- operation background
- patient intake card lighting
- day report backdrop

---

### UI themes

Examples:

- Broken Green CRT
- Neon Magenta Hologram
- Corporate Blue Medical UI
- Redline Interface
- Noir Amber Diagnostics

Where visible:

- patient file panel
- risk preview panel
- buttons
- scan overlays
- result panels

Rule:

UI themes may change frame, colors, animations, and sound pairing, but must preserve readability and layout.

---

### Scan visual packs

Examples:

- Basic Blue Scanline
- Neural Pulse Grid
- Redline Scanner
- Corporate Precision Sweep
- Stormwave Diagnostic Scan

Where visible:

- scan action
- hidden condition reveal
- body slot highlight
- risk reveal moment

Potential safe functional effect:

- clearer warning presentation
- different reveal animation
- optional accessibility/readability boost

Not allowed:

- paid scan visual directly reveals hidden conditions that free players cannot access

---

### Result animation packs

Examples:

- Clinical Green Stable Pulse
- Glitch Failure Collapse
- Neon Heartbeat Reveal
- Corporate Report Stamp
- Night Suite Seal

Where visible:

- operation outcome reveal
- day report summary
- patient response moment

---

### Operation table and equipment visuals

Examples:

- Scrap Table
- Refurbished Surgical Bench
- Neon Surgical Array
- Corporate Biobed
- Elite Implant Chair

Where visible:

- operation screen
- clinic upgrade screen
- tutorial preview hints

Functional relationship:

Equipment level may affect gameplay through progression systems, but the cosmetic skin itself should not be the direct source of major stats unless it is explicitly an earned progression upgrade, not a paid-only visual.

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

### Functional effect policy

Cosmetic functional effects should be classified as:

1. **Pure visual** — no gameplay effect.
2. **Feedback clarity** — communicates existing information more clearly.
3. **Quality-of-life** — convenience or readability, not outcome manipulation.
4. **Progression-linked** — earned upgrades that may signal actual clinic tier/equipment improvement.
5. **Premium visual only** — paid content with no critical gameplay advantage.

Premium cosmetics should primarily be categories 1, 2, and 5.

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

### Recommended distribution

| Source | Role |
|--------|------|
| Progression unlocks | Make clinic growth feel earned |
| Reputation unlocks | Reward careful play and prestige |
| Event rewards | Bring players back during seasons/special days |
| Premium IAP | Fund development with optional visual identity |
| Starter cosmetics | Teach personalization without monetization pressure |

---

## Data-driven model

Future data types already planned or created in M1:

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

### Ownership model

Cosmetic ownership should be save-safe and cloud-sync-ready later.

Potential ownership state:

- owned cosmetic ids
- selected clinic theme id
- selected UI theme id
- selected scan visual id
- selected result animation id
- selected ambience pack id
- last selected seasonal override
- source of ownership: progression, premium, event, achievement

This ownership should later be part of local save first and optional cloud save later.

---

## Visual pack composition

A `VisualPackData` can group multiple cosmetic elements into a coherent theme.

Example:

**Neon Specialist Pack**

- clinic theme
- UI theme
- scan visual
- result animation
- ambience layer
- optional patient card frame

Why packs matter:

- easier store presentation
- easier event rewards
- easier seasonal theme activation
- stronger visual identity

Packs should still be composed of separate data references so individual items can be mixed later if desired.

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

### Entitlement rules

- Entitlement keys are technical ids, not player-facing text.
- Entitlement ownership should be cached locally after verification.
- Restore purchases must not require changing cosmetic system logic.
- Premium visuals must remain optional.

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

### Event examples

- Neon New Year Clinic Theme
- Midnight Rain Scan Pack
- Corporate Audit UI Frame
- Emergency Weekend Redline Pack
- Rainstorm Ambience Pack
- National/Special Day clinic decoration pack

Event cosmetics may be:

- free temporary activation during the event
- earned permanent reward
- premium bundle
- login reward
- challenge reward

---

## Store and UX principles

The cosmetic store should eventually:

- preview cosmetics before purchase
- show exactly where a cosmetic appears
- avoid interrupting core gameplay
- never appear inside the first tutorial
- support restore purchases
- use localized names/descriptions
- separate premium, earned, and event items clearly

No store implementation should begin until platform service abstraction and RevenueCat planning are ready.

---

## Non-negotiable rules

1. Cosmetics must be visible or meaningfully felt.
2. Premium cosmetics must not break core balance.
3. Visual packs must not require core UI rewrites.
4. Cosmetic names/descriptions must be localized.
5. Ownership must be save-safe and cloud-sync-ready later.
6. Store SDKs must stay behind platform service interfaces.
7. Cosmetic systems must support future content additions without code rewrites.
8. The first tutorial must not sell cosmetics, but it may hint that the clinic can evolve.
9. Visual pack previews must show the player what changes.
10. Readability and accessibility must be preserved across UI themes.

---

## Milestone 1.6 acceptance criteria

Milestone 1.6 is complete when:

- cosmetic categories are documented
- clinic visual progression tiers are aligned with cosmetic system
- data-driven visual pack approach is documented
- premium/progression/event reward boundaries are documented
- functional cosmetic limits are documented
- ownership/save/cloud-sync implications are documented
- no store implementation, gameplay UI, SDK integration, or scene work is created
