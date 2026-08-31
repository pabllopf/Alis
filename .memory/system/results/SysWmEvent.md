# Result: SysWmEvent.cs

File: `1_Presentation/Extension/Graphic/Sdl2/src/Structs/SysWmEvent.cs`
CoverageBefore: 0.0% (SonarCloud; existing tests skipped)
CoverageAfter: 100.0% (1/1 instrumented line, local coverlet)
TestsAdded: 4 (SysWmEventCoverageTests.cs)
Commit: test: coverage SysWmEvent.cs
Status: REMEDIATED

## Summary

SysWmEvent.cs is a blittable `public struct` (LayoutKind.Sequential, Pack=1) exposing a single
executable member: the auto-property `IntPtr Msg { get; set; }` (line 55). The other members are
readonly fields (EventType type, uint timestamp). SonarCloud reported 0.0% because the
pre-existing `SysWmEventTest.cs` class annotates every test with the custom
`[RequireSdl2ImageFact]` attribute, which skips when the native `sdl2_image` library cannot be
resolved by name via `NativeLibrary.TryLoad`. On this host that lookup fails, so the whole class
was skipped and the only executable line stayed uncovered.

The `Msg` property needs no native interop — it is a pure managed `IntPtr` getter/setter.
A new `SysWmEventCoverageTests.cs` class uses plain `[Fact]` attributes (always run, matching the
PixelFormatCoverageTests / DropEventCoverageTests convention) to exercise:
- `Msg` set/get round-trip for an arbitrary pointer.
- `Msg` overwrite semantics and default zero.
- struct value-type copy independence for `Msg`.

## Verification

- SysWmEventCoverageTests filter (net8.0, Debug): 4 passed, 0 failed, 0 skipped.
- Coverlet cobertura: `SysWmEvent` class line-rate=1, branch-rate=1; `get_Msg` line 55 hit 10 times.
