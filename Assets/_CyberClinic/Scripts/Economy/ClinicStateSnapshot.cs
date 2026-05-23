using System;
using CyberClinic.Cosmetics;
using CyberClinic.Progression;

namespace CyberClinic.Economy
{
    /// <summary>Clinic runtime state snapshot for day flow and save (mutable instance data).</summary>
    [Serializable]
    public class ClinicStateSnapshot
    {
        public int CurrentDayIndex;
        public int Money;
        public float Reputation;
        public ClinicProgressionState Progression = new ClinicProgressionState();
        public ClinicVisualState VisualState = new ClinicVisualState();
    }
}
