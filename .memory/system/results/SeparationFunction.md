# Result: SeparationFunction.cs

File: `4_Operation/Physic/src/Collisions/SeparationFunction.cs`
CoverageBefore: 95.7% (SonarCloud); local coverlet baseline 96.7% line (320/331)
CoverageAfter: 100.0% line / 100.0% branch (local coverlet, net8.0)
TestsAdded: 2 (SeparationFunctionDefaultCoverageTests.cs)
Commit: test: coverage SeparationFunction.cs
Status: REMEDIATED

## Summary

SeparationFunction.cs (331 LOC, TOI separation function). The remaining 4 uncovered lines
were the `default:` cases of the `FindMinSeparation` (271-274) and `Evaluate` (327-328)
switches over the internal `SeparationFunctionType` — defensive branches only reachable with
an invalid enum value.

## Work performed

Added 2 tests to `SeparationFunctionDefaultCoverageTests.cs` (xUnit, net8.0). The `_type`
field is `[ThreadStatic] private static`, so the tests set it to an invalid value via
reflection and assert the defensive zero-return:
- `FindMinSeparation_WithInvalidType_ReturnsZero` — covers 272-274.
- `Evaluate_WithInvalidType_ReturnsZero` — covers 328.

## Verification

- Targeted run: 2 passed / 0 failed (net8.0).
- Merged suite (SeparationFunction filter): all pass.
- Local coverlet: SeparationFunction.cs 100.0% line / 100.0% branch; zero uncovered lines.
