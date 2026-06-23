## COVERAGE TASK

### File
2_Application/Alis/src/Builder/Core/Ecs/System/ManagerBuilders/Scenes/SceneManagerBuilder.cs

### Coverage
Current: 22.2% (7 uncovered lines)

### Method(s)
- `Add<T>(Action<SceneBuilder> config)` — adds a scene builder with config

### Existing Tests
- `SceneManagerBuilderTest.cs` (3 tests: constructor, build returns instance, build returns same instance)

### Source Code
```csharp
public SceneManagerBuilder Add<T>(Action<SceneBuilder> config) where T : Scene
{
    SceneBuilder sceneBuilder = new SceneBuilder(sceneManager.Context);
    config(sceneBuilder);
    Scene scene = sceneBuilder.Build();
    sceneManager.AddScene(scene);
    return this;
}
```

### Approach
Add a test using `Add<Scene>` with an empty config action, verify builder chaining and scene added to LoadedScenes.
