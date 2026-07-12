---
title: Source Generator Architecture
tags:
  - architecture
  - source-generators
  - roslyn
status: Draft
license: GPLv3
---

# Source Generator Architecture

## Overview

Alis uses Roslyn source generators extensively for compile-time code generation. All generator projects target `netstandard2.0` and are consumed as analyzers.

## Generator Projects

| Module | Generator | Generated Output |
|---|---|---|
| Application | `Alis.Generator` | Application-specific code |
| Core | `Alis.Core.Generator` | Core abstractions |
| Audio | `Alis.Core.Audio.Generator` | Audio system code |
| ECS | `Alis.Core.Ecs.Generator` | ECS component registration |
| Graphic | `Alis.Core.Graphic.Generator` | Graphics system code |
| Physic | `Alis.Core.Physic.Generator` | Physics system code |
| Data | `Alis.Core.Aspect.Data.Generator` | JSON serialization/deserialization |
| Fluent | `Alis.Core.Aspect.Fluent.Generator` | Fluent API builder code |
| Memory | `Alis.Core.Aspect.Memory.Generator` | Resource accessor generation |

## How They Work

Generators are referenced as `OutputItemType="Analyzer"`:

```xml
<ProjectReference Include=".../generator/*.csproj"
                  OutputItemType="Analyzer"
                  PrivateAssets="all"
                  ReferenceOutputAssembly="false">
    <Properties>TargetFramework=netstandard2.0</Properties>
</ProjectReference>
```

This means:
1. Generator output DLLs are not compile dependencies
2. They run at compile time to produce additional source files
3. Generated code is AOT-compatible (no Reflection.Emit)
4. All generators target `netstandard2.0` for broad compatibility

## Data Generator Example

The `Alis.Core.Aspect.Data.Generator` generates:
- `IJsonSerializable.GetSerializableProperties()` — property enumeration
- `IJsonDesSerializable<T>.CreateFromProperties()` — deserialization construction

Both methods are generated as explicit interface implementations for classes implementing those interfaces.

## Consumption Flow

```mermaid
graph LR
    A[User Code] --> B[Source Generator]
    B --> C[Generated .cs]
    C --> D[Compiler]
    D --> E[Final Assembly]
```

## Related Documents

- [[Alis.Core.Aspect.Data]]
- [[build-pipeline]]
- [[module-structure]]
