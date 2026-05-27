using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem.UI;
#endif

namespace CyberClinic.Slices
{
    public sealed class PatientPuzzleShellRuntime : MonoBehaviour
    {
        static readonly Color BackgroundColor = new Color(0.025f, 0.035f, 0.055f, 1f);
        static readonly Color PanelColor = new Color(0.075f, 0.095f, 0.135f, 0.96f);
        static readonly Color HeaderColor = new Color(0.13f, 0.18f, 0.24f, 0.98f);
        static readonly Color AccentColor = new Color(0.10f, 0.32f, 0.42f, 0.98f);
        static readonly Color TextColor = new Color(0.92f, 0.96f, 1f, 1f);
        static readonly Color MutedTextColor = new Color(0.68f, 0.76f, 0.84f, 1f);

        bool _built;

        void Awake()
        {
            EnsureBuiltDebugShell();
        }

        public void EnsureBuiltDebugShell()
        {
            if (_built)
            {
                return;
            }

            BuildShell(PatientPuzzleSliceScreenModelBuilder.BuildDebugScreenModel());
        }

        public void BuildShell(PatientPuzzleSliceScreenModel screenModel)
        {
            if (_built)
            {
                return;
            }

            EnsureCamera();
            EnsureEventSystem();

            var presentation = PatientPuzzleShellPresenter.Present(screenModel);

            var root = new GameObject(PatientPuzzleShellLayout.RootName, typeof(Canvas), typeof(CanvasScaler), typeof(GraphicRaycaster));
            root.transform.SetParent(transform, false);
            root.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
            var scaler = root.GetComponent<CanvasScaler>();
            scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            scaler.referenceResolution = PatientPuzzleShellLayout.ReferenceResolution;
            scaler.matchWidthOrHeight = 0.5f;

            CreateFullScreenImage(root.transform, "ShellBackground", BackgroundColor);
            CreateText(root.transform, PatientPuzzleShellLocalizationKeys.ShellTitle, 32, PatientPuzzleShellLayout.Title, Vector2.zero, Vector2.zero, TextAnchor.MiddleLeft, TextColor, FontStyle.Bold);
            CreateText(root.transform, PatientPuzzleShellLocalizationKeys.ShellSubtitlePlaceholder, 18, PatientPuzzleShellLayout.Subtitle, Vector2.zero, Vector2.zero, TextAnchor.MiddleLeft, MutedTextColor, FontStyle.Normal);

            CreateSection(root.transform, PatientPuzzleShellLayout.PatientDossierAreaName, PatientPuzzleShellLocalizationKeys.PatientDossierTitle, presentation.PatientDossierBody, PatientPuzzleShellLayout.PatientDossier);
            CreateSection(root.transform, PatientPuzzleShellLayout.ProcedureDecisionAreaName, PatientPuzzleShellLocalizationKeys.ProcedureDecisionTitle, presentation.ProcedureDecisionBody, PatientPuzzleShellLayout.ProcedureDecision);
            CreateSection(root.transform, PatientPuzzleShellLayout.RiskAnalysisAreaName, PatientPuzzleShellLocalizationKeys.RiskAnalysisTitle, presentation.RiskAnalysisBody, PatientPuzzleShellLayout.RiskAnalysis);
            CreateSection(root.transform, PatientPuzzleShellLayout.OperationResultAreaName, PatientPuzzleShellLocalizationKeys.OperationResultTitle, presentation.OperationResultBody, PatientPuzzleShellLayout.OperationResult);
            CreateSection(root.transform, PatientPuzzleShellLayout.ActionFeedbackAreaName, PatientPuzzleShellLocalizationKeys.ActionFeedbackTitle, presentation.ActionFeedbackBody, PatientPuzzleShellLayout.ActionFeedback);

            CreateText(root.transform, PatientPuzzleShellLocalizationKeys.FooterPlaceholder, 16, PatientPuzzleShellLayout.Footer, Vector2.zero, Vector2.zero, TextAnchor.MiddleLeft, MutedTextColor, FontStyle.Normal);

            _built = true;
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

        static void CreateSection(Transform parent, string name, string titleKey, string body, ShellAnchorRect anchor)
        {
            var panel = new GameObject(name, typeof(RectTransform), typeof(Image));
            panel.transform.SetParent(parent, false);
            var rect = panel.GetComponent<RectTransform>();
            rect.anchorMin = anchor.Min;
            rect.anchorMax = anchor.Max;
            rect.offsetMin = Vector2.zero;
            rect.offsetMax = Vector2.zero;
            panel.GetComponent<Image>().color = PanelColor;

            var header = new GameObject("Header", typeof(RectTransform), typeof(Image));
            header.transform.SetParent(panel.transform, false);
            var headerRect = header.GetComponent<RectTransform>();
            headerRect.anchorMin = new Vector2(0f, 1f);
            headerRect.anchorMax = new Vector2(1f, 1f);
            headerRect.offsetMin = new Vector2(0f, -48f);
            headerRect.offsetMax = Vector2.zero;
            header.GetComponent<Image>().color = HeaderColor;

            var accent = new GameObject("AccentBar", typeof(RectTransform), typeof(Image));
            accent.transform.SetParent(panel.transform, false);
            var accentRect = accent.GetComponent<RectTransform>();
            accentRect.anchorMin = new Vector2(0f, 0f);
            accentRect.anchorMax = new Vector2(0f, 1f);
            accentRect.offsetMin = Vector2.zero;
            accentRect.offsetMax = new Vector2(6f, 0f);
            accent.GetComponent<Image>().color = AccentColor;

            CreateText(header.transform, titleKey, 19, new ShellAnchorRect(Vector2.zero, Vector2.one), new Vector2(18f, 6f), new Vector2(-18f, -6f), TextAnchor.MiddleLeft, TextColor, FontStyle.Bold);
            CreateText(panel.transform, body, 17, new ShellAnchorRect(Vector2.zero, Vector2.one), new Vector2(20f, 18f), new Vector2(-20f, -64f), TextAnchor.UpperLeft, TextColor, FontStyle.Normal);
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

        static Text CreateText(Transform parent, string value, int fontSize, ShellAnchorRect anchor, Vector2 offsetMin, Vector2 offsetMax, TextAnchor alignment, Color color, FontStyle fontStyle)
        {
            var obj = new GameObject("Text", typeof(RectTransform), typeof(Text));
            obj.transform.SetParent(parent, false);
            var rect = obj.GetComponent<RectTransform>();
            rect.anchorMin = anchor.Min;
            rect.anchorMax = anchor.Max;
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
    }
}
