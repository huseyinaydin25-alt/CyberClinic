#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace CyberClinic.Slices.Editor
{
    public static class PatientPuzzleShellSceneValidator
    {
        const string ScenePath = "Assets/_CyberClinic/Scenes/PatientPuzzleShell.unity";

        [MenuItem("Cyber Clinic/Slices/Validate Patient Puzzle Shell Scene")]
        public static void ValidateScene()
        {
            var sceneAsset = AssetDatabase.LoadAssetAtPath<SceneAsset>(ScenePath);
            if (sceneAsset == null)
            {
                Debug.LogWarning("PatientPuzzleShellSceneValidator failed\nscenePath=" + ScenePath + "\nsceneAssetExists=False");
                return;
            }

            var scene = EditorSceneManager.OpenScene(ScenePath, OpenSceneMode.Single);
            var runtimeCount = Object.FindObjectsByType<PatientPuzzleShellRuntime>(FindObjectsSortMode.None).Length;

            if (runtimeCount != 1)
            {
                Debug.LogWarning("PatientPuzzleShellSceneValidator failed\nscenePath=" + ScenePath + "\nruntimeCount=" + runtimeCount + "\nuiMode=production_intent_placeholder_shell");
                return;
            }

            Debug.Log("PatientPuzzleShellSceneValidator OK\nscenePath=" + ScenePath + "\nruntimeCount=" + runtimeCount + "\nsceneName=" + scene.name + "\nuiMode=production_intent_placeholder_shell");
        }
    }
}
#endif
