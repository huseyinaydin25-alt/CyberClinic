using UnityEngine;

namespace CyberClinic.Slices
{
    public static class PatientPuzzleShellStyle
    {
        public static readonly Color BackgroundColor = new Color(0.025f, 0.035f, 0.055f, 1f);
        public static readonly Color PanelColor = new Color(0.075f, 0.095f, 0.135f, 0.96f);
        public static readonly Color HeaderColor = new Color(0.13f, 0.18f, 0.24f, 0.98f);
        public static readonly Color AccentColor = new Color(0.10f, 0.32f, 0.42f, 0.98f);
        public static readonly Color TextColor = new Color(0.92f, 0.96f, 1f, 1f);
        public static readonly Color MutedTextColor = new Color(0.68f, 0.76f, 0.84f, 1f);

        public const int TitleFontSize = 32;
        public const int SubtitleFontSize = 18;
        public const int SectionHeaderFontSize = 19;
        public const int SectionBodyFontSize = 17;
        public const int FooterFontSize = 16;
        public const float HeaderHeight = 48f;
        public const float AccentBarWidth = 6f;

        public static readonly Vector2 HeaderTextOffsetMin = new Vector2(18f, 6f);
        public static readonly Vector2 HeaderTextOffsetMax = new Vector2(-18f, -6f);
        public static readonly Vector2 BodyTextOffsetMin = new Vector2(20f, 18f);
        public static readonly Vector2 BodyTextOffsetMax = new Vector2(-20f, -64f);

        public static bool HasRequiredStyle()
        {
            return
                IsVisible(BackgroundColor) &&
                IsVisible(PanelColor) &&
                IsVisible(HeaderColor) &&
                IsVisible(AccentColor) &&
                IsVisible(TextColor) &&
                IsVisible(MutedTextColor) &&
                TitleFontSize > 0 &&
                SubtitleFontSize > 0 &&
                SectionHeaderFontSize > 0 &&
                SectionBodyFontSize > 0 &&
                FooterFontSize > 0 &&
                HeaderHeight > 0f &&
                AccentBarWidth > 0f;
        }

        static bool IsVisible(Color color)
        {
            return color.a > 0f;
        }
    }
}
