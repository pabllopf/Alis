# Result: Image.cs

File: `1_Presentation/Extension/Graphic/Sfml/src/Render/Image.cs`
CoverageBefore: 0.0% (SonarCloud; stale artifact)
CoverageAfter: 95.6% (87/91, local coverlet)
TestsAdded: 0 (already remediated in commit e2ce3efd5)
Commit: test: coverage Image.cs
Status: BLOCKED_BY_PRODUCTION_CODE

## Summary

Image.cs is the SFML image wrapper (27 complexity / 162 LOC). Committed `ImageTest.cs` /
`ImageExecutionTests.cs` / `ImageRemainingCoverageTests.cs` cover 87/91 lines (95.6%).

## Remaining uncovered (4 lines) — BLOCKED_BY_PRODUCTION_CODE

Lines 73-74 / 153-154: `LoadingFailedException` throw paths in `Image(uint, uint, Color)` and
`Image(uint, uint, byte[])`. CSFML never returns IntPtr.Zero for these (zero-size accepted; only
native OOM produces null), so the paths are unreachable without a production change.

## Verification

- `dotnet test Alis.Extension.Graphic.Sfml.Test.csproj -c Debug -f net8.0 --filter
  "FullyQualifiedName~Image"`: 46 passed, 0 failed, 0 skipped.
- Local coverlet (XPlat Code Coverage, cobertura): `Image.cs` 87/91 = 95.6%, identical to the
  committed result.
