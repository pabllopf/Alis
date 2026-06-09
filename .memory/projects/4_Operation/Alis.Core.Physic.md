---
title: Alis.Core.Physic
tags:
  - operation
  - runtime
  - implementation
  - documentation

status: draft

license: GPLv3
---


## Overview
2D physics simulation library for ALIS game engine. Provides rigid body dynamics, collision detection, constraints, and physics world management.

**Author**: Pablo Perdomo Falcón  
**License**: GNU General Public License v3.0  
**Total Source Files**: 408 C# files

## Project Details

| Property | Value |
|---|---|
| **Layer** | 4_Operation |
| **Type** | Library (Physics Engine) |
| **Framework** | net8.0 (multi-targeted) |
| **Output Type** | Class Library |
| **Namespace** | Alis.Core.Physic |

## Purpose
Implements a complete 2D physics simulation system for game development. Provides rigid body dynamics, collision detection, constraints/joints, and physics world management with continuous collision detection (CCD).

## Architecture

### Core Components

#### WorldPhysic Class
Main physics world container.

**Features:**
- Physics simulation loop
- Body management (add/remove)
- Collision detection
- Constraint solving
- Sleep management
- Continuous Collision Detection (CCD)

**Implementation Details:**
```csharp
public class WorldPhysic : IDisposable
{
    // Body management
    void AddBody(Body body);
    void RemoveBody(Body body);
    IEnumerable<Body> GetBodyList();
    
    // Simulation
    void Step(float timeStep);
    void WarmStart();
    
    // Collision
    void SetContactListener(IContactListener listener);
    
    // Cleanup
    void Dispose();
}
```

**World Properties:**
- Gravity: Vector2F gravity
- AllowSleep: Enable/disable body sleeping
- AutoClearForces: Clear forces after each step
- IsLocked: World is stepping (read-only)

#### Body Class (69KB)
Rigid body simulation.

**Features:**
- Linear and angular dynamics
- Mass and inertia calculation
- Sleep management
- Collision filtering
- Fixture management

**Body Types:**
- **Static**: Immovable, no mass
- **Dynamic**: Full physics simulation
- **Kinematic**: Position-controlled, no forces

**Properties:**
- `LinearVelocity` - Center of mass velocity
- `AngularVelocity` - Rotation speed (radians/sec)
- `Position` - Body position
- `Rotation` - Body rotation (Complex)
- `Mass` - Body mass
- `Inertia` - Moment of inertia
- `LinearDamping` - Linear velocity damping
- `AngularDamping` - Angular velocity damping
- `Awake` - Sleep state
- `Enabled` - Active state

**Body Methods:**
- `ApplyForce(Vector2F force, Vector2F point)` - Apply force at point
- `ApplyForceToCenter(Vector2F force)` - Apply force to center
- `ApplyTorque(float torque)` - Apply rotational force
- `ApplyLinearImpulse(Vector2F impulse, Vector2F point)` - Instant velocity change
- `ApplyAngularImpulse(float impulse)` - Instant rotation change
- `ResetMassData()` - Recalculate mass/inertia
- `SynchronizeFixtures()` - Update collision proxies

#### Fixture Class (14KB)
Collision shape container.

**Features:**
- Shape management
- Material properties (friction, restitution)
- Collision filtering
- Density and mass contribution

**Properties:**
- `Shape` - Collision shape
- `Friction` - Friction coefficient (0-1)
- `Restitution` - Bounciness (0-1)
- `Density` - Mass density
- `IsSensor` - Sensor mode (no collision response)
- `Category` - Collision category
- `Mask` - Collision mask

#### ContactManager Class (24KB)
Collision detection and contact management.

**Features:**
- Broadphase collision detection
- Narrowphase collision detection
- Contact creation and destruction
- Contact persistence

**Broadphase:**
- Dynamic tree (AABB tree)
- AABB extension for proxy movement
- AABB multiplier for prediction

**Narrowphase:**
- GJK algorithm (Gilbert-Johnson-Keerthi)
- EPA algorithm (Expanding Polytope Algorithm)
- Separation axis theorem

#### Contact System
Contact points and manifolds.

**Components:**
- `Contact` - Contact point management
- `Manifold` - Contact manifold data
- `ManifoldPoint` - Individual contact point
- `ContactEdge` - Body contact links

**Contact Events:**
- `BeforeCollisionEventHandler` - Before collision
- `AfterCollisionEventHandler` - After collision
- `OnCollisionEventHandler` - Collision event
- `OnSeparationEventHandler` - Separation event

### Collision System

#### Shapes (9 subdirectories)
Collision shape types:

| Shape | Description |
|---|---|
| **CircleShape** | Circular collision shape |
| **EdgeShape** | Line segment shape |
| **PolygonShape** | Convex polygon shape |
| **ChainShape** | Connected edge sequence |
| **BoxShape** | Rectangle shape |
| **CompoundShape** | Multiple shapes combined |

**Shape Features:**
- GJK distance computation
- Collision detection
- Mass data calculation
- Shape cloning

#### DynamicTree (35KB)
AABB tree for broadphase collision.

**Features:**
- Spatial partitioning
- AABB queries
- Ray casting
- Tree balancing

**Operations:**
- `InsertNode` - Add shape to tree
- `RemoveNode` - Remove shape from tree
- `MoveNode` - Update shape position
- `QueryAABB` - Query AABB region
- `RayCast` - Ray casting query

#### GJK Algorithm
Gilbert-Johnson-Keerthi distance algorithm.

**Features:**
- Distance computation between convex shapes
- Simplex construction
- Closest point finding
- Collision detection

#### EPA Algorithm
Expanding Polytope Algorithm.

**Features:**
- Penetration depth calculation
- Contact normal finding
- GJK extension
- Collision resolution

### Dynamics System

#### Island Class (22KB)
Island optimization for solver.

**Features:**
- Body grouping
- Solver warm starting
- Island creation
- Island clearing

**Island Management:**
- Bodies grouped by connectivity
- Solver iterates on island
- Improves convergence
- Reduces computation

#### Solver Classes
Constraint solver components:

| Class | Purpose |
|---|---|
| `SolverData` - Solver configuration |
| `SolverIterations` - Iteration counts |
| `SolverPosition` - Position correction |
| `SolverVelocity` - Velocity correction |

**Solver Process:**
1. Velocity solver (8 iterations)
2. Position solver (3 iterations)
3. TOI solver (20 iterations)
4. Warm starting from previous step

#### Joints (19 subdirectories)
Constraint types:

| Joint | Description |
|---|---|
| **DistanceJoint** - Fixed distance between points |
| **FrictionJoint** - Friction constraint |
| **GearJoint** - Ratio between two bodies |
| **MouseJoint** - Point-to-point constraint |
| **PrismaticJoint** - Sliding joint |
| **PulleyJoint** - Pulley system |
| **RevoluteJoint** - Rotational joint |
| **RopeJoint** - Limiting rope |
| **WeldJoint** - Rigid connection |
| **WheelJoint** - Spring suspension |

**Joint Features:**
- Stiffness control
- Damping control
- Frequency control
- Limit enforcement

### Controllers

#### ControllerCollection (9KB)
Physics controller management.

**Features:**
- Custom physics modifiers
- Ground friction
- Gravity scaling
- Body movement control

**Controller Types:**
- `ControllerTransform` - Transform controller
- Custom controllers via interface

### Settings (10KB)

#### SettingEnv Class
Physics engine configuration.

**Common Settings:**
- `MaxFloat` - Maximum float value
- `Epsilon` - Collision tolerance
- `MaxSubSteps` - Max sub-steps per contact (8)
- `MaxManifoldPoints` - Max contact points (2)
- `AabbExtension` - AABB extension (0.1m)
- `AabbMultiplier` - AABB multiplier (2.0)
- `LinearSlop` - Linear tolerance (0.005m)
- `AngularSlop` - Angular tolerance (2°)
- `PolygonRadius` - Polygon skin radius

**Dynamics Settings:**
- `MaxToiContacts` - Max TOI contacts (32)
- `VelocityThreshold` - Inelastic threshold (1.0m/s)
- `MaxLinearCorrection` - Max linear correction (0.2m)
- `MaxAngularCorrection` - Max angular correction (8°)
- `Baumgarte` - Overlap correction (0.2)
- `TimeToSleep` - Sleep time (0.5s)
- `LinearSleepTolerance` - Linear sleep tolerance (0.01m/s)
- `AngularSleepTolerance` - Angular sleep tolerance (2°)

**Solver Settings:**
- `VelocityIterations` - Velocity iterations (8)
- `PositionIterations` - Position iterations (3)
- `ContinuousPhysics` - CCD enabled
- `AllowSleep` - Sleep enabled
- `MaxPolygonVertices` - Max polygon vertices (8)

**Utility Functions:**
- `MixFriction(float f1, float f2)` - Geometric mean
- `MixRestitution(float r1, float r2)` - Maximum

## Key Components

### WorldPhysic.cs (69KB)
Main physics world.

### Body.cs (50KB) + Body.Factory.cs (9KB)
Rigid body simulation.

### Collision.cs (62KB)
Collision detection system.

### DynamicTree.cs (35KB)
AABB tree for broadphase.

### Island.cs (22KB)
Island optimization.

### ContactManager.cs (24KB)
Contact management.

### Fixture.cs (14KB)
Collision shape container.

### Shape Files (100+ files)
Collision shape implementations.

### Joint Files (50+ files)
Constraint/joint implementations.

### Common Settings (10KB)
Engine configuration.

## Dependencies

### Internal
- [[Alis.Core.Aspect.Math.Vector]] - Vector operations
- [[Alis.Core.Aspect.Math.Matrix]] - Matrix operations
- [[Alis.Core.Aspect.Math.Complex]] - Complex numbers

### External
- None (pure .NET)

## Build Configuration

| Property | Value |
|---|---|
| **LangVersion** | 13 |
| **Nullable** | enabled |
| **AllowUnsafeBlocks** | true |
| **Target Frameworks** | 15+ (netstandard2.0–net10.0, net461–net481) |

## Physics Simulation

### Time Stepping
- Fixed time step simulation
- Sub-stepping for stability
- Continuous Collision Detection (CCD)
- TOI (Time of Impact) solving

### Collision Detection
1. **Broadphase**: AABB tree filtering
2. **Narrowphase**: GJK/EPA algorithms
3. **Contact Generation**: Manifold creation
4. **Constraint Solving**: Impulse resolution

### Sleep System
- Body sleeps when velocity below tolerance
- Wakes on force/impulse application
- Reduces CPU cost for static objects

## Public APIs

### WorldPhysic Class
```csharp
public class WorldPhysic : IDisposable
{
    Vector2F Gravity { get; set; }
    bool AllowSleep { get; set; }
    bool AutoClearForces { get; }
    bool IsLocked { get; }
    
    void AddBody(Body body);
    void RemoveBody(Body body);
    void Step(float timeStep);
    void SetContactListener(IContactListener listener);
    void Dispose();
}
```

### Body Class
```csharp
public partial class Body
{
    Vector2F LinearVelocity { get; set; }
    float AngularVelocity { get; set; }
    Vector2F Position { get; }
    Complex Rotation { get; }
    float Mass { get; }
    float Inertia { get; }
    
    void ApplyForce(Vector2F force, Vector2F point);
    void ApplyTorque(float torque);
    void ApplyLinearImpulse(Vector2F impulse, Vector2F point);
    void ApplyAngularImpulse(float impulse);
}
```

### Fixture Class
```csharp
public class Fixture
{
    Shape Shape { get; }
    float Friction { get; set; }
    float Restitution { get; set; }
    float Density { get; set; }
    bool IsSensor { get; set; }
    
    void SetShape(Shape shape);
}
```

## Namespaces

| Namespace | Purpose |
|---|---|
| `Alis.Core.Physic` | Core physics types |
| `Alis.Core.Physic.Common` - Settings and utilities |
| `Alis.Core.Physic.Collisions` - Collision detection |
| `Alis.Core.Physic.Collisions.Shapes` - Shape types |
| `Alis.Core.Physic.Dynamics` - Body and world |
| `Alis.Core.Physic.Dynamics.Contacts` - Contact system |
| `Alis.Core.Physic.Dynamics.Joints` - Constraint joints |
| `Alis.Core.Physic.Controllers` - Physics controllers |

## Physics Pipeline

1. **World Creation**
   - Set gravity
   - Configure settings
   - Create bodies

2. **Body Setup**
   - Add fixtures
   - Set mass properties
   - Configure collision filtering

3. **Simulation Loop**
   - Clear forces
   - Step physics world
   - Update body positions

4. **Collision Handling**
   - Broadphase filtering
   - Narrowphase detection
   - Contact generation
   - Constraint solving

5. **Cleanup**
   - Remove bodies
   - Dispose world

## Configuration Usage

**Basic Usage:**
```csharp
var world = new WorldPhysic(new Vector2F(0, -9.81f));

var body = world.AddBody();
body.Position = new Vector2F(0, 10);

for (int i = 0; i < 60; i++)
{
    world.Step(1f / 60f);
}
```

**Collision Handling:**
```csharp
world.SetContactListener(new MyContactListener());

class MyContactListener : IContactListener
{
    public void BeginContact(Contact contact) { /* handle */ }
    public void EndContact(Contact contact) { /* handle */ }
}
```

## EF Core Usage

**None** - Pure physics library, no ORM usage.

## Testing Status

| Test Type | Status |
|---|---|
| **Unit Tests** | Limited - needs expansion |
| **Integration Tests** - Physics simulation tests |
| **Performance Tests** - Collision detection benchmarks |
| **Coverage** | Medium - core paths covered |

## Security-Sensitive Areas

1. **Unsafe Code**
   - `AllowUnsafeBlocks: true` for performance
   - Direct memory access
   - Vector operations

2. **Memory Management**
   - Body/fixture allocation
   - Contact pool management
   - Tree node management

3. **Numerical Stability**
   - Floating-point precision
   - Division by zero
   - Overflow protection

## Performance-Sensitive Areas

1. **Collision Detection**
   - GJK/EPA algorithms
   - Dynamic tree queries
   - Contact generation

2. **Constraint Solving**
   - Iterative solver
   - Warm starting
   - Island optimization

3. **Broadphase**
   - AABB tree operations
   - Spatial queries
   - Ray casting

4. **Time Stepping**
   - TOI solving
   - Sub-stepping
   - Sleep management

## Risks

1. **Numerical Instability**
   - Floating-point errors
   - Division by zero
   - Overflow/underflow

2. **Memory Leaks**
   - Bodies not removed
   - Contacts not cleared
   - Trees not disposed

3. **Performance Issues**
   - Too many bodies
   - Deep contact chains
   - Insufficient iterations

4. **Sleep System**
   - Bodies not sleeping
   - Waking issues
   - Sleep tolerance tuning

5. **CCD Issues**
   - Tunneling
   - TOI errors
   - Sub-step limits

## TODOs

- [ ] Expand unit test coverage
- [ ] Add 3D physics support
- [ ] Add soft body physics
- [ ] Add particle systems
- [ ] Profile collision performance
- [ ] Add physics visualization tools
- [ ] Document simulation benchmarks

## Complexity Observations

- **High**: Collision detection algorithms
- **High**: Constraint solving
- **High**: Continuous Collision Detection
- **Medium**: Body dynamics
- **Medium**: Contact management
- **Low**: Basic simulation

## Related

- [[4_Operation/Alis.Core.Ecs]] - ECS engine
- [[4_Operation/Alis.Core.Graphic]] - Graphics rendering
- [[4_Operation/Alis.Core.Audio]] - Audio system
- [[6_Ideation/Alis.Core.Game]] - Game logic

## See Also

- [[projects/4_Operation/Core]] - Core operations
- [[architecture/repository-overview]] - Repository architecture
- [[glossary/physics]] - Physics definition
- [[glossary/rigidbody]] - Rigid body definition
- [[glossary/collision]] - Collision definition
