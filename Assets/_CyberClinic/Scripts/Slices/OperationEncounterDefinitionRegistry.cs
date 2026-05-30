using System.Collections.Generic;

namespace CyberClinic.Slices
{
    public sealed class OperationEncounterDefinitionRegistry
    {
        readonly Dictionary<string, OperationEncounterDefinition> _definitions;

        public OperationEncounterDefinitionRegistry(IEnumerable<OperationEncounterDefinition> definitions)
        {
            _definitions = new Dictionary<string, OperationEncounterDefinition>();

            foreach (var definition in definitions)
            {
                if (!definition.IsValid())
                {
                    continue;
                }

                if (!_definitions.ContainsKey(definition.EncounterId))
                {
                    _definitions.Add(definition.EncounterId, definition);
                }
            }
        }

        public int Count => _definitions.Count;

        public bool TryGet(string encounterId, out OperationEncounterDefinition definition)
        {
            if (string.IsNullOrWhiteSpace(encounterId))
            {
                definition = default;
                return false;
            }

            return _definitions.TryGetValue(encounterId, out definition);
        }

        public bool Contains(string encounterId)
        {
            return TryGet(encounterId, out _);
        }

        public static OperationEncounterDefinitionRegistry CreateDebugRegistry()
        {
            return new OperationEncounterDefinitionRegistry(new[]
            {
                new OperationEncounterDefinition(
                    "debug_encounter_street_netrunner_optic_tune",
                    "debug.v1",
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
            });
        }
    }
}
