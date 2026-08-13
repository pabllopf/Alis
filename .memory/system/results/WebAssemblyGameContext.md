# WebAssemblyGameContext.cs

- **File**: `4_Operation/Graphic/src/Platforms/Web/WebAssemblyGameContext.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 50% (95/190; 40/135 class + 55/55 GameContextPresets)
- **Tests Added**: 23 (WebAssemblyGameContextExecutionTests.cs)
- **Uncovered Lines**: all instance members — ctor always throws on desktop: WebAssemblyPlatformFactory.Create throws because EGL native lib absent (WebAssemblyPlatform.Initialize swallows DllNotFoundException). Unreachable off-WASM; production change required.
- **Status**: BLOCKED_BY_PRODUCTION_CODE
