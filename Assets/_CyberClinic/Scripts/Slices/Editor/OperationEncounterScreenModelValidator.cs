#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace CyberClinic.Slices.Editor
{
    public static class OperationEncounterScreenModelValidator
    {
        [MenuItem("Cyber Clinic/Operation Encounter/Run M1.R Screen Model Debug")]
        public static void RunDebug()
        {
            var source = new OperationEncounterDebugContentSource();
            var screenModel = OperationEncounterScreenModelBuilder.FromContentSource(
                source,
                "debug_encounter_street_netrunner_optic_tune");

            var identityOk =
                screenModel.Identity.EncounterId == "debug_encounter_street_netrunner_optic_tune" &&
                screenModel.Identity.ContentVersion == "debug.v1" &&
                screenModel.Identity.SourceId == "local.debug.operation_encounter";

            var subjectOk =
                screenModel.Subject.ParticipantId == "debug_participant_street_netrunner" &&
                screenModel.Subject.ArchetypeId == "archetype.street_netrunner" &&
                screenModel.Subject.StabilityScore == 72;

            var actionOk =
                screenModel.Action.ProcedureId == "debug_procedure_micro_install" &&
                screenModel.Action.SpecialtyId == "specialty.optic_calibration" &&
                screenModel.Action.DifficultyScore == 38;

            var riskOk =
                screenModel.Risk.RiskTierId == "risk.uncertain" &&
                screenModel.Risk.BaseRiskScore == 31 &&
                screenModel.Risk.MinimumRecommendedPower == 85;

            var rewardOk =
                screenModel.Reward.RewardTableId == "reward_table.debug_operation_basic" &&
                screenModel.Reward.BaseCreditReward == 90 &&
                screenModel.Reward.BaseReputationReward == 5;

            var validOk = screenModel.IsValid();

            var missing = OperationEncounterScreenModelBuilder.FromContentSource(
                source,
                "missing.encounter");
            var missingOk = !missing.IsValid();

            if (!identityOk || !subjectOk || !actionOk || !riskOk || !rewardOk || !validOk || !missingOk)
            {
                Debug.LogWarning(
                    "OperationEncounterScreenModelDebug failed" +
                    "\nidentityOk=" + identityOk +
                    "\nsubjectOk=" + subjectOk +
                    "\nactionOk=" + actionOk +
                    "\nriskOk=" + riskOk +
                    "\nrewardOk=" + rewardOk +
                    "\nvalidOk=" + validOk +
                    "\nmissingOk=" + missingOk);
                return;
            }

            Debug.Log(
                "OperationEncounterScreenModelDebug OK" +
                "\nencounterId=" + screenModel.Identity.EncounterId +
                "\ncontentVersion=" + screenModel.Identity.ContentVersion +
                "\nsourceId=" + screenModel.Identity.SourceId +
                "\nparticipantId=" + screenModel.Subject.ParticipantId +
                "\nprocedureId=" + screenModel.Action.ProcedureId +
                "\nriskTier=" + screenModel.Risk.RiskTierId +
                "\nrewardTableId=" + screenModel.Reward.RewardTableId +
                "\ncanonicalScreenModel=True" +
                "\nmissingLookupSafe=True" +
                "\nuiBinding=operation_encounter_screen_model_ready");
        }
    }
}
#endif
