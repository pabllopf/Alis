# EscapeSequenceHandler Documentation

## Overview

**Location**: `src/Json/Helpers/EscapeSequenceHandler.cs`
**Type**: Class
**Implements**: `IEscapeSequenceHandler`
**Thread Safety**: Stateless (thread-safe)
**AOT Compatible**: Yes

## Purpose

Handles JSON escape sequences and special character processing. Converts between escaped and unescaped string representations in compliance with JSON standards.

## Features

### Supported Escape Sequences

| Sequence | Character | Code | Example |
|----------|-----------|------|---------|
| `\"` | Double Quote | 0x22 | `"text"` → text |
| `\\` | Backslash | 0x5C | `\\` → \ |
| `\/` | Forward Slash | 0x2F | `\/` → / |
| `\b` | Backspace | 0x08 | Whitespace control |
| `\f` | Form Feed | 0x0C | Whitespace control |
| `\n` | Newline | 0x0A | Line break |
| `\r` | Carriage Return | 0x0D | Line return |
| `\t` | Tab | 0x09 | Horizontal tab |
| `\uXXXX` | Unicode | Any | `\u0041` → A |

## Public Methods

### IsEscaped

**Signature**:
```csharp
bool IsEscaped(string text, int position)
```

**Purpose**: Determines if a character at a specific position is escaped.

**Parameters**:
- `text` (string) - The string to examine
- `position` (int) - The character position to check

**Returns**:
- `bool` - True if the character is escaped, false otherwise

**Exceptions**:
- `ArgumentNullException` - If text is null

**Algorithm**:
Counts backslashes immediately before the position. If odd number of backslashes, character is escaped.

**Examples**:
```csharp
var handler = new EscapeSequenceHandler();

// Escaped quote
handler.IsEscaped("say \\\"hello\\\"", 5); // true

// Unescaped quote
handler.IsEscaped("say \"hello\"", 4); // false

// Double backslash
handler.IsEscaped("path\\\\file", 5); // true
```

### Unescape

**Signature**:
```csharp
string Unescape(string escapedString)
```

**Purpose**: Converts a string with escape sequences to its actual representation.

**Parameters**:
- `escapedString` (string) - String containing escape sequences

**Returns**:
- `string` - Unescaped string

**Exceptions**:
- `ArgumentNullException` - If escapedString is null

**Algorithm**:
Iterates through the string, converting escape sequences to their character equivalents.

**Examples**:
```csharp
var handler = new EscapeSequenceHandler();

// Basic escapes
handler.Unescape("line1\\nline2");      // "line1\nline2"
handler.Unescape("tab\\tseparated");    // "tab\tseparated"
handler.Unescape("quote\\\"text");      // "quote\"text"

// Unicode escape
handler.Unescape("hello\\u0041");       // "helloA"

// Multiple escapes
handler.Unescape("a\\tb\\nc\\ud");      // "a\tb\nc\ud"
```

## Implementation Details

### Escape Detection

The escape detection uses a counter approach:

```csharp
// Count backslashes before position
int count = 0;
while (position > 0 && text[position - 1] == '\\')
{
    count++;
    position--;
}

// Odd count = escaped
return count % 2 == 1;
```

This correctly handles:
- Single escape: `\"` → escaped
- Double escape: `\\\"` → unescaped (escaped backslash)
- Triple escape: `\\\\"` → escaped backslash + escaped quote

### Unescape Processing

Character-by-character processing with lookahead:

1. **Standard escapes**: Direct mapping
2. **Unicode escapes**: Hex parsing
3. **Invalid escapes**: Character kept as-is

## Unicode Handling

The handler supports Unicode escape sequences in the form `\uXXXX`:

**Examples**:
```csharp
handler.Unescape("\\u0041");     // "A"
handler.Unescape("\\u00E9");     // "é"
handler.Unescape("\\u4E2D");     // "中"
handler.Unescape("\\uFFFF");     // (U+FFFF)
```

**Invalid Unicode**:
```csharp
handler.Unescape("\\uGGGG");     // Silently ignored, kept as-is
handler.Unescape("\\u123");      // Partial - kept as-is
```

## Integration Points

### Used by Components

- **JsonParser**: Processes escape sequences in string values
- **JsonDeserializer**: Unescapes property values
- **JsonNativeAot**: Provides escape handling service

### Dependency Injection

```csharp
var escapeHandler = new EscapeSequenceHandler();
var parser = new JsonParser(escapeHandler);
```

## Performance Characteristics

| Operation | Complexity |
|-----------|-----------|
| IsEscaped | O(n) - worst case, all backslashes |
| Unescape | O(n) - linear scan |
| Memory | O(n) - output string |

## Edge Cases

### Handled Correctly

```csharp
// Empty string
Unescape("")  // ""

// No escapes
Unescape("plain text")  // "plain text"

// Multiple consecutive escapes
Unescape("\\\\\\\\")  // "\\\\" → "\\"

// Mixed escapes
Unescape("a\\nb\\tc")  // "a\nb\tc"

// Unicode with other escapes
Unescape("\\n\\u0041")  // "\nA"
```

### Boundary Conditions

```csharp
// Backslash at end
Unescape("text\\")  // "text\"

// Multiple backslashes
Unescape("\\\\")  // "\\"

// Invalid hex
Unescape("\\uXXXX")  // Kept as-is
```

## Testing Scenarios

Key test cases should include:

1. **Basic Escapes**:
   - All standard escape types
   - Combinations

2. **Unicode Escapes**:
   - Valid hex codes
   - Invalid codes
   - Boundary values

3. **Edge Cases**:
   - Empty strings
   - No escapes
   - Multiple consecutive escapes
   - Backslash at boundaries

4. **Error Handling**:
   - Null input
   - Invalid Unicode

## Best Practices

1. **Always null-check inputs**:
   ```csharp
   if (text == null) throw new ArgumentNullException(nameof(text));
   ```

2. **Handle invalid Unicode gracefully**:
   - Don't throw exceptions
   - Keep original sequence

3. **Cache escapeHandler instance**:
   ```csharp
   private static readonly EscapeSequenceHandler handler = 
       new EscapeSequenceHandler();
   ```

4. **Use before deserialization**:
   - Unescape before type conversion

## Related Components

- [JsonParser](jsonParser.md)
- [JsonDeserializer](../deserialization/jsonDeserializer.md)
- [JsonNativeAot](../jsonNativeAot.md)

## Standards Compliance

Implements JSON escape sequences per RFC 7159:
- All standard escapes supported
- Unicode escapes fully supported
- Compatible with JSON parsers

## Future Enhancements

- Custom escape handling
- Performance optimizations
- Configurable behavior for invalid sequences

