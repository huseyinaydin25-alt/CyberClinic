# Roadmap Addendum — LiveOps, Competitive, and Retention Systems

**Date:** 2026-05-29  
**Status:** Added to roadmap  
**Scope:** Expand Cyber Clinic roadmap toward premium large-scale mobile game systems.

---

## Strategic reminder

Cyber Clinic is being planned as a premium, high-budget-equivalent mobile game, not a small prototype.

The roadmap must therefore include long-term retention, competition, live operations, social pressure, event cadence, and monetization-adjacent progression systems from the beginning, even if implementation comes after core gameplay foundations.

---

## Added roadmap pillars

```text
Daily / Weekly Missions
Streak System
Leaderboard
PvP / Async Competition
Events / Limited-Time Events
Season System
Battle Pass-like Progression Track
LiveOps Calendar
Player Retention Economy
Social / Competitive Layer
```

---

## M31 — Daily / Weekly Mission Foundation

```text
M31.1 — Mission Definition Model
M31.2 — Daily Mission Slot Model
M31.3 — Weekly Mission Slot Model
M31.4 — Mission Progress Tracking
M31.5 — Mission Reward Rules
M31.6 — Mission Save Binding
M31.7 — Mission Validator
```

Goal: Give players concrete daily and weekly reasons to return.

---

## M32 — Streak System Foundation

```text
M32.1 — Login Streak Model
M32.2 — Treatment Streak Model
M32.3 — Streak Reward Rules
M32.4 — Streak Break / Grace Rules
M32.5 — Streak Bar Presentation Model
M32.6 — Streak Save Binding
M32.7 — Streak Validator
```

Goal: Build return habit and session continuity.

---

## M33 — Leaderboard Foundation

```text
M33.1 — Leaderboard Score Model
M33.2 — Local Leaderboard Mock
M33.3 — Weekly Leaderboard Rules
M33.4 — Reputation / Earnings Ranking Rules
M33.5 — Leaderboard Presentation Model
M33.6 — Leaderboard Reset Rules
M33.7 — Leaderboard Validator
```

Goal: Add competitive ranking pressure before online backend integration.

---

## M34 — Async PvP / Competitive Challenge Foundation

```text
M34.1 — PvP Challenge Snapshot Model
M34.2 — Ghost Clinic Opponent Model
M34.3 — Async Score Comparison Rules
M34.4 — Fairness / Bracket Placeholder Rules
M34.5 — PvP Reward Rules
M34.6 — PvP Mock Service
M34.7 — PvP Validator
```

Goal: Add competition without requiring real-time multiplayer.

---

## M35 — Limited-Time Event Foundation

```text
M35.1 — Event Definition Model
M35.2 — Event Calendar Model
M35.3 — Event Availability Rules
M35.4 — Event Mission Binding
M35.5 — Event Reward Track Placeholder
M35.6 — Event Save Binding
M35.7 — Event Validator
```

Goal: Prepare rotating events and campaign-like limited-time content.

---

## M36 — Season System Foundation

```text
M36.1 — Season Definition Model
M36.2 — Season Progress Model
M36.3 — Season Reset Rules
M36.4 — Season Reward Tier Model
M36.5 — Season Mission Binding
M36.6 — Season Save Binding
M36.7 — Season Validator
```

Goal: Create long-term retention loops and periodic resets.

---

## M37 — Battle Pass-like Progression Track Foundation

```text
M37.1 — Free Track Model
M37.2 — Premium Track Placeholder Model
M37.3 — Tier Progression Rules
M37.4 — Claim State Model
M37.5 — Reward Preview Presentation
M37.6 — Track Save Binding
M37.7 — Progression Track Validator
```

Goal: Build a premium retention and monetization-compatible structure before SDK integration.

---

## M38 — LiveOps Calendar Foundation

```text
M38.1 — LiveOps Calendar Model
M38.2 — Campaign Window Model
M38.3 — Rotation Rule Placeholder
M38.4 — Event Priority Rules
M38.5 — LiveOps Debug Timeline
M38.6 — Calendar Save / Mock Binding
M38.7 — LiveOps Calendar Validator
```

Goal: Manage rotating missions, events, seasons, and special campaigns from one planning layer.

---

## M39 — Retention Economy Layer

```text
M39.1 — Soft Currency Sink Review
M39.2 — Reward Cadence Model
M39.3 — Return Bonus Rules
M39.4 — Session Goal Rules
M39.5 — Reward Escalation / Cap Rules
M39.6 — Retention Economy Validator
```

Goal: Make the economy support repeated sessions without collapsing progression balance.

---

## M40 — Social / Competitive Presentation Layer

```text
M40.1 — Player Profile Summary Model
M40.2 — Clinic Rank Badge Model
M40.3 — Public Score Snapshot Placeholder
M40.4 — Rival / Friend Placeholder Model
M40.5 — Competitive Result Presentation
M40.6 — Social Layer Validator
```

Goal: Make competitive and retention systems visible, prestigious, and motivating.

---

## Roadmap placement

These systems should not replace the current M15-M30 core gameplay, UI, progression, save, art, and monetization preparation roadmap.

Instead, they extend the roadmap after the core foundation is stable:

```text
M15-M30 -> Core game loop, UI, progression, save, art, monetization prep
M31-M40 -> LiveOps, retention, competition, seasons, events, PvP, leaderboard
```

---

## Important design rule

All live-ops and competitive systems must be designed with mock/offline-first foundations before real online services are required.

This keeps development safe, testable, deterministic, and compatible with later backend integration.
