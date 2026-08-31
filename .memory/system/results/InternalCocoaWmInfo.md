# Result: InternalCocoaWmInfo.cs

File: `1_Presentation/Extension/Graphic/Sdl2/src/Structs/InternalCocoaWmInfo.cs`
CoverageBefore: 0.0% (SonarCloud; existing tests skipped)
CoverageAfter: 100.0% (1/1 instrumented line, local coverlet)
TestsAdded: 4 (InternalCocoaWmInfoCoverageTests.cs)
Commit: test: coverage InternalCocoaWmInfo.cs
Status: REMEDIATED

## Summary

InternalCocoaWmInfo.cs is a blittable `public struct` (LayoutKind.Sequential, Pack=1) exposing a
single executable member: the auto-property `IntPtr Window { get; set; }` (line 44). SonarCloud
reported 0.0% because the pre-existing `InternalCocoaWmInfoTest.cs` class annotates every test
with the custom `[RequireSdl2ImageFact]` attribute, which skips when the native `sdl2_image`
library cannot be resolved by name via `NativeLibrary.TryLoad`. On this host that lookup fails,
so the whole class was skipped and the only executable line stayed uncovered.

The `Window` property needs no native interop — it is a pure managed `IntPtr` getter/setter.
A new `InternalCocoaWmInfoCoverageTests.cs` class uses plain `[Fact]` attributes (always run,
matching the PixelFormatCoverageTests / DropEventCoverageTests convention) to exercise:
- `Window` set/get round-trip for an arbitrary pointer.
- `Window` overwrite semantics and default zero.
- struct value-type copy independence for `Window`.

## Verification

- InternalCocoaWmInfoCoverageTests filter (net8.0, Debug): 4 passed, 0 failed, 0 skipped.
- Coverlet cobertura: `InternalCocoaWmInfo` class line-rate=1, branch-rate=1; `get_Window` line 44 hit 10 times.
