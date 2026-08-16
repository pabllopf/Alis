# Result: Scene.cs

File: `4_Operation/Ecs/src/Scene.cs`
CoverageBefore: 91.7% (SonarCloud); local coverlet baseline 94.3% line (975/1034)
CoverageAfter: 98.8% line (1022/1034, local coverlet, net8.0)
TestsAdded: 6 (SceneDeferredCoverageTests.cs)
Commit: test: coverage Scene.cs
Status: PARTIALLY_REMEDIATED

## Summary

Scene.cs (2045 LOC, ECS scene/world). Local coverlet showed 58 uncovered lines across the
deferred structural-change paths, the internal AddComponent/RemoveComponent APIs and the
command-buffer recursion machinery.

## Work performed

Added 6 tests to `SceneDeferredCoverageTests.cs` (xUnit, net8.0):
- `Create_WhileDisallowed_DefersAndResolves` / `Create_WhileDisallowed_WithManyComponents_DefersAndResolves`
  — `EnterDisallowState` + the 2..8-component `Create` overloads; `ExitDisallowState(null, false)`
  resolves the deferred archetypes (620-625, 816-820, 913-917, 1011-1015, 1116-1120, 1360-1364,
  1494-1498) and drains the command buffer (633-634, 639).
- `AddComponent_WhileDisallowed_DefersOperation` / `RemoveComponent_WhileDisallowed_DefersOperation`
  — deferred entity component mutations through the public `Add<T>`/`Remove<T>` APIs.
- `AddComponent_Direct_ResolvesArchetype` / `RemoveComponent_Direct_ResolvesArchetype` — the
  internal non-generic APIs (1715-1721, 1733-1740) via the InternalsVisibleTo surface, with the
  shared-temp-buffer protocol.

## Remaining uncovered lines — BLOCKED_BY_PRODUCTION_CODE

- 635-637, 680-682 — command-buffer / deferred-create recursion-limit throws (>200 nested
  deferred operations): require 200+ generations of nested structural-change events, which
  cannot be produced deterministically without bespoke event-chain components.
- 1881-1883, 1936-1938 — generic remove-event write/dispatch: requires the generated
  RemoveGenericComp event machinery on a component type.

## Verification

- Targeted run: 6 passed / 0 failed (net8.0).
- Merged suite: 354 passed / 0 failed (net8.0, Scene filter).
- Local coverlet: 1022/1034 = 98.8% line (was 94.3%).
