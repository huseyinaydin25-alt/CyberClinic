using System;

namespace CyberClinic.Patients
{
    [Serializable]
    public class PatientUrgencyProfile
    {
        public PatientUrgencyLevel Level;
        public float PatienceRemaining01 = 1f;
        public bool ShowVisibleTimer;
    }
}
