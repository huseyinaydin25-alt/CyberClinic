#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

namespace CyberClinic.Slices.Editor
{
    public static class PatientPuzzlePlayableShellInteractionAggregateValidator
    {
        [MenuItem("Cyber Clinic/Slices/Run Patient Puzzle Playable Shell Interaction Aggregate Debug")]
        public static void RunDebug()
        {
            var screenModel = PatientPuzzleSliceScreenModelBuilder.BuildDebugScreenModel();

            var bridgeOk = ValidateInteractionBridge();
            var previewOk = ValidatePreviewInteraction(screenModel);
            var commitOk = ValidateCommitInteraction(screenModel);
            var readoutOk = ValidateReadout();
            var feedbackOk = ValidateFeedbackRouter();
            var runtimeSmokeOk = ValidatePreviewCommitRuntimeSmoke(screenModel);

            if (!bridgeOk || !previewOk || !commitOk || !readoutOk || !feedbackOk || !runtimeSmokeOk)
            {
                Debug.LogWarning(
                    "PatientPuzzlePlayableShellInteractionAggregateDebug failed" +
                    "\nbridgeOk=" + bridgeOk +
                    "\npreviewOk=" + previewOk +
                    "\ncommitOk=" + commitOk +
                    "\nreadoutOk=" + readoutOk +
                    "\nfeedbackOk=" + feedbackOk +
                    "\nruntimeSmokeOk=" + runtimeSmokeOk);
                return;
            }

            Debug.Log(
                "PatientPuzzlePlayableShellInteractionAggregateDebug OK" +
                "\nbridgeOk=True" +
                "\npreviewOk=True" +
                "\ncommitOk=True" +
                "\nreadoutOk=True" +
                "\nfeedbackOk=True" +
                "\nruntimeSmokeOk=True" +
                "\npreviewState=Previewed/Available" +
                "\ncommitState=Previewed/Committed" +
                "\npreviewRoute=primary_action.feedback.previewed" +
                "\ncommitRoute=primary_action.feedback.committed" +
                "\nuiBinding=playable_shell_interaction_aggregate_ready");
        }

        static bool ValidateInteractionBridge()
        {
            var bridge = new PatientPuzzlePrimaryActionInteractionBridge();
            var initial = bridge.CurrentState;
            var preview = bridge.Preview();
            var commit = bridge.Commit();
            var disabled = bridge.Disable();
            var previewAfterDisabled = bridge.Preview();
            var reset = bridge.Reset();

            return
                IsState(initial, PreviewActionState.Available, CommitActionState.Available) &&
                preview.InteractionId == "primary_action.preview" &&
                IsState(preview.State, PreviewActionState.Previewed, CommitActionState.Available) &&
                commit.InteractionId == "primary_action.commit" &&
                IsState(commit.State, PreviewActionState.Previewed, CommitActionState.Committed) &&
                disabled.InteractionId == "primary_action.disable" &&
                IsState(disabled.State, PreviewActionState.Disabled, CommitActionState.Disabled) &&
                previewAfterDisabled.InteractionId == "primary_action.preview" &&
                IsState(previewAfterDisabled.State, PreviewActionState.Disabled, CommitActionState.Disabled) &&
                reset.InteractionId == "primary_action.reset" &&
                IsState(reset.State, PreviewActionState.Available, CommitActionState.Available);
        }

        static bool ValidatePreviewInteraction(PatientPuzzleSliceScreenModel screenModel)
        {
            var result = new PatientPuzzlePreviewActionDebugInteraction(screenModel).Execute();
            return
                result.InteractionId == "primary_action.preview" &&
                IsState(result.State, PreviewActionState.Previewed, CommitActionState.Available) &&
                result.Presentation.PrimaryActionBody.Contains("debug.previewActionState=Previewed") &&
                result.Presentation.PrimaryActionBody.Contains("debug.commitActionState=Available") &&
                RuntimeRendersState(screenModel, result.State, "Previewed", "Available");
        }

        static bool ValidateCommitInteraction(PatientPuzzleSliceScreenModel screenModel)
        {
            var result = new PatientPuzzleCommitActionDebugInteraction(screenModel).Execute();
            return
                result.InteractionId == "primary_action.commit" &&
                IsState(result.State, PreviewActionState.Previewed, CommitActionState.Committed) &&
                result.Presentation.PrimaryActionBody.Contains("debug.previewActionState=Previewed") &&
                result.Presentation.PrimaryActionBody.Contains("debug.commitActionState=Committed") &&
                RuntimeRendersState(screenModel, result.State, "Previewed", "Committed");
        }

        static bool ValidateReadout()
        {
            var ready = PatientPuzzlePrimaryActionStateReadoutPresenter.Present(PatientPuzzlePrimaryActionStateResolver.Initial());
            var previewedState = PatientPuzzlePrimaryActionStateResolver.AfterPreview(PatientPuzzlePrimaryActionStateResolver.Initial());
            var previewed = PatientPuzzlePrimaryActionStateReadoutPresenter.Present(previewedState);
            var committed = PatientPuzzlePrimaryActionStateReadoutPresenter.Present(PatientPuzzlePrimaryActionStateResolver.AfterCommit(previewedState));
            var disabled = PatientPuzzlePrimaryActionStateReadoutPresenter.Present(PatientPuzzlePrimaryActionStateResolver.Disabled());

            return
                ready.VisualTokenId == "primary_action.visual.ready" &&
                ready.IsInteractive &&
                previewed.VisualTokenId == "primary_action.visual.previewed" &&
                previewed.IsInteractive &&
                committed.VisualTokenId == "primary_action.visual.committed" &&
                !committed.IsInteractive &&
                disabled.VisualTokenId == "primary_action.visual.disabled" &&
                !disabled.IsInteractive;
        }

        static bool ValidateFeedbackRouter()
        {
            var ready = PatientPuzzlePrimaryActionFeedbackRouter.Route(PatientPuzzlePrimaryActionStateResolver.Initial());
            var previewedState = PatientPuzzlePrimaryActionStateResolver.AfterPreview(PatientPuzzlePrimaryActionStateResolver.Initial());
            var previewed = PatientPuzzlePrimaryActionFeedbackRouter.Route(previewedState);
            var committed = PatientPuzzlePrimaryActionFeedbackRouter.Route(PatientPuzzlePrimaryActionStateResolver.AfterCommit(previewedState));
            var disabled = PatientPuzzlePrimaryActionFeedbackRouter.Route(PatientPuzzlePrimaryActionStateResolver.Disabled());

            return
                ready.RouteId == "primary_action.feedback.ready" &&
                ready.ReadoutVisualTokenId == "primary_action.visual.ready" &&
                previewed.RouteId == "primary_action.feedback.previewed" &&
                previewed.ReadoutVisualTokenId == "primary_action.visual.previewed" &&
                committed.RouteId == "primary_action.feedback.committed" &&
                committed.ReadoutVisualTokenId == "primary_action.visual.committed" &&
                disabled.RouteId == "primary_action.feedback.disabled" &&
                disabled.ReadoutVisualTokenId == "primary_action.visual.disabled";
        }

        static bool ValidatePreviewCommitRuntimeSmoke(PatientPuzzleSliceScreenModel screenModel)
        {
            var previewInteraction = new PatientPuzzlePreviewActionDebugInteraction(screenModel).Execute();
            var commitInteraction = new PatientPuzzleCommitActionDebugInteraction(screenModel).Execute();
            var previewRoute = PatientPuzzlePrimaryActionFeedbackRouter.Route(previewInteraction.State);
            var commitRoute = PatientPuzzlePrimaryActionFeedbackRouter.Route(commitInteraction.State);

            return
                previewInteraction.InteractionId == "primary_action.preview" &&
                IsState(previewInteraction.State, PreviewActionState.Previewed, CommitActionState.Available) &&
                previewRoute.RouteId == "primary_action.feedback.previewed" &&
                previewRoute.ReadoutVisualTokenId == "primary_action.visual.previewed" &&
                RuntimeRendersState(screenModel, previewInteraction.State, "Previewed", "Available") &&
                commitInteraction.InteractionId == "primary_action.commit" &&
                IsState(commitInteraction.State, PreviewActionState.Previewed, CommitActionState.Committed) &&
                commitRoute.RouteId == "primary_action.feedback.committed" &&
                commitRoute.ReadoutVisualTokenId == "primary_action.visual.committed" &&
                RuntimeRendersState(screenModel, commitInteraction.State, "Previewed", "Committed");
        }

        static bool RuntimeRendersState(
            PatientPuzzleSliceScreenModel screenModel,
            PatientPuzzlePrimaryActionState state,
            string expectedPreviewState,
            string expectedCommitState)
        {
            EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
            var host = new GameObject("PatientPuzzlePlayableShellInteractionAggregateHost");
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

        static bool IsState(PatientPuzzlePrimaryActionState state, PreviewActionState preview, CommitActionState commit)
        {
            return state.PreviewState == preview && state.CommitState == commit;
        }
    }
}
#endif
