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
- darker illegal opportunities
- personal identity through selected themes

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

---

### Tier 4 — Black-Market Elite Suite

Atmosphere:

- luxury mixed with danger
- dark premium materials
- red/purple illegal-market accents
- hidden server panels
- intense scan overlays
- rare implant display cases

Gameplay feeling:

- elite but dangerous
- illegal power
- reputation and legal risk intertwined

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

---

## Non-negotiable rules

1. Clinic visual state must be data-driven.
2. UI theme changes must not require rewriting UI logic.
3. Visual progression must support localization for names/descriptions.
4. Premium visuals must not create unfair core mathematical advantage.
5. Seasonal visuals must be attachable without core code rewrites.
6. Progression visuals must reinforce player identity and long-term retention.
