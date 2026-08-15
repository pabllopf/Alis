# Result: ObjectiveCInterop.cs

File: `4_Operation/Graphic/src/Platforms/Osx/Native/ObjectiveCInterop.cs`
CoverageBefore: 0.0% (SonarCloud; stale artifact)
CoverageAfter: 100.0% (19/19 lines, local coverlet)
TestsAdded: 0 (already covered by committed ObjectiveCInteropTests.cs / ObjectiveCInteropRemainingCoverageTests.cs)
Commit: test: coverage ObjectiveCInterop.cs
Status: ALREADY_REMEDIATED

## Summary

ObjectiveCInterop.cs is the internal static ObjC-runtime interop facade (objc_getClass,
sel_registerName, objc_msgSend family, Sel helpers, NSViewGetFrame, GetWindowFrame,
NSString helpers). The P/Invoke externs are `[ExcludeFromCodeCoverage]`; the 19 instrumented
managed lines (static selector fields, Sel, NSViewGetFrame, GetWindowFrame, NSString helpers)
are already covered by the committed `ObjectiveCInteropTests.cs` and
`ObjectiveCInteropRemainingCoverageTests.cs` (`[MacOsOnly]`-gated, running on this macOS
host): a clean local coverlet run (net8.0, Debug) measures 19/19 lines (100.0%). All 17 tests
in the filter pass.

## Verification

- ObjectiveCInterop filter (net8.0, Debug): 17 passed, 0 failed, 0 skipped.
- Local coverlet: ObjectiveCInterop.cs 19/19 lines (100.0%), no uncovered lines.
