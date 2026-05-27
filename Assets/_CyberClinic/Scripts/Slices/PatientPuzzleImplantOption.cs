using System;
using CyberClinic.Patients;

namespace CyberClinic.Slices
{
    [Serializable]
    public class PatientPuzzleImplantOption
    {
        public string ImplantId;
        public BodySlot Slot;
        public int Price;
        public float CompatibilityScore;
        public string LabelKey;
    }
}
