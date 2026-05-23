using System;
using CyberClinic.Core;

namespace CyberClinic.Procedures
{
    /// <summary>Output preview before operation commit (calculator fills in Milestone 5).</summary>
    [Serializable]
    public class OperationResultPreview
    {
        public Percentage01 SuccessChance;
        public OperationRiskBand RiskBand;
        public OperationRiskBreakdown Breakdown = new OperationRiskBreakdown();
        public int OperationSeed;
        public bool IsPreviewOnly = true;
    }
}
