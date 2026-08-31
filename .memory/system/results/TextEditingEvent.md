# Result: TextEditingEvent.cs

File: `1_Presentation/Extension/Graphic/Sdl2/src/Structs/TextEditingEvent.cs`
CoverageBefore: 0.0% (SonarCloud; existing tests skipped)
CoverageAfter: 100.0% (1/1 instrumented line, local coverlet)
TestsAdded: 2 (TextEditingEventCoverageTests.cs)
Commit: test: coverage TextEditingEvent.cs
Status: REMEDIATED

## Summary

TextEditingEvent.cs is a `public readonly struct` (LayoutKind.Sequential, Pack=1) whose only
executable member is the getter `public string Text => Marshal.PtrToStringAnsi(textPtr)` (line
75); every other member is a readonly field. `textPtr` is `internal readonly`, so a `default`
instance has it as `IntPtr.Zero`, and `Marshal.PtrToStringAnsi(IntPtr.Zero)` returns `null`.

SonarCloud reported 0.0% because the pre-existing `TextEditingEventTest.cs` class annotates every
test with the custom `[RequireSdl2ImageFact]` attribute, which skips when the native `sdl2_image`
library cannot be resolved by name via `NativeLibrary.TryLoad`; on this host it skips, so the
`Text` getter stayed uncovered. (That file also uses forbidden reflection via
`FieldInfo.SetValueDirect`.)

The `Text` getter is coverable without any native interop via a default instance. A new
`TextEditingEventCoverageTests.cs` class uses plain `[Fact]` attributes (always run) to exercise:
- `Text` returns null for a zero text pointer (default instance).
- readonly fields default to zero.

## Verification

- TextEditingEventCoverageTests filter (net8.0, Debug): 2 passed, 0 failed, 0 skipped.
- Coverlet cobertura: `TextEditingEvent` class line-rate=1, branch-rate=1; `get_Text` line 75 hit 1 time.
