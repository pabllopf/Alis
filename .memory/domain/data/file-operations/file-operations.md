# File Operations

tags:
  - domain,api,reference,documentation

## IJsonFileHandler

Handles reading and writing JSON files to disk.

### Interface Definition

```csharp
public interface IJsonFileHandler
{
    void SerializeToFile<T>(T instance, string fileName, string relativePath) where T : IJsonSerializable;
    T DeserializeFromFile<T>(string fileName, string relativePath) where T : IJsonSerializable, IJsonDesSerializable<T>, new();
}
```

## JsonFileHandler

Implementation that:
- Accepts `IJsonSerializer` and `IJsonDeserializer` in constructor
- Creates target directory if it doesn't exist
- Serializes/deserializes via injected components

### Methods

#### SerializeToFile

```csharp
void SerializeToFile<T>(T instance, string fileName, string relativePath)
```

- Serializes object to JSON
- Creates directory structure if needed
- Writes to `{relativePath}/{fileName}.json`

#### DeserializeFromFile

```csharp
T DeserializeFromFile<T>(string fileName, string relativePath)
```

- Reads JSON file
- Deserializes to typed object
- Throws `FileNotFoundException` if file doesn't exist

### Example

```csharp
// Save
JsonNativeAot.SerializeToFile(person, "user123", "data/users");
// Creates: data/users/user123.json

// Load
var loaded = JsonNativeAot.DeserializeFromFile<Person>("user123", "data/users");
```

## Error Handling

| Exception | Condition |
|---|---|
| `ArgumentNullException` | Null parameters |
| `FileNotFoundException` | File doesn't exist |
| `IOException` | File I/O errors |
| `JsonSerializationException` | Serialization failure |
| `JsonDeserializationException` | Deserialization failure |

## Directory Creation

Automatic directory creation:

```csharp
// If "data/users" doesn't exist, it will be created
JsonNativeAot.SerializeToFile(person, "user", "data/users");
```

## Related

- [[JsonFileHandler]] - Implementation
- [[JsonNativeAot]] - Static facade
- [[IJsonSerializer]] - Serialization dependency
- [[IJsonDeserializer]] - Deserialization dependency
