using CyberClinic.Core;
using UnityEngine;

namespace CyberClinic.Patients
{
    [CreateAssetMenu(fileName = "PatientVisualTrait", menuName = "Cyber Clinic/Patients/Visual Trait")]
    public class PatientVisualTraitData : ScriptableObject, IIdentifiable, IWeightedDefinition
    {
        [SerializeField] string _id;
        [SerializeField] float _weight = 1f;
        [SerializeField] string _spriteAddress;
        [SerializeField] Color _accentTint = Color.white;

        public string Id => _id;
        public float Weight => _weight;
        public string SpriteAddress => _spriteAddress;
        public Color AccentTint => _accentTint;
    }
}
