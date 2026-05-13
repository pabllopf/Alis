# Alis - Solution Files Inventory

## Overview
The Alis repository uses multiple solution files to organize projects by scope. Each .slnx file targets a specific development workflow.

## Solution Files

| File | Scope | Estimated Projects |
|------|-------|--------------------|
| `alis.slnx` | All projects | 142 csproj |
| `alis.apps.slnx` | Application projects | ~12 csproj |
| `alis.benchmark.slnx` | Benchmark projects | ~1 csproj |
| `alis.core.slnx` | Core library projects | ~15 csproj |
| `alis.extensions.slnx` | Extension projects | ~40 csproj |
| `alis.samples.slnx` | Sample projects | ~40 csproj |
| `alis.test.slnx` | Test projects | ~25 csproj |

## alis.slnx - Complete Project Map

### Layer 2: Application (30 projects)
| Folder | Projects |
|--------|----------|
| `/2_Application/Alis/` | Alis.csproj, Alis.Test.csproj |
| `/2_Application/Alis/samples/alis.sample.king.platform/` | Web, Desktop |
| `/2_Application/Alis/samples/alis.sample.flappy.bird/` | Web, Desktop |
| `/2_Application/Alis/samples/alis.sample.space.simulator/` | Web, Desktop |
| `/2_Application/Alis/samples/alis.sample.dino/` | Web, Desktop |
| `/2_Application/Alis/samples/alis.sample.empty/` | Web, Desktop |
| `/2_Application/Alis/samples/alis.sample.pong/` | Web, Desktop |
| `/2_Application/Alis/samples/alis.sample.splitcamera/` | Web, Desktop |
| `/2_Application/Alis/samples/alis.sample.asteroid/` | Web, Desktop, Android, iOS |
| `/2_Application/Alis/samples/alis.sample.rogue/` | Web, Desktop |
| `/2_Application/Alis/samples/alis.sample.snake/` | Web, Desktop |
| `/2_Application/Alis/samples/alis.sample.ruinsoftartarus/` | Web, Desktop |
| `/2_Application/Alis/samples/alis.sample.egg/` | Web, Desktop |
| `/2_Application/Alis/samples/alis.sample.inefable/` | Web, Desktop |

### Layer 3: Structuration (3 projects)
| Folder | Projects |
|--------|----------|
| `/3_Structuration/Core/` | Alis.Core.csproj, Alis.Core.Test.csproj, Alis.Core.Sample.csproj |

### Layer 4: Operation (14 projects)
| Folder | Projects |
|--------|----------|
| `/4_Operation/Ecs/` | src, test, sample, generator (4 projects) |
| `/4_Operation/Graphic/` | src, test, sample, generator (4 projects) |
| `/4_Operation/Audio/` | src, test, sample (3 projects) |
| `/4_Operation/Physic/` | src, test, sample (3 projects) |

### Layer 5: Declaration (3 projects)
| Folder | Projects |
|--------|----------|
| `/5_Declaration/Aspect/` | src, test, sample (3 projects) |

### Layer 6: Ideation (21 projects)
| Folder | Projects |
|--------|----------|
| `/6_Ideation/Memory/` | src, test, sample, generator (4 projects) |
| `/6_Ideation/Fluent/` | src, test, sample, generator (4 projects) |
| `/6_Ideation/Math/` | src, test, sample (3 projects) |
| `/6_Ideation/Time/` | src, test, sample (3 projects) |
| `/6_Ideation/Data/` | src, test, sample, generator (4 projects) |
| `/6_Ideation/Logging/` | src, test, sample (3 projects) |

### Layer 1: Presentation (71 projects)
| Folder | Projects |
|--------|----------|
| `/1_Presentation/Installer/` | Alis.App.Installer.csproj |
| `/1_Presentation/Engine/` | Alis.App.Engine.csproj |
| `/1_Presentation/Hub/` | Alis.App.Hub.csproj |
| `/1_Presentation/Agent/` | Alis.App.Agent.csproj, Alis.App.Query.csproj |
| `/1_Presentation/Benchmark/` | Alis.Benchmark.csproj |
| **Extensions - Ads** | |
| `/1_Presentation/Extension/Ads/GoogleAds/` | src, test, sample (3 projects) |
| **Extensions - Cloud** | |
| `/1_Presentation/Extension/Cloud/DropBox/` | src, test, sample (3 projects) |
| `/1_Presentation/Extension/Cloud/GoogleDrive/` | src, test, sample (3 projects) |
| **Extensions - Graphic** | |
| `/1_Presentation/Extension/Graphic/Ui/` | src, test, sample (3 projects) |
| `/1_Presentation/Extension/Graphic/Sfml/` | src, test, sample (3 projects) |
| `/1_Presentation/Extension/Graphic/Glfw/` | src, test, sample (3 projects) |
| `/1_Presentation/Extension/Graphic/Sdl2/` | src, test, sample (3 projects) |
| **Extensions - Io** | |
| `/1_Presentation/Extension/Io/FileDialog/` | src, test, sample (3 projects) |
| **Extensions - Language** | |
| `/1_Presentation/Extension/Language/Translator/` | src, test, sample (3 projects) |
| `/1_Presentation/Extension/Language/Dialogue/` | src, test, sample (3 projects) |
| **Extensions - Math** | |
| `/1_Presentation/Extension/Math/ProceduralDungeon/` | src, test, sample (3 projects) |
| `/1_Presentation/Extension/Math/HighSpeedPriorityQueue/` | src, test, sample (3 projects) |
| **Extensions - Media** | |
| `/1_Presentation/Extension/Media/FFmpeg/` | src, test, sample (3 projects) |
| **Extensions - Network** | |
| `/1_Presentation/Extension/Network/` | src, test (2 projects) |
| `/1_Presentation/Extension/Network/samples/ConsoleGame/` | client, server (2 projects) |
| `/1_Presentation/Extension/Network/samples/SimpleChat/` | client, server (2 projects) |
| `/1_Presentation/Extension/Network/samples/SimpleGame/` | client, server (2 projects) |
| **Extensions - Payment** | |
| `/1_Presentation/Extension/Payment/Stripe/` | src, test, sample (3 projects) |
| **Extensions - Profile** | |
| `/1_Presentation/Extension/Profile/` | src, test, sample (3 projects) |
| **Extensions - Security** | |
| `/1_Presentation/Extension/Security/` | src, test, sample (3 projects) |
| **Extensions - Thread** | |
| `/1_Presentation/Extension/Thread/` | src, test, sample (3 projects) |
| **Extensions - Updater** | |
| `/1_Presentation/Extension/Updater/` | src, test, sample (3 projects) |

## Project Type Distribution

| Type | Count | Pattern |
|------|-------|---------|
| Library (src) | 45 | `*/src/*.csproj` |
| Test | 38 | `*/test/*.Test.csproj` |
| Sample | 40 | `*/sample/*.Sample.csproj` |
| Generator | 6 | `*/generator/*.Generator.csproj` |
| Application | 4 | Engine, Hub, Agent, Installer |
| Benchmark | 1 | Alis.Benchmark |
| Web Sample | 26 | `*/web/*.Web.csproj` |
| Desktop Sample | 26 | `*/desktop/*.Desktop.csproj` |

## Solution File Selection Guide

| Use Case | Solution File |
|----------|---------------|
| Full solution build | `alis.slnx` |
| Work on core libraries only | `alis.core.slnx` |
| Work on extensions only | `alis.extensions.slnx` |
| Work on samples only | `alis.samples.slnx` |
| Run tests only | `alis.test.slnx` |
| Run benchmarks | `alis.benchmark.slnx` |
| Build applications | `alis.apps.slnx` |

## Project-to-Solution Mapping (Cross-Reference)

| Project | alis.slnx | alis.apps | alis.core | alis.extensions | alis.samples | alis.test |
|---------|:---------:|:---------:|:---------:|:---------------:|:------------:|:---------:|
| Alis.App.Engine | ✓ | ✓ | | | | |
| Alis.App.Hub | ✓ | ✓ | | | | |
| Alis.App.Agent | ✓ | ✓ | | | | |
| Alis.App.Installer | ✓ | ✓ | | | | |
| Alis.Benchmark | ✓ | | ✓ | | | |
| Alis (2_Application) | ✓ | ✓ | ✓ | | | |
| Alis.Test | ✓ | | ✓ | | | ✓ |
| Alis.Core | ✓ | | ✓ | | | |
| Alis.Core.Ecs | ✓ | | ✓ | | | |
| Alis.Core.Audio | ✓ | | ✓ | | | |
| Alis.Core.Graphic | ✓ | | ✓ | | | |
| Alis.Core.Physic | ✓ | | ✓ | | | |
| Alis.Core.Aspect | ✓ | | ✓ | | | |
| All 6_Ideation modules | ✓ | | ✓ | | | |
| All Extensions | ✓ | | | ✓ | | |
| All Sample games | ✓ | | | | ✓ | |
| All Test projects | ✓ | | | | | ✓ |

### Build Optimization Tips
- Use `alis.core.slnx` for fast compilation of just the core libraries
- Use `alis.extensions.slnx` when working on extension features
- Use `alis.samples.slnx` for testing game samples
- Use `alis.test.slnx` for running only test suites