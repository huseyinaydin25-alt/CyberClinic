# Milestone 13.3 — UGUI Debug ViewModel Binding

**Date:** 2026-05-27  
**Status:** Implemented, pending local Unity validation  
**Scope:** Wire the existing debug/playable UGUI controller through `PatientPuzzleSliceViewModel` while preserving the same visible debug behavior.

---

## Goal

M13.3 aligns the existing debug UGUI slice with the future premium UI data architecture.

The visible debug scene should continue to behave the same, but the controller now consumes `PatientPuzzleSliceViewModel` instead of binding directly to `PatientPuzzleSliceReport` fields.

---

## Changed system

- `PatientPuzzleSliceDebugController`

---

## Data flow after M13.3

```text
PatientPuzzleSliceRunner.RunDebugSlice()
        ↓
PatientPuzzleSliceViewModelBuilder.BuildDebugViewModel()
        ↓
PatientPuzzleSliceDebugController
        ↓
UGUI debug panels / state chips / action readout
```

---

## Expected behavior

The existing UGUI debug scene should still show:

- patient panel
- implant panel
- risk panel
- result panel
- preview state chip
- commit state chip
- action readout
- preview button
- commit button

Preview should still set:

```text
lastAction=preview
stateId=preview.ready
```

Commit should still set:

```text
lastAction=commit
stateId=commit.done
creditsDelta=+90
reputationDelta=+5
```

---

## Validation menu

Use the existing smoke test:

```text
Cyber Clinic/Slices/Run Playable Slice UGUI Runtime Smoke Test
```

Expected output should still include:

```text
PlayableSliceUguiRuntimeSmokeValidator OK
actionReadoutAfterCommitContains=lastAction=commit
uiMode=UGUI
```

Also manually validate Play Mode in:

```text
Assets/_CyberClinic/Scenes/PlayableSliceUgui.unity
```

---

## Explicitly not added

- production UI
- prefab-based UI
- final visual style
- animation/tween system
- backend
- SDKs
- monetization
- new content

---

## Completion criteria

M13.3 is complete when:

- UGUI smoke validator passes
- manual Play Mode Preview still works
- manual Play Mode Commit still works
- visible debug output remains stable
- no Cyber Clinic runtime script errors are reported
