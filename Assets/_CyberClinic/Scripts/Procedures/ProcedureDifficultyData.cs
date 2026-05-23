using CyberClinic.Core;
using CyberClinic.Localization;
using UnityEngine;

namespace CyberClinic.Procedures
{
    [CreateAssetMenu(fileName = "ProcedureDifficulty", menuName = "Cyber Clinic/Procedures/Difficulty Profile")]
    public class ProcedureDifficultyData : ScriptableObject, IIdentifiable
    {
        [SerializeField] string _id;
        [SerializeField] ProcedureDifficultyLevel _level;
        [SerializeField] LocalizedTextRef _label;
        [SerializeField] float _difficultyValue;
        [SerializeField] float _safeBandMin = 0.85f;
        [SerializeField] float _stableBandMin = 0.70f;
        [SerializeField] float _uncertainBandMin = 0.50f;
        [SerializeField] float _dangerousBandMin = 0.30f;

        public string Id => _id;
        public ProcedureDifficultyLevel Level => _level;
        public LocalizedTextRef Label => _label;
        public float DifficultyValue => _difficultyValue;
        public float SafeBandMin => _safeBandMin;
        public float StableBandMin => _stableBandMin;
        public float UncertainBandMin => _uncertainBandMin;
        public float DangerousBandMin => _dangerousBandMin;
    }
}
