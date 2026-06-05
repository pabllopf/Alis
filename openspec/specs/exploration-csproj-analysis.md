## Exploration: Alis .csproj Analysis

### Executive Summary

The `alis_design.sln` contains **75 `.csproj` projects** organized across 6 architectural layers (1_Presentation → 6_Ideation) plus test projects. The build system is highly centralized: individual `.csproj` files are minimal (80% are ~8 lines), relying on a chain of shared MSBuild `.props` files — `Directory.Build.props`, `.config/Config.props`, and 8 type-specific default templates under `.config/default/`. The architecture enforces a strict top-down dependency flow where each layer can reference the layer below it but not above. Target frameworks are multi-TFM for libraries (up to 18 targets in Release), while test/app projects pin to `net8.0` and generators target `netstandard2.0;net8.0;net10.0`.

### Layer Distribution

| Layer | Count | Project Types |
|-------|-------|---------------|
| 1_Presentation | 44 | 14 src extension libs + 3 app exes + 27 test projects |
| 2_Application | 2 | 1 src lib (Alis.csproj) + 1 test |
| 3_Structuration | 2 | 1 src lib (Alis.Core.csproj) + 1 test |
| 4_Operation | 10 | 4 src libs + 4 tests + 2 generators |
| 5_Declaration | 2 | 1 src lib (Alis.Core.Aspect.csproj) + 1 test |
| 6_Ideation | 15 | 6 src libs + 6 tests + 3 generators |
| **Total** | **75** | **27 src libs + 3 app exes + 5 generators + 40 tests** |

### Per-Layer Detail

#### 1_Presentation (44 projects — 17 src/app + 27 tests)

- **Common patterns**: All src projects are net8.0 Exe (Engine, Hub, Installer) or netstandard2.0+ Library (extensions).
- **Shared props**: Extensions use `default_csproj.props` (→ Config.props). Apps (Engine/Hub/Installer) define properties inline without importing Config.props.
- **App projects** (Engine, Hub, Installer):
  - `Alis.App.Engine`: net8.0 Exe, inline properties, references Alis.csproj + Graphic.Ui + Updater + FileDialog
  - `Alis.App.Hub`: net8.0 Exe, same refs plus BuildAndCopy targets that embed Engine/Installer output
  - `Alis.App.Installer`: net8.0 Exe, same refs
- **Extension pattern**: 14 domains (Ads/GoogleAds, Security, Payment/Stripe, Network, Io/FileDialog, Updater, Language/Translator, Language/Dialogue, Math/ProceduralDungeon, Math/HighSpeedPriorityQueue, Graphic/Ui, Graphic/Sfml, Graphic/Glfw, Graphic/Sdl2, Profile, Cloud/DropBox, Cloud/GoogleDrive, Thread, Media/FFmpeg). Each has `src/Alis.Extension.{Domain}.csproj` + `test/Alis.Extension.{Domain}.Test.csproj`.
- **Tests**: Each test project auto-links its corresponding src csproj via NameTest regex. Test packages: xUnit 2.6.6, Moq 4.20.70, coverlet 6.0.4.
- **Layer dependencies**: Config.props adds ProjectReference from 1_Presentation → 2_Application (Alis.csproj) in Debug mode.

#### 2_Application (2 projects)

- **Alis** (`2_Application/Alis/src/Alis.csproj`): **Core aggregator project**. Imports `Config.props`. This is the main application assembly.
  - In Release mode, **compiles in source files from 3_Structuration, 4_Operation, 5_Declaration, and 6_Ideation** as linked `.cs` files (not ProjectReferences). This is a unique design — the application physically includes all lower-layer source.
  - All generators from 3_Structuration through 6_Ideation are included as Analyzers.
- **Alis.Test**: net8.0 + netstandard2.0 (unique — the only test project with multi-TFM). References `Alis.csproj` via NameTest auto-linking.

#### 3_Structuration (2 projects)

- **Alis.Core** (`3_Structuration/Core/src/Alis.Core.csproj`): Library. Imports `Config.props`.
  - In Release mode, compiles in source files from 4_Operation and 6_Ideation as linked files.
  - References Alis.Core.Ecs, Alis.Core.Audio, Alis.Core.Graphic, Alis.Core.Physic, Alis.Core.Aspect from 4_Operation/5_Declaration via Config.props Debug references.
- **Alis.Core.Test**: Standard test project, xUnit + Moq.

#### 4_Operation (10 projects)

- **Core engine modules**: Ecs, Audio, Graphic, Physic — each with `src/`, `test/`, and optionally `generator/`.
- **Src libs** (`Alis.Core.Ecs.csproj`, `Alis.Core.Audio.csproj`, `Alis.Core.Graphic.csproj`, `Alis.Core.Physic.csproj`): All identical 8-line files importing `Config.props`.
  - In Release mode, compile in source from 5_Declaration and 6_Ideation as linked files.
  - Reference generators from 5_Declaration and 6_Ideation as Analyzers.
- **Generators**: `Alis.Core.Ecs.Generator.csproj` and `Alis.Core.Graphic.Generator.csproj`. Self-contained (do NOT import Config.props). Target `netstandard2.0;net8.0;net10.0`. Reference `Microsoft.CodeAnalysis.CSharp 4.3.0` and `Microsoft.CodeAnalysis.Analyzers 3.3.4`.
- **Tests**: Standard test pattern.

#### 5_Declaration (2 projects)

- **Alis.Core.Aspect** (`5_Declaration/Aspect/src/Alis.Core.Aspect.csproj`): The "declaration" assembly. Imports `Config.props`. 8 lines.
  - In Release mode, compiles in 6_Ideation source as linked files.
  - References 6_Ideation generators as Analyzers.
- **Alis.Core.Aspect.Test**: Standard test.

#### 6_Ideation (15 projects)

- **6 domain aspects**: Data, Fluent, Logging, Math, Memory, Time. Each has `src/`, `test/`, and (Data, Fluent, Memory) have `generator/`.
- **Src libs**: All import `Config.props`. These are the lowest-level assemblies — no layer below them.
- **Generators**: Self-contained Roslyn source generators. Same pattern as 4_Operation generators.
- **Tests**: Standard test pattern.

### Key Findings

1. **Centralized Build System**: 80% of `.csproj` files are 8-line stubs that import shared props. The real configuration lives in:
   - `Directory.Build.props` — version (1.0.6), VSTest logging, emit compiler generated files
   - `.config/Config.props` — THE master config: TargetFrameworks, LangVersion 13, Nullable disable, treat warnings as errors, SourceLink, runtime identifiers, all NuGet package references, cross-layer ProjectReferences (Debug mode), per-layer generator analyzer chain, OS platform constants
   - `.config/default/default_*.props` — 8 type-specific templates (csproj, test, app, generator, benchmark, sample, sample_web, sample_android, sample_ios)

2. **Dependency Flow (top→bottom)**: Strict layered architecture enforced via MSBuild conditions on `$(ProjectDir)`:
   ```
   1_Presentation → 2_Application
   2_Application → 3_Structuration
   3_Structuration → 4_Operation
   4_Operation → 5_Declaration
   5_Declaration → 6_Ideation
   ```
   Each layer only references generators from layers below it.

3. **Release Mode Source Merging**: In Release configuration, `Alis.csproj` (2_Application) compiles linked `.cs` files from ALL lower layers (3 through 6) instead of using ProjectReferences. This is an optimization/merge strategy — likely for AOT/publishing.

4. **Multi-TFM Strategy**: 
   - Libraries (via Config.props): Debug mode → `netcoreapp2.0;net5.0;net8.0;net10.0;netstandard2.0;net461`. Release mode → 18 TFMs covering netcoreapp2.0→3.1, net5.0→10.0, netstandard2.0→2.1, net461→net481.
   - Generators: `netstandard2.0;net8.0;net10.0`
   - Tests/apps: `net8.0` (pinned)
   - Samples: `net10.0` (or platform-specific like `net10.0-android`)

5. **Generator-as-Analyzer Pattern**: Generator projects produce Analyzer assemblies consumed via `OutputItemType="Analyzer"` with `ReferenceOutputAssembly="false"`. All generators target `netstandard2.0` when consumed as analyzers.

6. **Test Auto-Linking**: Any project with `AssemblyName.Contains('Test')` auto-resolves to its corresponding source project via the `NameTest` regex, adding a `ProjectReference` to `../src/$(NameTest).csproj`.

7. **Runtime Identifier Matrix**: 12 RIDs: `browser-wasm; win-x64; win-x86; linux-x64; linux-arm64; linux-arm; osx-x64; osx-arm64; android-arm64; android-x64; ios-arm64; iossimulator-arm64; iossimulator-x64`. Platform-specific define constants (LINUX/OSX/WIN) are set via MSBuild OS detection.

8. **Hub Self-Hosting**: `Alis.App.Hub` builds `Alis.App.Engine` and `Alis.App.Installer` post-build, embedding them in its output as Editor/Installer subdirectories. macOS DMG/Windows ZIP/Linux ZIP bundles are created in Release.

### Risks / Gotchas

- **Build Complexity**: The chained `.props` system (Directory.Build.props → Config.props → default_*.props → individual .csproj) makes it hard to determine effective properties without running MSBuild evaluation. Analysis was done by tracing imports.
- **Inconsistency**: `Alis.App.Engine`/`Hub`/`Installer` define properties inline instead of importing `default_app_csproj.props`. `Alis.Test` has inline properties similar to but slightly different from `default_test_csproj.props`.
- **Multi-TFM in Debug**: Debug builds target only 6 TFMs, but Release targets 18. Build times will be significantly longer in Release.
- **Generator projects don't import Config.props**: They're self-contained, meaning they miss some global settings (e.g., SourceLink, versioning). This is intentional (analyzers need independence) but could cause drift.
- **Linked source files in Release**: The `Alis.csproj` Release mode compiles-in source from layers 3-6. This means the same .cs files are compiled in multiple assemblies — potential for duplicate type issues if not handled carefully.
- **No Benchmark projects in solution**: The `.config/default/default_benchmark_csproj.props` exists but no Benchmark `.csproj` is included in `alis_design.sln`.
- **No Sample projects in solution**: The sample props exist (web, android, ios, desktop) but no sample `.csproj` files are in the solution.

### Artifacts Saved
- Engram: topic_key `sdd/explore/alis-csproj-analysis`
- File: `openspec/specs/exploration-csproj-analysis.md`
