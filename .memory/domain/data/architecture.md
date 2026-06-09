# Architecture

tags:
  - domain,api,reference,documentation

## Design Patterns

### Facade Pattern

`JsonNativeAot` provides a unified interface to complex subsystem:

```
Facade: JsonNativeAot
  ├─ Serialization Facade
  ├─ Deserialization Facade
  ├─ Parsing Facade
  └─ File Operations Facade
```

### Strategy Pattern

Interface-based strategies:
- `IJsonSerializer` - Serialization strategy
- `IJsonDeserializer` - Deserialization strategy
- `IJsonParser` - Parsing strategy
- `IEscapeSequenceHandler` - Escape handling strategy

### Lazy Initialization

Singleton pattern via `Lazy<T>`:

```csharp
private static readonly Lazy<IJsonSerializer> _jsonSerializer =
    new(() => new JsonSerializer());
```

## Component Architecture

### Core Components

| Component | Type | Responsibility |
|---|---|---|
| `JsonNativeAot` | Static Facade | Main entry point |
| `JsonSerializer` | Strategy | Object → JSON |
| `JsonDeserializer` | Strategy | JSON → Object |
| `JsonParser` | Strategy | JSON → Dictionary |
| `EscapeSequenceHandler` | Strategy | Escape processing |
| `JsonFileHandler` | Facade | File I/O |

### Data Flow

```mermaid
sequenceDiagram
    participant Client
    participant JsonNativeAot
    participant JsonSerializer
    participant JsonParser
    participant JsonDeserializer
    
    Client->>JsonNativeAot: Serialize(obj)
    JsonNativeAot->>JsonSerializer: Serialize(obj)
    JsonSerializer->>obj: GetSerializableProperties()
    JsonSerializer-->>JsonNativeAot: JSON string
    
    Client->>JsonNativeAot: Deserialize<T>(json)
    JsonNativeAot->>JsonParser: ParseToDictionary(json)
    JsonParser-->>JsonDeserializer: Dictionary
    JsonDeserializer->>new T(): CreateFromProperties(dict)
    JsonDeserializer-->>JsonNativeAot: T instance
```

## Layer Boundaries

### Internal Layers

```
Alis.Core.Aspect.Data
├── Json (Core)
│   ├── Serialization
│   ├── Deserialization
│   ├── Parsing
│   ├── FileOperations
│   ├── Helpers
│   └── Exceptions
└── Attributes
```

### External Boundaries

- **No Presentation Layer** - Pure library
- **No Application Layer** - No business logic
- **No Infrastructure Dependencies** - Pure .NET

## AOT Design Principles

### Allowed Patterns

✅ Interface-based contracts
✅ Expression trees (metadata)
✅ Lazy<T> initialization
✅ Standard library types
✅ Value objects
✅ Immutable data structures

### Forbidden Patterns

❌ System.Reflection.Emit
❌ Runtime IL generation
❌ DynamicMethod creation
❌ Runtime Type.GetMembers()
❌ Dynamic LINQ
❌ Expression tree compilation to IL

## Thread Safety

- All public static members are thread-safe
- `Lazy<T>` ensures thread-safe singleton initialization
- No mutable static state
- Immutable data structures where possible

## Performance Characteristics

| Operation | Time Complexity | Space Complexity |
|---|---|---|
| Serialize | O(n) | O(n) |
| Deserialize | O(n) | O(n) |
| Parse | O(n) | O(n) |
| File I/O | O(n) + I/O | O(n) |

Where n = number of properties or JSON string length.

## Related

- [[Serialization Contract]] - Serialization architecture
- [[Deserialization Contract]] - Deserialization architecture
- [[Parsing Contract]] - Parsing architecture
- [[File Operations]] - File I/O architecture
