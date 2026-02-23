# JsonParser Documentation

## Overview

**Location**: `src/Json/Parsing/JsonParser.cs`
**Type**: Class
**Implements**: `IJsonParser`
**Thread Safety**: Stateless (thread-safe)
**AOT Compatible**: Yes

## Purpose

Parses JSON strings into dictionaries of property names and values. Provides low-level JSON parsing functionality with support for nested objects, arrays, and escape sequences.

## Architecture

The parser uses a character-by-character streaming approach:

1. **Tokenization**: Reads JSON character by character
2. **Escape Handling**: Processes escape sequences using IEscapeSequenceHandler
3. **Value Extraction**: Identifies and extracts property keys and values
4. **Type Preservation**: Maintains raw JSON for nested structures

## Public Methods

### ParseToDictionary

**Signature**:
```csharp
Dictionary<string, string> ParseToDictionary(string json)
```

**Parameters**:
- `json` (string) - The JSON string to parse

**Returns**:
- `Dictionary<string, string>` - Properties with string values

**Exceptions**:
- `ArgumentNullException` - If json is null
- `JsonParsingException` - If JSON is malformed

**Algorithm Complexity**:
- Time: O(n) - Single pass through the JSON string
- Space: O(n) - Dictionary storage

## Implementation Details

### Parsing Strategy

1. **Initialization**: Skip leading whitespace and opening brace
2. **Property Loop**: 
   - Extract property name (must be quoted string)
   - Skip colon separator
   - Extract property value
   - Handle comma separators
3. **Value Types**:
   - Quoted strings: Parse with escape handling
   - Objects/Arrays: Extract raw JSON (recursive)
   - Primitives: Extract as-is

### Escape Sequence Handling

The parser delegates escape sequence processing to `IEscapeSequenceHandler`:
- Detects escaped characters
- Converts escape sequences to actual characters
- Supports Unicode escapes (\uXXXX)

### Example Parsing

```json
{"Name":"John","Age":"30","Active":"true","Tags":["tag1","tag2"]}
```

Results in:
```csharp
{
    "Name" → "John",
    "Age" → "30",
    "Active" → "true",
    "Tags" → "[\"tag1\",\"tag2\"]"
}
```

## Supported JSON Features

✅ **Supported**:
- Object properties with string keys
- String values (with escape sequences)
- Numeric values (as strings)
- Boolean values (as strings)
- Null values
- Nested objects (as raw JSON)
- Arrays (as raw JSON)
- Whitespace
- Escaped characters

❌ **Not Supported**:
- Comments
- Trailing commas
- Single quotes for strings
- Unquoted keys

## Error Handling

### Invalid JSON Scenarios

1. **Malformed Structure**: Missing braces, invalid syntax
   - Throws: `JsonParsingException`

2. **Unterminated Strings**: Missing closing quote
   - Throws: `JsonParsingException`

3. **Invalid Escapes**: Unrecognized escape sequences
   - Result: Treated as literal characters

### Safe Parsing

All exceptions wrap the original error with context:

```csharp
try { /* parse */ }
catch (JsonParsingException) { throw; }
catch (Exception ex) 
{
    throw new JsonParsingException($"Failed to parse JSON: {ex.Message}", ex);
}
```

## Usage Examples

### Simple Parsing

```csharp
var parser = new JsonParser(new EscapeSequenceHandler());
string json = "{\"Name\":\"Alice\",\"Age\":\"25\"}";
var dict = parser.ParseToDictionary(json);

Console.WriteLine(dict["Name"]); // "Alice"
Console.WriteLine(dict["Age"]);  // "25"
```

### Complex Nested Structure

```csharp
string json = @"{
    ""User"":{""Name"":""Bob"",""Email"":""bob@example.com""},
    ""Scores"":[90, 85, 92],
    ""Active"":""true""
}";

var dict = parser.ParseToDictionary(json);

// Complex values returned as raw JSON
Console.WriteLine(dict["User"]);   
// {\"Name\":\"Bob\",\"Email\":\"bob@example.com\"}

Console.WriteLine(dict["Scores"]); 
// [90, 85, 92]
```

### Error Handling

```csharp
try
{
    parser.ParseToDictionary("{invalid json}");
}
catch (JsonParsingException ex)
{
    Console.WriteLine($"Parse error: {ex.Message}");
}
```

## Integration with Other Components

- **Used by**: `JsonDeserializer`, `JsonNativeAot`
- **Dependencies**: `IEscapeSequenceHandler`
- **Produces**: `Dictionary<string, string>`

## Performance Characteristics

| Metric | Value |
|--------|-------|
| Time Complexity | O(n) |
| Space Complexity | O(n) |
| First Char Access | O(n) |
| Property Lookup | O(1) |
| Worst Case | All special characters |

## Testing

Key test cases:

```csharp
// Empty JSON
ParseToDictionary("{}") → empty dictionary

// Simple properties
ParseToDictionary("{\"a\":\"1\",\"b\":\"2\"}") → {"a":"1","b":"2"}

// Nested structures
ParseToDictionary("{\"data\":{}}") → {"data":"{}"}

// Arrays
ParseToDictionary("{\"items\":[1,2]}") → {"items":"[1,2]"}

// Escape sequences
ParseToDictionary("{\"text\":\"a\\nb\"}") → {"text":"a\nb"}

// Malformed JSON
ParseToDictionary("{bad}") → throws JsonParsingException
```

## Best Practices

1. **Always null-check**: Null input throws `ArgumentNullException`
2. **Handle exceptions**: Malformed JSON throws `JsonParsingException`
3. **Process complex values**: Parse raw JSON from nested objects/arrays
4. **Use with deserializer**: Typically used via `JsonDeserializer`
5. **Validate input**: Pre-validate JSON format when possible

## Related Components

- [EscapeSequenceHandler](escapeSequenceHandler.md)
- [JsonDeserializer](../deserialization/jsonDeserializer.md)
- [JsonNativeAot](../jsonNativeAot.md)

## Limitations

1. **No streaming**: Entire JSON must fit in memory
2. **Single-level recursion**: Nested structures returned as raw JSON
3. **No type inference**: All values are strings
4. **No validation**: Doesn't verify JSON validity beyond structure

## Future Improvements

- Streaming mode for large files
- Lazy evaluation of nested structures
- Configurable strict/lenient parsing
- Performance optimizations for very large JSON

