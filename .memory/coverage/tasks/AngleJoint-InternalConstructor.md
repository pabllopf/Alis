## COVERAGE TASK

### File
4_Operation/Physic/src/Dynamics/Joints/AngleJoint.cs

### Coverage
97.7% (1 uncovered line)

### Uncovered Lines
58 (internal AngleJoint() parameterless constructor)

### Method
AngleJoint() — internal parameterless constructor

### Existing Tests
AngleJointTest.cs — covers public constructor, properties, GetReactionForce/Torque, WorldAnchorA/B, TargetAngle, SolvePositionConstraints, InitVelocityConstraints, SolveVelocityConstraints

### Gap
No test calls the internal parameterless constructor `internal AngleJoint()` which sets `JointType = JointType.Angle`.

### Approach
Add test using `new AngleJoint()` directly (InternalsVisibleTo is enabled in src csproj).

### Source Diff
```csharp
+ InternalConstructor_Parameterless_ShouldSetJointTypeToAngle
```
