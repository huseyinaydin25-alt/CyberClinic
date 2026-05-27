# Milestone 13.13 — Patient Puzzle Shell Style Contract

**Date:** 2026-05-27  
**Status:** Implemented, pending local Unity validation  
**Scope:** Centralize shell colors, font sizes, and small UI dimensions.

---

## Goal

M13.13 moves shell visual style constants out of `PatientPuzzleShellRuntime` and into a dedicated style contract.

This keeps runtime construction cleaner and prepares the shell for later theme and polish work.

---

## Added systems

- `PatientPuzzleShellStyle`
- `PatientPuzzleShellStyleValidator`

---

## Updated systems

- `PatientPuzzleShellRuntime`

---

## New editor menu

```text
Cyber Clinic/Slices/Run Patient Puzzle Shell Style Debug
```

---

## Expected validator output

```text
PatientPuzzleShellStyleDebug OK
styleOk=True
titleFontSize=32
subtitleFontSize=18
sectionHeaderFontSize=19
sectionBodyFontSize=17
footerFontSize=16
headerHeight=48
accentBarWidth=6
uiBinding=shell_style_contract_ready
```

---

## Regression checks

After the style validator passes, these should still pass:

```text
Cyber Clinic/Slices/Run Patient Puzzle Shell Debug
Cyber Clinic/Slices/Run Patient Puzzle Shell Layout Debug
Cyber Clinic/Slices/Run Patient Puzzle Shell Presenter Debug
Cyber Clinic/Slices/Run Patient Puzzle Shell Localization Keys Debug
```

---

## Not included

- final UI
- final art
- animation system
- backend
- SDKs
- monetization
- content expansion

---

## Completion criteria

M13.13 is complete when the style validator passes and existing shell validators still pass.
