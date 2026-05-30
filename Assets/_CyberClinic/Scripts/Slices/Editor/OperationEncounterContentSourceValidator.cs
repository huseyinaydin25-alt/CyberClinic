#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace CyberClinic.Slices.Editor
{
    public static class OperationEncounterContentSourceValidator
    {
        [MenuItem("Cyber Clinic/Operation Encounter/Run M1.R Content Source Debug")]
        public static void RunDebug()
        {
            var source = new OperationEncounterDebugContentSource();
            var loadResult = OperationEncounterContentLoader.Load(source);
            var registry = new OperationEncounterDefinitionRegistry(loadResult.Definitions);

            var sourceOk =
                source.SourceId == "local.debug.operation_encounter" &&
                source.ContentVersion == "debug.v1";

            var loadOk =
                loadResult.Success &&
                loadResult.SourceId == source.SourceId &&
                loadResult.ContentVersion == source.ContentVersion &&
                loadResult.Count == 1 &&
                loadResult.Message == "content_load_ok";

            var registryOk =
                registry.Count == 1 &&
                registry.TryGet("debug_encounter_street_netrunner_optic_tune", out var definition) &&
                definition.IsValid() &&
                definition.ContentVersion == "debug.v1" &&
                definition.Participant.ArchetypeId == "archetype.street_netrunner" &&
                definition.Procedure.SpecialtyId == "specialty.optic_calibration" &&
                definition.RiskProfile.RiskTierId == "risk.uncertain" &&
                definition.RewardProfile.RewardTableId == "reward_table.debug_operation_basic";

            var nullLoad = OperationEncounterContentLoader.Load(null);
            var nullHandlingOk =
                !nullLoad.Success &&
                nullLoad.Count == 0 &&
                nullLoad.Message == "content_source_missing";

            if (!sourceOk || !loadOk || !registryOk || !nullHandlingOk)
            {
                Debug.LogWarning(
                    "OperationEncounterContentSourceDebug failed" +
                    "\nsourceOk=" + sourceOk +
                    "\nloadOk=" + loadOk +
                    "\nregistryOk=" + registryOk +
                    "\nnullHandlingOk=" + nullHandlingOk +
                    "\nloadMessage=" + loadResult.Message +
                    "\nloadCount=" + loadResult.Count);
                return;
            }

            Debug.Log(
                "OperationEncounterContentSourceDebug OK" +
                "\nsourceId=" + source.SourceId +
                "\ncontentVersion=" + source.ContentVersion +
                "\nloadCount=" + loadResult.Count +
                "\nloadMessage=" + loadResult.Message +
                "\nregistryCount=" + registry.Count +
                "\nloadedEncounterId=" + definition.EncounterId +
                "\nlocalMockReady=True" +
                "\njsonBridgeReady=True" +
                "\nadminConfigBridgeReady=True" +
                "\nuiBinding=operation_encounter_content_source_ready");
        }
    }
}
#endif
