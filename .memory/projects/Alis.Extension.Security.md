---
title: Alis.Extension.Security
tags:
  - project
  - security
  - encryption
  - secure-types
  - layer-1
status: Draft
license: GPLv3
---

# Alis.Extension.Security

## Overview

Security and encryption library (Layer 1 - Extension). Provides secure data types and random number generation for safe data handling.

## Properties

| Property | Value |
|---|---|
| **Layer** | 1 - Presentation (Extension) |
| **Project Path** | `1_Presentation/Extension/Security/src/` |
| **Test Project** | `Alis.Extension.Security.Test` |
| **Has Samples** | Yes (`Alis.Extension.Security.Sample`) |

## Dependencies

- **Depends On**: [[Alis]] (Layer 2 - Application)

## Architecture

- Flat file structure in `src/`
- Key types: `SecureByte`, `SecureChar`, `SecureInt`, `SecureString`, `SecureRandom`

## Source Structure

```
src/
  (flat files)
```

## Testing

- Test project: `Alis.Extension.Security.Test`
- Located at `1_Presentation/Extension/Security/test/`

## Related

- [[Projects Index]]
- [[Security Overview]]
