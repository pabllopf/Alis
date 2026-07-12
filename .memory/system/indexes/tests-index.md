---
title: Tests Index
tags:
  - index
  - tests
  - testing
status: Draft
license: GPLv3
---

# Tests Index

## Test Infrastructure

| Aspect | Detail |
|---|---|
| Framework | xUnit |
| Mocking | Moq |
| WPF/Synchronization | Xunit.StaFact |
| Code Coverage | coverlet |
| Results Directory | `.test/<TargetFramework>/` |
| Test Runner | `dotnet test` |

## Test Counts by Project

| Project | Test Files (approx.) |
|---|---|
| Alis.Core.Aspect.Data.Test | 38 |
| Alis.Core.Aspect.Fluent.Test | 75 |
| Alis.Core.Aspect.Logging.Test | 78 |
| Alis.Core.Aspect.Math.Test | 45 |
| Alis.Core.Aspect.Memory.Test | 7 |
| Alis.Core.Aspect.Time.Test | 3 |
| Alis.Core.Aspect.Test | 1 |
| Alis.Core.Audio.Test | 40 |
| Alis.Core.Ecs.Test | 190 |
| Alis.Core.Graphic.Test | 90 |
| Alis.Core.Physic.Test | 225 |
| Alis.Core.Test | - |
| Alis.Test | - |
| Alis.App.Engine.Test | - |
| Alis.App.Hub.Test | - |
| Alis.App.Installer.Test | - |

## Test Patterns

- **Unit tests**: Individual class/method tests following AAA pattern
- **Extensive tests**: Comprehensive parameterized tests
- **Coverage tests**: Branch/edge-case focused tests
- **Platform-specific**: Conditional test execution via attributes (WindowsOnly, MacOsOnly, LinuxOnly, BrowserOnly, UnixOnly)
- **Integration tests**: Cross-component interaction tests
- **Stress tests**: Thread safety and performance tests

## Platform-Specific Test Attributes

Custom attributes for conditional test execution:
- `WindowsOnlyAttribute`
- `MacOsOnlyAttribute`
- `LinuxOnlyAttribute`
- `BrowserOnlyAttribute`
- `UnixOnlyAttribute`

## Related Documents

- [[testing-overview]]
- [[projects-index]]
- [[conventions-overview]]
