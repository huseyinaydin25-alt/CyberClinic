# Milestone 13.4 — UI Binding Contract

**Date:** 2026-05-27  
**Status:** Planned contract  
**Scope:** Define how the current patient puzzle ViewModel should map into future debug and production-intent UI screens.

---

## Goal

M13.4 defines a clear UI binding contract before adding production UI code, prefabs, animation, art, backend, SDKs, or monetization.

The purpose is to keep the project aligned with the premium Cyber Clinic vision while preserving the validated foundation.

---

## Current validated data source

The current validated UI data source is:

```text
PatientPuzzleSliceViewModel
```

Created through:

```text
PatientPuzzleSliceViewModelBuilder.BuildDebugViewModel()
```

Validated through:

```text
Cyber Clinic/Slices/Run Patient Puzzle Slice ViewModel Debug
```

---

## Binding principle

Future UI must bind to structured data, not parsed debug strings.

Allowed:

```text
ViewModel field → UI label/value/state
```

Avoid:

```text
Debug text blob → string parsing → UI
```

Debug UGUI may still show raw IDs for validation, but production-intent UI should convert raw IDs into localized labels, readable presentation, and player-facing structure.

---

## Screen model overview

The patient puzzle slice should eventually be represented as the following screen model areas:

```text
PatientDossierPanel
ProcedureDecisionPanel
RiskAnalysisPanel
OperationResultPanel
ActionFeedbackPanel
PersistentClinicStatusPanel
```

This is a binding contract only. It does not require these panels to exist yet as prefabs or production UI.

---

## PatientDossierPanel contract

Purpose:

- explain who the patient is
- communicate the procedural case context
- make generated patient data feel authored and readable

Current ViewModel fields:

```text
patientId
patientSeed
```

Future required fields beyond current ViewModel:

```text
patientDisplayNameKey
patientArchetypeNameKey
patientMotivationKey
patientRequestTypeKey
patientVisualTraitKey
patientDialogueToneKey
```

Debug-only fields:

```text
patientSeed
raw patientId
```

Production-facing fields should be localization keys or localization-ready IDs.

---

## ProcedureDecisionPanel contract

Purpose:

- show the selected implant and selected procedure
- make the choice feel tactical rather than plain text

Current ViewModel fields:

```text
selectedImplantId
selectedProcedureId
```

Future required fields beyond current ViewModel:

```text
implantDisplayNameKey
implantShortDescriptionKey
procedureDisplayNameKey
procedureShortDescriptionKey
implantCost
compatibilityScore
slotKey
requirements
warnings
```

Debug-only fields:

```text
raw selectedImplantId
raw selectedProcedureId
```

---

## RiskAnalysisPanel contract

Purpose:

- make risk understandable before the player commits
- communicate uncertainty and tradeoff clearly

Current ViewModel fields:

```text
previewSuccessChance
commitSuccessChance
riskBand
outcomeType
```

Future required fields beyond current ViewModel:

```text
riskBandLocalizationKey
riskExplanationKey
primaryRiskModifierKeys
successChancePresentationMode
warningSeverity
```

Presentation notes:

- percentages should be formatted consistently
- risk band should have a visual state
- high-risk states should be obvious but not noisy
- debug numeric values can remain visible only in debug modes

---

## OperationResultPanel contract

Purpose:

- reveal result outcome clearly
- communicate reward, penalty, reputation effect, and next step

Current ViewModel fields:

```text
outcomeType
startingCredits
endingCredits
startingReputation
endingReputation
creditsDelta
reputationDelta
saveSummary
```

Future required fields beyond current ViewModel:

```text
outcomeTitleKey
outcomeDescriptionKey
rewardReasonKey
reputationReasonKey
nextActionKey
```

Debug-only fields:

```text
saveSummary
raw outcomeType when not localized
```

---

## ActionFeedbackPanel contract

Purpose:

- show immediate result of Preview or Commit
- route visual/audio feedback in a structured way

Current ViewModel fields:

```text
visualCueId
audioCueId
```

Current controller state:

```text
lastAction
stateId
```

Future required fields beyond current ViewModel:

```text
actionState
feedbackIntensity
animationCueId
screenShakeCueId
hapticCueId
```

Production-facing UI should not display raw cue IDs. Debug UI may display them.

---

## PersistentClinicStatusPanel contract

Purpose:

- keep long-term economy/reputation/day context visible
- connect each procedure to clinic progression

Current ViewModel fields:

```text
startingCredits
endingCredits
startingReputation
endingReputation
creditsDelta
reputationDelta
```

Future required fields beyond current ViewModel:

```text
currentDayIndex
clinicTier
clinicThemeId
activeCosmeticIds
progressionMilestoneIds
```

This panel should support long-term progression and cosmetic desire later, but monetization and store flows remain out of scope for this milestone.

---

## Localization contract

Production-facing UI should not show raw debug IDs as player text.

Debug acceptable:

```text
patientId=test_street_netrunner
selectedImplantId=test_implant_optic_tune
visualCueId=test_cue_result_reveal
```

Production target:

```text
patientArchetypeNameKey → localized display label
implantDisplayNameKey → localized display label
riskBandLocalizationKey → localized display label
outcomeTitleKey → localized display label
```

Temporary placeholders are acceptable only if they are clearly marked as debug or localization-ready.

---

## Validation contract

Future UI binding validators should confirm:

```text
ViewModel exists
required fields are non-empty
creditsDelta is derived correctly
reputationDelta is derived correctly
risk fields are present
outcome fields are present
cue IDs are present for debug routing
no production-facing panel is forced to parse debug text
```

---

## Explicitly not implemented in M13.4

- production UI prefabs
- final screen layout
- animation/tween system
- VFX
- audio mixer routing
- backend
- SDKs
- monetization
- production content expansion

---

## Recommended next implementation step

M13.5 should add a small `PatientPuzzleSliceScreenModel` or equivalent adapter that groups the existing ViewModel fields into UI-facing sections without creating production UI.

Potential sections:

```text
PatientDossierSection
ProcedureDecisionSection
RiskAnalysisSection
OperationResultSection
ActionFeedbackSection
```

This keeps the project moving toward premium UI architecture while staying incremental and testable.
