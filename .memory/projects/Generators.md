# Generator Projects

## Overview
Generator projects provide code generation capabilities for the ALIS engine. They are organized within each layer's `Generator/` subdirectory and are dynamically referenced by all consuming projects.

## Generator Directory Structure
```
{Layer}/Generator/
├── src/    — Generator library (Alis.Generator.*)
├── test/   — Unit tests (Alis.Generator*.Test)
└── sample/ — Sample applications (Alis.Generator*.Sample)
```

## Generator Reference Pattern
All projects use dynamic glob-based project references to automatically include all generators:

```xml
<ItemGroup>
  <ProjectReference Include="$(MSBuildThisFileDirectory)..\..\*\Generator\src\*.csproj" />
  <ProjectReference Include="$(MSBuildThisFileDirectory)..\Generator\src\*.csproj" />
  <ProjectReference Include="$(MSBuildThisFileDirectory)..\..\Generator\src\*.csproj" />
  <ProjectReference Include="$(MSBuildThisFileDirectory)..\..\..\Generator\src\*.csproj" />
</ItemGroup>
```

This references generators from:
- Current layer (`..\Generator\src\`)
- Adjacent layers (`..\..\Generator\src\`, `..\..\*\Generator\src\`)
- Deeper layers (`..\..\..\Generator\src\`)

## Generator Build Configuration
- **LangVersion**: 13
- **Nullable**: disable
- **AllowUnsafeBlocks**: false
- **SonarQubeExclude**: true (test projects)

## Generator Asset Pipeline
All generators use the same asset pipeline:
- SHA256 hash-based change detection
- Incremental build via manifest file
- Base64-encoded zip archives

## Key Build Targets (All Generator Projects)
- `_PrepareAssetPackManifest` — Generates asset manifest with SHA256 hashes
- `ZipAssets` — Zips assets and encodes to base64

## Generator Dependencies
Generators depend on:
- [[Alis]] (2_Application) — Core application library
- Generators from lower layers (via glob references)

## Notes
- Generators are code-first tools that produce source code at build time
- Each layer has its own generators relevant to that layer's domain
- Dynamic referencing ensures all generators are automatically included
- No hardcoding of generator paths — uses MSBuild glob patterns
