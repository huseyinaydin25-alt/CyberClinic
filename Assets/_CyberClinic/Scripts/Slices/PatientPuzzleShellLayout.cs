using UnityEngine;

namespace CyberClinic.Slices
{
    public readonly struct ShellAnchorRect
    {
        public ShellAnchorRect(Vector2 min, Vector2 max)
        {
            Min = min;
            Max = max;
        }

        public Vector2 Min { get; }
        public Vector2 Max { get; }
    }

    public static class PatientPuzzleShellLayout
    {
        public const string RootName = "PatientPuzzleShellRoot";
        public const string PatientDossierAreaName = "PatientDossierArea";
        public const string ProcedureDecisionAreaName = "ProcedureDecisionArea";
        public const string RiskAnalysisAreaName = "RiskAnalysisArea";
        public const string OperationResultAreaName = "OperationResultArea";
        public const string ActionFeedbackAreaName = "ActionFeedbackArea";

        public static readonly Vector2 ReferenceResolution = new Vector2(1920f, 1080f);
        public static readonly ShellAnchorRect Title = new ShellAnchorRect(new Vector2(0.03f, 0.925f), new Vector2(0.97f, 0.985f));
        public static readonly ShellAnchorRect Subtitle = new ShellAnchorRect(new Vector2(0.03f, 0.885f), new Vector2(0.97f, 0.925f));
        public static readonly ShellAnchorRect PatientDossier = new ShellAnchorRect(new Vector2(0.03f, 0.55f), new Vector2(0.31f, 0.86f));
        public static readonly ShellAnchorRect ProcedureDecision = new ShellAnchorRect(new Vector2(0.03f, 0.20f), new Vector2(0.31f, 0.52f));
        public static readonly ShellAnchorRect RiskAnalysis = new ShellAnchorRect(new Vector2(0.34f, 0.55f), new Vector2(0.64f, 0.86f));
        public static readonly ShellAnchorRect OperationResult = new ShellAnchorRect(new Vector2(0.67f, 0.55f), new Vector2(0.97f, 0.86f));
        public static readonly ShellAnchorRect ActionFeedback = new ShellAnchorRect(new Vector2(0.34f, 0.20f), new Vector2(0.97f, 0.52f));
        public static readonly ShellAnchorRect Footer = new ShellAnchorRect(new Vector2(0.03f, 0.06f), new Vector2(0.97f, 0.13f));

        public static bool HasRequiredContract()
        {
            return
                HasValue(RootName) &&
                HasValue(PatientDossierAreaName) &&
                HasValue(ProcedureDecisionAreaName) &&
                HasValue(RiskAnalysisAreaName) &&
                HasValue(OperationResultAreaName) &&
                HasValue(ActionFeedbackAreaName) &&
                ReferenceResolution.x > 0f &&
                ReferenceResolution.y > 0f &&
                IsValid(PatientDossier) &&
                IsValid(ProcedureDecision) &&
                IsValid(RiskAnalysis) &&
                IsValid(OperationResult) &&
                IsValid(ActionFeedback);
        }

        static bool HasValue(string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }

        static bool IsValid(ShellAnchorRect rect)
        {
            return rect.Min.x >= 0f && rect.Min.y >= 0f && rect.Max.x <= 1f && rect.Max.y <= 1f && rect.Min.x < rect.Max.x && rect.Min.y < rect.Max.y;
        }
    }
}
