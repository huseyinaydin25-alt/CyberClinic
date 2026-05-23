using CyberClinic.Core;
using CyberClinic.Localization;
using UnityEngine;

namespace CyberClinic.Patients
{
    [CreateAssetMenu(fileName = "PatientArchetype", menuName = "Cyber Clinic/Patients/Archetype")]
    public class PatientArchetypeData : ScriptableObject, IIdentifiable, IWeightedDefinition
    {
        [SerializeField] string _id;
        [SerializeField] float _weight = 1f;
        [SerializeField] PatientArchetypeCategory _category;
        [SerializeField] LocalizedTextRef _name;
        [SerializeField] LocalizedTextRef _description;
        [SerializeField] LocalizedTextRef _flavor;
        [SerializeField] PatientLegalStatus _defaultLegalLean;

        public string Id => _id;
        public float Weight => _weight;
        public PatientArchetypeCategory Category => _category;
        public LocalizedTextRef Name => _name;
        public LocalizedTextRef Description => _description;
        public LocalizedTextRef Flavor => _flavor;
        public PatientLegalStatus DefaultLegalLean => _defaultLegalLean;
    }
}
