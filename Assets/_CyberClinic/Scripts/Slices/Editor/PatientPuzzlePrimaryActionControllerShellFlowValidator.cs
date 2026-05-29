#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

namespace CyberClinic.Slices.Editor
{
    public static class PatientPuzzlePrimaryActionControllerShellFlowValidator
    {
        [MenuItem("Cyber Clinic/Slices/Run Patient Puzzle Primary Action Controller Shell Flow Debug")]
        public static void RunDebug()
        {
            var screenModel = PatientPuzzleSliceScreenModelBuilder.BuildDebugScreenModel();
            var controller = new PatientPuzzlePrimaryActionController();

            var initialOk = RenderAndCheck(screenModel, controller.CurrentState, "Available", "Available");
            controller.Preview();
            var previewOk = RenderAndCheck(screenModel, controller.CurrentState, "Previewed", "Available");
            controller.Commit();
            var commitOk = RenderAndCheck(screenModel, controller.CurrentState, "Previewed", "Committed");
            controller.Disable();
            var disableOk = RenderAndCheck(screenModel, controller.CurrentState, "Disabled", "Disabled");
            controller.Reset();
            var resetOk = RenderAndCheck(screenModel, controller.CurrentState, "Available", "Available");

            if (!initialOk || !previewOk || !commitOk || !disableOk || !resetOk)
            {
                Debug.LogWarning(
                    "PatientPuzzlePrimaryActionControllerShellFlowDebug failed" +
                    "\ninitialOk=" + initialOk +
                    "\npreviewOk=" + previewOk +
                    "\ncommitOk=" + commitOk +
                    "\ndisableOk=" + disableOk +
                    "\nresetOk=" + resetOk +
                    "\ncurrentState=" + Format(controller.CurrentState));
                return;
            }

            Debug.Log(
                "PatientPuzzlePrimaryActionControllerShellFlowDebug OK" +
                "\ninitialRendered=Available/Available" +
                "\npreviewRendered=Previewed/Available" +
                "\ncommitRendered=Previewed/Committed" +
                "\ndisableRendered=Disabled/Disabled" +
                "\nresetRendered=Available/Available" +
                "\nuiBinding=primary_action_controller_shell_flow_ready");
        }

        static bool RenderAndCheck(
            PatientPuzzleSliceScreenModel screenModel,
            PatientPuzzlePrimaryActionState state,
            string expectedPreviewState,
            string expectedCommitState)
        {
            EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
            var host = new GameObject("PatientPuzzlePrimaryActionControllerShellFlowHost");
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

        static string Format(PatientPuzzlePrimaryActionState state)
        {
            return state.PreviewState + "/" + state.CommitState;
        }
    }
}
#endif
