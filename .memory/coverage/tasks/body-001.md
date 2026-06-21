---
status: Completed
---

# COVERAGE TASK

## File
4_Operation/Physic/src/Dynamics/Body.cs

## Coverage (SonarCloud)
65.3% (target: improve coverage of uncovered lines)

## Uncovered Lines
188 lines - includes property setters (LinearVelocity, AngularVelocity, SleepingAllowed, Awake, Enabled, FixedRotation, Position, Rotation, LocalCenter, Mass, Inertia), methods (CreateProxies, DestroyProxies, DestroyContacts, Add, Remove, SetTransformIgnoreContacts, ApplyForce, ApplyLinearImpulse, ApplyAngularImpulse, ResetMassData), transform conversions (GetWorldPoint, GetWorldVector, GetLocalPoint, GetLocalVector, GetLinearVelocityFromWorldPoint, GetLinearVelocityFromLocalPoint), fixture management (SetRestitution, SetFriction, SetCollisionCategories, SetCollidesWith, SetCollisionGroup), ShouldCollide, Clone, GetTransform

## Method
Various property setters and methods with world-locked paths, static-body early returns, and mass data calculations

## Existing Tests
23 existing tests in BodyTest.cs (constructor, ApplyLinearImpulse, ApplyForce, SetBodyType, SetTransform, CreateCircle, DeepClone, WorldAndLocalPointConversions, SetIsSensor, CreateRectangle, ResetDynamics, SetFixedRotation, SetSleepingAllowed, SetBullet, SetIgnoreGravity, SetLinearDamping, SetAngularDamping, AddFixture, RemoveFixture, ApplyTorque, ApplyAngularImpulse, ResetMassData, Mass_ShouldReflectFixtureDensity)

## Tests Added
69 new tests added covering:
- LinearVelocity/AngularVelocity static body early returns and wake-on-positive-value paths
- SleepingAllowed setter with false value (wake body)
- Awake setter with false value (ResetDynamics path)
- Position/Rotation getter/setter without world (Xf.Position, Sweep.A paths)
- FixedRotation getter and setter (same-value early return, mass reset)
- Mass setter with negative value (clamp to 1.0f), non-dynamic body early return
- Inertia setter on non-dynamic body, invalid value path
- Clone method (copies all properties)
- GetTransform/GetTransform(out)
- SetRestitution/SetFriction/SetCollisionCategories/SetCollidesWith/SetCollisionGroup (apply to all fixtures)
- ShouldCollide (both static = false, both dynamic = true)
- GetWorldVector/GetLocalVector (rotation-only transformations)
- GetLinearVelocityFromWorldPoint (includes rotational component)
- ApplyLinearImpulse with point (angular velocity path), static body early return
- ApplyAngularImpulse on static body early return
- ApplyTorque on static body early return
- GetRevolutions calculation
- WorldCenter property
- GetWorldPoint/GetLocalPoint (transform multiplication/division)
- SetBodyType to Static (clear velocities, wake, reset force/torque)
- Enabled setter (create/destroy proxies with world, same-value early return)
- Add fixture null check
- Remove fixture not belonging to body
- ApplyForce with ref parameters (force accumulation)
- ResetMassData with zero total mass, kinematic body, static body

## Status
Committed — 38cb45fc1
