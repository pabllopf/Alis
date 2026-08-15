# ObjectiveCInterop.cs

- **File**: `4_Operation/Graphic/src/Platforms/Osx/Native/ObjectiveCInterop.cs`
- **Coverage Before**: 5.0% (SonarCloud, stale)
- **Coverage After**: 100.0% (19/19 coverable lines, local coverlet, macOS arm64)
- **Tests Added**: 7 (ObjectiveCInteropRemainingCoverageTests.cs — UTF-8/whitespace/empty-name edge cases, NSString `length` round-trip, `isKindOfClass:` object check)
- **Note**: All `[DllImport]` externs carry `[ExcludeFromCodeCoverage]`; remaining covered lines are the wrapper methods `Class`, `Sel`, `NsString`, `NSViewGetFrame`, `GetWindowFrame` and the static selector fields. `GetWindowFrame` `#else` (stret) branch is not compiled on arm64, so it cannot be exercised. Real `NSView`/`NSWindow` message sends were skipped (require an NSApplication context on the main thread; null-receiver sends already assert zeroed frames).
- **Status**: COMPLETED
