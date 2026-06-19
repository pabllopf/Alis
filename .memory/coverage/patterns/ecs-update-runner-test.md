# Pattern: ECS Update Runner Test

## Target
`GameObjectUpdate<TComp, TArg>` and similar `Update<TComp, TArg...>` runner classes in `4_Operation/Ecs/src/Updating/Runners/`

## Approach
Create a component struct implementing the appropriate `IOnUpdate<TArg...>` interface, create entities with that component + arg components, call `scene.Update()`, and verify the component state changed correctly.

## Test Structure
```csharp
[Fact]
public void GameObjectUpdate_Arity1_Run_InvokesUpdateForAllEntities()
{
    using Scene scene = new Scene();
    GameObject entity = scene.Create(
        new Update1Component { CallCount = 0 },
        new Position { X = 1, Y = 2 }
    );
    scene.Update();
    Assert.Equal(1, entity.Get<Update1Component>().CallCount);
}
```

## Key Points
- Component structs must implement the matching `IOnUpdate<TArg...>` interface
- Each entity gets its own copy of component data
- `scene.Update()` dispatches through the `UpdateRunnerFactory` which instantiates the runner
- Runner processes entities in reverse order (`EntityCount - 1` down to `0`)
- Use `CallCount` field to verify the update was invoked
- Mutate arg component fields to verify references are passed correctly
- Multiple `scene.Update()` calls increment the call count accordingly

## Related Files
- `4_Operation/Ecs/test/Updating/Runners/UpdateTest.cs` - tests for arities 0, 2-8
- `4_Operation/Ecs/test/Updating/Runners/GameObjectUpdateTest.cs` - tests for arity 1
- `4_Operation/Ecs/test/Updating/Runners/UpdateRunnerFactoryTest.cs` - factory mapping tests
