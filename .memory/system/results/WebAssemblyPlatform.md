# WebAssemblyPlatform.cs

- **File**: `4_Operation/Graphic/src/Platforms/Web/WebAssemblyPlatform.cs`
- **Coverage Before**: 4.2% (SonarCloud); 36.3% local baseline (existing tests mostly `[WebOnly]`-skipped)
- **Coverage After**: 74.4% (328/441 lines, local coverlet)
- **Tests Added**: 34 (WebAssemblyPlatformTests.cs — plain `[Fact]`, direct internal calls via InternalsVisibleTo)
- **Uncovered Lines**: 113 — EGL native success/error paths (187-246, 159-160, 169-171, 669-691, 626-628, 637-639, 711), gamepad-data loops (532-543, 563-578), double-swallowed EmscriptenWeb catch blocks (272-338, 755-761), IsKeyDown unknown-key (742)
- **Status**: COMPLETED (remaining lines blocked by native EGL/emscripten availability)
