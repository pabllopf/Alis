---
title: ALIS Project Index
tags:
  - project
  - documentation
  - reference

status: draft

license: GPLv3
---


## Overview
Comprehensive documentation for the ALIS project — a game engine and development platform built with C# and .NET.

## Project Statistics
- **Total csproj files**: 140+
- **Layers**: 6 (1_Presentation through 6_Ideation)
- **Framework**: .NET 8.0/10.0
- **Language**: C# 13

## Documentation Structure

### Architecture & Overview
- [[Architecture]] — Layered architecture overview and dependency flow
- [[Build-System]] — Build configuration, asset pipeline, platform targets
- [[Generators]] — Code generation projects and reference patterns
- [[Testing-Strategy]] — Testing approach and test project structure
- [[Cross-Cutting-Concerns]] — SonarQube, warnings, language version, etc.

### Layer Documentation

#### 1_Presentation
- [[1_Presentation/Benchmark]] — Performance benchmarking application
- [[1_Presentation/Engine]] — Main game engine runtime (net10.0, AOT)
- [[1_Presentation/Hub]] — Game hub/launcher application
- [[1_Presentation/Installer]] — Installer application
- [[1_Presentation/Extension]] — Extension projects overview
  - [[1_Presentation/Extension-Graphic]] — UI and Shader extensions
  - [[1_Presentation/Extension-Io]] — FileDialog and FilePicker extensions
  - [[1_Presentation/Extension-Language]] — Translator and Dialogue extensions
  - [[1_Presentation/Extension-Math]] — ProceduralDungeon and PriorityQueue extensions
  - [[1_Presentation/Extension-Media]] — FFmpeg extension
  - [[1_Presentation/Extension-Network]] — Client and Server extensions
  - [[1_Presentation/Extension-Profile]] — User profile management
  - [[1_Presentation/Extension-Thread]] — Threading utilities
  - [[1_Presentation/Extension-Updater]] — Application update mechanism

#### 2_Application
- [[2_Application/Alis]] — Core application library
- [[2_Application/Alis.Test]] — Unit tests for core library
- [[Alis.Sample]] — Sample application

#### 3_Structuration
- [[3_Structuration/Core]] — Foundational abstractions overview
- [[3_Structuration/Alis.Core]] — Core engine abstractions
- [[3_Structuration/Alis.Core.Ecs]] — Entity Component System
- [[3_Structuration/Alis.Core.Graphic]] — Core graphics abstractions

#### 4_Operation
- [[4_Operation/Core]] — Runtime implementations overview
- [[4_Operation/Alis.Core.Audio]] — Audio engine
- [[4_Operation/Alis.Core.Input]] — Input handling
- [[4_Operation/Alis.Core.Physics]] — Physics simulation
- [[4_Operation/Alis.Core.Resource]] — Resource management
- [[4_Operation/Alis.Core.Scene]] — Scene management
- [[4_Operation/Alis.Core.Serialization]] — Data serialization
- [[4_Operation/Alis.Core.Window]] — Window management

#### 5_Declaration
- [[5_Declaration/Core]] — Data contracts overview
- [[5_Declaration/Alis.Core.Data]] — Data contracts and DTOs
- [[5_Declaration/Alis.Core.Log]] — Logging infrastructure

#### 6_Ideation
- [[6_Ideation/Core]] — Game-specific functionality overview
- [[6_Ideation/Alis.Core.Game]] — Game logic and state management
- [[6_Ideation/Alis.Core.Network]] — Networked game functionality

## Key Patterns
- **Layered Architecture**: 6 layers with strict dependency flow
- **Generator Pattern**: Code generation in each layer
- **Asset Pipeline**: SHA256 → zip → base64 for all projects
- **Platform Detection**: LINUX, OSX, WIN conditional compilation
- **AOT Compilation**: Engine and Hub use NativeAOT
- **Test Discovery**: Regex-based source project auto-discovery
- **Dynamic References**: Glob-based generator project references

## Build Commands
```bash
dotnet restore          # Restore dependencies
dotnet build Alis.sln   # Build solution
dotnet test Alis.sln    # Run tests
dotnet publish -r linux-x64 -c Release  # Publish for Linux
```

## Notes
- All projects use C# 13 with nullable disabled
- Extensive warning suppression suggests ongoing migration
- NativeAOT warnings indicate AOT compatibility work
- Hub auto-builds Engine and Installer dependencies
- macOS builds create .app bundles with DMG generation

## Related Architecture

- [[architecture/repository-overview]] — Full architecture overview
- [[architecture/dependency-graph]] — Dependency rules and flow
- [[architecture/build-system]] — Build configuration
- [[Alis Architecture Overview]] — Concept-level overview
- [[Layered Architecture]] — Layer structure
- [[adr-001-layered-architecture]] — Architecture decision
- [[adr-002-aggregator-pattern]] — Aggregator pattern decision

## Related Indexes

- [[project-index]] — Complete 140-project index
- [[layer-index]] — Layer breakdown
- [[dependency-index]] — Dependency map
- [[architecture-index]] — Patterns index

## Related Topics

- [[Generator Pattern]] — Source generator architecture
- [[Multi-Targeting Strategy]] — Framework targets
- [[Platform-Specific Build Constants]] — Platform detection
- [[Multi-Platform Samples]] — Sample game details

## Related Documentation

- [[testing-overview]] — Test coverage
- [[security-overview]] — Security analysis
- [[naming-conventions]] — Naming rules
- [[onboarding/getting-started]] — Developer guide
- [[ai-context]] — AI agent reference
