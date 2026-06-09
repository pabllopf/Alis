# Deserialization

tags:
  - domain,api,reference,documentation

## IJsonDesSerializable<T>

Defines a contract for objects that can reconstruct themselves from a flat dictionary of JSON property names and their string values.

### Interface Definition

```csharp
public interface IJsonDesSerializable<out T>
{
    T CreateFromProperties(Dictionary<string, string> properties);
}
```

### Generic Constraint

Type `T` must:
- Implement `IJsonSerializable`
- Implement `IJsonDesSerializable<T>`
- Have a parameterless constructor (`new()`)

### Implementation Guide

1. Create new instance using parameterless constructor
2. Iterate over property dictionary
3. Convert string values to target types
4. Handle missing or null entries gracefully
5. Return fully populated instance

### Example

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
            
        if (properties.TryGetValue("Tags", out var tagsJson))
        {
            // Parse raw JSON array string
            person.Tags = JsonSerializer.Deserialize<List<string>>(tagsJson);
        }
        
        return person;
    }
}
```

## IJsonDeserializer

Deserializes JSON strings into typed objects.

### Implementation

`JsonDeserializer` class:
- Accepts `IJsonParser` in constructor
- Parses JSON to property dictionary
- Creates new instance via parameterless constructor
- Calls `CreateFromProperties()` to populate
- Wraps exceptions in `JsonDeserializationException`

### Pipeline

```
1. Parse JSON string → Dictionary<string, string>
2. new T() - create instance
3. CreateFromProperties(properties) - populate
4. Return fully constructed object
```

## Error Handling

### JsonDeserializationException

Thrown when:
- JSON parsing fails
- Property population fails
- Type conversion fails
- Invalid property dictionary

```csharp
try
{
    var person = JsonNativeAot.Deserialize<Person>(json);
}
catch (JsonDeserializationException ex)
{
    // Handle deserialization error
}
```

## Complex Value Deserialization

Nested objects/arrays are delivered as raw JSON strings:

```csharp
if (properties.TryGetValue("Items", out var itemsJson))
{
    // itemsJson is a raw JSON array string
    // Parse it using nested deserialization
    var parsedItems = JsonSerializer.Deserialize<List<Product>>(itemsJson);
    person.Items = parsedItems;
}
```

## Performance Notes

- O(n) where n = JSON string length
- Single pass through property dictionary
- Minimal allocations
- No reflection overhead

## Related

- [[IJsonSerializable]] - Serialization counterpart
- [[JsonDeserializer]] - Implementation
- [[JsonParser]] - Low-level parsing
