using System;
using System.Collections.Generic;
using CyberClinic.Core;
using CyberClinic.Cosmetics;

namespace CyberClinic.Patients
{
    public struct PatientGenerationContextBuildResult
    {
        public bool Success;
        public PatientGenerationContext Context;
        public PatientGenerationError Error;
    }

    /// <summary>Builds filtered generation pools from input config (tutorial-safe, legality filters).</summary>
    public static class PatientGenerationContextBuilder
    {
        static readonly PatientArchetypeCategory[] TutorialArchetypeCategories =
        {
            PatientArchetypeCategory.StreetNetrunner,
            PatientArchetypeCategory.BurnoutMedic,
            PatientArchetypeCategory.FashionHacker,
            PatientArchetypeCategory.CorporateExile,
            PatientArchetypeCategory.UndergroundFighter
        };

        public static PatientGenerationContextBuildResult TryBuild(PatientGenerationInput input)
        {
            var config = input.Config ?? new PatientGenerationConfig();
            var archetypes = FilterArchetypes(input.Archetypes, config);
            var motivations = FilterCopy(input.Motivations, m => m != null);
            var requests = FilterCopy(input.RequestTypes, r => r != null);
            var hiddenConditions = FilterHiddenConditions(input.HiddenConditions, config);
            var visualTraits = FilterCopy(input.VisualTraits, v => v != null);
            var dialogueTones = FilterCopy(input.DialogueTones, d => d != null);

            if (archetypes.Count == 0)
            {
                return Fail(
                    config.TutorialSafeMode
                        ? PatientGenerationErrorCode.TutorialConstraintPoolEmpty
                        : PatientGenerationErrorCode.EmptyFilteredPool,
                    "Archetype pool empty after filters.");
            }

            if (motivations.Count == 0 || requests.Count == 0 || hiddenConditions.Count == 0 ||
                visualTraits.Count == 0 || dialogueTones.Count == 0)
            {
                return Fail(PatientGenerationErrorCode.EmptyFilteredPool, "A required pool is empty after filters.");
            }

            var seedContext = input.SeedContext;
            var patientSeed = seedContext.ToPatientSeed();

            return new PatientGenerationContextBuildResult
            {
                Success = true,
                Context = new PatientGenerationContext
                {
                    SeedContext = seedContext,
                    PatientSeed = patientSeed,
                    Random = new CyberClinicRandom(patientSeed),
                    Config = config,
                    Archetypes = archetypes.ToArray(),
                    Motivations = motivations.ToArray(),
                    HiddenConditions = hiddenConditions.ToArray(),
                    VisualTraits = visualTraits.ToArray(),
                    DialogueTones = dialogueTones.ToArray(),
                    RequestTypes = requests.ToArray()
                }
            };
        }

        static List<PatientArchetypeData> FilterArchetypes(PatientArchetypeData[] source, PatientGenerationConfig config)
        {
            var list = new List<PatientArchetypeData>();
            for (var i = 0; i < source.Length; i++)
            {
                var archetype = source[i];
                if (archetype == null)
                {
                    continue;
                }

                if (config.TutorialSafeMode)
                {
                    if (!IsTutorialArchetype(archetype))
                    {
                        continue;
                    }

                    if (!config.AllowIllegal && IsIllegalLean(archetype.DefaultLegalLean))
                    {
                        continue;
                    }
                }
                else
                {
                    if (!config.AllowIllegal && IsIllegalLean(archetype.DefaultLegalLean))
                    {
                        continue;
                    }

                    if (!config.AllowGrayMarket && archetype.DefaultLegalLean == PatientLegalStatus.Gray)
                    {
                        continue;
                    }
                }

                list.Add(archetype);
            }

            return list;
        }

        static List<PatientHiddenConditionData> FilterHiddenConditions(
            PatientHiddenConditionData[] source,
            PatientGenerationConfig config)
        {
            var list = new List<PatientHiddenConditionData>();
            for (var i = 0; i < source.Length; i++)
            {
                var condition = source[i];
                if (condition == null)
                {
                    continue;
                }

                if (config.TutorialSafeMode)
                {
                    if (IsSevereCondition(condition))
                    {
                        continue;
                    }

                    if (condition.Id == "false_papers" || condition.Id == "blacklisted")
                    {
                        continue;
                    }
                }

                list.Add(condition);
            }

            return list;
        }

        static List<T> FilterCopy<T>(T[] source, Func<T, bool> predicate)
        {
            var list = new List<T>();
            for (var i = 0; i < source.Length; i++)
            {
                if (predicate(source[i]))
                {
                    list.Add(source[i]);
                }
            }

            return list;
        }

        static bool IsTutorialArchetype(PatientArchetypeData archetype)
        {
            for (var i = 0; i < TutorialArchetypeCategories.Length; i++)
            {
                if (archetype.Category == TutorialArchetypeCategories[i])
                {
                    return true;
                }
            }

            return false;
        }

        static bool IsIllegalLean(PatientLegalStatus status) => status == PatientLegalStatus.Illegal;

        static bool IsSevereCondition(PatientHiddenConditionData condition) =>
            condition.OperationPenalty >= 0.12f;

        static PatientGenerationContextBuildResult Fail(PatientGenerationErrorCode code, string message) =>
            new PatientGenerationContextBuildResult
            {
                Success = false,
                Error = PatientGenerationError.Create(code, message)
            };
    }
}
