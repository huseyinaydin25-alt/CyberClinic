# Cyber Clinic — Localization

Milestone 2 localization foundation for **Unity Localization** (`com.unity.localization`).

---

## Locales

| Code | Role | Asset path |
|------|------|------------|
| `en` | **Base / source locale** | `Locales/English (en).asset` (created by setup) |
| `tr` | **Secondary locale** | `Locales/Turkish (tr).asset` (created by setup) |

English is the project default locale. Turkish must stay in parity for core UI and system strings as features ship.

---

## Rules

1. **No hardcoded player-facing text** in C#, prefabs, or ScriptableObjects.
2. Store **keys only** in code and data: `LocalizationKey`, `LocalizedTextRef`.
3. Copy lives in **String Tables** under `StringTables/`.
4. Use **Smart Strings** for placeholders (`{0}`, named args) — do not concatenate sentences in code.

See `Assets/Docs/LOCALIZATION_PLAN.md` and `Assets/Docs/DEVELOPMENT_RULES.md`.

---

## Folder layout

```
Localization/
  Locales/              # en + tr Locale assets (after setup)
  StringTables/         # String Table Collection assets per group
  StringTables/Seed/    # CSV source of truth for seed keys (en + tr)
  AssetTables/          # Localized sprites/assets (future)
  Localization Settings.asset
  README_LOCALIZATION.md
```

---

## String table groups

| Collection | CSV seed | Purpose |
|------------|----------|---------|
| `UI` | `Seed/UI.csv` | App shell, clinic HUD, operation UI |
| `Tutorial` | `Seed/Tutorial.csv` | First-time tutorial prompts |
| `Patients` | `Seed/Patients.csv` | Archetypes, requests, status labels |
| `Implants` | `Seed/Implants.csv` | Tiers and legality labels |
| `Procedures` | `Seed/Procedures.csv` | Difficulty, risk bands, outcomes |
| `Economy` | `Seed/Economy.csv` | Money, reputation, day report |
| `Events` | `Seed/Events.csv` | Clinic and seasonal event labels |
| `Cosmetics` | `Seed/Cosmetics.csv` | Cosmetic categories and purchase types |
| `Clinic` | `Seed/Clinic.csv` | Clinic tier names |
| `Errors` | `Seed/Errors.csv` | Player-visible errors |
| `System` | `Seed/System.csv` | Boot, offline, sync messages |

Key naming: `domain.subdomain.element` (lowercase, snake_case). Keys are stable contracts.

---

## First-time setup in Unity

1. Open the project and wait for **Package Manager** to resolve `com.unity.localization` and `com.unity.addressables`.
2. Run **`Cyber Clinic → Localization → Setup Foundation (M2)`**  
   - Creates locales, Localization Settings, string table collections, and imports all `Seed/*.csv` entries.
3. Optional: **`Cyber Clinic → Localization → Validate Hardcoded Text`**  
   - Heuristic scan of `Assets/_CyberClinic/Scripts/` for suspicious string literals.

Re-run setup after editing CSV seed files to refresh table entries.

---

## Code usage (data layer)

```csharp
// ScriptableObject / runtime data — keys only
[SerializeField] LocalizedTextRef _name; // e.g. ui.app.title

// Constants for math/UI term keys
LocalizationKey key = CyberClinicIds.MathTerms.CyberToxPressure;
```

Resolve strings at runtime through Unity Localization APIs in UI layer (Milestone 6+), not via hardcoded fallbacks.

---

## Validator limitations

`LocalizationKeyValidator` is a **best-effort** editor heuristic. It ignores:

- Localization-style keys (`ui.common.confirm`)
- Technical ids and paths
- `Debug.Log` lines and Editor scripts

Review warnings manually; false positives and false negatives are possible.
