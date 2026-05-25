# Clinic Visual Progression — Design Memory

This document defines how Cyber Clinic visually evolves over time.

---

## Core principle

Cyber Clinic must not use one static clinic background and one static UI forever.

As the player gains reputation, improves equipment, unlocks cosmetics, survives events, and progresses through the clinic economy, the game should become visually richer and more distinctive.

> The player should not only read that the clinic improved; they should see it.

---

## Progression fantasy

The player begins as a small, questionable back-alley operator and can grow into a powerful cyber-medical presence.

Visual progression should communicate:

- rising reputation
- improved equipment
- better scan capabilities
- access to richer clients
- darker high-risk opportunities
- personal identity through selected themes

---

## Landscape composition principle

Cyber Clinic is landscape-first. Each clinic tier should support a strong horizontal composition:

- left zone: patient/body/scan focus
- center zone: operation table or clinic action space
- right zone: patient file, risk, dialogue, or decision panels
- top zone: day, money, reputation, system status
- bottom zone: action buttons, warnings, contextual hints

Visual upgrades should not break this composition. Themes may change framing, lighting, panel style, and depth, but not the core readability of the landscape layout.

---

## Clinic tier examples

### Tier 0 — Back-Alley Clinic

Atmosphere:

- cramped
- dirty walls
- unstable lighting
- old monitor glow
- cheap operation table
- visible cables
- rain leaking outside
- heavy noir shadow

Gameplay feeling:

- risky
- underground
- survival-focused

Visual language:

- flickering green/amber UI
- low contrast corners
- noisy scan output
- rough patient card frames
- cheap mechanical sounds

Unlocked/available content:

- tutorial starts here
- street-level patient pool
- basic scan visuals
- basic clinic theme only

---

### Tier 1 — Functional Street Clinic

Atmosphere:

- cleaner layout
- basic neon signage
- functional scan screen
- improved patient file display
- repaired lighting
- modest equipment

Gameplay feeling:

- the clinic is becoming reliable
- still street-level but less desperate

Visual language:

- clearer UI panels
- more stable scanlines
- cleaner operation table
- less aggressive glitch

Possible unlocks:

- first UI theme choice
- first scan visual variant
- first patient card frame
- basic cosmetic selection explanation

---

### Tier 2 — Neon Specialist Clinic

Atmosphere:

- strong holographic panels
- cleaner cyberpunk UI
- better operation table
- animated scan surfaces
- city neon through window
- more confident ambient hum

Gameplay feeling:

- specialist identity
- more professional decisions
- higher-value patients

Visual language:

- vibrant neon edge lighting
- animated risk panels
- stronger scan overlays
- more premium result reveal animations

Possible unlocks:

- specialist patient pool
- higher quality implant previews
- neon clinic theme
- advanced scan visual packs

---

### Tier 3 — Corporate-Grade Cyber Lab

Atmosphere:

- sterile surfaces
- cold blue/white medical light
- corporate-grade holograms
- precision equipment
- elegant UI frames
- high-end patient files

Gameplay feeling:

- prestigious
- controlled
- high-stakes corporate clientele

Visual language:

- clean medical blue/white UI
- precise scanner animations
- subtle audio feedback
- refined operation table motion

Possible unlocks:

- corporate patient pool
- corporate UI theme
- precision scan pack
- premium-looking day report style

---

### Tier 4 — Black-Market Elite Suite

Atmosphere:

- luxury mixed with danger
- dark premium materials
- red/purple high-risk accents
- hidden server panels
- intense scan overlays
- rare implant display cases

Gameplay feeling:

- elite but dangerous
- high profit and high consequence
- reputation and legal risk intertwined

Visual language:

- red/purple risk lighting
- dark velvet/metal textures
- high-intensity result animations
- stronger audio tension

Possible unlocks:

- elite high-risk patient pool
- redline UI theme
- rare implant previews
- high-stakes event visuals

---

## What can change visually

Interchangeable visual areas:

- clinic room background
- operation table
- scanner device
- patient file frame
- holographic UI shell
- risk meter style
- scanline effect
- warning pulse effect
- glitch style
- result reveal animation
- ambience layer
- UI sound theme
- neon signage
- seasonal props

---

## Data-driven implementation target

Future data types:

- `ClinicTierVisualData`
- `ClinicThemeData`
- `VisualPackData`
- `UIThemeData`
- `ScanVisualData`
- `AmbienceThemeData`

Potential `ClinicThemeData` fields:

- `themeId`
- `nameLocalizationKey`
- `descriptionLocalizationKey`
- `requiredClinicTier`
- `requiredReputation`
- `backgroundVisualRef`
- `operationTableVisualRef`
- `uiThemeRef`
- `scanVisualRef`
- `resultAnimationRef`
- `ambientSoundRef`
- `eventTags`
- `patientPoolTags`
- `isPremium`
- `entitlementKey`

---

## Progression unlock philosophy

Clinic progression should be partly earned and partly customizable.

Recommended approach:

- Tier upgrades unlock baseline visual improvements.
- Reputation unlocks prestigious variants.
- Events unlock seasonal variants.
- Premium purchases unlock optional visual identities.
- Paid visuals should not be the only way for the clinic to improve visually.

---

## Relationship to gameplay

Visual progression may unlock or signal gameplay state, but should not hide critical mechanics behind payment.

Examples:

- a better scanner theme may make warnings more readable
- higher clinic tiers may unlock new patient pools
- premium themes may change look and sound, not core success math
- event themes may temporarily alter atmosphere and patient mix

---

## Relationship to tutorial

The first tutorial should start with a low-tier clinic identity so later upgrades feel meaningful.

The tutorial should show at least one upgrade preview or locked visual hint to make players understand that the clinic can evolve.

Possible hint:

- a locked wall panel labeled by localization key
- a flickering unavailable scanner preview
- a brief post-success message implying the clinic can be upgraded later

The tutorial must not open a store or push purchases.

---

## Seasonal and special day overlays

Seasonal visuals should be overlays, not separate hardcoded scenes.

Examples:

- temporary neon signage
- altered rain/lighting color
- event badge on patient cards
- special day background props
- alternate ambience layer
- themed result stamp

These should be attachable through data such as `SeasonalThemeData` and later remote activation through backend/live event systems.

---

## Non-negotiable rules

1. Clinic visual state must be data-driven.
2. UI theme changes must not require rewriting UI logic.
3. Visual progression must support localization for names/descriptions.
4. Premium visuals must not create unfair core mathematical advantage.
5. Seasonal visuals must be attachable without core code rewrites.
6. Progression visuals must reinforce player identity and long-term retention.
7. Landscape readability must remain intact across all visual tiers.
8. The player should always understand what changed visually after an upgrade.

---

## Milestone 1.6 acceptance criteria

Milestone 1.6 is complete when:

- clinic tiers are documented with visual language and possible unlocks
- landscape composition constraints are documented
- interchangeable visual areas are documented
- seasonal overlay approach is documented
- relationship between progression, premium visuals, and gameplay fairness is documented
- no gameplay UI, scene work, store implementation, SDK integration, or backend implementation is created
