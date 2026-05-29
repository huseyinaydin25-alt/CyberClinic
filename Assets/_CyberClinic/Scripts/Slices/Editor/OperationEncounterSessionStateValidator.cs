#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace CyberClinic.Slices.Editor
{
    public static class OperationEncounterSessionStateValidator
    {
        [MenuItem("Cyber Clinic/Operation Encounter/Run Session State Debug")]
        public static void RunDebug()
        {
            var screenModel = PatientPuzzleSliceScreenModelBuilder.BuildDebugScreenModel();
            var initial = OperationEncounterSessionState.CreateInitial(screenModel);

            var plannedActionState = PatientPuzzlePrimaryActionStateResolver.AfterPreview(initial.ActionState);
            var afterPlan = initial.WithInteraction("operation_action.plan", plannedActionState);

            var executedActionState = PatientPuzzlePrimaryActionStateResolver.AfterCommit(afterPlan.ActionState);
            var afterExecute = afterPlan.WithInteraction("operation_action.execute", executedActionState);

            var afterDisable = afterPlan.WithLockedDisabled("operation_action.disable");
            var afterReset = afterExecute.Reset();

            var initialOk =
                initial.ScreenModel.PatientDossier.PatientId == screenModel.PatientDossier.PatientId &&
                IsState(initial, PreviewActionState.Available, CommitActionState.Available) &&
                initial.LastInteractionId == "operation_encounter.session.initial" &&
                initial.LastFeedbackRoute.RouteId == "primary_action.feedback.ready" &&
                !initial.HasPreviewed &&
                !initial.HasCommitted &&
                !initial.IsLocked;

            var planOk =
                IsState(afterPlan, PreviewActionState.Previewed, CommitActionState.Available) &&
                afterPlan.LastInteractionId == "operation_action.plan" &&
                afterPlan.LastFeedbackRoute.RouteId == "primary_action.feedback.previewed" &&
                afterPlan.HasPreviewed &&
                !afterPlan.HasCommitted &&
                !afterPlan.IsLocked;

            var executeOk =
                IsState(afterExecute, PreviewActionState.Previewed, CommitActionState.Committed) &&
                afterExecute.LastInteractionId == "operation_action.execute" &&
                afterExecute.LastFeedbackRoute.RouteId == "primary_action.feedback.committed" &&
                afterExecute.HasPreviewed &&
                afterExecute.HasCommitted &&
                afterExecute.IsLocked;

            var disableOk =
                IsState(afterDisable, PreviewActionState.Disabled, CommitActionState.Disabled) &&
                afterDisable.LastInteractionId == "operation_action.disable" &&
                afterDisable.LastFeedbackRoute.RouteId == "primary_action.feedback.disabled" &&
                afterDisable.HasPreviewed &&
                !afterDisable.HasCommitted &&
                afterDisable.IsLocked;

            var resetOk =
                IsState(afterReset, PreviewActionState.Available, CommitActionState.Available) &&
                afterReset.LastInteractionId == "operation_encounter.session.initial" &&
                afterReset.LastFeedbackRoute.RouteId == "primary_action.feedback.ready" &&
                !afterReset.HasPreviewed &&
                !afterReset.HasCommitted &&
                !afterReset.IsLocked;

            if (!initialOk || !planOk || !executeOk || !disableOk || !resetOk)
            {
                Debug.LogWarning(
                    "OperationEncounterSessionStateDebug failed" +
                    "\ninitialOk=" + initialOk +
                    "\nplanOk=" + planOk +
                    "\nexecuteOk=" + executeOk +
                    "\ndisableOk=" + disableOk +
                    "\nresetOk=" + resetOk);
                return;
            }

            Debug.Log(
                "OperationEncounterSessionStateDebug OK" +
                "\ninitialState=Available/Available" +
                "\ninitialRoute=primary_action.feedback.ready" +
                "\nafterPlanState=Previewed/Available" +
                "\nafterPlanRoute=primary_action.feedback.previewed" +
                "\nafterExecuteState=Previewed/Committed" +
                "\nafterExecuteRoute=primary_action.feedback.committed" +
                "\nafterExecuteLocked=True" +
                "\nafterDisableState=Disabled/Disabled" +
                "\nafterDisableRoute=primary_action.feedback.disabled" +
                "\nafterResetState=Available/Available" +
                "\nuiBinding=operation_encounter_session_state_ready");
        }

        static bool IsState(OperationEncounterSessionState state, PreviewActionState preview, CommitActionState commit)
        {
            return state.ActionState.PreviewState == preview && state.ActionState.CommitState == commit;
        }
    }
}
#endif
