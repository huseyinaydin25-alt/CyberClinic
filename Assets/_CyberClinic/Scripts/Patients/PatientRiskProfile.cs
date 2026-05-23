using System;
using CyberClinic.Core;

namespace CyberClinic.Patients
{
    /// <summary>Runtime tolerance and stress values for operation math (exact floats may stay hidden until scan).</summary>
    [Serializable]
    public class PatientRiskProfile
    {
        public Percentage01 CyberToxResistance;
        public Percentage01 NeuralStability;
        public Percentage01 BodyStressBaseline;
        public int PanicNumeric;
        public Percentage01 PainThreshold;

        public PatientPanicLevel PanicBand => PanicNumeric switch
        {
            < 25 => PatientPanicLevel.Calm,
            < 50 => PatientPanicLevel.Uneasy,
            < 75 => PatientPanicLevel.Agitated,
            _ => PatientPanicLevel.Panicked
        };
    }
}
