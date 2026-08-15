# Result: VertexArray.cs

File: `1_Presentation/Extension/Graphic/Sfml/src/Render/VertexArray.cs`
CoverageBefore: 0.0% (SonarCloud stale; local coverlet 84/92 = 91.3%)
CoverageAfter: 91.3% (84/92 lines, local coverlet; unchanged)
TestsAdded: 0 (both Draw target branches blocked by CSFML 3.0 ABI defects)
Commit: test: coverage VertexArray.cs
Status: BLOCKED_BY_PRODUCTION_CODE

## Summary

VertexArray.cs is the SFML vertex-array wrapper (16 complexity / 59 LOC per SonarCloud). The
committed suite (`VertexArrayTest.cs` / `VertexTest.cs` / `VertexRemainingCoverageTests.cs`)
covers 84/92 lines locally (91.3%); targeted run: 51 passed / 0 failed on
`Alis.Extension.Graphic.Sfml.Test` (net8.0).

Covered: all constructors, Append, indexer get/set, PrimitiveType, Bounds, Clear, Resize,
GetVertexCount, iterator surface, ToString, Dispose, and `Draw` with a mock `IRenderTarget`
(neither concrete branch).

## Remaining uncovered lines (4) — BLOCKED_BY_PRODUCTION_CODE

- 147-148 — `Draw` case `RenderWindow rw`: `sfRenderWindow_drawVertexArray(rw.CPointer,
  CPointer, ref marshaledStates)`. The marshalled `sfRenderStates` layout shifted in CSFML 3.0
  (documented in RenderWindow.md: "the marshalled sfRenderStates layout shifted in CSFML 3.0 →
  SIGSEGV"); the RenderWindow draw-family bodies are unreachable — the same P/Invoke family
  segfaults the host.
- 150-151 — `Draw` case `RenderTexture rt`: `sfRenderTexture_drawVertexArray(...)`. Requires a
  constructed `RenderTexture`, which is impossible on the installed CSFML 3.0: the creation-ABI
  mismatch SIGSEGVs the host (documented in RenderTexture.md, 2/93 lines reachable).

Both branches require production interop fixes in `src/` (sfRenderStates layout / RenderTexture
creation ABI); out of scope for coverage work.

## Verification

- Targeted run: 51 passed / 0 failed (net8.0).
- Local coverlet: VertexArray.cs 84/92 lines (91.3%).
