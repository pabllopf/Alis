# Result: RenderTexture.cs

File: `1_Presentation/Extension/Graphic/Sfml/src/Render/RenderTexture.cs`
CoverageBefore: 0.0% (SonarCloud; stale artifact)
CoverageAfter: 2.2% (2/93 lines, local coverlet; unchanged)
TestsAdded: 0 (instance creation impossible: CSFML 3.0 creation-ABI mismatch SIGSEGVs the host)
Commit: test: coverage RenderTexture.cs
Status: BLOCKED_BY_PRODUCTION_CODE

## Summary

RenderTexture.cs is the SFML off-screen render-target wrapper (93 instrumented lines). The
installed CSFML 3.0 library changed the creation ABI: the header at
`/opt/homebrew/opt/csfml/include/CSFML/Graphics/RenderTexture.h` declares

    sfRenderTexture* sfRenderTexture_create(sfVector2u size, const sfContextSettings* settings);

while the wrapper at RenderTexture.cs:482 declares the CSFML 2.x form
`sfRenderTexture_create(uint width, uint height, bool depthBuffer)`. A native probe recorded
in the committed `RenderTextureExecutionTests.cs` confirmed that the mismatched call
dereferences the height argument as a `ContextSettings*` pointer and kills the test host with
a SIGSEGV, so no `RenderTexture` instance can be created and all 91 instance-member lines
(ctors, Repeated/Smooth/Size/Texture/DefaultView, views, maps, Clear/Draw, GL states,
SetActive, GenerateMipmap, Display, ToString, Destroy) are unreachable.

The only safely reachable surface is the static `MaximumAntialiasingLevel` property
(2/93 lines): the CSFML 3.0 library renamed the symbol to
`sfRenderTexture_getMaximumAntiAliasingLevel`, so the wrapper's P/Invoke throws
`EntryPointNotFoundException` at the boundary, which the committed tests assert.

Deterministic coverage requires a production fix of the `sfRenderTexture_create` /
`sfRenderTexture_createWithSettings` declarations (CSFML 3.0 ABI), out of scope.

## Verification

- RenderTexture filter (net8.0, Debug): 46 passed, 0 failed, 0 skipped (no-hook CI mode).
- Local coverlet: RenderTexture.cs 2/93 lines (2.2%); 91 instance lines blocked.
- CSFML 3.0 header inspected; creation signature mismatch confirmed at compile time.
