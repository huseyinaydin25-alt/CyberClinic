#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace CyberClinic.Slices.Editor
{
    public static class PatientPuzzleShellStyleValidator
    {
        [MenuItem("Cyber Clinic/Slices/Run Patient Puzzle Shell Style Debug")]
        public static void RunDebug()
        {
            var styleOk = PatientPuzzleShellStyle.HasRequiredStyle();
            var fontSizesOk =
                PatientPuzzleShellStyle.TitleFontSize == 32 &&
                PatientPuzzleShellStyle.SubtitleFontSize == 18 &&
                PatientPuzzleShellStyle.SectionHeaderFontSize == 19 &&
                PatientPuzzleShellStyle.SectionBodyFontSize == 17 &&
                PatientPuzzleShellStyle.FooterFontSize == 16;
            var dimensionsOk = PatientPuzzleShellStyle.HeaderHeight == 48f && PatientPuzzleShellStyle.AccentBarWidth == 6f;
            var colorsOk =
                PatientPuzzleShellStyle.BackgroundColor.a > 0f &&
                PatientPuzzleShellStyle.PanelColor.a > 0f &&
                PatientPuzzleShellStyle.HeaderColor.a > 0f &&
                PatientPuzzleShellStyle.AccentColor.a > 0f &&
                PatientPuzzleShellStyle.TextColor.a > 0f &&
                PatientPuzzleShellStyle.MutedTextColor.a > 0f;

            if (!styleOk || !fontSizesOk || !dimensionsOk || !colorsOk)
            {
                Debug.LogWarning(
                    "PatientPuzzleShellStyleDebug failed" +
                    "\nstyleOk=" + styleOk +
                    "\nfontSizesOk=" + fontSizesOk +
                    "\ndimensionsOk=" + dimensionsOk +
                    "\ncolorsOk=" + colorsOk);
                return;
            }

            Debug.Log(
                "PatientPuzzleShellStyleDebug OK" +
                "\nstyleOk=True" +
                "\ntitleFontSize=" + PatientPuzzleShellStyle.TitleFontSize +
                "\nsubtitleFontSize=" + PatientPuzzleShellStyle.SubtitleFontSize +
                "\nsectionHeaderFontSize=" + PatientPuzzleShellStyle.SectionHeaderFontSize +
                "\nsectionBodyFontSize=" + PatientPuzzleShellStyle.SectionBodyFontSize +
                "\nfooterFontSize=" + PatientPuzzleShellStyle.FooterFontSize +
                "\nheaderHeight=" + PatientPuzzleShellStyle.HeaderHeight.ToString("F0") +
                "\naccentBarWidth=" + PatientPuzzleShellStyle.AccentBarWidth.ToString("F0") +
                "\nuiBinding=shell_style_contract_ready");
        }
    }
}
#endif
