# Alis.Core.Aspect.Data

## Overview
Data persistence and JSON serialization library for ALIS game engine. Provides AOT-compatible JSON handling with file operations.

**Author**: Pablo Perdomo Falcón  
**License**: GNU General Public License v3.0

## Project Details
- **Layer**: 6_Ideation
- **Type**: Library (Data Aspect)
- **Framework**: net8.0, netstandard2.0
- **Output Type**: Class Library

## Purpose
Provides comprehensive data persistence and JSON serialization functionality including:
- AOT-compatible JSON serialization/deserialization
- File operations for JSON files
- Custom attributes for serialization control
- Type-safe data handling

## Key Components

### JSON Serialization
- **JsonSerializer<T>** - Generic JSON serializer
- **IJsonSerializer<T>** - Serialization interface
- **IJsonDesSerializable<T>** - Deserialization interface
- **IJsonSerializable** - Serialization marker

### File Operations
- **JsonFileHandler<T>** - JSON file handler implementation
- **IJsonFileHandler** - File operations interface
- Automatic directory creation
- .json extension handling

### Custom Attributes
- **JsonNativeIgnoreAttribute** - Skip property during serialization
- **JsonNativePropertyNameAttribute** - Custom JSON property name

### AOT Support
- **JsonNativeAot** - AOT-compatible serialization
- No reflection-based serialization
- Compile-time code generation

### Error Handling
- **JsonDeserializationException** - Deserialization errors
- **JsonParsingException** - JSON parsing errors

## Dependencies
- System.Text.Json - Native JSON handling
- System.IO - File operations

## Build Configuration
- **LangVersion**: 13
- **Nullable**: enabled
- **AllowUnsafeBlocks**: false

### AOT Features
1. No runtime reflection
2. Compile-time serialization code generation
3. Cross-platform file handling
4. Thread-safe operations

## Testing Status
- **Unit Tests**: Present (Alis.Core.Aspect.Data.Test)
- **Sample Apps**: Included (Alis.Core.Aspect.Data.Sample)

## Architecture Notes
1. Interface-based design for flexibility
2. Generic type parameters for type safety
3. AOT-first approach for performance
4. Cross-platform path handling

## Related Projects
- [[Alis.App.Engine]] (1_Presentation) - Uses JSON for save/load
- [[Alis.Core.Aspect.Memory]] (6_Ideation) - Asset persistence

## Documentation Version
Auto-generated from source code analysis. Last updated: 2026-06-08
