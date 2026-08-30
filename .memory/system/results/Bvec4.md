# Result: Bvec4.cs

File: `1_Presentation/Extension/Graphic/Sfml/src/Render/Bvec4.cs`
CoverageBefore: 0.0% (SonarCloud; 6 uncovered lines)
CoverageAfter: 100.0% (12/12 instrumented lines, local coverlet, Bvec4-filtered run)
TestsAdded: 4 (Bvec4CoverageTests.cs, plain [Fact])
Commit: test: coverage Bvec4.cs
Status: REMEDIATED

## Summary

Bvec4.cs is a plain struct with a 4-bool constructor and 4 public bool fields (`X`, `Y`,
`Z`, `W`), no logic.

Committed `Bvec4Test.cs` (`[RequireCSfmlSystemFact]`) and
`Bvec4RemainingCoverageTests.cs` (`[RequireCSfmlWindowsFact]`) already covered the
constructor, but both are gated on the CSFML native library which is not resolvable in the
CI/SonarCloud run, hence 0.0%.

Added `Bvec4CoverageTests.cs` with plain `[Fact]` tests: constructor assignment, default
zero (false) values, direct field round trip, and value-type copy independence.

## Verification

- Bvec4-filtered run: 7 passed / 0 failed, 0 skipped (net8.0).
- Local coverlet: Bvec4.cs 100.0% (12/12 instrumented lines, line-rate 1.0, branch-rate 1.0).