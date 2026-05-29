#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

namespace CyberClinic.Slices.Editor
{
    public static class PatientPuzzlePreviewCommitRuntimeSmokeValidator
    {
        [MenuItem("Cyber Clinic/Slices/Run Patient Puzzle Preview Commit Runtime Smoke Test")]
        public static void RunSmokeTest()
        {
            var screenModel = PatientPuzzleSliceScreenModelBuilder.BuildDebugScreenModel();

            var previewInteraction = new PatientPuzzlePreviewActionDebugInteraction(screenModel).Execute();
            var commitInteraction = new PatientPuzzleCommitActionDebugInteraction(screenModel).Execute();

            var previewRuntimeOk = RuntimeRendersState(
                screenModel,
                previewInteraction.State,
                "Previewed",
                "Available");
            var commitRuntimeOk = RuntimeRendersState(
                screenModel,
                commitInteraction.State,
                "Previewed",
                "Committed");

            var previewRoute = PatientPuzzlePrimaryActionFeedbackRouter.Route(previewInteraction.State);
            var commitRoute = PatientPuzzlePrimaryActionFeedbackRouter.Route(commitInteraction.State);

            var previewOk =
                previewInteraction.InteractionId == "primary_action.preview" &&
                previewInteraction.State.PreviewState == PreviewActionState.Previewed &&
                previewInteraction.State.CommitState == CommitActionState.Available &&
                previewInteraction.Presentation.PrimaryActionBody.Contains("debug.previewActionState=Previewed") &&
                previewInteraction.Presentation.PrimaryActionBody.Contains("debug.commitActionState=Available") &&
                previewRoute.RouteId == "primary_action.feedback.previewed" &&
                previewRoute.ReadoutVisualTokenId == "primary_action.visual.previewed" &&
                previewRuntimeOk;

            var commitOk =
                commitInteraction.InteractionId == "primary_action.commit" &&
                commitInteraction.State.PreviewState == PreviewActionState.Previewed &&
                commitInteraction.State.CommitState == CommitActionState.Committed &&
                commitInteraction.Presentation.PrimaryActionBody.Contains("debug.previewActionState=Previewed") &&
                commitInteraction.Presentation.PrimaryActionBody.Contains("debug.commitActionState=Committed") &&
                commitRoute.RouteId == "primary_action.feedback.committed" &&
                commitRoute.ReadoutVisualTokenId == "primary_action.visual.committed" &&
                commitRuntimeOk;

            if (!previewOk || !commitOk)
            {
                Debug.LogWarning(
                    "PatientPuzzlePreviewCommitRuntimeSmoke failed" +
                    "\npreviewOk=" + previewOk +
                    "\ncommitOk=" + commitOk +
                    "\npreviewRuntimeOk=" + previewRuntimeOk +
                    "\ncommitRuntimeOk=" + commitRuntimeOk +
                    "\npreviewInteractionId=" + previewInteraction.InteractionId +
                    "\ncommitInteractionId=" + commitInteraction.InteractionId +
                    "\npreviewRoute=" + previewRoute.RouteId +
                    "\ncommitRoute=" + commitRoute.RouteId +
                    "\npreviewToken=" + previewRoute.ReadoutVisualTokenId +
                    "\ncommitToken=" + commitRoute.ReadoutVisualTokenId);
                return;
            }

            Debug.Log(
                "PatientPuzzlePreviewCommitRuntimeSmoke OK" +
                "\npreviewInteractionId=" + previewInteraction.InteractionId +
                "\npreviewState=Previewed/Available" +
                "\npreviewRoute=" + previewRoute.RouteId +
                "\npreviewToken=" + previewRoute.ReadoutVisualTokenId +
                "\npreviewRuntimeOk=True" +
                "\ncommitInteractionId=" + commitInteraction.InteractionId +
                "\ncommitState=Previewed/Committed" +
                "\ncommitRoute=" + commitRoute.RouteId +
                "\ncommitToken=" + commitRoute.ReadoutVisualTokenId +
                "\ncommitRuntimeOk=True" +
                "\nuiBinding=preview_commit_runtime_smoke_ready");
        }

        static bool RuntimeRendersState(
            PatientPuzzleSliceScreenModel screenModel,
            PatientPuzzlePrimaryActionState state,
            string expectedPreviewState,
            string expectedCommitState)
        {
            EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
            var host = new GameObject("PatientPuzzlePreviewCommitRuntimeSmokeHost");
            var runtime = host.AddComponent<PatientPuzzleShellRuntime>();
            runtime.BuildShell(screenModel, state);

            var primaryActionArea = GameObject.Find(PatientPuzzleShellLayout.PrimaryActionAreaName);
            var primaryActionText = FindSectionText(primaryActionArea);
            return
                primaryActionArea != null &&
                primaryActionText != null &&
                primaryActionText.text.Contains("debug.previewActionState=" + expectedPreviewState) &&
                primaryActionText.text.Contains("debug.commitActionState=" + expectedCommitState);
        }

        static Text FindSectionText(GameObject section)
        {
            if (section == null)
            {
                return null;
            }

            var texts = section.GetComponentsInChildren<Text>();
            for (int i = 0; i < texts.Length; i++)
            {
                if (texts[i].text.StartsWith("debug."))
                {
                    return texts[i];
                }
            }

            return null;
        }
    }
}
#endif
