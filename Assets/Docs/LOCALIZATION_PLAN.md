# Localization Plan — Design Memory

All **player-facing text** in Cyber Clinic uses **Unity Localization** with stable **localization keys**. This document is the contract for writers, translators, and Cursor-led implementation.

**Related:** `DEVELOPMENT_RULES.md`, `GAME_DESIGN_MEMORY.md`

---

## Core rule

**No hardcoded player-facing text** in:

- C# (`"Accept"`, `$"Risk: {x}"` with English words)
- Prefabs (TextMeshPro default text, UI Toolkit labels)
- ScriptableObject display fields (store keys, not sentences)
- Animation/UI tutorial overlays

---

## Locales

| Locale | Code | Role |
|--------|------|------|
| English | `en` | **Base locale**—authoritative for key completeness |
| Turkish | `tr` | **Secondary locale**—required for milestone 2 parity on core UI |
| Future | `de`, `fr`, … | Add when product requires; key structure unchanged |

**Milestone 2:** Install Unity Localization, create String Tables, set `en` default, `tr` secondary.

---

## String table groups

Physical collections under `Assets/_CyberClinic/Localization/StringTables/`:

| Collection | Contents |
|------------|----------|
| `UI` | Buttons, panels, navigation, settings |
| `Patients` | Archetypes, traits, file labels |
| `Implants` | Names, descriptions, tiers |
| `Procedures` | Names, steps, difficulty labels |
| `Complications` | Outcome text, follow-up |
| `Events` | Clinic event titles/bodies |
| `Dialogue` | Patient lines by tone/id |
| `Warnings` | Risk, CyberTox, neural, legal |
| `Tutorial` | Onboarding, tooltips |
| `Economy` | Money, reputation, day report |
| `Results` | Operation outcomes, stamps |

Shared table name prefix in keys matches collection (see naming).

---

## Key naming convention

```
<domain>.<subdomain>.<element>[.<variant>]
```

Rules:

- Lowercase, snake_case segments
- **Stable forever**—copy edits do not rename keys
- IDs from SO use same id: `patient.archetype.underground_fighter.name`
- Numbered variants: `.001`, `.002` for dialogue

### Example keys (canonical samples)

```
ui.button.accept_patient
ui.button.reject_patient
ui.panel.patient_file.title
patient.archetype.underground_fighter.name
patient.request.reflex_booster.description
implant.neural_spine.name
warning.cybertox.critical
event.blackout.title
dialogue.patient.panicked.001
result.operation.success.stable
math.term.cyber_tox_pressure
risk.band.dangerous.label
```

---

## Dynamic text with variables

Use Unity **Smart Strings** / `LocalizedString` with arguments:

| Pattern | Use |
|---------|-----|
| `{0}` | Single number/string arg |
| `{name}` | Named args for clarity |
| Plural | Smart string plural rules per locale |

**Right:** Key `economy.day_report.profit` = `"Day {0}: +{1}¢"`  
**Wrong:** `$"Day {day}: +{profit} credits"` in code

Format numbers in UI layer; pass **already-localized** unit suffix keys if needed (`economy.currency.symbol`).

---

## Smart string strategy

1. Author complete sentences per locale—no concatenating English fragments in code.
2. Turkish agglutination and gender agreement handled in `tr` table, not code branches.
3. Risk breakdown: one key per term label; values formatted separately.
4. Dialogue: full line per key—no `"Hello " + name` in code.

---

## What counts as player-facing text

| Player-facing (MUST localize) | Not player-facing (may stay English) |
|-------------------------------|--------------------------------------|
| UI labels, buttons, tooltips | Editor-only debug menus |
| Patient file, dialogue, results | `Debug.Log` messages |
| Tutorials, warnings, errors shown to user | Analytics event names |
| Store-style descriptions in game | SO asset file names |
| Day report, reputation flavor | Git commit messages |
| Loading tips | `#if UNITY_EDITOR` dev overlays marked non-shipping |

**Rule of thumb:** If it appears in a shipping build screenshot, it needs a key.

---

## What may remain non-localized temporarily

Only during **active development** before Milestone 2, and only if:

- Behind `DEVELOPMENT_LOCALIZATION_BYPASS` flag (Editor/dev builds)
- Tracked in `ROADMAP.md` as debt with removal date
- **Never** merged to `main` for release branches

After Milestone 2: **zero bypass** on `main`.

---

## How Cursor must write future code

1. **Read** `LOCALIZATION_PLAN.md` + `DEVELOPMENT_RULES.md` before UI/copy work.
2. Add keys to appropriate String Table **before** binding UI.
3. ScriptableObjects store `LocalizedStringReference` or string key fields—never display prose.
4. Prefabs: bind `Localize String Event` or equivalent—empty default text in TMP.
5. PR checklist: grep for quoted user-visible English in `Scripts/` and `_CyberClinic` prefabs.

### Wrong vs right

**Wrong**

```csharp
titleText.text = "Patient File";
acceptButton.GetComponentInChildren<TMP_Text>().text = "Accept";
```

**Right**

```csharp
// Pseudocode — actual API per Unity Localization setup at M2
titleText.BindLocalized("ui.panel.patient_file.title");
acceptButton.BindLocalized("ui.button.accept_patient");
```

**Wrong (SO)**

```text
displayName: "Neural Spine Mk2"
```

**Right (SO)**

```text
nameKey: "implant.neural_spine.name"
descriptionKey: "implant.neural_spine.description"
```

---

## Asset tables

`Localization/AssetTables/` for localized sprites if needed (e.g. region-specific compliance icons). Most art is locale-agnostic.

---

## Module ownership

| Task | Owner |
|------|-------|
| String Tables | Content/design + `Localization/` helpers |
| Runtime resolve | `Scripts/Localization/` |
| UI bind | `Scripts/UI/` uses localization API only |

---

## Acceptance criteria (Milestone 2)

- [ ] Unity Localization package installed (documented in CHANGELOG)
- [ ] `en` + `tr` tables for all groups
- [ ] Key naming linter or checklist in PR template
- [ ] No hardcoded strings in M2 deliverables
- [ ] Example keys above exist as entries
