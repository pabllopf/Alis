# Alis.Extension.Security

## Overview

The **Alis.Extension.Security** project provides secure data types that protect sensitive information from being exposed in memory through encryption and obfuscation techniques.

**Type**: Extension  
**Framework**: net8.0/netstandard2.0  
**Files**: 9 source files (1,383 lines total)

## Purpose

This extension provides secure wrapper types for primitive data types that encrypt values in memory to prevent exposure through memory dumps, debugging, or logging.

## Components

### Secure Types

| Type | Description | Lines |
|------|-------------|-------|
| `SecureChar` | Secure character wrapper with XOR obfuscation | 148 |
| `SecureByte` | Secure byte wrapper | 169 |
| `SecureInt` | Secure integer wrapper | 169 |
| `SecureLong` | Secure long wrapper | 168 |
| `SecureFloat` | Secure float wrapper | 162 |
| `SecureDouble` | Secure double wrapper | 162 |
| `SecureDecimal` | Secure decimal wrapper | 165 |
| `SecureString` | Secure string with encryption key | 94 |

### Core Infrastructure

| Type | Description |
|------|-------------|
| `SecureRandom` | Cryptographically secure random number generator wrapper |

## Architecture

### Encryption Strategy

Each secure type uses XOR-based obfuscation:

```csharp
// Example from SecureChar
private char _value;      // Encrypted value
private char _randomValue; // Obfuscation key

get => (_value - _randomValue);  // Decrypt on read
set => (_randomValue = key; _value = value + key);  // Encrypt on write
```

### SecureString Implementation

Uses a two-step encryption process:

1. **Key Generation**: Creates random char key using `SecureRandom.NextChar()`
2. **XOR Encryption**: Encrypts string character-by-character with the key

```csharp
public class SecureString
{
    private readonly char secret;           // Generated key
    private string encryptedValue;          // Encrypted data
    
    public string GetValue() => EncryptDecrypt(encryptedValue, secret);
}
```

## Public API

### SecureChar

- Constructor: `SecureChar(char value = '\x0000')`
- Implicit conversions to/from `char`
- Arithmetic operators: `+`, `-`, `*`, `/`
- Comparison operators: `==`, `!=`

### SecureString

- Constructor: `SecureString(string value)`
- Method: `string GetValue()`
- Internal method: `void SetValue(string value)`

### SecureRandom

- `int NextInt()` - Cryptographically secure random int
- `char NextChar()` - Cryptographically secure random char
- `long NextLong()` - Cryptographically secure random long
- `byte NextByte()` - Cryptographically secure random byte
- `float NextFloat(int min, int max)` - Range-based float
- `double NextDouble(int min, int max)` - Range-based double
- `decimal NextDecimal(int min, int max)` - Range-based decimal

## Dependencies

```xml
<Project Sdk="Microsoft.NET.Sdk">
    <Import Project="$(SolutionDir).config/Config.props"/>
</Project>
```

**External Dependencies**:
- `System.Security.Cryptography` - For secure random generation

## Security Considerations

### Strengths

1. **XOR Obfuscation**: Values are never stored in plain text
2. **Cryptographic Random**: Uses `RandomNumberGenerator` for keys
3. **Automatic Encryption/Decryption**: Transparent to users via implicit conversions

### Limitations

1. **Not Military-Grade**: XOR encryption is obfuscation, not true encryption
2. **Key in Memory**: Keys exist temporarily during operations
3. **No Authentication**: No integrity verification of encrypted data

### Use Cases

✅ Appropriate for:
- Preventing accidental exposure in logs
- Protecting against casual memory inspection
- Reducing attack surface for simple threats

❌ Not appropriate for:
- Protecting sensitive credentials
- Compliance-required encryption (PCI-DSS, HIPAA)
- High-security applications

## Testing

**Test Project**: `Alis.Extension.Security.Test`  
**Sample Project**: `Alis.Extension.Security.Sample`

## Related Projects

- [[projects/1_Presentation/Alis.Extension.Network]] - Network security
- [[Alis.Core]] - Core engine
- [[SecureString]] - Secure string implementation

## Usage Example

```csharp
// Secure character
SecureChar passwordChar = 'P';
char actualChar = passwordChar;  // Implicit conversion decrypts

// Secure string
var secret = new SecureString("MySecret");
string decrypted = secret.GetValue();

// Secure random
int randomInt = SecureRandom.NextInt();
char randomChar = SecureRandom.NextChar();
```

## Status

| Aspect | Status |
|--------|--------|
| Implementation | ✓ Complete |
| Documentation | ✓ Documented |
| Tests | Pending |
| Samples | Pending |

## TODO

- [ ] Add comprehensive unit tests
- [ ] Create security benchmark tests
- [ ] Document performance characteristics
- [ ] Add memory safety analysis
