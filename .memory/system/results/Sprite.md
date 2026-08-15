# Result: Sprite.cs

File: `1_Presentation/Extension/Graphic/Sfml/src/Render/Sprite.cs`
CoverageBefore: 0.0% (SonarCloud; stale artifact)
CoverageAfter: 0.0% (0 instrumented lines hit; instance construction crashes the host)
TestsAdded: 0 (instance creation impossible: CSFML 3.0 changed sfSprite_create to take a texture)
Commit: test: coverage Sprite.cs
Status: BLOCKED_BY_PRODUCTION_CODE

## Summary

Sprite.cs is the SFML sprite wrapper (Transformable-derived) over the CSFML graphics P/Invoke
surface (constructors, Color, Texture, TextureRect, GetLocalBounds, GetGlobalBounds, Draw,
Destroy, plus the inherited transform members). The committed `SpriteTest.cs` / `SpriteTests.cs`
are reflection-only (existence/read-write probes) and never construct a Sprite instance.

The installed CSFML 3.0 library changed the creation ABI: the header at
`/opt/homebrew/opt/csfml/include/CSFML/Graphics/Sprite.h` declares

    sfSprite* sfSprite_create(const sfTexture* texture);

while every wrapper constructor at Sprite.cs:52-90 calls the CSFML 2.x no-argument form
`sfSprite_create()`. A minimal probe of `new Sprite()` + `Color` kills the test host
(`Serie de pruebas anulada`) — the native function dereferences the garbage texture argument.
Every instance member is therefore unreachable on the installed library, which is why the
committed tests stay at reflection level.

Deterministic coverage requires a production fix of the `sfSprite_create` declarations
(CSFML 3.0 ABI, texture argument), out of scope.

## Verification

- Minimal probe (`new Sprite()` + `Color`): test host crash (run aborted).
- CSFML 3.0 header inspected: `sfSprite_create(const sfTexture*)` mismatch confirmed.
- No Sprite test file was committed (generated probe removed after the crash).
