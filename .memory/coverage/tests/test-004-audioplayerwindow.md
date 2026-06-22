# Test Record #4 — AudioPlayerWindow.cs

## Source File

- **Path**: `1_Presentation/Engine/src/Windows/AudioPlayerWindow.cs`
- **Class**: `AudioPlayerWindow`
- **Namespace**: `Alis.App.Engine.Windows`

## Test File

- **Path**: `1_Presentation/Engine/test/AudioPlayerWindowTest.cs`
- **Class**: `AudioPlayerWindowTest`

## Test Cases (11 Tests)

### WindowName Field Tests (1 Test)

1. **WindowName_Field_ShouldNotBeNull** — Validates public static `WindowName` field exists, is not empty, and contains "Audio Player"

### Constructor Tests (5 Tests)

2. **Constructor_ShouldSetSpaceWork** — Validates constructor injection sets SpaceWork property
3. **Constructor_ShouldInitializeProgressTo1** — Validates private `progress` field is initialized to 1f
4. **Constructor_ShouldInitializeCurrentTimeToZero** — Validates private `currentTime` field is initialized to TimeSpan.Zero
5. **Constructor_ShouldInitializeTotalTimeTo10Seconds** — Validates private `totalTime` field is initialized to 10 seconds
6. **Constructor_ShouldInitializeIsPlayingToTrue** — Validates private `isPlaying` field is initialized to true

### Property Tests (1 Test)

7. **SpaceWork_Property_ShouldReturnSetValue** — Validates SpaceWork property getter returns the same instance as constructor parameter

### Method Tests (4 Tests)

8. **Initialize_ShouldNotThrow** — Validates Initialize() method does not throw exceptions
9. **Start_ShouldNotThrow** — Validates Start() method does not throw exceptions
10. **Render_ShouldNotThrow_WhenWindowIsOpen** — Validates Render() method does not throw when window is open
11. **Render_ShouldNotThrow_WhenWindowIsClosed** — Validates Render() method does not throw when window is closed (uses reflection to set private `isOpen` field to false)

### Private Fields (Not Tested - Implementation Details)

- `currentTime` — TimeSpan for current playback position
- `flags` — ImGuiWindowFlags with NoCollapse option
- `progress` — float progress value (1f)
- `totalTime` — TimeSpan for total audio duration (10 seconds)
- `isOpen` — bool window open state
- `isPlaying` — bool audio playing state

### Notes

- Tests use `RuntimeHelpers.GetUninitializedObject` to avoid complex SpaceWork initialization
- Test #11 uses reflection to set private `isOpen` field to false, simulating window being closed
- All tests follow Arrange/Act/Assert pattern
- Tests focus on public API surface (constructor, properties, methods)
- Private UI rendering logic (`Render()` method body) is not fully tested as it requires ImGui context

## Commit Information

- **Commit Hash**: b17af10c3
- **Commit Message**: `test: coverage AudioPlayerWindow.cs`
- **Date**: 2026-06-22
