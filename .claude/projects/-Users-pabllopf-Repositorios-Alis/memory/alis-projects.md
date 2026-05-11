---
name: Alis project inventory
description: Complete list of all 142 projects with paths, types, and file counts
type: project
---

## 1_Presentation (71 csproj)

### Apps
- Alis.App.Agent → 1_Presentation/Agent/src/
- Alis.App.Query → 1_Presentation/Agent/query/
- Alis.App.Engine → 1_Presentation/Engine/src/ (depends on Graphic.Ui, Io.FileDialog, Updater, Alis)
- Alis.App.Hub → 1_Presentation/Hub/src/
- Alis.App.Installer → 1_Presentation/Installer/src/
- Alis.Benchmark → 1_Presentation/Benchmark/src/ (215 files, compares 10+ ECS)

### Extensions (src/sample/test pattern)
- Ads.GoogleAds
- Cloud.DropBox, Cloud.GoogleDrive
- Graphic.Glfw, Graphic.Sdl2, Graphic.Sfml, Graphic.Ui (251 files)
- Io.FileDialog
- Language.Dialogue, Language.Translator
- Math.HighSpeedPriorityQueue, Math.ProceduralDungeon (215 files)
- Media.FFmpeg (276 files)
- Network (303 files - largest) + 6 sample clients/servers
- Payment.Stripe
- Profile
- Security
- Thread
- Updater

## 2_Application (30 csproj)
- Alis → 2_Application/Alis/src/ (163 files: Builder + Core/Ecs)
- Alis.Test → 2_Application/Alis/test/
- 13 sample games × (desktop + web, some with android/ios):
  Asteroid, Dino, Egg, Empty, Flappy.Bird, Inefable, King.Platform, Pong, Rogue, RuinsOfTartarus, Snake, Space.Simulator, SplitCamera

## 3_Structuration (3 csproj)
- Alis.Core → 3_Structuration/Core/src/ (multi-target: net471-net9.0)
- Alis.Core.Sample, Alis.Core.Test

## 4_Operation (14 csproj)
- Ecs: src + generator + sample + test (155 files in src)
- Audio: src + sample + test (56 files)
- Graphic: src + generator + sample + test (195 files)
- Physic: src + sample + test (239 files - collisions, joints, decomposition)

## 5_Declaration (3 csproj)
- Alis.Core.Aspect → 5_Declaration/Aspect/src/ (59 files)
- Sample + Test

## 6_Ideation (21 csproj) - src/generator/sample/test pattern
- Data (68 files): JSON serialization
- Fluent (178 files): Fluent API builder
- Logging (74 files): Filters, formatters, outputs
- Math (79 files): Vector, Matrix, Shapes
- Memory (53 files): Memory management
- Time (51 files): Time utilities

## Build Order
6_Ideation → 5_Declaration → 3_Structuration → 4_Operation → 2_Application → 1_Presentation
