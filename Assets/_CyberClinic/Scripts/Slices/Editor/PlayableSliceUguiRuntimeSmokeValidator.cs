#if UNITY_EDITOR
using System.Reflection;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CyberClinic.Slices.Editor
{
    public static class PlayableSliceUguiRuntimeSmokeValidator
    {
        [MenuItem("Cyber Clinic/Slices/Run Playable Slice UGUI Runtime Smoke Test")]
        public static void RunSmokeTest()
        {
            EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);

            var host = new GameObject("PlayableSliceUguiSmokeHost");
            var runtime = host.AddComponent<PlayableSliceUguiRuntime>();

            InvokePrivate(runtime, "Awake");

            var controller = host.GetComponent<PatientPuzzleSliceDebugController>();
            InvokePrivate(controller, "Start");

            var root = GameObject.Find("PlayableSliceUguiRoot");
            var previewButton = FindButton("PreviewButton");
            var commitButton = FindButton("CommitButton");
            var previewStateText = FindChildText("PreviewStateChip");
            var commitStateText = FindChildText("CommitStateChip");
            var actionReadoutText = FindChildText("ActionReadout");

            if (root == null || controller == null || previewButton == null || commitButton == null || previewStateText == null || commitStateText == null || actionReadoutText == null)
            {
                Debug.LogWarning(
                    "PlayableSliceUguiRuntimeSmokeValidator failed" +
                    "\nrootExists=" + (root != null) +
                    "\ncontrollerExists=" + (controller != null) +
                    "\npreviewButtonExists=" + (previewButton != null) +
                    "\ncommitButtonExists=" + (commitButton != null) +
                    "\npreviewStateTextExists=" + (previewStateText != null) +
                    "\ncommitStateTextExists=" + (commitStateText != null) +
                    "\nactionReadoutTextExists=" + (actionReadoutText != null));
                return;
            }

            previewButton.onClick.Invoke();
            var previewStateAfterPreview = previewStateText.text;
            var commitStateAfterPreview = commitStateText.text;
            var actionReadoutAfterPreview = actionReadoutText.text;

            commitButton.onClick.Invoke();
            var previewStateAfterCommit = previewStateText.text;
            var commitStateAfterCommit = commitStateText.text;
            var actionReadoutAfterCommit = actionReadoutText.text;

            var canvasCount = Object.FindObjectsByType<Canvas>(FindObjectsSortMode.None).Length;
            var eventSystemCount = Object.FindObjectsByType<EventSystem>(FindObjectsSortMode.None).Length;
            var cameraExists = Camera.main != null;
            var previewOk = previewStateAfterPreview == "ui.slice.preview.state.active" && commitStateAfterPreview == "ui.slice.commit.state.idle";
            var commitOk = previewStateAfterCommit == "ui.slice.preview.state.idle" && commitStateAfterCommit == "ui.slice.commit.state.active";
            var previewReadoutOk = actionReadoutAfterPreview.Contains("lastAction=preview") && actionReadoutAfterPreview.Contains("stateId=preview.ready");
            var commitReadoutOk = actionReadoutAfterCommit.Contains("lastAction=commit") && actionReadoutAfterCommit.Contains("stateId=commit.done") && actionReadoutAfterCommit.Contains("creditsDelta=") && actionReadoutAfterCommit.Contains("reputationDelta=");

            if (!cameraExists || canvasCount != 1 || eventSystemCount != 1 || !previewOk || !commitOk || !previewReadoutOk || !commitReadoutOk)
            {
                Debug.LogWarning(
                    "PlayableSliceUguiRuntimeSmokeValidator failed" +
                    "\ncameraExists=" + cameraExists +
                    "\ncanvasCount=" + canvasCount +
                    "\neventSystemCount=" + eventSystemCount +
                    "\npreviewStateAfterPreview=" + previewStateAfterPreview +
                    "\ncommitStateAfterPreview=" + commitStateAfterPreview +
                    "\npreviewStateAfterCommit=" + previewStateAfterCommit +
                    "\ncommitStateAfterCommit=" + commitStateAfterCommit +
                    "\nactionReadoutAfterPreview=" + actionReadoutAfterPreview +
                    "\nactionReadoutAfterCommit=" + actionReadoutAfterCommit);
                return;
            }

            Debug.Log(
                "PlayableSliceUguiRuntimeSmokeValidator OK" +
                "\nrootExists=True" +
                "\ncanvasCount=" + canvasCount +
                "\neventSystemCount=" + eventSystemCount +
                "\ncameraExists=True" +
                "\npreviewButtonCount=1" +
                "\ncommitButtonCount=1" +
                "\npreviewStateAfterPreview=" + previewStateAfterPreview +
                "\ncommitStateAfterCommit=" + commitStateAfterCommit +
                "\nactionReadoutAfterPreview=" + actionReadoutAfterPreview +
                "\nactionReadoutAfterCommit=" + actionReadoutAfterCommit +
                "\nactionReadoutAfterCommitContains=lastAction=commit" +
                "\nuiMode=UGUI");
        }

        static void InvokePrivate(object target, string methodName)
        {
            var method = target.GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic);
            method?.Invoke(target, null);
        }

        static Button FindButton(string objectName)
        {
            var obj = GameObject.Find(objectName);
            return obj == null ? null : obj.GetComponent<Button>();
        }

        static Text FindChildText(string objectName)
        {
            var obj = GameObject.Find(objectName);
            return obj == null ? null : obj.GetComponentInChildren<Text>();
        }
    }
}
#endif
