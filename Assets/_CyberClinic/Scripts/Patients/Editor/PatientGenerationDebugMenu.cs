#if UNITY_EDITOR
using CyberClinic.Core;
using UnityEditor;
using UnityEngine;

namespace CyberClinic.Patients.Editor
{
    /// <summary>Editor-only deterministic generation smoke test (technical log output only).</summary>
    public static class PatientGenerationDebugMenu
    {
        const string ArchetypeSearch = "t:PatientArchetypeData";
        const string MotivationSearch = "t:PatientMotivationData";
        const string HiddenSearch = "t:PatientHiddenConditionData";
        const string VisualSearch = "t:PatientVisualTraitData";
        const string DialogueSearch = "t:PatientDialogueToneData";
        const string RequestSearch = "t:PatientRequestTypeData";

        [MenuItem("Cyber Clinic/Patients/Generate Debug Patient")]
        public static void GenerateDebugPatient()
        {
            var archetypes = LoadAll<PatientArchetypeData>(ArchetypeSearch);
            var motivations = LoadAll<PatientMotivationData>(MotivationSearch);
            var hiddenConditions = LoadAll<PatientHiddenConditionData>(HiddenSearch);
            var visualTraits = LoadAll<PatientVisualTraitData>(VisualSearch);
            var dialogueTones = LoadAll<PatientDialogueToneData>(DialogueSearch);
            var requestTypes = LoadAll<PatientRequestTypeData>(RequestSearch);

            if (archetypes.Length == 0 || motivations.Length == 0 || hiddenConditions.Length == 0 ||
                visualTraits.Length == 0 || dialogueTones.Length == 0 || requestTypes.Length == 0)
            {
                Debug.LogWarning(
                    "PatientGenerationDebug: Missing Patient*Data assets in project. Create ScriptableObject definitions before testing.");
                return;
            }

            var input = new PatientGenerationInput
            {
                SeedContext = new SeedContext(84921, 3, 0),
                Config = new PatientGenerationConfig { TutorialSafeMode = false },
                Archetypes = archetypes,
                Motivations = motivations,
                HiddenConditions = hiddenConditions,
                VisualTraits = visualTraits,
                DialogueTones = dialogueTones,
                RequestTypes = requestTypes
            };

            var result = PatientGenerator.Generate(input);
            if (!result.Success)
            {
                Debug.LogWarning($"PatientGenerationDebug failed: {result.Error.Code} — {result.TechnicalMessage}");
                return;
            }

            var patient = result.Patient;
            Debug.Log(
                "PatientGenerationDebug OK\n" +
                $"instanceId={patient.InstanceId}\n" +
                $"patientSeed={patient.PatientSeed}\n" +
                $"archetypeId={patient.ArchetypeId}\n" +
                $"motivationId={patient.MotivationId}\n" +
                $"requestTypeId={patient.RequestTypeId}\n" +
                $"bodyProblemId={patient.BodyProblemId}\n" +
                $"bodyProblemSlot={patient.BodyProblemSlot}\n" +
                $"requestedUpgradeSlot={patient.RequestedUpgradeSlot}\n" +
                $"visualTraitId={patient.VisualTraitId}\n" +
                $"dialogueToneId={patient.DialogueToneId}\n" +
                $"declaredLegal={patient.Known.DeclaredLegalStatus}\n" +
                $"actualLegal={patient.LegalStatus}\n" +
                $"urgency={patient.Urgency.Level}\n" +
                $"budgetRange={patient.Budget.StatedRange.Min}-{patient.Budget.StatedRange.Max}\n" +
                $"trueCeiling={patient.Budget.TrueCeiling}\n" +
                $"neuralStability={patient.Risk.NeuralStability.Value:F3}\n" +
                $"cyberToxResistance={patient.Risk.CyberToxResistance.Value:F3}\n" +
                $"panic={patient.Risk.PanicNumeric}\n" +
                $"hiddenConditionCount={patient.Hidden.HiddenConditions.Count}\n" +
                $"slotConflictHidden={patient.Hidden.SlotConflictRevealState == RevealState.Hidden}");
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
