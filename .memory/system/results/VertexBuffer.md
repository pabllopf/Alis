# Result: VertexBuffer.cs

File: `1_Presentation/Extension/Graphic/Sfml/src/Render/VertexBuffer.cs`
CoverageBefore: 0.0% (SonarCloud stale; local coverlet 72/80 = 90.0%)
CoverageAfter: 90.0% (72/80 lines, local coverlet; unchanged)
TestsAdded: 0 (both Draw target branches blocked by CSFML 3.0 ABI defects)
Commit: test: coverage VertexBuffer.cs
Status: BLOCKED_BY_PRODUCTION_CODE

## Summary

VertexBuffer.cs is the SFML vertex-buffer wrapper (16 complexity / 108 LOC per SonarCloud). The
committed suite (`VertexBufferTest.cs` + related coverage tests) covers 72/80 lines locally
(90.0%); targeted run: all VertexBuffer-filtered tests pass (net8.0).

Covered: all constructors, Create/Update/UpdateData, VertexCount, PrimitiveType, Usage,
NativeHandle, ToString, Dispose, and `Draw` with a mock `IRenderTarget` (neither concrete
branch).

## Remaining uncovered lines (4) — BLOCKED_BY_PRODUCTION_CODE

- 160-161 — `Draw` case `RenderWindow rw`: `sfRenderWindow_drawVertexBuffer(rw.CPointer,
  CPointer, ref marshaledStates)`. The marshalled `sfRenderStates` layout shifted in CSFML 3.0
  (documented in RenderWindow.md → SIGSEGV family); unreachable on the installed library.
- 163-164 — `Draw` case `RenderTexture rt`: `sfRenderTexture_drawVertexBuffer(...)`. Requires a
  constructed `RenderTexture`, impossible on the installed CSFML 3.0 (creation-ABI mismatch
  SIGSEGVs the host; documented in RenderTexture.md).

Identical blocker family to VertexArray.cs (same file's Draw branches). Both require production
interop fixes in `src/`; out of scope for coverage work.

## Verification

- Targeted run: all VertexBuffer tests pass (net8.0).
- Local coverlet: VertexBuffer.cs 72/80 lines (90.0%).
