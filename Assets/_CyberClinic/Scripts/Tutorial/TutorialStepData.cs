using CyberClinic.Core;
using CyberClinic.Localization;
using UnityEngine;

namespace CyberClinic.Tutorial
{
    [CreateAssetMenu(fileName = "TutorialStep", menuName = "Cyber Clinic/Tutorial/Step")]
    public class TutorialStepData : ScriptableObject, IIdentifiable
    {
        [SerializeField] string _id;
        [SerializeField] TutorialStepType _stepType;
        [SerializeField] TutorialTriggerType _triggerType;
        [SerializeField] LocalizedTextRef _instruction;
        [SerializeField] string _targetUiElementId;
        [SerializeField] bool _blocksInputUntilComplete = true;

        public string Id => _id;
        public TutorialStepType StepType => _stepType;
        public TutorialTriggerType TriggerType => _triggerType;
        public LocalizedTextRef Instruction => _instruction;
        public string TargetUiElementId => _targetUiElementId;
        public bool BlocksInputUntilComplete => _blocksInputUntilComplete;
    }
}
