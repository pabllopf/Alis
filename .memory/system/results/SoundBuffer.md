# Result: SoundBuffer.cs

File: `1_Presentation/Extension/Graphic/Sfml/src/Audios/SoundBuffer.cs`
CoverageBefore: 0.0% (SonarCloud; stale artifact)
CoverageAfter: 77.8% (49/63, local coverlet)
TestsAdded: 0 (3 probe tests removed in previous session — every samples-ctor call SIGBUSes the host)
Commit: test: coverage SoundBuffer.cs
Status: BLOCKED_BY_PRODUCTION_CODE

## Summary

SoundBuffer.cs is the SFML sound-buffer wrapper (16 complexity / 121 LOC). Committed
`SoundBufferTest.cs` + `SoundBufferRemainingCoverageTests.cs` cover 49/63 lines (77.8%).

## Remaining uncovered (14) — BLOCKED_BY_PRODUCTION_CODE

Lines 127-144: `SoundBuffer(short[], uint, uint)` body — the wrapper declares the 4-param
`sfSoundBuffer_createFromSamples` vs CSFML 3.0's 6-param signature (missing
channelMapData/channelMapSize read from garbage registers → SIGBUS). Production ABI change
required.

## Verification

- `dotnet test Alis.Extension.Graphic.Sfml.Test.csproj -c Debug -f net8.0 --filter
  "FullyQualifiedName~SoundBuffer"`: 51 passed, 0 failed, 0 skipped.
- Local coverlet (XPlat Code Coverage, cobertura): `SoundBuffer.cs` 49/63 = 77.8%, identical to
  the committed result.
