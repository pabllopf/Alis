# Result: Bvec2.cs

File: `1_Presentation/Extension/Graphic/Sfml/src/Render/Bvec2.cs`
CoverageBefore: 0.0% (SonarCloud; 4 uncovered lines)
CoverageAfter: 100.0% (4/4 instrumented lines, local coverlet, Bvec2-filtered run)
TestsAdded: 3 (Bvec2CoverageTests.cs, plain [Fact])
Commit: test: coverage Bvec2.cs
Status: REMEDIATED

## Summary

Bvec2.cs is a plain sequential-layout struct with 2 public boolean fields (`X`, `Y`) and a
2-arg constructor.

Committed `Bvec2Test.cs` (2 tests) and `Bvec2RemainingCoverageTests.cs` (1 test) already
covered the type but all use `[RequireCSfmlSystemFact]`/`[RequireCSfmlWindowsFact]`, which
skip when the SFML native libraries cannot be resolved (CI/SonarCloud run), hence 0.0%.

Added `Bvec2CoverageTests.cs` (3 plain `[Fact]`): constructor component mapping, default
initialization defaults, and field mutation.

## Verification

- Bvec2CoverageTests-filtered run: 3 passed / 0 failed (net8.0).
- Local coverlet: Bvec2.cs 100.0% (4/4 instrumented lines, line-rate 1.0).