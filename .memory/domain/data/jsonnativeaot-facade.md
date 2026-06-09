# JsonNativeAot - Static Facade

tags:
  - domain,api,reference,documentation

## Overview

`JsonNativeAot` is the main entry point for all JSON operations. It provides a static facade that configures and exposes a complete JSON pipeline through lazily-initialized singletons.

## Architecture

### Lazy-Initialized Singletons

```csharp
private static readonly Lazy<IEscapeSequenceHandler> _escapeSequenceHandler
private static readonly Lazy<IJsonParser> _jsonParser
private static readonly Lazy<IJsonSerializer> _jsonSerializer
private static readonly Lazy<IJsonDeserializer> _jsonDeserializer
private static readonly Lazy<IJsonFileHandler> _jsonFileHandler
```

All components are initialized on first use and are thread-safe via `Lazy<T>`.

## Public API

### Serialization

```csharp
// Simple serialization
string json = JsonNativeAot.Serialize(person);

// Save to file
JsonNativeAot.SerializeToFile(person, "user123", "data/users");
```

### Deserialization

```csharp
// From JSON string
var person = JsonNativeAot.Deserialize<Person>(json);

// From file
var loaded = JsonNativeAot.DeserializeFromFile<Person>("user123", "data/users");
```

### Low-Level Parsing

```csharp
// Parse to dictionary
Dictionary<string, string> props = JsonNativeAot.ParseJsonToDictionary(json);
```

## Pipeline Flow

```
Serialize:
  IJsonSerializable.GetSerializableProperties() 
    → JsonSerializer.Serialize() 
      → JSON string

Deserialize:
  JSON string 
    → JsonParser.ParseToDictionary() 
      → Dictionary<string, string> 
        → IJsonDesSerializable.CreateFromProperties() 
          → T instance

File Operations:
  JSON file 
    → JsonFileHandler 
      → Serialize/Deserialize pipeline
```

## Thread Safety

- All static members are thread-safe
- `Lazy<T>` ensures thread-safe singleton initialization
- No mutable static state

## AOT Compatibility

This class is specifically designed for AOT environments:

✅ **No runtime code generation**
✅ **No System.Reflection.Emit**
✅ **No DynamicMethod creation**
✅ **No runtime IL emission**
✅ **Interface-based contracts only**

## Usage Pattern

```csharp
using Alis.Core.Aspect.Data.Json;

public class User : IJsonSerializable, IJsonDesSerializable<User>
{
    public string Id { get; set; }
    public string Name { get; set; }
    
    public IEnumerable<(string, string)> GetSerializableProperties()
    {
        yield return ("Id", Id);
        yield return ("Name", Name);
    }
    
    public User CreateFromProperties(Dictionary<string, string> props)
    {
        var user = new User();
        user.Id = props["Id"];
        user.Name = props["Name"];
        return user;
    }
}

// Usage
var user = new User { Id = "1", Name = "John" };
string json = JsonNativeAot.Serialize(user);
var loaded = JsonNativeAot.Deserialize<User>(json);
```

## Related

- [[IJsonSerializable]] - Serialization contract
- [[IJsonDesSerializable]] - Deserialization contract
- [[JsonSerializer]] - Serialization implementation
- [[JsonDeserializer]] - Deserialization implementation
- [[JsonParser]] - Low-level parsing
