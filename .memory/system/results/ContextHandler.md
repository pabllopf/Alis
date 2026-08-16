# Result: ContextHandler.cs

File: `pabllopf-official_alis:2_Application/Alis/src/Core/Ecs/Systems/Scope/ContextHandler.cs`
CoverageBefore: 70.3% (SonarCloud Line: 71.4%, Branch: 57.1%, 48 uncovered lines / 6 uncovered conditions)
CoverageAfter: 100.0% (336/336 lines, 100% branches, local coverlet, all suites combined)
TestsAdded: 1 (ContextHandlerAdditionalCoverageTests.cs: Run_WithoutGraphicsContext_ExecutesLoopBody_ThenThrows)
Commit: test: coverage ContextHandler.cs
Status: COMPLETE

## Summary

ContextHandler.cs is the ECS game-loop driver (17 complexity / 196 ncloc). SonarCloud
reported 70.3% (48 uncovered lines): the entire `Run()` main-loop body (120-188) and the
`Preview()` tail after `OnDraw` (308-324). `OnDraw` -> `Gl.GlClearColor` throws
`InvalidOperationException` deterministically without a GL context, so prior committed
suites (ContextHandlerTest/FullCoverage/RemainingCoverage, commit 47f5a07f2) could only
reach the loop with `Run()` pre-stopped or rely on skipped loop tests.

Mid-session, a concurrent agent committed e11a6c81b (`ContextHandlerExecutionTests.cs`),
which fakes `Gl.Initialize(FakeProcAddress)` so `OnDraw` succeeds, running the real loop
with an external `Exit()` stopper — covering the FPS/average-frames branch (1.1s run), the
fixed-time-step while loop, smooth-delta and frame-duration/Thread.Sleep lines in both
`Run()` and `Preview()`.

This session added ContextHandlerAdditionalCoverageTests.cs, a deterministic
sleep-free/thread-free test that executes the `Run()` loop body synchronously and verifies
the `InvalidOperationException` propagation path plus frame/time accounting
(TotalFrames, FrameCount, DeltaTime/UnscaledDeltaTime, Time/TimeAsDouble scaling).

## Verification

- Filtered run `FullyQualifiedName~ContextHandler`: 34 passed, 4 skipped (net8.0).
- Full Alis.Test suite: 942 passed; only 3 pre-existing `GraphicManagerBootstrapTests`
  failures (missing native SDL2 libs, environment, unrelated to ContextHandler).
- Local coverlet (XPlat, cobertura): ContextHandler.cs 336/336 lines = 100.0%, branch 100%.

## Blocked lines

None. All previously-uncovered lines (Run loop body 120-188, Preview tail 308-324) are
now covered via the fake-GL execution suites.
