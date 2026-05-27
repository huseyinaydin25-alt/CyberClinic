#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace CyberClinic.Economy.Editor
{
    public static class EconomyDebugMenu
    {
        [MenuItem("Cyber Clinic/Economy/Run Day Flow Debug")]
        public static void RunDayFlowDebug()
        {
            var start = new ClinicEconomyState
            {
                Credits = 500,
                Reputation = 40,
                DayIndex = 4
            };

            var deltas = new[]
            {
                new EconomyDelta(180, 6, "debug.operation_success"),
                new EconomyDelta(-45, 0, "debug.supply_cost"),
                new EconomyDelta(0, -3, "debug.patient_unstable")
            };

            var report = DayReportBuilder.Build(
                start,
                deltas,
                acceptedPatients: 2,
                completedOperations: 1,
                failedOperations: 1);

            var deterministic =
                report.DayIndex == 4 &&
                report.StartingCredits == 500 &&
                report.EndingCredits == 635 &&
                report.StartingReputation == 40 &&
                report.EndingReputation == 43 &&
                report.AcceptedPatients == 2 &&
                report.CompletedOperations == 1 &&
                report.FailedOperations == 1 &&
                report.Deltas.Length == 3;

            if (!deterministic)
            {
                Debug.LogWarning("EconomyDebug failed");
                return;
            }

            Debug.Log(
                "EconomyDebug OK\n" +
                $"dayIndex={report.DayIndex}\n" +
                $"startingCredits={report.StartingCredits}\n" +
                $"endingCredits={report.EndingCredits}\n" +
                $"startingReputation={report.StartingReputation}\n" +
                $"endingReputation={report.EndingReputation}\n" +
                $"acceptedPatients={report.AcceptedPatients}\n" +
                $"completedOperations={report.CompletedOperations}\n" +
                $"failedOperations={report.FailedOperations}\n" +
                $"deltaCount={report.Deltas.Length}");
        }
    }
}
#endif
