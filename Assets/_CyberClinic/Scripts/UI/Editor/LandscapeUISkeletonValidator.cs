#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace CyberClinic.UI.Editor
{
    public static class LandscapeUISkeletonValidator
    {
        const string PrefabPath = "Assets/_CyberClinic/UI/Prefabs/LandscapeUISkeleton.prefab";

        [MenuItem("Cyber Clinic/UI/Validate Landscape Skeleton Prefab")]
        public static void ValidatePrefab()
        {
            var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(PrefabPath);
            if (prefab == null)
            {
                Debug.LogWarning("LandscapeUISkeletonValidator failed: prefab missing at " + PrefabPath);
                return;
            }

            var canvas = prefab.GetComponent<Canvas>();
            var scaler = prefab.GetComponent<CanvasScaler>();
            var panels = prefab.GetComponentsInChildren<LandscapeUIPanel>(true);
            var localizedTexts = prefab.GetComponentsInChildren<CyberLocalizedText>(true);

            var hasFourPanels = panels.Length == 4;
            var hasFourLabels = localizedTexts.Length == 4;
            var hasLandscapeReference = scaler != null &&
                                       Mathf.Approximately(scaler.referenceResolution.x, 1920f) &&
                                       Mathf.Approximately(scaler.referenceResolution.y, 1080f);

            if (canvas == null || scaler == null || !hasFourPanels || !hasFourLabels || !hasLandscapeReference)
            {
                Debug.LogWarning(
                    "LandscapeUISkeletonValidator failed\n" +
                    $"hasCanvas={canvas != null}\n" +
                    $"hasScaler={scaler != null}\n" +
                    $"panelCount={panels.Length}\n" +
                    $"localizedTextCount={localizedTexts.Length}\n" +
                    $"referenceResolution={(scaler != null ? scaler.referenceResolution.ToString() : "missing")}");
                return;
            }

            Debug.Log(
                "LandscapeUISkeletonValidator OK\n" +
                $"prefabPath={PrefabPath}\n" +
                $"panelCount={panels.Length}\n" +
                $"localizedTextCount={localizedTexts.Length}\n" +
                $"referenceResolution={scaler.referenceResolution.x:0}x{scaler.referenceResolution.y:0}\n" +
                $"renderMode={canvas.renderMode}");
        }
    }
}
#endif
