using CyberClinic.Core;
using CyberClinic.Localization;
using UnityEngine;

namespace CyberClinic.Patients
{
    [CreateAssetMenu(fileName = "PatientDialogueTone", menuName = "Cyber Clinic/Patients/Dialogue Tone")]
    public class PatientDialogueToneData : ScriptableObject, IIdentifiable, IWeightedDefinition
    {
        [SerializeField] string _id;
        [SerializeField] float _weight = 1f;
        [SerializeField] LocalizedTextRef[] _lineKeys;

        public string Id => _id;
        public float Weight => _weight;
        public LocalizedTextRef[] LineKeys => _lineKeys;
    }
}
