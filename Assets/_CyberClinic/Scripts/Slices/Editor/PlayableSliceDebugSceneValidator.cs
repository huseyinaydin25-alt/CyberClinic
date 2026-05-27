#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace CyberClinic.Slices.Editor
{
    public static class PlayableSliceDebugSceneValidator
    {
        const string ScenePath = "Assets/_CyberClinic/Scenes/PlayableSliceDebug.unity";

        [MenuItem("Cyber Clinic/Slices/Validate Playable Slice Debug Scene")]
        public static void ValidateScene()
        {
            var asset = AssetDatabase.LoadAssetAtPath<SceneAsset>(ScenePath);
            if (asset == null)
            {
                Debug.LogWarning("PlayableSliceDebugSceneValidator failed\nsceneMissing=True\nscenePath=" + ScenePath);
                return;
            }

            var scene = EditorSceneManager.OpenScene(ScenePath);
            var controllers = Object.FindObjectsByType<PatientPuzzleSliceDebugController>(FindObjectsSortMode.None);
            var valid = controllers != null && controllers.Length == 1;

            if (!valid)
            {
                Debug.LogWarning("PlayableSliceDebugSceneValidator failed\ncontrollerCount=" + (controllers == null ? 0 : controllers.Length));
                return;
            }

            Debug.Log("PlayableSliceDebugSceneValidator OK\nscenePath=" + ScenePath + "\ncontrollerCount=" + controllers.Length + "\nuiMode=OnGUI");
        }
    }
}
#endif
