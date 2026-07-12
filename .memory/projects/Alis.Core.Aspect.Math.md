---
title: Alis.Core.Aspect.Math
tags:
  - ideation
  - math
  - vector
  - matrix
  - geometry
status: Draft
license: GPLv3
---

# Alis.Core.Aspect.Math

**Layer:** 6_Ideation
**Path:** `6_Ideation/Math/src/Alis.Core.Aspect.Math.csproj`

## Purpose

Core math library providing vector, matrix, shape, and utility types for the game framework.

## Types

### Vectors
- `Vector2F` — 2D float vector
- `Vector3F` — 3D float vector
- `Vector4F` — 4D float vector

### Matrices
- `Matrix2X2` — 2x2 matrix
- `Matrix3X2` — 3x2 matrix
- `Matrix3X3` — 3x3 matrix
- `Matrix4X4` — 4x4 matrix

### Shapes
- `IShape` — Shape interface
- `CircleF` / `CircleI` — Float/Int circles
- `LineF` / `LineI` — Float/Int lines
- `RectangleF` / `RectangleI` — Float/Int rectangles
- `PointF` / `PointI` — Float/Int points
- `SquareF` / `SquareI` — Float/Int squares

### Utilities
- `CustomMathF` — Custom math functions
- `HashCode` — Hash code utilities
- `RandomUtils` — Random number utilities
- `Quaternion` — Quaternion math
- `Helper` — General math helpers
- `Constant` — Math constants
- `Depth` — Depth/ordering utilities
- `Color` — Color representation

### Collections
- `IFastImmutableArray` / `FastImmutableArray` — High-performance immutable arrays

## Dependencies

None (leaf layer)

## Testing

**Path:** `6_Ideation/Math/test/`

45 test files covering:
- Vector math (2F, 3F, 4F with param'd tests)
- Matrix operations (2x2,3x3,4x4)
- Shape operations (all shape types)
- Collection (FastImmutableArray)
- Utility (RandomUtils, Quaternion, CustomMathF)
- Color and Depth definitions

## Performance Considerations

- Hot-path critical types (Vector, Matrix) used extensively throughout engine
- FastImmutableArray is a custom allocation-efficient collection
- No LINQ in hot math paths

## Related Documents

- [[Alis.Core.Aspect]]
- [[Alis.Core.Physic]]
- [[Alis.Core.Graphic]]
