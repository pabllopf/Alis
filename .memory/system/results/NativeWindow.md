# NativeWindow.cs

- **File**: `1_Presentation/Extension/Graphic/Glfw/src/NativeWindow.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 96.43% (351/364 lines)
- **Tests Added**: 63 (NativeWindowExecutionTests.cs + MainThreadNativeWorker.cs, startup-hook main-thread executor, no-op guarded for CI)
- **Uncovered Lines**: Fullscreen() (async re-show), SetIcons (MarshalDirectiveException), X11/Win32 entry points absent from macOS dylib, KeyRepeat branch (Release flag always set), ReleaseHandle catch, Minimized/MousePosition round-trip (macOS cursor warp needs Accessibility permission)
- **Status**: COMPLETED
