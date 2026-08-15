# Result: Cursor.cs

File: `1_Presentation/Extension/Graphic/Sfml/src/Windows/Cursor.cs`
CoverageBefore: 0.0% (SonarCloud stale; local coverlet 14/36 = 38.9%)
CoverageAfter: 38.9% (14/36 lines, local coverlet; unchanged)
TestsAdded: 0 (pixel-based constructor segfaults the host; production interop defect)
Commit: test: coverage Cursor.cs
Status: BLOCKED_BY_PRODUCTION_CODE

## Summary

Cursor.cs is the SFML cursor wrapper (3 complexity / 57 LOC per SonarCloud). The committed
suite (`CursorTest.cs` / `CursorExecutionTests.cs` / `CursorRemainingCoverageTests.cs`) covers
14/36 lines locally (38.9%); targeted run: all Cursor-filtered tests pass (net8.0).

Covered: the `Cursor(CursorType)` system-cursor constructor, the CursorType enum surface,
Dispose/Destroy, and CPointer access. `CursorType` uses the value-type enum marshalling which
matches CSFML 3.0's `sfCursorType` ABI.

## Remaining uncovered lines (11) — BLOCKED_BY_PRODUCTION_CODE

- 190-202 — the entire `Cursor(byte[] pixels, Vector2F size, Vector2F hotspot)` pixel-based
  constructor body (GCHandle pinning, `sfCursor_createFromPixels` call, cleanup).

The native CSFML 3.0 signature is `sfCursor_createFromPixels(const uint8_t* pixels,
sfVector2u size, sfVector2u hotspot)` (Cursor.h:120) — the size and hotspot are `sfVector2u`
(2 x uint). The wrapper's DllImport declares `Vector2F size, Vector2F hotspot` (2 x float).
On x86-64 the structs are passed in registers with identical size, so the float bit patterns
are reinterpreted as huge uint dimensions; the native cursor-creation path then reads pixels
with garbage extents and segfaults the test host (probe verified: SIGSEGV/exit 138 at the
constructor, before any managed exception). Same struct-ABI mismatch family as Texture.cs
`sfVector2u` (documented in Texture.md). Covering it requires fixing the `src/` DllImport
signature; out of scope for coverage work.

## Verification

- Targeted run: all Cursor tests pass (net8.0).
- Local coverlet: Cursor.cs 14/36 lines (38.9%).
- Probe: `new Cursor(pixels, new Vector2F(4,4), new Vector2F(0,0))` segfaults the host.
