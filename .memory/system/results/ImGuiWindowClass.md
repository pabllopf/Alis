# Result: ImGuiWindowClass.cs

File: `1_Presentation/Extension/Graphic/Ui/src/ImGuiWindowClass.cs`
CoverageBefore: 0.0% (SonarCloud, stale artifact)
CoverageAfter: 100.0% (8/8, local coverlet, ImGuiWindowClass-filtered run)
TestsAdded: 0 (already covered by committed ImGuiWindowClassTest.cs + ImGuiWindowClassTests.cs)
Commit: test: coverage ImGuiWindowClass.cs
Status: ALREADY_REMEDIATED

## Summary

ImGuiWindowClass.cs is a plain struct (8 auto-properties only: `ClassId`,
`ParentViewportId`, `ViewportFlagsOverrideSet`, `ViewportFlagsOverrideClear`,
`TabItemFlagsOverrideSet`, `DockNodeFlagsOverrideSet`, `DockingAlwaysTabBar`,
`DockingAllowUnclassed`; no logic).

The committed `ImGuiWindowClassTest.cs` (2 tests) and `ImGuiWindowClassTests.cs` (19
tests), all `[RequireCImguiSystemFact]`, exercise every property's default value, set/get
round trip, and struct copy semantics. Local coverlet on the ImGuiWindowClass-filtered run
reports 100.0% (8/8 instrumented lines). The SonarCloud 0.0% is a stale artifact (tests not
yet uploaded).

## Verification

- ImGuiWindowClass-filtered run: 21 passed / 0 failed (net8.0).
- Local coverlet: ImGuiWindowClass.cs 100.0% (8/8 lines).
