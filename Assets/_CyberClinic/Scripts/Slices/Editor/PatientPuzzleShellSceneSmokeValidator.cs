#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CyberClinic.Slices.Editor
{
    public static class PatientPuzzleShellSceneSmokeValidator
    {
        const string ScenePath = "Assets/_CyberClinic/Scenes/PatientPuzzleShell.unity";

        [MenuItem("Cyber Clinic/Slices/Run Patient Puzzle Shell Scene Smoke Test")]
        public static void RunSmokeTest()
        {
            var sceneAsset = AssetDatabase.LoadAssetAtPath<SceneAsset>(ScenePath);
            if (sceneAsset == null)
            {
                Debug.LogWarning("PatientPuzzleShellSceneSmoke failed\nscenePath=" + ScenePath + "\nsceneAssetExists=False");
                return;
            }

            var scene = EditorSceneManager.OpenScene(ScenePath, OpenSceneMode.Single);
            var runtime = Object.FindFirstObjectByType<PatientPuzzleShellRuntime>();
            if (runtime == null)
            {
                Debug.LogWarning("PatientPuzzleShellSceneSmoke failed\nscenePath=" + ScenePath + "\nruntimeExists=False");
                return;
            }

            runtime.EnsureBuiltDebugShell();

            var root = GameObject.Find(PatientPuzzleShellLayout.RootName);
            var patientArea = GameObject.Find(PatientPuzzleShellLayout.PatientDossierAreaName);
            var procedureArea = GameObject.Find(PatientPuzzleShellLayout.ProcedureDecisionAreaName);
            var riskArea = GameObject.Find(PatientPuzzleShellLayout.RiskAnalysisAreaName);
            var resultArea = GameObject.Find(PatientPuzzleShellLayout.OperationResultAreaName);
            var feedbackArea = GameObject.Find(PatientPuzzleShellLayout.ActionFeedbackAreaName);
            var primaryActionArea = GameObject.Find(PatientPuzzleShellLayout.PrimaryActionAreaName);

            var patientText = FindSectionText(patientArea);
            var procedureText = FindSectionText(procedureArea);
            var riskText = FindSectionText(riskArea);
            var resultText = FindSectionText(resultArea);
            var feedbackText = FindSectionText(feedbackArea);
            var primaryActionText = FindSectionText(primaryActionArea);

            var canvasCount = Object.FindObjectsByType<Canvas>(FindObjectsSortMode.None).Length;
            var eventSystemCount = Object.FindObjectsByType<EventSystem>(FindObjectsSortMode.None).Length;
            var rootOk = root != null;
            var sectionsOk = patientArea != null && procedureArea != null && riskArea != null && resultArea != null && feedbackArea != null && primaryActionArea != null;
            var bindingOk =
                patientText != null && patientText.text.Contains("debug.patientId=test_street_netrunner") &&
                procedureText != null && procedureText.text.Contains("debug.selectedImplantId=test_implant_optic_tune") &&
                riskText != null && riskText.text.Contains("debug.riskBand=Uncertain") &&
                resultText != null && resultText.text.Contains("debug.creditsDelta=+90") &&
                feedbackText != null && feedbackText.text.Contains("debug.visualCueId=test_cue_result_reveal") &&
                primaryActionText != null && primaryActionText.text.Contains("debug.previewActionState=available");

            if (!rootOk || canvasCount != 1 || eventSystemCount != 1 || !sectionsOk || !bindingOk)
            {
                Debug.LogWarning(
                    "PatientPuzzleShellSceneSmoke failed" +
                    "\nscenePath=" + ScenePath +
                    "\nrootOk=" + rootOk +
                    "\ncanvasCount=" + canvasCount +
                    "\neventSystemCount=" + eventSystemCount +
                    "\nsectionsOk=" + sectionsOk +
                    "\nbindingOk=" + bindingOk +
                    "\npatientText=" + SafeText(patientText) +
                    "\nprocedureText=" + SafeText(procedureText) +
                    "\nriskText=" + SafeText(riskText) +
                    "\nresultText=" + SafeText(resultText) +
                    "\nfeedbackText=" + SafeText(feedbackText) +
                    "\nprimaryActionText=" + SafeText(primaryActionText));
                return;
            }

            Debug.Log(
                "PatientPuzzleShellSceneSmoke OK" +
                "\nscenePath=" + ScenePath +
                "\nsceneName=" + scene.name +
                "\nruntimeExists=True" +
                "\nrootExists=True" +
                "\ncanvasCount=" + canvasCount +
                "\neventSystemCount=" + eventSystemCount +
                "\nsectionsOk=True" +
                "\nprimaryActionIncluded=True" +
                "\nbindingOk=True" +
                "\nuiBinding=shell_scene_smoke_ready");
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
