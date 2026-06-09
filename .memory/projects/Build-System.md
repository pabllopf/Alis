---
title: Build System
tags:
  - project
  - documentation
  - reference

status: Draft

license: GPLv3

---


## Overview
ALIS uses a highly automated build system with shared configuration, asset pipeline, and platform-specific targets. All projects import `Config.props` for common settings.

## Shared Configuration (Config.props)
- **LangVersion**: 13 (all projects)
- **Nullable**: disable (all projects)
- **AllowUnsafeBlocks**: false (all projects)
- **SonarQubeExclude**: true (test projects)
- **WarningLevel**: 0 (Hub, Installer)

## Output Directory Pattern
- **Libraries**: `bin/$(Configuration)/$(RuntimeIdentifier)/lib/$(TargetFramework)/`
- **Applications**: `bin/$(Configuration)/$(RuntimeIdentifier)/lib/`
- **Test Projects**: `bin/$(Configuration)/$(RuntimeIdentifier)/test/$(TargetFramework)/`

## Asset Pipeline
All projects use a consistent asset pipeline:

### Steps
1. **_PrepareAssetPackManifest** — Scans asset files and generates manifest with SHA256 hashes
2. **Incremental Build Check** — Compares current hashes with manifest; skips if unchanged
3. **ZipAssets** — Zips assets and encodes to base64

### Benefits
- Incremental builds (skip if assets unchanged)
- Deterministic output (hash-based change detection)
- Base64-encoded archives for embedding

## Platform Detection
Conditional compilation symbols derived from `RuntimeIdentifier`:

```xml
<PlatformSymbol Condition="'$(RuntimeIdentifier)' == 'osx' Or '$(RuntimeIdentifier)' == 'osx.10.14' Or ...">OSX</PlatformSymbol>
<PlatformSymbol Condition="'$(RuntimeIdentifier)' == 'linux' Or '$(RuntimeIdentifier)' == 'linux-x64' Or ...">LINUX</PlatformSymbol>
<PlatformSymbol Condition="'$(RuntimeIdentifier)' == 'win' Or '$(RuntimeIdentifier)' == 'win-x64' Or ...">WIN</PlatformSymbol>
```

Also derives runtime-specific symbols: `linuxx64`, `osxarm64`, etc.

## Platform-Specific Build Targets

### macOS
- Creates `.app` bundle with proper structure
- Generates `Info.plist` dynamically
- Copies icon and resources
- Hub: Creates DMG with retry logic (3 attempts for Spotlight)

### Linux
- Creates zip distribution
- Includes executable and dependencies

### Windows
- Creates zip distribution
- Includes executable and dependencies

## AOT Compilation (Engine & Hub)
Enabled for both Debug and Release:

```xml
<PublishAot>true</PublishAot>
<SelfContained>true</SelfContained>
<PublishTrimmed>true</PublishTrimmed>
<TrimMode>link</TrimMode>
<OptimizationPreference>Size</OptimizationPreference>
<IlcDisableReflection>true</IlcDisableReflection>
<IlcFoldIdenticalMethodBodies>true</IlcFoldIdenticalMethodBodies>
<StripSymbols>true</StripSymbols>
```

Generates analysis files: `.mstat`, `.dgml`, `.map`, IL dump

## Generator References
All projects use dynamic glob-based project references to generators:

```xml
<ItemGroup>
  <ProjectReference Include="$(MSBuildThisFileDirectory)..\..\*\Generator\src\*.csproj" />
  <ProjectReference Include="$(MSBuildThisFileDirectory)..\Generator\src\*.csproj" />
  <ProjectReference Include="$(MSBuildThisFileDirectory)..\..\Generator\src\*.csproj" />
  <ProjectReference Include="$(MSBuildThisFileDirectory)..\..\..\Generator\src\*.csproj" />
</ItemGroup>
```

This automatically references all generators in the solution without hardcoding paths.

## Hub Auto-Build Targets
Hub automatically builds dependencies:

```xml
<Target Name="BuildAndCopyEngineOutput">
  <MSBuild Projects="..\Engine\src\Alis.App.Engine.csproj" />
</Target>

<Target Name="BuildAndCopyInstallerOutput">
  <MSBuild Projects="..\Installer\src\Alis.App.Installer.csproj" />
</Target>
```

## Warning Suppression
Extensive NoWarn configuration across all projects:

- **ALIS001-ALIS010**: Custom ALIS warnings
- **CA1050, CA1303, CA2007, CA2243**: Microsoft.CodeAnalysis warnings
- **RS0016_ RS0017_ RS0018**: Roslyn analyzer warnings
- **IL2026, IL3050, IL2104**: NativeAOT warnings
- **NU1507, NU1900, NU1902, NU1903**: NuGet warnings
- **SYSLIB1054, SYSLIB1116**: .NET runtime warnings
- **And many more...**

## Test Project Configuration
- Auto-discover source project via regex pattern
- Excluded from SonarQube analysis
- Output to `test/` subdirectory

## Build Commands
```bash
# Restore dependencies
dotnet restore

# Build solution
dotnet build Alis.sln

# Run tests
dotnet test Alis.sln

# Publish for specific platform
dotnet publish -r linux-x64 -c Release
dotnet publish -r osx.11.0 -c Release
dotnet publish -r win-x64 -c Release

## Related

- [[build-system]] — Architecture build docs
- [[build-summary]] — Build pipeline overview
- [[Cross-Cutting-Concerns]] — Cross-cutting build config
- [[Generators]] — Generator reference pattern
- [[Multi-Targeting Strategy]] — Framework targets
- [[Platform-Specific Build Constants]] — Platform symbols
- [[naming-conventions]] — Project naming rules
- [[projects/Index]] — All project docs
- [[onboarding/getting-started]] — Build commands
- [[ai-context]] — Build reference
- [[code-review-checklist]] — Build review items
```
