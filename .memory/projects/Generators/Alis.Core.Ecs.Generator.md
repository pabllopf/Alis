# Alis.Core.Ecs.Generator

## Overview
Most complex generator in the Alis repository. Incremental generator (`IIncrementalGenerator`) that produces the ECS component type registry — scans all `IComponentBase` implementations and generates registration code consumed by the Alis.Core.Ecs runtime.

## Details
- **Layer**: 4_Operation (Ecs subsystem)
- **Type**: `IIncrementalGenerator` + `DiagnosticAnalyzer`
- **Files**: 14 (1 `.csproj` + 13 `.cs`)
- **Target**: `netstandard2.0;net8.0;net10.0`

## Source Files

| File | Purpose |
|---|---|
| `ComponentUpdateTypeRegistryGenerator.cs` | Main incremental generator — scans `IComponentBase` types, produces `AlisComponentRegistry.g.cs` |
| `GeneratorAnalyzer.cs` | Diagnostic analyzer: FR0000–FR0003 for invalid component configurations |
| `RegistryHelpers.cs` | Constants and extension methods for interface detection |
| `CodeBuilder.cs` | Thread-local `StringBuilder` wrapper for code generation |
| `CustomHashCode.cs` | xxHash32-based hash code for incremental caching |
| `EquatableArray.cs` | Value-equatable array wrapper for incremental generation stability |
| `Models/ComponentUpdateItemModel.cs` | Component registration data record |
| `Models/UpdateModelFlags.cs` | Flags: IsClass, IsStruct, IsGeneric, Initable, etc. |
| `Models/SourceOutput.cs` | (name, source) output record |
| `Models/TypeDeclarationModel.cs` | Nested type declaration model |
| `Structures/Stack.cs` | Custom resizable ref-struct stack |
| `Collections/FastImmutableArray.cs` | High-performance immutable array with builder |
| `Collections/IFastImmutableArray.cs` | Interface for FastImmutableArray |

## Generated Output
- `AlisComponentRegistry.g.cs` — monolithic registry with `[ModuleInitializer]` registering all components
- Generic type partial classes with self-initializing static constructors
- Supports `IOnInit`, `IOnDestroy`, and `[UpdateType]` attribute scanning

## Diagnostics
| Code | Description |
|---|---|
| FR0000 | Non-partial generic component type |
| FR0001 | Non-partial outer type for nested generic |
| FR0002 | Non-partial nested type |
| FR0003 | Multiple component interfaces on single type |

## Related
- [[projects/4_Operation/Ecs]] — ECS subsystem
- [[projects/Generators]] — Generator overview
