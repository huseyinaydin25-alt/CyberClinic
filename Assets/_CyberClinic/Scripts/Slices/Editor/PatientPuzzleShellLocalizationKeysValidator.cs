#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace CyberClinic.Slices.Editor
{
    public static class PatientPuzzleShellLocalizationKeysValidator
    {
        [MenuItem("Cyber Clinic/Slices/Run Patient Puzzle Shell Localization Keys Debug")]
        public static void RunDebug()
        {
            var keysOk = PatientPuzzleShellLocalizationKeys.HasRequiredKeys();
            var shellOk = PatientPuzzleShellLocalizationKeys.ShellTitle == "ui.shell.patient_puzzle.title";
            var sectionOk =
                PatientPuzzleShellLocalizationKeys.PatientDossierTitle == "ui.shell.patient_dossier.title" &&
                PatientPuzzleShellLocalizationKeys.ProcedureDecisionTitle == "ui.shell.procedure_decision.title" &&
                PatientPuzzleShellLocalizationKeys.RiskAnalysisTitle == "ui.shell.risk_analysis.title" &&
                PatientPuzzleShellLocalizationKeys.OperationResultTitle == "ui.shell.operation_result.title" &&
                PatientPuzzleShellLocalizationKeys.ActionFeedbackTitle == "ui.shell.action_feedback.title";
            var placeholderOk =
                PatientPuzzleShellLocalizationKeys.PatientProfilePending == "ui.placeholder.patient_profile_pending" &&
                PatientPuzzleShellLocalizationKeys.ImplantProcedureCardsPending == "ui.placeholder.implant_procedure_cards_pending" &&
                PatientPuzzleShellLocalizationKeys.FeedbackRoutingPending == "ui.placeholder.feedback_routing_pending";

            if (!keysOk || !shellOk || !sectionOk || !placeholderOk)
            {
                Debug.LogWarning(
                    "PatientPuzzleShellLocalizationKeysDebug failed" +
                    "\nkeysOk=" + keysOk +
                    "\nshellOk=" + shellOk +
                    "\nsectionOk=" + sectionOk +
                    "\nplaceholderOk=" + placeholderOk);
                return;
            }

            Debug.Log(
                "PatientPuzzleShellLocalizationKeysDebug OK" +
                "\nkeysOk=True" +
                "\nshellTitle=" + PatientPuzzleShellLocalizationKeys.ShellTitle +
                "\npatientDossierTitle=" + PatientPuzzleShellLocalizationKeys.PatientDossierTitle +
                "\nprocedureDecisionTitle=" + PatientPuzzleShellLocalizationKeys.ProcedureDecisionTitle +
                "\nriskAnalysisTitle=" + PatientPuzzleShellLocalizationKeys.RiskAnalysisTitle +
                "\noperationResultTitle=" + PatientPuzzleShellLocalizationKeys.OperationResultTitle +
                "\nactionFeedbackTitle=" + PatientPuzzleShellLocalizationKeys.ActionFeedbackTitle +
                "\nuiBinding=shell_localization_keys_ready");
        }
    }
}
#endif
