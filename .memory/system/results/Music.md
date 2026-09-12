# Music.cs

## File
1_Presentation/Extension/Graphic/Sfml/src/Audios/Music.cs

## Coverage (SonarCloud, master)
- Line: 0.0%, Branch: 0.0%, Uncovered Lines: 82, Method: Music

## Local verification
- Build: `dotnet build Alis.Extension.Graphic.Sfml.Test.csproj -c Debug` → OK
- Full run: 1870/1870 passed, 0 skipped
- Coverlet (XPlat, .config/coverlet.runsettings): Music class `line-rate = 1.0` (100%)
- Existing tests: `MusicTest.cs` (33 facts) + `MusicExecutionTests.cs` (14 facts) cover
  all three constructors (file / bytes / stream + failure paths), every property
  getter/setter, Play / Pause / Stop, ToString, Dispose and the TimeSpan struct.

## Analysis
SonarCloud shows 0% because the tests are gated by `RequireCSfmlAudioFactAttribute`,
which skips them in CI where `csfml-audio` is unavailable. Locally all 50 Music tests
execute and reach 100% line coverage. No uncovered managed behavior remains that can
be exercised without the native dependency; adding more tests would only duplicate
existing coverage and would also be skipped in the CI environment.

## Outcome
No new tests required. queue.md entry satisfied; state + summary updated.
