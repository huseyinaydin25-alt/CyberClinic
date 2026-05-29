#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace CyberClinic.Slices.Editor
{
    public static class PatientPuzzlePrimaryActionStateReadoutValidator
    {
        [MenuItem("Cyber Clinic/Slices/Run Patient Puzzle Primary Action State Readout Debug")]
        public static void RunDebug()
        {
            var ready = PatientPuzzlePrimaryActionStateReadoutPresenter.Present(PatientPuzzlePrimaryActionStateResolver.Initial());
            var previewedState = PatientPuzzlePrimaryActionStateResolver.AfterPreview(PatientPuzzlePrimaryActionStateResolver.Initial());
            var previewed = PatientPuzzlePrimaryActionStateReadoutPresenter.Present(previewedState);
            var committedState = PatientPuzzlePrimaryActionStateResolver.AfterCommit(previewedState);
            var committed = PatientPuzzlePrimaryActionStateReadoutPresenter.Present(committedState);
            var disabled = PatientPuzzlePrimaryActionStateReadoutPresenter.Present(PatientPuzzlePrimaryActionStateResolver.Disabled());

            var readyOk =
                ready.PreviewReadoutKey == "ui.primary_action.preview.available" &&
                ready.CommitReadoutKey == "ui.primary_action.commit.available" &&
                ready.SummaryReadoutKey == "ui.primary_action.summary.ready" &&
                ready.VisualTokenId == "primary_action.visual.ready" &&
                ready.IsInteractive;
            var previewedOk =
                previewed.PreviewReadoutKey == "ui.primary_action.preview.previewed" &&
                previewed.CommitReadoutKey == "ui.primary_action.commit.available" &&
                previewed.SummaryReadoutKey == "ui.primary_action.summary.previewed" &&
                previewed.VisualTokenId == "primary_action.visual.previewed" &&
                previewed.IsInteractive;
            var committedOk =
                committed.PreviewReadoutKey == "ui.primary_action.preview.previewed" &&
                committed.CommitReadoutKey == "ui.primary_action.commit.committed" &&
                committed.SummaryReadoutKey == "ui.primary_action.summary.committed" &&
                committed.VisualTokenId == "primary_action.visual.committed" &&
                !committed.IsInteractive;
            var disabledOk =
                disabled.PreviewReadoutKey == "ui.primary_action.preview.disabled" &&
                disabled.CommitReadoutKey == "ui.primary_action.commit.disabled" &&
                disabled.SummaryReadoutKey == "ui.primary_action.summary.disabled" &&
                disabled.VisualTokenId == "primary_action.visual.disabled" &&
                !disabled.IsInteractive;

            if (!readyOk || !previewedOk || !committedOk || !disabledOk)
            {
                Debug.LogWarning(
                    "PatientPuzzlePrimaryActionStateReadoutDebug failed" +
                    "\nreadyOk=" + readyOk +
                    "\npreviewedOk=" + previewedOk +
                    "\ncommittedOk=" + committedOk +
                    "\ndisabledOk=" + disabledOk +
                    "\nready=" + Format(ready) +
                    "\npreviewed=" + Format(previewed) +
                    "\ncommitted=" + Format(committed) +
                    "\ndisabled=" + Format(disabled));
                return;
            }

            Debug.Log(
                "PatientPuzzlePrimaryActionStateReadoutDebug OK" +
                "\nreadyToken=" + ready.VisualTokenId +
                "\npreviewedToken=" + previewed.VisualTokenId +
                "\ncommittedToken=" + committed.VisualTokenId +
                "\ndisabledToken=" + disabled.VisualTokenId +
                "\nreadyInteractive=True" +
                "\npreviewedInteractive=True" +
                "\ncommittedInteractive=False" +
                "\ndisabledInteractive=False" +
                "\nuiBinding=primary_action_state_readout_ready");
        }

        static string Format(PatientPuzzlePrimaryActionStateReadout readout)
        {
            return readout.PreviewReadoutKey + "/" +
                   readout.CommitReadoutKey + "/" +
                   readout.SummaryReadoutKey + "/" +
                   readout.VisualTokenId + "/interactive=" +
                   readout.IsInteractive;
        }
    }
}
#endif
