# Result: Sound.cs

File: `1_Presentation/Extension/Graphic/Sfml/src/Audios/Sound.cs`
CoverageBefore: 0.0% (SonarCloud; stale artifact)
CoverageAfter: 0.0% (0/93 lines, local coverlet; unchanged)
TestsAdded: 0 (instance creation impossible: CSFML 3.0 changed sfSound_create to take a buffer)
Commit: test: coverage Sound.cs
Status: BLOCKED_BY_PRODUCTION_CODE

## Summary

Sound.cs is the SFML sound wrapper over the CSFML audio P/Invoke surface (93 instrumented
lines: default/buffer/copy constructors, SoundBuffer, Status, Loop, Pitch, Volume,
PlayingOffset, Position, RelativeToListener, MinDistance, Attenuation, Play/Pause/Stop,
ToString, Destroy).

The installed CSFML 3.0 library changed the creation ABI: the header at
`/opt/homebrew/opt/csfml/include/CSFML/Audio/Sound.h` declares

    sfSound* sfSound_create(const sfSoundBuffer* buffer);

while the wrapper at Sound.cs:301 declares the CSFML 2.x no-argument form
`sfSound_create()`. Calling it passes no buffer argument, the native function dereferences a
garbage pointer, and the test host dies with a crash (`Serie de pruebas anulada`) — verified
with a minimal probe of just `new Sound()` + `Status` on net8.0 Debug. Every instance member
(93 lines) is therefore unreachable on the installed library.

Deterministic coverage requires a production fix of the `sfSound_create` declaration (CSFML
3.0 ABI, buffer argument), out of scope.

## Verification

- Minimal probe (`new Sound()` + `Status`): test host crash (run aborted).
- CSFML 3.0 header inspected: `sfSound_create(const sfSoundBuffer*)` mismatch confirmed.
- No Sound test file was committed (generated tests were removed after the crash).
