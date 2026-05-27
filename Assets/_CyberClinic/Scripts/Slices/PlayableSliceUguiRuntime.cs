using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem.UI;
#endif

namespace CyberClinic.Slices
{
    public sealed class PlayableSliceUguiRuntime : MonoBehaviour
    {
        static readonly Color BackgroundColor = new Color(0.035f, 0.045f, 0.065f, 1f);
        static readonly Color PanelColor = new Color(0.09f, 0.11f, 0.15f, 0.94f);
        static readonly Color PanelHeaderColor = new Color(0.16f, 0.19f, 0.26f, 0.96f);
        static readonly Color ReadoutColor = new Color(0.06f, 0.075f, 0.105f, 0.96f);
        static readonly Color ButtonColor = new Color(0.14f, 0.16f, 0.22f, 0.96f);
        static readonly Color ButtonHighlightColor = new Color(0.22f, 0.27f, 0.36f, 1f);
        static readonly Color ButtonPressedColor = new Color(0.08f, 0.1f, 0.14f, 1f);
        static readonly Color TextColor = new Color(0.92f, 0.95f, 1f, 1f);
        static readonly Color MutedTextColor = new Color(0.72f, 0.78f, 0.88f, 1f);
        static readonly Color StatusIdleColor = new Color(0.12f, 0.14f, 0.18f, 0.92f);

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

            CreateFullScreenImage(root.transform, "DebugBackground", BackgroundColor);

            var controller = gameObject.GetComponent<PatientPuzzleSliceDebugController>();
            if (controller == null)
            {
                controller = gameObject.AddComponent<PatientPuzzleSliceDebugController>();
            }

            CreateText(root.transform, "Cyber Clinic Playable Slice Debug", 34, new Vector2(0.03f, 0.92f), new Vector2(0.97f, 0.985f), Vector2.zero, Vector2.zero, TextAnchor.MiddleLeft, TextColor, FontStyle.Bold);
            CreateText(root.transform, "ui.slice.debug.helper", 21, new Vector2(0.03f, 0.875f), new Vector2(0.97f, 0.925f), Vector2.zero, Vector2.zero, TextAnchor.MiddleLeft, MutedTextColor, FontStyle.Normal);

            var previewState = CreateStateChip(root.transform, "PreviewStateChip", "ui.slice.preview.state.idle", new Vector2(0.36f, 0.78f), new Vector2(0.58f, 0.85f));
            var commitState = CreateStateChip(root.transform, "CommitStateChip", "ui.slice.commit.state.idle", new Vector2(0.60f, 0.78f), new Vector2(0.82f, 0.85f));

            var patientText = CreatePanel(root.transform, "PatientPanel", "ui.slice.patient.panel", new Vector2(0.03f, 0.48f), new Vector2(0.31f, 0.84f));
            var implantText = CreatePanel(root.transform, "ImplantPanel", "ui.slice.implant.panel", new Vector2(0.03f, 0.18f), new Vector2(0.31f, 0.46f));
            var riskText = CreatePanel(root.transform, "RiskPanel", "ui.slice.risk.panel", new Vector2(0.34f, 0.18f), new Vector2(0.63f, 0.74f));
            var resultText = CreatePanel(root.transform, "ResultPanel", "ui.slice.result.panel", new Vector2(0.66f, 0.18f), new Vector2(0.97f, 0.74f));
            var actionReadoutText = CreateReadout(root.transform, "ActionReadout", "slice.pending", new Vector2(0.66f, 0.055f), new Vector2(0.97f, 0.145f));
            var previewButton = CreateButton(root.transform, "PreviewButton", "ui.slice.preview.button", new Vector2(0.34f, 0.06f), new Vector2(0.48f, 0.14f));
            var commitButton = CreateButton(root.transform, "CommitButton", "ui.slice.commit.button", new Vector2(0.50f, 0.06f), new Vector2(0.64f, 0.14f));

            SetPrivateField(controller, "_patientText", patientText);
            SetPrivateField(controller, "_implantText", implantText);
            SetPrivateField(controller, "_riskText", riskText);
            SetPrivateField(controller, "_resultText", resultText);
            SetPrivateField(controller, "_previewStateText", previewState.Label);
            SetPrivateField(controller, "_commitStateText", commitState.Label);
            SetPrivateField(controller, "_actionReadoutText", actionReadoutText);
            SetPrivateField(controller, "_previewStateImage", previewState.Background);
            SetPrivateField(controller, "_commitStateImage", commitState.Background);
            SetPrivateField(controller, "_previewButtonImage", previewButton.GetComponent<Image>());
            SetPrivateField(controller, "_commitButtonImage", commitButton.GetComponent<Image>());
            SetPrivateField(controller, "_previewButton", previewButton);
            SetPrivateField(controller, "_commitButton", commitButton);
            SetPrivateField(controller, "_showGuiFallback", false);
        }

        static void EnsureCamera()
        {
            if (Camera.main != null)
            {
                Camera.main.backgroundColor = BackgroundColor;
                return;
            }

            var cameraObject = new GameObject("Main Camera", typeof(Camera));
            cameraObject.tag = "MainCamera";
            var camera = cameraObject.GetComponent<Camera>();
            camera.clearFlags = CameraClearFlags.SolidColor;
            camera.backgroundColor = BackgroundColor;
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

            var eventSystemObject = new GameObject("EventSystem", typeof(EventSystem));
#if ENABLE_INPUT_SYSTEM
            eventSystemObject.AddComponent<InputSystemUIInputModule>();
#else
            eventSystemObject.AddComponent<StandaloneInputModule>();
#endif
        }

        static Text CreatePanel(Transform parent, string name, string titleKey, Vector2 anchorMin, Vector2 anchorMax)
        {
            var panel = new GameObject(name, typeof(RectTransform), typeof(Image));
            panel.transform.SetParent(parent, false);
            var rect = panel.GetComponent<RectTransform>();
            rect.anchorMin = anchorMin;
            rect.anchorMax = anchorMax;
            rect.offsetMin = Vector2.zero;
            rect.offsetMax = Vector2.zero;
            panel.GetComponent<Image>().color = PanelColor;

            var header = new GameObject("Header", typeof(RectTransform), typeof(Image));
            header.transform.SetParent(panel.transform, false);
            var headerRect = header.GetComponent<RectTransform>();
            headerRect.anchorMin = new Vector2(0f, 1f);
            headerRect.anchorMax = new Vector2(1f, 1f);
            headerRect.offsetMin = new Vector2(0f, -58f);
            headerRect.offsetMax = Vector2.zero;
            header.GetComponent<Image>().color = PanelHeaderColor;

            CreateText(header.transform, titleKey, 25, Vector2.zero, Vector2.one, new Vector2(18f, 8f), new Vector2(-18f, -8f), TextAnchor.MiddleLeft, TextColor, FontStyle.Bold);
            return CreateText(panel.transform, "slice.pending", 24, Vector2.zero, Vector2.one, new Vector2(22f, 22f), new Vector2(-22f, -78f), TextAnchor.UpperLeft, TextColor, FontStyle.Normal);
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
            var image = obj.GetComponent<Image>();
            image.color = ButtonColor;

            var button = obj.GetComponent<Button>();
            var colors = button.colors;
            colors.normalColor = ButtonColor;
            colors.highlightedColor = ButtonHighlightColor;
            colors.pressedColor = ButtonPressedColor;
            colors.selectedColor = ButtonHighlightColor;
            colors.disabledColor = new Color(0.08f, 0.08f, 0.1f, 0.55f);
            colors.colorMultiplier = 1f;
            button.colors = colors;

            CreateText(obj.transform, labelKey, 25, Vector2.zero, Vector2.one, new Vector2(8f, 8f), new Vector2(-8f, -8f), TextAnchor.MiddleCenter, TextColor, FontStyle.Bold);
            return button;
        }

        static StateChip CreateStateChip(Transform parent, string name, string labelKey, Vector2 anchorMin, Vector2 anchorMax)
        {
            var obj = new GameObject(name, typeof(RectTransform), typeof(Image));
            obj.transform.SetParent(parent, false);
            var rect = obj.GetComponent<RectTransform>();
            rect.anchorMin = anchorMin;
            rect.anchorMax = anchorMax;
            rect.offsetMin = Vector2.zero;
            rect.offsetMax = Vector2.zero;
            var image = obj.GetComponent<Image>();
            image.color = StatusIdleColor;
            var label = CreateText(obj.transform, labelKey, 23, Vector2.zero, Vector2.one, new Vector2(14f, 8f), new Vector2(-14f, -8f), TextAnchor.MiddleCenter, TextColor, FontStyle.Bold);
            return new StateChip(image, label);
        }

        static Text CreateReadout(Transform parent, string name, string value, Vector2 anchorMin, Vector2 anchorMax)
        {
            var panel = new GameObject(name, typeof(RectTransform), typeof(Image));
            panel.transform.SetParent(parent, false);
            var rect = panel.GetComponent<RectTransform>();
            rect.anchorMin = anchorMin;
            rect.anchorMax = anchorMax;
            rect.offsetMin = Vector2.zero;
            rect.offsetMax = Vector2.zero;
            panel.GetComponent<Image>().color = ReadoutColor;
            return CreateText(panel.transform, value, 16, Vector2.zero, Vector2.one, new Vector2(14f, 6f), new Vector2(-14f, -6f), TextAnchor.MiddleLeft, TextColor, FontStyle.Bold);
        }

        static void CreateFullScreenImage(Transform parent, string name, Color color)
        {
            var obj = new GameObject(name, typeof(RectTransform), typeof(Image));
            obj.transform.SetParent(parent, false);
            var rect = obj.GetComponent<RectTransform>();
            rect.anchorMin = Vector2.zero;
            rect.anchorMax = Vector2.one;
            rect.offsetMin = Vector2.zero;
            rect.offsetMax = Vector2.zero;
            obj.GetComponent<Image>().color = color;
        }

        static Text CreateText(Transform parent, string value, int fontSize, Vector2 anchorMin, Vector2 anchorMax, Vector2 offsetMin, Vector2 offsetMax, TextAnchor alignment, Color color, FontStyle fontStyle)
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
            text.alignment = alignment;
            text.color = color;
            text.fontStyle = fontStyle;
            text.horizontalOverflow = HorizontalWrapMode.Wrap;
            text.verticalOverflow = VerticalWrapMode.Overflow;
            return text;
        }

        static void SetPrivateField(object target, string fieldName, object value)
        {
            var field = target.GetType().GetField(fieldName, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            field?.SetValue(target, value);
        }

        readonly struct StateChip
        {
            public StateChip(Image background, Text label)
            {
                Background = background;
                Label = label;
            }

            public Image Background { get; }
            public Text Label { get; }
        }
    }
}
