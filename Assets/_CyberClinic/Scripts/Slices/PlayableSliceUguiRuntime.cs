using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CyberClinic.Slices
{
    public sealed class PlayableSliceUguiRuntime : MonoBehaviour
    {
        void Awake()
        {
            EnsureCamera();
            EnsureEventSystem();

            var root = new GameObject("PlayableSliceUguiRoot", typeof(Canvas), typeof(CanvasScaler), typeof(GraphicRaycaster));
            root.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
            var scaler = root.GetComponent<CanvasScaler>();
            scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            scaler.referenceResolution = new Vector2(1920, 1080);
            scaler.matchWidthOrHeight = 0.5f;

            var controller = gameObject.GetComponent<PatientPuzzleSliceDebugController>();
            if (controller == null)
            {
                controller = gameObject.AddComponent<PatientPuzzleSliceDebugController>();
            }

            var patientText = CreatePanel(root.transform, "PatientPanel", "ui.slice.patient.panel", new Vector2(0f, 0.5f), new Vector2(0.33f, 1f));
            var implantText = CreatePanel(root.transform, "ImplantPanel", "ui.slice.implant.panel", new Vector2(0f, 0f), new Vector2(0.33f, 0.5f));
            var riskText = CreatePanel(root.transform, "RiskPanel", "ui.slice.risk.panel", new Vector2(0.33f, 0.5f), new Vector2(0.66f, 1f));
            var resultText = CreatePanel(root.transform, "ResultPanel", "ui.slice.result.panel", new Vector2(0.66f, 0f), new Vector2(1f, 1f));
            var previewButton = CreateButton(root.transform, "PreviewButton", "ui.slice.preview.button", new Vector2(0.36f, 0.08f), new Vector2(0.48f, 0.16f));
            var commitButton = CreateButton(root.transform, "CommitButton", "ui.slice.commit.button", new Vector2(0.51f, 0.08f), new Vector2(0.63f, 0.16f));

            SetPrivateField(controller, "_patientText", patientText);
            SetPrivateField(controller, "_implantText", implantText);
            SetPrivateField(controller, "_riskText", riskText);
            SetPrivateField(controller, "_resultText", resultText);
            SetPrivateField(controller, "_previewButton", previewButton);
            SetPrivateField(controller, "_commitButton", commitButton);
            SetPrivateField(controller, "_showGuiFallback", false);
        }

        static void EnsureCamera()
        {
            if (Camera.main != null)
            {
                return;
            }

            var cameraObject = new GameObject("Main Camera", typeof(Camera));
            cameraObject.tag = "MainCamera";
            var camera = cameraObject.GetComponent<Camera>();
            camera.clearFlags = CameraClearFlags.SolidColor;
            camera.backgroundColor = Color.black;
            camera.orthographic = true;
            camera.orthographicSize = 5f;
            camera.transform.position = new Vector3(0f, 0f, -10f);
        }

        static void EnsureEventSystem()
        {
            if (Object.FindFirstObjectByType<EventSystem>() != null)
            {
                return;
            }

            new GameObject("EventSystem", typeof(EventSystem), typeof(StandaloneInputModule));
        }

        static Text CreatePanel(Transform parent, string name, string titleKey, Vector2 anchorMin, Vector2 anchorMax)
        {
            var panel = new GameObject(name, typeof(RectTransform), typeof(Image));
            panel.transform.SetParent(parent, false);
            var rect = panel.GetComponent<RectTransform>();
            rect.anchorMin = anchorMin;
            rect.anchorMax = anchorMax;
            rect.offsetMin = new Vector2(8f, 8f);
            rect.offsetMax = new Vector2(-8f, -8f);
            panel.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0.35f);
            CreateText(panel.transform, titleKey, 24, new Vector2(0f, 1f), new Vector2(1f, 1f), new Vector2(12f, -52f), new Vector2(-12f, -12f));
            return CreateText(panel.transform, "slice.pending", 20, Vector2.zero, Vector2.one, new Vector2(16f, 16f), new Vector2(-16f, -72f));
        }

        static Button CreateButton(Transform parent, string name, string labelKey, Vector2 anchorMin, Vector2 anchorMax)
        {
            var obj = new GameObject(name, typeof(RectTransform), typeof(Image), typeof(Button));
            obj.transform.SetParent(parent, false);
            var rect = obj.GetComponent<RectTransform>();
            rect.anchorMin = anchorMin;
            rect.anchorMax = anchorMax;
            rect.offsetMin = Vector2.zero;
            rect.offsetMax = Vector2.zero;
            obj.GetComponent<Image>().color = new Color(0.1f, 0.1f, 0.1f, 0.9f);
            var text = CreateText(obj.transform, labelKey, 20, Vector2.zero, Vector2.one, new Vector2(8f, 8f), new Vector2(-8f, -8f));
            text.alignment = TextAnchor.MiddleCenter;
            return obj.GetComponent<Button>();
        }

        static Text CreateText(Transform parent, string value, int fontSize, Vector2 anchorMin, Vector2 anchorMax, Vector2 offsetMin, Vector2 offsetMax)
        {
            var obj = new GameObject("Text", typeof(RectTransform), typeof(Text));
            obj.transform.SetParent(parent, false);
            var rect = obj.GetComponent<RectTransform>();
            rect.anchorMin = anchorMin;
            rect.anchorMax = anchorMax;
            rect.offsetMin = offsetMin;
            rect.offsetMax = offsetMax;
            var text = obj.GetComponent<Text>();
            text.text = value;
            text.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
            text.fontSize = fontSize;
            text.alignment = TextAnchor.UpperLeft;
            text.color = Color.white;
            return text;
        }

        static void SetPrivateField(object target, string fieldName, object value)
        {
            var field = target.GetType().GetField(fieldName, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            field?.SetValue(target, value);
        }
    }
}
