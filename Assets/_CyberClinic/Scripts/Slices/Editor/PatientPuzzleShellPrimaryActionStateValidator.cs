#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

namespace CyberClinic.Slices.Editor
{
    public static class PatientPuzzleShellPrimaryActionStateValidator
    {
        [MenuItem("Cyber Clinic/Slices/Validate Patient Puzzle Shell Primary Action State")]
        public static void RunDebug()
        {
            var defaultState = PatientPuzzlePrimaryActionState.DefaultAvailable;
            var stateModelOk =
                defaultState.PreviewState == PreviewActionState.Available &&
                defaultState.CommitState == CommitActionState.Available;

            var presentation = PatientPuzzleShellPresenter.Present(PatientPuzzleSliceScreenModelBuilder.BuildDebugScreenModel());
            var presentationStateOk =
                presentation.HasRequiredDebugData() &&
                presentation.PrimaryActionState.PreviewState == PreviewActionState.Available &&
                presentation.PrimaryActionState.CommitState == CommitActionState.Available &&
                presentation.PrimaryActionBody.Contains("debug.previewActionState=Available") &&
                presentation.PrimaryActionBody.Contains("debug.commitActionState=Available");

            EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
            var host = new GameObject("PatientPuzzleShellPrimaryActionStateHost");
            var runtime = host.AddComponent<PatientPuzzleShellRuntime>();
            runtime.EnsureBuiltDebugShell();

            var primaryActionArea = GameObject.Find(PatientPuzzleShellLayout.PrimaryActionAreaName);
            var primaryActionText = FindSectionText(primaryActionArea);
            var runtimeStateOk =
                primaryActionText != null &&
                primaryActionText.text.Contains("debug.previewActionState=Available") &&
                primaryActionText.text.Contains("debug.commitActionState=Available");

            if (!stateModelOk || !presentationStateOk || !runtimeStateOk || primaryActionArea == null)
            {
                Debug.LogWarning(
                    "PatientPuzzleShellPrimaryActionStateDebug failed" +
                    "\nstateModelOk=" + stateModelOk +
                    "\npresentationStateOk=" + presentationStateOk +
                    "\nruntimeStateOk=" + runtimeStateOk +
                    "\nprimaryActionArea=" + (primaryActionArea != null) +
                    "\nprimaryActionText=" + SafeText(primaryActionText));
                return;
            }

            Debug.Log(
                "PatientPuzzleShellPrimaryActionStateDebug OK" +
                "\npreviewState=" + defaultState.PreviewState +
                "\ncommitState=" + defaultState.CommitState +
                "\npresentationStateOk=True" +
                "\nruntimeStateOk=True" +
                "\nprimaryActionArea=True" +
                "\nuiBinding=shell_primary_action_state_model_ready");
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

        static string SafeText(Text text)
        {
            return text == null ? "<null>" : text.text;
        }
    }
}
#endif
