# Result: SdlInputConst.cs

File: `1_Presentation/Extension/Graphic/Sdl2/src/Mapping/SdlInputConst.cs`
CoverageBefore: 0.0% (SonarCloud; const LOC artifact)
CoverageAfter: Not measurable (0 instrumented lines; coverlet emits no coverage for const classes)
TestsAdded: 0 (already covered by committed SdlInputConstTest.cs)
Commit: test: coverage SdlInputConst.cs
Status: ALREADY_REMEDIATED

## Summary

SdlInputConst.cs is a pure `static` const class (KScancodeMask, ButtonLeft/Middle/Right, and
related SDL input constants). It contains no executable statements, so coverlet produces no
`<class>` entry for it and line coverage is not a meaningful metric (SonarCloud's "uncovered
lines" are const declaration lines that can never be hit). The committed `SdlInputConstTest.cs`
(9 tests in the filter) asserts the constant values.

## Verification

- SdlInputConst filter (net8.0, Debug): 9 passed, 0 failed, 0 skipped.
- Coverlet: no `<class>` entry for SdlInputConst.cs → not instrumentable, nothing to remediate.
