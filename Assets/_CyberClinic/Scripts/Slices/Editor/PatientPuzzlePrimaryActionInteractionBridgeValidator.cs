#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace CyberClinic.Slices.Editor
{
    public static class PatientPuzzlePrimaryActionInteractionBridgeValidator
    {
        [MenuItem("Cyber Clinic/Slices/Run Patient Puzzle Primary Action Interaction Bridge Debug")]
        public static void RunDebug()
        {
            var bridge = new PatientPuzzlePrimaryActionInteractionBridge();
            var initial = bridge.CurrentState;
            var preview = bridge.Preview();
            var commit = bridge.Commit();
            var disable = bridge.Disable();
            var previewAfterDisable = bridge.Preview();
            var reset = bridge.Reset();

            var initialOk = IsState(initial, PreviewActionState.Available, CommitActionState.Available);
            var previewOk =
                preview.InteractionId == "primary_action.preview" &&
                IsState(preview.State, PreviewActionState.Previewed, CommitActionState.Available);
            var commitOk =
                commit.InteractionId == "primary_action.commit" &&
                IsState(commit.State, PreviewActionState.Previewed, CommitActionState.Committed);
            var disableOk =
                disable.InteractionId == "primary_action.disable" &&
                IsState(disable.State, PreviewActionState.Disabled, CommitActionState.Disabled);
            var disabledPreservedOk =
                previewAfterDisable.InteractionId == "primary_action.preview" &&
                IsState(previewAfterDisable.State, PreviewActionState.Disabled, CommitActionState.Disabled);
            var resetOk =
                reset.InteractionId == "primary_action.reset" &&
                IsState(reset.State, PreviewActionState.Available, CommitActionState.Available);

            if (!initialOk || !previewOk || !commitOk || !disableOk || !disabledPreservedOk || !resetOk)
            {
                Debug.LogWarning(
                    "PatientPuzzlePrimaryActionInteractionBridgeDebug failed" +
                    "\ninitialOk=" + initialOk +
                    "\npreviewOk=" + previewOk +
                    "\ncommitOk=" + commitOk +
                    "\ndisableOk=" + disableOk +
                    "\ndisabledPreservedOk=" + disabledPreservedOk +
                    "\nresetOk=" + resetOk +
                    "\ninitial=" + Format(initial) +
                    "\npreview=" + preview.InteractionId + ":" + Format(preview.State) +
                    "\ncommit=" + commit.InteractionId + ":" + Format(commit.State) +
                    "\ndisable=" + disable.InteractionId + ":" + Format(disable.State) +
                    "\npreviewAfterDisable=" + previewAfterDisable.InteractionId + ":" + Format(previewAfterDisable.State) +
                    "\nreset=" + reset.InteractionId + ":" + Format(reset.State));
                return;
            }

            Debug.Log(
                "PatientPuzzlePrimaryActionInteractionBridgeDebug OK" +
                "\ninitialState=" + Format(initial) +
                "\npreviewInteraction=primary_action.preview" +
                "\npreviewState=" + Format(preview.State) +
                "\ncommitInteraction=primary_action.commit" +
                "\ncommitState=" + Format(commit.State) +
                "\ndisableInteraction=primary_action.disable" +
                "\ndisableState=" + Format(disable.State) +
                "\ndisabledPreserved=True" +
                "\nresetInteraction=primary_action.reset" +
                "\nresetState=" + Format(reset.State) +
                "\nuiBinding=primary_action_interaction_bridge_ready");
        }

        static bool IsState(PatientPuzzlePrimaryActionState state, PreviewActionState preview, CommitActionState commit)
        {
            return state.PreviewState == preview && state.CommitState == commit;
        }

        static string Format(PatientPuzzlePrimaryActionState state)
        {
            return state.PreviewState + "/" + state.CommitState;
        }
    }
}
#endif
