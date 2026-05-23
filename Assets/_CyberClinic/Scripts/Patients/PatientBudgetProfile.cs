using System;
using CyberClinic.Core;
using CyberClinic.Localization;

namespace CyberClinic.Patients
{
    /// <summary>Stated and true budget data; true ceiling may remain hidden until scan.</summary>
    [Serializable]
    public class PatientBudgetProfile
    {
        /// <summary>Localization key for stated budget band label (e.g. patient.budget.tight.label).</summary>
        public LocalizationKey StatedBandLabelKey;

        public RangeInt StatedRange;
        public int TrueCeiling;
        public RevealState TrueCeilingRevealState = RevealState.Hidden;
        public bool WillWalkIfOverBudget;
        public RevealState WalkAwayRevealState = RevealState.Hidden;
    }
}
