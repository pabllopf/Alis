# Alis — Layer 1: Presentation (Projects, Dependencies, Key Types)

## Overview

- **Directory**: `1_Presentation/`
- **Total .cs files**: ~1,539 (src: 968, test: 484, other: 87)
- **Total projects**: ~75 (4 apps, 19 extensions × 3 variants, 6 network samples, 1 benchmark)
- **Build target**: `net8.0` for apps, `net10.0` for samples, `net8.0` for tests
- **Outputs EXE** (apps/samples) or **Library** (extensions/tests)

## Applications (4 + Test)

| Project | Path | TF | Description | Key Dependencies |
|---------|------|----|-------------|-----------------|
| Alis.App.Engine | `Engine/src/` | net8.0 | Main game engine runtime, windows, menus, demos, shaders, fonts, icons, entity system, config, shortcut | Alis, Graphic.Ui, Updater, FileDialog, all generators as analyzers |
| Alis.App.Engine.Test | `Engine/test/` | net8.0 | Engine tests | Alis.App.Engine, xunit, Moq |
| Alis.App.Hub | `Hub/src/` | net8.0 | Hub application for managing games/projects; Mac DMG bundling, Windows/Linux zip bundling | Alis, Graphic.Ui, Updater, FileDialog, Engine (built/copied), Installer (built/copied) |
| Alis.App.Hub.Test | `Hub/test/` | net8.0 | Hub tests | Alis.App.Hub, xunit, Moq |
| Alis.App.Agent | `Agent/src/` | net8.0 | AI agent application | Alis |
| Alis.App.Query | `Agent/query/` | net8.0 | Agent query interface | Alis |
| Alis.App.Installer | `Installer/src/` | net8.0 | Application installer | Alis, Graphic.Ui, Updater, FileDialog |
| Alis.App.Installer.Test | `Installer/test/` | net8.0 | Installer tests | Alis.App.Installer, xunit, Moq |
| Alis.Benchmark | `Benchmark/src/` | net8.0 | Performance suite comparing 10+ ECS impls + class/struct, interface/abstract, collection benchmarks | Alis, BenchmarkDotNet, Arch, DefaultEcs, Flecs.NET, Friflo, HypEcs, Morpeh, Svelto, fennecs, Leopotam, MonoGame.Extended, Myriad, RelEcs, Frent |

## Extensions (19 Libraries, each with src/sample/test)

### Ads (1)
| Project | Path | Files | External Dep |
|---------|------|-------|-------------|
| Alis.Extension.Ads.GoogleAds | `Extension/Ads/GoogleAds/src/` | 4 | Google.Ads.Common 9.5.3 |
| Sample | `sample/` | 2 | Alis.csproj |
| Test | `test/` | 2 | Alis.Extension.Ads.GoogleAds, xunit, Moq |

### Cloud (2)
| Project | Path | Files | External Dep |
|---------|------|-------|-------------|
| Alis.Extension.Cloud.DropBox | `Extension/Cloud/DropBox/src/` | 4 | Dropbox.Api 7.0.0 |
| Alis.Extension.Cloud.GoogleDrive | `Extension/Cloud/GoogleDrive/src/` | 4 | Google.Apis.Drive.v3 1.68.0.3601 |

### Graphic (4)
| Project | Path | Files | External Dep |
|---------|------|-------|-------------|
| Alis.Extension.Graphic.Glfw | `Extension/Graphic/Glfw/src/` | 30+ | MonoGame.Framework.DesktopGL |
| Alis.Extension.Graphic.Sdl2 | `Extension/Graphic/Sdl2/src/` | 179+ | SDL2 native bindings |
| Alis.Extension.Graphic.Sfml | `Extension/Graphic/Sfml/src/` | ~115 | SFML native bindings |
| Alis.Extension.Graphic.Ui | `Extension/Graphic/Ui/src/` | 109+ | — |

### Io (1)
| Project | Path | Files | External Dep |
|---------|------|-------|-------------|
| Alis.Extension.Io.FileDialog | `Extension/Io/FileDialog/src/` | 12 | — |

### Language (2)
| Project | Path | Files | External Dep |
|---------|------|-------|-------------|
| Alis.Extension.Language.Dialogue | `Extension/Language/Dialogue/src/` | 17 | — |
| Alis.Extension.Language.Translator | `Extension/Language/Translator/src/` | ~20 | — |

### Math (2)
| Project | Path | Files | External Dep |
|---------|------|-------|-------------|
| Alis.Extension.Math.HighSpeedPriorityQueue | `Extension/Math/HighSpeedPriorityQueue/src/` | 9 | — |
| Alis.Extension.Math.ProceduralDungeon | `Extension/Math/ProceduralDungeon/src/` | ~50 | — |

### Media (1)
| Project | Path | Files | External Dep |
|---------|------|-------|-------------|
| Alis.Extension.Media.FFmpeg | `Extension/Media/FFmpeg/src/` | ~50 | FFmpeg native binaries |

### Network (1 + 6 samples)
| Project | Path | Files | External Dep |
|---------|------|-------|-------------|
| Alis.Extension.Network | `Extension/Network/src/` | 34 | — |
| Alis.Extension.Network.Test | `test/` | 13 | Network, xunit, Moq |
| Sample.ConsoleGame.Client | `samples/ConsoleGame/client/` | 9 | Network |
| Sample.ConsoleGame.Server | `samples/ConsoleGame/server/` | 8 | Network |
| Sample.SimpleChat.Client | `samples/SimpleChat/client/` | 3 | Network |
| Sample.SimpleChat.Server | `samples/SimpleChat/server/` | 2 | Network |
| Sample.SimpleGame.Client | `samples/SimpleGame/client/` | 9 | Network |
| Sample.SimpleGame.Server | `samples/SimpleGame/server/` | 8 | Network |

### Payment (1)
| Project | Path | Files | External Dep |
|---------|------|-------|-------------|
| Alis.Extension.Payment.Stripe | `Extension/Payment/Stripe/src/` | 16 | Stripe.net 49.2.0 |

### Profile (1)
| Project | Path | Files | External Dep |
|---------|------|-------|-------------|
| Alis.Extension.Profile | `Extension/Profile/src/` | ~45 | — |

### Security (1)
| Project | Path | Files | External Dep |
|---------|------|-------|-------------|
| Alis.Extension.Security | `Extension/Security/src/` | 9 | — |

### Thread (1)
| Project | Path | Files | External Dep |
|---------|------|-------|-------------|
| Alis.Extension.Thread | `Extension/Thread/src/` | ~30 | — |

### Updater (1)
| Project | Path | Files | External Dep |
|---------|------|-------|-------------|
| Alis.Extension.Updater | `Extension/Updater/src/` | ~15 | — |

## Network Extension — Key Types

| Namespace | Types |
|-----------|-------|
| `Alis.Extension.Network.Core` | Core networking abstractions, 20+ files |
| `Alis.Extension.Network.Client` | Client-side networking |
| `Alis.Extension.Network.Server` | Server-side networking |
| `Alis.Extension.Network.Internal` | Internal utilities |
| `Alis.Extension.Network.Exceptions` | Exception types |

## Large Directories within Extensions

| Directory | Files | Project |
|-----------|-------|---------|
| `Extension/Graphic/Ui/src/Extras/Plot` | 64 | Graph.Ui |
| `Extension/Graphic/Ui/src` | 109 | Graph.Ui |
| `Extension/Graphic/Ui/test/Extras/Plot` | 33 | Graph.Ui |
| `Extension/Graphic/Ui/test/Extras/Node` | 15 | Graph.Ui |
| `Extension/Graphic/Sdl2/src/Structs` | 56 | Graph.Sdl2 |
| `Extension/Graphic/Sdl2/src/Enums` | 50 | Graph.Sdl2 |
| `Extension/Graphic/Sdl2/src/Delegates` | 13 | Graph.Sdl2 |
| `Extension/Graphic/Sfml/src/Windows` | 39 | Graph.Sfml |
| `Extension/Graphic/Sfml/src/Render` | 37 | Graph.Sfml |
| `Extension/Math/ProceduralDungeon/src` | ~50 | Math.ProceduralDungeon |
| `Extension/Media/FFmpeg/src` | ~50 | Media.FFmpeg |
| `Extension/Thread/src` | ~30 | Thread |
| `Extension/Profile/src` | ~45 | Profile |
| `Extension/Network/src/Core` | 20 | Network |
| `Extension/Network/src` | 14 | Network |
| `Extension/Language/Translator/src` | ~20 | Language.Translator |
| `Extension/Language/Dialogue/src/Core` | 14 | Language.Dialogue |

## Extension Categories Summary

| Category | Count | Total Files (src only) |
|----------|-------|----------------------|
| Graphic | 4 | ~410 |
| Math | 2 | ~59 |
| Language | 2 | ~37 |
| Cloud | 2 | 8 |
| Thread | 1 | ~30 |
| Media | 1 | ~50 |
| Network | 1 (+6 samples) | ~34 (+28) |
| Payment | 1 | 16 |
| Profile | 1 | ~45 |
| Security | 1 | 9 |
| Updater | 1 | ~15 |
| Io | 1 | 12 |
| Ads | 1 | 4 |
| **Total** | **19 libs + 6 samples** | **~695** |

## App-Specific Details

### Engine (`Alis.App.Engine`)
- 10 Windows
- 6 Menus
- 6 Demos
- 3 Shaders
- 4 Fonts
- 2 Icons
- 2 Entity
- 2 Configuration
- 1 Shortcut
- Custom MSBuild targets: asset packaging (SHA256 manifest, zip→base64 encoding for cross-platform)

### Hub (`Alis.App.Hub`)
- 7 Windows/Sections
- 5 Entity
- 2 Core
- 3 Utils
- Custom MSBuild targets: copies Engine+Installer output, creates DMG (macOS), zip (Linux/Windows)

### Agent (`Alis.App.Agent + Query`)
- AI agent application
- Query interface

### Installer (`Alis.App.Installer`)
- Application installer
- 4 src + 2 test
