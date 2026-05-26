using System;
using CyberClinic.Core;

namespace CyberClinic.Procedures
{
    [Serializable]
    public class OperationResult
    {
        public bool Success;
        public Percentage01 SuccessChance;
        public OperationRiskBand RiskBand;
        public OperationOutcomeType OutcomeType;
        public int OperationSeed;
        public float RawScore;
        public float RandomVariance;
        public OperationBreakdownEntry[] Breakdown = Array.Empty<OperationBreakdownEntry>();
    }
}
