# Test File: BodyTest

## Location
4_Operation/Physic/test/Dynamics/BodyTest.cs

## Framework
xUnit (no Moq needed)

## Test Count
92 tests total (23 original + 69 new)

## Test Categories
- **Constructor defaults**: 1 test
- **LinearVelocity/AngularVelocity**: 6 tests (static body returns, positive value wakes, ref setters)
- **SleepingAllowed/Awake**: 3 tests (false wakes body, false resets dynamics)
- **Position/Rotation**: 4 tests (getter without world, setter without world, rotation getter/setter)
- **FixedRotation**: 3 tests (getter, setter resets angular velocity, same-value early return)
- **Mass/Inertia**: 6 tests (negative mass clamp, non-dynamic return, invalid inertia, density reflection)
- **Clone/DeepClone**: 2 tests (clone copies properties, deep clone copies fixtures)
- **Transform**: 4 tests (GetTransform, GetTransform out, GetWorldPoint, GetLocalPoint)
- **Fixture management**: 8 tests (SetRestitution, SetFriction, SetCollisionCategories, SetCollidesWith, SetCollisionGroup, Add null, Remove foreign, CreateRectangle)
- **ShouldCollide**: 2 tests (both static = false, both dynamic = true)
- **Vector conversions**: 4 tests (GetWorldVector, GetLocalVector, GetLinearVelocityFromWorldPoint, GetLinearVelocityFromLocalPoint)
- **Forces/Impulses**: 8 tests (ApplyForce ref, ApplyLinearImpulse with point, ApplyAngularImpulse static, ApplyTorque static, static body returns)
- **Mass data**: 5 tests (ResetMassData zero mass, kinematic, static, fixture density)
- **Body type**: 2 tests (to static clears velocities, existing test)
- **Enabled**: 3 tests (create/destroy proxies, same-value early return)
- **Various getters**: 4 tests (Revolutions, WorldCenter, FixedRotation getter, etc.)
- **Existing tests preserved**: 23 original tests

## Pattern Notes
- Uses WorldPhysic + CreateBody/CreateCircle for most tests
- Uses standalone Body() for unit-testing property setters without world
- Tests verify both positive paths and early-return guards
- No Moq used - real WorldPhysic instances
- Tests cover static/kinematic/dynamic body type behaviors
