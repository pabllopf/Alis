## COVERAGE TASK

### File
2_Application/Alis/src/Core/Ecs/Systems/Manager/Audio/AudioManager.cs

### Coverage
50.0% (3 uncovered lines)

### Uncovered Lines
56-58 (5-parameter constructor body)

### Method
AudioManager(string id, string name, string tag, bool isEnable, Context context)

### Existing Tests
AudioManagerTest.cs — covers Context constructor, default properties, accessibility, AManager inheritance, IManager interface

### Gap
The `FullConstructor_SetsAllProperties` test exists but is inert — it has `[InlineData]` without `[Theory]`, so xUnit never executes it. Adding `[Theory]` activates the test and covers the 5-parameter constructor.

### Fix
Add `[Theory]` attribute to `FullConstructor_SetsAllProperties` in AudioManagerTest.cs
