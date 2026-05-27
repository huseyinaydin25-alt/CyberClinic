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
        [SerializeField] Button _previewButton;
        [SerializeField] Button _commitButton;
        [SerializeField] bool _showGuiFallback;

        PatientPuzzleSliceReport _lastReport;
        string _stateId = "preview.ready";

        void Start()
        {
            BindButtons();
            RefreshPreview();
        }

        void OnDestroy()
        {
            if (_previewButton != null)
            {
                _previewButton.onClick.RemoveListener(RefreshPreview);
            }

            if (_commitButton != null)
            {
                _commitButton.onClick.RemoveListener(CommitSlice);
            }
        }

        void OnGUI()
        {
            if (!_showGuiFallback)
            {
                return;
            }

            GUI.Label(new Rect(24, 16, 520, 28), "Cyber Clinic - Playable Slice Debug");

            if (GUI.Button(new Rect(24, 52, 180, 44), "ui.slice.preview.button"))
            {
                RefreshPreview();
            }

            if (GUI.Button(new Rect(220, 52, 180, 44), "ui.slice.commit.button"))
            {
                CommitSlice();
            }

            GUI.TextArea(new Rect(24, 112, 560, 180), BuildBlockA());
            GUI.TextArea(new Rect(24, 308, 560, 260), BuildBlockB());
        }

        public void RefreshPreview()
        {
            _stateId = "preview.ready";
            _lastReport = PatientPuzzleSliceRunner.RunDebugSlice();
            ApplyReport(_stateId);
        }

        public void CommitSlice()
        {
            _stateId = "commit.done";
            _lastReport = PatientPuzzleSliceRunner.RunDebugSlice();
            ApplyReport(_stateId);
        }

        void BindButtons()
        {
            if (_previewButton != null)
            {
                _previewButton.onClick.RemoveListener(RefreshPreview);
                _previewButton.onClick.AddListener(RefreshPreview);
            }

            if (_commitButton != null)
            {
                _commitButton.onClick.RemoveListener(CommitSlice);
                _commitButton.onClick.AddListener(CommitSlice);
            }
        }

        string BuildBlockA()
        {
            if (_lastReport == null)
            {
                return "slice.pending";
            }

            return
                "stateId=" + _stateId + "\n" +
                "patientId=" + _lastReport.PatientId + "\n" +
                "patientSeed=" + _lastReport.PatientSeed + "\n" +
                "selectedImplantId=" + _lastReport.SelectedImplantId + "\n" +
                "selectedProcedureId=" + _lastReport.SelectedProcedureId;
        }

        string BuildBlockB()
        {
            if (_lastReport == null)
            {
                return "slice.pending";
            }

            return
                "previewSuccessChance=" + _lastReport.PreviewSuccessChance.ToString("F3") + "\n" +
                "commitSuccessChance=" + _lastReport.CommitSuccessChance.ToString("F3") + "\n" +
                "riskBand=" + _lastReport.RiskBand + "\n" +
                "outcomeType=" + _lastReport.OutcomeType + "\n" +
                "startingCredits=" + _lastReport.StartingCredits + "\n" +
                "endingCredits=" + _lastReport.EndingCredits + "\n" +
                "startingReputation=" + _lastReport.StartingReputation + "\n" +
                "endingReputation=" + _lastReport.EndingReputation + "\n" +
                "visualCueId=" + _lastReport.VisualCueId + "\n" +
                "audioCueId=" + _lastReport.AudioCueId + "\n" +
                "saveSummary=" + _lastReport.SaveSummary;
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
