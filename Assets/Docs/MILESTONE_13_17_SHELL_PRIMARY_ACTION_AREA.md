# Milestone 13.17 — Patient Puzzle Shell Primary Action Area

**Date:** 2026-05-27  
**Status:** Validated locally in Unity  
**Scope:** Add a placeholder PrimaryActionArea to the patient puzzle shell.

---

## Goal

M13.17 adds a dedicated shell area for primary operation actions.

This creates a placeholder foundation for future Preview and Commit visual states without adding final buttons, animation, art, or production UI.

---

## Added shell area

```text
PrimaryActionArea
```

---

## Updated systems

- `PatientPuzzleShellLocalizationKeys`
- `PatientPuzzleShellLayout`
- `PatientPuzzleShellPresenter`
- `PatientPuzzleShellRuntime`

---

## Added validator

- `PatientPuzzleShellPrimaryActionValidator`

---

## New editor menu

```text
Cyber Clinic/Slices/Run Patient Puzzle Shell Primary Action Debug
```

---

## Validation fix

During local validation, the first run exposed culture-sensitive decimal formatting in shell presentation output.

The presenter now formats chance values with invariant culture so debug shell output is deterministic across editor locales.

---

## Validated primary action output

```text
PatientPuzzleShellPrimaryActionDebug OK
keysOk=True
layoutOk=True
presentationOk=True
runtimeOk=True
primaryActionArea=True
previewActionState=available
commitActionState=available
uiBinding=shell_primary_action_placeholder_ready
```

---

## End-to-end regression still passes

```text
PatientPuzzleShellEndToEndDebug OK
foundationOk=True
sceneSmokeOk=True
scenePath=Assets/_CyberClinic/Scenes/PatientPuzzleShell.unity
sceneName=PatientPuzzleShell
canvasCount=1
eventSystemCount=1
uiBinding=shell_end_to_end_ready
```

---

## Not included

- final buttons
- final UI
- final art
- animation system
- backend
- SDKs
- monetization
- content expansion

---

## Completion result

M13.17 is complete because the primary action validator passed and the shell end-to-end validator still passed locally in Unity.
