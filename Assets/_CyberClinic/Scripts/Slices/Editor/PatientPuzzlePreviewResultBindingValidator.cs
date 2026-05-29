#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace CyberClinic.Slices.Editor
{
    public static class PatientPuzzlePreviewResultBindingValidator
    {
        [MenuItem("Cyber Clinic/Slices/Run Patient Puzzle Preview Result Binding Debug")]
        public static void RunDebug()
        {
            var screenModel = PatientPuzzleSliceScreenModelBuilder.BuildDebugScreenModel();
            var controller = new PatientPuzzleSessionController(screenModel);
            var afterPreview = controller.Preview();
            var binding = PatientPuzzlePreviewResultBinder.Bind(afterPreview);

            var sessionOk =
                binding.SessionState.HasPreviewed &&
                !binding.SessionState.HasCommitted &&
                !binding.SessionState.IsLocked &&
                binding.SessionState.LastInteractionId == "primary_action.preview" &&
                binding.SessionState.PrimaryActionState.PreviewState == PreviewActionState.Previewed &&
                binding.SessionState.PrimaryActionState.CommitState == CommitActionState.Available;

            var feedbackOk =
                binding.FeedbackRouteId == "primary_action.feedback.previewed" &&
                binding.ReadoutVisualTokenId == "primary_action.visual.previewed";

            var presentationOk =
                binding.Presentation.HasPrimaryActionState(binding.SessionState.PrimaryActionState) &&
                binding.Presentation.PrimaryActionBody.Contains("debug.previewActionState=Previewed") &&
                binding.Presentation.PrimaryActionBody.Contains("debug.commitActionState=Available");

            if (!sessionOk || !feedbackOk || !presentationOk)
            {
                Debug.LogWarning(
                    "PatientPuzzlePreviewResultBindingDebug failed" +
                    "\nsessionOk=" + sessionOk +
                    "\nfeedbackOk=" + feedbackOk +
                    "\npresentationOk=" + presentationOk +
                    "\nfeedbackRouteId=" + binding.FeedbackRouteId +
                    "\nreadoutVisualTokenId=" + binding.ReadoutVisualTokenId);
                return;
            }

            Debug.Log(
                "PatientPuzzlePreviewResultBindingDebug OK" +
                "\nsessionState=Previewed/Available" +
                "\nhasPreviewed=True" +
                "\nhasCommitted=False" +
                "\nisLocked=False" +
                "\nlastInteractionId=primary_action.preview" +
                "\nfeedbackRouteId=" + binding.FeedbackRouteId +
                "\nreadoutVisualTokenId=" + binding.ReadoutVisualTokenId +
                "\npresentationOk=True" +
                "\nuiBinding=preview_result_binding_ready");
        }
    }
}
#endif
