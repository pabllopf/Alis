# Alis.Core.Physic

## Overview

The **Alis.Core.Physic** project provides a comprehensive 2D physics engine for the ALIS game engine. It implements a full physics simulation system including rigid body dynamics, collision detection, constraints, and controllers.

## Purpose

- Simulate 2D physics for game objects
- Handle collision detection and resolution
- Support rigid body dynamics
- Implement constraint solving
- Provide broadphase collision detection
- Support continuous collision detection (CCD)

## Architecture

### Core Components

| Component | Description | Files |
|-----------|-------------|-------|
| **Dynamics** | Rigid body simulation | Dynamics/*.cs (~100 files) |
| **Collisions** | Collision detection | Collisions/*.cs (~50 files) |
| **Controllers** | Physics controllers | Controllers/*.cs (5 files) |
| **Common** | Shared utilities | Common/*.cs (~40 files) |

### Dynamics System

The dynamics system handles rigid body simulation:

- **Body** - Main rigid body class
- **BodyCollection** - Collection of bodies
- **Fixture** - Collision shapes attached to bodies
- **ContactManager** - Manages body contacts

### Collision Detection

Collision system implements:

- **AABB** (Axis-Aligned Bounding Box) queries
- **Dynamic Tree** broadphase algorithm
- **GJK** (Gilbert-Johnson-Keerthi) distance algorithm
- **EPA** (Expanding Polytope Algorithm) for collision resolution
- **Ray casting** for queries

### Controllers

Physics controllers that affect bodies:

| Controller | Description |
|------------|-------------|
| `GravityController` | Apply gravity to bodies |
| `BuoyancyController` | Simulate fluid buoyancy |
| `VelocityLimitController` | Limit body velocities |

## Configuration

See [SettingEnv.cs](SettingEnv.cs) for physics engine settings:

```csharp
public static class SettingEnv
{
    // Collision tolerance
    public const float LinearSlop = 0.005f;
    public const float AngularSlop = 2.0f / 180.0f * Constant.Pi;
    public const float PolygonRadius = 2.0f * LinearSlop;
    
    // Solver settings
    public static readonly int VelocityIterations = 8;
    public static readonly int PositionIterations = 3;
    
    // Sleep settings
    public const float TimeToSleep = 0.5f;
    public const float LinearSleepTolerance = 0.01f;
    
    // CCD (Continuous Collision Detection)
    public static readonly bool ContinuousPhysics = true;
    public const int MaxSubSteps = 8;
}
```

## Public API

### Body Class

Main entry point for physics objects:

```csharp
public class Body
{
    // Properties
    public Vector2 Position { get; set; }
    public float Angle { get; set; }
    public Vector2 Velocity { get; set; }
    public float AngularVelocity { get; set; }
    public float Mass { get; }
    public float Inertia { get; }
    
    // Methods
    public void ApplyForce(Vector2 force);
    public void ApplyTorque(float torque);
    public void SetLinearVelocity(Vector2 velocity);
    public void SetAngularVelocity(float velocity);
    public void Sleep();
    public void WakeUp();
}
```

### World Class

Physics world management:

```csharp
public class World
{
    BodyCollection Bodies { get; }
    
    void Step(float deltaTime);
    void DestroyBody(Body body);
    Body CreateBody(BodyType type);
}
```

### Collision System

```csharp
public static class Collision
{
    static bool TestCircleCircle(float radius1, Vector2 center1, float radius2, Vector2 center2);
    static bool TestPolygonCircle(Polygon polygon, Circle circle);
    // ... more collision tests
}
```

## Files

| Directory | Files | Description |
|-----------|-------|-------------|
| Dynamics/ | ~100 | Rigid body simulation |
| Collisions/ | ~50 | Collision detection algorithms |
| Controllers/ | 5 | Physics controllers |
| Common/ | ~40 | Shared utilities and constants |
| SettingEnv.cs | 1 | Configuration settings |

## Dependencies

- **Alis.Core** - Core engine functionality
- **Alis.Core.Ecs** - Entity integration (optional)

## Quality Plan

See [QualityPlan.md](QualityPlan.md) for performance and accuracy goals.

## Usage Example

```csharp
using Alis.Core.Physic;

// Create physics world
var world = new World();

// Create a body
var body = world.CreateBody(BodyType.Dynamic);
body.Position = new Vector2(0, 10);

// Add a fixture (collision shape)
var shape = new PolygonShape();
shape.SetAsBox(5, 5);
body.AddFixture(shape);

// Step the physics world
for (int i = 0; i < 60; i++)
{
    world.Step(1f / 60);
}
```

## Features

- ✅ Rigid body dynamics
- ✅ Collision detection (AABB, ray cast)
- ✅ Constraint solving
- ✅ Continuous Collision Detection (CCD)
- ✅ Sleep/wake management
- ✅ Friction and restitution
- ✅ Gravity and forces
- ✅ Controllers (gravity, buoyancy, velocity limit)
- ✅ Broadphase optimization (Dynamic Tree)

## Performance Considerations

- **Velocity/Position Iterations**: Default 8/3 iterations
- **Sleep Thresholds**: Configurable for performance vs accuracy
- **Broadphase**: Dynamic Tree for efficient queries
- **Sub-stepping**: Up to 8 sub-steps per contact

## TODOs

- [ ] Add soft body support
- [ ] Implement particle systems
- [ ] Add vehicle physics
- [ ] Optimize for mobile platforms
- [ ] Add physics debugging visualizer

## Related Projects

- [[Alis.Core.Ecs]] - Physics system integration
- [[Alis.Core.Graphic]] - Visual representation of physics
- [[Alis.Core]] - Core engine
