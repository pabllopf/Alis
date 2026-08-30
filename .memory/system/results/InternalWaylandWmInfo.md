# Result: InternalWaylandWmInfo.cs

File: `1_Presentation/Extension/Graphic/Sdl2/src/Structs/InternalWaylandWmInfo.cs`
CoverageBefore: 0.0% (SonarCloud; 6 uncovered lines)
CoverageAfter: 100.0% (12/12 instrumented lines, local coverlet, InternalWaylandWmInfo-filtered run)
TestsAdded: 3 (InternalWaylandWmInfoRemainingCoverageTests.cs, plain [Fact])
Commit: test: coverage InternalWaylandWmInfo.cs
Status: REMEDIATED

## Summary

InternalWaylandWmInfo.cs is a plain `[StructLayout(LayoutKind.Sequential, Pack=1)]` struct
with 6 `IntPtr` auto-properties (`Display`, `Surface`, `ShellSurface`, `EglWindow`,
`XdgSurface`, `XdgToplevel`) and no logic.

The committed `InternalWaylandWmInfoTest.cs` covered them but every test used
`[RequireSdl2ImageFact]`, which SKIPS when `libsdl2_image` cannot be resolved by
`NativeLibrary.TryLoad` (verified locally: 3/3 skipped). That is why SonarCloud still
reported the 6 property lines as uncovered.

Added `InternalWaylandWmInfoRemainingCoverageTests.cs` with plain `[Fact]` tests: default
initialization, set/get round trip for all 6 properties, and value-type copy independence.

## Verification

- Targeted run: 3 passed / 0 failed, 0 skipped (net8.0).
- Local coverlet: InternalWaylandWmInfo.cs 100.0% (12/12 instrumented lines, line-rate 1.0, branch-rate 1.0).