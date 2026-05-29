#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

namespace CyberClinic.Slices.Editor
{
    public static class PatientPuzzleCommitActionDebugInteractionValidator
    {
        [MenuItem("Cyber Clinic/Slices/Run Patient Puzzle Commit Action Debug Interaction")]
        public static void RunDebug()
        {
            var screenModel = PatientPuzzleSliceScreenModelBuilder.BuildDebugScreenModel();
            var interaction = new PatientPuzzleCommitActionDebugInteraction(screenModel);
            var result = interaction.Execute();

            var interactionOk = result.InteractionId == "primary_action.commit";
            var stateOk =
                result.State.PreviewState == PreviewActionState.Previewed &&
                result.State.CommitState == CommitActionState.Committed;
            var presentationOk =
                result.Presentation.HasPrimaryActionState(result.State) &&
                result.Presentation.PrimaryActionBody.Contains("debug.previewActionState=Previewed") &&
                result.Presentation.PrimaryActionBody.Contains("debug.commitActionState=Committed");
            var runtimeOk = RuntimeRendersState(screenModel, result.State);

            if (!interactionOk || !stateOk || !presentationOk || !runtimeOk)
            {
                Debug.LogWarning(
                    "PatientPuzzleCommitActionDebugInteraction failed" +
                    "\ninteractionOk=" + interactionOk +
                    "\nstateOk=" + stateOk +
                    "\npresentationOk=" + presentationOk +
                    "\nruntimeOk=" + runtimeOk +
                    "\ninteractionId=" + result.InteractionId +
                    "\nstate=" + Format(result.State) +
                    "\nprimaryActionBody=" + result.Presentation.PrimaryActionBody);
                return;
            }

            Debug.Log(
                "PatientPuzzleCommitActionDebugInteraction OK" +
                "\ninteractionId=" + result.InteractionId +
                "\npreviewState=" + result.State.PreviewState +
                "\ncommitState=" + result.State.CommitState +
                "\npresentationOk=True" +
                "\nruntimeOk=True" +
                "\nuiBinding=commit_action_debug_interaction_ready");
        }

        static bool RuntimeRendersState(PatientPuzzleSliceScreenModel screenModel, PatientPuzzlePrimaryActionState state)
        {
            EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
            var host = new GameObject("PatientPuzzleCommitActionDebugInteractionHost");
            var runtime = host.AddComponent<PatientPuzzleShellRuntime>();
            runtime.BuildShell(screenModel, state);

            var primaryActionArea = GameObject.Find(PatientPuzzleShellLayout.PrimaryActionAreaName);
            var primaryActionText = FindSectionText(primaryActionArea);
            return
                primaryActionArea != null &&
                primaryActionText != null &&
                primaryActionText.text.Contains("debug.previewActionState=Previewed") &&
                primaryActionText.text.Contains("debug.commitActionState=Committed");
        }

        static Text FindSectionText(GameObject section)
        {
            if (section == null)
            {
                return null;
            }

            var texts = section.GetComponentsInChildren<Text>();
            for (int i = 0; i < texts.Length; i++)
            {
                if (texts[i].text.StartsWith("debug."))
                {
                    return texts[i];
                }
            }

            return null;
        }

        static string Format(PatientPuzzlePrimaryActionState state)
        {
            return state.PreviewState + "/" + state.CommitState;
        }
    }
}
#endif
