## COVERAGE TASK

### File
2_Application/Alis/src/Builder/Core/Ecs/Entity/SceneBuilder.cs

### Coverage
Current: 40.0% (6 uncovered lines)

### Method(s)
- `Add<T>(Action<GameObjectBuilder> config)` — adds a game object with config

### Existing Tests
- `SceneBuilderTest.cs` (4 tests: constructor, build, name)

### Approach
Add a test using `Add<GameObject>` with an empty config action, verify builder chaining.
