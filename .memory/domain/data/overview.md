---
title: Alis.Core.Aspect.Data
tags:
  - domain
  - api
  - reference
  - documentation

status: Draft

license: GPLv3

---


## Overview

**Alis.Core.Aspect.Data** is a JSON serialization/deserialization library designed for AOT (Ahead-of-Time) compiled environments. It provides a reflection-free, runtime IL-emission-free approach to JSON handling through interface-based contracts.

## Purpose

This project enables:
- JSON serialization without System.Text.Json or Newtonsoft.Json dependencies
- AOT-compatible JSON handling for .NET Native, NativeAOT, and other ahead-of-time compiled scenarios
- Bidirectional JSON conversion through `IJsonSerializable` and `IJsonDesSerializable<T>` interfaces
- File-based JSON persistence with automatic directory creation

## Architecture

### Core Interfaces

| Interface | Namespace | Purpose |
|---|---|---|
| `IJsonSerializable` | `Alis.Core.Aspect.Data.Json` | Provides serializable properties as name-value tuples |
| `IJsonDesSerializable<T>` | `Alis.Core.Aspect.Data.Json` | Reconstructs objects from property dictionaries |
| `IJsonSerializer` | `Alis.Core.Aspect.Data.Json.Serialization` | Serializes objects to JSON strings |
| `IJsonDeserializer` | `Alis.Core.Aspect.Data.Json.Deserialization` | Deserializes JSON strings to objects |
| `IJsonParser` | `Alis.Core.Aspect.Data.Json.Parsing` | Parses JSON to flat property dictionaries |
| `IJsonFileHandler` | `Alis.Core.Aspect.Data.Json.FileOperations` | Reads/writes JSON files |

### Key Components

- **JsonNativeAot** - Static facade providing `Serialize<T>()`, `Deserialize<T>()`, `ParseJsonToDictionary()`, `SerializeToFile<T>()`, `DeserializeFromFile<T>()`
- **JsonSerializer** - Converts `IJsonSerializable` objects to JSON strings
- **JsonDeserializer** - Reconstructs objects from JSON via `IJsonDesSerializable<T>.CreateFromProperties()`
- **JsonParser** - Low-level JSON parsing to `Dictionary<string, string>`
- **EscapeSequenceHandler** - Handles JSON escape sequences in strings
- **JsonFileHandler** - File I/O operations with automatic directory creation

## Dependencies

```xml
<Import Project="$(SolutionDir).config/Config.props"/>
```

No external NuGet packages. Pure .NET Standard implementation.

## Target Frameworks

Multi-targeted to 15+ frameworks:
- .NET Standard 2.0-2.1
- .NET Core 2.0-3.1
- .NET 5.0-10.0
- .NET Framework 4.61-4.81

## AOT Compatibility

This library is specifically designed for AOT environments:

✅ **Allowed:**
- Interface-based contracts
- Expression trees (for metadata)
- Lazy<T> for singleton initialization
- Standard library types

❌ **Forbidden:**
- System.Reflection.Emit
- Runtime IL generation
- DynamicMethod creation
- Runtime Type.GetMembers() reflection

## Usage Pattern

### Serialization

```csharp
public class Person : IJsonSerializable
{
    public string Name { get; set; }
    public int Age { get; set; }
    public List<string> Tags { get; set; }
    
    public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
    {
        yield return ("Name", Name);
        yield return ("Age", Age.ToString());
        yield return ("Tags", Tags != null ? $"\"{string.Join(",", Tags)}\"" : null);
    }
}

string json = JsonNativeAot.Serialize(person);
```

### Deserialization

```csharp
public class Person : IJsonSerializable, IJsonDesSerializable<Person>
{
    public string Name { get; set; }
    public int Age { get; set; }
    public List<string> Tags { get; set; }
    
    public Person CreateFromProperties(Dictionary<string, string> properties)
    {
        var person = new Person();
        
        if (properties.TryGetValue("Name", out var name))
            person.Name = name;
            
        if (properties.TryGetValue("Age", out var ageStr) && int.TryParse(ageStr, out var age))
            person.Age = age;
            
        return person;
    }
}

var person = JsonNativeAot.Deserialize<Person>(json);
```

### File Operations

```csharp
JsonNativeAot.SerializeToFile(person, "user", "data/users");
var loaded = JsonNativeAot.DeserializeFromFile<Person>("user", "data/users");
```

## File Structure

```
6_Ideation/Data/src/
├── Json/
│   ├── IJsonSerializable.cs
│   ├── IJsonDesSerializable.cs
│   ├── JsonNativeAot.cs
│   ├── Serialization/
│   │   ├── IJsonSerializer.cs
│   │   └── JsonSerializer.cs
│   ├── Deserialization/
│   │   ├── IJsonDeserializer.cs
│   │   └── JsonDeserializer.cs
│   ├── Parsing/
│   │   ├── IJsonParser.cs
│   │   └── JsonParser.cs
│   ├── FileOperations/
│   │   ├── IJsonFileHandler.cs
│   │   └── JsonFileHandler.cs
│   ├── Helpers/
│   │   ├── IEscapeSequenceHandler.cs
│   │   └── EscapeSequenceHandler.cs
│   ├── Exceptions/
│   │   ├── JsonParsingException.cs
│   │   ├── JsonSerializationException.cs
│   │   └── JsonDeserializationException.cs
│   ├── JsonNativeIgnoreAttribute.cs
│   └── JsonNativePropertyNameAttribute.cs
└── Alis.Core.Aspect.Data.csproj
```

## Exception Types

| Exception | Trigger |
|---|---|
| `JsonParsingException` | Malformed JSON input |
| `JsonSerializationException` | Serialization failures |
| `JsonDeserializationException` | Deserialization or property population failures |

## Performance Characteristics

- **Serialization**: O(n) where n = number of properties
- **Deserialization**: O(n) where n = JSON string length
- **Memory**: Minimal allocations, no temporary object graphs
- **Thread Safety**: Lazy<T> ensures thread-safe singleton initialization

## Testing

See test project: `6_Ideation/Data/test/Alis.Core.Aspect.Data.Test.csproj`

## Related Projects

- [[Alis.Core.Aspect.Memory]] - Memory persistence aspect
- [[Alis.Core.Aspect.Fluent]] - Fluent validation aspect
- [[Alis.Core.Aspect.Logging]] - Logging aspect
- [[SharedKernel]] - Base abstractions

## License

GNU General Public License v3.0

## Author

Pablo Perdomo Falcón  
Web: https://www.pabllopf.dev/
