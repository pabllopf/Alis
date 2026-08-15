# Coverage Index

## Project

```
Name: Alis
Key: pabllopf-official_alis
Branch: master
```

## Previous Coverage State

_No previous state available — fresh start after memory cleanup._

## Current Coverage State (Synced 2026-07-23)

- **Overall Coverage:** 70.5%
- **Line Coverage:** 68.4%
- **Branch Coverage:** 80.7%
- **Uncovered Lines:** 18,226
- **Uncovered Conditions:** 2,334

## Files with Coverage Gaps (Core ECS)

| File | Coverage | Uncovered Lines | Test Files |
|------|----------|-----------------|------------|
| `Gen2GcCallback.cs` | 48.8% | 31 | 2 |
| `EnumerableHelpers.cs` | 80.5% | 11 | 7 |
| `GameObject.cs` | 85.9% | 95 | 40+ |
| `Update.cs` | 87.6% | 28 | 5 |
| `QueryEnumerator.cs` | 93.2% | 16 | 2 |
| `GameObjectExtensions.cs` | 94.1% | 4 | 1 |
| `ComponentRegistry.cs` | 97.0% | 3 | 8 |

## Recent Remediation

| File | Coverage Before | Coverage After | Tests Added |
|------|-----------------|----------------|-------------|
| `Gl.cs` (Graphic/OpenGL) | 30.7% | 100.0% (209/209) | 13 |
| `MacNativePlatform.cs` (Graphic/Osx) | 14.2% | 43.7% (153/350) | 9 |
| `WebAssemblyGameExamples.cs` (Graphic/Web) | 6.3% | 17.4% (73/419) | 14 |
| `ObjectiveCInterop.cs` (Graphic/Osx) | 5.0% | 100.0% (19/19) | 10 |
| `WebAssemblyPlatform.cs` (Graphic/Web) | 4.2% | 74.4% (328/441) | 34 |
| `ImPlotP2.cs` (Ui/Plot) | 1.6% | 84.1% (380/452 local) | 89 |
| `Mouse.cs` (Sfml/Windows) | 0.0% | 55.0% | 6 |
| `NativeWindow.cs` (Glfw) | 0.0% (SonarCloud) | 98.63% (718/728, hook-enabled local run) | 1 + existing worker suite wiring |

## Notable Files with Low Coverage (Filtered)

| File | Coverage | Lines | Type |
|------|----------|-------|------|
| `GraphicManager.cs` | 39.6% | 129 | Platform-dependent |
| `Sprite.cs` | 26.2% | 164 | 7 test files already |
| `BoxCollider.cs` | 54.6% | 110 | 14+ test files |
| `ContextHandler.cs` | 54.9% | 73 | Depends on Runtime/Timing |
| `Gen2GcCallback.cs` | 48.8% | 31 | GC finalizer paths |

## Platforms remaining uncovered

Most remaining uncovered lines (18,226) are in platform-specific, UI-wrapper, or network-dependent code that is difficult to test in isolation.

_No previous delta available — fresh start._
