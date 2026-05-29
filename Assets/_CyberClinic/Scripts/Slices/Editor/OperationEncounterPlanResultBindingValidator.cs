#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace CyberClinic.Slices.Editor
{
    public static class OperationEncounterPlanResultBindingValidator
    {
        [MenuItem("Cyber Clinic/Operation Encounter/Run Plan Result Binding Debug")]
        public static void RunDebug()
        {
            var screenModel = PatientPuzzleSliceScreenModelBuilder.BuildDebugScreenModel();
            var controller = new OperationEncounterSessionController(screenModel);
            var afterPlan = controller.Plan();
            var binding = OperationEncounterPlanResultBinder.Bind(afterPlan);

            var sessionOk =
                binding.SessionState.HasPreviewed &&
                !binding.SessionState.HasCommitted &&
                !binding.SessionState.IsLocked &&
                binding.SessionState.LastInteractionId == "operation_action.plan" &&
                binding.SessionState.ActionState.PreviewState == PreviewActionState.Previewed &&
                binding.SessionState.ActionState.CommitState == CommitActionState.Available;

            var feedbackOk =
                binding.FeedbackRouteId == "primary_action.feedback.previewed" &&
                binding.ReadoutVisualTokenId == "primary_action.visual.previewed";

            var presentationOk =
                binding.Presentation.HasPrimaryActionState(binding.SessionState.ActionState) &&
                binding.Presentation.PrimaryActionBody.Contains("debug.previewActionState=Previewed") &&
                binding.Presentation.PrimaryActionBody.Contains("debug.commitActionState=Available");

            if (!sessionOk || !feedbackOk || !presentationOk)
            {
                Debug.LogWarning(
                    "OperationEncounterPlanResultBindingDebug failed" +
                    "\nsessionOk=" + sessionOk +
                    "\nfeedbackOk=" + feedbackOk +
                    "\npresentationOk=" + presentationOk +
                    "\nfeedbackRouteId=" + binding.FeedbackRouteId +
                    "\nreadoutVisualTokenId=" + binding.ReadoutVisualTokenId);
                return;
            }

            Debug.Log(
                "OperationEncounterPlanResultBindingDebug OK" +
                "\nsessionState=Previewed/Available" +
                "\nhasPlanned=True" +
                "\nhasExecuted=False" +
                "\nisLocked=False" +
                "\nlastInteractionId=operation_action.plan" +
                "\nfeedbackRouteId=" + binding.FeedbackRouteId +
                "\nreadoutVisualTokenId=" + binding.ReadoutVisualTokenId +
                "\npresentationOk=True" +
                "\nuiBinding=operation_encounter_plan_result_binding_ready");
        }
    }
}
#endif
