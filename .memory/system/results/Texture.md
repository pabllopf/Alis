# Result: Texture.cs

File: `1_Presentation/Extension/Graphic/Sfml/src/Render/Texture.cs`
CoverageBefore: 0.0% (SonarCloud stale; local coverlet 228/254 = 89.8%)
CoverageAfter: 89.8% (228/254 lines, local coverlet; unchanged)
TestsAdded: 0 (window-based Update overloads corrupt the host; production interop defect)
Commit: test: coverage Texture.cs
Status: BLOCKED_BY_PRODUCTION_CODE

## Summary

Texture.cs is the SFML texture wrapper over the CSFML graphics P/Invoke surface (43 complexity /
238 LOC per SonarCloud). The committed suite (`TextureTest.cs` / `TextureTests.cs` /
`TextureExecutionTests.cs` / `TextureRemainingCoverageTests.cs` — commit 295f80577) covers
228/254 lines locally (89.8%); targeted run: 177 passed / 0 failed on
`Alis.Extension.Graphic.Sfml.Test` (net8.0).

Covered: all constructors (file, area, stream, memory, image, copy — with the width/height
constructor's `LoadingFailedException` throw path), Smooth/Repeated/Srgb getters, MaximumSize,
NativeHandle, CopyToImage, pixel/image/width-height pixel Updates, GenerateMipmap, Swap, Bind,
ToString, Destroy. Line 70 (the closing brace after the width/height ctor throw) is unreachable
by construction.

## Remaining uncovered lines (13) — BLOCKED_BY_PRODUCTION_CODE

- 364-366, 376-378 — `Update(Window window)` and `Update(Window window, uint x, uint y)`.
- 386-388, 398-400 — `Update(RenderWindow window)` and `Update(RenderWindow window, uint x, uint y)`.

These four overloads were investigated with the repo's main-thread startup-hook pattern
(`SfmlTestBootstrap` + `RenderWindowMainThreadWorker`, used successfully for RenderWindow.cs):
a probe confirmed the wrappers execute on the main thread, but every instrumentation run
crashes the test host at shutdown with `BadImageFormatException: Bad IL range` in
`System.GC.RunFinalizers` — native heap corruption.

### Root cause — CSFML 3.0 ABI change (production defect)

The installed CSFML 3.0 declares (Texture.h:273, 283):

    void sfTexture_updateFromWindow(sfTexture*, const sfWindow*, sfVector2u offset);
    void sfTexture_updateFromRenderWindow(sfTexture*, const sfRenderWindow*, sfVector2u offset);

i.e. the offset is a single `sfVector2u` struct. The wrapper's DllImports declare the CSFML 2.x
signature `(IntPtr texture, IntPtr window, uint x, uint y)` (Texture.cs:620-628) — two separate
`uint` arguments. On x86-64 the struct occupies one register (upper 32 bits of `x` become
`offset.y`), so the native copy target offset is garbage, and `glCopyTexSubImage2D` writes the
window pixels to a random texture offset → heap corruption. The corruption is timing-dependent:
plain runs pass, coverlet-instrumented runs crash intermittently at process shutdown. Same ABI
defect family as RenderWindow.cs (sfWindowState/sfVector2u changes, documented in
RenderWindow.md).

Covering the overloads requires fixing the `src/` DllImport signatures to marshal `sfVector2u`;
out of scope for coverage work.

## Verification

- Targeted run: 177 passed / 0 failed (net8.0).
- Local coverlet: Texture.cs 228/254 lines (89.8%).
- Probe: main-thread window update confirmed reachable but corrupts the host (ABI mismatch).
