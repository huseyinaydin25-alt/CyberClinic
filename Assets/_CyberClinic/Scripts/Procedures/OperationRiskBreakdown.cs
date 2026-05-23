using System;
using System.Collections.Generic;
using CyberClinic.Localization;

namespace CyberClinic.Procedures
{
    /// <summary>Term-by-term breakdown for risk preview UI (labels via localization keys).</summary>
    [Serializable]
    public class OperationRiskBreakdown
    {
        public List<OperationRiskBreakdownEntry> Entries = new List<OperationRiskBreakdownEntry>();
    }

    [Serializable]
    public struct OperationRiskBreakdownEntry
    {
        public LocalizationKey TermKey;
        public float Value;
        public float SignedContribution;
        public int SortOrder;
    }
}
