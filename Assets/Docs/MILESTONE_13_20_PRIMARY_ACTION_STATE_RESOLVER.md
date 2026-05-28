# Milestone 13.20 — Primary Action State Resolver

**Date:** 2026-05-28  
**Status:** Validated locally in Unity  
**Scope:** Add and validate a small transition resolver for primary action states.

---

## Goal

M13.20 adds a deterministic resolver for `PatientPuzzlePrimaryActionState` transitions.

This keeps Preview and Commit state transitions testable before adding final buttons, animation, production UI, backend, SDKs, or monetization.

---

## Added resolver

```text
PatientPuzzlePrimaryActionStateResolver
```

---

## Resolver transitions

```text
Initial        -> Available/Available
AfterPreview   -> Previewed/Available
AfterCommit    -> Previewed/Committed
Disabled       -> Disabled/Disabled
Disabled input -> Disabled/Disabled
```

---

## Updated model file

- `PatientPuzzlePrimaryActionState.cs`

---

## Added validator

- `PatientPuzzlePrimaryActionStateResolverValidator`

---

## New editor menu

```text
Cyber Clinic/Slices/Run Patient Puzzle Primary Action State Resolver Debug
```

---

## Validated resolver output

```text
PatientPuzzlePrimaryActionStateResolverDebug OK
initialState=Available/Available
afterPreviewState=Previewed/Available
afterCommitState=Previewed/Committed
disabledState=Disabled/Disabled
disabledPreserved=True
uiBinding=primary_action_state_resolver_ready
```

---

## Existing primary action state validator still passes

```text
PatientPuzzlePrimaryActionStateDebug OK
previewStatesOk=True
commitStatesOk=True
defaultPreviewState=Available
defaultCommitState=Available
previewedStateRepresentable=True
committedStateRepresentable=True
disabledStateRepresentable=True
presenterBindingOk=True
uiBinding=primary_action_state_model_ready
```

---

## Existing shell primary action validator still passes

```text
PatientPuzzleShellPrimaryActionDebug OK
keysOk=True
layoutOk=True
presentationOk=True
runtimeOk=True
primaryActionArea=True
previewActionState=Available
commitActionState=Available
uiBinding=shell_primary_action_placeholder_ready
```

---

## Existing foundation validator still passes

```text
PatientPuzzleShellFoundationDebug OK
localizationOk=True
layoutOk=True
styleOk=True
presenterOk=True
runtimeOk=True
primaryActionIncluded=True
primaryActionStateIncluded=True
previewState=Available
commitState=Available
canvasCount=1
eventSystemCount=1
uiBinding=shell_foundation_aggregate_ready
```

---

## Existing end-to-end validator still passes

```text
PatientPuzzleShellEndToEndDebug OK
foundationOk=True
sceneSmokeOk=True
primaryActionIncluded=True
primaryActionStateIncluded=True
previewState=Available
commitState=Available
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

M13.20 is complete because the resolver validator passed and the existing primary action / shell regression validators still passed locally in Unity.

---

## Overall project progress estimate

Approximate full-game completion after M13.20: **17%**.
