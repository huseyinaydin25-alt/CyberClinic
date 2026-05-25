using System;
using System.Collections.Generic;
using CyberClinic.Core;
using CyberClinic.Localization;

namespace CyberClinic.Patients
{
    /// <summary>Deterministic procedural patient generator (Milestone 3).</summary>
    public static class PatientGenerator
    {
        static readonly BodySlot[] BodySlots =
        {
            BodySlot.Head,
            BodySlot.Torso,
            BodySlot.ArmLeft,
            BodySlot.ArmRight,
            BodySlot.LegLeft,
            BodySlot.LegRight,
            BodySlot.Spine,
            BodySlot.Skin,
            BodySlot.Internal
        };

        public static PatientGenerationResult Generate(PatientGenerationInput input)
        {
            var validation = PatientGenerationValidator.Validate(input);
            if (!validation.IsValid)
            {
                return PatientGenerationResult.Failed(validation.Error);
            }

            var contextBuild = PatientGenerationContextBuilder.TryBuild(input);
            if (!contextBuild.Success)
            {
                return PatientGenerationResult.Failed(contextBuild.Error);
            }

            var patient = BuildPatient(contextBuild.Context);
            return PatientGenerationResult.Succeeded(patient);
        }

        static GeneratedPatient BuildPatient(PatientGenerationContext context)
        {
            var random = context.Random;
            var config = context.Config;

            var archetype = PatientGenerationWeights.PickWeightedDefinition(random, context.Archetypes);
            var motivation = PatientGenerationWeights.PickWeightedDefinition(random, context.Motivations);
            var request = PatientGenerationWeights.PickWeightedDefinition(random, context.RequestTypes);
            var visualTrait = PatientGenerationWeights.PickWeightedDefinition(random, context.VisualTraits);
            var dialogueTone = PatientGenerationWeights.PickWeightedDefinition(random, context.DialogueTones);

            var requestSlot = request.TargetSlot;
            var bodyProblemSlot = PickBodyProblemSlot(random, requestSlot, config.SlotConflictChance);
            var hasSlotConflict = bodyProblemSlot == requestSlot;

            var hiddenConditions = PickHiddenConditions(random, context, config, hasSlotConflict);
            var declaredLegal = ResolveDeclaredLegalStatus(random, archetype, config);
            var actualLegal = ResolveActualLegalStatus(declaredLegal, hiddenConditions);

            var urgency = ResolveUrgency(random, config);
            var budget = BuildBudgetProfile(random, config, motivation.Id);
            var risk = BuildRiskProfile(random, config, hiddenConditions, urgency, motivation.Id);

            var patient = new GeneratedPatient
            {
                InstanceId = PatientIdFactory.CreateInstanceId(context.SeedContext),
                PatientSeed = context.PatientSeed,
                GenerationContext = context.SeedContext,
                ArchetypeId = archetype.Id,
                MotivationId = motivation.Id,
                BodyProblemId = BodySlotToProblemId(bodyProblemSlot),
                BodyProblemSlot = bodyProblemSlot,
                RequestTypeId = request.Id,
                RequestedUpgradeSlot = requestSlot,
                VisualTraitId = visualTrait.Id,
                DialogueToneId = dialogueTone.Id,
                LegalStatus = actualLegal,
                Budget = budget,
                Risk = risk,
                Urgency = urgency,
                Known = BuildKnownInfo(random, archetype, motivation, request, visualTrait, dialogueTone, declaredLegal),
                Hidden = BuildHiddenInfo(hiddenConditions, hasSlotConflict)
            };

            return patient;
        }

        static PatientKnownInfo BuildKnownInfo(
            CyberClinicRandom random,
            PatientArchetypeData archetype,
            PatientMotivationData motivation,
            PatientRequestTypeData request,
            PatientVisualTraitData visualTrait,
            PatientDialogueToneData dialogueTone,
            PatientLegalStatus declaredLegal)
        {
            var known = new PatientKnownInfo
            {
                ArchetypeNameKey = ResolveArchetypeNameKey(archetype),
                RequestDescriptionKey = ResolveRequestDescriptionKey(request),
                MotivationHintKey = ResolveMotivationHintKey(motivation),
                DeclaredLegalStatus = declaredLegal
            };

            known.VisibleVisualTraitIds.Add(visualTrait.Id);
            AddDialogueLineKeys(known, dialogueTone, random);
            return known;
        }

        static PatientHiddenInfo BuildHiddenInfo(
            List<PatientHiddenConditionData> hiddenConditions,
            bool hasSlotConflict)
        {
            var hidden = new PatientHiddenInfo
            {
                ToleranceRevealState = RevealState.Hidden,
                SlotConflictRevealState = hasSlotConflict ? RevealState.Hidden : RevealState.Revealed,
                MotivationSubtextRevealState = RevealState.Hidden
            };

            for (var i = 0; i < hiddenConditions.Count; i++)
            {
                hidden.HiddenConditions.Add(new HiddenConditionEntry
                {
                    ConditionId = hiddenConditions[i].Id,
                    RevealState = RevealState.Hidden
                });
            }

            return hidden;
        }

        static LocalizationKey ResolveArchetypeNameKey(PatientArchetypeData archetype) =>
            archetype.Name.HasKey ? archetype.Name.Key : PatientLocalizationKeys.ArchetypeName(archetype.Id);

        static LocalizationKey ResolveRequestDescriptionKey(PatientRequestTypeData request) =>
            request.Description.HasKey ? request.Description.Key : PatientLocalizationKeys.RequestDescription(request.Id);

        static LocalizationKey ResolveMotivationHintKey(PatientMotivationData motivation) =>
            motivation.HintLabel.HasKey ? motivation.HintLabel.Key : PatientLocalizationKeys.MotivationHint(motivation.Id);

        static void AddDialogueLineKeys(PatientKnownInfo known, PatientDialogueToneData dialogueTone, CyberClinicRandom random)
        {
            var lines = dialogueTone.LineKeys;
            if (lines == null || lines.Length == 0)
            {
                return;
            }

            var index = lines.Length == 1 ? 0 : random.NextInt(0, lines.Length - 1);
            if (lines[index].HasKey)
            {
                known.VisibleDialogueLineKeys.Add(lines[index].Key);
            }
        }

        static BodySlot PickBodyProblemSlot(CyberClinicRandom random, BodySlot requestSlot, float conflictChance)
        {
            if (random.NextFloat() < conflictChance)
            {
                return requestSlot;
            }

            var candidates = new List<BodySlot>();
            for (var i = 0; i < BodySlots.Length; i++)
            {
                if (BodySlots[i] != requestSlot)
                {
                    candidates.Add(BodySlots[i]);
                }
            }

            if (candidates.Count == 0)
            {
                return requestSlot;
            }

            var index = random.NextInt(0, candidates.Count - 1);
            return candidates[index];
        }

        static List<PatientHiddenConditionData> PickHiddenConditions(
            CyberClinicRandom random,
            PatientGenerationContext context,
            PatientGenerationConfig config,
            bool forceSlotConflict)
        {
            var results = new List<PatientHiddenConditionData>();
            var maxCount = Math.Max(0, config.MaxHiddenConditions);

            if (config.TutorialSafeMode)
            {
                maxCount = Math.Min(maxCount, 1);
            }

            if (maxCount == 0 && !forceSlotConflict)
            {
                return results;
            }

            var targetCount = maxCount == 0 ? 0 : random.NextInt(0, maxCount);

            if (config.TutorialSafeMode && targetCount == 0 && context.HiddenConditions.Length > 0)
            {
                targetCount = 1;
            }

            var pool = new List<PatientHiddenConditionData>(context.HiddenConditions);
            for (var i = 0; i < targetCount && pool.Count > 0; i++)
            {
                var picked = PatientGenerationWeights.PickWeightedDefinition(random, pool);
                if (picked != null)
                {
                    results.Add(picked);
                    pool.Remove(picked);
                }
            }

            if (forceSlotConflict && !ContainsCondition(results, "slot_conflict"))
            {
                var slotConflict = FindConditionById(context.HiddenConditions, "slot_conflict");
                if (slotConflict != null)
                {
                    results.Add(slotConflict);
                }
            }

            return results;
        }

        static PatientLegalStatus ResolveDeclaredLegalStatus(
            CyberClinicRandom random,
            PatientArchetypeData archetype,
            PatientGenerationConfig config)
        {
            if (config.TutorialSafeMode)
            {
                return random.NextFloat() < 0.6f ? PatientLegalStatus.Gray : PatientLegalStatus.Legal;
            }

            var lean = archetype.DefaultLegalLean;
            if (!config.AllowIllegal && lean == PatientLegalStatus.Illegal)
            {
                lean = PatientLegalStatus.Gray;
            }

            if (!config.AllowGrayMarket && lean == PatientLegalStatus.Gray)
            {
                lean = PatientLegalStatus.Legal;
            }

            return lean;
        }

        static PatientLegalStatus ResolveActualLegalStatus(
            PatientLegalStatus declared,
            List<PatientHiddenConditionData> hiddenConditions)
        {
            if (ContainsCondition(hiddenConditions, "false_papers"))
            {
                return declared == PatientLegalStatus.Legal ? PatientLegalStatus.Gray : declared;
            }

            return declared;
        }

        static PatientUrgencyProfile ResolveUrgency(CyberClinicRandom random, PatientGenerationConfig config)
        {
            PatientUrgencyLevel level;
            if (config.TutorialSafeMode)
            {
                level = PatientUrgencyLevel.Medium;
            }
            else
            {
                var min = (int)config.MinUrgency;
                var max = (int)config.MaxUrgency;
                if (min > max)
                {
                    (min, max) = (max, min);
                }

                level = (PatientUrgencyLevel)random.NextInt(min, max);
            }

            return new PatientUrgencyProfile
            {
                Level = level,
                PatienceRemaining01 = 1f,
                ShowVisibleTimer = level >= PatientUrgencyLevel.High
            };
        }

        static PatientBudgetProfile BuildBudgetProfile(
            CyberClinicRandom random,
            PatientGenerationConfig config,
            string motivationId)
        {
            BudgetBandId band;
            if (config.TutorialSafeMode)
            {
                band = random.NextFloat() < 0.5f ? BudgetBandId.Tight : BudgetBandId.Standard;
            }
            else
            {
                band = (BudgetBandId)random.NextInt(0, 4);
            }

            var statedMin = config.MinBudget;
            var statedMax = config.MaxBudget;
            NormalizeBudgetRange(ref statedMin, ref statedMax, band);

            var statedRange = new RangeInt(statedMin, statedMax);
            var trueCeiling = ComputeTrueCeiling(random, statedRange, band, motivationId);

            return new PatientBudgetProfile
            {
                StatedBandLabelKey = PatientLocalizationKeys.BudgetBand(band),
                StatedRange = statedRange,
                TrueCeiling = trueCeiling,
                TrueCeilingRevealState = RevealState.Hidden,
                WillWalkIfOverBudget = band == BudgetBandId.Tight || band == BudgetBandId.Broke,
                WalkAwayRevealState = RevealState.Hidden
            };
        }

        static void NormalizeBudgetRange(ref int min, ref int max, BudgetBandId band)
        {
            if (min > max)
            {
                (min, max) = (max, min);
            }

            var span = max - min;
            switch (band)
            {
                case BudgetBandId.Broke:
                    max = min + Math.Max(50, span / 4);
                    break;
                case BudgetBandId.Tight:
                    max = min + Math.Max(100, span / 2);
                    break;
                case BudgetBandId.Flush:
                    min = min + span / 3;
                    break;
                case BudgetBandId.Suspicious:
                    min = min + span / 2;
                    max = min + span / 4;
                    break;
            }
        }

        static int ComputeTrueCeiling(CyberClinicRandom random, RangeInt statedRange, BudgetBandId band, string motivationId)
        {
            var statedMax = statedRange.Max;
            var multiplier = band switch
            {
                BudgetBandId.Broke => random.NextFloat(0.55f, 0.75f),
                BudgetBandId.Tight => random.NextFloat(0.7f, 0.9f),
                BudgetBandId.Standard => random.NextFloat(0.95f, 1.05f),
                BudgetBandId.Flush => random.NextFloat(1.05f, 1.15f),
                BudgetBandId.Suspicious => random.NextFloat(0.5f, 0.8f),
                _ => 1f
            };

            if (motivationId == "profit")
            {
                multiplier *= random.NextFloat(0.75f, 0.95f);
            }

            return Math.Max(statedRange.Min, (int)(statedMax * multiplier));
        }

        static PatientRiskProfile BuildRiskProfile(
            CyberClinicRandom random,
            PatientGenerationConfig config,
            List<PatientHiddenConditionData> hiddenConditions,
            PatientUrgencyProfile urgency,
            string motivationId)
        {
            var neural = Percentage01.From01(random.NextFloat(
                config.BaseNeuralStabilityRange.Min,
                config.BaseNeuralStabilityRange.Max));

            var cyberTox = Percentage01.From01(random.NextFloat(
                config.BaseCyberToxResistanceRange.Min,
                config.BaseCyberToxResistanceRange.Max));

            ApplyHiddenConditionRiskModifiers(hiddenConditions, ref neural, ref cyberTox);

            if (motivationId == "vengeance")
            {
                neural = Percentage01.From01(Math.Min(neural.Value, 0.45f));
            }

            if (motivationId == "addiction")
            {
                cyberTox = Percentage01.From01(Math.Min(cyberTox.Value, 0.4f));
            }

            var panicBase = random.NextFloat(config.BasePanicRange.Min, config.BasePanicRange.Max);
            panicBase += UrgencyToPanicBonus(urgency.Level);
            if (motivationId == "vengeance")
            {
                panicBase += 12f;
            }

            if (ContainsCondition(hiddenConditions, "panic_disorder"))
            {
                panicBase += 15f;
            }

            var panic = (int)Math.Clamp(panicBase, 0f, 100f);

            return new PatientRiskProfile
            {
                NeuralStability = neural,
                CyberToxResistance = cyberTox,
                BodyStressBaseline = Percentage01.From01(random.NextFloat(0.2f, 0.55f)),
                PanicNumeric = panic,
                PainThreshold = Percentage01.From01(random.NextFloat(0.35f, 0.8f))
            };
        }

        static void ApplyHiddenConditionRiskModifiers(
            List<PatientHiddenConditionData> hiddenConditions,
            ref Percentage01 neural,
            ref Percentage01 cyberTox)
        {
            for (var i = 0; i < hiddenConditions.Count; i++)
            {
                var condition = hiddenConditions[i];
                if (condition.Id == "neural_fragile")
                {
                    neural = Percentage01.From01(Math.Max(0.05f, neural.Value - 0.2f));
                }

                if (condition.Id == "cybertox_sensitive")
                {
                    cyberTox = Percentage01.From01(Math.Max(0.05f, cyberTox.Value - 0.2f));
                }
            }
        }

        static float UrgencyToPanicBonus(PatientUrgencyLevel level) => level switch
        {
            PatientUrgencyLevel.Low => 0f,
            PatientUrgencyLevel.Medium => 5f,
            PatientUrgencyLevel.High => 12f,
            PatientUrgencyLevel.Critical => 22f,
            _ => 0f
        };

        static string BodySlotToProblemId(BodySlot slot)
        {
            return "body_problem." + BodySlotToKeySegment(slot);
        }

        static string BodySlotToKeySegment(BodySlot slot) => slot switch
        {
            BodySlot.ArmLeft => "arm_left",
            BodySlot.ArmRight => "arm_right",
            BodySlot.LegLeft => "leg_left",
            BodySlot.LegRight => "leg_right",
            _ => slot.ToString().ToLowerInvariant()
        };

        static bool ContainsCondition(List<PatientHiddenConditionData> conditions, string id)
        {
            for (var i = 0; i < conditions.Count; i++)
            {
                if (conditions[i].Id == id)
                {
                    return true;
                }
            }

            return false;
        }

        static PatientHiddenConditionData FindConditionById(PatientHiddenConditionData[] pool, string id)
        {
            for (var i = 0; i < pool.Length; i++)
            {
                if (pool[i].Id == id)
                {
                    return pool[i];
                }
            }

            return null;
        }
    }
}
