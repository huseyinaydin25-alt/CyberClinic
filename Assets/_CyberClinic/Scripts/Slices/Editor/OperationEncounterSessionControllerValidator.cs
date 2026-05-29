#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace CyberClinic.Slices.Editor
{
    public static class OperationEncounterSessionControllerValidator
    {
        [MenuItem("Cyber Clinic/Operation Encounter/Run Session Controller Debug")]
        public static void RunDebug()
        {
            var screenModel = PatientPuzzleSliceScreenModelBuilder.BuildDebugScreenModel();
            var controller = new OperationEncounterSessionController(screenModel);

            var initial = controller.CurrentState;
            var afterPlan = controller.Plan();
            var afterExecute = controller.Execute();
            var planAfterExecute = controller.Plan();
            var executeAfterExecute = controller.Execute();
            var afterReset = controller.Reset();
            var afterDisable = controller.Disable();
            var planAfterDisable = controller.Plan();
            var afterSecondReset = controller.Reset();

            var initialOk =
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

            var lockedPreservedOk =
                SameSessionState(afterExecute, planAfterExecute) &&
                SameSessionState(afterExecute, executeAfterExecute);

            var resetOk =
                IsState(afterReset, PreviewActionState.Available, CommitActionState.Available) &&
                afterReset.LastInteractionId == "operation_encounter.session.initial" &&
                afterReset.LastFeedbackRoute.RouteId == "primary_action.feedback.ready" &&
                !afterReset.HasPreviewed &&
                !afterReset.HasCommitted &&
                !afterReset.IsLocked;

            var disableOk =
                IsState(afterDisable, PreviewActionState.Disabled, CommitActionState.Disabled) &&
                afterDisable.LastInteractionId == "operation_action.disable" &&
                afterDisable.LastFeedbackRoute.RouteId == "primary_action.feedback.disabled" &&
                !afterDisable.HasPreviewed &&
                !afterDisable.HasCommitted &&
                afterDisable.IsLocked;

            var disabledPreservedOk = SameSessionState(afterDisable, planAfterDisable);

            var secondResetOk =
                IsState(afterSecondReset, PreviewActionState.Available, CommitActionState.Available) &&
                afterSecondReset.LastInteractionId == "operation_encounter.session.initial" &&
                !afterSecondReset.IsLocked;

            if (!initialOk || !planOk || !executeOk || !lockedPreservedOk || !resetOk || !disableOk || !disabledPreservedOk || !secondResetOk)
            {
                Debug.LogWarning(
                    "OperationEncounterSessionControllerDebug failed" +
                    "\ninitialOk=" + initialOk +
                    "\nplanOk=" + planOk +
                    "\nexecuteOk=" + executeOk +
                    "\nlockedPreservedOk=" + lockedPreservedOk +
                    "\nresetOk=" + resetOk +
                    "\ndisableOk=" + disableOk +
                    "\ndisabledPreservedOk=" + disabledPreservedOk +
                    "\nsecondResetOk=" + secondResetOk);
                return;
            }

            Debug.Log(
                "OperationEncounterSessionControllerDebug OK" +
                "\ninitialState=Available/Available" +
                "\nafterPlanState=Previewed/Available" +
                "\nafterExecuteState=Previewed/Committed" +
                "\nafterExecuteLocked=True" +
                "\nlockedPreserved=True" +
                "\nafterResetState=Available/Available" +
                "\nafterDisableState=Disabled/Disabled" +
                "\ndisabledPreserved=True" +
                "\nafterSecondResetState=Available/Available" +
                "\nuiBinding=operation_encounter_session_controller_ready");
        }

        static bool IsState(OperationEncounterSessionState state, PreviewActionState preview, CommitActionState commit)
        {
            return state.ActionState.PreviewState == preview && state.ActionState.CommitState == commit;
        }

        static bool SameSessionState(OperationEncounterSessionState left, OperationEncounterSessionState right)
        {
            return
                left.ActionState.PreviewState == right.ActionState.PreviewState &&
                left.ActionState.CommitState == right.ActionState.CommitState &&
                left.LastInteractionId == right.LastInteractionId &&
                left.LastFeedbackRoute.RouteId == right.LastFeedbackRoute.RouteId &&
                left.HasPreviewed == right.HasPreviewed &&
                left.HasCommitted == right.HasCommitted &&
                left.IsLocked == right.IsLocked;
        }
    }
}
#endif
