using CyberClinic.Core;
using CyberClinic.Implants;
using CyberClinic.Localization;
using CyberClinic.Patients;
using UnityEngine;

namespace CyberClinic.Procedures
{
    [CreateAssetMenu(fileName = "ProcedureImplantCompatibility", menuName = "Cyber Clinic/Procedures/Implant Compatibility")]
    public class ProcedureImplantCompatibilityData : ScriptableObject, IIdentifiable
    {
        [SerializeField] string _id;
        [SerializeField] LocalizedTextRef _label;
        [SerializeField] string _procedureId;
        [SerializeField] string _implantId;
        [SerializeField] BodySlot _targetSlot;
        [SerializeField] ImplantCompatibilityRelation _relation;
        [SerializeField] float _successModifier;
        [SerializeField] float _bodyStressModifier;
        [SerializeField] float _cyberToxModifier;
        [SerializeField] float _neuralLoadModifier;

        public string Id => _id;
        public LocalizedTextRef Label => _label;
        public string ProcedureId => _procedureId;
        public string ImplantId => _implantId;
        public BodySlot TargetSlot => _targetSlot;
        public ImplantCompatibilityRelation Relation => _relation;
        public float SuccessModifier => _successModifier;
        public float BodyStressModifier => _bodyStressModifier;
        public float CyberToxModifier => _cyberToxModifier;
        public float NeuralLoadModifier => _neuralLoadModifier;
    }
}
