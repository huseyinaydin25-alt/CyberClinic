# Milestone 13.7 — Production-Intent UI Shell Plan

**Date:** 2026-05-27  
**Status:** Planned  
**Scope:** Define the first production-intent UI shell that will consume `PatientPuzzleSliceScreenModel` without adding final art, animations, prefabs, SDKs, backend, monetization, or production content.

---

## Goal

M13.7 starts the transition from debug UGUI toward a production-intent UI architecture.

This does not mean final UI. It means creating a cleaner shell structure that reflects the intended premium Cyber Clinic screen organization while still using placeholder visual treatment.

---

## Current foundation

Validated foundation before M13.7:

```text
Runner
Report
ViewModel
ScreenModel
Debug UGUI
```

Validated menus:

```text
Cyber Clinic/Slices/Run Patient Puzzle Slice ViewModel Debug
Cyber Clinic/Slices/Run Patient Puzzle Slice ScreenModel Debug
Cyber Clinic/Slices/Run Patient Puzzle Slice Data Consistency
Cyber Clinic/Slices/Run Playable Slice UGUI Runtime Smoke Test
```

---

## Production-intent shell definition

A production-intent UI shell is a structured UI scene/runtime that:

- consumes `PatientPuzzleSliceScreenModel`
- maps data into screen sections
- uses placeholder shapes, panels, and labels
- keeps player-facing text localization-ready
- avoids debug text blobs as the core binding method
- introduces a more intentional screen hierarchy than the current debug UGUI
- remains easy to validate through editor menus

It is not final UI art.

---

## Proposed shell areas

The first shell should include five visible areas:

```text
PatientDossierArea
ProcedureDecisionArea
RiskAnalysisArea
OperationResultArea
ActionFeedbackArea
```

Optional later area:

```text
PersistentClinicStatusArea
```

This optional area should wait until the clinic progression screen model is expanded.

---

## Section-to-data mapping

### PatientDossierArea

Consumes:

```text
PatientPuzzleSliceScreenModel.PatientDossier
```

Current fields:

```text
PatientId
PatientSeed
```

Shell display may show raw IDs only if marked as debug/placeholder.

Future production labels should use localization keys.

---

### ProcedureDecisionArea

Consumes:

```text
PatientPuzzleSliceScreenModel.ProcedureDecision
```

Current fields:

```text
SelectedImplantId
SelectedProcedureId
```

Shell should visually separate implant and procedure instead of placing both inside one text blob.

---

### RiskAnalysisArea

Consumes:

```text
PatientPuzzleSliceScreenModel.RiskAnalysis
```

Current fields:

```text
PreviewSuccessChance
CommitSuccessChance
RiskBand
OutcomeType
```

Shell should reserve space for future risk modifiers, warning states, and animated scan feedback.

---

### OperationResultArea

Consumes:

```text
PatientPuzzleSliceScreenModel.OperationResult
```

Current fields:

```text
StartingCredits
EndingCredits
StartingReputation
EndingReputation
CreditsDelta
ReputationDelta
OutcomeType
SaveSummary
```

Shell should make result and deltas more prominent than raw save summary.

`SaveSummary` should remain debug-only.

---

### ActionFeedbackArea

Consumes:

```text
PatientPuzzleSliceScreenModel.ActionFeedback
```

Current fields:

```text
VisualCueId
AudioCueId
```

Shell may display cue routing in placeholder/debug mode, but future production UI should route these to visual/audio systems instead of showing raw IDs.

---

## Layout direction

The first shell should be landscape-first and mobile-aware.

Recommended arrangement:

```text
[ Patient Dossier ] [ Risk Analysis     ] [ Operation Result ]
[ Procedure      ] [ Action Feedback   ] [ Primary Action   ]
```

The screen should create a clearer sense of tactical decision flow:

```text
Patient → Procedure → Risk → Commit → Result
```

---

## Technical direction

M13.7 should remain a plan only.

M13.8 may implement a minimal runtime-generated shell using the existing UGUI approach, but with separate shell classes and section binding.

Possible future classes:

```text
PatientPuzzleShellScreenModelPresenter
PatientPuzzleShellRuntime
PatientPuzzleShellDebugValidator
```

The existing debug UGUI should remain intact until the shell is validated.

---

## Validation expectations for future implementation

A future shell validator should confirm:

```text
shell root exists
all five section areas exist
section data is bound from PatientPuzzleSliceScreenModel
patient section receives patient ID and seed
procedure section receives implant and procedure IDs
risk section receives chance/risk/outcome
result section receives credits/reputation deltas
feedback section receives visual/audio cue IDs
no required section is empty
uiBinding=production_intent_shell_placeholder
```

---

## Localization rule

Production-intent shell work must distinguish between:

```text
raw debug IDs
localization keys
resolved player-facing labels
```

In the shell phase, raw IDs are allowed only as temporary placeholder/debug display.

Production-facing labels should be introduced through localization-ready fields, not hardcoded final text.

---

## Explicitly out of scope

- final production UI
- final art
- hand-authored UI prefab library
- animation/tween implementation
- VFX
- audio mixer routing
- backend
- SDKs
- monetization
- store UI
- cosmetic store
- large content expansion

---

## Completion criteria for M13.7

M13.7 is complete when this plan exists and the next implementation step is clearly constrained to a minimal, validator-backed, production-intent placeholder shell.

---

## Recommended next milestone

M13.8 should implement the minimal production-intent placeholder shell runtime and validator.

It should consume `PatientPuzzleSliceScreenModel`, keep the existing debug UGUI untouched, and expose a new editor menu for validation.
