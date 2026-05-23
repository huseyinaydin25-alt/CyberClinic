namespace CyberClinic.Core
{
    /// <summary>
    /// Well-known content id tokens for code references. Display names use localization keys, not these ids.
    /// </summary>
    public static class CyberClinicIds
    {
        public static class MathTerms
        {
            public const string BaseSuccess = "math.term.base_success";
            public const string ClinicSkillBonus = "math.term.clinic_skill_bonus";
            public const string EquipmentBonus = "math.term.equipment_bonus";
            public const string PreparationBonus = "math.term.preparation_bonus";
            public const string ImplantCompatibility = "math.term.implant_compatibility";
            public const string ProcedureDifficulty = "math.term.procedure_difficulty";
            public const string CyberToxPressure = "math.term.cyber_tox_pressure";
            public const string NeuralLoadPressure = "math.term.neural_load_pressure";
            public const string BodyStress = "math.term.body_stress";
            public const string HiddenConditionPenalty = "math.term.hidden_condition_penalty";
            public const string PatientPanicPenalty = "math.term.patient_panic_penalty";
            public const string IllegalImplantRisk = "math.term.illegal_implant_risk";
            public const string SeededVariance = "math.term.seeded_variance";
        }

        public static class RiskBands
        {
            public const string Safe = "risk.band.safe";
            public const string Stable = "risk.band.stable";
            public const string Uncertain = "risk.band.uncertain";
            public const string Dangerous = "risk.band.dangerous";
            public const string Critical = "risk.band.critical";
        }
    }
}
