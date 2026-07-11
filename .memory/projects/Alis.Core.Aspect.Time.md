---
title: Alis.Core.Aspect.Time
tags:
  - project
  - time
  - clock
  - layer-6
status: Draft
license: GPLv3
---

# Alis.Core.Aspect.Time

## Overview

Time measurement and tracking library (Layer 6 - Ideation). Provides clock and time utilities for game loop timing.

## Properties

| Property | Value |
|---|---|
| **Layer** | 6 - Ideation |
| **Project Path** | `6_Ideation/Time/src/` |
| **Test Project** | `Alis.Core.Aspect.Time.Test` |
| **Generator** | `Alis.Core.Aspect.Time.Generator` |
| **Has Samples** | Yes (`Alis.Core.Aspect.Time.Sample`) |

## Dependencies

- **Depends On**: [[Alis.Core.Aspect]] (Layer 5 reference chain)
- **Used By**: [[Alis.Core.Ecs]]

## Architecture

- Flat file structure in `src/`
- Key classes: `Clock`

## Source Structure

```
src/
  (flat files)
```

## Testing

- Test project: `Alis.Core.Aspect.Time.Test`
- Located at `6_Ideation/Time/test/`

## Related

- [[Alis.Core.Aspect]]
- [[Alis.Core.Ecs]]
- [[Time Domain]]
- [[Projects Index]]
