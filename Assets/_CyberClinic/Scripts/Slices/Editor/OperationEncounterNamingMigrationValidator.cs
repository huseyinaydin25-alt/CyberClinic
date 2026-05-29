#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace CyberClinic.Slices.Editor
{
    public static class OperationEncounterNamingMigrationValidator
    {
        [MenuItem("Cyber Clinic/Slices/Run Operation Encounter Naming Migration Debug")]
        public static void RunDebug()
        {
            var screenModel = PatientPuzzleSliceScreenModelBuilder.BuildDebugScreenModel();
            var controller = new OperationEncounterSessionController(screenModel);

            var initial = controller.CurrentState;
            var preview = controller.Preview();
            var binding = OperationEncounterPreviewResultBinder.Bind(preview);
            var commit = controller.Commit();
            var reset = controller.Reset();

            var initialOk =
                initial.ActionState.PreviewState == PreviewActionState.Available &&
                initial.ActionState.CommitState == CommitActionState.Available &&
                initial.LastInteractionId == "patient_puzzle.session.initial" &&
                !initial.HasPreviewed &&
                !initial.HasCommitted &&
                !initial.IsLocked;

            var previewOk =
                preview.ActionState.PreviewState == PreviewActionState.Previewed &&
                preview.ActionState.CommitState == CommitActionState.Available &&
                preview.LastInteractionId == "primary_action.preview" &&
                preview.HasPreviewed &&
                !preview.HasCommitted &&
                !preview.IsLocked;

            var bindingOk =
                binding.SessionState.ActionState.PreviewState == PreviewActionState.Previewed &&
                binding.SessionState.ActionState.CommitState == CommitActionState.Available &&
                binding.FeedbackRouteId == "primary_action.feedback.previewed" &&
                binding.ReadoutVisualTokenId == "primary_action.visual.previewed";

            var commitOk =
                commit.ActionState.PreviewState == PreviewActionState.Previewed &&
                commit.ActionState.CommitState == CommitActionState.Committed &&
                commit.LastInteractionId == "primary_action.commit" &&
                commit.HasPreviewed &&
                commit.HasCommitted &&
                commit.IsLocked;

            var resetOk =
                reset.ActionState.PreviewState == PreviewActionState.Available &&
                reset.ActionState.CommitState == CommitActionState.Available &&
                reset.LastInteractionId == "patient_puzzle.session.initial" &&
                !reset.HasPreviewed &&
                !reset.HasCommitted &&
                !reset.IsLocked;

            if (!initialOk || !previewOk || !bindingOk || !commitOk || !resetOk)
            {
                Debug.LogWarning(
                    "OperationEncounterNamingMigrationDebug failed" +
                    "\ninitialOk=" + initialOk +
                    "\npreviewOk=" + previewOk +
                    "\nbindingOk=" + bindingOk +
                    "\ncommitOk=" + commitOk +
                    "\nresetOk=" + resetOk);
                return;
            }

            Debug.Log(
                "OperationEncounterNamingMigrationDebug OK" +
                "\ncanonicalName=OperationEncounter" +
                "\nlegacyName=PatientPuzzle" +
                "\ninitialState=Available/Available" +
                "\npreviewState=Previewed/Available" +
                "\npreviewBinding=True" +
                "\ncommitState=Previewed/Committed" +
                "\nresetState=Available/Available" +
                "\nlegacyCompatibility=True" +
                "\nuiBinding=operation_encounter_naming_ready");
        }
    }
}
#endif
