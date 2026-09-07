# ContextHandler.cs — Coverage Remediation Result

## File
`2_Application/Alis/src/Core/Ecs/Systems/Scope/ContextHandler.cs`

## Coverage
- Local (SonarCloud metric): 70.3% line
- Uncovered lines (local coverlet): 48

## Analysis Date
2026-09-07

## Uncovered Lines (local coverlet, ContextHandler filter, 31 pass / 4 skip)
- Run(): 137-142 (FPS counter branch), 153-166 (fixed-timestep loop body), 172-174 (OnAfterDraw/OnGui/OnRenderPresent), 177-188 (smooth-delta, frame timing, Thread.Sleep)
- Preview(): 308-310 (OnAfterDraw/OnGui/OnRenderPresent), 313-324 (smooth-delta, frame timing, Thread.Sleep)

## Investigation
All 48 uncovered lines are physically located AFTER `internalRuntime.OnDraw()` (Run line 171 / Preview line 307) OR require in-loop wall-clock time to accumulate (FPS branch, fixed-timestep loop) that cannot occur before OnDraw throws.

Verified empirically (scratch diagnostic, since removed):
- With `PreviewMode = true`, `GraphicManager.OnDraw()` → `RenderPreview()` → native `Gl.GlClear()` throws `InvalidOperationException` without a bound OpenGL context.
- `Preview()` therefore throws inside the single loop pass at `OnDraw`, and the tail lines (after OnDraw) plus the time-dependent branches are never reached.
- The existing `Run_WithoutGraphicsContext_ExecutesLoopBody_ThenThrows` test asserts `TotalFrames == 1` (exactly one iteration before the throw), confirming no time accumulates to hit the FPS/fixed-step branches.

## Blocking Cause
Reaching these lines requires either:
1. A native OpenGL graphics context (impossible in a headless xUnit process), or
2. Production code changes (creating a mockable graphics abstraction) — forbidden by source protection.

## Resolution
Status: BLOCKED_BY_PRODUCTION_CODE

No new tests can increase coverage of `ContextHandler.cs` without production changes or a native GL context. Existing tests (ContextHandlerTest.cs, ContextHandlerFullCoverageTest.cs, ContextHandlerAdditionalCoverageTests.cs, ContextHandlerRemainingCoverageTests.cs, ContextHandlerCoverageTests) already cover the reachable surface: 31 pass / 4 skipped (infinite-loop or GL-bound). No changes committed for this file this pass.
