# Exceptions

## JsonParsingException

Thrown when JSON parsing fails due to malformed input.

### Triggers

- Unexpected character in JSON
- Unmatched quotes
- Invalid escape sequence
- Malformed JSON structure

### Example

```csharp
try
{
    var props = JsonNativeAot.ParseJsonToDictionary("{invalid");
}
catch (JsonParsingException ex)
{
    // Handle parsing error
}
```

## JsonSerializationException

Thrown when serialization fails.

### Triggers

- Null instance passed to serializer
- Serialization logic error
- Underlying exception during property traversal

### Example

```csharp
try
{
    string json = JsonNativeAot.Serialize(null);
}
catch (JsonSerializationException ex)
{
    // Handle serialization error
}
```

## JsonDeserializationException

Thrown when deserialization fails.

### Triggers

- Null JSON string
- Parsing failure
- Property population failure
- Type conversion error
- Invalid property dictionary

### Example

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

## Exception Hierarchy

```
System.Exception
  ├─ JsonParsingException
  ├─ JsonSerializationException
  └─ JsonDeserializationException
```

## Error Handling Best Practices

1. Always wrap deserialization in try-catch
2. Log exception details for debugging
3. Provide user-friendly error messages
4. Validate JSON before parsing when possible

## Related

- [[JsonParser]] - Throws JsonParsingException
- [[JsonSerializer]] - Throws JsonSerializationException
- [[JsonDeserializer]] - Throws JsonDeserializationException
