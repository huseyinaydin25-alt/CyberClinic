# Playable Slice Debug Validation

**Date:** 2026-05-27  
**Status:** Validated locally in Unity Play Mode  
**Scope:** First local playable debug scene and UGUI debug scene for the technical patient puzzle slice.

---

## Added systems

- `PatientPuzzleSliceDebugController`
- `PlayableSliceDebugSceneBuilder`
- `PlayableSliceDebugSceneValidator`
- `PlayableSliceUguiRuntime`
- `PlayableSliceUguiRuntimeSceneBuilder`
- `PlayableSliceUguiRuntimeSceneValidator`
- `PlayableSliceUguiRuntimeSmokeValidator`

---

## Scene: OnGUI debug slice

```text
Assets/_CyberClinic/Scenes/PlayableSliceDebug.unity
```

Created through:

```text
Cyber Clinic/Slices/Create Playable Slice Debug Scene
```

Validated through:

```text
Cyber Clinic/Slices/Validate Playable Slice Debug Scene
```

---

## Scene: UGUI debug slice

```text
Assets/_CyberClinic/Scenes/PlayableSliceUgui.unity
```

Created through:

```text
Cyber Clinic/Slices/Create Playable Slice UGUI Scene
```

Validated through:

```text
Cyber Clinic/Slices/Validate Playable Slice UGUI Scene
```

Runtime smoke-tested through:

```text
Cyber Clinic/Slices/Run Playable Slice UGUI Runtime Smoke Test
```

---

## Runtime debug UI

The first debug scene uses immediate-mode debug UI via `OnGUI`.

The UGUI debug scene creates its canvas, camera, event system, panels, buttons, and state chips at runtime through `PlayableSliceUguiRuntime`.

The UGUI scene shows:

- patient panel
- implant panel
- risk panel
- result panel
- preview button
- commit button
- preview state chip
- commit state chip

This is intentionally not production UI.

---

## User validation: OnGUI debug slice

Preview state displayed in Play Mode:

```text
stateId=preview.ready
patientId=test_street_netrunner
patientSeed=82115621
selectedImplantId=test_implant_optic_tune
selectedProcedureId=test_proc_micro_install
```

Commit state displayed in Play Mode:

```text
stateId=commit.done
patientId=test_street_netrunner
patientSeed=82115621
selectedImplantId=test_implant_optic_tune
selectedProcedureId=test_proc_micro_install
```

No Unity Console errors were reported.

---

## User validation: UGUI debug slice

Scene validator output:

```text
PlayableSliceUguiSceneValidator OK
scenePath=Assets/_CyberClinic/Scenes/PlayableSliceUgui.unity
runtimeCount=1
controllerCount=1
uiMode=UGUI
```

Runtime smoke validator output:

```text
PlayableSliceUguiRuntimeSmokeValidator OK
rootExists=True
canvasCount=1
eventSystemCount=1
cameraExists=True
previewButtonCount=1
commitButtonCount=1
previewStateAfterPreview=ui.slice.preview.state.active
commitStateAfterCommit=ui.slice.commit.state.active
uiMode=UGUI
```

Manual Play Mode validation confirmed:

- UGUI scene opens in Play Mode.
- Four panels are visible.
- Preview and Commit buttons are visible.
- Preview and Commit buttons update displayed slice values.
- Preview and Commit state feedback is visually distinguishable after the debug polish pass.
- No Unity Console errors were reported.

---

## Confirmed behavior

- OnGUI debug scene can be created by menu.
- OnGUI debug scene can be opened and played.
- UGUI debug scene can be created by menu.
- UGUI debug scene can be opened and played.
- UGUI runtime creates Canvas, EventSystem, and Main Camera safely.
- UGUI runtime uses `InputSystemUIInputModule` when the Input System package is enabled.
- Preview action runs the M11 slice report.
- Commit action runs the M11 slice report.
- Patient, implant, procedure, risk, result, economy, visual cue, audio cue, and save summary fields display correctly.
- Preview and Commit state changes are now smoke-testable through editor tooling.
- The slice is now locally playable as a debug UGUI scene.

---

## Not created

- production UI
- final scene layout
- production art
- production prefabs
- real VFX spawning
- real audio playback
- save slot UI
- backend/cloud calls
- platform SDK calls
- monetization SDK calls

---

## Next practical step

Keep the UGUI debug slice as the verified local playable foundation. The next implementation step should remain small: either add a lightweight debug-only event log/readout to the UGUI slice or start a separate production-intent UI plan document before adding any production art, SDK, backend, or monetization work.
