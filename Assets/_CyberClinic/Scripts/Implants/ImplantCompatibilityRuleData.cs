using CyberClinic.Core;
using CyberClinic.Localization;
using CyberClinic.Patients;
using UnityEngine;

namespace CyberClinic.Implants
{
    [CreateAssetMenu(fileName = "ImplantCompatibilityRule", menuName = "Cyber Clinic/Implants/Compatibility Rule")]
    public class ImplantCompatibilityRuleData : ScriptableObject, IIdentifiable
    {
        [SerializeField] string _id;
        [SerializeField] LocalizedTextRef _label;
        [SerializeField] LocalizedTextRef _description;
        [SerializeField] BodySlot _patientSlot;
        [SerializeField] BodySlot _implantSlot;
        [SerializeField] ImplantCompatibilityRelation _relation;
        [SerializeField] float _compatibilityModifier;
        [SerializeField] float _bodyStressModifier;
        [SerializeField] string _bodyProblemId;
        [SerializeField] string _hiddenConditionId;

        public string Id => _id;
        public LocalizedTextRef Label => _label;
        public LocalizedTextRef Description => _description;
        public BodySlot PatientSlot => _patientSlot;
        public BodySlot ImplantSlot => _implantSlot;
        public ImplantCompatibilityRelation Relation => _relation;
        public float CompatibilityModifier => _compatibilityModifier;
        public float BodyStressModifier => _bodyStressModifier;
        public string BodyProblemId => _bodyProblemId;
        public string HiddenConditionId => _hiddenConditionId;
    }
}
