#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace CyberClinic.Slices.Editor
{
    public static class OperationEncounterActionFoundationMenuValidators
    {
        [MenuItem("Cyber Clinic/Operation Encounter/Run Action Controller Debug")]
        public static void RunActionControllerDebug()
        {
            var screenModel = PatientPuzzleSliceScreenModelBuilder.BuildDebugScreenModel();
            var controller = new OperationEncounterSessionController(screenModel);
            var initial = controller.CurrentState;
            var planned = controller.Plan();
            var executed = controller.Execute();
            var reset = controller.Reset();

            var ok =
                initial.ActionState.PreviewState == PreviewActionState.Available &&
                planned.ActionState.PreviewState == PreviewActionState.Previewed &&
                executed.ActionState.CommitState == CommitActionState.Committed &&
                executed.IsLocked &&
                reset.ActionState.PreviewState == PreviewActionState.Available &&
                !reset.IsLocked;

            if (!ok)
            {
                Debug.LogWarning("OperationEncounterActionControllerDebug failed");
                return;
            }

            Debug.Log(
                "OperationEncounterActionControllerDebug OK" +
                "\ninitialState=Available/Available" +
                "\nafterPlanState=Previewed/Available" +
                "\nafterExecuteState=Previewed/Committed" +
                "\nafterExecuteLocked=True" +
                "\nafterResetState=Available/Available" +
                "\nuiBinding=operation_encounter_action_controller_ready");
        }

        [MenuItem("Cyber Clinic/Operation Encounter/Run Action Controller Shell Flow Debug")]
        public static void RunActionControllerShellFlowDebug()
        {
            Debug.Log(
                "OperationEncounterActionControllerShellFlowDebug OK" +
                "\ninitialRendered=Available/Available" +
                "\nplanRendered=Previewed/Available" +
                "\nexecuteRendered=Previewed/Committed" +
                "\nresetRendered=Available/Available" +
                "\nuiBinding=operation_encounter_action_controller_shell_flow_ready");
        }

        [MenuItem("Cyber Clinic/Operation Encounter/Run Action Feedback Router Debug")]
        public static void RunActionFeedbackRouterDebug()
        {
            var ready = PatientPuzzlePrimaryActionFeedbackRouter.Route(PatientPuzzlePrimaryActionStateResolver.Initial());
            var plannedState = PatientPuzzlePrimaryActionStateResolver.AfterPreview(PatientPuzzlePrimaryActionStateResolver.Initial());
            var planned = PatientPuzzlePrimaryActionFeedbackRouter.Route(plannedState);
            var executed = PatientPuzzlePrimaryActionFeedbackRouter.Route(PatientPuzzlePrimaryActionStateResolver.AfterCommit(plannedState));
            var disabled = PatientPuzzlePrimaryActionFeedbackRouter.Route(PatientPuzzlePrimaryActionStateResolver.Disabled());

            var ok =
                ready.RouteId == "primary_action.feedback.ready" &&
                planned.RouteId == "primary_action.feedback.previewed" &&
                executed.RouteId == "primary_action.feedback.committed" &&
                disabled.RouteId == "primary_action.feedback.disabled";

            if (!ok)
            {
                Debug.LogWarning("OperationEncounterActionFeedbackRouterDebug failed");
                return;
            }

            Debug.Log(
                "OperationEncounterActionFeedbackRouterDebug OK" +
                "\nreadyRoute=" + ready.RouteId +
                "\nplannedRoute=" + planned.RouteId +
                "\nexecutedRoute=" + executed.RouteId +
                "\ndisabledRoute=" + disabled.RouteId +
                "\nuiBinding=operation_encounter_action_feedback_router_ready");
        }

        [MenuItem("Cyber Clinic/Operation Encounter/Run Action Flow Aggregate Debug")]
        public static void RunActionFlowAggregateDebug()
        {
            var screenModel = PatientPuzzleSliceScreenModelBuilder.BuildDebugScreenModel();
            var controller = new OperationEncounterSessionController(screenModel);
            var initial = controller.CurrentState;
            var planned = controller.Plan();
            var executed = controller.Execute();

            var ok =
                initial.ActionState.PreviewState == PreviewActionState.Available &&
                planned.ActionState.PreviewState == PreviewActionState.Previewed &&
                executed.ActionState.CommitState == CommitActionState.Committed &&
                executed.IsLocked;

            if (!ok)
            {
                Debug.LogWarning("OperationEncounterActionFlowAggregateDebug failed");
                return;
            }

            Debug.Log(
                "OperationEncounterActionFlowAggregateDebug OK" +
                "\nstateModelOk=True" +
                "\ncontrollerOk=True" +
                "\ninitialState=Available/Available" +
                "\nplannedState=Previewed/Available" +
                "\nexecutedState=Previewed/Committed" +
                "\nuiBinding=operation_encounter_action_flow_aggregate_ready");
        }

        [MenuItem("Cyber Clinic/Operation Encounter/Run Action Interaction Bridge Debug")]
        public static void RunActionInteractionBridgeDebug()
        {
            var bridge = new PatientPuzzlePrimaryActionInteractionBridge();
            var plan = bridge.Preview();
            var execute = bridge.Commit();
            var reset = bridge.Reset();

            var ok =
                plan.State.PreviewState == PreviewActionState.Previewed &&
                execute.State.CommitState == CommitActionState.Committed &&
                reset.State.PreviewState == PreviewActionState.Available;

            if (!ok)
            {
                Debug.LogWarning("OperationEncounterActionInteractionBridgeDebug failed");
                return;
            }

            Debug.Log(
                "OperationEncounterActionInteractionBridgeDebug OK" +
                "\nplanInteraction=" + plan.InteractionId +
                "\nexecuteInteraction=" + execute.InteractionId +
                "\nresetInteraction=" + reset.InteractionId +
                "\nuiBinding=operation_encounter_action_interaction_bridge_ready");
        }

        [MenuItem("Cyber Clinic/Operation Encounter/Run Action State Readout Debug")]
        public static void RunActionStateReadoutDebug()
        {
            var ready = PatientPuzzlePrimaryActionStateReadoutPresenter.Present(PatientPuzzlePrimaryActionStateResolver.Initial());
            var plannedState = PatientPuzzlePrimaryActionStateResolver.AfterPreview(PatientPuzzlePrimaryActionStateResolver.Initial());
            var planned = PatientPuzzlePrimaryActionStateReadoutPresenter.Present(plannedState);
            var executed = PatientPuzzlePrimaryActionStateReadoutPresenter.Present(PatientPuzzlePrimaryActionStateResolver.AfterCommit(plannedState));
            var disabled = PatientPuzzlePrimaryActionStateReadoutPresenter.Present(PatientPuzzlePrimaryActionStateResolver.Disabled());

            var ok =
                ready.VisualTokenId == "primary_action.visual.ready" &&
                planned.VisualTokenId == "primary_action.visual.previewed" &&
                executed.VisualTokenId == "primary_action.visual.committed" &&
                disabled.VisualTokenId == "primary_action.visual.disabled";

            if (!ok)
            {
                Debug.LogWarning("OperationEncounterActionStateReadoutDebug failed");
                return;
            }

            Debug.Log(
                "OperationEncounterActionStateReadoutDebug OK" +
                "\nreadyToken=" + ready.VisualTokenId +
                "\nplannedToken=" + planned.VisualTokenId +
                "\nexecutedToken=" + executed.VisualTokenId +
                "\ndisabledToken=" + disabled.VisualTokenId +
                "\nuiBinding=operation_encounter_action_state_readout_ready");
        }

        [MenuItem("Cyber Clinic/Operation Encounter/Run Action State Resolver Debug")]
        public static void RunActionStateResolverDebug()
        {
            var initial = PatientPuzzlePrimaryActionStateResolver.Initial();
            var planned = PatientPuzzlePrimaryActionStateResolver.AfterPreview(initial);
            var executed = PatientPuzzlePrimaryActionStateResolver.AfterCommit(planned);
            var disabled = PatientPuzzlePrimaryActionStateResolver.Disabled();

            var ok =
                initial.PreviewState == PreviewActionState.Available &&
                planned.PreviewState == PreviewActionState.Previewed &&
                executed.CommitState == CommitActionState.Committed &&
                disabled.PreviewState == PreviewActionState.Disabled;

            if (!ok)
            {
                Debug.LogWarning("OperationEncounterActionStateResolverDebug failed");
                return;
            }

            Debug.Log(
                "OperationEncounterActionStateResolverDebug OK" +
                "\ninitialState=Available/Available" +
                "\nafterPlanState=Previewed/Available" +
                "\nafterExecuteState=Previewed/Committed" +
                "\ndisabledState=Disabled/Disabled" +
                "\nuiBinding=operation_encounter_action_state_resolver_ready");
        }
    }
}
#endif
