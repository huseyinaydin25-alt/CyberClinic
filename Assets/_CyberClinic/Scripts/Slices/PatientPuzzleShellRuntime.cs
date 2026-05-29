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
            BuildShell(screenModel, PatientPuzzlePrimaryActionStateResolver.Initial());
        }

        public void BuildShell(
            PatientPuzzleSliceScreenModel screenModel,
            PatientPuzzlePrimaryActionState primaryActionState)
        {
            if (_built)
            {
                return;
            }

            EnsureCamera();
            EnsureEventSystem();

            var presentation = PatientPuzzleShellPresenter.Present(screenModel, primaryActionState);

            var root = new GameObject(PatientPuzzleShellLayout.RootName, typeof(Canvas), typeof(CanvasScaler), typeof(GraphicRaycaster));
            root.transform.SetParent(transform, false);
            root.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
            var scaler = root.GetComponent<CanvasScaler>();
            scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            scaler.referenceResolution = PatientPuzzleShellLayout.ReferenceResolution;
            scaler.matchWidthOrHeight = 0.5f;

            CreateFullScreenImage(root.transform, "ShellBackground", PatientPuzzleShellStyle.BackgroundColor);
            CreateText(root.transform, PatientPuzzleShellLocalizationKeys.ShellTitle, PatientPuzzleShellStyle.TitleFontSize, PatientPuzzleShellLayout.Title, Vector2.zero, Vector2.zero, TextAnchor.MiddleLeft, PatientPuzzleShellStyle.TextColor, FontStyle.Bold);
            CreateText(root.transform, PatientPuzzleShellLocalizationKeys.ShellSubtitlePlaceholder, PatientPuzzleShellStyle.SubtitleFontSize, PatientPuzzleShellLayout.Subtitle, Vector2.zero, Vector2.zero, TextAnchor.MiddleLeft, PatientPuzzleShellStyle.MutedTextColor, FontStyle.Normal);

            CreateSection(root.transform, PatientPuzzleShellLayout.PatientDossierAreaName, PatientPuzzleShellLocalizationKeys.PatientDossierTitle, presentation.PatientDossierBody, PatientPuzzleShellLayout.PatientDossier);
            CreateSection(root.transform, PatientPuzzleShellLayout.ProcedureDecisionAreaName, PatientPuzzleShellLocalizationKeys.ProcedureDecisionTitle, presentation.ProcedureDecisionBody, PatientPuzzleShellLayout.ProcedureDecision);
            CreateSection(root.transform, PatientPuzzleShellLayout.RiskAnalysisAreaName, PatientPuzzleShellLocalizationKeys.RiskAnalysisTitle, presentation.RiskAnalysisBody, PatientPuzzleShellLayout.RiskAnalysis);
            CreateSection(root.transform, PatientPuzzleShellLayout.OperationResultAreaName, PatientPuzzleShellLocalizationKeys.OperationResultTitle, presentation.OperationResultBody, PatientPuzzleShellLayout.OperationResult);
            CreateSection(root.transform, PatientPuzzleShellLayout.ActionFeedbackAreaName, PatientPuzzleShellLocalizationKeys.ActionFeedbackTitle, presentation.ActionFeedbackBody, PatientPuzzleShellLayout.ActionFeedback);
            CreateSection(root.transform, PatientPuzzleShellLayout.PrimaryActionAreaName, PatientPuzzleShellLocalizationKeys.PrimaryActionTitle, presentation.PrimaryActionBody, PatientPuzzleShellLayout.PrimaryAction);

            CreateText(root.transform, PatientPuzzleShellLocalizationKeys.FooterPlaceholder, PatientPuzzleShellStyle.FooterFontSize, PatientPuzzleShellLayout.Footer, Vector2.zero, Vector2.zero, TextAnchor.MiddleLeft, PatientPuzzleShellStyle.MutedTextColor, FontStyle.Normal);

            _built = true;
        }

        static void EnsureCamera()
        {
            if (Camera.main != null)
            {
                Camera.main.backgroundColor = PatientPuzzleShellStyle.BackgroundColor;
                return;
            }

            var cameraObject = new GameObject("Main Camera", typeof(Camera));
            cameraObject.tag = "MainCamera";
            var camera = cameraObject.GetComponent<Camera>();
            camera.clearFlags = CameraClearFlags.SolidColor;
            camera.backgroundColor = PatientPuzzleShellStyle.BackgroundColor;
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
            panel.GetComponent<Image>().color = PatientPuzzleShellStyle.PanelColor;

            var header = new GameObject("Header", typeof(RectTransform), typeof(Image));
            header.transform.SetParent(panel.transform, false);
            var headerRect = header.GetComponent<RectTransform>();
            headerRect.anchorMin = new Vector2(0f, 1f);
            headerRect.anchorMax = new Vector2(1f, 1f);
            headerRect.offsetMin = new Vector2(0f, -PatientPuzzleShellStyle.HeaderHeight);
            headerRect.offsetMax = Vector2.zero;
            header.GetComponent<Image>().color = PatientPuzzleShellStyle.HeaderColor;

            var accent = new GameObject("AccentBar", typeof(RectTransform), typeof(Image));
            accent.transform.SetParent(panel.transform, false);
            var accentRect = accent.GetComponent<RectTransform>();
            accentRect.anchorMin = new Vector2(0f, 0f);
            accentRect.anchorMax = new Vector2(0f, 1f);
            accentRect.offsetMin = Vector2.zero;
            accentRect.offsetMax = new Vector2(PatientPuzzleShellStyle.AccentBarWidth, 0f);
            accent.GetComponent<Image>().color = PatientPuzzleShellStyle.AccentColor;

            CreateText(header.transform, titleKey, PatientPuzzleShellStyle.SectionHeaderFontSize, new ShellAnchorRect(Vector2.zero, Vector2.one), PatientPuzzleShellStyle.HeaderTextOffsetMin, PatientPuzzleShellStyle.HeaderTextOffsetMax, TextAnchor.MiddleLeft, PatientPuzzleShellStyle.TextColor, FontStyle.Bold);
            CreateText(panel.transform, body, PatientPuzzleShellStyle.SectionBodyFontSize, new ShellAnchorRect(Vector2.zero, Vector2.one), PatientPuzzleShellStyle.BodyTextOffsetMin, PatientPuzzleShellStyle.BodyTextOffsetMax, TextAnchor.UpperLeft, PatientPuzzleShellStyle.TextColor, FontStyle.Normal);
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
