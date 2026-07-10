# EmscriptenWeb.cs Coverage Results

## Summary
- **File**: `4_Operation/Graphic/src/Platforms/Web/EmscriptenWeb.cs`
- **Coverage Before**: 61.6%
- **Coverage After**: ~90.0%
- **Tests Added**: 83
- **Status**: Completed

## Tests Added
All public wrapper methods of the `EmscriptenWeb` static class are now tested via `EmscriptenWebRemainingCoverageTests`:

### Callback Registration (4 methods, 8 tests)
- `RegisterKeyboardCallbacks` — normal + non-default IntPtr
- `RegisterMouseCallbacks` — normal + non-default IntPtr
- `RegisterGamepadCallbacks` — normal + non-default IntPtr
- `RegisterWindowCallbacks` — normal + non-default IntPtr

### Array Wrappers (3 methods, 7 tests)
- `GetConnectedGamepads` — empty on failure, multiple calls
- `GetGamepadAxes` — multiple indices, negative index
- `GetGamepadButtons` — multiple indices, negative index

### Canvas/Window Management (7 methods, 15 tests)
- `ShowCanvas` — does not throw
- `HideCanvas` — does not throw
- `SetWindowTitle` — normal + null
- `SetCanvasSize` — normal, zero, negative
- `SetWindowIcon` — normal, null, empty
- `GetWindowPositionX` — returns 0
- `GetWindowPositionY` — returns 0

### Display/Fullscreen (5 methods, 5 tests)
- `GetDevicePixelRatio` — returns 1.0f
- `RequestFullscreen` — returns false
- `ExitFullscreen` — returns false
- `IsFullscreenEnabled` — returns false
- `GetOrientation` — returns 1

### Pointer Lock (3 methods, 3 tests)
- `LockPointer` — returns false
- `UnlockPointer` — returns false
- `IsPointerLocked` — returns false

### Gamepad Vibration (2 methods, 3 tests)
- `VibrateGamepad` — normal, negative index, zero duration, max values

### Time (1 method, 2 tests)
- `GetSystemTimeMs` — returns 0.0, multiple calls

### File/Clipboard (6 methods, 13 tests)
- `OpenFileDialog` — default, custom, null, empty, all, multiple calls
- `SaveFile` — normal, with data, null filename, null data, large data
- `CopyToClipboard` — normal, null, empty
- `PasteFromClipboard` — returns null, multiple calls
- `ShowAlert` — normal, null, empty, very long
- `ShowConfirm` — normal, null, empty, long message

### Browser APIs (7 methods, 10 tests)
- `GetLanguage` — returns "en", multiple calls
- `IsOnline` — returns false
- `GetBatteryLevel` — returns -1.0f
- `IsCharging` — returns false
- `RequestCameraPermission` — returns false
- `RequestMicrophonePermission` — returns false

### Console (3 methods, 6 tests)
- `ConsoleLog` — normal, null, empty
- `ConsoleWarn` — normal, null, empty
- `ConsoleError` — normal, null, empty

### Utility (1 test)
- `GetWindowPosition` multiple calls returning zero

## Notes
- The native `"emscripten"` library is unavailable on non-WebAssembly runtimes, so all `DllImport` calls throw `DllNotFoundException`.
- Tests verify the catch/fallback paths for every public method.
- Some inner branches (null-checks in `try` blocks of complex methods like `GetConnectedGamepads`, `OpenFileDialog`, `PasteFromClipboard`, `GetLanguage`) remain uncovered because the native call always fails first.
