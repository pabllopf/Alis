# Result: ImPlotInputMap.cs

File: `1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotInputMap.cs`
CoverageBefore: 0.0% (SonarCloud, stale artifact)
CoverageAfter: 100.0% (24/24, local coverlet, ImPlotInputMap-filtered run)
TestsAdded: 0 (already covered by committed ImPlotInputMapTests.cs / ImPlotInputMapTest.cs)
Commit: test: coverage ImPlotInputMap.cs
Status: ALREADY_REMEDIATED

## Summary

ImPlotInputMap.cs is a pure managed value-type struct (12 auto-properties, 24 complexity /
18 LOC per SonarCloud) mapping ImGui mouse buttons and modifier flags for plot input.

The committed `ImPlotInputMapTests.cs` (14 tests, `[RequireImNodesSystemFact]`) and
`ImPlotInputMapTest.cs` (24 tests, `[RequireCImguiSystemFact]`) already exercise every
getter and setter. The SonarCloud 0.0% is a stale artifact (tests not yet uploaded); local
coverlet on the filtered run reports 100.0% (24/24 instrumented lines, all 12 properties
hit).

No native interop is involved; the struct is fully deterministic and testable without
producing code changes.

## Verification

- ImPlotInputMap-filtered run: 38 passed / 0 failed / 0 skipped (net8.0, cimgui available).
- Local coverlet: ImPlotInputMap.cs 24/24 lines = 100.0%.
