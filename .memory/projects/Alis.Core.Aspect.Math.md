---
title: Alis.Core.Aspect.Math
tags:
  - project
  - math
  - vectors
  - matrices
  - layer-6
status: Draft
license: GPLv3
---

# Alis.Core.Aspect.Math

## Overview

Mathematics library (Layer 6 - Ideation). Provides vectors, matrices, shapes, and utility math functions for game development.

## Properties

| Property | Value |
|---|---|
| **Layer** | 6 - Ideation |
| **Project Path** | `6_Ideation/Math/src/` |
| **Test Project** | `Alis.Core.Aspect.Math.Test` |
| **Generator** | `Alis.Core.Aspect.Math.Generator` |
| **Has Samples** | Yes (`Alis.Core.Aspect.Math.Sample`) |

## Dependencies

- **Depends On**: [[Alis.Core.Aspect]] (Layer 5 reference chain)
- **Used By**: [[Alis.Core.Physic]], [[Alis.Core.Graphic]]

## Architecture

- `src/Collections/` - Math collections
- `src/Definition/` - Math definitions and constants
- `src/Matrix/` - Matrix operations (2D, 3D, 4D)
- `src/Shapes/` - Geometric shapes
- `src/Util/` - Math utility functions
- `src/Vector/` - Vector operations (2D, 3D, 4D)

## Source Structure

```
src/
  Collections/
  Definition/
  Matrix/
  Shapes/
  Util/
  Vector/
```

## Testing

- Test project: `Alis.Core.Aspect.Math.Test`
- Located at `6_Ideation/Math/test/`

## Related

- [[Alis.Core.Aspect]]
- [[Alis.Core.Physic]]
- [[Alis.Core.Graphic]]
- [[Math Domain]]
- [[Projects Index]]
