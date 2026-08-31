# Result: InternalUikitWmInfo.cs

File: `1_Presentation/Extension/Graphic/Sdl2/src/Structs/InternalUikitWmInfo.cs`
CoverageBefore: 0.0% (SonarCloud; existing tests skipped)
CoverageAfter: 100.0% (1/1 instrumented line, local coverlet)
TestsAdded: 5 (InternalUikitWmInfoCoverageTests.cs)
Commit: test: coverage InternalUikitWmInfo.cs
Status: REMEDIATED

## Summary

InternalUikitWmInfo.cs is a blittable `public struct` (LayoutKind.Sequential, Pack=1) exposing a
single executable member: the auto-property `IntPtr Window { get; set; }` (line 44). The other
members are readonly uint fields (framebuffer, colorBuffer, resolveFramebuffer). SonarCloud
reported 0.0% because the pre-existing `InternalUikitWmInfoTest.cs` class annotates every test
with the custom `[RequireSdl2ImageFact]` attribute, which skips when the native `sdl2_image`
library cannot be resolved by name via `NativeLibrary.TryLoad`. On this host that lookup fails,
so the whole class was skipped and the only executable line stayed uncovered.

The `Window` property needs no native interop — it is a pure managed `IntPtr` getter/setter.
A new `InternalUikitWmInfoCoverageTests.cs` class uses plain `[Fact]` attributes (always run,
matching the PixelFormatCoverageTests / DropEventCoverageTests convention) to exercise:
- `Window` set/get round-trip for an arbitrary pointer.
- `Window` overwrite semantics and default zero.
- readonly buffer fields default to zero.
- struct value-type copy independence for `Window`.

## Verification

- InternalUikitWmInfoCoverageTests filter (net8.0, Debug): 5 passed, 0 failed, 0 skipped.
- Coverlet cobertura: `InternalUikitWmInfo` class line-rate=1, branch-rate=1; `get_Window` line 44 hit 10 times.
