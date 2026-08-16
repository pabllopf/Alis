# Result: Transformable.cs

File: `1_Presentation/Extension/Graphic/Sfml/src/Render/Transformable.cs`
CoverageBefore: 0.0% (SonarCloud; stale artifact)
CoverageAfter: 100.0% (72/72, local coverlet)
TestsAdded: 0 (already remediated in commit 2f79dcd08)
Commit: test: coverage Transformable.cs
Status: ALREADY_REMEDIATED

## Summary

Transformable.cs is the SFML transformable wrapper (16 complexity / 112 LOC). Committed
`TransformableTest.cs` + `TransformableTests.cs` cover 72/72 lines = 100.0%.

## Verification

- `dotnet test Alis.Extension.Graphic.Sfml.Test.csproj -c Debug -f net8.0 --filter
  "FullyQualifiedName~Transformable"`: 56 passed, 0 failed, 0 skipped.
- Local coverlet (XPlat Code Coverage, cobertura): `Transformable.cs` 72/72 lines = 100.0%.
