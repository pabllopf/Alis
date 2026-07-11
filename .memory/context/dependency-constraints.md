---
title: Dependency Constraints
tags:
  - context
  - dependencies
  - constraints
status: Draft
license: GPLv3
---

# Dependency Constraints

## Layer Dependency Matrix

| Layer | Depends On | Cannot Depend On |
|---|---|---|
| 1 - Presentation | Layer 2 (Application) | Layers 3-6 |
| 2 - Application | Layer 3 (Structuration) | Layers 4-6 |
| 3 - Structuration | Layer 4 (Operation) | Layers 5-6 |
| 4 - Operation | Layer 5 (Declaration) | Layer 6 |
| 5 - Declaration | Layer 6 (Ideation) | None |
| 6 - Ideation | None | None |

## Enforcement

Dependencies are enforced through MSBuild conditional references in `Config.props`:
- Debug mode: Explicit `ProjectReference` based on project directory prefix
- Projects cannot manually add cross-layer `ProjectReference`

## NuGet Dependency Constraints

```yaml
Core Projects (Layers 2-6):
  - No external NuGet packages allowed
  
Extension Projects (Layer 1):
  - NuGet packages allowed only for their specific integration
  - Must be approved in Config.props
  
Approved Packages:
  - Stripe.net -> Alis.Extension.Payment.Stripe
  - Google.Ads.Common -> Alis.Extension.Ads.GoogleAds
  - Google.Apis.Drive.v3 -> Alis.Extension.Cloud.GoogleDrive
  - Dropbox.Api -> Alis.Extension.Cloud.DropBox
```

## Native Binary Constraints

```yaml
Runtime Identifiers:
  - Native libraries stored in runtimes/<rid>/native/
  - Currently supported: win-x64, win-x86, win-arm64, osx-x64, osx-arm64,
    linux-x64, linux-arm64, linux-arm, browser-wasm

Distribution:
  - Native binaries packed as NuGet content
  - Automatically copied to output during build
```

## Related

- [[Architecture Rules]]
- [[Dependency Graph]]
- [[Dependency Index]]
