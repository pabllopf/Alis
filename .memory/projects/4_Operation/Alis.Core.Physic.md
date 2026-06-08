# Physic Project Documentation

## Alis.Core.Physic - Physics Engine

### Purpose
High-performance 2D physics engine providing rigid body dynamics, collision detection, broadphase algorithms, and physics controllers. Implements continuous collision detection (CCD), contact manifolds, and dynamic tree broadphase optimization.

### Dependencies
- **Alis.Core**: Base abstractions
- **Alis.Core.Aspect.Memory**: Memory aspects for data structures
- **System.Memory**: Span<T> and Memory<T> for performance
- **System.Runtime.CompilerServices.Unsafe**: Low-level memory operations

### Key Components

#### Collision System
- **Collision**: Core collision detection algorithms (GJK, EPA, SAT)
- **BroadPhase**: Dynamic tree broadphase optimization
- **Manifold**: Contact manifold generation and management
- **Distance**: GJK distance algorithm for closest points
- **AABB**: Axis-aligned bounding box operations

#### Dynamics System
- **Body**: Rigid body with mass, inertia, velocity, and position
- **BodyType**: Static, Dynamic, and Kinematic body types
- **Fixture**: Collision shapes (polygon, edge, circle, chain)
- **ContactManager**: Contact generation and persistence
- **Complex**: Complex number operations for rotation

#### Controllers
- **GravityController**: Gravity simulation with multiple gravity types
- **BuoyancyController**: Fluid buoyancy simulation
- **VelocityLimitController**: Velocity clamping and limits

#### Common Utilities
- **SettingEnv**: Physics engine configuration constants
  - LinearSlop: Collision tolerance (0.005f)
  - AngularSlop: Angular collision tolerance
  - MaxSubSteps: Maximum sub-steps per contact (8)
  - MaxManifoldPoints: Maximum contact points (2)
- **Constant**: Mathematical constants (Pi, Tau)
- **FileBuffer**: Buffered file reader for parsing

### Data Access
- Direct memory access via Span<T> and Memory<T>
- Custom memory pooling for performance
- Unsafe code for low-level operations

### Messaging Usage
- **Event System**: AfterCollisionEventHandler, BeforeCollisionEventHandler
- **Delegate-based callbacks**: BeginContactDelegate, EndContactDelegate
- **Controller events**: Physics state change notifications

### Testing Status
- **Unit Tests**: Partial - needs expansion
- **Integration Tests**: Sample programs demonstrate usage
- **Coverage**: Needs improvement in edge cases and error handling

### Risks
1. **Numerical Stability**: Float precision issues in collision detection
2. **Performance**: Complex collision algorithms may impact frame rate
3. **Thread Safety**: Physics simulation may have race conditions in multi-threaded scenarios
4. **Memory Management**: Heavy use of unsafe code requires careful review

### TODOs
- [ ] Expand test coverage to 80%+
- [ ] Add multi-threaded testing
- [ ] Optimize collision detection for large scenes
- [ ] Add support for more collision shapes
- [ ] Create comprehensive sample applications

### Complexity Observations
- **High**: Physics engine with custom collision algorithms
- **Performance-Critical**: Real-time simulation requires constant optimization
- **Complexity**: Multiple broadphase algorithms and contact management

### Quality Plan
See [[4_Operation/Physic/QualityPlan]] for improvement goals and tracking.
