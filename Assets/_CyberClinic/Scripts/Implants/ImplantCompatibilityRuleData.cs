using CyberClinic.Core;
using CyberClinic.Patients;
using UnityEngine;

namespace CyberClinic.Implants
{
    [CreateAssetMenu(fileName = "ImplantCompatibilityRule", menuName = "Cyber Clinic/Implants/Compatibility Rule")]
    public class ImplantCompatibilityRuleData : ScriptableObject, IIdentifiable
    {
        [SerializeField] string _id;
        [SerializeField] BodySlot _slot;
        [SerializeField] string _conflictingBodyProblemId;
        [SerializeField] float _compatibilityPenalty = 0.25f;

        public string Id => _id;
        public BodySlot Slot => _slot;
        public string ConflictingBodyProblemId => _conflictingBodyProblemId;
        public float CompatibilityPenalty => _compatibilityPenalty;
    }
}
