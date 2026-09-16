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

## Session 2026-09-15 (continued) findings

- 4_Operation/Ecs is now saturated for deterministic coverage. Remaining uncovered lines are:
  - Arity-8 range Run(Scene, Archetype, start, length) in Update.cs — needs a 9-component entity
    created as ONE deferred call; Scene.Create maxes at 8 and buffered Adds play back after the
    deferred subset update => BLOCKED_BY_PRODUCTION_API.
  - ComponentRegistry internal registration edge branches, Archetype.SameComponents mismatch,
    GameObjectExtensions.GetComp, Scene deferred-recursion-limit throws — no InternalsVisibleTo in
    Ecs src, so unreachable from tests; only reachable through deep public-API scenarios.
  - EnumerableHelpers/FastestStack/CommandBuffer "uncovered" lines are coverlet sequence-point
    artifacts (clamps/braces) or require >1B-element inputs.
- 4_Operation/Graphic (MacNativePlatform, GLShaderProgram, WebAssembly*) — 613 tests legitimately
  skip (WebOnly/WindowsOnly/LinuxOnly); the macOS/GL paths need a live GL context / main-thread
  window and are not testable off the main thread (same class of limitation as Glfw).

## Session 2026-09-15 (final) — Physic/Ecs definitive findings

- TimeOfImpact (public, 89.7%): the 14 remaining lines (164-167 max-iteration Failed,
  239-242 pushback Failed, 256-258 pushback cap, 299-306 root-find exit) are CCD bisection
  edge states that require precisely tuned sweeps; existing 280/294 coverage is the practical
  ceiling without deep per-shape tuning.
- SimpleCombiner 97-99 ("Skipping corrupt poly"): UNREACHABLE. SimplifyTools.MergeParallelEdges
  only merges while newNVertices > 3 (SimplifyTools.cs:216/228), so a merged polygon can never
  drop below 3 vertices -> the Count < 3 else branch is dead code.
- Island/WorldPhysic/ContactSolver/Collision remaining lines: internal methods (no
  InternalsVisibleTo) or contact/TOI simulation states (disabled contacts, ToiFlag) that need
  multi-body dynamic simulation setup.
- MarchingSquares/EarclipDecomposer/YuPengClipper remaining lines: specific marching/clipping
  edge geometry.

Conclusion: deterministic, CI-runnable coverage is saturated across the pure-managed codebase.
Every remaining gap requires one of: (a) InternalsVisibleTo / visibility changes in src,
(b) CI workflow changes (native libs / startup hooks), or (c) algorithm-specific edge geometry
with <3-line payoff.

## 2026-09-16 — Ui gate fix (largest unlock of the effort)

Fix: RequireCImguiSystemFactAttribute + RequireImNodesSystemFactAttribute now probe the bare
`cimgui.dylib` (self-contained universal binary). Result: Ui test project 10358 passed /
14 legitimate skips; Ui/src total 95.8% (22144/23118) local coverlet. Committed 8ab33a4de.

Residual Ui gaps verified BLOCKED (crash the native cimgui lib when called):
- ImPlotP8 PlotShaded S16/U16/S32/U32/S64/U64 ref overloads (24 lines) — native access violation.
- ImGuiP8 SliderFloat4 (both overloads) — native crash (SliderFloat/2/3 are safe and covered).
- ImGuiIOPtr KeysData/MouseClickedPos/MouseDragMaxDistanceAbs getters — Marshal.OffsetOf<ImGuiIo>
  reads with a zeroed block; struct exposes KeysData0..9 not "KeysData", so the getter throws; not
  worth covering. AddInputCharacter/AddKeyEvent/... native IO_* methods are context-dependent.

## 2026-09-16 (cont.) — verified crash-gated residuals

- SDL2 extension: 100.0% (2274/2274) local coverlet; Sdl.cs (1670 lines) now runs on CI via the
  gate fix; SdlImage/SdlTtf remain CI-blocked by framework/homebrew native deps.
- ImNodes EditorContextFree: crashes the test host (native access violation) when called with a
  real editor context -> residual ImNodes lines are crash-gated, matching the ImPlotP8 integer
  PlotShaded and ImGuiP8 SliderFloat4 findings.
- Conclusion re-confirmed: Ui is at its safe ceiling (95.8%); remaining ~4% crashes the bundled
  cimgui when the wrapper's struct/pointer marshalling mismatches the native ABI.
