using System;
using CyberClinic.Localization;
using UnityEngine;

namespace CyberClinic.Patients
{
    public struct PatientGenerationValidationResult
    {
        public bool IsValid;
        public PatientGenerationError Error;
    }

    /// <summary>Validates source pools and localization key presence before generation.</summary>
    public static class PatientGenerationValidator
    {
        public static PatientGenerationValidationResult Validate(PatientGenerationInput input)
        {
            if (input == null)
            {
                return Fail(PatientGenerationErrorCode.NullInput, "PatientGenerationInput is null.");
            }

            if (input.Archetypes == null || input.Archetypes.Length == 0)
            {
                return Fail(PatientGenerationErrorCode.MissingArchetypes, "Archetype pool is null or empty.");
            }

            if (input.Motivations == null || input.Motivations.Length == 0)
            {
                return Fail(PatientGenerationErrorCode.MissingMotivations, "Motivation pool is null or empty.");
            }

            if (input.RequestTypes == null || input.RequestTypes.Length == 0)
            {
                return Fail(PatientGenerationErrorCode.MissingRequestTypes, "Request type pool is null or empty.");
            }

            if (input.HiddenConditions == null || input.HiddenConditions.Length == 0)
            {
                return Fail(PatientGenerationErrorCode.MissingHiddenConditions, "Hidden condition pool is null or empty.");
            }

            if (input.VisualTraits == null || input.VisualTraits.Length == 0)
            {
                return Fail(PatientGenerationErrorCode.MissingVisualTraits, "Visual trait pool is null or empty.");
            }

            if (input.DialogueTones == null || input.DialogueTones.Length == 0)
            {
                return Fail(PatientGenerationErrorCode.MissingDialogueTones, "Dialogue tone pool is null or empty.");
            }

            if (!ValidatePoolIds(input.Archetypes, "archetype", out var archetypeError))
            {
                return archetypeError;
            }

            if (!ValidatePoolIds(input.Motivations, "motivation", out var motivationError))
            {
                return motivationError;
            }

            if (!ValidatePoolIds(input.RequestTypes, "request", out var requestError))
            {
                return requestError;
            }

            if (!ValidatePoolIds(input.HiddenConditions, "hidden_condition", out var hiddenError))
            {
                return hiddenError;
            }

            if (!ValidatePoolIds(input.VisualTraits, "visual_trait", out var visualError))
            {
                return visualError;
            }

            if (!ValidatePoolIds(input.DialogueTones, "dialogue_tone", out var toneError))
            {
                return toneError;
            }

            if (!ValidateArchetypeKeys(input.Archetypes, out var archetypeKeyError))
            {
                return archetypeKeyError;
            }

            if (!ValidateMotivationKeys(input.Motivations, out var motivationKeyError))
            {
                return motivationKeyError;
            }

            if (!ValidateRequestKeys(input.RequestTypes, out var requestKeyError))
            {
                return requestKeyError;
            }

            return new PatientGenerationValidationResult { IsValid = true, Error = PatientGenerationError.None };
        }

        static PatientGenerationValidationResult Fail(PatientGenerationErrorCode code, string message) =>
            new PatientGenerationValidationResult
            {
                IsValid = false,
                Error = PatientGenerationError.Create(code, message)
            };

        static bool ValidatePoolIds<T>(T[] items, string poolName, out PatientGenerationValidationResult result)
            where T : ScriptableObject, CyberClinic.Core.IIdentifiable
        {
            for (var i = 0; i < items.Length; i++)
            {
                var item = items[i];
                if (item == null)
                {
                    result = Fail(PatientGenerationErrorCode.InvalidDefinitionId, $"{poolName} pool contains null entry at index {i}.");
                    return false;
                }

                if (string.IsNullOrWhiteSpace(item.Id))
                {
                    result = Fail(
                        PatientGenerationErrorCode.InvalidDefinitionId,
                        $"{poolName} '{item.name}' has empty id at index {i}.");
                    return false;
                }
            }

            result = default;
            return true;
        }

        static bool ValidateArchetypeKeys(PatientArchetypeData[] archetypes, out PatientGenerationValidationResult result)
        {
            for (var i = 0; i < archetypes.Length; i++)
            {
                var archetype = archetypes[i];
                if (!HasKey(archetype.Name) && !HasKey(PatientLocalizationKeys.ArchetypeName(archetype.Id)))
                {
                    result = Fail(
                        PatientGenerationErrorCode.MissingLocalizationKey,
                        $"Archetype '{archetype.Id}' missing name localization key.");
                    return false;
                }
            }

            result = default;
            return true;
        }

        static bool ValidateMotivationKeys(PatientMotivationData[] motivations, out PatientGenerationValidationResult result)
        {
            for (var i = 0; i < motivations.Length; i++)
            {
                var motivation = motivations[i];
                if (!HasKey(motivation.HintLabel) && !HasKey(PatientLocalizationKeys.MotivationHint(motivation.Id)))
                {
                    result = Fail(
                        PatientGenerationErrorCode.MissingLocalizationKey,
                        $"Motivation '{motivation.Id}' missing hint localization key.");
                    return false;
                }
            }

            result = default;
            return true;
        }

        static bool ValidateRequestKeys(PatientRequestTypeData[] requests, out PatientGenerationValidationResult result)
        {
            for (var i = 0; i < requests.Length; i++)
            {
                var request = requests[i];
                if (!HasKey(request.Description) && !HasKey(PatientLocalizationKeys.RequestDescription(request.Id)))
                {
                    result = Fail(
                        PatientGenerationErrorCode.MissingLocalizationKey,
                        $"Request '{request.Id}' missing description localization key.");
                    return false;
                }
            }

            result = default;
            return true;
        }

        static bool HasKey(LocalizedTextRef textRef) => textRef.HasKey;

        static bool HasKey(LocalizationKey key) => key.IsValid;
    }
}
