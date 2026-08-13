# SoundBuffer.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Audios/SoundBuffer.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 77.8% (49/63, local — 51 existing tests pass)
- **Tests Added**: 0 (3 probe tests removed — every samples-ctor call SIGBUSes the host)
- **Uncovered Lines**: 127-144 — SoundBuffer(short[],uint,uint) body: wrapper declares 4-param sfSoundBuffer_createFromSamples vs CSFML 3.0 6-param (missing channelMapData/channelMapSize read from garbage registers → SIGBUS). Production ABI change required.
- **Status**: BLOCKED_BY_PRODUCTION_CODE
