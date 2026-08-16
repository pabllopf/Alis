# Result: Monitor.cs

File: `1_Presentation/Extension/Graphic/Glfw/src/Structs/Monitor.cs`
CoverageBefore: 60.0% (SonarCloud; Line: 52.4% = 22/42, Branch: 100.0%)
CoverageAfter: 100.0% (42/42 lines, local coverlet hook-enabled; +47.6%)
TestsAdded: 4 (native-backed Monitor tests in MonitorTests.cs)
Commit: test: coverage Monitor.cs
Status: REMEDIATED

## Summary

Monitor.cs is a thin struct wrapper over a native GLFW monitor handle (11 complexity / 46 LOC).
The committed suite (MonitorTests.cs, MonitorRemainingCoverageTests.cs,
MonitorAdditionalRemainingCoverageTests.cs) already covered None, Equals(object/IEquatable),
GetHashCode, the ==/!= operators and ToString. The only uncovered members were the three
native-backed accessors: `WorkArea` (lines 121-124), `ContentScale` (lines 136-139) and
`UserPointer` (lines 149-150) — 10 lines total, exactly matching SonarCloud's report.

## Work performed

Filled the empty shell `MonitorTests` class in `test/MonitorTests.cs` with 4 xUnit facts that
exercise the native-backed members against the real GLFW monitor captured by
`GlfwTestBootstrap.PrimaryMonitor` on the process main thread:
- `WorkArea_Get_ReturnsValidRectangle` → non-empty work-area rectangle.
- `ContentScale_Get_IsPositive` → positive scale on both axes.
- `UserPointer_SetThenGet_RoundTrips` → set/readback of a non-zero pointer.
- `UserPointer_SetZero_IsSafe` → clearing the user pointer round-trips.

All tests are `[RequireGlfwFact]`-gated and no-op when the startup hook is not installed
(`GlfwTestBootstrap.Ready` is false on CI), so they are harmless no-ops in CI without a hook.

## Verification

- Targeted run (no hook, CI-equivalent): 35 passed / 0 failed (net8.0).
- Hook-enabled local run (`ALIS_GLFW_HOOK=1` + scratch reflection `DOTNET_STARTUP_HOOKS`):
  38 passed / 0 failed; Monitor.cs 42/42 lines = 100.0%.
