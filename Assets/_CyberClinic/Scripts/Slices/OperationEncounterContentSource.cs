using System.Collections.Generic;

namespace CyberClinic.Slices
{
    public interface IOperationEncounterContentSource
    {
        string SourceId { get; }
        string ContentVersion { get; }
        IReadOnlyList<OperationEncounterDefinition> LoadDefinitions();
    }

    public readonly struct OperationEncounterContentLoadResult
    {
        public OperationEncounterContentLoadResult(
            string sourceId,
            string contentVersion,
            IReadOnlyList<OperationEncounterDefinition> definitions,
            bool success,
            string message)
        {
            SourceId = sourceId;
            ContentVersion = contentVersion;
            Definitions = definitions;
            Success = success;
            Message = message;
        }

        public string SourceId { get; }
        public string ContentVersion { get; }
        public IReadOnlyList<OperationEncounterDefinition> Definitions { get; }
        public bool Success { get; }
        public string Message { get; }
        public int Count => Definitions == null ? 0 : Definitions.Count;
    }

    public static class OperationEncounterContentLoader
    {
        public static OperationEncounterContentLoadResult Load(IOperationEncounterContentSource source)
        {
            if (source == null)
            {
                return new OperationEncounterContentLoadResult(
                    string.Empty,
                    string.Empty,
                    new OperationEncounterDefinition[0],
                    false,
                    "content_source_missing");
            }

            var definitions = source.LoadDefinitions() ?? new OperationEncounterDefinition[0];
            var validCount = 0;

            for (int i = 0; i < definitions.Count; i++)
            {
                if (definitions[i].IsValid())
                {
                    validCount++;
                }
            }

            var success = validCount == definitions.Count && definitions.Count > 0;
            return new OperationEncounterContentLoadResult(
                source.SourceId,
                source.ContentVersion,
                definitions,
                success,
                success ? "content_load_ok" : "content_load_invalid");
        }
    }

    public sealed class OperationEncounterDebugContentSource : IOperationEncounterContentSource
    {
        public string SourceId => "local.debug.operation_encounter";
        public string ContentVersion => "debug.v1";

        public IReadOnlyList<OperationEncounterDefinition> LoadDefinitions()
        {
            return new[]
            {
                new OperationEncounterDefinition(
                    "debug_encounter_street_netrunner_optic_tune",
                    ContentVersion,
                    new OperationEncounterParticipantDefinition(
                        "debug_participant_street_netrunner",
                        "archetype.street_netrunner",
                        72),
                    new OperationEncounterProcedureDefinition(
                        "debug_procedure_micro_install",
                        "specialty.optic_calibration",
                        38),
                    new OperationEncounterRiskProfile(
                        31,
                        85,
                        "risk.uncertain"),
                    new OperationEncounterRewardProfile(
                        "reward_table.debug_operation_basic",
                        90,
                        5))
            };
        }
    }
}
