#if UNITY_EDITOR
using System;
using CyberClinic.Procedures;
using UnityEditor;
using UnityEngine;

namespace CyberClinic.Feedback.Editor
{
    public static class ClinicFeedbackDebugMenu
    {
        [MenuItem("Cyber Clinic/Feedback/Validate Debug Cues")]
        public static void ValidateDebugCues()
        {
            var cues = LoadAllCues();
            if (cues.Length < 3)
            {
                Debug.LogWarning($"ClinicFeedbackDebug failed: cueCount={cues.Length}");
                return;
            }

            var routerObject = new GameObject("ClinicFeedbackDebugRouter");
            var router = routerObject.AddComponent<ClinicFeedbackRouter>();
            SetPrivateField(router, "_cues", cues);

            var scanOk = router.TryRoute(
                new ClinicFeedbackRequest(ClinicFeedbackEventId.BasicScan, OperationRiskBand.Safe, OperationOutcomeType.PreviewOnly, 0.4f, "debug.scan"),
                out var scanCue);

            var warningOk = router.TryRoute(
                new ClinicFeedbackRequest(ClinicFeedbackEventId.RiskPreviewUpdated, OperationRiskBand.Dangerous, OperationOutcomeType.PreviewOnly, 0.8f, "debug.warning"),
                out var warningCue);

            var resultOk = router.TryRoute(
                new ClinicFeedbackRequest(ClinicFeedbackEventId.OperationResult, OperationRiskBand.Uncertain, OperationOutcomeType.StableSuccess, 0.65f, "debug.result"),
                out var resultCue);

            UnityEngine.Object.DestroyImmediate(routerObject);

            if (!scanOk || !warningOk || !resultOk)
            {
                Debug.LogWarning(
                    "ClinicFeedbackDebug failed\n" +
                    $"scanOk={scanOk}\n" +
                    $"warningOk={warningOk}\n" +
                    $"resultOk={resultOk}");
                return;
            }

            Debug.Log(
                "ClinicFeedbackDebug OK\n" +
                $"cueCount={cues.Length}\n" +
                $"scanCueId={scanCue.Id}\n" +
                $"warningCueId={warningCue.Id}\n" +
                $"resultCueId={resultCue.Id}\n" +
                $"scanCategory={scanCue.Category}\n" +
                $"warningCategory={warningCue.Category}\n" +
                $"resultCategory={resultCue.Category}");
        }

        static ClinicFeedbackCueData[] LoadAllCues()
        {
            var guids = AssetDatabase.FindAssets("t:ClinicFeedbackCueData");
            var cues = new ClinicFeedbackCueData[guids.Length];
            var count = 0;

            for (var i = 0; i < guids.Length; i++)
            {
                var path = AssetDatabase.GUIDToAssetPath(guids[i]);
                var cue = AssetDatabase.LoadAssetAtPath<ClinicFeedbackCueData>(path);
                if (cue != null)
                {
                    cues[count++] = cue;
                }
            }

            if (count == cues.Length)
            {
                return cues;
            }

            var trimmed = new ClinicFeedbackCueData[count];
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
