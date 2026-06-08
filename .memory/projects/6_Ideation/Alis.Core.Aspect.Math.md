# Alis.Core.Aspect.Math

## Overview

The **Alis.Core.Aspect.Math** project provides core math primitives for the ALIS game engine. It implements value-type vectors, matrices, shapes, quaternions, and custom math utilities designed for high-performance calculations with zero GC pressure on hot paths.

## Purpose

- Provide 2D/3D vector mathematics (Vector2F, Vector3F, Vector4F)
- Implement matrix operations (2x2, 3x2, 3x3, 4x4)
- Define geometric shapes (Circle, Line, Point, Rectangle, Square)
- Offer custom math functions optimized for float operations

## Architecture

### Value Types

All types use `[StructLayout(LayoutKind.Sequential, Pack = 1)]` for cache-friendly memory layout:

| Type | Description |
|------|-------------|
| **Vectors** | Vector2F, Vector3F, Vector4F (with fuzzy equality for collision detection) |
| **Matrices** | Matrix2X2, Matrix3X2, Matrix3X3, Matrix4X4 (with precomputed hashCode) |
| **Shapes** | CircleF/I, LineF/I, PointF/I, RectangleF/I, SquareF/I |
| **Utilities** | Color (RGBA), Depth, Quaternion, CustomMathF, HashCode |

### Key Features

- **Fuzzy equality** - Vector2F uses 0.01f tolerance for float comparison
- **Precomputed hashCode** - Matrices and Quaternions cache hash codes
- **Integer/Float variants** - Every shape has F and I versions
- **IShape marker** - Empty interface for generic constraints

## Files

| File | Count | Description |
|------|-------|-------------|
| Vector2F.cs | 1 | 2D float vector |
| Vector3F.cs | 1 | 3D float vector |
| Vector4F.cs | 1 | 4D float vector (color/quad) |
| Matrix2X2.cs | 1 | 2x2 matrix |
| Matrix3X2.cs | 1 | 3x2 affine transform |
| Matrix4X4.cs | 1 | 4x4 perspective/orthographic |
| CircleF.cs | 1 | 2D circle |
| RectangleF.cs | 1 | 2D rectangle |
| CustomMathF.cs | 1 | Custom math functions |
| HashCode.cs | 1 | Custom hash code generator |

## Dependencies

- **System.Security.Cryptography** - RNGCryptoServiceProvider (HashCode)
- **Alis.Core** - Core engine

## Quality Plan

See [QualityPlan.md](QualityPlan.md) for performance goals.

## Known Issues

1. **HashCode uses RNGCryptoServiceProvider** - Blocking call, slow startup
2. **Quaternion hashCode stale** - Private setters invalidate cached hash
3. **No Vector3F/Vector4F hashCode** - Inconsistent API
4. **IShape is empty** - No common contract (Bounds, Intersects, Area)
5. **No SIMD support** - Could use Vector<T> intrinsics

## TODOs

- [ ] Fix hashCode immutability
- [ ] Replace RNGCryptoServiceProvider with Random.Shared
- [ ] Add hashCode to Vector types
- [ ] Give IShape a real contract (Intersects, Bounds, Area)
- [ ] Add Quaternion factory methods (Identity, FromEuler)
- [ ] Add matrix inverse/transpose
- [ ] Add shape collision detection

## Related Projects

- [[Alis.Core.Ecs]] - Uses math primitives for transforms
- [[Alis.Core.Graphic]] - Rendering uses math calculations
