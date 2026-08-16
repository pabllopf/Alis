# Result: Shape.cs

File: `1_Presentation/Extension/Graphic/Sfml/src/Render/Shape.cs`
CoverageBefore: 0.0% (SonarCloud; stale artifact)
CoverageAfter: 85.0% (51/60, local coverlet)
TestsAdded: 0 (already remediated, committed ShapeTest/ShapeTests)
Commit: test: coverage Shape.cs
Status: BLOCKED_BY_PRODUCTION_CODE

## Summary

Shape.cs is the SFML shape wrapper (20 complexity / 138 LOC). Committed `ShapeTest.cs` +
`ShapeTests.cs` cover 51/60 lines (85.0%).

## Remaining uncovered (9) — BLOCKED_BY_PRODUCTION_CODE

Lines 159-172: Draw switch cases for `RenderWindow` and `RenderTexture` —
`sfRenderWindow_drawShape` SIGSEGVs on a live window (CSFML 3.0 sfRenderStates layout shift,
same as SfmlText.Draw); RenderTexture ctor is ABI-broken. Production change required.

## Verification

- `dotnet test Alis.Extension.Graphic.Sfml.Test.csproj -c Debug -f net8.0 --filter
  "FullyQualifiedName~Shape"`: 115 passed, 0 failed, 0 skipped.
- Local coverlet (XPlat Code Coverage, cobertura): `Shape.cs` 51/60 = 85.0%, identical to the
  committed result.
