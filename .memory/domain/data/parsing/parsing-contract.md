---
title: JSON Parsing
tags:
  - domain
  - api
  - reference
  - documentation

status: draft
---


## IJsonParser

Parses JSON strings into flat property dictionaries without deserializing to specific types.

### Interface Definition

```csharp
public interface IJsonParser
{
    Dictionary<string, string> ParseToDictionary(string json);
}
```

### Implementation

`JsonParser` class:
- Accepts `IEscapeSequenceHandler` in constructor
- Parses JSON character by character
- Handles quoted strings, escape sequences
- Builds flat property dictionary
- Returns complex values as raw JSON strings

### Algorithm

```
1. Skip whitespace
2. Expect '{'
3. For each key-value pair:
   a. Parse quoted key
   b. Skip ':'
   c. Parse value (quoted string, object, or array)
   d. Add to dictionary
4. Expect '}'
```

## ParseJsonToDictionary

Low-level parsing method on `JsonNativeAot`:

```csharp
Dictionary<string, string> ParseJsonToDictionary(string json)
```

### Example

```csharp
string json = "{\"Name\":\"John\",\"Age\":\"30\"}";
var props = JsonNativeAot.ParseJsonToDictionary(json);
// props["Name"] = "John"
// props["Age"] = "30"
```

### Complex Values

Objects and arrays are returned as raw JSON:

```csharp
string json = "{\"Name\":\"John\",\"Tags\":[\"dev\",\"admin\"]}";
var props = JsonNativeAot.ParseJsonToDictionary(json);
// props["Tags"] = "[\"dev\",\"admin\"]"
```

## Escape Sequence Handling

`EscapeSequenceHandler` processes:
- `\"` - quoted string
- `\\` - backslash
- `\/` - forward slash
- `\b` - backspace
- `\f` - form feed
- `\n` - newline
- `\r` - carriage return
- `\t` - tab
- `\uXXXX` - Unicode

## Error Handling

### JsonParsingException

Thrown when:
- Malformed JSON
- Unexpected character
- Unmatched quotes
- Invalid escape sequence

## Performance

- O(n) where n = JSON string length
- Single pass parsing
- Minimal allocations
- No regex or reflection

## Related

- [[JsonParser]] - Implementation
- [[IEscapeSequenceHandler]] - Escape handling
- [[JsonDeserializer]] - Uses parser for deserialization
