# Result: KeyCodes.cs

File: `1_Presentation/Extension/Graphic/Sdl2/src/Mapping/KeyCodes.cs`
CoverageBefore: 0.0% (SonarCloud; enum LOC artifact)
CoverageAfter: Not measurable (0 instrumented lines; coverlet emits no coverage for pure enums)
TestsAdded: 0 (already covered by committed `KeyCodesTest.cs`)
Commit: test: coverage KeyCodes.cs
Status: ALREADY_REMEDIATED

## Summary

KeyCodes.cs is a pure `public enum` (0 complexity / 258 LOC per SonarCloud) whose members map
SDK scancodes with `SdlScancode.SdlScancode* | SdlInputConst.KScancodeMask` and ASCII char
literals. It contains no executable statements, branches or methods.

A local coverlet run (net8.0, Debug, KeyCodes filter) confirms the type produces **zero
instrumented lines**: KeyCodes.cs (together with SdlScancode.cs and SdlInputConst.cs) is
absent from the cobertura `<class>` list, so line coverage is not a meaningful metric for it.
SonarCloud's 169 "uncovered lines" are enum declaration/comment lines that can never be hit.

The enum's only observable surface — member values — is already fully asserted by the
committed `KeyCodesTest.cs` (33 passing tests: ASCII literals, digit/letter ranges, function
and modifier keys under KScancodeMask, cursor keys, punctuation, keypad and media keys).
KeyCodes is also exercised through Sdl.ScanCodeToKeyCode / SKeyName / KeySym in SdlTest.cs /
KeySymTest.cs / SdlTests.cs.

## Verification

- KeyCodes filter (net8.0, Debug): 33 passed, 0 failed, 0 skipped.
- Coverlet: no `<class>` entry for KeyCodes.cs → not instrumentable, nothing to remediate.
