using System;

namespace CyberClinic.Procedures
{
    /// <summary>Player-selected operation plan before commit (no calculation here).</summary>
    [Serializable]
    public class ProcedurePlan
    {
        public string ProcedureId;
        public string ImplantId;
        public float PreparationBonus;
        public int OperationSeed;
    }
}
