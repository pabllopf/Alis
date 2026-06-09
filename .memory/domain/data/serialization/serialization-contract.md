# Serialization

tags:
  - domain,api,reference,documentation

## IJsonSerializable

Defines a contract for objects that can provide their serializable properties for JSON conversion.

### Interface Definition

```csharp
public interface IJsonSerializable
{
    IEnumerable<(string PropertyName, string Value)> GetSerializableProperties();
}
```

### Implementation Guide

1. Use `yield return` for each property
2. Primitive values should be converted to strings
3. Complex values (objects/arrays) should return raw JSON strings
4. Null values are allowed and will be skipped by the serializer
5. Time Complexity: O(n) where n = number of properties

### Example

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
```

## IJsonSerializer

Serializes objects implementing `IJsonSerializable` into JSON strings.

### Implementation

`JsonSerializer` class:
- Iterates over property tuples from `GetSerializableProperties()`
- Quotes primitive values
- Inserts complex values (objects/arrays) as raw JSON
- Skips null-valued properties
- Returns "{}" for empty objects

### Algorithm

```
1. Start with "{"
2. For each property:
   a. Skip if value is null
   b. Add comma separator (if not first)
   c. Add property name in quotes
   d. Add colon
   e. If value starts with '{' or '[': append as-is
   f. Otherwise: quote and append value
3. End with "}"
```

## JsonNativeIgnoreAttribute

Marks properties to be excluded from serialization.

```csharp
[JsonNativeIgnore]
public string Password { get; set; }
```

## JsonNativePropertyNameAttribute

Customizes the JSON property name.

```csharp
[JsonNativePropertyName("user_name")]
public string UserName { get; set; }
```

## Complex Value Handling

Complex values (nested objects or arrays) should be returned as raw JSON strings:

```csharp
public class Order : IJsonSerializable
{
    public string OrderId { get; set; }
    public List<Product> Items { get; set; }
    
    public IEnumerable<(string PropertyName, string Value)> GetSerializableProperties()
    {
        yield return ("OrderId", OrderId);
        yield return ("Items", Items != null ? JsonSerializer.Serialize(Items) : null);
    }
}
```

## Performance Notes

- StringBuilder-based construction for efficiency
- Minimal allocations during serialization
- No reflection overhead
- Compatible with AOT compilation

## Related

- [[IJsonDesSerializable]] - Deserialization counterpart
- [[JsonNativeAot]] - Static facade
- [[JsonSerializer]] - Implementation
