---
title: Alis.Core.Aspect.Data
tags:
  - ideation
  - aspect
  - library
  - documentation

status: draft

license: GPLv3
---


## Overview

The **Alis.Core.Aspect.Data** project provides a JSON serialization/deserialization system with source generator support for AOT-compatible code generation. It implements a custom recursive descent parser instead of relying on System.Text.Json.

## Purpose

- Serialize/deserialize game objects to/from JSON
- Generate AOT-compatible serialization code at compile time
- Handle JSON parsing with escape sequences and raw values
- Support file-based JSON operations

## Architecture

### Core Interfaces

| Interface | Description |
|-----------|-------------|
| `IJsonSerializable` | Types that can be serialized (GetSerializableProperties) |
| `IJsonDeserializable<T>` | Types that can be deserialized (CreateFromProperties) |
| `IJsonParser` | JSON parsing to Dictionary<string,string> |
| `IJsonSerializer` | String-based serialization |
| `IJsonDeserializer<T>` | Deserialization from properties |

### Serialization Pipeline

1. **GetSerializableProperties()** - Returns property tuples
2. **JsonParser.ParseToDictionary()** - Parse JSON to dictionary
3. **CreateFromProperties()** - Reconstruct object from properties

### Source Generator

`SerializableSourceGenerator`:
- Scans for `[Serializable]` attribute
- Generates `IJsonSerializable` and `IJsonDeserializable<T>` implementations
- AOT-compatible (no reflection at runtime)

## Files

| File | Count | Description |
|------|-------|-------------|
| IJsonSerializable.cs | 1 | Serialization interface |
| IJsonDeserializable.cs | 1 | Deserialization interface |
| JsonParser.cs | 1 | Recursive descent parser |
| JsonSerializer.cs | 1 | String-based serializer |
| JsonDeserializer.cs | 1 | Property-based deserializer |
| Exceptions/*.cs | 3 | Custom exceptions |

## Dependencies

- **Microsoft.CodeAnalysis.CSharp** - Source generator (generator/ only)
- **Alis.Core** - Core engine

## Quality Plan

See [QualityPlan.md](QualityPlan.md) for performance goals.

## Known Issues

1. **String-based serialization** - All values serialized as strings, losing type information
2. **No array support** - Arrays read as raw JSON strings
3. **Unicode escaping not handled** - JsonParser doesn't handle \uXXXX sequences
4. **Generator attribute mismatch** - Generator uses `[Serializable]` but module defines `JsonNativeAot`

## TODOs

- [ ] Fix generator attribute detection
- [ ] Add proper numeric/boolean handling
- [ ] Improve parser with Unicode support
- [ ] Add array deserialization
- [ ] Performance optimization (object pooling, Span<char>)

## Related Projects

- [[Alis.Core.Aspect.Fluent]] - Fluent aspect system
- [[Alis.Core.Aspect.Data.Generator]] - Source generator
