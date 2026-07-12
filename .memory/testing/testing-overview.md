---
title: Testing Overview
tags:
  - testing
  - overview
  - coverage
status: Draft
license: GPLv3
---

# Testing Overview

## Test Framework

| Component | Tool |
|---|---|
| Unit Testing | xUnit |
| Mocking | Moq |
| WPF/Sync Context | Xunit.StaFact |
| Code Coverage | coverlet |
| Test Results | `.test/<TargetFramework>/*.trx` |

## Test Distribution

| Layer | Module | Test Files | Test Density |
|---|---|---|---|
| 6_Ideation | Data | 38 | High |
| 6_Ideation | Fluent | 75 | Very High |
| 6_Ideation | Logging | 78 | Very High |
| 6_Ideation | Math | 45 | High |
| 6_Ideation | Memory | 7 | Medium |
| 6_Ideation | Time | 3 | Low |
| 5_Declaration | Aspect | 1 | Minimal |
| 4_Operation | Audio | 40 | High |
| 4_Operation | Ecs | 190 | Very High |
| 4_Operation | Graphic | 90 | Very High |
| 4_Operation | Physic | 225 | Very High |

## Test Patterns

### Naming Convention
- `{Class}Test.cs` — Primary test class
- `{Class}ExtensiveTest.cs` — Parameterized exhaustive tests
- `{Class}CoverageTest.cs` — Branch/edge-case coverage
- `{Class}RemainingCoverageTests.cs` — Final coverage push
- `{Class}EdgeCaseTest.cs` — Edge case scenarios
- `{Class}SafeTests.cs` — Tests safe for all environments

### Platform-Specific Testing
Custom xUnit attributes for platform-dependent tests:
- `WindowsOnlyAttribute`
- `MacOsOnlyAttribute`
- `LinuxOnlyAttribute`
- `BrowserOnlyAttribute`
- `UnixOnlyAttribute`

These ensure platform-specific code (P/Invoke, native interop) is only tested on the appropriate platform.

### Coverage Approach
- Physics and ECS modules have the highest coverage (likely >95%)
- Edge case and branch coverage tests indicate strong emphasis on reliability
- Some modules (Time, Memory) have lower test counts relative to complexity

## Coverage Gaps

| Area | Risk |
|---|---|
| Presentation layer apps (Engine, Hub, Installer) | Lower test density |
| Extension projects | Minimal testing (some have no tests) |
| Sample projects | Not tested |
| Generator projects | Limited testing |
| Platform-specific code (non-Browser) | Lower test coverage on non-macOS platforms |

## Running Tests

```bash
# Quick test
dotnet test alis_design.sln -c Release -f net8.0

# Full test suite
./docs/scripts/macos/run_tests.sh
```

## Related Documents

- [[tests-index]]
- [[security-overview]]
- [[conventions-overview]]
