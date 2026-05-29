#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace CyberClinic.Slices.Editor
{
    public static class OperationEncounterNamingMigrationValidator
    {
        [MenuItem("Cyber Clinic/Operation Encounter/Run Naming Migration Debug")]
        public static void RunDebug()
        {
            var screenModel = PatientPuzzleSliceScreenModelBuilder.BuildDebugScreenModel();
            var controller = new OperationEncounterSessionController(screenModel);

            var initial = controller.CurrentState;
            var planned = controller.Plan();
            var binding = OperationEncounterPlanResultBinder.Bind(planned);
            var executed = controller.Execute();
            var reset = controller.Reset();

            var initialOk =
                initial.ActionState.PreviewState == PreviewActionState.Available &&
                initial.ActionState.CommitState == CommitActionState.Available &&
                initial.LastInteractionId == "operation_encounter.session.initial" &&
                !initial.HasPreviewed &&
                !initial.HasCommitted &&
                !initial.IsLocked;

            var planOk =
                planned.ActionState.PreviewState == PreviewActionState.Previewed &&
                planned.ActionState.CommitState == CommitActionState.Available &&
                planned.LastInteractionId == "operation_action.plan" &&
                planned.HasPreviewed &&
                !planned.HasCommitted &&
                !planned.IsLocked;

            var bindingOk =
                binding.SessionState.ActionState.PreviewState == PreviewActionState.Previewed &&
                binding.SessionState.ActionState.CommitState == CommitActionState.Available &&
                binding.FeedbackRouteId == "primary_action.feedback.previewed" &&
                binding.ReadoutVisualTokenId == "primary_action.visual.previewed";

            var executeOk =
                executed.ActionState.PreviewState == PreviewActionState.Previewed &&
                executed.ActionState.CommitState == CommitActionState.Committed &&
                executed.LastInteractionId == "operation_action.execute" &&
                executed.HasPreviewed &&
                executed.HasCommitted &&
                executed.IsLocked;

            var resetOk =
                reset.ActionState.PreviewState == PreviewActionState.Available &&
                reset.ActionState.CommitState == CommitActionState.Available &&
                reset.LastInteractionId == "operation_encounter.session.initial" &&
                !reset.HasPreviewed &&
                !reset.HasCommitted &&
                !reset.IsLocked;

            if (!initialOk || !planOk || !bindingOk || !executeOk || !resetOk)
            {
                Debug.LogWarning(
                    "OperationEncounterNamingMigrationDebug failed" +
                    "\ninitialOk=" + initialOk +
                    "\nplanOk=" + planOk +
                    "\nbindingOk=" + bindingOk +
                    "\nexecuteOk=" + executeOk +
                    "\nresetOk=" + resetOk);
                return;
            }

            Debug.Log(
                "OperationEncounterNamingMigrationDebug OK" +
                "\ncanonicalName=OperationEncounter" +
                "\ninitialState=Available/Available" +
                "\nplanState=Previewed/Available" +
                "\nplanBinding=True" +
                "\nexecuteState=Previewed/Committed" +
                "\nresetState=Available/Available" +
                "\nuiBinding=operation_encounter_naming_ready");
        }
    }
}
#endif
