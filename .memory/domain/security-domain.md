---
title: Security Domain
tags:
  - domain
  - security
  - cryptography
  - extension
status: Draft
license: GPLv3
---

# Security Domain

## Overview

Cryptographic security utilities for generating secure random values.

## Module

**Assembly:** `Alis.Extension.Security`
**Layer:** 1_Presentation (Extension)
**Path:** `1_Presentation/Extension/Security/src/`

## Key Types

| Type | Description |
|---|---|
| `SecureInt` | Cryptographically secure random int |
| `SecureFloat` | Cryptographically secure random float |
| `SecureDouble` | Cryptographically secure random double |
| `SecureString` | Cryptographically secure random string |
| `SecureByte` | Cryptographically secure random byte |
| `SecureLong` | Cryptographically secure random long |
| `SecureDecimal` | Cryptographically secure random decimal |
| `SecureChar` | Cryptographically secure random char |

## Implementation

All types use `System.Security.Cryptography.RandomNumberGenerator`
for cryptographic randomness, suitable for:
- Game mechanics requiring unpredictable values
- Security-sensitive random generation
- Cryptographic key generation

## Dependencies

- Depends on: `2_Application/Alis`

## Related

- [[Alis.Extension.Security]]
- [[security-overview]]
