# Result: View.cs

File: `1_Presentation/Extension/Graphic/Sfml/src/Render/View.cs`
CoverageBefore: 0.0% (SonarCloud; stale artifact)
CoverageAfter: 97.9% (47/48 lines, local coverlet; unchanged)
TestsAdded: 0 (1 line unreachable: Reset closing brace behind a removed CSFML 3.0 export)
Commit: test: coverage View.cs
Status: BLOCKED_BY_PRODUCTION_CODE

## Summary

View.cs is the SFML view wrapper over the CSFML graphics surface (48 instrumented lines:
default/rect/copy constructors, Center/Size/Rotation/Viewport get-set, Reset, Move, Rotate,
Zoom, ToString, Destroy). `sfView_create` is unchanged in CSFML 3.0 and a view is a pure CPU
object, so the committed `ViewTest.cs` / `ViewExecutionTests.cs` already cover 47/48 lines
(97.9%) on a desktop host.

## Remaining uncovered line (1) — BLOCKED_BY_PRODUCTION_CODE

Line 156 is the closing brace of `Reset(FloatRect)`. CSFML 3.0 removed the `sfView_reset`
export (the header `/opt/homebrew/opt/csfml/include/CSFML/Graphics/View.h` only declares
`sfView_move`/`sfView_rotate` in that area), so the wrapper's P/Invoke at View.cs:155 throws
`EntryPointNotFoundException` at the call boundary and the method-end sequence point is never
reached. The committed `ViewExecutionTests.cs` already asserts this exact behavior
(`Assert.Throws<EntryPointNotFoundException>(() => view.Reset(...))`). Deterministic coverage
requires a production change (removed-API handling), out of scope.

## Verification

- View filter (net8.0, Debug): 66 passed, 0 failed, 0 skipped.
- Local coverlet: View.cs 47/48 lines (97.9%); line 156 unreachable.
