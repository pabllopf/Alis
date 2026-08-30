# Result: Ivec3.cs

File: `1_Presentation/Extension/Graphic/Sfml/src/Render/Ivec3.cs`
CoverageBefore: 0.0% (SonarCloud; 5 uncovered lines)
CoverageAfter: 100.0% (10/10 instrumented lines, local coverlet, Ivec3-filtered run)
TestsAdded: 4 (Ivec3CoverageTests.cs, plain [Fact])
Commit: test: coverage Ivec3.cs
Status: REMEDIATED

## Summary

Ivec3.cs is a plain struct with an int-triplet constructor and 3 public int fields (`X`,
`Y`, `Z`), no logic.

Committed `Ivec3Test.cs` and `Ivec3RemainingCoverageTests.cs` (both 1 test each, gated with
`[RequireCSfmlSystemFact]`/`[RequireCSfmlWindowsFact]`) already covered the constructor,
but they skip when the CSFML native library cannot be resolved (CI/SonarCloud run), hence
0.0%.

Added `Ivec3CoverageTests.cs` with plain `[Fact]` tests: constructor assignment, default
zero values, direct field round trip, and value-type copy independence.

## Verification

- Ivec3-filtered run: 7 passed / 0 failed, 0 skipped (net8.0).
- Local coverlet: Ivec3.cs 100.0% (10/10 instrumented lines, line-rate 1.0, branch-rate 1.0).