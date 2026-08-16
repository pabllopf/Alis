# Result: RenderWindow.cs

File: `1_Presentation/Extension/Graphic/Sfml/src/Render/RenderWindow.cs`
CoverageBefore: 0.0% (SonarCloud; stale artifact)
CoverageAfter: 63.4% (102/161, local coverlet, hook-enabled run)
TestsAdded: 0 (already remediated in commit 23f34b13c)
Commit: test: coverage RenderWindow.cs
Status: BLOCKED_BY_PRODUCTION_CODE

## Summary

RenderWindow.cs is the SFML render-window wrapper over the CSFML graphics P/Invoke surface. The
committed `RenderWindowTest.cs` / `RenderWindowTests.cs` / `RenderWindowExecutionTests.cs` +
`RenderWindowMainThreadWorker.cs` + `SfmlTestBootstrap.cs` (main-thread startup-hook pattern)
cover 102/161 lines (63.4%). Remaining uncovered lines are all blocked by production ABI defects
vs the installed CSFML 3.0 library (same analysis as the original commit):

- 58-60/70-72/83-98 — RenderWindow constructors: CSFML 3.0 changed the window-creation ABI
  (extra `sfWindowState` parameter); the wrapper declares the CSFML 2.x signature, so direct
  construction produces a broken GL context. Bootstrap bypasses via `createFromHandle`.
- 294-307/316-343/355-368 — Draw(IDrawable) / Draw(Vertex[]) / Draw(Vertex[], start, count,
  type, states) bodies: the marshalled sfRenderStates layout shifted in CSFML 3.0 → SIGSEGV.
- 484-495 — SetIcon: ObjC NSException on the main-thread worker.
- 662 — WaitEvent: blocks indefinitely (no events are ever posted).
- 681-683 — InternalSetMousePosition: Vector2F vs sfVector2i ABI mismatch → SIGBUS.

## Verification

- Hook-enabled run (`ALIS_SFML_HOOK=1` + scratch reflection `DOTNET_STARTUP_HOOKS`, matching
  the approach documented in the NativeWindow result): `RenderWindow.cs` 102/161 = 63.4%,
  identical to the committed result. Native host crashes at process exit (known shutdown
  pattern) but coverage data is captured.
- No-hook run: 67 passed / 0 failed (execution tests degrade to guarded no-ops on CI).
