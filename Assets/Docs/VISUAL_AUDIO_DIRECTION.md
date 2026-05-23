# Visual & Audio Direction — Design Memory

**Visual effects, animation, UI feedback, audio, and atmosphere are core gameplay systems**—equal priority to operation math and patient generation. Players learn clinic risk through **feel** (glitch, scan sweep, warning pulse) as much as numbers.

**Related:** `GAME_DESIGN_MEMORY.md`, `OPERATION_MATH.md`, `README_ARCHITECTURE.md`

---

## Visual style

| Pillar | Direction |
|--------|-----------|
| Genre read | 2D **stylized cyberpunk medical noir** |
| Clinic | Dark interiors, wet reflections, cramped surgery bay |
| Lighting | Neon cyan/magenta accents, harsh surgical whites |
| UI | Holographic medical HUD—scanlines, thin vectors, monospace labels |
| Weather | Rain on windows (parallax/loop), distant city glow |
| Mood | Clinical tension—not horror gore; consequence through tech failure |

**Art path:** `Assets/_CyberClinic/Art/`  
**VFX prefabs:** `Assets/_CyberClinic/Prefabs/VFX/`

No player-facing text in texture art.

---

## Signature visual moments

| Moment | Visual language |
|--------|-----------------|
| **Biometric scan** | Horizontal scan beam, wireframe overlay, data flicker |
| **Glitch** | RGB split, UV jitter, brief chromatic aberration |
| **Risk overlay** | Corner brackets, EKG-style line, band-colored border |
| **Warning pulse** | Rhythmic red/cyan edge pulse synced to audio tick |
| **Patient card** | Slide-in, hologram fade, urgency timer shimmer |
| **Operation result reveal** | Full-screen wipe + stamp (SUCCESS / UNSTABLE / FAIL) |
| **Implant install** | Slot flash, spark at contact, patient reaction sprite |
| **UI transitions** | 200–350ms ease; never instant hard cuts for major panels |

---

## Visual quality rules

1. **Every major gameplay action has visual feedback** (see action table below).
2. Feedback is triggered by **semantic events**, not inline in Economy/Procedures code.
3. Intensity scales with **risk band** (Safe minimal → Critical maximum).
4. Mobile-first: pooled particles, limited overdraw, no unbounded spawn.
5. Tunable via `ScriptableObjects/Visual/`—designers adjust timing/intensity without code.
6. Calculator and UI do not spawn particles directly.

### Major actions → visual feedback

| Action | Minimum visual |
|--------|----------------|
| Accept patient | Card lock-in glow |
| Reject patient | Card dismiss + faint glitch |
| Open patient file | Panel transition + hologram open |
| Basic scan | Scan beam + overlay reveal |
| Deep scan | Longer scan + glitch peek |
| Select implant | Slot highlight + compatibility color |
| Risk preview update | Risk overlay + band color |
| Commit operation | Surgery room focus + tension VFX |
| Operation result | Result reveal + patient reaction |
| Day end | Ambient dim + report panel |

---

## VFX modules (runtime architecture)

Planned types in `Scripts/Visual/`—**names are contracts for Milestone 7+**:

| Module | Responsibility |
|--------|----------------|
| `VisualFeedbackManager` | Subscribes to game events; routes to controllers |
| `GlitchEffectController` | RGB split, screen glitch bursts |
| `ScanEffectController` | Biometric scan beam, reveal masking |
| `ScreenShakeController` | Impact shake on fail/catastrophe |
| `WarningPulseController` | Risk band Dangerous/Critical pulses |
| `ImplantInstallEffect` | Install spark, slot flash |
| `PatientReactionEffect` | Success wince, fail spasm, stable nod |
| `ResultRevealEffect` | Outcome stamp, color wash |
| `UITransitionController` | Panel in/out, hologram fades |

**Data:** `ScriptableObjects/Visual/` maps `GameEventId` → prefab, duration, intensity curve.

---

## Audio direction

| Layer | Role |
|-------|------|
| **Ambience** | Rain, HVAC hum, distant traffic, neon buzz |
| **Music** | Low-tempo electronic noir; state-based (clinic / surgery / result) |
| **SFX** | UI, scan, warnings, tools, implant, success/fail |
| **Voice blips** | Non-verbal patient reactions (no VO lines required v1) |

Atmosphere should make the clinic feel **alive** when idle—player reads tension from soundscape before reading numbers.

---

## Audio modules (runtime architecture)

Planned types in `Scripts/Audio/`:

| Module | Responsibility |
|--------|----------------|
| `AudioManager` | Mixer routing, pool, volume settings |
| `SFXLibrary` | Addressable clip refs by id |
| `AmbienceController` | Loop layers, rain intensity |
| `MusicStateController` | Clinic / surgery / result stems |
| `PatientVoiceBlipController` | Short reactive blips on dialogue/reaction |

**Data:** `ScriptableObjects/Audio/` maps events → clip, pitch variance, cooldown.

---

## SFX categories

| Category | Examples |
|----------|----------|
| `ui` | Click, panel open, tab switch |
| `scan` | Scan start, scan complete, data tick |
| `warning` | Low beep, critical alarm, pulse tick |
| `surgery` | Tool whir, implant lock, neural spike |
| `patient` | Gasp, grunt, relief exhale |
| `result` | Success chime, unstable chord, fail slam |
| `economy` | Cash tick, rep up/down (subtle) |

Paths: `Assets/_CyberClinic/Audio/SFX/`

---

## Ambience categories

| Category | Examples |
|----------|----------|
| `room_tone` | Clinic idle loop |
| `weather` | Rain on glass |
| `city` | Distant sirens, ads muffled |
| `surgery` | Tighter room tone under music |

Paths: `Assets/_CyberClinic/Audio/Ambience/`, `Music/`

---

## Risk band → feedback intensity

| Band | Visual | Audio |
|------|--------|-------|
| Safe | None or subtle border | Soft tone |
| Stable | Light HUD glow | Neutral |
| Uncertain | Amber overlay | Double tick |
| Dangerous | Warning pulse | Rhythmic alarm |
| Critical | Glitch + shake | Alarm + heartbeat |

Synced from `OperationBreakdown.riskBand` preview events.

---

## Success / failure feedback

| Outcome | Visual | Audio |
|---------|--------|-------|
| `critical_success` | Gold scan flash | Bright chime + music lift |
| `stable_success` | Green stamp | Clean success |
| `unstable_success` | Amber stamp + minor glitch | Dissonant resolve |
| `failure` | Red glitch burst | Fail slam |
| `catastrophe` | Heavy glitch + shake | Alarm + ambience duck |

---

## Decoupling (mandatory)

```
Procedures → OperationResolved event
  → VisualFeedbackManager → controllers
  → AudioManager → SFXLibrary
```

Changing VFX prefab **must not** change `successChance`.  
Changing SFX **must not** change reputation rewards.

---

## Acceptance criteria (Milestones 7–8)

**M7 Visual**

- [ ] Scan, glitch, warning pulse, result reveal, UI transitions wired to events
- [ ] SO-driven feedback map
- [ ] No gameplay math in Visual scripts

**M8 Audio**

- [ ] AudioManager + SFXLibrary + ambience loop
- [ ] Scan/warning/success/fail sounds on same events as VFX
- [ ] Music state switches for surgery/result
