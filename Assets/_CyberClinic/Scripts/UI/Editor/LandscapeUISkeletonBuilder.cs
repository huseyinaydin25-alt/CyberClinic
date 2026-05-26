#if UNITY_EDITOR
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace CyberClinic.UI.Editor
{
    public static class LandscapeUISkeletonBuilder
    {
        const string PrefabPath = "Assets/_CyberClinic/UI/Prefabs/LandscapeUISkeleton.prefab";

        [MenuItem("Cyber Clinic/UI/Create Landscape Skeleton Prefab")]
        public static void CreatePrefab()
        {
            Directory.CreateDirectory("Assets/_CyberClinic/UI/Prefabs");

            var root = new GameObject("LandscapeUISkeleton", typeof(Canvas), typeof(CanvasScaler), typeof(GraphicRaycaster));
            var canvas = root.GetComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;

            var scaler = root.GetComponent<CanvasScaler>();
            scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            scaler.referenceResolution = new Vector2(1920, 1080);
            scaler.matchWidthOrHeight = 0.5f;

            CreatePanel(root.transform, LandscapeUIScreenId.PatientFile, "ui.screen.patient_file.title", new Vector2(0f, 0f), new Vector2(0.33f, 1f));
            CreatePanel(root.transform, LandscapeUIScreenId.ImplantSelection, "ui.screen.implant_selection.title", new Vector2(0.33f, 0f), new Vector2(0.66f, 0.5f));
            CreatePanel(root.transform, LandscapeUIScreenId.RiskPreview, "ui.screen.risk_preview.title", new Vector2(0.33f, 0.5f), new Vector2(0.66f, 1f));
            CreatePanel(root.transform, LandscapeUIScreenId.ResultPanel, "ui.screen.result_panel.title", new Vector2(0.66f, 0f), new Vector2(1f, 1f));

            PrefabUtility.SaveAsPrefabAsset(root, PrefabPath);
            Object.DestroyImmediate(root);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            Debug.Log("LandscapeUISkeletonBuilder OK\nprefabPath=" + PrefabPath + "\npanelCount=4\nreferenceResolution=1920x1080");
        }

        static void CreatePanel(Transform parent, LandscapeUIScreenId id, string titleKey, Vector2 anchorMin, Vector2 anchorMax)
        {
            var panel = new GameObject(id.ToString(), typeof(RectTransform), typeof(Image), typeof(LandscapeUIPanel));
            panel.transform.SetParent(parent, false);
            var rect = panel.GetComponent<RectTransform>();
            rect.anchorMin = anchorMin;
            rect.anchorMax = anchorMax;
            rect.offsetMin = new Vector2(8f, 8f);
            rect.offsetMax = new Vector2(-8f, -8f);

            var image = panel.GetComponent<Image>();
            image.color = new Color(0f, 0f, 0f, 0.35f);

            var marker = panel.GetComponent<LandscapeUIPanel>();
            SetPrivateField(marker, "_panelId", id);
            SetPrivateField(marker, "_technicalId", "ui.panel." + id.ToString().ToLowerInvariant());

            CreateLabel(panel.transform, titleKey, new Vector2(0f, 1f), new Vector2(1f, 1f), new Vector2(0f, -54f));
        }

        static void CreateLabel(Transform parent, string key, Vector2 anchorMin, Vector2 anchorMax, Vector2 offsetMax)
        {
            var label = new GameObject("Title", typeof(RectTransform), typeof(Text), typeof(CyberLocalizedText));
            label.transform.SetParent(parent, false);
            var rect = label.GetComponent<RectTransform>();
            rect.anchorMin = anchorMin;
            rect.anchorMax = anchorMax;
            rect.offsetMin = new Vector2(12f, offsetMax.y);
            rect.offsetMax = new Vector2(-12f, -12f);

            var text = label.GetComponent<Text>();
            text.text = key;
            text.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
            text.fontSize = 24;
            text.alignment = TextAnchor.MiddleLeft;
            text.color = Color.white;

            var localized = label.GetComponent<CyberLocalizedText>();
            SetPrivateField(localized, "_text", CyberClinic.Localization.LocalizedTextRef.FromKey(key));
        }

        static void SetPrivateField(object target, string fieldName, object value)
        {
            var field = target.GetType().GetField(fieldName, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            field?.SetValue(target, value);
        }
    }
}
#endif
