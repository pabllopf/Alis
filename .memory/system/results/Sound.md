# Coverage Worker Result
File: 1_Presentation/Extension/Graphic/Sfml/src/Audios/Sound.cs
CoverageBefore: 0.0% (SonarCloud CI)
CoverageAfter: 0.0% (0/106 lines, no executable path; verified via XPlat Code Coverage + isolated probes)
TestsAdded: 0
Commit: (none)
Status: BLOCKED_BY_NATIVE
Details:
- Sound.cs wraps sfSound natives (default/buffer/copy ctors, SoundBuffer attachment, Status, Loop, Pitch, Volume, PlayingOffset, Position, RelativeToListener, MinDistance, Attenuation, Play/Pause/Stop, ToString, Destroy).
- No test file exists for Sound (hint SoundTests.cs absent). Attempted execution tests: constructed Sound via default ctor, via SoundBuffer (built from test Assets/AudioSample.wav through the proven byte[] SoundBuffer path) and via copy ctor. Every attempt blocked the test host ("Proceso de host de pruebas bloqueado"), including the minimal default-ctor test in isolation: CSFML 3.0 sfSound_create(const sfSoundBuffer* buffer) requires a buffer argument the wrapper omits (2.x ABI), so native stores a garbage buffer pointer and dereferences it. Root cause identical to SoundStream.Initialize / SoundBuffer short[] ctor.
- All 106 instrumented lines sit behind the three ctors (each calls sfSound_create or sfSound_copy); none is executable. Tests reverted. Not coverable without editing src.