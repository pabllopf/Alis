# Result: ComponentRegistry.cs

File: `4_Operation/Ecs/src/Kernel/ComponentRegistry.cs`
CoverageBefore: 92.8% (SonarCloud; Line: 94.1%, Branch: 89.6%, 7 uncovered lines)
CoverageAfter: 94.1% (224/238, local coverlet, full Ecs suite; unchanged)
TestsAdded: 0 (all 7 remaining lines are unreachable)
Commit: test: coverage ComponentRegistry.cs
Status: BLOCKED_BY_PRODUCTION_CODE

## Summary

ComponentRegistry.cs contains the `Component` static registry (32 complexity / 158 LOC). The
committed suite (ComponentRegistryTests + the world/archetype suites, 4185 tests) covers
registration, lookup, factory creation, id assignment and the per-component tables.

## Remaining uncovered lines (7) — BLOCKED_BY_PRODUCTION_CODE

- 85, 100, 229 — `return null!;` statements immediately after `Throw_ComponentTypeNotInit(t)`,
  which throws on every path (null/void, uninitialized IComponentBase, uninitialized other).
  Dead returns.
- 141-142, 184-185 — the `ushort.MaxValue` component-count overflow guards in
  `GetExistingOrSetupNewComponent<T>` and the non-generic overload. Reaching them requires
  either 65535 unique real component types (impossible to fabricate under AOT rules) or
  manipulating the `private static _nextComponentId` counter (private, reflection forbidden).

## Verification

- Full Ecs suite: same pre-existing failure set as baseline (CommandBufferCoverageTest).
- Local coverlet: ComponentRegistry.cs 224/238 = 94.1% (matches SonarCloud line metric).
