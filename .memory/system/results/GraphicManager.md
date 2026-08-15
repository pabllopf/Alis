# Result: GraphicManager.cs

File: `2_Application/Alis/src/Core/Ecs/Systems/Manager/Graphic/GraphicManager.cs`
CoverageBefore: 0.0% (SonarCloud; stale artifact; local 65.6% = 145/221)
CoverageAfter: 97.3% (215/221 lines, local coverlet, hook-enabled run)
TestsAdded: 4 (GraphicManagerBootstrapTests.cs + GraphicManagerBootstrap.cs + StartupHook.cs)
Commit: test: coverage GraphicManager.cs
Status: PARTIALLY_REMEDIATED

## Summary

GraphicManager.cs is the ECS graphics manager (465 LOC; 221 instrumented lines). The
committed preview-mode suite covered 145/221 (65.6%); the full platform init/draw paths were
unreachable because AppKit window creation requires the process main thread while xUnit runs
tests on worker threads. This session added the established startup-hook pattern to the
Alis test project: `StartupHook.cs` + `GraphicManagerBootstrap.cs` run `OnInit` (default-size,
custom-size, titled, iconed variants) and `OnDraw` (with a world containing Camera, Sprite and
BoxCollider, physics debug enabled) on the main thread, plus a preview-mode `OnDraw`. Local
coverlet (net8.0, Debug, hook-enabled, GraphicManager filter — 72 tests) measures 215/221
lines (97.3%).

## Remaining uncovered lines (6) — BLOCKED_BY_PRODUCTION_CODE

- 203-205 — `Context.Exit()` branch: requires `platform.PollEvents()` to return false, i.e. a
  closed/exit-requested window, not deterministically drivable.
- 300-302 — `BuildNewKeys` pressed-key branch: requires an actually pressed key, not drivable.

## Verification

- GraphicManager filter (net8.0, Debug, hook enabled): 72 passed, 0 failed, 0 skipped.
- Local coverlet: GraphicManager.cs 215/221 lines (97.3%); 6 lines blocked.
- No-hook CI mode: bootstrap tests degrade to guarded no-ops.
