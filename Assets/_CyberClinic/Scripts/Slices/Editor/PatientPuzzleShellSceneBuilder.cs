#if UNITY_EDITOR
using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CyberClinic.Slices.Editor
{
    public static class PatientPuzzleShellSceneBuilder
    {
        const string ScenePath = "Assets/_CyberClinic/Scenes/PatientPuzzleShell.unity";

        [MenuItem("Cyber Clinic/Slices/Create Patient Puzzle Shell Scene")]
        public static void CreateScene()
        {
            CreateSceneAsset(openAfterCreate: false);
        }

        [MenuItem("Cyber Clinic/Slices/Create Or Open Patient Puzzle Shell Scene")]
        public static void CreateOrOpenScene()
        {
            if (!File.Exists(ScenePath))
            {
                CreateSceneAsset(openAfterCreate: true);
                return;
            }

            EditorSceneManager.OpenScene(ScenePath, OpenSceneMode.Single);
            Selection.activeObject = AssetDatabase.LoadAssetAtPath<SceneAsset>(ScenePath);
            Debug.Log("PatientPuzzleShellSceneOpen OK\nscenePath=" + ScenePath + "\ncreated=False\nuiMode=production_intent_placeholder_shell");
        }

        static void CreateSceneAsset(bool openAfterCreate)
        {
            Directory.CreateDirectory("Assets/_CyberClinic/Scenes");
            var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
            scene.name = "PatientPuzzleShell";

            new GameObject("PatientPuzzleShellRuntime", typeof(PatientPuzzleShellRuntime));

            EditorSceneManager.SaveScene(scene, ScenePath);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            if (openAfterCreate)
            {
                EditorSceneManager.OpenScene(ScenePath, OpenSceneMode.Single);
                Selection.activeObject = AssetDatabase.LoadAssetAtPath<SceneAsset>(ScenePath);
            }

            Debug.Log("PatientPuzzleShellSceneBuilder OK\nscenePath=" + ScenePath + "\nruntimeCount=1\ncreated=True\nopened=" + openAfterCreate + "\nuiMode=production_intent_placeholder_shell");
        }
    }
}
#endif
