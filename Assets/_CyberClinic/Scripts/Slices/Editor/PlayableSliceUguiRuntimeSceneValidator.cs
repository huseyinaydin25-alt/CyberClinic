#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace CyberClinic.Slices.Editor
{
    public static class PlayableSliceUguiRuntimeSceneValidator
    {
        const string ScenePath = "Assets/_CyberClinic/Scenes/PlayableSliceUgui.unity";

        [MenuItem("Cyber Clinic/Slices/Validate Playable Slice UGUI Scene")]
        public static void ValidateScene()
        {
            var asset = AssetDatabase.LoadAssetAtPath<SceneAsset>(ScenePath);
            if (asset == null)
            {
                Debug.LogWarning("PlayableSliceUguiSceneValidator failed\nsceneMissing=True\nscenePath=" + ScenePath);
                return;
            }

            EditorSceneManager.OpenScene(ScenePath);
            var runtimes = Object.FindObjectsByType<PlayableSliceUguiRuntime>(FindObjectsSortMode.None);
            var controllers = Object.FindObjectsByType<PatientPuzzleSliceDebugController>(FindObjectsSortMode.None);
            var runtimeCount = runtimes == null ? 0 : runtimes.Length;
            var controllerCount = controllers == null ? 0 : controllers.Length;

            if (runtimeCount != 1 || controllerCount != 1)
            {
                Debug.LogWarning("PlayableSliceUguiSceneValidator failed\nruntimeCount=" + runtimeCount + "\ncontrollerCount=" + controllerCount);
                return;
            }

            Debug.Log("PlayableSliceUguiSceneValidator OK\nscenePath=" + ScenePath + "\nruntimeCount=" + runtimeCount + "\ncontrollerCount=" + controllerCount + "\nuiMode=UGUI");
        }
    }
}
#endif
