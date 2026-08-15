# Result: Context.cs

File: `1_Presentation/Extension/Graphic/Sfml/src/Windows/Context.cs`
CoverageBefore: 0.0% (SonarCloud stale; local coverlet 34/40 = 85.0%)
CoverageAfter: 85.0% (34/40 lines, local coverlet; unchanged)
TestsAdded: 0 (finalizer catch block unreachable; production code)
Commit: test: coverage Context.cs
Status: BLOCKED_BY_PRODUCTION_CODE

## Summary

Context.cs is the SFML OpenGL context wrapper (7 complexity / 47 LOC per SonarCloud). The
committed suite (`ContextTest.cs` / `ContextExecutionTests.cs` + ContextSettings coverage)
covers 34/40 lines locally (85.0%); targeted run: all Context-filtered tests pass (net8.0).

Covered: constructor, Settings, `Global` lazy singleton (both null and non-null paths),
finalizer happy path (`sfContext_destroy` succeeds), SetActive, ToString, and the
`ContextSettings` value type.

## Remaining uncovered lines (3) — BLOCKED_BY_PRODUCTION_CODE

- 96-98 — the `~Context()` finalizer's `catch { }` block. It only executes when
  `sfContext_destroy(myThis)` throws inside a GC finalizer. With a live CSFML library the
  destroy call cannot throw deterministically; forcing it requires corrupting the readonly
  `myThis` handle via reflection (forbidden by AOT rules) or modifying `src/`. The same
  unreachable-catch family applies to every `CriticalFinalizerObject` in the module.

## Verification

- Targeted run: all Context tests pass (net8.0).
- Local coverlet: Context.cs 34/40 lines (85.0%).
