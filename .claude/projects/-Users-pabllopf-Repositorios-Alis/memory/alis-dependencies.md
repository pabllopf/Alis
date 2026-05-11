---
name: Alis dependencies
description: Project reference graph, external packages, build order for the Alis solution
type: project
---

## Internal Dependencies

### 6_Ideation (leaf - no internal deps)
All aspects: Data, Fluent, Logging, Math, Memory, Time
Generators depend only on Microsoft.CodeAnalysis.CSharp

### 5_Declaration
Alis.Core.Aspect → 6_Ideation/* (Data, Fluent, Logging, Math, Memory, Time)

### 3_Structuration
Alis.Core → 5_Declaration/Aspect + 6_Ideation/*

### 4_Operation
- Alis.Core.Ecs → 3_Structuration/Core + 5_Declaration/Aspect
- Alis.Core.Ecs.Generator → Microsoft.CodeAnalysis.CSharp + 4_Operation/Ecs
- Alis.Core.Audio → 3_Structuration/Core + 4_Operation/Ecs
- Alis.Core.Graphic → 3_Structuration/Core + 4_Operation/Ecs
- Alis.Core.Graphic.Generator → Microsoft.CodeAnalysis.CSharp + 4_Operation/Graphic
- Alis.Core.Physic → 3_Structuration/Core + 4_Operation/Ecs

### 2_Application
Alis → 3_Structuration/Core + 4_Operation/* (Ecs, Audio, Graphic, Physic)

### 1_Presentation
- Alis.App.Engine → 2_Application/Alis + Extension/Graphic.Ui + Io.FileDialog + Updater
- Alis.App.Hub → 2_Application/Alis
- Alis.App.Agent → 2_Application/Alis
- Alis.App.Installer → 2_Application/Alis
- Alis.Benchmark → 2_Application/Alis + 4_Operation/* (all)
- All Extensions → 2_Application/Alis (+ some reference 4_Operation/*)

## Key External Packages
- **Benchmarking**: BenchmarkDotNet
- **Testing**: xunit, Moq, Microsoft.NET.Test.Sdk, Xunit.StaFact
- **ECS libs (benchmark)**: Arch, DefaultEcs, Flecs.NET.Release, Friflo.Engine.ECS, HypEcs, Scellecs.Morpeh, Svelto.ECS, fennecs, MonoGame.Extended.Entities, Leopotam.Ecs
- **Cloud**: Google.Apis.Drive.v3, Dropbox.Api
- **Payment**: Stripe.net
- **Graphics**: MonoGame.Framework.DesktopGL, SDL2 bindings, SFML bindings, GLFW bindings
- **Media**: FFmpeg
- **Analysis**: Roslynator.Analyzers, Microsoft.CodeAnalysis.NetAnalyzers
- **Source Gen**: Microsoft.CodeAnalysis.CSharp, Microsoft.CodeAnalysis.Analyzers

## Config Profiles (.config/default/)
- default_csproj.props, default_app_csproj.props, default_test_csproj.props
- default_sample_csproj.props, default_generator_csproj.props
- default_sample_web_csproj.props, default_sample_android_csproj.props, default_sample_ios_csproj.props
