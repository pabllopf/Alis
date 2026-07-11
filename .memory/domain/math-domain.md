---
title: Math Domain
tags:
  - domain
  - math
  - vectors
  - matrices
status: Draft
license: GPLv3
---

# Math Domain

## Overview

The Math domain provides vector, matrix, and geometric math operations essential for game development. Implemented in [[Alis.Core.Aspect.Math]].

## Module Structure

| Directory | Purpose |
|---|---|
| `Collections/` | Specialized math collections |
| `Definition/` | Math constants and definitions |
| `Matrix/` | 2D, 3D, 4D matrix operations |
| `Shapes/` | Geometric shape primitives |
| `Util/` | Math utility functions |
| `Vector/` | 2D, 3D, 4D vector operations |

## Key Types

- `CustomMathF` - Custom floating-point math
- `HashCode` - Hash code utilities
- Vector types (2D, 3D, 4D)
- Matrix types (2x2, 3x3, 4x4)
- Shape types (Rectangle, Circle, etc.)

## Usage

Used extensively by:
- [[Alis.Core.Physic]] - Physics calculations
- [[Alis.Core.Graphic]] - Transform matrices, projection
- [[Alis.Core.Ecs]] - Spatial queries

## Related

- [[Alis.Core.Aspect.Math]]
- [[Alis.Core.Aspect.Math.Generator]]
- [[Alis.Core.Physic]]
- [[Alis.Core.Graphic]]
