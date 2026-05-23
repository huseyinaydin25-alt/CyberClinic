# Supabase Backend Plan — Design Memory

This document defines how Supabase may be used in Cyber Clinic without making core gameplay dependent on online connectivity.

---

## Core backend principle

Supabase is an **online service layer**, not the brain of the game.

The core game loop must work offline:

- procedural patient generation
- operation math
- implant/procedure decisions
- visual/audio feedback
- local save
- basic day flow

Supabase can enhance the game with sync, live content, admin-managed configuration, and long-term services.

---

## Planned Supabase use cases

Potential use cases:

- remote config
- balance values
- live event schedule
- seasonal event activation
- cloud save / backup
- player profiles
- leaderboard
- telemetry events
- admin audit log
- RevenueCat entitlement cache / webhook support
- content publishing support for future admin panel

---

## What Supabase must not own

Supabase must not directly own or calculate:

- operation success chance
- patient generation core logic
- implant compatibility math
- local operation outcomes
- moment-to-moment clinic flow
- VFX/audio behavior

These remain Unity-side domain systems.

---

## Service abstraction

Unity must access Supabase through interfaces, never directly from gameplay modules.

Planned interfaces:

- `IBackendService`
- `IRemoteConfigService`
- `ICloudSaveService`
- `ILeaderboardService`
- `ILiveEventService`
- `ITelemetryService`

Gameplay systems use domain services and events. Backend services sync or enrich after the domain result exists.

---

## Planned tables

Initial schema candidates:

- `players`
- `player_profiles`
- `cloud_saves`
- `remote_config`
- `balance_versions`
- `live_events`
- `leaderboards`
- `iap_entitlements_cache`
- `telemetry_events`
- `admin_audit_log`

These tables are not final. Schema must be designed milestone-by-milestone.

---

## Security principles

- No service-role key in Unity client.
- Row Level Security planned from the start.
- Player can access only their own profile/save data.
- Admin tables are not directly writable from the client.
- Purchases and entitlements should be verified server-side or via RevenueCat webhook flow.
- Secrets live outside repo.

---

## Offline-first strategy

If Supabase is unavailable:

- local save continues
- game can be played
- telemetry may queue or drop safely
- remote config falls back to local defaults
- live events may use cached data or remain inactive
- leaderboard upload retries later

---

## Relationship to special events

Special day, holiday, seasonal, and limited events can be activated through Supabase remote config or live event tables.

Event definitions should still be data-driven in Unity. Supabase can decide which event is active, when it starts, and which content pool is enabled.

---

## Relationship to cosmetics

Supabase can help with:

- event reward tracking
- cloud backup of owned cosmetics
- active seasonal visual themes
- content rotation metadata

RevenueCat remains the source of truth for paid entitlements unless a server-side entitlement cache is created later.

---

## First action later

When backend milestone begins:

1. Create empty Supabase project.
2. Do not add secrets to repo.
3. Draft SQL schema in a docs or migrations folder.
4. Design RLS policies before client connection.
5. Add Unity service interfaces and mocks before real Supabase client wiring.

---

## Non-negotiable rules

1. Offline core gameplay must survive backend outage.
2. No Supabase calls from operation calculator, patient generator, or UI directly.
3. All backend access through service interfaces.
4. No secrets committed.
5. RLS is designed before production data.
6. Backend changes must update this document and `DECISIONS.md` when architectural.
