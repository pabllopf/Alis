# Result: SoundRecorder.cs

File: `1_Presentation/Extension/Graphic/Sfml/src/Audios/SoundRecorder.cs`
CoverageBefore: 0.0% (SonarCloud; stale artifact)
CoverageAfter: 98.0% (50/51, local coverlet)
TestsAdded: 0 (already remediated, committed SoundRecorderTest.cs)
Commit: test: coverage SoundRecorder.cs
Status: BLOCKED_BY_PRODUCTION_CODE

## Summary

SoundRecorder.cs is the SFML sound-recorder wrapper (19 complexity / 111 LOC). Committed
`SoundRecorderTest.cs` covers 50/51 lines (98.0%).

## Remaining uncovered (1 line) — BLOCKED_BY_PRODUCTION_CODE

Line 221: `SetProcessingInterval` body — `sfSoundRecorder_setProcessingInterval` symbol is
missing in CSFML 3.0 (always EntryPointNotFoundException). Production ABI change required.

## Verification

- `dotnet test Alis.Extension.Graphic.Sfml.Test.csproj -c Debug -f net8.0 --filter
  "FullyQualifiedName~SoundRecorder"`: 23 passed, 0 failed, 0 skipped.
- Local coverlet (XPlat Code Coverage, cobertura): `SoundRecorder.cs` 50/51 = 98.0%, identical
  to the committed result.
