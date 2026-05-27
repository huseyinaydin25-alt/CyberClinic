using System;

namespace CyberClinic.Slices
{
    [Serializable]
    public class PatientPuzzleSliceReport
    {
        public string PatientId;
        public int PatientSeed;
        public string SelectedImplantId;
        public string SelectedProcedureId;
        public float PreviewSuccessChance;
        public float CommitSuccessChance;
        public string RiskBand;
        public string OutcomeType;
        public int StartingCredits;
        public int EndingCredits;
        public int StartingReputation;
        public int EndingReputation;
        public string VisualCueId;
        public string AudioCueId;
        public string SaveSummary;
    }
}
