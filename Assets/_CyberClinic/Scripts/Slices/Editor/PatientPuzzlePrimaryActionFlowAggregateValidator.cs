#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

namespace CyberClinic.Slices.Editor
{
    public static class PatientPuzzlePrimaryActionFlowAggregateValidator
    {
        [MenuItem("Cyber Clinic/Slices/Run Patient Puzzle Primary Action Flow Aggregate Debug")]
        public static void RunDebug()
        {
            var screenModel = PatientPuzzleSliceScreenModelBuilder.BuildDebugScreenModel();

            var stateModelOk = ValidateStateModel(screenModel);
            var resolverOk = ValidateResolver();
            var presenterOk = ValidatePresenter(screenModel);
            var runtimeOk = ValidateRuntime(screenModel);
            var controllerOk = ValidateController();
            var shellFlowOk = ValidateControllerShellFlow(screenModel);

            if (!stateModelOk || !resolverOk || !presenterOk || !runtimeOk || !controllerOk || !shellFlowOk)
            {
                Debug.LogWarning(
                    "PatientPuzzlePrimaryActionFlowAggregateDebug failed" +
                    "\nstateModelOk=" + stateModelOk +
                    "\nresolverOk=" + resolverOk +
                    "\npresenterOk=" + presenterOk +
                    "\nruntimeOk=" + runtimeOk +
                    "\ncontrollerOk=" + controllerOk +
                    "\nshellFlowOk=" + shellFlowOk);
                return;
            }

            Debug.Log(
                "PatientPuzzlePrimaryActionFlowAggregateDebug OK" +
                "\nstateModelOk=True" +
                "\nresolverOk=True" +
                "\npresenterOk=True" +
                "\nruntimeOk=True" +
                "\ncontrollerOk=True" +
                "\nshellFlowOk=True" +
                "\ninitialState=Available/Available" +
                "\npreviewedState=Previewed/Available" +
                "\ncommittedState=Previewed/Committed" +
                "\ndisabledState=Disabled/Disabled" +
                "\nuiBinding=primary_action_flow_aggregate_ready");
        }

        static bool ValidateStateModel(PatientPuzzleSliceScreenModel screenModel)
        {
            var defaultState = PatientPuzzlePrimaryActionState.DefaultAvailable;
            var previewedState = new PatientPuzzlePrimaryActionState(PreviewActionState.Previewed, CommitActionState.Available);
            var committedState = new PatientPuzzlePrimaryActionState(PreviewActionState.Previewed, CommitActionState.Committed);
            var disabledState = new PatientPuzzlePrimaryActionState(PreviewActionState.Disabled, CommitActionState.Disabled);
            var presentation = PatientPuzzleShellPresenter.Present(screenModel);

            return
                IsState(defaultState, PreviewActionState.Available, CommitActionState.Available) &&
                IsState(previewedState, PreviewActionState.Previewed, CommitActionState.Available) &&
                IsState(committedState, PreviewActionState.Previewed, CommitActionState.Committed) &&
                IsState(disabledState, PreviewActionState.Disabled, CommitActionState.Disabled) &&
                presentation.PrimaryActionBody.Contains("debug.previewActionState=Available") &&
                presentation.PrimaryActionBody.Contains("debug.commitActionState=Available");
        }

        static bool ValidateResolver()
        {
            var initial = PatientPuzzlePrimaryActionStateResolver.Initial();
            var afterPreview = PatientPuzzlePrimaryActionStateResolver.AfterPreview(initial);
            var afterCommit = PatientPuzzlePrimaryActionStateResolver.AfterCommit(afterPreview);
            var disabled = PatientPuzzlePrimaryActionStateResolver.Disabled();
            var previewFromDisabled = PatientPuzzlePrimaryActionStateResolver.AfterPreview(disabled);
            var commitFromDisabled = PatientPuzzlePrimaryActionStateResolver.AfterCommit(disabled);

            return
                IsState(initial, PreviewActionState.Available, CommitActionState.Available) &&
                IsState(afterPreview, PreviewActionState.Previewed, CommitActionState.Available) &&
                IsState(afterCommit, PreviewActionState.Previewed, CommitActionState.Committed) &&
                IsState(disabled, PreviewActionState.Disabled, CommitActionState.Disabled) &&
                IsState(previewFromDisabled, PreviewActionState.Disabled, CommitActionState.Disabled) &&
                IsState(commitFromDisabled, PreviewActionState.Disabled, CommitActionState.Disabled);
        }

        static bool ValidatePresenter(PatientPuzzleSliceScreenModel screenModel)
        {
            var initial = PatientPuzzlePrimaryActionStateResolver.Initial();
            var previewed = PatientPuzzlePrimaryActionStateResolver.AfterPreview(initial);
            var committed = PatientPuzzlePrimaryActionStateResolver.AfterCommit(previewed);
            var disabled = PatientPuzzlePrimaryActionStateResolver.Disabled();

            return
                PresentationHasState(PatientPuzzleShellPresenter.Present(screenModel), "Available", "Available") &&
                PresentationHasState(PatientPuzzleShellPresenter.Present(screenModel, initial), "Available", "Available") &&
                PresentationHasState(PatientPuzzleShellPresenter.Present(screenModel, previewed), "Previewed", "Available") &&
                PresentationHasState(PatientPuzzleShellPresenter.Present(screenModel, committed), "Previewed", "Committed") &&
                PresentationHasState(PatientPuzzleShellPresenter.Present(screenModel, disabled), "Disabled", "Disabled");
        }

        static bool ValidateRuntime(PatientPuzzleSliceScreenModel screenModel)
        {
            var initial = PatientPuzzlePrimaryActionStateResolver.Initial();
            var previewed = PatientPuzzlePrimaryActionStateResolver.AfterPreview(initial);
            var committed = PatientPuzzlePrimaryActionStateResolver.AfterCommit(previewed);
            var disabled = PatientPuzzlePrimaryActionStateResolver.Disabled();

            return
                RuntimeRendersState(screenModel, initial, "Available", "Available") &&
                RuntimeRendersState(screenModel, previewed, "Previewed", "Available") &&
                RuntimeRendersState(screenModel, committed, "Previewed", "Committed") &&
                RuntimeRendersState(screenModel, disabled, "Disabled", "Disabled");
        }

        static bool ValidateController()
        {
            var controller = new PatientPuzzlePrimaryActionController();
            var initial = controller.CurrentState;
            var afterPreview = controller.Preview();
            var afterCommit = controller.Commit();
            var afterDisable = controller.Disable();
            var previewAfterDisable = controller.Preview();
            var afterReset = controller.Reset();

            return
                IsState(initial, PreviewActionState.Available, CommitActionState.Available) &&
                IsState(afterPreview, PreviewActionState.Previewed, CommitActionState.Available) &&
                IsState(afterCommit, PreviewActionState.Previewed, CommitActionState.Committed) &&
                IsState(afterDisable, PreviewActionState.Disabled, CommitActionState.Disabled) &&
                IsState(previewAfterDisable, PreviewActionState.Disabled, CommitActionState.Disabled) &&
                IsState(afterReset, PreviewActionState.Available, CommitActionState.Available);
        }

        static bool ValidateControllerShellFlow(PatientPuzzleSliceScreenModel screenModel)
        {
            var controller = new PatientPuzzlePrimaryActionController();
            var initialOk = RuntimeRendersState(screenModel, controller.CurrentState, "Available", "Available");
            controller.Preview();
            var previewOk = RuntimeRendersState(screenModel, controller.CurrentState, "Previewed", "Available");
            controller.Commit();
            var commitOk = RuntimeRendersState(screenModel, controller.CurrentState, "Previewed", "Committed");
            controller.Disable();
            var disableOk = RuntimeRendersState(screenModel, controller.CurrentState, "Disabled", "Disabled");
            controller.Reset();
            var resetOk = RuntimeRendersState(screenModel, controller.CurrentState, "Available", "Available");

            return initialOk && previewOk && commitOk && disableOk && resetOk;
        }

        static bool PresentationHasState(PatientPuzzleShellPresentation presentation, string expectedPreviewState, string expectedCommitState)
        {
            return
                presentation.PrimaryActionBody.Contains("debug.previewActionState=" + expectedPreviewState) &&
                presentation.PrimaryActionBody.Contains("debug.commitActionState=" + expectedCommitState);
        }

        static bool RuntimeRendersState(
            PatientPuzzleSliceScreenModel screenModel,
            PatientPuzzlePrimaryActionState state,
            string expectedPreviewState,
            string expectedCommitState)
        {
            EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
            var host = new GameObject("PatientPuzzlePrimaryActionFlowAggregateHost");
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
