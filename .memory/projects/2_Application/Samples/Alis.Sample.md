# Alis.Sample (All-in-One Sample)

tags:
  - application,sample,documentation

## Overview
All-in-one sample/demo application that exercises the full ALIS engine pipeline. Includes all source generators from across the 6-layer architecture and a custom asset build pipeline with SHA256-based incremental compilation.

## Project Details
- **Layer**: 2_Application
- **Type**: Sample Application (integration test / reference)
- **Framework**: `net10.0`
- **Output Dir**: `bin/$(Configuration)/$(RuntimeIdentifier)/lib/`
- **SonarQubeExclude**: `true`

## Dependencies
- **Direct**: [[projects/2_Application/Alis]] (Core application library)
- **Source Generators**: All generators from:
  - `3_Structuration/**/generator/**`
  - `4_Operation/**/generator/**`
  - `5_Declaration/**/generator/**`
  - `6_Ideation/**/generator/**`

## Build Configuration
- **LangVersion**: `13`
- **Nullable**: `disable`
- **AllowUnsafeBlocks**: `false`

## Asset Pipeline
Uses a custom MSBuild-based asset pipeline for resource management:

| Target | Description |
|---|---|
| `_PrepareAssetPackManifest` | Generates asset manifest with SHA256 content hashes for each asset file |
| `ZipAssets` | Compresses all assets into a zip archive |
| *(embedded)* | Base64-encodes the zip into the assembly |

**Architecture**: Incremental build — only re-processes assets when content changes (SHA256-based change detection via manifest file).

## Project References
- All `Generator.csproj` files from 4_Operation and 6_Ideation (referenced as Analyzers with `PrivateAssets=all`, `ReferenceOutputAssembly=false`)
- Targets `netstandard2.0` for generator compatibility

## Notes
- Most comprehensive sample in terms of dependency coverage (references every layer)
- Tests the full build pipeline including source generators
- Asset pipeline enables self-contained game builds without external asset files at runtime
- SHA256 manifest ensures deterministic builds and cache optimization
- Excluded from SonarQube analysis (sample code quality standards differ from library code)

## Related
- [[Multi-Platform Samples]] — Sample game overview
- [[projects/2_Application/Alis]] — Core application
- [[projects/1_Presentation/Engine]] — Engine runtime
- [[Application Composition]] — App structure
- [[Generator Pattern]] — Source generation
- [[Layered Architecture]] — Layer structure
- [[build-system]] — Build configuration
- [[projects/Index]] — All project docs
