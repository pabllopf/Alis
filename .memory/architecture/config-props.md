---
title: Config.props Reference
tags:
  - architecture
  - build
  - configuration
  - reference
status: Draft
license: GPLv3
---

# Config.props Reference

## Overview

The `.config/Config.props` file (777 lines) is the central build configuration for all Alis projects. Every `.csproj` imports it as its first action.

## Structure

### 1. Multi-Target Framework Configuration

```xml
<PropertyGroup Condition="$(Configuration) == 'Debug'">
    <TargetFrameworks>
        netcoreapp2.0;net5.0;net8.0;net10.0;netstandard2.0;net461
    </TargetFrameworks>
</PropertyGroup>
```

Release mode extends this to 19+ TFMs with platform-specific exclusions.

### 2. Platform Configuration

Six platform profiles: `Win`, `Osx`, `Linux`, `Browser`, `Ios`, `Android`

Each defines:
- Conditional target frameworks per platform
- Platform-specific define constants (`WIN`, `OSX`, `LINUX`)
- Architecture-specific configurations

### 3. Language Settings

```xml
<LangVersion>13</LangVersion>
<Nullable>disable</Nullable>
<AllowUnsafeBlocks>false</AllowUnsafeBlocks>
<WarningsAsErrors>true</WarningsAsErrors>
```

### 4. Dependency Resolution

Debug mode resolves dependencies through the 6-layer chain:

```xml
<ProjectReference Condition="$(ProjectDir.Contains('1_Presentation'))"
    Include="$(SolutionDir)2_Application/**/src/**/Alis.csproj"/>
<ProjectReference Condition="$(ProjectDir.Contains('2_Application'))"
    Include="$(SolutionDir)3_Structuration/**/src/**/Alis.*.csproj"/>
<!-- ...continues through all 6 layers... -->
```

### 5. Generator Reference Chain

All generator projects are injected as analyzers:

```xml
<ProjectReference Condition="..."
    OutputItemType="Analyzer"
    PrivateAssets="all"
    ReferenceOutputAssembly="false">
    <Properties>TargetFramework=netstandard2.0</Properties>
</ProjectReference>
```

### 6. Release Mode Source Merging

In Release mode, source files from lower layers are linked into upper-layer assemblies:

```xml
<Compile Condition="$(ProjectDir.Contains('2_Application'))"
    Include="$(SolutionDir)3_Structuration/Core/**/src/**/*.cs;"
    Link="$([System.String]::Copy('%(RecursiveDir)').Replace('src',''))%(Filename)%(Extension)"/>
```

### 7. SonarQube Rules

Numerous SonarQube warnings are suppressed as project-wide noise.

### 8. Package Metadata

Standard NuGet package metadata: author, license (GPLv3), icon, project URL, repository, tags.

### 9. Runtime Native Binary Deployment

Native libraries in `runtimes/<rid>/native/` are automatically copied to output.

### 10. InternalsVisibleTo

All projects expose internals to their test project:
```xml
<InternalsVisibleTo Include="$(AssemblyName).Test"/>
```

## Related

- [[Build System]]
- [[Architecture Overview]]
- [[Directory.Build.props]]
