#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

namespace CyberClinic.Slices.Editor
{
    public static class PatientPuzzleShellPrimaryActionValidator
    {
        [MenuItem("Cyber Clinic/Slices/Run Patient Puzzle Shell Primary Action Debug")]
        public static void RunDebug()
        {
            var keysOk =
                PatientPuzzleShellLocalizationKeys.HasRequiredKeys() &&
                PatientPuzzleShellLocalizationKeys.PrimaryActionTitle == "ui.shell.primary_action.title" &&
                PatientPuzzleShellLocalizationKeys.PreviewActionPlaceholder == "ui.placeholder.preview_action_state_pending" &&
                PatientPuzzleShellLocalizationKeys.CommitActionPlaceholder == "ui.placeholder.commit_action_state_pending";

            var layoutOk =
                PatientPuzzleShellLayout.HasRequiredContract() &&
                PatientPuzzleShellLayout.PrimaryActionAreaName == "PrimaryActionArea";

            var presentation = PatientPuzzleShellPresenter.Present(PatientPuzzleSliceScreenModelBuilder.BuildDebugScreenModel());
            var presentationOk =
                presentation.HasRequiredDebugData() &&
                presentation.PrimaryActionBody.Contains("debug.previewActionState=available") &&
                presentation.PrimaryActionBody.Contains("debug.commitActionState=available") &&
                presentation.PrimaryActionBody.Contains("debug.previewSuccessChance=0.675") &&
                presentation.PrimaryActionBody.Contains("debug.commitSuccessChance=0.690");

            EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
            var host = new GameObject("PatientPuzzleShellPrimaryActionHost");
            var runtime = host.AddComponent<PatientPuzzleShellRuntime>();
            runtime.EnsureBuiltDebugShell();

            var primaryActionArea = GameObject.Find(PatientPuzzleShellLayout.PrimaryActionAreaName);
            var primaryActionText = FindSectionText(primaryActionArea);
            var runtimeOk =
                primaryActionArea != null &&
                primaryActionText != null &&
                primaryActionText.text.Contains("debug.previewActionState=available") &&
                primaryActionText.text.Contains("debug.commitActionState=available");

            if (!keysOk || !layoutOk || !presentationOk || !runtimeOk)
            {
                Debug.LogWarning(
                    "PatientPuzzleShellPrimaryActionDebug failed" +
                    "\nkeysOk=" + keysOk +
                    "\nlayoutOk=" + layoutOk +
                    "\npresentationOk=" + presentationOk +
                    "\nruntimeOk=" + runtimeOk +
                    "\nprimaryActionText=" + SafeText(primaryActionText));
                return;
            }

            Debug.Log(
                "PatientPuzzleShellPrimaryActionDebug OK" +
                "\nkeysOk=True" +
                "\nlayoutOk=True" +
                "\npresentationOk=True" +
                "\nruntimeOk=True" +
                "\nprimaryActionArea=True" +
                "\npreviewActionState=available" +
                "\ncommitActionState=available" +
                "\nuiBinding=shell_primary_action_placeholder_ready");
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
