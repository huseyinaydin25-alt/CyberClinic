#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CyberClinic.Slices.Editor
{
    public static class PatientPuzzleShellEndToEndValidator
    {
        const string ScenePath = "Assets/_CyberClinic/Scenes/PatientPuzzleShell.unity";

        [MenuItem("Cyber Clinic/Slices/Run Patient Puzzle Shell End To End Debug")]
        public static void RunDebug()
        {
            var foundationOk = ValidateFoundation();
            var sceneOk = ValidateSceneSmoke(out var canvasCount, out var eventSystemCount, out var sceneName);

            if (!foundationOk || !sceneOk)
            {
                Debug.LogWarning(
                    "PatientPuzzleShellEndToEndDebug failed" +
                    "\nfoundationOk=" + foundationOk +
                    "\nsceneOk=" + sceneOk +
                    "\nscenePath=" + ScenePath +
                    "\nsceneName=" + sceneName +
                    "\ncanvasCount=" + canvasCount +
                    "\neventSystemCount=" + eventSystemCount);
                return;
            }

            Debug.Log(
                "PatientPuzzleShellEndToEndDebug OK" +
                "\nfoundationOk=True" +
                "\nsceneSmokeOk=True" +
                "\nscenePath=" + ScenePath +
                "\nsceneName=" + sceneName +
                "\ncanvasCount=" + canvasCount +
                "\neventSystemCount=" + eventSystemCount +
                "\nuiBinding=shell_end_to_end_ready");
        }

        static bool ValidateFoundation()
        {
            if (!PatientPuzzleShellLocalizationKeys.HasRequiredKeys())
            {
                return false;
            }

            if (!PatientPuzzleShellLayout.HasRequiredContract())
            {
                return false;
            }

            if (!PatientPuzzleShellStyle.HasRequiredStyle())
            {
                return false;
            }

            var screenModel = PatientPuzzleSliceScreenModelBuilder.BuildDebugScreenModel();
            var presentation = PatientPuzzleShellPresenter.Present(screenModel);
            return
                presentation.HasRequiredDebugData() &&
                presentation.PatientDossierBody.Contains("debug.patientId=test_street_netrunner") &&
                presentation.ProcedureDecisionBody.Contains("debug.selectedImplantId=test_implant_optic_tune") &&
                presentation.RiskAnalysisBody.Contains("debug.riskBand=Uncertain") &&
                presentation.OperationResultBody.Contains("debug.creditsDelta=+90") &&
                presentation.ActionFeedbackBody.Contains("debug.visualCueId=test_cue_result_reveal");
        }

        static bool ValidateSceneSmoke(out int canvasCount, out int eventSystemCount, out string sceneName)
        {
            canvasCount = 0;
            eventSystemCount = 0;
            sceneName = "<none>";

            var sceneAsset = AssetDatabase.LoadAssetAtPath<SceneAsset>(ScenePath);
            if (sceneAsset == null)
            {
                return false;
            }

            var scene = EditorSceneManager.OpenScene(ScenePath, OpenSceneMode.Single);
            sceneName = scene.name;

            var runtime = Object.FindFirstObjectByType<PatientPuzzleShellRuntime>();
            if (runtime == null)
            {
                return false;
            }

            runtime.EnsureBuiltDebugShell();

            canvasCount = Object.FindObjectsByType<Canvas>(FindObjectsSortMode.None).Length;
            eventSystemCount = Object.FindObjectsByType<EventSystem>(FindObjectsSortMode.None).Length;

            var root = GameObject.Find(PatientPuzzleShellLayout.RootName);
            var patientArea = GameObject.Find(PatientPuzzleShellLayout.PatientDossierAreaName);
            var procedureArea = GameObject.Find(PatientPuzzleShellLayout.ProcedureDecisionAreaName);
            var riskArea = GameObject.Find(PatientPuzzleShellLayout.RiskAnalysisAreaName);
            var resultArea = GameObject.Find(PatientPuzzleShellLayout.OperationResultAreaName);
            var feedbackArea = GameObject.Find(PatientPuzzleShellLayout.ActionFeedbackAreaName);

            var patientText = FindSectionText(patientArea);
            var procedureText = FindSectionText(procedureArea);
            var riskText = FindSectionText(riskArea);
            var resultText = FindSectionText(resultArea);
            var feedbackText = FindSectionText(feedbackArea);

            return
                root != null &&
                canvasCount == 1 &&
                eventSystemCount == 1 &&
                patientArea != null &&
                procedureArea != null &&
                riskArea != null &&
                resultArea != null &&
                feedbackArea != null &&
                patientText != null && patientText.text.Contains("debug.patientId=test_street_netrunner") &&
                procedureText != null && procedureText.text.Contains("debug.selectedImplantId=test_implant_optic_tune") &&
                riskText != null && riskText.text.Contains("debug.riskBand=Uncertain") &&
                resultText != null && resultText.text.Contains("debug.creditsDelta=+90") &&
                feedbackText != null && feedbackText.text.Contains("debug.visualCueId=test_cue_result_reveal");
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
