using CyberClinic.Core;
using CyberClinic.Localization;
using UnityEngine;

namespace CyberClinic.Procedures
{
    [CreateAssetMenu(fileName = "Procedure", menuName = "Cyber Clinic/Procedures/Procedure")]
    public class ProcedureData : ScriptableObject, IIdentifiable
    {
        [SerializeField] string _id;
        [SerializeField] LocalizedTextRef _name;
        [SerializeField] LocalizedTextRef _description;
        [SerializeField] float _baseSuccess = 0.75f;
        [SerializeField] float _procedureDifficulty;
        [SerializeField] float _bodyStressAdd;
        [SerializeField] float _cyberToxMultiplier = 1f;
        [SerializeField] float _neuralMultiplier = 1f;
        [SerializeField] ProcedureDifficultyLevel _difficultyLevel;

        public string Id => _id;
        public LocalizedTextRef Name => _name;
        public LocalizedTextRef Description => _description;
        public float BaseSuccess => _baseSuccess;
        public float ProcedureDifficulty => _procedureDifficulty;
        public float BodyStressAdd => _bodyStressAdd;
        public float CyberToxMultiplier => _cyberToxMultiplier;
        public float NeuralMultiplier => _neuralMultiplier;
        public ProcedureDifficultyLevel DifficultyLevel => _difficultyLevel;
    }
}
