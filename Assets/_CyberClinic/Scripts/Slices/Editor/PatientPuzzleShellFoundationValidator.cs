#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CyberClinic.Slices.Editor
{
    public static class PatientPuzzleShellFoundationValidator
    {
        [MenuItem("Cyber Clinic/Slices/Run Patient Puzzle Shell Foundation Debug")]
        public static void RunDebug()
        {
            var localizationOk = PatientPuzzleShellLocalizationKeys.HasRequiredKeys();
            var layoutOk = PatientPuzzleShellLayout.HasRequiredContract();
            var styleOk = PatientPuzzleShellStyle.HasRequiredStyle();

            var screenModel = PatientPuzzleSliceScreenModelBuilder.BuildDebugScreenModel();
            var presentation = PatientPuzzleShellPresenter.Present(screenModel);
            var presenterOk =
                presentation.HasRequiredDebugData() &&
                presentation.PatientDossierBody.Contains("debug.patientId=test_street_netrunner") &&
                presentation.ProcedureDecisionBody.Contains("debug.selectedImplantId=test_implant_optic_tune") &&
                presentation.RiskAnalysisBody.Contains("debug.riskBand=Uncertain") &&
                presentation.OperationResultBody.Contains("debug.creditsDelta=+90") &&
                presentation.ActionFeedbackBody.Contains("debug.visualCueId=test_cue_result_reveal") &&
                presentation.PrimaryActionBody.Contains("debug.previewActionState=available") &&
                presentation.PrimaryActionBody.Contains("debug.commitActionState=available");

            EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
            var host = new GameObject("PatientPuzzleShellFoundationHost");
            var runtime = host.AddComponent<PatientPuzzleShellRuntime>();
            runtime.EnsureBuiltDebugShell();

            var root = GameObject.Find(PatientPuzzleShellLayout.RootName);
            var canvasCount = Object.FindObjectsByType<Canvas>(FindObjectsSortMode.None).Length;
            var eventSystemCount = Object.FindObjectsByType<EventSystem>(FindObjectsSortMode.None).Length;
            var runtimeOk =
                root != null &&
                canvasCount == 1 &&
                eventSystemCount == 1 &&
                GameObject.Find(PatientPuzzleShellLayout.PatientDossierAreaName) != null &&
                GameObject.Find(PatientPuzzleShellLayout.ProcedureDecisionAreaName) != null &&
                GameObject.Find(PatientPuzzleShellLayout.RiskAnalysisAreaName) != null &&
                GameObject.Find(PatientPuzzleShellLayout.OperationResultAreaName) != null &&
                GameObject.Find(PatientPuzzleShellLayout.ActionFeedbackAreaName) != null &&
                GameObject.Find(PatientPuzzleShellLayout.PrimaryActionAreaName) != null;

            if (!localizationOk || !layoutOk || !styleOk || !presenterOk || !runtimeOk)
            {
                Debug.LogWarning(
                    "PatientPuzzleShellFoundationDebug failed" +
                    "\nlocalizationOk=" + localizationOk +
                    "\nlayoutOk=" + layoutOk +
                    "\nstyleOk=" + styleOk +
                    "\npresenterOk=" + presenterOk +
                    "\nruntimeOk=" + runtimeOk +
                    "\ncanvasCount=" + canvasCount +
                    "\neventSystemCount=" + eventSystemCount);
                return;
            }

            Debug.Log(
                "PatientPuzzleShellFoundationDebug OK" +
                "\nlocalizationOk=True" +
                "\nlayoutOk=True" +
                "\nstyleOk=True" +
                "\npresenterOk=True" +
                "\nruntimeOk=True" +
                "\nprimaryActionIncluded=True" +
                "\ncanvasCount=" + canvasCount +
                "\neventSystemCount=" + eventSystemCount +
                "\nuiBinding=shell_foundation_aggregate_ready");
        }
    }
}
#endif
