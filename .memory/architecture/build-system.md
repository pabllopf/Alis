# ALIS Build System

## Centralized Build Configuration

### Directory.Build.props
Located at repository root, provides centralized build configuration for all 140 projects.

#### Key Settings
- **C# Version**: 13 (latest)
- **Target Frameworks**: net8.0, netstandard2.0 (project-dependent)
- **LangVersion**: 13
- **ImplicitUsings**: enabled
- **Nullable**: enabled (where specified)
- **AllowUnsafeBlocks**: true
- **EnforceCodeStyleInBuild**: true
- **GenerateDocumentationFile**: true

#### SonarQube Configuration
```xml
<SonarQubeExclude Condition="'$(IsTestProject)' == 'true'">true</SonarQubeExclude>
<NoWarn>$(NoWarn);S4136;S4200;S3925;S3267;CA1816</NoWarn>
```

#### InternalsVisibleTo Pattern
All projects automatically expose internals to their corresponding test project:
```xml
<InternalsVisibleTo Condition="$(AssemblyName.EndsWith('Core'))" />
<InternalsVisibleTo Condition="$(AssemblyName.EndsWith('Extension'))" />
```

#### Global Package References
- **coverlet.collector** 6.0.4 (test coverage)
- **SonarAnalyzer.CSharp** (code analysis)

#### Custom Analyzers
- **ALIS001-ALIS010**: Project-specific Roslyn analyzers

### .config/Config.props
Project metadata configuration:
- **Version**: 0.1.0
- **Author**: Pablo
- **Company**: Alis
- **Product**: ALIS Game Engine Framework
- **Copyright**: Copyright © $(Year) Alis
- **PackageLicenseExpression**: MIT
- **RepositoryUrl**: https://github.com/pabllopf/Alis

## Solution Structure

### alis.slnx (Structured Solution)
Primary solution file with folder-based organization:
- Groups projects by architectural layer
- Includes sample projects
- Supports incremental loading

### alis_design.sln (Design Solution)
Full solution file with all 75 projects explicitly listed.

## Multi-Targeting Strategy

### Framework Support
Projects target multiple frameworks based on their layer:
- **Presentation/Applications**: net8.0 (desktop), netstandard2.0 (portable)
- **Core Engine**: net8.0, netstandard2.0
- **Aspects (Ideation)**: netstandard2.0 (for maximum compatibility)

### Native Runtime Support
NuGet packages include native libraries for:
- **Windows**: win-arm64, win-x64, win-x86
- **macOS**: osx-arm64, osx-x64
- **Linux**: linux-arm64, linux-arm, linux-x64
- **Linux Musl**: linux-musl-x64, linux-musl-arm, linux-musl-arm64

## AOT & Trimming Support
- **PublishAot**: Enabled for native AOT compilation
- **EnableTrimAnalyzer**: Enabled for trimming analysis
- **IsAotCompatible**: Marked where applicable

## Asset Packaging
- SFML native libraries bundled in NuGet packages
- Content files included via `<None>` and `<Content>` elements
- Platform-specific assets organized by runtime identifier

## Build Commands

```bash
# Restore dependencies
dotnet restore

# Build all projects
dotnet build alis.slnx

# Build specific layer
dotnet build 6_Ideation/Alis.Core.Aspect.Fluent/src/Alis.Core.Aspect.Fluent.csproj

# Run tests
dotnet test --filter "FullyQualifiedName~Alis.Core.Aspect.Fluent.Test"

# Publish as self-contained
dotnet publish -c Release -r win-x64 --self-contained

# Publish as framework-dependent
dotnet publish -c Release -r win-x64 --framework net8.0

# Create NuGet package
dotnet pack -c Release
```

## Project Reference Patterns

### Direct Project References
```xml
<ProjectReference Include="..\Alis.Core\Alis.Core.csproj" />
<ProjectReference Include="..\Alis.Core.Ecs\src\Alis.Core.Ecs.csproj" />
```

### Generator Project References
```xml
<ProjectReference Include="..\Alis.Core.Ecs.Generator\Alis.Core.Ecs.Generator.csproj" OutputItemType="Analyzer" />
```

### Test Project References
```xml
<ItemGroup>
  <ProjectReference Include="..\Alis.Core.Ecs\src\Alis.Core.Ecs.csproj" />
</ItemGroup>
```

## CI/CD Considerations
- SonarQube analysis on pull requests
- Test coverage requirements (coverlet.collector)
- Multi-platform build verification
- NuGet package validation
