# Deterministic Operation Calculation Doctrine

**Date:** 2026-05-29  
**Status:** Active design doctrine  
**Scope:** Define the deterministic calculation philosophy for Cyber Clinic operation outcomes in the new 3D MMO-lite RPG vision.

---

## Strategic decision

Cyber Clinic operation outcomes must be deterministic, explainable, and build-driven.

The player should feel that outcomes are produced by readable systems, not arbitrary randomness.

---

## New completion estimate

The old completion estimate of approximately 18% applied to the earlier patient puzzle / playable slice vision.

The new full vision is much larger.

```text
Core operation logic foundation progress: ~18%
Full 3D MMO-lite RPG vision progress: ~3%
```

This does not mean progress was lost. It means the target expanded.

---

## Core rule

```text
Operation outcome = deterministic calculation from known inputs.
```

Randomness may exist only as controlled, seeded, explainable variance.

The same player state, same case, same equipment, same modifiers, and same seed should produce the same result.

---

## Required calculation inputs

A future operation calculation should be able to include:

```text
Case definition ID
Case difficulty
Patient condition modifiers
Procedure definition ID
Procedure difficulty
Clinic owner level
Clinic reputation tier
Equipped item power
Equipped item stat modifiers
Item rarity modifiers
Item upgrade levels
Item set bonuses
Facility upgrade modifiers
Specialist role bonuses
AI module bonuses
Consumable modifiers
Event modifiers
Season modifiers
Alliance contribution modifiers
Raid phase modifiers
Admin-defined balance constants
Deterministic operation seed
```

---

## Example calculation philosophy

```text
baseOperationScore
+ clinicProgressionScore
+ equippedItemScore
+ itemStatModifierScore
+ facilityModifierScore
+ specialistModifierScore
+ eventModifierScore
+ allianceModifierScore
- caseDifficultyPenalty
- riskPenalty
+ deterministicSeededVariance
= finalOperationScore
```

Then:

```text
finalOperationScore -> preview success chance
finalOperationScore -> risk band
finalOperationScore -> possible outcome tier
finalOperationScore -> reward modifier
```

---

## Player-facing rule

The player should be able to understand why the operation is easy, risky, or nearly impossible.

The game should eventually expose a modifier breakdown such as:

```text
Base case difficulty
Procedure difficulty
Tool bonus
Diagnostic device bonus
AI module bonus
Clinic facility bonus
Set bonus
Risk penalty
Event bonus
Final preview chance
```

---

## MMO itemization rule

Items must matter.

The value, rarity, upgrade level, stat rolls, and set bonuses of items should meaningfully affect operation planning and execution.

Players should chase better items because those items allow them to:

```text
Improve success chance
Reduce risk
Unlock harder cases
Qualify for group operations
Qualify for raid operations
Increase rewards
Build specialized roles
Improve league / leaderboard performance under fair rules
```

---

## No unfair chaos rule

The system should not feel like uncontrolled RNG.

Avoid:

```text
Hidden random failure without explanation
Random results that ignore item/build preparation
Unclear modifiers
Unbounded luck swings
Unrepeatable debug results
```

Prefer:

```text
Seeded variance
Clear modifier breakdown
Stable formulas
Admin-tunable constants
Validator-tested cases
Replayable deterministic debug scenarios
```

---

## Admin-configurable rule

Operation formulas should eventually be controlled by admin-style data where safe.

Admin data may define:

```text
case difficulty
procedure difficulty
risk weights
stat weights
rarity power budget
item modifier caps
event modifiers
reward multipliers
drop rate modifiers
operation tier thresholds
```

Code should provide the calculation engine and validation rules. Data should provide content and balance.

---

## Validator rule

Every future operation calculation layer must include deterministic validators.

Required validator examples:

```text
same input same output
higher item power improves score
higher case difficulty lowers score
risk reduction item lowers risk band
set bonus applies only when requirements are met
locked operation result does not change after commit
admin data missing references fail validation
seeded variance remains within allowed range
```

---

## Near-term implementation implication

Current M15 work should continue.

But after the operation decision loop is stable, the next major logic direction should be:

```text
Operation Calculation v2
Item stat modifier foundation
Modifier breakdown model
Deterministic calculation validator
```

This should happen before deep liveops, alliance, raid, or monetization systems.

---

## Design target

The player should think:

```text
I need better tools.
I need a stronger diagnostic device.
I need a better AI module.
I need the right set bonus.
I need to upgrade my clinic facility.
Then I can take on harder operations.
```

That is the core RPG loop.
