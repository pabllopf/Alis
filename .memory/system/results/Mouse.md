# Result: Mouse.cs

File: `1_Presentation/Extension/Graphic/Sfml/src/Windows/Mouse.cs`
CoverageBefore: 54.2% (SonarCloud; stale artifact)
CoverageAfter: 70.0% (14/20, local coverlet)
TestsAdded: 0 (already remediated, committed MouseTest/MouseTests/MouseRemainingCoverageTests)
Commit: test: coverage Mouse.cs
Status: BLOCKED_BY_PRODUCTION_CODE

## Summary

Mouse.cs is the SFML mouse static wrapper (7 complexity / 57 LOC). Committed
MouseTest.cs/MouseTests.cs/MouseRemainingCoverageTests.cs (6 tests + RequireCSfmlSystemFact
native tests) cover 14/20 lines (70.0%) locally.

## Remaining uncovered (6) — BLOCKED_BY_PRODUCTION_CODE

- 125-127 — `SetPosition(Vector2F)`: system-cursor side effect (moves the actual OS mouse);
  also requires a display server.
- 145-147 — `SetPosition(Vector2F, Window)` window-relative branch: requires a live Window
  instance (needs the main-thread hook infrastructure; the window-relative `GetPosition`
  branches above are covered the same way in the committed suite).

## Verification

- `dotnet test Alis.Extension.Graphic.Sfml.Test.csproj -c Debug -f net8.0 --filter
  "FullyQualifiedName~Mouse"`: 70 passed, 0 failed, 0 skipped.
- Local coverlet (XPlat Code Coverage, cobertura): 14/20 = 70.0%.
