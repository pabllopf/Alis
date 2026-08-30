# Result: StbTexteditRow.cs

File: `1_Presentation/Extension/Graphic/Ui/src/StbTexteditRow.cs`
CoverageBefore: 0.0% (SonarCloud; 6 uncovered lines)
CoverageAfter: 100.0% (12/12 instrumented lines, local coverlet, StbTexteditRow-filtered run)
TestsAdded: 3 (StbTexteditRowCoverageTests.cs, plain [Fact])
Commit: test: coverage StbTexteditRow.cs
Status: REMEDIATED

## Summary

StbTexteditRow.cs is a plain struct with 6 auto-properties (`X0`, `X1`,
`BaselineYDelta`, `Ymin`, `Ymax`, `NumChars`) and no logic.

Committed `StbTexteditRowTest.cs` (12 tests) and `StbTexteditRowRemainingCoverageTests.cs`
(12 tests) already covered every property but all of them use
`[RequireCImguiSystemFact]`, which skips when the `cimgui` native library cannot be
resolved (CI/SonarCloud run has no cimgui, hence 0.0%).

Added `StbTexteditRowCoverageTests.cs` with plain `[Fact]` tests: default zero values,
float/int round trip, and value-type copy independence.

## Verification

- StbTexteditRow-filtered run: 27 passed / 0 failed, 0 skipped (net8.0).
- Local coverlet: StbTexteditRow.cs 100.0% (12/12 instrumented lines, line-rate 1.0, branch-rate 1.0).