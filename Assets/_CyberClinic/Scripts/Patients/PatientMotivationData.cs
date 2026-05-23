using CyberClinic.Core;
using CyberClinic.Localization;
using UnityEngine;

namespace CyberClinic.Patients
{
    [CreateAssetMenu(fileName = "PatientMotivation", menuName = "Cyber Clinic/Patients/Motivation")]
    public class PatientMotivationData : ScriptableObject, IIdentifiable, IWeightedDefinition
    {
        [SerializeField] string _id;
        [SerializeField] float _weight = 1f;
        [SerializeField] LocalizedTextRef _hintLabel;
        [SerializeField] LocalizedTextRef _description;

        public string Id => _id;
        public float Weight => _weight;
        public LocalizedTextRef HintLabel => _hintLabel;
        public LocalizedTextRef Description => _description;
    }
}
