#if UNITY_EDITOR
using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CyberClinic.Slices.Editor
{
    public static class PlayableSliceDebugSceneBuilder
    {
        const string ScenePath = "Assets/_CyberClinic/Scenes/PlayableSliceDebug.unity";

        [MenuItem("Cyber Clinic/Slices/Create Playable Slice Debug Scene")]
        public static void CreateScene()
        {
            Directory.CreateDirectory("Assets/_CyberClinic/Scenes");

            var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
            scene.name = "PlayableSliceDebug";

            new GameObject("PatientPuzzleSliceDebugController", typeof(PatientPuzzleSliceDebugController));

            EditorSceneManager.SaveScene(scene, ScenePath);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            Debug.Log("PlayableSliceDebugSceneBuilder OK\nscenePath=" + ScenePath + "\ncontrollerCount=1\nuiMode=OnGUI");
        }
    }
}
#endif
