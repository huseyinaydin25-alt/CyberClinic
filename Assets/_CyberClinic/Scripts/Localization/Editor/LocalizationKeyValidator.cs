#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

namespace CyberClinic.Localization.Editor
{
    /// <summary>
    /// Heuristic scan for suspicious hardcoded player-facing strings in runtime scripts.
    /// Menu: Cyber Clinic/Localization/Validate Hardcoded Text
    /// </summary>
    public static class LocalizationKeyValidator
    {
        const string ScriptsRoot = "Assets/_CyberClinic/Scripts";

        static readonly Regex StringLiteralRegex = new Regex(
            @"@?""([^""\\]|\\.)*""",
            RegexOptions.Compiled);

        static readonly string[] IgnoredPathSegments =
        {
            "/Editor/",
            "\\Editor\\"
        };

        [MenuItem("Cyber Clinic/Localization/Validate Hardcoded Text")]
        public static void ValidateHardcodedText()
        {
            var issues = new List<string>();
            var scriptPaths = Directory.GetFiles(ScriptsRoot, "*.cs", SearchOption.AllDirectories);

            foreach (var path in scriptPaths)
            {
                if (IsIgnoredPath(path))
                {
                    continue;
                }

                var lines = File.ReadAllLines(path);
                for (var i = 0; i < lines.Length; i++)
                {
                    var line = lines[i];
                    if (ShouldSkipLine(line))
                    {
                        continue;
                    }

                    foreach (Match match in StringLiteralRegex.Matches(line))
                    {
                        var literal = Unescape(match.Value);
                        if (IsSuspiciousPlayerFacingString(literal))
                        {
                            issues.Add($"{path}:{i + 1}: {literal}");
                        }
                    }
                }
            }

            if (issues.Count == 0)
            {
                Debug.Log("LocalizationKeyValidator: No suspicious hardcoded player-facing strings found.");
                return;
            }

            Debug.LogWarning($"LocalizationKeyValidator: Found {issues.Count} suspicious string literal(s):\n" + string.Join("\n", issues));
        }

        static bool IsIgnoredPath(string path) =>
            path.IndexOf("/Editor/", StringComparison.OrdinalIgnoreCase) >= 0 ||
            path.IndexOf("\\Editor\\", StringComparison.OrdinalIgnoreCase) >= 0;

        static bool ShouldSkipLine(string line)
        {
            var trimmed = line.Trim();
            return trimmed.StartsWith("//", StringComparison.Ordinal) ||
                   trimmed.StartsWith("///", StringComparison.Ordinal) ||
                   trimmed.StartsWith("*", StringComparison.Ordinal) ||
                   trimmed.Contains("Debug.Log", StringComparison.Ordinal) ||
                   trimmed.Contains("LogWarning", StringComparison.Ordinal) ||
                   trimmed.Contains("LogError", StringComparison.Ordinal) ||
                   trimmed.Contains("CreateAssetMenu", StringComparison.Ordinal) ||
                   trimmed.Contains("MenuItem(", StringComparison.Ordinal);
        }

        static string Unescape(string quoted)
        {
            var inner = quoted;
            if (inner.StartsWith("@\"", StringComparison.Ordinal))
            {
                inner = inner.Substring(2, inner.Length - 3);
            }
            else if (inner.StartsWith("\"", StringComparison.Ordinal))
            {
                inner = inner.Substring(1, inner.Length - 2);
            }

            return inner.Replace("\\\"", "\"", StringComparison.Ordinal);
        }

        static bool IsSuspiciousPlayerFacingString(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 4)
            {
                return false;
            }

            if (LooksLikeLocalizationOrTechnicalId(value))
            {
                return false;
            }

            if (value.IndexOf('/') >= 0 || value.IndexOf('\\') >= 0)
            {
                return false;
            }

            if (value.StartsWith("CyberClinic.", StringComparison.Ordinal) ||
                value.StartsWith("Assets/", StringComparison.Ordinal) ||
                value.StartsWith("com.unity.", StringComparison.Ordinal))
            {
                return false;
            }

            if (!value.Contains(" ", StringComparison.Ordinal))
            {
                return false;
            }

            if (!ContainsLetter(value))
            {
                return false;
            }

            return true;
        }

        static bool LooksLikeLocalizationOrTechnicalId(string value)
        {
            if (Regex.IsMatch(value, @"^[a-z0-9_.]+$"))
            {
                return true;
            }

            if (value.StartsWith("ui.", StringComparison.Ordinal) ||
                value.StartsWith("patient.", StringComparison.Ordinal) ||
                value.StartsWith("implant.", StringComparison.Ordinal) ||
                value.StartsWith("procedure.", StringComparison.Ordinal) ||
                value.StartsWith("operation.", StringComparison.Ordinal) ||
                value.StartsWith("economy.", StringComparison.Ordinal) ||
                value.StartsWith("event.", StringComparison.Ordinal) ||
                value.StartsWith("cosmetic.", StringComparison.Ordinal) ||
                value.StartsWith("clinic.", StringComparison.Ordinal) ||
                value.StartsWith("error.", StringComparison.Ordinal) ||
                value.StartsWith("system.", StringComparison.Ordinal) ||
                value.StartsWith("tutorial.", StringComparison.Ordinal) ||
                value.StartsWith("math.", StringComparison.Ordinal) ||
                value.StartsWith("risk.", StringComparison.Ordinal) ||
                value.StartsWith("dialogue.", StringComparison.Ordinal))
            {
                return true;
            }

            return false;
        }

        static bool ContainsLetter(string value)
        {
            foreach (var c in value)
            {
                if (char.IsLetter(c))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
#endif
