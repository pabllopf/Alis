## COVERAGE TASK

### File
2_Application/Alis/src/Core/Ecs/Components/Body/RigidBody.cs

### Coverage
Current: 0.0% (2 uncovered lines)

### Method(s)
- `OnUpdate(IGameObject self)` — empty body (struct implementing IOnUpdate)

### Existing Tests
- `RigidBodyTest.cs` (2 tests: default constructor, interface check)

### Source Code
```csharp
public struct RigidBody : IOnUpdate
{
    public void OnUpdate(IGameObject self)
    {
    }
}
```

### Approach
Add a single test verifying `OnUpdate` is callable without throwing.
