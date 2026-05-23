using System;

namespace CyberClinic.Economy
{
    /// <summary>Money delta produced by domain logic; applied by Economy module orchestrator.</summary>
    [Serializable]
    public class EconomyChangeSet
    {
        public int MoneyDelta;
        public int ScanCost;
        public int OperationRevenue;
        public int ImplantCost;
        public string SourceId;
    }
}
