using UnityEngine;
using UnityEngine.UI;

namespace CyberClinic.Slices
{
    public sealed class PatientPuzzleSliceDebugController : MonoBehaviour
    {
        [SerializeField] Text _patientText;
        [SerializeField] Text _implantText;
        [SerializeField] Text _riskText;
        [SerializeField] Text _resultText;

        PatientPuzzleSliceReport _lastReport;

        void Start()
        {
            RefreshPreview();
        }

        public void RefreshPreview()
        {
            _lastReport = PatientPuzzleSliceRunner.RunDebugSlice();
            ApplyReport("preview.ready");
        }

        public void CommitSlice()
        {
            _lastReport = PatientPuzzleSliceRunner.RunDebugSlice();
            ApplyReport("commit.done");
        }

        void ApplyReport(string stateId)
        {
            if (_lastReport == null)
            {
                SetText(_resultText, "slice.error.no_report");
                return;
            }

            SetText(_patientText,
                "patientId=" + _lastReport.PatientId + "\n" +
                "patientSeed=" + _lastReport.PatientSeed);

            SetText(_implantText,
                "selectedImplantId=" + _lastReport.SelectedImplantId + "\n" +
                "selectedProcedureId=" + _lastReport.SelectedProcedureId);

            SetText(_riskText,
                "previewSuccessChance=" + _lastReport.PreviewSuccessChance.ToString("F3") + "\n" +
                "commitSuccessChance=" + _lastReport.CommitSuccessChance.ToString("F3") + "\n" +
                "riskBand=" + _lastReport.RiskBand + "\n" +
                "outcomeType=" + _lastReport.OutcomeType);

            SetText(_resultText,
                "stateId=" + stateId + "\n" +
                "startingCredits=" + _lastReport.StartingCredits + "\n" +
                "endingCredits=" + _lastReport.EndingCredits + "\n" +
                "startingReputation=" + _lastReport.StartingReputation + "\n" +
                "endingReputation=" + _lastReport.EndingReputation + "\n" +
                "visualCueId=" + _lastReport.VisualCueId + "\n" +
                "audioCueId=" + _lastReport.AudioCueId + "\n" +
                "saveSummary=" + _lastReport.SaveSummary);
        }

        static void SetText(Text target, string value)
        {
            if (target != null)
            {
                target.text = value;
            }
        }
    }
}
