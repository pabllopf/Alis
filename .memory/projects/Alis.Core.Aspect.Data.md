---
title: Alis.Core.Aspect.Data
tags:
  - project
  - data
  - serialization
  - json
  - layer-6
status: Draft
license: GPLv3
---

# Alis.Core.Aspect.Data

## Overview

Data serialization and deserialization library (Layer 6 - Ideation). Provides JSON serialization/deserialization capabilities.

## Properties

| Property | Value |
|---|---|
| **Layer** | 6 - Ideation |
| **Project Path** | `6_Ideation/Data/src/` |
| **Test Project** | `Alis.Core.Aspect.Data.Test` |
| **Generator** | `Alis.Core.Aspect.Data.Generator` |
| **Has Samples** | Yes (`Alis.Core.Aspect.Data.Sample`) |

## Dependencies

- **Depends On**: [[Alis.Core.Aspect]] (Layer 5 reference chain)
- **Used By**: All upper layers

## Architecture

- `src/Json/` - JSON serialization/deserialization logic
- Has a paired source generator project

## Source Structure

```
src/
  Json/
```

## Testing

- Test project: `Alis.Core.Aspect.Data.Test`
- Located at `6_Ideation/Data/test/`

## Related

- [[Alis.Core.Aspect]]
- [[Data Domain]]
- [[Projects Index]]
