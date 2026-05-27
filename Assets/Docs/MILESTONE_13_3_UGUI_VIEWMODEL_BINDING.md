# Milestone 13.3 — UGUI Debug ViewModel Binding

**Date:** 2026-05-27  
**Status:** Validated locally in Unity  
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

---

## Manual validation result

Manual Play Mode validation was completed in Unity:

- PlayableSliceUgui scene opened in Hierarchy.
- Preview button was clicked successfully.
- Commit button was clicked successfully.
- No Cyber Clinic runtime script error was reported.
- Visible debug output remained stable after the ViewModel binding change.

---

## Project panel scene visibility note

During validation, the scene appeared open in the Hierarchy as:

```text
PlayableSliceUgui
  PlayableSliceUguiRuntime
```

However, `PlayableSliceUgui.unity` was not visible in the Project panel under `Assets/_CyberClinic/Scenes` even after the scene builder log appeared.

This does not block M13.3 runtime validation, but it should be improved as editor tooling in a follow-up step so the debug scene can be created, opened, selected, and located more reliably.

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

M13.3 is complete because:

- manual Play Mode Preview works
- manual Play Mode Commit works
- visible debug output remains stable
- no Cyber Clinic runtime script errors were reported
- data now flows through `PatientPuzzleSliceViewModel`
