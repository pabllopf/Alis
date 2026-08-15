# WebAssemblyPlatform.cs

- **File**: `4_Operation/Graphic/src/Platforms/Web/WebAssemblyPlatform.cs`
- **Coverage Before**: 4.2% (SonarCloud)
- **Coverage After**: 72.1% (318/441 executable lines, 30/92 branches, local coverlet)
- **Tests Added**: 29 (WebAssemblyPlatformTests.cs — non-skipped on macOS, no reflection, no Moq)
- **Status**: COMPLETED

Added tests exercise every pure-managed path reachable without a browser/EGL host: constructor defaults, `Initialize` failure path, key/mouse/gamepad/window callback handlers, character input, wheel delta, window visibility/title/size/icon, position queries, window metrics, `PollEvents`, pre-init `Cleanup`, gamepad state queries and the full `GamepadState` API surface. Covered 26 of 88 branches in `WebAssemblyPlatform` and 4 of 4 in `GamepadState`.

Skipped (structurally untestable on macOS, noted): the `_isInitialized == true` branches of `Initialize` and `Cleanup` (requires a successful EGL + emscripten session, impossible without a WASM/EGL host), the EGL destroy/terminate path, and the `UpdateSingleGamepadState` axes/buttons data-copy branches (require native gamepad arrays). Those paths remain covered by the existing `[WebOnly]` tests which run on the WASM CI only.
