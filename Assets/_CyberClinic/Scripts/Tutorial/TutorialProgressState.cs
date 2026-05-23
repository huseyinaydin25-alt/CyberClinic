using System;
using System.Collections.Generic;

namespace CyberClinic.Tutorial
{
    [Serializable]
    public class TutorialProgressState
    {
        public bool HasCompletedFirstTimeTutorial;
        public string ActiveSequenceId;
        public int CurrentStepIndex;
        public List<string> CompletedStepIds = new List<string>();
        public bool AllowSkip;
    }
}
