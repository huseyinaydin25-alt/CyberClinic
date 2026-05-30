#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace CyberClinic.Slices.Editor
{
    public static class OperationEncounterModularFoundationValidator
    {
        [MenuItem("Cyber Clinic/Operation Encounter/Run M1.R Modular Foundation Debug")]
        public static void RunDebug()
        {
            var participant = new OperationEncounterParticipantDefinition(
                "debug_participant_street_netrunner",
                "archetype.street_netrunner",
                72);
            var procedure = new OperationEncounterProcedureDefinition(
                "debug_procedure_micro_install",
                "specialty.optic_calibration",
                38);
            var risk = new OperationEncounterRiskProfile(
                31,
                85,
                "risk.uncertain");
            var reward = new OperationEncounterRewardProfile(
                "reward_table.debug_operation_basic",
                90,
                5);
            var definition = new OperationEncounterDefinition(
                "debug_encounter_street_netrunner_optic_tune",
                "debug.v1",
                participant,
                procedure,
                risk,
                reward);

            var participantOk = participant.IsValid();
            var procedureOk = procedure.IsValid();
            var riskOk = risk.IsValid();
            var rewardOk = reward.IsValid();
            var definitionOk = definition.IsValid();

            var registry = OperationEncounterDefinitionRegistry.CreateDebugRegistry();
            OperationEncounterDefinition loaded;
            var foundLoaded = registry.TryGet("debug_encounter_street_netrunner_optic_tune", out loaded);
            var registryOk =
                registry.Count == 1 &&
                registry.Contains("debug_encounter_street_netrunner_optic_tune") &&
                foundLoaded &&
                loaded.IsValid() &&
                loaded.EncounterId == definition.EncounterId &&
                loaded.ContentVersion == "debug.v1" &&
                loaded.Participant.ParticipantId == participant.ParticipantId &&
                loaded.Procedure.ProcedureId == procedure.ProcedureId &&
                loaded.RiskProfile.MinimumRecommendedPower == 85 &&
                loaded.RewardProfile.RewardTableId == "reward_table.debug_operation_basic";

            var missingLookupOk = !registry.TryGet("missing.encounter", out _);

            if (!participantOk || !procedureOk || !riskOk || !rewardOk || !definitionOk || !registryOk || !missingLookupOk)
            {
                Debug.LogWarning(
                    "OperationEncounterModularFoundationDebug failed" +
                    "\nparticipantOk=" + participantOk +
                    "\nprocedureOk=" + procedureOk +
                    "\nriskOk=" + riskOk +
                    "\nrewardOk=" + rewardOk +
                    "\ndefinitionOk=" + definitionOk +
                    "\nregistryOk=" + registryOk +
                    "\nmissingLookupOk=" + missingLookupOk +
                    "\nregistryCount=" + registry.Count);
                return;
            }

            Debug.Log(
                "OperationEncounterModularFoundationDebug OK" +
                "\nparticipantDefinition=True" +
                "\nprocedureDefinition=True" +
                "\nriskProfile=True" +
                "\nrewardProfile=True" +
                "\nencounterDefinition=True" +
                "\nregistryCount=1" +
                "\nloadedEncounterId=" + loaded.EncounterId +
                "\ncontentVersion=" + loaded.ContentVersion +
                "\ndataDrivenReady=True" +
                "\nadminConfigReady=True" +
                "\nuiBinding=operation_encounter_modular_foundation_ready");
        }
    }
}
#endif
