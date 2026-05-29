#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

namespace CyberClinic.Slices.Editor
{
    public static class PatientPuzzleShellRuntimeStateValidator
    {
        [MenuItem("Cyber Clinic/Slices/Run Patient Puzzle Shell Runtime State Debug")]
        public static void RunDebug()
        {
            var screenModel = PatientPuzzleSliceScreenModelBuilder.BuildDebugScreenModel();
            var initialOk = BuildAndCheck(screenModel, PatientPuzzlePrimaryActionStateResolver.Initial(), "Available", "Available");
            var previewedOk = BuildAndCheck(screenModel, PatientPuzzlePrimaryActionStateResolver.AfterPreview(PatientPuzzlePrimaryActionStateResolver.Initial()), "Previewed", "Available");
            var committedOk = BuildAndCheck(screenModel, PatientPuzzlePrimaryActionStateResolver.AfterCommit(PatientPuzzlePrimaryActionStateResolver.AfterPreview(PatientPuzzlePrimaryActionStateResolver.Initial())), "Previewed", "Committed");
            var disabledOk = BuildAndCheck(screenModel, PatientPuzzlePrimaryActionStateResolver.Disabled(), "Disabled", "Disabled");

            if (!initialOk || !previewedOk || !committedOk || !disabledOk)
            {
                Debug.LogWarning(
                    "PatientPuzzleShellRuntimeStateDebug failed" +
                    "\ninitialOk=" + initialOk +
                    "\npreviewedOk=" + previewedOk +
                    "\ncommittedOk=" + committedOk +
                    "\ndisabledOk=" + disabledOk);
                return;
            }

            Debug.Log(
                "PatientPuzzleShellRuntimeStateDebug OK" +
                "\ninitialState=Available/Available" +
                "\npreviewedState=Previewed/Available" +
                "\ncommittedState=Previewed/Committed" +
                "\ndisabledState=Disabled/Disabled" +
                "\nuiBinding=shell_runtime_state_aware_ready");
        }

        static bool BuildAndCheck(
            PatientPuzzleSliceScreenModel screenModel,
            PatientPuzzlePrimaryActionState state,
            string expectedPreviewState,
            string expectedCommitState)
        {
            EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
            var host = new GameObject("PatientPuzzleShellRuntimeStateHost");
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
