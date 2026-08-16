# Result: ContextHandler.cs

File: `2_Application/Alis/src/Core/Ecs/Systems/Scope/ContextHandler.cs`
CoverageBefore: 70.3% (SonarCloud; Line: 71.4%, Branch: 57.1%)
CoverageAfter: 100.0% (336/336, local coverlet, ContextHandler-filtered run)
TestsAdded: 3 (ContextHandlerExecutionTests.cs: real frame-loop executions)
Commit: test: coverage ContextHandler.cs
Status: REMEDIATED

## Summary

ContextHandler.cs is the ECS game-loop handler (17 complexity / 196 LOC). Existing committed
tests covered the pre-loop init, Save/Load and the stopped-loop paths, but the entire Run frame
loop body (120-188: per-frame time bookkeeping, the fixed-time-step inner loop, the draw
pipeline and the frame-rate sleep) and the Preview tail (308-324: OnCalculate/draw/smooth
delta/frame-end) were uncovered — Run was always entered with IsRunning=false and Preview
always threw inside the fixed-step loop.

## Tests added (ContextHandlerExecutionTests.cs)

- `Run_WithRunningContext_ExecutesFrameLoop` — Run entered with IsRunning=true in preview mode
  with `TargetFrames=1000` (=> ~1ms frame budget), a background task exits after 60ms; the whole
  frame loop executes (fixed-step inner loop, draw pipeline, smooth delta, frame sleep).
- `Run_WithRunningContext_OverOneSecond_CoversAverageFrames` — runs the loop >1s to cover the
  average-frames-per-second branch (TotalFrames > 100 asserted).
- `Preview_WithInitializedGl_Completes` — full Preview without throwing, with fake OpenGL
  function pointers (glClearColor/glClear) installed via `Gl.Initialize` (preview mode skips
  platform init but RenderPreview still calls Gl clear commands).
- Class is `IDisposable` and restores `Gl.Initialize(null)` so
  `ContextHandlerTest.Preview_AfterInitPreview_ThrowsInvalidOperationException` (asserts the
  not-initialized behavior) is unaffected. Collections run sequentially per `.config/xunit.runner.json`.

## Verification

- Full Alis suite (excluding the pre-existing environment-dependent GraphicManagerBootstrapTests
  hook failures, verified failing before this change): 940 passed / 4 skipped / 0 failed (net8.0).
- Local coverlet: ContextHandler.cs 336/336 = 100.0% (before: 71.4% line).
