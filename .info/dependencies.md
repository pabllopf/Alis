# Alis - Dependency Graph

## Project Reference Map

### Build Order (Topological)
```
6_Ideation/* (no internal deps)
    ↓
5_Declaration/Aspect
    ↓
3_Structuration/Core
    ↓
4_Operation/* (Ecs, Audio, Graphic, Physic)
    ↓
2_Application/Alis
    ↓
1_Presentation/* (Extensions, Apps)
```

### Detailed Dependencies

#### 6_Ideation (No internal dependencies - leaf modules)
```
Alis.Core.Aspect.Data          → (external only: JSON libs, etc.)
Alis.Core.Aspect.Data.Generator → Microsoft.CodeAnalysis.CSharp
Alis.Core.Aspect.Fluent        → (external only)
Alis.Core.Aspect.Fluent.Generator → Microsoft.CodeAnalysis.CSharp
Alis.Core.Aspect.Logging       → (external only)
Alis.Core.Aspect.Math          → (external only)
Alis.Core.Aspect.Memory        → (external only)
Alis.Core.Aspect.Memory.Generator → Microsoft.CodeAnalysis.CSharp
Alis.Core.Aspect.Time          → (external only)
```

#### 5_Declaration
```
Alis.Core.Aspect               → 6_Ideation/* (Data, Fluent, etc.)
```

#### 3_Structuration
```
Alis.Core                    → 5_Declaration/Aspect, 6_Ideation/*
```

#### 4_Operation
```
Alis.Core.Ecs                → 3_Structuration/Core, 5_Declaration/Aspect
Alis.Core.Ecs.Generator      → Microsoft.CodeAnalysis.CSharp, 4_Operation/Ecs
Alis.Core.Audio              → 3_Structuration/Core, 4_Operation/Ecs
Alis.Core.Graphic            → 3_Structuration/Core, 4_Operation/Ecs
Alis.Core.Graphic.Generator  → Microsoft.CodeAnalysis.CSharp, 4_Operation/Graphic
Alis.Core.Physic             → 3_Structuration/Core, 4_Operation/Ecs
```

#### 2_Application
```
Alis                         → 3_Structuration/Core, 4_Operation/* (Ecs, Audio, Graphic, Physic)
Alis.Test                    → Alis, xunit, Moq
```

#### 1_Presentation - Applications
```
Alis.App.Engine              → 2_Application/Alis, 1_Presentation/Extension/Graphic.Ui,
                                Io.FileDialog, Updater
Alis.App.Engine.Test         → Alis.App.Engine, xunit
Alis.App.Hub                 → 2_Application/Alis
Alis.App.Hub.Test            → Alis.App.Hub, xunit
Alis.App.Agent               → 2_Application/Alis
Alis.App.Installer           → 2_Application/Alis
Alis.App.Installer.Test      → Alis.App.Installer, xunit
Alis.Benchmark               → 2_Application/Alis, 4_Operation/* (all ECS, Physic, etc.)
```

#### 1_Presentation - Extensions
```
Alis.Extension.Ads.GoogleAds     → 2_Application/Alis, Google.Apis.Drive.v3
Alis.Extension.Cloud.DropBox     → 2_Application/Alis, Dropbox.Api
Alis.Extension.Cloud.GoogleDrive → 2_Application/Alis, Google.Apis.Drive.v3
Alis.Extension.Graphic.Glfw      → 2_Application/Alis, MonoGame.Framework.DesktopGL
Alis.Extension.Graphic.Sdl2      → 2_Application/Alis, SDL2 bindings
Alis.Extension.Graphic.Sfml      → 2_Application/Alis, SFML bindings
Alis.Extension.Graphic.Ui        → 2_Application/Alis, 4_Operation/Ecs, 4_Operation/Graphic
Alis.Extension.Io.FileDialog     → 2_Application/Alis
Alis.Extension.Language.Dialogue → 2_Application/Alis
Alis.Extension.Language.Translator → 2_Application/Alis
Alis.Extension.Math.HighSpeedPriorityQueue → (standalone)
Alis.Extension.Math.ProceduralDungeon → 2_Application/Alis, 6_Ideation/Math
Alis.Extension.Media.FFmpeg      → 2_Application/Alis
Alis.Extension.Network           → 2_Application/Alis
Alis.Extension.Payment.Stripe    → 2_Application/Alis, Stripe.net
Alis.Extension.Profile           → 2_Application/Alis
Alis.Extension.Security          → 2_Application/Alis
Alis.Extension.Thread            → 2_Application/Alis
Alis.Extension.Updater           → 2_Application/Alis
```

## Dependency Graph Visualization

```
                    ┌─────────────────────────────────┐
                    │   6_Ideation (Leaf Modules)      │
                    │  Data, Fluent, Logging, Math,    │
                    │  Memory, Time + Generators       │
                    └──────────────┬──────────────────┘
                                   ↓
                    ┌─────────────────────────────────┐
                    │   5_Declaration (Aspects)        │
                    │  Alis.Core.Aspect               │
                    └──────────────┬──────────────────┘
                                   ↓
                    ┌─────────────────────────────────┐
                    │   3_Structuration (Core)         │
                    │  Alis.Core                      │
                    └──────────────┬──────────────────┘
                                   ↓
              ┌────────────────────┼────────────────────┐
              ↓                    ↓                    ↓
    ┌─────────────────┐  ┌─────────────────┐  ┌─────────────────┐
    │ 4_Operation/Ecs │  │ 4_Operation/    │  │ 4_Operation/    │
    │                 │  │ Graphic         │  │ Physic          │
    │ + Audio         │  │ + Generator     │  │                 │
    └────────┬────────┘  └────────┬────────┘  └────────┬────────┘
             │                    │                    │
             └────────────────────┼────────────────────┘
                                  ↓
                    ┌─────────────────────────────────┐
                    │   2_Application/Alis             │
                    │  Main app + 13 sample games      │
                    └──────────────┬──────────────────┘
                                   ↓
              ┌────────────────────┼────────────────────┐
              ↓                    ↓                    ↓
    ┌─────────────────┐  ┌─────────────────┐  ┌─────────────────┐
    │ Apps            │  │ Extensions      │  │ Benchmarks      │
    │ Engine, Hub,    │  │ 25+ extensions  │  │ 10+ ECS         │
    │ Agent, Installer│  │ Ads, Cloud,     │  │ comparisons     │
    │                 │  │ Graphic, Net,   │  │                 │
    │                 │  │ Media, etc.     │  │                 │
    └─────────────────┘  └─────────────────┘  └─────────────────┘
```

## Cross-Module References

### Which modules reference which?
| Referencing Module | Referenced Modules |
|-------------------|-------------------|
| 1_Presentation | 2_Application, 3_Structuration, 4_Operation, 6_Ideation |
| 2_Application | 3_Structuration, 4_Operation |
| 3_Structuration | 5_Declaration, 6_Ideation |
| 4_Operation | 3_Structuration, 5_Declaration, 6_Ideation |
| 5_Declaration | 6_Ideation |
| 6_Ideation | (none - leaf) |

## External Dependencies by Module

### 4_Operation
| Package | Used By |
|---------|---------|
| MonoGame.Framework.DesktopGL | Graphic, Extensions |
| DefaultEcs | Benchmark |
| Arch | Benchmark |
| Flecs.NET.Release | Benchmark |
| Friflo.Engine.ECS | Benchmark |
| HypEcs | Benchmark |
| Scellecs.Morpeh | Benchmark |
| Svelto.ECS | Benchmark |
| fennecs | Benchmark |

### 1_Presentation Extensions
| Package | Extension |
|---------|-----------|
| Google.Apis.Drive.v3 | Cloud.GoogleDrive, Ads.GoogleAds |
| Dropbox.Api | Cloud.DropBox |
| Stripe.net | Payment.Stripe |
| FFmpeg binaries | Media.FFmpeg |
