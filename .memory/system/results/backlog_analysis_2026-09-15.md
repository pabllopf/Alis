# Coverage Backlog Analysis — 2026-09-15

Fresh SonarCloud cache: `.memory/system/cache/sonarcloud_cache_20260915_074747.json`
(main project `pabllopf-official_alis`, branch master, 1473 files).

## Systemic findings

1. Most 0% extension files (Sfml, Sdl2, Ui, Glfw) are 0% because the macos-15-intel
   SonarCloud runner has no native libs, so the `Require*Fact` tests skip. The Sdl2
   gate was fixed on 2026-09-15 (`test: Sdl.cs`). Sfml/Ui/Glfw gates still need the
   same bundled-native resolution fix.
2. Some "uncovered lines" are coverlet/Sonar brace artifacts. Example: Network
   `Internal/Events.cs` reports 39 uncovered lines, but they are the `}` lines closing
   each `if (IsEnabled())` block; the `WriteEvent` call lines ARE covered (the
   EventListener tests assert `EventCount > 0`). Not actionable.
3. `4_Operation/Ecs/src/Redifinition/Gen2GcCallback.cs` (43.8%) is a GC-finalizer
   callback kept alive by a static list; its finalizer path is not deterministically
   reachable from tests. BLOCKED_BY_PRODUCTION_CODE for deterministic coverage.

## Genuinely actionable pure-managed gaps (run on CI)

### 2_Application/Alis/src/Core/Ecs/Systems/Scope/ContextHandler.cs (70.3%, 48 uncovered)
Local coverlet (Alis.Test, 951 passed / 4 skipped) uncovered:
- 137-142  Run() one-second FPS averaging block
- 153-166  Run() fixed-timestep while loop
- 172-188  Run() draw calls, smooth delta, frame sleep
- 308-324  (same loop body region)
All are inside `Run()`'s `while (_context.IsRunning)` body. Existing tests call
`handler.Exit()` before `Run()`, so the loop body never executes. Needs a test that
lets the loop run one or two iterations and exit (preview mode auto-exit or a manager
that flips IsRunning). Risk: infinite loop if the exit condition is not met.

### 2_Application/Alis/src/Core/Ecs/Systems/Manager/Graphic/GraphicManager.cs (65%, 76 uncovered)
Local coverlet uncovered: 132-169 (OnInit), 197-255 (OnDraw/RenderPreview),
295-306 (BuildNewKeys), 434-436. Requires a platform/context for render paths.

### 4_Operation/Ecs/src/GameObject.cs — DONE (47.3% -> 91.3%)
### 4_Operation/Ecs/src/Redifinition/BitOperations.cs — DONE (31% -> 100%)

## Recommended next targets (deterministic, pure managed)
- 1_Presentation/Extension/Updater/src/UpdateManager.cs (89.8%, 34) — verify no network.
- 4_Operation/Physic DTSweep.cs (85%, 88) — pure Delaunay math.
- 2_Application ContextHandler / GraphicManager (above).
- Extension native gates (Sfml `RequireCSfml*FactAttribute`, Ui, Glfw) — mirror the
  Sdl2 `{name}.dylib` fix so existing tests stop skipping on CI.
