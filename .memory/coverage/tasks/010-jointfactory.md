# COVERAGE TASK

## File
`4_Operation/Physic/src/Dynamics/Joints/JointFactory.cs`

## Coverage
33.3% | 46 uncovered lines | 0 uncovered conditions

## Methods to Cover
- `CreateMotorJoint(WorldPhysic, Body, Body, bool)`
- `CreateRevoluteJoint(WorldPhysic, Body, Body, Vector2F, Vector2F, bool)`
- `CreateRopeJoint(WorldPhysic, Body, Body, Vector2F, Vector2F, bool)`
- `CreateWeldJoint(WorldPhysic, Body, Body, Vector2F, Vector2F, bool)`
- `CreatePrismaticJoint(WorldPhysic, Body, Body, Vector2F, Vector2F, bool)`
- `CreateAngleJoint(WorldPhysic, Body, Body)`
- `CreateDistanceJoint(WorldPhysic, Body, Body, Vector2F, Vector2F, bool)`
- `CreateFrictionJoint(WorldPhysic, Body, Body, Vector2F, bool)`
- `CreateFrictionJoint(WorldPhysic, Body, Body)`
- `CreateGearJoint(WorldPhysic, Body, Body, Joint, Joint, float)`
- `CreatePulleyJoint(WorldPhysic, Body, Body, Vector2F, Vector2F, Vector2F, Vector2F, float, bool)`

## Existing Tests
`test/Dynamics/Joints/JointFactoryTest.cs` — 4 tests (DistanceJoint simple, RevoluteJoint with anchor, WheelJoint with axis, FixedMouseJoint)

## Approach
Each factory method creates a joint, adds it to the world, and returns it. Test each by:
1. Creating WorldPhysic + two bodies
2. Calling factory method
3. Asserting joint type, body references, world joint list
