# JsonNativeAot

## Overview

`JsonNativeAot` is the main facade class providing static entry points for all JSON operations in the module. It manages lazy initialization of components and provides a convenient, thread-safe API.

**Location**: `src/Json/JsonNativeAot.cs`
**Type**: Static class
**Thread Safety**: Yes (uses `Lazy<T>`)
**AOT Compatible**: Yes (zero reflection)

## Architecture

The class delegates to these internal components:
- `IJsonParser` (JsonParser) - JSON string parsing
- `IJsonSerializer` (JsonSerializer) - Object serialization
- `IJsonDeserializer` (JsonDeserializer) - JSON deserialization
- `IJsonFileHandler` (JsonFileHandler) - File I/O
- `IEscapeSequenceHandler` (EscapeSequenceHandler) - Escape handling

All components are lazily initialized on first use for optimal performance.

## Public Methods

### Serialize<T>

Serializes an object to a JSON string.

**Signature**:
```csharp
public static string Serialize<T>(T instance) where T : IJsonSerializable
```

**Parameters**:
- `instance` (T) - The object to serialize

**Returns**: 
- `string` - JSON representation of the object

**Exceptions**:
- `ArgumentNullException` - If instance is null
- `JsonSerializationException` - If serialization fails

**Time Complexity**: O(n) - where n is the number of properties
**Space Complexity**: O(n) - for the output JSON string

**Example**:
```csharp
var user = new User { Name = "John", Age = 30 };
string json = JsonNativeAot.Serialize(user);
// Output: {"Name":"John","Age":"30"}
```

### Deserialize<T>

Deserializes a JSON string to a typed object.

**Signature**:
```csharp
public static T Deserialize<T>(string json) 
    where T : IJsonSerializable, IJsonDesSerializable<T>, new()
```

**Parameters**:
- `json` (string) - JSON string to deserialize

**Returns**:
- `T` - Deserialized object instance

**Exceptions**:
- `ArgumentNullException` - If json is null
- `JsonDeserializationException` - If deserialization fails
- `JsonParsingException` - If JSON parsing fails

**Time Complexity**: O(n) - where n is the length of the JSON string
**Space Complexity**: O(n) - for the property dictionary

**Example**:
```csharp
string json = "{\"Name\":\"John\",\"Age\":\"30\"}";
var user = JsonNativeAot.Deserialize<User>(json);
// user.Name = "John", user.Age = 30
```

### SerializeToFile<T>

Serializes an object to a JSON file.

**Signature**:
```csharp
public static void SerializeToFile<T>(T instance, string fileName, string relativePath) 
    where T : IJsonSerializable
```

**Parameters**:
- `instance` (T) - Object to serialize
- `fileName` (string) - File name without extension
- `relativePath` (string) - Relative path from current directory

**File Path**: `{CurrentDirectory}/{relativePath}/{fileName}.json`

**Exceptions**:
- `ArgumentNullException` - If any parameter is null
- `IOException` - If file operations fail

**Behavior**:
- Creates the directory if it doesn't exist
- Overwrites existing files

**Example**:
```csharp
var user = new User { Name = "John", Age = 30 };
JsonNativeAot.SerializeToFile(user, "user", "data/users");
// Creates: {CurrentDirectory}/data/users/user.json
```

### DeserializeFromFile<T>

Deserializes a JSON file to a typed object.

**Signature**:
```csharp
public static T DeserializeFromFile<T>(string fileName, string relativePath) 
    where T : IJsonSerializable, IJsonDesSerializable<T>, new()
```

**Parameters**:
- `fileName` (string) - File name without extension
- `relativePath` (string) - Relative path from current directory

**Returns**:
- `T` - Deserialized object instance

**Exceptions**:
- `FileNotFoundException` - If file doesn't exist
- `ArgumentNullException` - If any parameter is null
- `IOException` - If file operations fail
- `JsonDeserializationException` - If deserialization fails

**Example**:
```csharp
var user = JsonNativeAot.DeserializeFromFile<User>("user", "data/users");
// Reads: {CurrentDirectory}/data/users/user.json
```

### ParseJsonToDictionary

Parses JSON string into a property dictionary.

**Signature**:
```csharp
public static Dictionary<string, string> ParseJsonToDictionary(string json)
```

**Parameters**:
- `json` (string) - JSON string to parse

**Returns**:
- `Dictionary<string, string>` - Property names and values

**Exceptions**:
- `ArgumentNullException` - If json is null
- `JsonParsingException` - If JSON parsing fails

**Notes**:
- Complex values (objects/arrays) are returned as raw JSON strings
- Low-level API for advanced usage

**Time Complexity**: O(n) - where n is the length of the JSON string
**Space Complexity**: O(n) - for the output dictionary

**Example**:
```csharp
string json = "{\"Name\":\"John\",\"Age\":\"30\",\"Tags\":[\"tag1\",\"tag2\"]}";
var props = JsonNativeAot.ParseJsonToDictionary(json);
// props["Name"] = "John"
// props["Age"] = "30"
// props["Tags"] = "[\"tag1\",\"tag2\"]"
```

## Internal Implementation

### Lazy Initialization

The class uses `Lazy<T>` for thread-safe initialization:

```csharp
private static readonly Lazy<IEscapeSequenceHandler> _escapeSequenceHandler = 
    new(() => new EscapeSequenceHandler());

private static readonly Lazy<IJsonParser> _jsonParser = 
    new(() => new JsonParser(_escapeSequenceHandler.Value));

private static readonly Lazy<IJsonSerializer> _jsonSerializer = 
    new(() => new JsonSerializer());

private static readonly Lazy<IJsonDeserializer> _jsonDeserializer = 
    new(() => new JsonDeserializer(_jsonParser.Value));

private static readonly Lazy<IJsonFileHandler> _jsonFileHandler = 
    new(() => new JsonFileHandler(_jsonSerializer.Value, _jsonDeserializer.Value));
```

**Benefits**:
- Thread-safe without locks
- Services created only when first used
- Minimal memory overhead
- No performance penalty

## Usage Patterns

### Pattern 1: Simple Serialization

```csharp
public class Person : IJsonSerializable
{
    public string Name { get; set; }
    public int Age { get; set; }

    public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
    {
        yield return ("Name", Name);
        yield return ("Age", Age.ToString());
    }
}

var person = new Person { Name = "Alice", Age = 25 };
string json = JsonNativeAot.Serialize(person);
// Output: {"Name":"Alice","Age":"25"}
```

### Pattern 2: Bidirectional Serialization

```csharp
public class Person : IJsonSerializable, IJsonDesSerializable<Person>
{
    public string Name { get; set; }
    public int Age { get; set; }

    public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
    {
        yield return ("Name", Name);
        yield return ("Age", Age.ToString());
    }

    public Person CreateFromProperties(Dictionary<string, string> properties)
    {
        return new Person
        {
            Name = properties.TryGetValue("Name", out var name) ? name : null,
            Age = properties.TryGetValue("Age", out var age) && 
                  int.TryParse(age, out var ageValue) ? ageValue : 0
        };
    }
}

string json = "{\"Name\":\"Alice\",\"Age\":\"25\"}";
var person = JsonNativeAot.Deserialize<Person>(json);
```

### Pattern 3: File Operations

```csharp
// Save to file
var person = new Person { Name = "Bob", Age = 30 };
JsonNativeAot.SerializeToFile(person, "person", "data");

// Load from file
var loaded = JsonNativeAot.DeserializeFromFile<Person>("person", "data");
```

### Pattern 4: Nested Objects

```csharp
public class Company : IJsonSerializable, IJsonDesSerializable<Company>
{
    public string Name { get; set; }
    public List<Person> Employees { get; set; }

    public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
    {
        var employeeJson = "[" + string.Join(",", 
            Employees.Select(e => JsonNativeAot.Serialize(e))) + "]";
        
        yield return ("Name", Name);
        yield return ("Employees", employeeJson);
    }

    public Company CreateFromProperties(Dictionary<string, string> properties)
    {
        var employees = new List<Person>();
        if (properties.TryGetValue("Employees", out var empJson))
        {
            // Parse array of JSON objects
            // Implementation depends on specific format
        }

        return new Company
        {
            Name = properties.TryGetValue("Name", out var name) ? name : null,
            Employees = employees
        };
    }
}
```

## Performance Characteristics

### Time Complexity
| Operation | Complexity | Notes |
|-----------|-----------|-------|
| Serialize | O(n) | Iterate properties once |
| Deserialize | O(n) | Parse JSON and create object |
| ParseToDictionary | O(n) | Single-pass parse |
| File I/O | O(n) | Depends on file size |

### Space Complexity
All operations: O(n) - proportional to data size

### Optimizations
- Lazy initialization reduces startup overhead
- StringBuilder for efficient string building
- Single-pass parsing algorithm
- Dictionary for O(1) property lookup

## AOT Compatibility

✅ **100% AOT Compatible**

No dynamic features used:
- No `Activator.CreateInstance()`
- No reflection-based access
- No `Type.GetType()` calls
- No `MethodInfo.Invoke()`
- All types known at compile-time

## Thread Safety

The class is **thread-safe** due to:
- Lazy<T> initialization (thread-safe)
- Static readonly fields
- Stateless components

**Recommendation**: Use JsonNativeAot across the entire application (safe for concurrent access).

## Error Handling

### Exception Hierarchy
```
Exception
├── JsonParsingException (from parser)
├── JsonSerializationException (from serializer)
├── JsonDeserializationException (from deserializer)
├── ArgumentNullException (from null checks)
├── FileNotFoundException (from file operations)
└── IOException (from file operations)
```

## Related Components

- [JsonParser](../parsing/jsonParser.md) - JSON parsing implementation
- [JsonSerializer](../serialization/jsonSerializer.md) - Serialization implementation
- [JsonDeserializer](../deserialization/jsonDeserializer.md) - Deserialization implementation
- [JsonFileHandler](../fileOperations/jsonFileHandler.md) - File I/O implementation
- [EscapeSequenceHandler](../helpers/escapeSequenceHandler.md) - Escape handling

## Best Practices

1. **Always implement both interfaces** for bidirectional serialization:
   ```csharp
   public class MyType : IJsonSerializable, IJsonDesSerializable<MyType>
   ```

2. **Handle null safely** in CreateFromProperties:
   ```csharp
   var value = properties.TryGetValue("Key", out var v) ? v : defaultValue;
   ```

3. **Use for complex types** - return raw JSON from GetSerializableProperties:
   ```csharp
   yield return ("nested", JsonNativeAot.Serialize(nestedObject));
   ```

4. **Validate input** in CreateFromProperties:
   ```csharp
   if (int.TryParse(ageStr, out var age) && age > 0)
       Age = age;
   ```

## See Also

- [Usage Examples](../samples/usageExamples.md)
- [Exception Handling](../exceptions.md)
- [Module Architecture](../architecture.md)

