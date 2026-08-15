# Result: Clipboard.cs

File: `1_Presentation/Extension/Graphic/Sfml/src/Windows/Clipboard.cs`
CoverageBefore: 0.0% (SonarCloud; stale artifact)
CoverageAfter: 100.0% (21/21 lines, local coverlet)
TestsAdded: 2 (ClipboardExecutionTests.cs)
Commit: test: coverage Clipboard.cs
Status: PARTIALLY_REMEDIATED

## Summary

Clipboard.cs is a static wrapper over `sfClipboard_getUnicodeString` /
`sfClipboard_setUnicodeString` (Contents getter with UTF-32 length scan + decode, setter with
pinned UTF-32 buffer). The committed `ClipboardTest.cs` was reflection-only; this session added
`ClipboardExecutionTests.cs` (2 tests) which exercise the real clipboard of the desktop
session: a pure read, and a set/round-trip that always restores the original contents in a
finally block. Local coverlet (net8.0, Debug, Clipboard filter) measures 21/21 lines (100.0%);
all 16 tests pass.

## Verification

- Clipboard filter (net8.0, Debug): 16 passed, 0 failed, 0 skipped.
- Local coverlet: Clipboard.cs 21/21 lines (100.0%), no uncovered lines.
- Round-trip restores the original clipboard contents.
