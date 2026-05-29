# Roadmap Addendum — 3D Gameplay, Operation Room, and Clinic World

**Date:** 2026-05-29  
**Status:** Added to roadmap  
**Scope:** Redirect Cyber Clinic toward 3D gameplay, 3D operation room interactions, 3D clinic spaces, camera systems, 3D tools, animation, and premium presentation.

---

## Strategic decision

Cyber Clinic gameplay should be 3D.

The game should not be limited to flat UI screens. The operation encounter, clinic ownership fantasy, item prestige, cosmetic skins, tools, patients, VFX, and raid/group surgeries should all eventually have a 3D presentation layer.

---

## Updated product definition

```text
Cyber Clinic = 3D cyber-medical clinic RPG
+ procedural 3D surgery encounters
+ MMO-style itemization and equipment builds
+ premium cosmetic customization
+ 3D clinic environment ownership
+ live-ops retention systems
+ social alliance / league systems
+ co-op high-difficulty operations
+ long-term item and cosmetic chase
```

---

## Important compatibility note

Existing UI / shell / session / controller / validator work remains useful.

It should be reclassified as:

```text
3D operation gameplay logic foundation
3D encounter state foundation
UI overlay foundation
Debug validation foundation
```

The 3D layer should consume the same decision loop, session state, preview / commit results, item modifiers, and feedback routes.

---

## Added roadmap pillars

```text
3D Operation Room
3D Patient Presentation
3D Surgical Tool Interaction
3D Clinic Environment
3D Camera System
3D Animation System
3D VFX / SFX Integration
3D Cosmetic Skin Application
3D Item / Equipment Visualization
3D Raid / Group Surgery Presentation
Mobile Performance / Optimization
```

---

## M49 — 3D Technical Foundation

```text
M49.1 — 3D Scene Folder Contract
M49.2 — 3D Prefab Folder Contract
M49.3 — 3D Material / Shader Placeholder Contract
M49.4 — 3D Lighting Placeholder Contract
M49.5 — 3D Camera Rig Placeholder
M49.6 — 3D Performance Budget Document
M49.7 — 3D Foundation Validator
```

Goal: Prepare the project for 3D production without breaking current 2D/UI foundations.

---

## M50 — 3D Operation Room Prototype

```text
M50.1 — Operation Room Scene Builder
M50.2 — Operating Table Placeholder
M50.3 — Patient Placeholder Mesh
M50.4 — Tool Tray Placeholder
M50.5 — Room Lighting Placeholder
M50.6 — Operation Room Smoke Validator
M50.7 — Operation Room Aggregate Validator
```

Goal: Create the first 3D scene where surgery gameplay can eventually happen.

---

## M51 — 3D Patient Presentation Foundation

```text
M51.1 — Patient 3D Avatar Placeholder
M51.2 — Patient Condition Visual Slot Model
M51.3 — Implant Target Zone Placeholder
M51.4 — Symptom / Risk Visual Marker Placeholder
M51.5 — Patient Visual State Binding
M51.6 — Patient 3D Presentation Validator
```

Goal: Make generated patients visible and readable in 3D.

---

## M52 — 3D Surgical Tool Interaction Foundation

```text
M52.1 — Tool Interaction Target Model
M52.2 — Select Tool Intent
M52.3 — Aim / Hover Placeholder
M52.4 — Apply Tool Intent
M52.5 — Tool Feedback Token Binding
M52.6 — Tool Interaction Validator
```

Goal: Prepare actual 3D gameplay interactions around medical tools.

---

## M53 — 3D Camera and Input Foundation

```text
M53.1 — Operation Camera Rig
M53.2 — Focus Target Model
M53.3 — Camera Zoom / Pan Placeholder
M53.4 — Mobile Touch Input Intent
M53.5 — Desktop Debug Input Intent
M53.6 — Camera / Input Validator
```

Goal: Make 3D operation scenes controllable on mobile and testable in editor.

---

## M54 — 3D Clinic Environment Foundation

```text
M54.1 — Clinic Room Scene Builder
M54.2 — Clinic Navigation Placeholder
M54.3 — Upgradeable Facility Slot Placeholder
M54.4 — Cosmetic Decoration Slot Placeholder
M54.5 — Clinic Prestige Visual Binding
M54.6 — Clinic Environment Validator
```

Goal: Let the clinic become a visible owned 3D space, not just menus.

---

## M55 — 3D Item and Equipment Visualization

```text
M55.1 — 3D Item Display Model
M55.2 — Equipped Tool Mesh Binding
M55.3 — Device Skin Mesh Binding
M55.4 — Implant Visual Variant Binding
M55.5 — Rarity Material / VFX Token Binding
M55.6 — 3D Equipment Visualization Validator
```

Goal: Make item ownership visible in 3D and emotionally valuable.

---

## M56 — 3D Cosmetic Skin Application

```text
M56.1 — 3D Skin Slot Binding
M56.2 — Clinic Theme Mesh / Material Binding
M56.3 — Tool Skin Mesh / Material Binding
M56.4 — Avatar Skin Binding
M56.5 — Skin Preview Scene Placeholder
M56.6 — 3D Skin Validator
```

Goal: Connect monetizable cosmetic systems to visible 3D presentation.

---

## M57 — 3D Operation VFX / Animation Foundation

```text
M57.1 — Operation Animation Token Model
M57.2 — Tool Use Animation Placeholder
M57.3 — Patient Reaction Animation Placeholder
M57.4 — Success / Failure Result VFX Binding
M57.5 — Rare Result Celebration VFX Binding
M57.6 — 3D VFX / Animation Validator
```

Goal: Make operations feel premium and responsive.

---

## M58 — 3D Group / Raid Surgery Presentation

```text
M58.1 — Multi-Specialist Operation Layout Placeholder
M58.2 — Contribution Slot Visual Model
M58.3 — Raid Phase Visual Placeholder
M58.4 — Alliance Member Contribution Visual Binding
M58.5 — Raid Result Presentation Placeholder
M58.6 — 3D Raid Surgery Validator
```

Goal: Prepare co-op and alliance operations for high-end 3D presentation.

---

## M59 — 3D Mobile Performance and Optimization Layer

```text
M59.1 — Target Device Performance Budget
M59.2 — Mesh / Material Budget Rules
M59.3 — VFX Budget Rules
M59.4 — Camera / Lighting Budget Rules
M59.5 — Quality Tier Placeholder
M59.6 — Performance Validator Checklist
```

Goal: Keep the 3D direction realistic for mobile platforms.

---

## Roadmap integration

The redesigned master roadmap should now include 3D gameplay as an early major pillar, not a late polish layer.

Recommended placement:

```text
Finish M15 Operation Decision Loop
Then add 3D Technical Foundation / Operation Room Prototype earlier
Then connect itemization and operation modifiers to both logic and 3D presentation
Then build cosmetics / skins with 3D visibility from the beginning
```

---

## Implementation rule

Do not jump directly to final 3D art.

Use placeholder geometry, validators, scene builders, and deterministic state binding first:

```text
Placeholder 3D scene
Logic-to-3D binding
3D validator
Then visual polish
Then production art
```

---

## Current work implication

M15 should still continue.

But M15 should be understood as the gameplay logic layer that will drive future 3D operations.

```text
M15 Preview / Commit / Result / Locking
-> drives 3D operation UI overlay
-> drives 3D patient state
-> drives 3D tool feedback
-> drives operation VFX/SFX
-> drives item stat modifier display
```
