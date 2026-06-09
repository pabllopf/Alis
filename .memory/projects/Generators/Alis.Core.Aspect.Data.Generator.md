---
title: Alis.Core.Aspect.Data.Generator
tags:
  - project
  - documentation
  - reference

status: draft

license: GPLv3
---


## Overview
Source generator (`ISourceGenerator`) for AOT-safe JSON serialization. Scans `[Serializable]` types and generates `IJsonSerializable` / `IJsonDesSerializable<T>` partial class implementations.

## Details
- **Layer**: 6_Ideation (Data aspect)
- **Type**: `ISourceGenerator` + `ISyntaxReceiver`
- **Files**: 6 (1 `.csproj` + 5 `.cs`)
- **Target**: `netstandard2.0;net8.0;net10.0`

## Source Files

| File | Purpose |
|---|---|
| `SerializableSourceGenerator.cs` | Main source generator — drives the generation pipeline |
| `SerializableSyntaxReceiver.cs` | `ISyntaxReceiver` that collects all `[Serializable]` types |
| `SerializationCodeBuilder.cs` | Generates `GetSerializableProperties()` and `CreateFromProperties()` partial methods |
| `HelperMethodsGenerator.cs` | Generates helper methods for arrays, collections, dictionaries |
| `TypeConversionHelper.cs` | Type detection: IsList, IsDictionary, IsComplexType, etc. |

## Generated Output
For each `[Serializable]` type:
- Partial class implementing `IJsonSerializable` with `GetSerializableProperties()`
- Partial class implementing `IJsonDesSerializable<T>` with `CreateFromProperties(Dictionary<string, string>)`
- `ToJson()` / `FromJson()` extension methods wrapping `JsonNativeAot`
- Helper methods: `SerializeArray`, `DeserializeList`, `SerializeDictionary`, etc.

## Supported Types
- All primitive types, enums, DateTime, Guid, Uri, Version, TimeSpan
- Complex types (recursive)
- Arrays (1D/2D), generic collections, dictionaries
- Custom property names via `[JsonNativePropertyName]`
- Exclusion via `[JsonNativeIgnore]`

## Related
- [[projects/6_Ideation/Data]] — Data aspect
- [[projects/Generators]] — Generator overview
