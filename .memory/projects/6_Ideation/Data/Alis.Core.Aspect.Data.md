---
title: Data Aspect Documentation
tags: [ideation,aspect,library,documentation]
---


## Alis.Core.Aspect.Data - JSON Serialization System

### Purpose
Lightweight JSON serialization/deserialization system with AOT-friendly design, supporting bidirectional conversion between objects and JSON strings.

### Dependencies
- **Alis.Core**: Base abstractions

### Key Components

#### JSON Interfaces
- **IJsonSerializable<T>**: Serialization contract
- **IJsonDesSerializable<T>**: Deserialization contract with CreateFromProperties
- **JsonNativeAot**: Static JSON serializer/deserializer

#### Features
- **Dictionary-based deserialization**: Property dictionary to object mapping
- **AOT-friendly**: No reflection overhead, suitable for Native AOT
- **Nested object support**: Raw JSON strings for complex types
- **Type-safe**: Generic constraints ensure parameterless constructors

### Design Pattern
- **Interface-based serialization**: Explicit contracts for serialization
- **Dictionary mapping**: Property name to value mapping
- **Static factory methods**: JsonNativeAot.Deserialize/Serialize

### Testing Status
- **Unit Tests**: Partial - needs expansion
- **Integration Tests**: Sample programs demonstrate usage

### Risks
1. **Performance**: Dictionary-based approach may have overhead for large objects
2. **Nested JSON**: Complex nested structures require secondary parsing
3. **Error Handling**: Invalid property names or types throw exceptions

### TODOs
- [ ] Expand test coverage to 80%+
- [ ] Add support for more JSON types
- [ ] Optimize for large object graphs
- [ ] Create comprehensive sample applications

### Quality Plan
See [[6_Ideation/Data/QualityPlan]] for improvement goals.
