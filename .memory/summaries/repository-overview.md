# Repository Overview

## High-Level Architecture

Alis is a **high-performance game engine and development framework** written in C#. It follows a modular architecture with clear separation between core engine functionality, extensions, applications, and samples.

## Module Map

### 1_Presentation - User-Facing Applications
- **Engine**: Core game application
- **Hub**: Application hub/manager
- **Installer**: Installation system
- **Benchmark**: Performance testing

### 2_Application - Main Application Layer
- **Alis**: Main application framework
- Multiple platform-specific samples (Android, iOS, Web, Desktop)

### 3_Structuration - Core Foundation
- **Alis.Core**: Fundamental abstractions and base classes

### 4_Operation - Engine Systems
- **Audio**: Audio processing system
- **ECS**: Entity Component System for game logic
- **Graphic**: Rendering and graphics system
- **Physic**: Physics engine

### 5_Declaration - Aspect-Oriented Programming
- **Aspect**: AOP framework for cross-cutting concerns

### 6_Ideation - Advanced Aspects
- **Data**: Data management and processing
- **Fluent**: Fluent interfaces and builders
- **Logging**: Logging infrastructure
- **Math**: Mathematical utilities and algorithms
- **Memory**: Asset management and memory handling
- **Time**: Time management and scheduling

## Dependency Overview

```
Core (3_Structuration)
  ↓
Operation Systems (4_Operation)
  - ECS
  - Graphic  
  - Audio
  - Physic
  ↓
Ideation Aspects (6_Ideation)
  ↓
Extensions (1_Presentation/Extension)
  ↓
Applications & Samples
```

## Technology Stack

- **Language**: C# (.NET 5/6/7/8, .NET Framework 4.6.1, .NET Standard 2.0)
- **Architecture**: ECS (Entity Component System), AOP (Aspect-Oriented Programming)
- **Graphics**: SFML, GLFW, SDL2 bindings
- **Cross-Platform**: Windows, macOS, Linux, iOS, Android, WebAssembly
- **Package Management**: Embedded asset packs (.pack/.zip)

## Architectural Style

1. **ECS Architecture**: Pure entity-component-system design for game logic
2. **AOP Framework**: Cross-cutting concerns via aspect-oriented programming
3. **Layered Architecture**: Clear separation between core, operation, and presentation layers
4. **Plugin System**: Extension-based architecture for modularity

## Major Bounded Contexts

| Context | Description | Projects |
|---|---|---|
| Core Engine | Fundamental engine abstractions | Alis.Core, Alis.Core.Ecs, Alis.Core.Graphic |
| Game Systems | Audio, Physics, Rendering | Alis.Core.Audio, Alis.Core.Physic |
| AOP Framework | Aspect-oriented programming | Alis.Core.Aspect.* |
| Extensions | Platform-specific extensions | Alis.Extension.* |
| Applications | User-facing applications | Alis.App.* |
| Samples | Example implementations | Alis.Sample.* |

## Important Risks

1. **Multi-targeting Complexity**: Supporting .NET 5/6/7/8, .NET Framework, and .NET Standard increases maintenance burden
2. **Native Interop**: Heavy use of platform-specific native bindings (OpenGL, SFML, etc.)
3. **Memory Management**: Custom memory pooling and asset management requires careful handling
4. **Performance Sensitivity**: ECS system requires high-performance code paths

## Technical Debt Observations

1. **Generated Code**: Heavy reliance on source generators increases build complexity
2. **Platform-Specific Code**: Extensive platform-specific implementations (Mac, Windows, Linux)
3. **Test Coverage**: Mixed test coverage across projects
4. **Documentation**: Limited inline documentation in some core areas

## Repository Statistics

- **Total Projects**: 140
- **Source Files**: ~3,319 C# files
- **Target Frameworks**: .NET 5, 6, 7, 8, .NET Framework 4.6.1, .NET Standard 2.0
- **Platform Support**: Windows, macOS, Linux, iOS, Android, WebAssembly
