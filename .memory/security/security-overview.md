---
title: Security Overview
tags:
  - security
  - overview
  - audit
status: Draft
license: GPLv3
---

# Security Overview

## Analysis Scope

Security analysis of the Alis game framework repository.

## Observations

### External NuGet Dependencies (Limited)
Only 4 specific extension projects have external dependencies:
- `Alis.Extension.Payment.Stripe` → Stripe.net
- `Alis.Extension.Ads.GoogleAds` → Google.Ads.Common
- `Alis.Extension.Cloud.GoogleDrive` → Google.Apis.Drive.v3
- `Alis.Extension.Cloud.DropBox` → Dropbox.Api

All core projects have zero external dependencies (except SourceLink).

### Build Security
- `TreatWarningsAsErrors` = true
- `AnalysisMode` = AllEnabledByDefault
- `AnalysisLevel` = latest
- `Nullable` = disabled (project-wide)
- `AllowUnsafeBlocks` = false
- SonarCloud analysis active

### Code Quality
- Warnings as errors enforced
- .NET analyzers enabled at highest level
- SonarCloud static analysis active (bugs + security hotspots tracked)
- Extensive test coverage for critical modules

### Platform Native Interop
- P/Invoke usage in:
  - Windows: User32, Gdi32, Opengl32, Kernel32
  - macOS: Objective-C interop
  - Linux: X11 interop
- Browser: WebAssembly/JS interop via Emscripten
- Native methods are wrapped following the `S4200` suppression pattern

### SonarCloud Issues Tracked

| Category | Count | Status |
|---|---|---|
| Bugs | 5 | 0 pending (all resolved) |
| Security Hotspots | 1 | Resolved |
| Code Smells | - | Not tracked in this session |

## Risk Areas

1. **Native interop surface** — platform-specific P/Invoke calls could be exploited if input validation is insufficient
2. **Deserialization** — JSON deserialization in `Alis.Core.Aspect.Data` has been hardened with validation in deserialization constructors
3. **Asset loading** — ZIP-based asset packing in `Alis.Core.Aspect.Memory` could be an attack vector for malformed archives
4. **Network extension** — requires code review for common network security issues

## Related Documents

- [[testing-overview]]
- [[Alis.Core.Aspect.Data]]
- [[conventions-overview]]
