---
title: Alis.Core.Physic
tags:
  - operation
  - physic
  - collision
  - dynamics
  - simulation
status: Draft
license: GPLv3
---

# Alis.Core.Physic

**Layer:** 4_Operation
**Path:** `4_Operation/Physic/src/Alis.Core.Physic.csproj`

## Purpose

2D physics simulation engine with collision detection, rigid body dynamics, joints, controllers, and decomposition utilities.

## Architecture

### Collision Detection
- `DynamicTree` / `DynamicTreeBroadPhase` — Broad-phase spatial partitioning
- `AABB` — Axis-aligned bounding boxes
- `Collision` / `Distance` / `TimeOfImpact` — Narrow-phase collision
- `Manifold` / `ManifoldPoint` — Contact manifold
- `Simplex` / `SimplexCache` — GJK algorithm support
- `IBroadPhase` — Broad-phase interface
- `RayCastInput` / `RayCastOutput` — Ray casting

### Collision Shapes
- `CircleShape`, `PolygonShape`, `EdgeShape`, `ChainShape`
- `Shape` / `ShapeType` — Shape base

### Dynamics
- `Body` / `BodyCollection` — Physics bodies
- `Fixture` / `FixtureCollection` — Shape attachment
- `WorldPhysic` — Physics world simulation
- `ContactManager` — Contact resolution
- `ContactSolver` — Constraint solving
- `Island` — Simulation island grouping
- `SolverData` / `SolverIterations` — Solver configuration

### Joints
- `RevoluteJoint`, `PrismaticJoint`, `DistanceJoint`
- `AngleJoint`, `WeldJoint`, `WheelJoint`
- `FrictionJoint`, `MotorJoint`, `RopeJoint`
- `PulleyJoint`, `GearJoint`, `FixedMouseJoint`

### Controllers
- `BuoyancyController`, `GravityController`, `VelocityLimitController`

### Decomposition
- `BayazitDecomposer`, `CDTDecomposer`, `EarclipDecomposer`
- `FlipcodeDecomposer`, `SeidelDecomposer`
- CDT (Constrained Delaunay Triangulation) implementation

### Utilities
- `Vertices` — Polygon vertex management
- `SimplifyTools` — Polygon simplification
- `CuttingTools` — Polygon cutting
- `RealExplosion` / `SimpleExplosion` — Explosion physics
- `MarchingSquares` / `Terrain` — Terrain generation
- `PolygonTools` — Polygon operations
- `LineTools` — Line geometry

### Math
- `Mat22`, `Mat33` — 2D/3D matrices
- `Sweep` — CCD sweep
- `FixedArray2/3/4/8` — Fixed-size arrays

## Dependencies

- Alis.Core.Aspect (5_Declaration)

## Testing

**Path:** `4_Operation/Physic/test/`

~225+ test files — the most extensive test suite. Covers:
- All collision types and algorithms
- Every joint type
- Body dynamics and fixtures
- Decomposition algorithms (all 5)
- Controllers
- All utility classes
- Edge case and coverage tests

## Complexity

This is the most complex module in the repository, implementing a full 2D physics engine with:
- Continuous collision detection (CCD)
- Multiple constraint solver types
- Delaunay triangulation
- Convex decomposition
- Terrain generation

## Related Documents

- [[Alis.Core.Ecs]]
- [[Alis.Core.Aspect.Math]]
- [[testing-overview]]
- [[Alis.Core.Graphic]]
