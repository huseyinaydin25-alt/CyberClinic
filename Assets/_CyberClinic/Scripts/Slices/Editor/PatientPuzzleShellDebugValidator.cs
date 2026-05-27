#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CyberClinic.Slices.Editor
{
    public static class PatientPuzzleShellDebugValidator
    {
        [MenuItem("Cyber Clinic/Slices/Run Patient Puzzle Shell Debug")]
        public static void RunDebug()
        {
            EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);

            var host = new GameObject("PatientPuzzleShellDebugHost");
            var runtime = host.AddComponent<PatientPuzzleShellRuntime>();
            runtime.EnsureBuiltDebugShell();

            var root = GameObject.Find("PatientPuzzleShellRoot");
            var patientArea = GameObject.Find("PatientDossierArea");
            var procedureArea = GameObject.Find("ProcedureDecisionArea");
            var riskArea = GameObject.Find("RiskAnalysisArea");
            var resultArea = GameObject.Find("OperationResultArea");
            var feedbackArea = GameObject.Find("ActionFeedbackArea");

            var patientText = FindSectionText(patientArea);
            var procedureText = FindSectionText(procedureArea);
            var riskText = FindSectionText(riskArea);
            var resultText = FindSectionText(resultArea);
            var feedbackText = FindSectionText(feedbackArea);

            var rootOk = root != null;
            var canvasCount = Object.FindObjectsByType<Canvas>(FindObjectsSortMode.None).Length;
            var eventSystemCount = Object.FindObjectsByType<EventSystem>(FindObjectsSortMode.None).Length;
            var sectionsOk = patientArea != null && procedureArea != null && riskArea != null && resultArea != null && feedbackArea != null;
            var patientOk = patientText != null && patientText.text.Contains("debug.patientId=test_street_netrunner") && patientText.text.Contains("debug.patientSeed=82115621");
            var procedureOk = procedureText != null && procedureText.text.Contains("debug.selectedImplantId=test_implant_optic_tune") && procedureText.text.Contains("debug.selectedProcedureId=test_proc_micro_install");
            var riskOk = riskText != null && riskText.text.Contains("debug.riskBand=Uncertain") && riskText.text.Contains("debug.outcomeType=StableSuccess");
            var resultOk = resultText != null && resultText.text.Contains("debug.creditsDelta=+90") && resultText.text.Contains("debug.reputationDelta=+5");
            var feedbackOk = feedbackText != null && feedbackText.text.Contains("debug.visualCueId=test_cue_result_reveal") && feedbackText.text.Contains("debug.audioCueId=test_audio_operation_success");

            if (!rootOk || canvasCount != 1 || eventSystemCount != 1 || !sectionsOk || !patientOk || !procedureOk || !riskOk || !resultOk || !feedbackOk)
            {
                Debug.LogWarning(
                    "PatientPuzzleShellDebug failed" +
                    "\nrootOk=" + rootOk +
                    "\ncanvasCount=" + canvasCount +
                    "\neventSystemCount=" + eventSystemCount +
                    "\nsectionsOk=" + sectionsOk +
                    "\npatientOk=" + patientOk +
                    "\nprocedureOk=" + procedureOk +
                    "\nriskOk=" + riskOk +
                    "\nresultOk=" + resultOk +
                    "\nfeedbackOk=" + feedbackOk +
                    "\npatientText=" + SafeText(patientText) +
                    "\nprocedureText=" + SafeText(procedureText) +
                    "\nriskText=" + SafeText(riskText) +
                    "\nresultText=" + SafeText(resultText) +
                    "\nfeedbackText=" + SafeText(feedbackText));
                return;
            }

            Debug.Log(
                "PatientPuzzleShellDebug OK" +
                "\nrootExists=True" +
                "\ncanvasCount=" + canvasCount +
                "\neventSystemCount=" + eventSystemCount +
                "\npatientArea=True" +
                "\nprocedureArea=True" +
                "\nriskArea=True" +
                "\nresultArea=True" +
                "\nfeedbackArea=True" +
                "\npatientBinding=True" +
                "\nprocedureBinding=True" +
                "\nriskBinding=True" +
                "\nresultBinding=True" +
                "\nfeedbackBinding=True" +
                "\nuiBinding=production_intent_shell_placeholder");
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
