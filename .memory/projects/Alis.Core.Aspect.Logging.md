---
title: Alis.Core.Aspect.Logging
tags:
  - project
  - logging
  - diagnostics
  - layer-6
status: Draft
license: GPLv3
---

# Alis.Core.Aspect.Logging

## Overview

Logging infrastructure library (Layer 6 - Ideation). Provides configurable logging with filters, formatters, and multiple output targets.

## Properties

| Property | Value |
|---|---|
| **Layer** | 6 - Ideation |
| **Project Path** | `6_Ideation/Logging/src/` |
| **Test Project** | `Alis.Core.Aspect.Logging.Test` |
| **Generator** | `Alis.Core.Aspect.Logging.Generator` |
| **Has Samples** | Yes (`Alis.Core.Aspect.Logging.Sample`) |

## Dependencies

- **Depends On**: [[Alis.Core.Aspect]] (Layer 5 reference chain)
- **Used By**: All upper layers

## Architecture

- `src/Abstractions/` - Logging abstractions and interfaces
- `src/Core/` - Core logging engine
- `src/Filters/` - Log filtering mechanisms
- `src/Formatters/` - Log message formatting
- `src/Outputs/` - Log output targets (console, file, etc.)

## Source Structure

```
src/
  Abstractions/
  Core/
  Filters/
  Formatters/
  Outputs/
```

## Testing

- Test project: `Alis.Core.Aspect.Logging.Test`
- Located at `6_Ideation/Logging/test/`

## Related

- [[Alis.Core.Aspect]]
- [[Logging Domain]]
- [[Projects Index]]
