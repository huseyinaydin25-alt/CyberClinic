# Milestone 13.15 — Patient Puzzle Shell Scene Smoke Validator

**Date:** 2026-05-27  
**Status:** Validated locally in Unity  
**Scope:** Add a scene-level smoke validator for `PatientPuzzleShell.unity`.

---

## Goal

M13.15 verifies that the saved shell scene asset can open and build the runtime placeholder shell structure.

This is stronger than checking whether the scene contains a `PatientPuzzleShellRuntime` component.

---

## Added system

- `PatientPuzzleShellSceneSmokeValidator`

---

## New editor menu

```text
Cyber Clinic/Slices/Run Patient Puzzle Shell Scene Smoke Test
```

---

## Validated scene path

```text
Assets/_CyberClinic/Scenes/PatientPuzzleShell.unity
```

---

## Validated output

```text
PatientPuzzleShellSceneSmoke OK
scenePath=Assets/_CyberClinic/Scenes/PatientPuzzleShell.unity
sceneName=PatientPuzzleShell
runtimeExists=True
rootExists=True
canvasCount=1
eventSystemCount=1
sectionsOk=True
bindingOk=True
uiBinding=shell_scene_smoke_ready
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

## Completion result

M13.15 is complete because the scene smoke validator passed locally in Unity.
