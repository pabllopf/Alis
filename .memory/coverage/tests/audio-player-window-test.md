# AudioPlayerWindow Test Pattern

## Approach
For ImGui-dependent windows that cannot be integration-tested:

1. **Constructor tests**: Verify SpaceWork is assigned correctly
2. **Property tests**: Verify read-only properties via reflection
3. **No-op method tests**: Test Initialize() and Start() don't throw
4. **Static member tests**: Verify WindowName and constants
5. **Reflection tests**: Verify private fields exist with correct types
6. **Interface implementation tests**: Use reflection for internal interfaces

## Key Pattern: Internal Interface Access
IWindow is internal. Access via:
Type iwindowType = typeof(AudioPlayerWindow).Assembly.GetType("Alis.App.Engine.Windows.IWindow", true);

## Files
- Test: 1_Presentation/Engine/test/AudioPlayerWindowTest.cs
- Source: 1_Presentation/Engine/src/Windows/AudioPlayerWindow.cs
