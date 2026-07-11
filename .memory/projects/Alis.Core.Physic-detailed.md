---
title: Alis.Core.Physic - Detailed Analysis
tags:
  - project
  - physic
  - detailed
  - collision
  - dynamics
  - layer-4
status: Draft
license: GPLv3
---

# Alis.Core.Physic - Detailed Source Analysis

## Overview

The Physics project contains **~125 source files** implementing a Box2D-derived 2D physics engine with collision detection, rigid body dynamics, and constraint solving.

## Architecture

```mermaid
graph TD
    subgraph "World"
        WorldPhysic[WorldPhysic - 1982 lines] --> Body[Body]
        WorldPhysic --> ContactManager[ContactManager]
        WorldPhysic --> Island[Island Solver]
    end
    
    subgraph "Body"
        Body --> Fixture[Fixture]
        Body --> Shape[Shape]
        Fixture --> Shape
    end
    
    subgraph "Collision"
        DynamicTree[DynamicTree - Broadphase] --> AABB[AABB]
        DynamicTree --> Collision[Collision Detection - 1554 lines]
        Collision --> Contact[Contact - 660 lines]
        Contact --> ContactSolver[ContactSolver]
    end
    
    subgraph "Dynamics"
        Island --> Joint[Joint System - 11 types]
        Joint --> Solver[Solver]
        Controller[Controller System] --> WorldPhysic
    end
```

## Key Types

### WorldPhysic (1982 lines)
- Core physics simulation world
- Manages bodies, contacts, joints, and controllers
- Steps simulation forward in time
- Collision event callbacks

### Body (1422 lines)
- Rigid body with position, rotation, velocity
- Three types: `Static`, `Kinematic`, `Dynamic`
- Connected to fixtures for collision shape
- Mass properties calculation

### Collision System

| Type | Lines | Description |
|---|---|---|
| `Collision` | 1554 lines | Core collision detection algorithms |
| `DynamicTree<TNode>` | 1035 lines | Spatial partitioning (AABB tree) |
| `AABB` | 431 lines | Axis-aligned bounding box |
| `Contact` | 660 lines | Contact point management |
| `ContactManager` | 724 lines | Contact lifecycle management |
| `ContactSolver` | - | Contact constraint resolution |

### Shape Types

| Shape | Description |
|---|---|
| `CircleShape` | Circle collision shape |
| `PolygonShape` | Convex polygon |
| `EdgeShape` | Edge/line segment |
| `ChainShape` | Chain of edges |

### Joint System (11 types)

| Joint | Description |
|---|---|
| `DistanceJoint` | Fixed distance constraint |
| `RevoluteJoint` | Hinge/pin joint |
| `PrismaticJoint` | Sliding joint |
| `PulleyJoint` | Pulley mechanism |
| `GearJoint` | Gear ratio coupling |
| `WheelJoint` | Wheel suspension |
| `WeldJoint` | Fixed weld |
| `FrictionJoint` | Friction simulation |
| `RopeJoint` | Rope length constraint |
| `MotorJoint` | Motor-driven joint |
| `AngleJoint` | Angle constraint |

### Controller System

| Controller | Lines | Description |
|---|---|---|
| `GravityController` | 306 lines | Gravitational force simulation |
| `BuoyancyController` | 260 lines | Fluid buoyancy simulation |
| `VelocityLimitController` | - | Maximum velocity clamping |

### Geometry Utilities

| Utility | Description |
|---|---|
| `Vertices` (703 lines) | Polygon vertex manipulation |
| `Path` (484 lines) | Catmull-Rom spline paths |
| `PolygonTools` | Polygon generation utilities |
| Decomposition | CDT, Earclip, Bayazit, Seidel triangulation |
| Convex Hull | ChainHull, GiftWrap, Melkman algorithms |
| Texture Tools | Terrain, MarchingSquares |

## Related

- [[Alis.Core.Physic]]
- [[Math Domain]]
- [[ECS Domain]]
- [[Performance Overview]]
- [[Projects Index]]
