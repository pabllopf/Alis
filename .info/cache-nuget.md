# Alis - NuGet Package Map

## Overview
Alis publishes 30+ NuGet packages covering core engine, aspects, and extensions. All packages are free under GPL-3.0.

## Core Packages
| Package | NuGet | Version | Description |
|---------|-------|---------|-------------|
| **Alis** | `Alis` | Latest | Full game development bundle - main runtime and entry points |
| **Alis.Core** | `Alis.Core` | Latest | Shared runtime foundations, common abstractions, services |
| **Alis.Core.Ecs** | `Alis.Core.Ecs` | Latest | Entity Component System for high-performance game objects |
| **Alis.Core.Physic** | `Alis.Core.Physic` | Latest | Physics primitives, collisions, movement, world interaction |
| **Alis.Core.Audio** | `Alis.Core.Audio` | Latest | Audio abstractions, playback, routing, music/SFX |
| **Alis.Core.Graphic** | `Alis.Core.Graphic` | Latest | Rendering core, graphics abstractions, pipeline components |

## Aspect Packages
| Package | NuGet | Version | Description |
|---------|-------|---------|-------------|
| **Alis.Core.Aspect** | `Alis.Core.Aspect` | Latest | Aspect-oriented foundation, cross-cutting behavior |
| **Alis.Core.Aspect.Data** | `Alis.Core.Aspect.Data` | Latest | Data aspects: validation, transformation, data access |
| **Alis.Core.Aspect.Fluent** | `Alis.Core.Aspect.Fluent` | Latest | Fluent API for configuring and composing aspects |
| **Alis.Core.Aspect.Logging** | `Alis.Core.Aspect.Logging` | Latest | Logging aspects: tracing, diagnostics, observability |
| **Alis.Core.Aspect.Math** | `Alis.Core.Aspect.Math` | Latest | Math aspects: calculations, numeric consistency |
| **Alis.Core.Aspect.Memory** | `Alis.Core.Aspect.Memory` | Latest | Memory aspects: allocation monitoring, performance |
| **Alis.Core.Aspect.Time** | `Alis.Core.Aspect.Time` | Latest | Timing aspects: latency tracking, benchmarking |

## Extension Packages
| Package | NuGet | Version | Description |
|---------|-------|---------|-------------|
| **Alis.Extension.Ads.GoogleAds** | `Alis.Extension.Ads.GoogleAds` | Latest | Google Ads integration for monetization |
| **Alis.Extension.Cloud.DropBox** | `Alis.Extension.Cloud.DropBox` | Latest | Dropbox connector for cloud file sync |
| **Alis.Extension.Cloud.GoogleDrive** | `Alis.Extension.Cloud.GoogleDrive` | Latest | Google Drive adapter for cloud persistence |
| **Alis.Extension.Graphic.Glfw** | `Alis.Extension.Graphic.Glfw` | Latest | GLFW backend for context creation, input |
| **Alis.Extension.Graphic.Sdl2** | `Alis.Extension.Graphic.Sdl2` | Latest | SDL2 backend for windowing, input, graphics |
| **Alis.Extension.Graphic.Sfml** | `Alis.Extension.Graphic.Sfml` | Latest | SFML integration for 2D rendering |
| **Alis.Extension.Graphic.Ui** | `Alis.Extension.Graphic.Ui` | Latest | UI rendering for menus, overlays, interfaces |
| **Alis.Extension.Io.FileDialog** | `Alis.Extension.Io.FileDialog` | Latest | Native file dialog integration |
| **Alis.Extension.Language.Dialogue** | `Alis.Extension.Language.Dialogue` | Latest | Dialogue system for conversations |
| **Alis.Extension.Language.Translator** | `Alis.Extension.Language.Translator` | Latest | Translation utilities, multilingual support |
| **Alis.Extension.Math.HighSpeedPriorityQueue** | `Alis.Extension.Math.HighSpeedPriorityQueue` | Latest | High-performance priority queue |
| **Alis.Extension.Math.ProceduralDungeon** | `Alis.Extension.Math.ProceduralDungeon` | Latest | Procedural dungeon generation |
| **Alis.Extension.Media.FFmpeg** | `Alis.Extension.Media.FFmpeg` | Latest | FFmpeg media processing |
| **Alis.Extension.Network** | `Alis.Extension.Network` | Latest | Client/server networking, multiplayer |
| **Alis.Extension.Payment.Stripe** | `Alis.Extension.Payment.Stripe` | Latest | Stripe payment processing |
| **Alis.Extension.Profile** | `Alis.Extension.Profile` | Latest | Profile management, player settings |
| **Alis.Extension.Security** | `Alis.Extension.Security` | Latest | Security helpers, hardening |
| **Alis.Extension.Thread** | `Alis.Extension.Thread` | Latest | Threading utilities, concurrency |
| **Alis.Extension.Updater** | `Alis.Extension.Updater` | Latest | Auto-updater service |

## Package Dependencies

### Core Package Dependency Chain
```
Alis (main bundle)
  ├── Alis.Core
  │     ├── Alis.Core.Aspect
  │     │     ├── Alis.Core.Aspect.Data
  │     │     ├── Alis.Core.Aspect.Fluent
  │     │     ├── Alis.Core.Aspect.Logging
  │     │     ├── Alis.Core.Aspect.Math
  │     │     ├── Alis.Core.Aspect.Memory
  │     │     └── Alis.Core.Aspect.Time
  │     ├── Alis.Core.Ecs
  │     │     └── (depends on Alis.Core, Alis.Core.Aspect)
  │     ├── Alis.Core.Audio
  │     │     └── (depends on Alis.Core, Alis.Core.Ecs)
  │     ├── Alis.Core.Graphic
  │     │     └── (depends on Alis.Core, Alis.Core.Ecs)
  │     └── Alis.Core.Physic
  │           └── (depends on Alis.Core, Alis.Core.Ecs)
```

### Extension Package Dependencies
| Extension | Direct Dependencies |
|-----------|-------------------|
| All Extensions | Alis (main bundle) |
| Graphic.Ui | Alis.Core.Ecs, Alis.Core.Graphic |
| Math.ProceduralDungeon | Alis.Core.Aspect.Math |

### External Package Dependencies
| External Package | Version | Used By |
|-----------------|---------|---------|
| Stripe.net | 49.2.0 | Payment.Stripe |
| Google.Ads.Common | 9.5.3 | Ads.GoogleAds |
| Google.Apis.Drive.v3 | 1.68.0.3601 | Cloud.GoogleDrive |
| Dropbox.Api | 7.0.0 | Cloud.DropBox |
| MonoGame.Framework.DesktopGL | - | Graphic extensions, benchmarks |
| Microsoft.CodeAnalysis.CSharp | - | All Generator projects |
| Microsoft.SourceLink.GitHub | 8.0.0 | All packages (symbols) |
| System.IO.Compression | 4.3.0 | .NET Framework targets |
| System.Net.Http | 4.3.0 | .NET Framework targets |
| System.Runtime.CompilerServices.Unsafe | 6.1.1 | All targets |
| System.Memory | 4.6.2 | All targets |

## Testing Dependencies (Not Packaged)
| Package | Purpose |
|---------|---------|
| xunit | Test framework |
| xunit.runner.visualstudio | Test runner |
| Microsoft.NET.Test.Sdk | Test platform |
| Moq | Mocking framework |
| Xunit.StaFact | STA test support |
| BenchmarkDotNet | Performance benchmarks |

## Benchmark Dependencies (Not Packaged)
| Package | Purpose |
|---------|---------|
| Arch | High-performance ECS comparison |
| DefaultEcs | Data-oriented ECS comparison |
| Flecs.NET.Release | Flecs port comparison |
| Friflo.Engine.ECS | Fast ECS comparison |
| HypEcs | Lightweight ECS comparison |
| Scellecs.Morpeh | Morpeh ECS comparison |
| Svelto.ECS | Enterprise ECS comparison |
| myECS | Simple ECS comparison |
| fennecs | Fast ECS comparison |

## Package Metadata
| Property | Value |
|----------|-------|
| **Author** | Pablo Perdomo Falcón |
| **License** | GNU GPL v3.0 |
| **Project URL** | www.alisengine.com |
| **Repository** | https://github.com/pabllopf/Alis |
| **Icon** | logo.png |
| **Tags** | game, framework, windows, macos, linux, ios, android, web |
| **Package Readme** | readme.md |

## Quick Install
```bash
# Full bundle (recommended for most users)
dotnet add package Alis

# Individual core packages
dotnet add package Alis.Core
dotnet add package Alis.Core.Ecs
dotnet add package Alis.Core.Audio
dotnet add package Alis.Core.Graphic
dotnet add package Alis.Core.Physic

# Individual aspect packages
dotnet add package Alis.Core.Aspect
dotnet add package Alis.Core.Aspect.Data
dotnet add package Alis.Core.Aspect.Fluent
dotnet add package Alis.Core.Aspect.Logging
dotnet add package Alis.Core.Aspect.Math
dotnet add package Alis.Core.Aspect.Memory
dotnet add package Alis.Core.Aspect.Time

# Extension packages (as needed)
dotnet add package Alis.Extension.Network
dotnet add package Alis.Extension.Graphic.Ui
dotnet add package Alis.Extension.Media.FFmpeg
dotnet add package Alis.Extension.Graphic.Sdl2
```