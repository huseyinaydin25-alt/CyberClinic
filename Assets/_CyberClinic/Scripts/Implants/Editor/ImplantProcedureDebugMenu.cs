#if UNITY_EDITOR
using CyberClinic.Procedures;
using UnityEditor;
using UnityEngine;

namespace CyberClinic.Implants.Editor
{
    /// <summary>Editor-only data smoke test for M4 implant/procedure assets (technical log output only).</summary>
    public static class ImplantProcedureDebugMenu
    {
        const string ImplantSearch = "t:ImplantData";
        const string ProcedureSearch = "t:ProcedureData";
        const string CompatibilityRuleSearch = "t:ImplantCompatibilityRuleData";
        const string VisualVariantSearch = "t:ImplantVisualVariantData";
        const string ProcedureCompatibilitySearch = "t:ProcedureImplantCompatibilityData";

        [MenuItem("Cyber Clinic/Implants/Validate Debug Data")]
        public static void ValidateDebugData()
        {
            var implants = LoadAll<ImplantData>(ImplantSearch);
            var procedures = LoadAll<ProcedureData>(ProcedureSearch);
            var compatibilityRules = LoadAll<ImplantCompatibilityRuleData>(CompatibilityRuleSearch);
            var visualVariants = LoadAll<ImplantVisualVariantData>(VisualVariantSearch);
            var procedureCompatibilities = LoadAll<ProcedureImplantCompatibilityData>(ProcedureCompatibilitySearch);

            if (implants.Length == 0 || procedures.Length == 0 || compatibilityRules.Length == 0 ||
                visualVariants.Length == 0 || procedureCompatibilities.Length == 0)
            {
                Debug.LogWarning(
                    "ImplantProcedureDebug: Missing M4 implant/procedure data assets. Expected ImplantData, ProcedureData, ImplantCompatibilityRuleData, ImplantVisualVariantData, and ProcedureImplantCompatibilityData.");
                return;
            }

            var missingIdCount = 0;
            missingIdCount += CountMissingIds(implants);
            missingIdCount += CountMissingIds(procedures);
            missingIdCount += CountMissingIds(compatibilityRules);
            missingIdCount += CountMissingIds(visualVariants);
            missingIdCount += CountMissingIds(procedureCompatibilities);

            if (missingIdCount > 0)
            {
                Debug.LogWarning($"ImplantProcedureDebug failed: missingIdCount={missingIdCount}");
                return;
            }

            var firstImplant = implants[0];
            var firstProcedure = procedures[0];
            var firstRule = compatibilityRules[0];
            var firstVariant = visualVariants[0];
            var firstProcedureCompatibility = procedureCompatibilities[0];

            Debug.Log(
                "ImplantProcedureDebug OK\n" +
                $"implantCount={implants.Length}\n" +
                $"procedureCount={procedures.Length}\n" +
                $"compatibilityRuleCount={compatibilityRules.Length}\n" +
                $"visualVariantCount={visualVariants.Length}\n" +
                $"procedureCompatibilityCount={procedureCompatibilities.Length}\n" +
                $"firstImplantId={firstImplant.Id}\n" +
                $"firstImplantSlot={firstImplant.TargetSlot}\n" +
                $"firstImplantTier={firstImplant.Tier}\n" +
                $"firstImplantLegality={firstImplant.Legality}\n" +
                $"firstImplantQuality={firstImplant.Quality}\n" +
                $"firstProcedureId={firstProcedure.Id}\n" +
                $"firstProcedureDifficulty={firstProcedure.DifficultyLevel}\n" +
                $"firstCompatibilityRuleId={firstRule.Id}\n" +
                $"firstCompatibilityRelation={firstRule.Relation}\n" +
                $"firstCompatibilityModifier={firstRule.CompatibilityModifier:F3}\n" +
                $"firstVisualVariantId={firstVariant.Id}\n" +
                $"firstVisualVariantImplantId={firstVariant.ImplantId}\n" +
                $"firstProcedureCompatibilityId={firstProcedureCompatibility.Id}\n" +
                $"firstProcedureCompatibilityProcedureId={firstProcedureCompatibility.ProcedureId}\n" +
                $"firstProcedureCompatibilityImplantId={firstProcedureCompatibility.ImplantId}");
        }

        static int CountMissingIds<T>(T[] items) where T : ScriptableObject, CyberClinic.Core.IIdentifiable
        {
            var count = 0;
            for (var i = 0; i < items.Length; i++)
            {
                if (items[i] == null || string.IsNullOrWhiteSpace(items[i].Id))
                {
                    count++;
                }
            }
            return count;
        }

        static T[] LoadAll<T>(string filter) where T : Object
        {
            var guids = AssetDatabase.FindAssets(filter);
            var items = new T[guids.Length];
            var count = 0;
            for (var i = 0; i < guids.Length; i++)
            {
                var path = AssetDatabase.GUIDToAssetPath(guids[i]);
                var asset = AssetDatabase.LoadAssetAtPath<T>(path);
                if (asset != null)
                {
                    items[count++] = asset;
                }
            }

            if (count == items.Length)
            {
                return items;
            }

            var trimmed = new T[count];
            for (var i = 0; i < count; i++)
            {
                trimmed[i] = items[i];
            }
            return trimmed;
        }
    }
}
#endif
