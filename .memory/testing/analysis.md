---
title: Testing Analysis — ALIS
tags: [testing,test,quality,assurance]
---


## Test Framework

| Component | Technology |
|-----------|-----------|
| Framework | xUnit 2.6.6 |
| Mocking | Moq 4.20.70 |
| Assertions | xUnit built-in |
| Coverage | dotnet cover |
| Output | `.test/<TargetFramework>/` (TRX format) |

## Test Projects (35 total)

### Core Engine Tests (4)

| Test Project | Source | Location |
|-------------|--------|----------|
| Alis.Core.Ecs.Test | Alis.Core.Ecs | 4_Operation/Ecs/test/ |
| Alis.Core.Graphic.Test | Alis.Core.Graphic | 4_Operation/Graphic/test/ |
| Alis.Core.Audio.Test | Alis.Core.Audio | 4_Operation/Audio/test/ |
| Alis.Core.Physic.Test | Alis.Core.Physic | 4_Operation/Physic/test/ |

### Aspect Tests (6)

| Test Project | Source | Location |
|-------------|--------|----------|
| Alis.Core.Aspect.Memory.Test | Alis.Core.Aspect.Memory | 6_Ideation/Memory/test/ |
| Alis.Core.Aspect.Fluent.Test | Alis.Core.Aspect.Fluent | 6_Ideation/Fluent/test/ |
| Alis.Core.Aspect.Data.Test | Alis.Core.Aspect.Data | 6_Ideation/Data/test/ |
| Alis.Core.Aspect.Math.Test | Alis.Core.Aspect.Math | 6_Ideation/Math/test/ |
| Alis.Core.Aspect.Time.Test | Alis.Core.Aspect.Time | 6_Ideation/Time/test/ |
| Alis.Core.Aspect.Logging.Test | Alis.Core.Aspect.Logging | 6_Ideation/Logging/test/ |

### Extension Tests (19)

| Test Project | Source |
|-------------|--------|
| Alis.Extension.Ads.GoogleAds.Test | Alis.Extension.Ads.GoogleAds |
| Alis.Extension.Security.Test | Alis.Extension.Security |
| Alis.Extension.Payment.Stripe.Test | Alis.Extension.Payment.Stripe |
| Alis.Extension.Network.Test | Alis.Extension.Network |
| Alis.Extension.Io.FileDialog.Test | Alis.Extension.Io.FileDialog |
| Alis.Extension.Updater.Test | Alis.Extension.Updater |
| Alis.Extension.Language.Translator.Test | Alis.Extension.Language.Translator |
| Alis.Extension.Language.Dialogue.Test | Alis.Extension.Language.Dialogue |
| Alis.Extension.Math.ProceduralDungeon.Test | Alis.Extension.Math.ProceduralDungeon |
| Alis.Extension.Math.HighSpeedPriorityQueue.Test | Alis.Extension.Math.HighSpeedPriorityQueue |
| Alis.Extension.Graphic.Ui.Test | Alis.Extension.Graphic.Ui |
| Alis.Extension.Graphic.Sfml.Test | Alis.Extension.Graphic.Sfml |
| Alis.Extension.Graphic.Glfw.Test | Alis.Extension.Graphic.Glfw |
| Alis.Extension.Graphic.Sdl2.Test | Alis.Extension.Graphic.Sdl2 |
| Alis.Extension.Profile.Test | Alis.Extension.Profile |
| Alis.Extension.Cloud.DropBox.Test | Alis.Extension.Cloud.DropBox |
| Alis.Extension.Cloud.GoogleDrive.Test | Alis.Extension.Cloud.GoogleDrive |
| Alis.Extension.Thread.Test | Alis.Extension.Thread |
| Alis.Extension.Media.FFmpeg.Test | Alis.Extension.Media.FFmpeg |

### Application Tests (4)

| Test Project | Source |
|-------------|--------|
| Alis.Test | Alis |
| Alis.Core.Test | Alis.Core |
| Alis.App.Engine.Test | Alis.App.Engine |
| Alis.App.Hub.Test | Alis.App.Hub |
| Alis.App.Installer.Test | Alis.App.Installer |

## Test Categories

| Category | Description | Example |
|----------|------------|---------|
| Unit Tests | Component lifecycle, entity operations | ECS component tests |
| Integration Tests | Scene management, system interactions | Scene query tests |
| Platform Tests | Native binding verification | SFML/SDL2/GLFW tests |
| Performance Tests | Benchmark critical paths | Alis.Benchmark |

## Coverage by Layer

| Layer | Test Projects | Estimated Coverage | Priority |
|-------|--------------|-------------------|----------|
| 4_Operation | 4 | ~25% | High |
| 6_Ideation | 6 | ~20% | Medium |
| 1_Presentation (Extensions) | 19 | ~15% | Medium |
| 3_Structuration | 1 | ~10% | Low |
| 2_Application | 1 | ~5% | Low |
| 1_Presentation (Apps) | 3 | ~5% | Low |

## Test Execution

```bash
# Run all tests
dotnet test alis.slnx

# Run specific layer
dotnet test 4_Operation/Ecs/test/Alis.Core.Ecs.Test.csproj

# Run with coverage
dotnet test /p:CollectCoverage=true

# Run Debug + Release
dotnet test -c Debug && dotnet test -c Release
```

## Recommendations

1. Increase core ECS coverage to 80%+
2. Add property-based testing for math types
3. Add fuzzing tests for asset pack parsing
4. Implement integration test suite for cross-system interactions
5. Add platform-specific test matrices
6. Implement snapshot testing for generated code

---

## Related Documentation

- [[system/indexes/tests-index]] — Test project index
- [[system/indexes/projects-index]] — Project inventory
