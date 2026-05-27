# CodeMagic iOS Pipeline Plan

**Milestone:** 12 — CodeMagic iOS Build Pipeline  
**Status:** Draft foundation  
**Unity version:** 6000.3.16f1

---

## Purpose

This document defines the first safe CodeMagic iOS pipeline foundation for Cyber Clinic.

The repository now contains a root-level `codemagic.yaml` draft. It does not contain Apple secrets, certificates, provisioning profiles, private keys, or App Store Connect API keys.

---

## Current pipeline file

```text
codemagic.yaml
```

Workflow id:

```text
cyber-clinic-ios
```

Current behavior:

- selects Unity `6000.3.16f1`
- defines basic iOS build variables
- defines expected CodeMagic environment group: `apple_credentials`
- keeps Unity export, signing, and Xcode archive as TODO echo steps until local iOS build settings are finalized
- exports expected artifact paths
- sends build email notifications to the project owner email

---

## Required CodeMagic UI setup later

Create a CodeMagic app connected to the GitHub repository.

Add an environment group named:

```text
apple_credentials
```

This group should be configured in CodeMagic UI only. Do not commit secret values to git.

Planned variables / integrations:

- Apple Developer Portal or App Store Connect integration
- signing certificate reference
- provisioning profile reference or automatic signing setup
- app identifier / bundle id confirmation
- Unity license handling, if required by CodeMagic setup

---

## Current bundle id placeholder

```text
com.cyberclinic.game
```

This must be finalized before production/TestFlight builds.

---

## Not committed

The following must never be committed:

- `.p12` files
- provisioning profiles
- App Store Connect API private keys
- Apple account passwords
- Unity license secrets
- CodeMagic secret values

---

## Next work before a real TestFlight build

1. Confirm iOS bundle id.
2. Confirm Unity iOS player settings locally.
3. Confirm Apple Developer app identifier.
4. Configure CodeMagic Apple integration in CodeMagic UI.
5. Replace placeholder Unity export TODO with a validated Unity batchmode iOS export command.
6. Replace placeholder Xcode archive TODO with a validated archive/export command.
7. Run first unsigned or development-signed CI test.
8. Move to TestFlight only after signing is stable.

---

## Out of scope for this milestone

- committing Apple secrets
- creating certificates in git
- App Store submission automation
- real TestFlight release
- production signing migration
- monetization SDK integration
- backend deployment
