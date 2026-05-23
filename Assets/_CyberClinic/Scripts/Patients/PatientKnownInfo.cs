using System;
using System.Collections.Generic;
using CyberClinic.Localization;

namespace CyberClinic.Patients
{
    /// <summary>Facts visible on the patient file without scanning.</summary>
    [Serializable]
    public class PatientKnownInfo
    {
        public LocalizationKey ArchetypeNameKey;
        public LocalizationKey RequestDescriptionKey;
        public LocalizationKey MotivationHintKey;
        public PatientLegalStatus DeclaredLegalStatus;
        public List<string> VisibleVisualTraitIds = new List<string>();
        public List<LocalizationKey> VisibleDialogueLineKeys = new List<LocalizationKey>();
    }
}
