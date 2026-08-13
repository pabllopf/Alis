# SoundBufferRecorder.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Audios/SoundBufferRecorder.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 81.25% (13/16, local — 18 existing tests pass)
- **Tests Added**: 0 (existing suite authoritative)
- **Uncovered Lines**: 97-99 — OnStop body: constructs SoundBuffer(short[],uint,uint) whose ctor SIGBUSes the host (CSFML 3.0 sfSoundBuffer_createFromSamples 6-param ABI mismatch). Production change required.
- **Status**: BLOCKED_BY_PRODUCTION_CODE
