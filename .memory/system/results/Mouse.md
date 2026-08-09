# Mouse.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Windows/Mouse.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 55.0%
- **Tests Added**: 6
- **Uncovered Lines**: Native P/Invoke paths (`IsButtonPressed`, `GetPosition()`/`GetPosition(null)`, `SetPosition(Vector2F)`/`SetPosition(position, null)`) require csfml native libraries absent on SonarCloud CI (macos-15-intel). Existing `MouseTests.cs`/`MouseTest.cs` cover them locally via `RequireCSfmlSystemFact` but those are skipped on CI.
- **Status**: COMPLETED (window-relative branches + enums covered with plain `[Fact]` tests that run on CI; native paths untestable on CI)
