using System;
using CyberClinic.Patients;

namespace CyberClinic.Implants
{
    /// <summary>Runtime compatibility evaluation output (calculation in later milestone).</summary>
    [Serializable]
    public class ImplantCompatibilityResult
    {
        public float CompatibilityScore;
        public bool HasSlotConflict;
        public bool HasBodyProblemConflict;
        public BodySlot TargetSlot;
    }
}
