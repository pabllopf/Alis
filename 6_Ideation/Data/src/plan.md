# Data Module Plan

## Overview

JSON serialization/deserialization system with source generator support for AOT-compatible code generation. Part of the Aspect-oriented programming layer (5_Declaration/Aspect depends on this).

## Project Structure

| Project | Path | Type | Files |
|---------|------|------|-------|
| Alis.Core.Aspect.Data | `src/` | Library (net461-net9.0) | 20 source files |
| Alis.Core.Aspect.Data.Generator | `generator/` | Source Generator | 5 files |
| Alis.Core.Aspect.Data.Sample | `sample/` | Console App | 6 files |
| Alis.Core.Aspect.Data.Test | `test/` | xUnit Tests | 30+ files |

## Source Files (src/)

### Core Interfaces
- `IJsonSerializable.cs` - Interface for types that can be serialized (GetSerializableProperties)
- `IJsonDesSerializable.cs` - Interface for types that can be deserialized (CreateFromProperties)
- `JsonNativeAot.cs` - Attribute for marking types as AOT-serializable
- `JsonNativeIgnoreAttribute.cs` - Attribute to exclude properties from serialization
- `JsonNativePropertyNameAttribute.cs` - Attribute to rename properties in JSON output

### Serialization
- `Serialization/IJsonSerializer.cs` - Interface
- `Serialization/JsonSerializer.cs` - Implementation using StringBuilder, iterates GetSerializableProperties()

### Deserialization
- `Deserialization/IJsonDeserializer.cs` - Interface
- `Deserialization/JsonDeserializer.cs` - Implementation using IJsonParser + CreateFromProperties()

### Parsing
- `Parsing/IJsonParser.cs` - Interface (ParseToDictionary)
- `Parsing/JsonParser.cs` - Hand-written recursive descent parser with:
  - String handling with escape sequences
  - Raw JSON value support (nested objects/arrays)
  - Primitive value reading

### File Operations
- `FileOperations/IJsonFileHandler.cs` - Interface
- `FileOperations/JsonFileHandler.cs` - File read/write wrapper

### Helpers
- `Helpers/IEscapeSequenceHandler.cs` - Interface
- `Helpers/EscapeSequenceHandler.cs` - JSON escape/unescape logic

### Exceptions
- `Exceptions/JsonDeserializationException.cs`
- `Exceptions/JsonParsingException.cs`
- `Exceptions/JsonSerializationException.cs`

## Generator Files

### SerializableSourceGenerator
- Scans for types with `[Serializable]` attribute
- Generates implementations of IJsonSerializable and IJsonDesSerializable<T>
- Pipeline: SerializableSyntaxReceiver -> SemanticModel -> SerializationCodeBuilder -> AddSource

### Supporting Generator Files
- `SerializableSyntaxReceiver.cs` - Syntax filtering
- `SerializationCodeBuilder.cs` - Code generation logic
- `HelperMethodsGenerator.cs` - Helper method templates
- `TypeConversionHelper.cs` - Type conversion utilities

## Dependencies

- **Internal**: None (leaf module)
- **External**: Microsoft.CodeAnalysis.CSharp (generator only)

## Architecture Notes

- Manual JSON parser (not System.Text.Json) - custom implementation
- IJsonSerializable requires types to implement GetSerializableProperties() returning (propertyName, value) tuples
- Values are serialized as strings; complex values detected by checking for `{` or `[` prefix
- Deserialization parses JSON to Dictionary<string,string> then calls CreateFromProperties()
- Source generator auto-implements the interfaces for `[Serializable]` types
- AOT-compatible design: no reflection at runtime for generated code

## Code Quality Issues

1. **String-based serialization**: All property values serialized as strings, then parsed back on deserialization. Loses type information for numbers/booleans.
2. **No array support in parser**: Arrays are read as raw JSON strings but not deserialized into collections.
3. **IsComplexJsonValue heuristic**: Only checks for `{` or `[` prefix - fragile for edge cases.
4. **No Unicode escaping**: JsonParser doesn't handle Unicode escape sequences (\uXXXX).
5. **StringBuilder allocation**: JsonSerializer allocates a new StringBuilder per serialization call.
6. **Generator attribute mismatch**: Generator looks for `[Serializable]` but attributes are JsonNativeAOT/JsonNativeIgnore.

## Next Refactoring Tasks

### Priority 1 - Critical
1. **Fix generator attribute detection**: Generator uses `[Serializable]` but the module defines `JsonNativeAot` attribute. Align these.
2. **Add proper numeric/boolean handling**: Serialize actual JSON primitives instead of string-wrapping all values.

### Priority 2 - Important
3. **Improve parser**: Add proper Unicode escape handling, null/boolean literal parsing.
4. **Add array deserialization**: Parse JSON arrays into typed collections.
5. **Remove manual parser dependency**: Consider System.Text.Json for complex nested values instead of raw string passthrough.

### Priority 3 - Nice to have
6. **Add JSON validation**: Schema validation for deserialized types.
7. **Performance optimization**: Object pooling for StringBuilder, Span<char> parsing.
8. **Add JSON patching**: Partial update support for deserialized objects.

## Test Coverage

- Extensive test suite with parametrized tests
- Tests cover: serialization, deserialization, parsing, file operations, escape sequences, exceptions
- Integration tests for complex objects and nested structures
- AOT-specific tests
