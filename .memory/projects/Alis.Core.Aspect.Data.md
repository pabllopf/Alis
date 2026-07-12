---
title: Alis.Core.Aspect.Data
tags:
  - ideation
  - data
  - json
  - serialization
status: Draft
license: GPLv3
---

# Alis.Core.Aspect.Data

**Layer:** 6_Ideation
**Path:** `6_Ideation/Data/src/Alis.Core.Aspect.Data.csproj`

## Purpose

JSON serialization and deserialization framework with AOT-compatible source generator integration. Provides a high-performance, allocation-sensitive JSON pipeline for the Alis game framework.

## Public API

### Core Entry Points
- `JsonNativeAot` — Static facade for serialization/deserialization
- `IJsonSerializable` — Serialization contract
- `IJsonDesSerializable<T>` — Deserialization contract

### Parsing
- `IJsonParser` / `JsonParser` — JSON tokenization and parsing
- `EscapeSequenceHandler` / `IEscapeSequenceHandler` — String escaping

### Serialization
- `IJsonSerializer` / `JsonSerializer` — Object → JSON conversion

### Deserialization
- `IJsonDeserializer` / `JsonDeserializer` — JSON → Object conversion

### File Operations
- `IJsonFileHandler` / `JsonFileHandler` — File-based JSON IO

### Exceptions
- `JsonSerializationException`
- `JsonDeserializationException`
- `JsonParsingException`

## Source Generator

**Path:** `6_Ideation/Data/generator/`

Generates partial class implementations of `IJsonSerializable` and `IJsonDesSerializable<T>` at compile time for types marked with the interfaces.

Key classes:
- `SerializableSourceGenerator` — Main incremental generator
- `SerializationCodeBuilder` — Code generation for serialization/deserialization methods
- `HelperMethodsGenerator` — Auxiliary conversion helpers
- `TypeConversionHelper` — Type detection utilities
- `SerializableSyntaxReceiver` — Syntax tree scanning

## Dependencies

None (leaf layer — depends only on .NET BCL)

## Dependents (Upstream)

- Alis.Core.Aspect (5_Declaration)
- All projects transitively via Config.props

## Testing

**Path:** `6_Ideation/Data/test/`

23 test files covering:
- Unit tests for parser, serializer, deserializer
- Advanced integration tests
- Model serialization contracts (24 model types)
- Edge case and regression tests
- File operations
- AOT compatibility

## Risks

- Large number of test model types may indicate over-testing of simple types
- Source generator AOT compatibility may break with new TFMs
- Exception handling overhead in hot deserialization paths

## Related Documents

- [[Alis.Core.Aspect]]
- [[source-generator-architecture]]
- [[Alis.Core.Aspect.Fluent]]
