## COVERAGE TEST PATTERN

### Target
AudioManager.cs — 5-parameter constructor

### Pattern
Broken test fix. The `FullConstructor_SetsAllProperties` method had `[InlineData]` attributes but was missing `[Theory]`, so xUnit never collected the test.

```csharp
[Theory]
[InlineData("test-id", "TestAudio", "AudioTag", true)]
[InlineData("", "", "", false)]
public void FullConstructor_SetsAllProperties(string id, string name, string tag, bool isEnable)
{
    Context context = new Context(new Setting());
    AudioManager audioManager = new AudioManager(id, name, tag, isEnable, context);
    Assert.Equal(id, audioManager.Id);
    Assert.Equal(name, audioManager.Name);
    Assert.Equal(tag, audioManager.Tag);
    Assert.Equal(isEnable, audioManager.IsEnable);
}
```

### Key Insight
Missing `[Theory]` is a common xUnit mistake. The `[InlineData]` attribute is meaningless without `[Theory]`; xUnit silently ignores the method.

### Related Files
- `2_Application/Alis/src/Core/Ecs/Systems/Manager/Audio/AudioManager.cs` (line 56)
- `2_Application/Alis/test/AudioManagerTest.cs` (line 187)
