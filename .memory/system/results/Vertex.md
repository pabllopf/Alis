# Result: Vertex.cs

File: `1_Presentation/Extension/Graphic/Sdl2/src/Structs/Vertex.cs`
CoverageBefore: 0.0% (SonarCloud; 3 uncovered lines)
CoverageAfter: 100.0% (3/3 instrumented lines, local coverlet, Vertex-filtered run)
TestsAdded: 3 (VertexCoverageTests.cs, plain [Fact])
Commit: test: coverage Vertex.cs
Status: REMEDIATED

## Summary

Vertex.cs is a plain sequential-layout struct with 3 auto-properties (`Position`,
`Color`, `TexCoordinate`), no logic.

Committed `VertexTest.cs` (2 tests) uses `[RequireSdl2ImageFact]`, which skips when
`libsdl2_image` cannot be resolved (CI/SonarCloud run), hence 0.0%.

Added `VertexCoverageTests.cs` (3 plain `[Fact]`): default values, set/store round trip,
and value-type copy independence.

## Verification

- VertexCoverageTests-filtered run: 3 passed / 0 failed (net8.0).
- Local coverlet: Vertex.cs 100.0% (3/3 instrumented lines, line-rate 1.0).