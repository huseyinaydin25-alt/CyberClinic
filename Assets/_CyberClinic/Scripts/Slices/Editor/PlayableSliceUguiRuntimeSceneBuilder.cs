#if UNITY_EDITOR
using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CyberClinic.Slices.Editor
{
    public static class PlayableSliceUguiRuntimeSceneBuilder
    {
        const string ScenePath = "Assets/_CyberClinic/Scenes/PlayableSliceUgui.unity";

        [MenuItem("Cyber Clinic/Slices/Create Playable Slice UGUI Scene")]
        public static void CreateScene()
        {
            Directory.CreateDirectory("Assets/_CyberClinic/Scenes");
            var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
            scene.name = "PlayableSliceUgui";

            new GameObject("PlayableSliceUguiRuntime", typeof(PlayableSliceUguiRuntime), typeof(PatientPuzzleSliceDebugController));

            EditorSceneManager.SaveScene(scene, ScenePath);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            Debug.Log("PlayableSliceUguiSceneBuilder OK\nscenePath=" + ScenePath + "\nruntimeCount=1\nuiMode=UGUI");
        }
    }
}
#endif
