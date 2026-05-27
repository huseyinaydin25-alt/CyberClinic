# Milestone 12 Completion — CodeMagic iOS Build Pipeline

**Date:** 2026-05-27  
**Status:** Draft foundation completed  
**Scope:** Safe CodeMagic iOS pipeline draft and setup documentation.

---

## Completed

- Unity project version checked:

```text
6000.3.16f1
```

- Root `codemagic.yaml` draft added.
- `CODEMAGIC_IOS_PIPELINE.md` added.
- Workflow id added:

```text
cyber-clinic-ios
```

- Expected CodeMagic environment group documented:

```text
apple_credentials
```

---

## Pipeline status

The pipeline is intentionally a safe draft.

Current steps:

- verify expected Unity version by log
- placeholder Unity iOS export step
- placeholder signing preparation step
- placeholder Xcode archive step
- artifact path draft
- email notification draft

Real Unity export and Xcode archive commands are left as TODO until iOS player settings and Apple signing are confirmed.

---

## Not committed

No secrets were committed.

Not included:

- Apple certificates
- provisioning profiles
- App Store Connect API private keys
- Apple account passwords
- Unity license secrets
- CodeMagic secret values

---

## Not created

- real TestFlight release
- App Store submission automation
- production signing migration
- monetization SDK integration
- backend deployment

---

## Next step

Configure CodeMagic UI and Apple Developer / App Store Connect signing outside git before enabling real iOS archive and TestFlight steps.
