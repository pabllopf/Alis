# Result: SoundStream.cs

File: `1_Presentation/Extension/Graphic/Sfml/src/Audios/SoundStream.cs`
CoverageBefore: 0.0% (SonarCloud; stale artifact)
CoverageAfter: 4.3% (3/69, local coverlet)
TestsAdded: 0 (17 probe tests written and removed in previous session — each crashed the test host)
Commit: test: coverage SoundStream.cs
Status: BLOCKED_BY_PRODUCTION_CODE

## Summary

SoundStream.cs is the SFML sound-stream wrapper (29 complexity / 171 LOC). Only ctor paths are
coverable (3/69).

## Remaining uncovered (66) — BLOCKED_BY_PRODUCTION_CODE

All instance members: the wrapper P/Invokes `sfSoundStream_create` with the CSFML 2.x 5-arg ABI
vs the installed CSFML 3.0 7-arg (channel-map args read from stale registers → NULL deref in the
libcsfml-audio ctor). Every probe test crashed the test host. Production ABI change required.

## Verification

- `dotnet test Alis.Extension.Graphic.Sfml.Test.csproj -c Debug -f net8.0 --filter
  "FullyQualifiedName~SoundStream"`: 11 passed, 0 failed, 0 skipped.
- Local coverlet (XPlat Code Coverage, cobertura): `SoundStream.cs` 3/69 = 4.3%, identical to
  the committed result.
