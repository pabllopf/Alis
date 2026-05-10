# AGENTS.md

# Alis Solution Agent Rules

## Project Overview

Alis is a fully managed high-performance multimedia, application, tooling, and game development ecosystem written entirely in C#.

The repository is a large-scale layered .NET monorepo organized by architectural responsibility and dependency direction.

The root solution is:

- `alis.sln`

All modules, tools, generators, tests, samples, and applications inside the repository must comply with the rules defined in this document.

The framework is designed around:
- High performance
- Cross-platform portability
- Long-term maintainability
- Deterministic execution
- Multi-framework compatibility
- Zero unnecessary dependencies
- Fully managed C# development
- Large-scale modular architecture

---

# Solution Architecture

The repository follows a strict layered architecture.

Folder numbering defines dependency direction.

Lower layers must never depend on higher layers.

## Layer Structure

### 1_Presentation
Presentation, UI, engine, frontend integrations, tooling frontends, visualization systems, runtime hosts, and application-facing APIs.

Contains:
- Engine
- Extensions
- UI systems
- Runtime presentation layers
- Platform frontends

### 2_Application
Application orchestration layer.

Contains:
- Main Alis applications
- Runtime composition
- Application integration logic
- Runtime startup systems
- Executable applications
- Samples

### 3_Structuration
Core structural abstractions and shared architecture foundations.

Contains:
- Core abstractions
- Base infrastructure
- Shared architecture systems

### 4_Operation
Operational modules and implementation systems.

Contains:
- Graphics
- Audio
- Media
- Runtime systems
- Platform operations
- Backend implementations

### 5_Declaration
Contracts, declarations, interfaces, metadata definitions, and declarative systems.

### 6_Ideation
Experimental systems, prototypes, research modules, and future concepts.

---

# Dependency Direction Rules

Dependencies must always respect the repository architecture.

Allowed direction:
```text
1_Presentation
    ↓
2_Application
    ↓
3_Structuration
    ↓
4_Operation
    ↓
5_Declaration
    ↓
6_Ideation
```

Reverse dependencies are forbidden.

Cross-layer violations are forbidden.

Agents must never introduce architectural dependency violations.

The dependency rules are enforced through:
- `.config/Config.props`
- Shared MSBuild imports
- Conditional `ProjectReference` rules

---

# Repository Structure

## Root Solution
- `alis.sln`

## Solution Projects (Relative Paths)

The following project files are included in `alis.sln` and should be referenced using repository-relative paths:

```text
2_Application/Alis/src/Alis.csproj
4_Operation/Ecs/generator/Alis.Core.Ecs.Generator.csproj
4_Operation/Graphic/generator/Alis.Core.Graphic.Generator.csproj
6_Ideation/Memory/test/Alis.Core.Aspect.Memory.Test.csproj
6_Ideation/Memory/src/Alis.Core.Aspect.Memory.csproj
6_Ideation/Memory/generator/Alis.Core.Aspect.Memory.Generator.csproj
6_Ideation/Memory/sample/Alis.Core.Aspect.Memory.Sample.csproj
6_Ideation/Fluent/test/Alis.Core.Aspect.Fluent.Test.csproj
6_Ideation/Fluent/src/Alis.Core.Aspect.Fluent.csproj
6_Ideation/Fluent/generator/Alis.Core.Aspect.Fluent.Generator.csproj
6_Ideation/Fluent/sample/Alis.Core.Aspect.Fluent.Sample.csproj
6_Ideation/Math/test/Alis.Core.Aspect.Math.Test.csproj
6_Ideation/Math/src/Alis.Core.Aspect.Math.csproj
6_Ideation/Math/sample/Alis.Core.Aspect.Math.Sample.csproj
6_Ideation/Time/test/Alis.Core.Aspect.Time.Test.csproj
6_Ideation/Time/src/Alis.Core.Aspect.Time.csproj
6_Ideation/Time/sample/Alis.Core.Aspect.Time.Sample.csproj
6_Ideation/Data/test/Alis.Core.Aspect.Data.Test.csproj
6_Ideation/Data/src/Alis.Core.Aspect.Data.csproj
6_Ideation/Data/generator/Alis.Core.Aspect.Data.Generator.csproj
6_Ideation/Data/sample/Alis.Core.Aspect.Data.Sample.csproj
6_Ideation/Logging/test/Alis.Core.Aspect.Logging.Test.csproj
6_Ideation/Logging/src/Alis.Core.Aspect.Logging.csproj
6_Ideation/Logging/sample/Alis.Core.Aspect.Logging.Sample.csproj
1_Presentation/Extension/Ads/GoogleAds/test/Alis.Extension.Ads.GoogleAds.Test.csproj
1_Presentation/Extension/Ads/GoogleAds/src/Alis.Extension.Ads.GoogleAds.csproj
1_Presentation/Extension/Ads/GoogleAds/sample/Alis.Extension.Ads.GoogleAds.Sample.csproj
1_Presentation/Extension/Security/test/Alis.Extension.Security.Test.csproj
1_Presentation/Extension/Security/src/Alis.Extension.Security.csproj
1_Presentation/Extension/Security/sample/Alis.Extension.Security.Sample.csproj
1_Presentation/Extension/Payment/Stripe/test/Alis.Extension.Payment.Stripe.Test.csproj
1_Presentation/Extension/Payment/Stripe/src/Alis.Extension.Payment.Stripe.csproj
1_Presentation/Extension/Payment/Stripe/sample/Alis.Extension.Payment.Stripe.Sample.csproj
1_Presentation/Extension/Network/test/Alis.Extension.Network.Test.csproj
1_Presentation/Extension/Network/src/Alis.Extension.Network.csproj
1_Presentation/Extension/Network/samples/ConsoleGame/server/Alis.Extension.Network.Sample.ConsoleGame.Server.csproj
1_Presentation/Extension/Network/samples/ConsoleGame/client/Alis.Extension.Network.Sample.ConsoleGame.Client.csproj
1_Presentation/Extension/Network/samples/SimpleGame/server/Alis.Extension.Network.Sample.SimpleGame.Server.csproj
1_Presentation/Extension/Network/samples/SimpleGame/client/Alis.Extension.Network.Sample.SimpleGame.Client.csproj
1_Presentation/Extension/Network/samples/SimpleChat/server/Alis.Extension.Network.Sample.SimpleChat.Server.csproj
1_Presentation/Extension/Network/samples/SimpleChat/client/Alis.Extension.Network.Sample.SimpleChat.Client.csproj
1_Presentation/Extension/Io/FileDialog/test/Alis.Extension.Io.FileDialog.Test.csproj
1_Presentation/Extension/Io/FileDialog/src/Alis.Extension.Io.FileDialog.csproj
1_Presentation/Extension/Io/FileDialog/sample/Alis.Extension.Io.FileDialog.Sample.csproj
1_Presentation/Extension/Updater/test/Alis.Extension.Updater.Test.csproj
1_Presentation/Extension/Updater/src/Alis.Extension.Updater.csproj
1_Presentation/Extension/Updater/sample/Alis.Extension.Updater.Sample.csproj
1_Presentation/Extension/Language/Translator/test/Alis.Extension.Language.Translator.Test.csproj
1_Presentation/Extension/Language/Translator/src/Alis.Extension.Language.Translator.csproj
1_Presentation/Extension/Language/Translator/sample/Alis.Extension.Language.Translator.Sample.csproj
1_Presentation/Extension/Language/Dialogue/test/Alis.Extension.Language.Dialogue.Test.csproj
1_Presentation/Extension/Language/Dialogue/src/Alis.Extension.Language.Dialogue.csproj
1_Presentation/Extension/Language/Dialogue/sample/Alis.Extension.Language.Dialogue.Sample.csproj
1_Presentation/Extension/Math/ProceduralDungeon/test/Alis.Extension.Math.ProceduralDungeon.Test.csproj
1_Presentation/Extension/Math/ProceduralDungeon/src/Alis.Extension.Math.ProceduralDungeon.csproj
1_Presentation/Extension/Math/ProceduralDungeon/sample/Alis.Extension.Math.ProceduralDungeon.Sample.csproj
1_Presentation/Extension/Math/HighSpeedPriorityQueue/test/Alis.Extension.Math.HighSpeedPriorityQueue.Test.csproj
1_Presentation/Extension/Math/HighSpeedPriorityQueue/src/Alis.Extension.Math.HighSpeedPriorityQueue.csproj
1_Presentation/Extension/Math/HighSpeedPriorityQueue/sample/Alis.Extension.Math.HighSpeedPriorityQueue.Sample.csproj
1_Presentation/Extension/Graphic/Ui/test/Alis.Extension.Graphic.Ui.Test.csproj
1_Presentation/Extension/Graphic/Ui/src/Alis.Extension.Graphic.Ui.csproj
1_Presentation/Extension/Graphic/Ui/sample/Alis.Extension.Graphic.Ui.Sample.csproj
1_Presentation/Extension/Graphic/Sfml/test/Alis.Extension.Graphic.Sfml.Test.csproj
1_Presentation/Extension/Graphic/Sfml/src/Alis.Extension.Graphic.Sfml.csproj
1_Presentation/Extension/Graphic/Sfml/sample/Alis.Extension.Graphic.Sfml.Sample.csproj
1_Presentation/Extension/Graphic/Glfw/test/Alis.Extension.Graphic.Glfw.Test.csproj
1_Presentation/Extension/Graphic/Glfw/src/Alis.Extension.Graphic.Glfw.csproj
1_Presentation/Extension/Graphic/Glfw/sample/Alis.Extension.Graphic.Glfw.Sample.csproj
1_Presentation/Extension/Graphic/Sdl2/test/Alis.Extension.Graphic.Sdl2.Test.csproj
1_Presentation/Extension/Graphic/Sdl2/src/Alis.Extension.Graphic.Sdl2.csproj
1_Presentation/Extension/Graphic/Sdl2/sample/Alis.Extension.Graphic.Sdl2.Sample.csproj
1_Presentation/Extension/Profile/test/Alis.Extension.Profile.Test.csproj
1_Presentation/Extension/Profile/src/Alis.Extension.Profile.csproj
1_Presentation/Extension/Profile/sample/Alis.Extension.Profile.Sample.csproj
1_Presentation/Extension/Cloud/DropBox/test/Alis.Extension.Cloud.DropBox.Test.csproj
1_Presentation/Extension/Cloud/DropBox/src/Alis.Extension.Cloud.DropBox.csproj
1_Presentation/Extension/Cloud/DropBox/sample/Alis.Extension.Cloud.DropBox.Sample.csproj
1_Presentation/Extension/Cloud/GoogleDrive/test/Alis.Extension.Cloud.GoogleDrive.Test.csproj
1_Presentation/Extension/Cloud/GoogleDrive/src/Alis.Extension.Cloud.GoogleDrive.csproj
1_Presentation/Extension/Cloud/GoogleDrive/sample/Alis.Extension.Cloud.GoogleDrive.Sample.csproj
1_Presentation/Extension/Thread/test/Alis.Extension.Thread.Test.csproj
1_Presentation/Extension/Thread/src/Alis.Extension.Thread.csproj
1_Presentation/Extension/Thread/sample/Alis.Extension.Thread.Sample.csproj
1_Presentation/Extension/Media/FFmpeg/test/Alis.Extension.Media.FFmpeg.Test.csproj
1_Presentation/Extension/Media/FFmpeg/src/Alis.Extension.Media.FFmpeg.csproj
1_Presentation/Extension/Media/FFmpeg/sample/Alis.Extension.Media.FFmpeg.Sample.csproj
1_Presentation/Installer/test/Alis.App.Installer.Test.csproj
1_Presentation/Installer/src/Alis.App.Installer.csproj
1_Presentation/Engine/test/Alis.App.Engine.Test.csproj
1_Presentation/Engine/src/Alis.App.Engine.csproj
1_Presentation/Hub/test/Alis.App.Hub.Test.csproj
1_Presentation/Hub/src/Alis.App.Hub.csproj
3_Structuration/Core/test/Alis.Core.Test.csproj
3_Structuration/Core/src/Alis.Core.csproj
3_Structuration/Core/sample/Alis.Core.Sample.csproj
2_Application/Alis/test/Alis.Test.csproj
2_Application/Alis/samples/alis.sample.king.platform/web/Alis.Sample.King.Platform.Web.csproj
2_Application/Alis/samples/alis.sample.king.platform/desktop/Alis.Sample.King.Platform.Desktop.csproj
2_Application/Alis/samples/alis.sample.flappy.bird/web/Alis.Sample.Flappy.Bird.Web.csproj
2_Application/Alis/samples/alis.sample.flappy.bird/desktop/Alis.Sample.Flappy.Bird.Desktop.csproj
2_Application/Alis/samples/alis.sample.space.simulator/web/Alis.Sample.Space.Simulator.Web.csproj
2_Application/Alis/samples/alis.sample.space.simulator/desktop/Alis.Sample.Space.Simulator.Desktop.csproj
2_Application/Alis/samples/alis.sample.dino/web/Alis.Sample.Dino.Web.csproj
2_Application/Alis/samples/alis.sample.dino/desktop/Alis.Sample.Dino.Desktop.csproj
2_Application/Alis/samples/alis.sample.empty/web/Alis.Sample.Empty.Web.csproj
2_Application/Alis/samples/alis.sample.empty/desktop/Alis.Sample.Empty.Desktop.csproj
2_Application/Alis/samples/alis.sample.pong/web/Alis.Sample.Pong.Web.csproj
2_Application/Alis/samples/alis.sample.pong/desktop/Alis.Sample.Pong.Desktop.csproj
2_Application/Alis/samples/alis.sample.splitcamera/web/Alis.Sample.SplitCamera.Web.csproj
2_Application/Alis/samples/alis.sample.splitcamera/desktop/Alis.Sample.SplitCamera.Desktop.csproj
2_Application/Alis/samples/alis.sample.asteroid/web/Alis.Sample.Asteroid.Web.csproj
2_Application/Alis/samples/alis.sample.asteroid/desktop/Alis.Sample.Asteroid.Desktop.csproj
4_Operation/Audio/src/Alis.Core.Audio.csproj
4_Operation/Graphic/src/Alis.Core.Graphic.csproj
4_Operation/Ecs/src/Alis.Core.Ecs.csproj
4_Operation/Physic/src/Alis.Core.Physic.csproj
5_Declaration/Aspect/src/Alis.Core.Aspect.csproj
2_Application/Alis/samples/alis.sample.rogue/web/Alis.Sample.Rogue.Web.csproj
2_Application/Alis/samples/alis.sample.rogue/desktop/Alis.Sample.Rogue.Desktop.csproj
2_Application/Alis/samples/alis.sample.snake/web/Alis.Sample.Snake.Web.csproj
2_Application/Alis/samples/alis.sample.snake/desktop/Alis.Sample.Snake.Desktop.csproj
2_Application/Alis/samples/alis.sample.ruinsoftartarus/web/Alis.Sample.RuinsOfTartarus.Web.csproj
2_Application/Alis/samples/alis.sample.ruinsoftartarus/desktop/Alis.Sample.RuinsOfTartarus.Desktop.csproj
2_Application/Alis/samples/alis.sample.egg/web/Alis.Sample.Egg.Web.csproj
2_Application/Alis/samples/alis.sample.egg/desktop/Alis.Sample.Egg.Desktop.csproj
2_Application/Alis/samples/alis.sample.inefable/web/Alis.Sample.Inefable.Web.csproj
2_Application/Alis/samples/alis.sample.inefable/desktop/Alis.Sample.Inefable.Desktop.csproj
5_Declaration/Aspect/test/Alis.Core.Aspect.Test.csproj
5_Declaration/Aspect/sample/Alis.Core.Aspect.Sample.csproj
4_Operation/Ecs/test/Alis.Core.Ecs.Test.csproj
4_Operation/Ecs/sample/Alis.Core.Ecs.Sample.csproj
4_Operation/Graphic/test/Alis.Core.Graphic.Test.csproj
4_Operation/Graphic/sample/Alis.Core.Graphic.Sample.csproj
4_Operation/Audio/test/Alis.Core.Audio.Test.csproj
4_Operation/Audio/sample/Alis.Core.Audio.Sample.csproj
4_Operation/Physic/test/Alis.Core.Physic.Test.csproj
4_Operation/Physic/sample/Alis.Core.Physic.Sample.csproj
1_Presentation/Benchmark/src/Alis.Benchmark.csproj
```

## Shared Configuration
- `.config/`

Contains:
- Shared MSBuild props
- Shared targets
- Common project templates
- Multi-targeting configuration
- Runtime packaging rules
- Shared test configuration

Important files:
- `.config/Config.props`
- `.config/default/default_csproj.props`
- `.config/default/default_test_csproj.props`

---

# Main Repository Areas

## Presentation Layer
- `1_Presentation/`

Contains:
- Engine
- Extensions
- UI systems
- Visualization systems
- Runtime frontends

Example:
- `1_Presentation/Engine/src/`

---

## Application Layer
- `2_Application/`

Contains:
- Main applications
- Runtime integration
- Samples
- Executable compositions

Example:
- `2_Application/Alis/src/Alis.csproj`

---

## Structuration Layer
- `3_Structuration/`

Contains:
- Core architecture
- Shared abstractions
- Base systems

Example:
- `3_Structuration/Core/src/Alis.Core.csproj`

---

## Operation Layer
- `4_Operation/`

Contains:
- Graphics
- Media
- Runtime systems
- Platform implementations
- Native integrations

Several operation modules use paired `generator/`, `sample/`, `src/`, and `test/` subtrees; notable examples include `4_Operation/Ecs/` and `4_Operation/Graphic/`.

Example:
- `4_Operation/Graphic/src/Alis.Core.Graphic.csproj`

---

## Declaration Layer
- `5_Declaration/`

Contains:
- Contracts
- Interfaces
- Shared declarations
- Metadata systems

---

## Ideation Layer
- `6_Ideation/`

Contains:
- Experimental systems
- Research modules
- Prototype implementations

Several ideation modules also follow the `generator/`, `sample/`, `src/`, and `test/` layout; notable examples include `6_Ideation/Data/`, `6_Ideation/Fluent/`, and `6_Ideation/Memory/`.

---

# Platform Compatibility

All code must remain compatible with the supported platforms.

## Supported Platforms

### Windows
- `win-x64`
- `win-x86`
- `win-arm64`

### Linux
- `linux-x64`
- `linux-musl-x64`
- `linux-arm`
- `linux-arm64`
- `linux-musl-arm`
- `linux-musl-arm64`

### macOS
- `osx-x64`
- `osx-arm64`

### Web
- `browser-wasm`

### Mobile (Planned)
- `android`
- `ios`

All systems must be designed with platform abstraction and portability in mind.

Platform-specific implementations must remain isolated.

---

# Framework Compatibility

All code must remain compatible with all supported frameworks.

## Supported Frameworks

### .NET Core
- `netcoreapp2.0`
- `netcoreapp2.1`
- `netcoreapp2.2`
- `netcoreapp3.0`
- `netcoreapp3.1`

### .NET
- `net5.0`
- `net6.0`
- `net7.0`
- `net8.0`
- `net9.0`
- `net10.0`

### .NET Standard
- `netstandard2.0`
- `netstandard2.1`

### .NET Framework
- `net471`
- `net472`
- `net48`
- `net481`

Do not use APIs unavailable on older targets unless protected through conditional compilation.

Backward compatibility is mandatory.

AOT compatibility is mandatory for all generated and manually authored code paths.

---

# Build and Test Workflows

## Restore
```bash
dotnet restore alis.sln
```

## Build
```bash
dotnet build alis.sln -c Debug
```

## Run Tests
```bash
dotnet test alis.sln
```

For repository-wide validation on macOS, use `docs/scripts/macos/run_tests.sh`; it runs `dotnet test` for every non-template `*.csproj` twice, once in Debug and once in Release.

For the broader packaging workflows, `docs/scripts/macos/build_all.sh` restores `alis.sln` and packs the production projects, while `docs/scripts/macos/pack_all.sh` builds and packs the same production-project subset for `osx-arm64` and `net9.0`.

---

# Repository Scripts

## Test Scripts
- `docs/scripts/macos/run_tests.sh`
- `docs/scripts/linux/run_tests.sh`
- `docs/scripts/windows/run_tests.bat`

Runs:
- Debug tests for every non-template `*.csproj`
- Release tests for every non-template `*.csproj`

Skips:
- Templates

---

## Build Scripts
- `docs/scripts/macos/build_all.sh`
- `docs/scripts/macos/pack_all.sh`
- `docs/scripts/windows/run_pack_all.bat`

These scripts:
- Restore, build, and/or pack the production project set
- Skip `*.Template.*`, `*.App.*`, `*.Test.*`, `*.Benchmark.*`, `*.Sample.*`, and `*.Generator.*` projects
- Apply repository-wide packaging conventions

---

# Project Rules

## Project Creation Rules

Agents must never:
- Create new projects
- Create new solutions
- Modify repository architecture
- Change dependency directions

Agents must not:
- Edit `.csproj` configurations unless explicitly requested
- Modify shared build infrastructure without necessity

The repository structure is intentionally automated and convention-driven.

---

# Dependency Policy

Third-party dependencies are strictly prohibited.

## Forbidden
- External NuGet packages
- Community libraries
- External frameworks
- Third-party runtime helpers
- Dependency injection frameworks
- External serialization libraries
- External utility libraries

## Allowed
- Standard .NET libraries
- System libraries
- Native platform APIs
- OpenGL
- Vulkan
- Metal
- DirectX
- Internal framework modules

The framework must remain fully self-contained.

---

# Source Generator Rules

Source generators are first-class architecture components.

All generated output must be AOT-safe and must not rely on runtime code generation.

Generators are referenced through analyzers using:
- `OutputItemType="Analyzer"`

Generators must:
- Produce deterministic code
- Preserve compatibility
- Avoid allocations when possible
- Generate XML documentation
- Never generate invalid code
- Emit deterministic diagnostics when required build inputs are missing or invalid
- Keep AOT validation paths active so invalid configurations fail early at compile time

Repository examples of required validation behavior include:
- `6_Ideation/Fluent/generator/AotReflectionAnalyzer.cs` diagnostic checks for reflection/emit/invoke patterns
- `6_Ideation/Memory/generator/ResourceAccessorGenerator.cs` diagnostics for missing/invalid `assets.pack` and non-executable output kinds (`ALIS0011`, `ALIS0012`, `ALIS0013`)

Generated code quality must match manual code quality.

---

# Language Rules

Everything must be written entirely in English.

## Mandatory English Usage
- Source code
- APIs
- Documentation
- XML comments
- Tests
- Exception messages
- Identifiers
- Variables
- Type names

Mixed-language code is forbidden.

---

# Documentation Rules

Only XML documentation comments are allowed.

## Allowed
```csharp
/// <summary>
/// Represents a graphics device.
/// </summary>
public sealed class GraphicDevice
{
}
```

## Forbidden
```csharp
// Single-line comments

/* Multi-line comments */
```

Do not use:
- `//`
- `/* */`

Documentation must be:
- Technical
- Precise
- Maintainable
- Consistent

All public, protected, and internal APIs must be documented.

---

# File Generation Rules

Only C# source files may be created.

## Allowed
- `.cs`

## Forbidden
- `.md`
- `.txt`
- `.rst`
- `.json`
- `.yaml`
- `.yml`
- `.xml`
- `.docx`
- Temporary reports
- Summary files
- Migration files

Agents must not generate repository documentation files.

---

# Coding Standards

## General Principles
- Prefer explicit code.
- Prefer deterministic behavior.
- Prefer predictable memory usage.
- Prefer maintainable abstractions.
- Prefer performance-oriented design.

---

## Naming Rules
- PascalCase for types and members
- camelCase for locals and parameters
- Meaningful names only
- Avoid unclear abbreviations

---

## Performance Rules

Performance is a first-class requirement.

All implementations should consider:
- Allocation reduction
- Cache locality
- SIMD opportunities
- Data-oriented design
- Deterministic execution
- Low-overhead abstractions

Avoid:
- LINQ in hot paths
- Boxing
- Reflection
- Hidden allocations
- Unnecessary heap allocations
- Runtime code generation (`System.Reflection.Emit`, runtime IL emit, dynamic method generation)

Use spans and memory-efficient APIs when target compatibility allows.

---

# Architecture Rules

## Mandatory Principles
- Cross-platform portability
- Backend abstraction
- Minimal overhead
- API consistency
- Deterministic behavior
- Thread safety where required

---

## Forbidden Practices
- Hidden side effects
- Global mutable state when avoidable
- Runtime-specific assumptions
- Platform leaks into shared APIs
- Architecture shortcuts that break layering
- Runtime code generation patterns that break AOT compatibility
- Reflection-heavy execution paths without explicit AOT-safe alternatives

---

# Graphics and Native Backend Rules

Graphics systems may integrate:
- OpenGL
- Vulkan
- DirectX
- Metal
- WebGL

Backend-specific implementations must remain isolated behind abstractions.

Public APIs must remain backend-agnostic.

---

# Testing Rules

All development must follow strict TDD practices.

## Mandatory Workflow
1. Write failing tests
2. Implement functionality
3. Validate tests
4. Refactor safely

---

# Test Requirements

Every code change must include:
- Unit tests
- Integration tests when applicable
- Regression tests when applicable
- Performance tests for performance-sensitive code

---

# Test Infrastructure

The repository uses:
- xUnit
- Xunit.StaFact
- Moq
- coverlet.collector

Shared configuration:
- `.config/default/default_test_csproj.props`

---

# Test Output Rules

Test results are stored under:
```text
.test/<TargetFramework>/
```

---

# Samples Rules

Samples must:
- Compile successfully
- Demonstrate real usage
- Validate platform behavior
- Remain minimal
- Avoid unnecessary complexity

---

# Packaging and Runtime Rules

The repository contains:
- Runtime packaging
- Asset packing
- Native runtime bundling
- Platform-specific publishing

Do not modify:
- Output paths
- Packaging logic
- Runtime bundle structure

without explicit necessity.

---

# Agent Behavior Rules

The agent must:
- Respect repository architecture
- Preserve compatibility
- Minimize breaking changes
- Keep APIs coherent
- Avoid unnecessary refactors
- Follow existing conventions
- Maintain performance characteristics

The agent must never:
- Add external dependencies
- Create new projects
- Change solution architecture
- Reduce compatibility targets
- Add undocumented APIs
- Generate unsupported files

---

# Validation Checklist

Before completing any task verify:

- All tests pass
- All projects compile
- No forbidden comments exist
- XML documentation exists
- No external dependencies were added
- Platform compatibility is preserved
- Multi-framework compatibility is preserved
- AOT compatibility is preserved
- AOT-related analyzers and generator diagnostics remain enforceable for changed code paths
- Performance impact was considered
- Architecture rules were respected
- No dependency direction violations were introduced
- No unsupported files were generated
