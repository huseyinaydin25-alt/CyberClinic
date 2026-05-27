#if UNITY_EDITOR
using System;
using CyberClinic.Procedures;
using UnityEditor;
using UnityEngine;

namespace CyberClinic.Audio.Editor
{
    public static class ClinicAudioDebugMenu
    {
        [MenuItem("Cyber Clinic/Audio/Validate Debug Cues")]
        public static void ValidateDebugCues()
        {
            var cues = LoadAllCues();
            if (cues.Length < 3)
            {
                Debug.LogWarning($"ClinicAudioDebug failed: cueCount={cues.Length}");
                return;
            }

            var libraryObject = new GameObject("ClinicAudioDebugLibrary");
            var library = libraryObject.AddComponent<ClinicAudioCueLibrary>();
            SetPrivateField(library, "_cues", cues);

            var scanOk = library.TryFind(
                new ClinicAudioRequest(ClinicAudioEventId.ScanStart, ClinicAudioCategory.Scan, OperationRiskBand.Safe, OperationOutcomeType.PreviewOnly, 0.4f, "debug.scan"),
                out var scanCue);

            var warningOk = library.TryFind(
                new ClinicAudioRequest(ClinicAudioEventId.WarningPulse, ClinicAudioCategory.Warning, OperationRiskBand.Dangerous, OperationOutcomeType.PreviewOnly, 0.8f, "debug.warning"),
                out var warningCue);

            var successOk = library.TryFind(
                new ClinicAudioRequest(ClinicAudioEventId.OperationSuccess, ClinicAudioCategory.Result, OperationRiskBand.Stable, OperationOutcomeType.StableSuccess, 0.7f, "debug.success"),
                out var successCue);

            UnityEngine.Object.DestroyImmediate(libraryObject);

            if (!scanOk || !warningOk || !successOk)
            {
                Debug.LogWarning(
                    "ClinicAudioDebug failed\n" +
                    $"scanOk={scanOk}\n" +
                    $"warningOk={warningOk}\n" +
                    $"successOk={successOk}");
                return;
            }

            Debug.Log(
                "ClinicAudioDebug OK\n" +
                $"cueCount={cues.Length}\n" +
                $"scanCueId={scanCue.Id}\n" +
                $"warningCueId={warningCue.Id}\n" +
                $"successCueId={successCue.Id}\n" +
                $"scanCategory={scanCue.Category}\n" +
                $"warningCategory={warningCue.Category}\n" +
                $"successCategory={successCue.Category}\n" +
                $"scanAddress={scanCue.ClipAddress}\n" +
                $"warningAddress={warningCue.ClipAddress}\n" +
                $"successAddress={successCue.ClipAddress}");
        }

        static ClinicAudioCueData[] LoadAllCues()
        {
            var guids = AssetDatabase.FindAssets("t:ClinicAudioCueData");
            var cues = new ClinicAudioCueData[guids.Length];
            var count = 0;

            for (var i = 0; i < guids.Length; i++)
            {
                var path = AssetDatabase.GUIDToAssetPath(guids[i]);
                var cue = AssetDatabase.LoadAssetAtPath<ClinicAudioCueData>(path);
                if (cue != null)
                {
                    cues[count++] = cue;
                }
            }

            if (count == cues.Length)
            {
                return cues;
            }

            var trimmed = new ClinicAudioCueData[count];
            Array.Copy(cues, trimmed, count);
            return trimmed;
        }

        static void SetPrivateField(object target, string fieldName, object value)
        {
            var field = target.GetType().GetField(fieldName, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            field?.SetValue(target, value);
        }
    }
}
#endif
