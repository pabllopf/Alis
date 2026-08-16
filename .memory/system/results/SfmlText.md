# Result: SfmlText.cs

File: `1_Presentation/Extension/Graphic/Sfml/src/Render/SfmlText.cs`
CoverageBefore: 0.0% (SonarCloud; stale artifact)
CoverageAfter: 95.2% (80/84, local coverlet)
TestsAdded: 0 (already remediated in commit d94c9678f)
Commit: test: coverage SfmlText.cs
Status: BLOCKED_BY_PRODUCTION_CODE

## Summary

SfmlText.cs is the SFML text wrapper (30 complexity / 197 LOC). Committed `SfmlTextTest.cs` /
`SfmlTextTests.cs` cover 80/84 lines (95.2%).

## Remaining uncovered (4 lines) — BLOCKED_BY_PRODUCTION_CODE

Lines 263-267: Draw switch cases for `RenderWindow` and `RenderTexture` —
`sfRenderWindow_drawText` SIGSEGVs on a live window (CSFML 3.0 sfRenderStates layout shift,
same as RenderWindow.Draw) and the RenderTexture ctor is ABI-broken. Production change
required.

## Verification

- `dotnet test Alis.Extension.Graphic.Sfml.Test.csproj -c Debug -f net8.0 --filter
  "FullyQualifiedName~SfmlText"`: 38 passed, 0 failed, 0 skipped.
- Local coverlet (XPlat Code Coverage, cobertura): `SfmlText.cs` 80/84 = 95.2%, identical to
  the committed result.
