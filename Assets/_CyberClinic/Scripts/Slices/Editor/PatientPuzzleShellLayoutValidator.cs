#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace CyberClinic.Slices.Editor
{
    public static class PatientPuzzleShellLayoutValidator
    {
        [MenuItem("Cyber Clinic/Slices/Run Patient Puzzle Shell Layout Debug")]
        public static void RunDebug()
        {
            var contractOk = PatientPuzzleShellLayout.HasRequiredContract();
            var rootOk = PatientPuzzleShellLayout.RootName == "PatientPuzzleShellRoot";
            var sectionNamesOk =
                PatientPuzzleShellLayout.PatientDossierAreaName == "PatientDossierArea" &&
                PatientPuzzleShellLayout.ProcedureDecisionAreaName == "ProcedureDecisionArea" &&
                PatientPuzzleShellLayout.RiskAnalysisAreaName == "RiskAnalysisArea" &&
                PatientPuzzleShellLayout.OperationResultAreaName == "OperationResultArea" &&
                PatientPuzzleShellLayout.ActionFeedbackAreaName == "ActionFeedbackArea";
            var resolutionOk = PatientPuzzleShellLayout.ReferenceResolution == new Vector2(1920f, 1080f);

            if (!contractOk || !rootOk || !sectionNamesOk || !resolutionOk)
            {
                Debug.LogWarning(
                    "PatientPuzzleShellLayoutDebug failed" +
                    "\ncontractOk=" + contractOk +
                    "\nrootOk=" + rootOk +
                    "\nsectionNamesOk=" + sectionNamesOk +
                    "\nresolutionOk=" + resolutionOk);
                return;
            }

            Debug.Log(
                "PatientPuzzleShellLayoutDebug OK" +
                "\ncontractOk=True" +
                "\nrootName=" + PatientPuzzleShellLayout.RootName +
                "\npatientAreaName=" + PatientPuzzleShellLayout.PatientDossierAreaName +
                "\nprocedureAreaName=" + PatientPuzzleShellLayout.ProcedureDecisionAreaName +
                "\nriskAreaName=" + PatientPuzzleShellLayout.RiskAnalysisAreaName +
                "\nresultAreaName=" + PatientPuzzleShellLayout.OperationResultAreaName +
                "\nfeedbackAreaName=" + PatientPuzzleShellLayout.ActionFeedbackAreaName +
                "\nreferenceResolution=1920x1080" +
                "\nuiBinding=shell_layout_contract_ready");
        }
    }
}
#endif
