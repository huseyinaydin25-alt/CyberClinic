using System;
using System.Collections.Generic;

namespace CyberClinic.Patients
{
    /// <summary>Hidden conditions and obscured facts; reveal state per entry.</summary>
    [Serializable]
    public class PatientHiddenInfo
    {
        public List<HiddenConditionEntry> HiddenConditions = new List<HiddenConditionEntry>();
        public RevealState ToleranceRevealState = RevealState.Hidden;
        public RevealState SlotConflictRevealState = RevealState.Hidden;
        public RevealState MotivationSubtextRevealState = RevealState.Hidden;
    }

    [Serializable]
    public struct HiddenConditionEntry
    {
        public string ConditionId;
        public RevealState RevealState;
    }
}
