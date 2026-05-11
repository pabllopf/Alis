# Math Module Plan

## Overview

Core math primitives library providing value-type vectors, matrices, shapes, quaternions, and custom math utilities. Designed for high-performance game engine calculations with AOT compatibility and zero GC pressure on hot paths.

## Project Structure

| Project | Path | Type | Files |
|---------|------|------|-------|
| Alis.Core.Aspect.Math | `src/` | Library (net461-net9.0) | 25 source files |
| Alis.Core.Aspect.Math.Sample | `sample/` | Console App | - |
| Alis.Core.Aspect.Math.Test | `test/` | xUnit Tests | - |

## Source Files (src/)

### Vectors (3 files)
- `Vector2F.cs` - 2D float vector with static presets (Zero, One, UnitX, UnitY), operator overloads, Transform(Matrix3X2/Matrix4X4/Quaternion), fuzzy equality (0.01f tolerance), ISerializable
- `Vector3F.cs` - 3D float vector with similar API surface
- `Vector4F.cs` - 4D float vector (color/quad support)

### Matrices (4 files)
- `Matrix2X2.cs` - 2x2 matrix, Pack=1 layout, precomputed hashCode
- `Matrix3X2.cs` - 3x2 matrix for 2D affine transforms (position + scale + rotation), Transform(Vector2F)
- `Matrix3X3.cs` - 3x3 matrix for 2D projective transforms
- `Matrix4X4.cs` - 4x4 matrix for 3D perspective/orthographic projections
- `CustomIndexOutOfRangeException.cs` - Custom exception for matrix bounds

### Shapes (8 files)
- `IShape.cs` - Empty marker interface for all shape types
- `Circle/CircleF.cs` - 2D circle (X, Y, R), Pack=1
- `Circle/CircleI.cs` - Integer-radius circle variant
- `Line/LineF.cs` - 2D line with float endpoints
- `Line/LineI.cs` - Integer line variant
- `Point/PointF.cs` - 2D point with float coordinates, Copy() method
- `Point/PointI.cs` - Integer point variant
- `Rectangle/RectangleF.cs` - 2D rectangle (X, Y, W, H), Pack=1
- `Rectangle/RectangleI.cs` - Integer rectangle variant
- `Square/SquareF.cs` - 2D square (X, Y, Size)
- `Square/SquareI.cs` - Integer square variant

### Definitions (2 files)
- `Color.cs` - RGBA byte tuple (R, G, B, A), Pack=1, ISerializable
- `Depth.cs` - Depth value type for Z-buffer operations

### Utilities (3 files)
- `CustomMathF.cs` - Static math class with float constants (E, Pi, Tau), custom Sqrt() (Newton-Raphson iteration, 10 max iterations), Abs(), Min(), Max(), Sin(), Cos(), Tan(), Asin(), Acos(), Atan2(), Lerp(), Clamp(), SmoothStep(), Round(), Floor(), Ceil(), Truncate(), Pow(), Log(), Exp()
- `Constant.cs` - Math constants (Epsilon, Euler, Pi, PiOver2, PiOver4, Log10E, Log2E, Tau, etc.)
- `Quaternion.cs` - 4D quaternion (X, Y, W) with Pack=1, precomputed hashCode, immutable setters

### Collections (2 files)
- `FastImmutableArray.cs` - Read-only array with O(1) indexable lookup, Builder pattern (IList<T> + IReadOnlyList<T>), thread-safe by design (single `this` dereference rule documented), single reference-type field size contract
- `IFastImmutableArray.cs` - Non-generic marker interface

### Hash Code (1 file)
- `HashCode.cs` - Custom hash code struct with Knuth-style primes (2654435761U, 2246822519U, 3266489917U), `GenerateGlobalSeed()` via RNGCryptoServiceProvider, Add<T>() with pattern matching for value/reference types, ToHashCode()

### Util Helpers (1 file)
- `Helper.cs` - Utility methods for common math operations

## Dependencies

- **Internal**: None (leaf module)
- **External**: System.Security.Cryptography.RNGCryptoServiceProvider (HashCode)

## Architecture Notes

- **Pure value types**: All structs use `[StructLayout(LayoutKind.Sequential, Pack = 1)]` for cache-friendly memory layout
- **Precomputed hashCode**: Matrices and Quaternions compute hashCode in constructor and cache it - avoids recomputation on every access
- **Fuzzy equality**: Vector2F uses 0.01f tolerance for float comparison - essential for game engine collision detection
- **IShape marker**: Empty interface allows generic shape constraints (`where T : IShape`)
- **Integer/Float variants**: Every shape has both F and I versions for pixel-perfect vs. world-space operations
- **FastImmutableArray**: Follows ImmutableArray<T> contract with strict thread-safety rules documented in XML comments
- **Custom MathF**: Replaces System.Math with float-optimized versions to avoid double-to-float conversions

## Code Quality Issues

1. **HashCode uses RNGCryptoServiceProvider**: `GenerateGlobalSeed()` calls RNGCryptoServiceProvider on type initialization - blocking call, slow startup. Should use Random.Shared or a fast PRNG.
2. **Quaternion hashCode stale**: hashCode is computed from constructor parameters but X/Y/Z/W have private setters - if mutated after construction, hashCode becomes invalid.
3. **Matrix hashCode same issue**: Same mutable-state/stale-hash problem as Quaternion.
4. **No Vector3F/Vector4F hashCode**: Only Matrix and Quaternion precompute hashCodes - inconsistent API.
5. **IShape is empty**: Marker interface provides no common contract (no Bounds(), No Intersects(), no Area()).
6. **CustomMathF duplicates System.MathF**: Most methods (Sin, Cos, Tan, etc.) are already in System.MathF. Custom versions add no value unless optimized.
7. **No SIMD support**: Vectors and matrices could use Vector<T> intrinsics for batch operations.
8. **Quaternion missing static presets**: No Identity, Zero, or FromEuler() factory methods like Vector2F has.

## Next Refactoring Tasks

### Priority 1 - Critical
1. **Fix hashCode immutability**: Either make X/Y/Z/W truly immutable (no setters after construction) or remove precomputed hashCode and compute on-demand.
2. **Fix HashCode seed generation**: Replace RNGCryptoServiceProvider with Random.Shared or a non-blocking PRNG to avoid type initialization blocking.
3. **Add hashCode to Vector types**: Consistency - Vector2F/3F/4F should also precompute hashCodes.

### Priority 2 - Important
4. **Give IShape a real contract**: Add `bool Intersects(T other)`, `RectangleF Bounds()`, `float Area()`.
5. **Add Quaternion factory methods**: Identity, FromEuler(Vector3F), FromAxisAngle(Vector3F, float).
6. **Add integer variants for matrices**: Matrix2X2I, Matrix3X2I for pixel-space transforms.
7. **Add Intersects() to shapes**: CircleF.Intersects(CircleF), RectangleF.Intersects(RectangleF), etc.

### Priority 3 - Nice to have
8. **SIMD optimization**: Add System.Numerics.Vectors support for batch vector operations.
9. **CustomMathF deprecation audit**: Remove methods that are identical to System.MathF, keep only custom Sqrt().
10. **Add matrix inverse/transpose**: Matrix3X2, Matrix4X4 need Inverse() and Transpose() for game engine transforms.
11. **Add shape collision detection**: Circle-Circle, Rectangle-Rectangle, Circle-Rectangle intersection tests.

## Test Coverage

- Tests for vector operations (addition, subtraction, dot product, cross product, normalization)
- Tests for matrix multiplication and transform
- Tests for shape equality and bounds
- Tests for CustomMathF functions (Sqrt, Lerp, Clamp, etc.)
- Tests for FastImmutableArray thread safety
