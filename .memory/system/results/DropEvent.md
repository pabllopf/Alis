# Result: DropEvent.cs

File: `1_Presentation/Extension/Graphic/Sdl2/src/Structs/DropEvent.cs`
CoverageBefore: 0.0% (SonarCloud; existing tests skipped)
CoverageAfter: 100.0% (1/1 instrumented line, local coverlet)
TestsAdded: 4 (DropEventCoverageTests.cs)
Commit: test: coverage DropEvent.cs
Status: REMEDIATED

## Summary

DropEvent.cs is a blittable `public struct` (LayoutKind.Sequential, Pack=1) exposing a single
executable member: the auto-property `IntPtr File { get; set; }` (line 55). SonarCloud reported
0.0% because the pre-existing `DropEventTest.cs` class annotates every test with the custom
`[RequireSdl2ImageFact]` attribute, which skips the whole class when the native `sdl2_image`
library cannot be resolved by name via `NativeLibrary.TryLoad`. On this host that lookup fails,
so all 6 existing tests were skipped and the struct's only executable line stayed uncovered.

The `File` property requires no native interop — it is a pure managed `IntPtr` getter/setter.
A new `DropEventCoverageTests.cs` class therefore uses plain `[Fact]` attributes (always run,
matching the PixelFormatCoverageTests convention) to exercise:

- `File` set/get round-trip for an arbitrary pointer.
- `File` overwrite semantics.
- default `File == IntPtr.Zero`.
- struct value-type copy independence for `File`.

## Verification

- DropEventCoverageTests filter (net8.0, Debug): 4 passed, 0 failed, 0 skipped.
- Coverlet cobertura: `DropEvent` class line-rate=1, branch-rate=1; `get_File` line 55 hit 10 times.
