# Alis - CI/CD Pipeline Cache

## Overview
The Alis repository uses GitHub Actions for continuous integration, testing, code quality checks, and package publishing. Each module and extension has its own SonarCloud workflow.

## Workflow Files Location
`.github/workflows/[ALIS]*.yml`

## CI/CD Workflows

### Core Pipelines
| Workflow | File | Purpose |
|----------|------|---------|
| **TEST** | `[ALIS][TEST].yml` | Run all tests across the solution |
| **CODE** | `[ALIS][CODE].yml` | Code quality checks, linting |
| **BENCHMARK** | `[ALIS][BENCHMARK].yml` | Run ECS benchmark suite |
| **PUBLISH** | `[ALIS][PUBLISH].yml` | Publish NuGet packages |
| **DEPENDENCY REVIEW** | `[ALIS][DEPENDENCY][REVIEW].yml` | Review dependency changes |
| **CONTRIBUTORS** | `[ALIS][CONTRIBUTORS].yml` | Track new contributors |
| **NEW CONTRIBUTORS** | `[ALIS][NEW][CONTRIBUTORS].yml` | New contributor onboarding |
| **CHECK ISSUES** | `[ALIS][CHECK][ISSUES].yml` | Issue triage and checking |

### SonarCloud Quality Pipelines

#### Core Module SonarCloud
| Workflow | Module |
|----------|--------|
| `[ALIS][CORE][SONARCLOUD].yml` | Alis.Core (3_Structuration) |
| `[ALIS][CORE][ECS][SONARCLOUD].yml` | Alis.Core.Ecs (4_Operation) |
| `[ALIS][CORE][AUDIO][SONARCLOUD].yml` | Alis.Core.Audio (4_Operation) |
| `[ALIS][CORE][GRAPHIC][SONARCLOUD].yml` | Alis.Core.Graphic (4_Operation) |
| `[ALIS][CORE][PHYSIC][SONARCLOUD].yml` | Alis.Core.Physic (4_Operation) |

#### Aspect Module SonarCloud
| Workflow | Module |
|----------|--------|
| `[ALIS][CORE][ASPECT][SONARCLOUD].yml` | Alis.Core.Aspect (5_Declaration) |
| `[ALIS][CORE][ASPECT][DATA][SONARCLOUD].yml` | Alis.Core.Aspect.Data (6_Ideation) |
| `[ALIS][CORE][ASPECT][FLUENT][SONARCLOUD].yml` | Alis.Core.Aspect.Fluent (6_Ideation) |
| `[ALIS][CORE][ASPECT][LOGGING][SONARCLOUD].yml` | Alis.Core.Aspect.Logging (6_Ideation) |
| `[ALIS][CORE][ASPECT][MATH][SONARCLOUD].yml` | Alis.Core.Aspect.Math (6_Ideation) |
| `[ALIS][CORE][ASPECT][MEMORY][SONARCLOUD].yml` | Alis.Core.Aspect.Memory (6_Ideation) |
| `[ALIS][CORE][ASPECT][TIME][SONARCLOUD].yml` | Alis.Core.Aspect.Time (6_Ideation) |

#### Extension SonarCloud Workflows
| Workflow | Extension Category |
|----------|-------------------|
| `[ALIS][EXTENSION][ADS][GOOGLEADS][SONARCLOUD].yml` | GoogleAds |
| `[ALIS][EXTENSION][CLOUD][DROPBOX][SONARCLOUD].yml` | DropBox |
| `[ALIS][EXTENSION][CLOUD][GOOGLEDRIVE][SONARCLOUD].yml` | GoogleDrive |
| `[ALIS][EXTENSION][GRAPHIC][GLFW][SONARCLOUD].yml` | Graphic.Glfw |
| `[ALIS][EXTENSION][GRAPHIC][SDL2][SONARCLOUD].yml` | Graphic.Sdl2 |
| `[ALIS][EXTENSION][GRAPHIC][SFML][SONARCLOUD].yml` | Graphic.Sfml |
| `[ALIS][EXTENSION][GRAPHIC][UI][SONARCLOUD].yml` | Graphic.Ui |
| `[ALIS][EXTENSION][IO][FILEDIALOG][SONARCLOUD].yml` | Io.FileDialog |
| `[ALIS][EXTENSION][LANGUAGE][DIALOGUE][SONARCLOUD].yml` | Language.Dialogue |
| `[ALIS][EXTENSION][LANGUAGE][TRANSLATOR][SONARCLOUD].yml` | Language.Translator |
| `[ALIS][EXTENSION][MATH][HIGHSPEEDPRIORITYQUEUE][SONARCLOUD].yml` | Math.HighSpeedPriorityQueue |
| `[ALIS][EXTENSION][MATH][PROCEDURALDUNGEON][SONARCLOUD].yml` | Math.ProceduralDungeon |
| `[ALIS][EXTENSION][MEDIA][FFMPEG][SONARCLOUD].yml` | Media.FFmpeg |
| `[ALIS][EXTENSION][NETWORK][SONARCLOUD].yml` | Network |
| `[ALIS][EXTENSION][PAYMENT][STRIPE][SONARCLOUD].yml` | Payment.Stripe |
| `[ALIS][EXTENSION][PROFILE][SONARCLOUD].yml` | Profile |
| `[ALIS][EXTENSION][SECURITY][SONARCLOUD].yml` | Security |
| `[ALIS][EXTENSION][THREAD][SONARCLOUD].yml` | Thread |
| `[ALIS][EXTENSION][UPDATER][SONARCLOUD].yml` | Updater |

**Total SonarCloud workflows: 38**
**Total workflow files: 41**

## SonarCloud Metrics Tracked
From readme.md badges, SonarCloud tracks:
- Coverage
- Lines of Code (LOC)
- Maintainability Rating (SQALE)
- Code Smells
- Technical Debt
- Security Rating
- Bugs
- Reliability Rating
- Duplicated Lines Density
- Vulnerabilities

## Local Build/Test Scripts

### macOS Scripts (`docs/scripts/macos/`)
| Script | Purpose | Count |
|--------|---------|-------|
| Build scripts | Build specific modules or all | Multiple |
| Test scripts | Run tests (Debug + Release) | Multiple |
| Clean scripts | Clean build artifacts | Multiple |
| Pack scripts | Package NuGet packages | Multiple |
| **Total** | | **21 scripts** |

### Linux Scripts (`docs/scripts/linux/`)
| Script | Purpose | Count |
|--------|---------|-------|
| Install scripts | Install dependencies | Multiple |
| Generate scripts | Run source generators | Multiple |
| Test scripts | Run tests | Multiple |
| **Total** | | **6 scripts** |

### Windows Scripts (`docs/scripts/windows/`)
| Script | Purpose | Count |
|--------|---------|-------|
| Batch equivalents | Windows versions of macOS scripts | Multiple |
| **Total** | | **8 scripts** |

## CI Pipeline Flow
```
Push to main/PR
    ↓
[ALIS][CODE] - Code quality checks
    ↓
[ALIS][TEST] - Run all tests
    ↓
[ALIS][BENCHMARK] - Run benchmarks (if applicable)
    ↓
Per-module SonarCloud analysis (parallel)
    ↓
[ALIS][PUBLISH] - Publish NuGet packages (on tag/release)
```

## Test Configuration
| Setting | Value |
|---------|-------|
| **Test Framework** | xunit |
| **Test Runner** | Microsoft.NET.Test.Sdk |
| **Mocking** | Moq |
| **STA Tests** | Xunit.StaFact |
| **Test Logger** | TRX format |
| **Test Output Directory** | `.test/{TargetFramework}/` |
| **InternalsVisibleTo** | `{AssemblyName}.Test` (auto-injected) |

## NuGet Publishing
- **Package Source**: https://www.nuget.org/profiles/pabllopf
- **Total Downloads**: 1M+
- **Package Format**: snupkg (symbols)
- **SourceLink**: GitHub integration enabled
- **Deterministic Builds**: Enabled