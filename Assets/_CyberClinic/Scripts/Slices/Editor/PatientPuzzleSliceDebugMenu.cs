#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace CyberClinic.Slices.Editor
{
    public static class PatientPuzzleSliceDebugMenu
    {
        [MenuItem("Cyber Clinic/Slices/Run Patient Puzzle Slice Debug")]
        public static void RunPatientPuzzleSliceDebug()
        {
            var report = PatientPuzzleSliceRunner.RunDebugSlice();

            var valid =
                report != null &&
                report.PatientSeed == 82115621 &&
                report.PatientId == "test_street_netrunner" &&
                report.SelectedImplantId == "test_implant_optic_tune" &&
                report.SelectedProcedureId == "test_proc_micro_install" &&
                report.StartingCredits == 500 &&
                report.EndingCredits == 590 &&
                report.StartingReputation == 40 &&
                report.EndingReputation == 45 &&
                report.VisualCueId == "test_cue_result_reveal" &&
                report.AudioCueId == "test_audio_operation_success";

            if (!valid)
            {
                Debug.LogWarning("PatientPuzzleSliceDebug failed");
                return;
            }

            Debug.Log(
                "PatientPuzzleSliceDebug OK\n" +
                $"patientId={report.PatientId}\n" +
                $"patientSeed={report.PatientSeed}\n" +
                $"selectedImplantId={report.SelectedImplantId}\n" +
                $"selectedProcedureId={report.SelectedProcedureId}\n" +
                $"previewSuccessChance={report.PreviewSuccessChance:F3}\n" +
                $"commitSuccessChance={report.CommitSuccessChance:F3}\n" +
                $"riskBand={report.RiskBand}\n" +
                $"outcomeType={report.OutcomeType}\n" +
                $"startingCredits={report.StartingCredits}\n" +
                $"endingCredits={report.EndingCredits}\n" +
                $"startingReputation={report.StartingReputation}\n" +
                $"endingReputation={report.EndingReputation}\n" +
                $"visualCueId={report.VisualCueId}\n" +
                $"audioCueId={report.AudioCueId}\n" +
                $"saveSummary={report.SaveSummary}");
        }
    }
}
#endif
