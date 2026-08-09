# Coverage Summary

## VideoWriter.cs

- **File**: `1_Presentation/Extension/Media/FFmpeg/src/Video/VideoWriter.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 97.1%
- **Tests Added**: 48
- **Uncovered Lines**: Lines 260-263 (`catch` block in `CloseWrite` — cannot be hit on macOS since `Process.Kill()` never throws for valid processes)

## SceneManager.cs

- **File**: `2_Application/Alis/src/Core/Ecs/Systems/Manager/Scene/SceneManager.cs`
- **Coverage Before**: 98.6%
- **Coverage After**: 100.0%
- **Tests Added**: 1
- **Uncovered Lines**: None

## UnixPlayerBase.cs

- **File**: `4_Operation/Audio/src/Players/UnixPlayerBase.cs`
- **Coverage Before**: 98.5%
- **Coverage After**: 100.0%
- **Tests Added**: 1
- **Uncovered Lines**: None (line 282 `}` is non-executable closing brace)

## Mouse.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Windows/Mouse.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 55.0%
- **Tests Added**: 6
- **Uncovered Lines**: Native P/Invoke paths (`IsButtonPressed`, `GetPosition()`, `SetPosition(Vector2F)`, null-window branches) require csfml native libs absent on SonarCloud CI; existing `RequireCSfmlSystemFact` tests are skipped there

## BreakableBody.cs

- **File**: `4_Operation/Physic/src/Common/Logic/BreakableBody.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 100.0%
- **Tests Added**: 14
- **Uncovered Lines**: None

## FloatRect.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Render/FloatRect.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 100.0%
- **Tests Added**: 23
- **Uncovered Lines**: None

## IntRect.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Render/IntRect.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 100.0%
- **Tests Added**: 23
- **Uncovered Lines**: None

## Color.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Render/Color.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 100.0%
- **Tests Added**: 26
- **Uncovered Lines**: None

## StreamAdaptor.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Systems/StreamAdaptor.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 93.6%
- **Tests Added**: 10
- **Uncovered Lines**: Lines 108-110 (`catch` in `~StreamAdaptor` — `Dispose(false)` never throws for valid pointers)

## BlendMode.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Render/BlendMode.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 100.0%
- **Tests Added**: 16
- **Uncovered Lines**: None

## ObjectBase.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Systems/ObjectBase.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 100.0%
- **Tests Added**: 7
- **Uncovered Lines**: None

## ContextSettings.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Windows/ContextSettings.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 100.0%
- **Tests Added**: 5
- **Uncovered Lines**: None

## KeyEventArgs.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Windows/KeyEventArgs.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 100.0%
- **Tests Added**: 4
- **Uncovered Lines**: None

## Vertex.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Render/Vertex.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 100.0%
- **Tests Added**: 5
- **Uncovered Lines**: None

## MouseWheelScrollEventArgs.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Windows/MouseWheelScrollEventArgs.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 100.0%
- **Tests Added**: 3
- **Uncovered Lines**: None

## SensorEventArgs.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Windows/SensorEventArgs.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 100.0%
- **Tests Added**: 3
- **Uncovered Lines**: None

## LoadingFailedException.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Windows/LoadingFailedException.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 100.0%
- **Tests Added**: 5
- **Uncovered Lines**: None

## LoadingFailedException.cs (Systems)

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Systems/LoadingFailedException.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 100.0%
- **Tests Added**: 5
- **Uncovered Lines**: None

## JoystickMoveEventArgs.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Windows/JoystickMoveEventArgs.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 100.0%
- **Tests Added**: 3
- **Uncovered Lines**: None

## MouseButtonEventArgs.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Windows/MouseButtonEventArgs.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 100.0%
- **Tests Added**: 3
- **Uncovered Lines**: None

## MouseWheelEventArgs.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Windows/MouseWheelEventArgs.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 100.0%
- **Tests Added**: 3
- **Uncovered Lines**: None

## TouchEventArgs.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Windows/TouchEventArgs.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 100.0%
- **Tests Added**: 3
- **Uncovered Lines**: None

## Ivec4.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Render/Ivec4.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 100.0%
- **Tests Added**: 2
- **Uncovered Lines**: None

## Vec4.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Render/Vec4.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 100.0%
- **Tests Added**: 2
- **Uncovered Lines**: None

## Vec3.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Render/Vec3.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 100.0%
- **Tests Added**: 3
- **Uncovered Lines**: None

## JoystickButtonEventArgs.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Windows/JoystickButtonEventArgs.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 100.0%
- **Tests Added**: 3
- **Uncovered Lines**: None

## MouseMoveEventArgs.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Windows/MouseMoveEventArgs.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 100.0%
- **Tests Added**: 3
- **Uncovered Lines**: None

## SizeEventArgs.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Windows/SizeEventArgs.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 100.0%
- **Tests Added**: 3
- **Uncovered Lines**: None
