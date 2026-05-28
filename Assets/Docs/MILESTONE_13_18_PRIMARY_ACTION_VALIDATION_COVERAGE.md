# Milestone 13.18 — Primary Action Validation Coverage

**Date:** 2026-05-27  
**Status:** Implemented, pending local Unity validation  
**Scope:** Include `PrimaryActionArea` in higher-level shell validators.

---

## Goal

M13.18 ensures the new `PrimaryActionArea` is not only checked by its dedicated validator, but also by the main shell validation chain.

---

## Updated validators

- `PatientPuzzleShellFoundationValidator`
- `PatientPuzzleShellDebugValidator`
- `PatientPuzzleShellSceneSmokeValidator`
- `PatientPuzzleShellEndToEndValidator`

---

## Expected validation outputs

### Foundation

```text
PatientPuzzleShellFoundationDebug OK
localizationOk=True
layoutOk=True
styleOk=True
presenterOk=True
runtimeOk=True
primaryActionIncluded=True
canvasCount=1
eventSystemCount=1
uiBinding=shell_foundation_aggregate_ready
```

### Shell Debug

```text
PatientPuzzleShellDebug OK
primaryActionArea=True
primaryActionBinding=True
uiBinding=production_intent_shell_placeholder
```

### Scene Smoke

```text
PatientPuzzleShellSceneSmoke OK
primaryActionIncluded=True
bindingOk=True
uiBinding=shell_scene_smoke_ready
```

### End-to-End

```text
PatientPuzzleShellEndToEndDebug OK
foundationOk=True
sceneSmokeOk=True
primaryActionIncluded=True
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

## Completion criteria

M13.18 is complete when all updated validators pass locally in Unity.
