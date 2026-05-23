using CyberClinic.Core;
using CyberClinic.Localization;
using UnityEngine;

namespace CyberClinic.Patients
{
    [CreateAssetMenu(fileName = "PatientHiddenCondition", menuName = "Cyber Clinic/Patients/Hidden Condition")]
    public class PatientHiddenConditionData : ScriptableObject, IIdentifiable, IWeightedDefinition
    {
        [SerializeField] string _id;
        [SerializeField] float _weight = 1f;
        [SerializeField] LocalizedTextRef _revealedName;
        [SerializeField] LocalizedTextRef _scanHint;
        [SerializeField] float _operationPenalty;
        [SerializeField] float _neuralLoadMultiplier = 1f;
        [SerializeField] float _cyberToxMultiplier = 1f;

        public string Id => _id;
        public float Weight => _weight;
        public LocalizedTextRef RevealedName => _revealedName;
        public LocalizedTextRef ScanHint => _scanHint;
        public float OperationPenalty => _operationPenalty;
        public float NeuralLoadMultiplier => _neuralLoadMultiplier;
        public float CyberToxMultiplier => _cyberToxMultiplier;
    }
}
