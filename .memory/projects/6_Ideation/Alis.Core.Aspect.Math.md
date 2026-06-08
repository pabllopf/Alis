# Alis.Core.Aspect.Math

## Overview
Mathematical library for ALIS game engine. Provides vector math, quaternions, shapes, and utility functions.

**Author**: Pablo Perdomo Falcón  
**License**: GNU General Public License v3.0

## Project Details
- **Layer**: 6_Ideation
- **Type**: Library (Math Aspect)
- **Framework**: net8.0
- **Output Type**: Class Library

## Purpose
Provides comprehensive mathematical utilities for game development including:
- 2D/3D vector operations (Vector2F, Vector3F, Vector4F)
- Quaternion mathematics for 3D rotations
- Shape primitives (Point, Square, Rectangle, Circle)
- Utility functions (Random, Constants, Helper)

## Key Components

### Vector Types
- **Vector2F** - 2D float vector
- **Vector3F** - 3D float vector  
- **Vector4F** - 4D float vector (RGBA, quaternion components)

### Quaternion
- 3D rotation representation
- Arithmetic operators (add, sub, mul, div)
- StructLayout for performance

### Shapes
- **IShape** - Shape interface
- **PointI/PointF** - Point implementations
- **SquareI/SquareF** - Square implementations
- **RectangleI/RectangleF** - Rectangle implementations

### Utilities
- **Quaternion** - 3D rotation math
- **RandomUtils** - Cryptographically secure random generation
- **Constant** - Mathematical constants
- **Helper** - Extension methods and helpers

## Dependencies
- None (standalone library)

## Build Configuration
- **LangVersion**: 13
- **Nullable**: enabled
- **AllowUnsafeBlocks**: true (performance-critical math)

## Performance Features
1. Struct-based types for value semantics
2. LayoutKind.Sequential for P/Invoke compatibility
3. Pack=1 for tight memory layout
4. Minimal allocations in hot paths

## Testing Status
- **Unit Tests**: Present (Alis.Core.Aspect.Math.Test)
- **Sample Apps**: Included (Alis.Core.Aspect.Math.Sample)

## Architecture Notes
1. Pure math library - no engine dependencies
2. Struct-based for performance
3. Implicit conversions where appropriate
4. Extension methods for convenience

## Related Projects
- [[Alis.Core.Ecs]] (4_Operation) - Uses Vector2F
- [[Alis.Extension.Graphic.*]] (1_Presentation) - Uses math types

## Documentation Version
Auto-generated from source code analysis. Last updated: 2026-06-08
