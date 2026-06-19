## COVERAGE TEST PATTERN

### Target
AngleJoint.cs — internal parameterless constructor

### Pattern
Direct invocation via InternalsVisibleTo.

```csharp
[Fact]
public void InternalConstructor_Parameterless_ShouldSetJointTypeToAngle()
{
    AngleJoint joint = new AngleJoint();

    Assert.Equal(JointType.Angle, joint.JointType);
}
```

### Key Insight
The source csproj includes `<InternalsVisibleTo Include="$(AssemblyName).Test"/>`, so test projects can access `internal` members directly without reflection.
