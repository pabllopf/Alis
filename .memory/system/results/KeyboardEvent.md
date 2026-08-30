# Result: KeyboardEvent.cs

File: `1_Presentation/Extension/Graphic/Sdl2/src/Structs/KeyboardEvent.cs`
CoverageBefore: 0.0% (SonarCloud; 1 uncovered lines)
CoverageAfter: 100.0% (2/2, local coverlet, KeyboardEvent-filtered run)
TestsAdded: 2 (KeyboardEventCoverageTests.cs, plain [Fact])
Commit: test: coverage KeyboardEvent.cs
Status: REMEDIATED

## Summary

KeyboardEvent.cs is a sequential-layout struct holding readonly `EventType`/`uint`/`byte`
public fields and a `KeySym KeySym` auto-property. Only the property getter/setter lines on
line 69 are instrumented.

Committed `KeyboardEventTest.cs` already covered the type but all tests use
`[RequireSdl2ImageFact]`, which skips when `libsdl2_image` cannot be resolved
(CI/SonarCloud run), hence 0.0%.

Added `KeyboardEventCoverageTests.cs` (2 plain `[Fact]`): default (zeroed) values across the
readonly fields and default KeySym, and KeySym set/store round trip with a populated
`KeySym` (SdlScancodeA / KeyCodes.A / KeyMods.None).

## Verification

- KeyboardEvent-filtered run: 2 passed / 0 failed (net8.0).
- Local coverlet: KeyboardEvent.cs 100.0% (2/2 instrumented lines,
  line-rate 1.0, branch-rate 1.0).