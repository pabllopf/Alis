# SoundStream.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Audios/SoundStream.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 4.3% (3/69 — only ctor paths)
- **Tests Added**: 0 (17 probe tests written and removed — each crashed the test host)
- **Uncovered Lines**: all instance members — wrapper P/Invokes sfSoundStream_create with CSFML 2.x 5-arg ABI vs installed CSFML 3.0 7-arg (channel map args read from stale registers → NULL deref in libcsfml-audio ctor). Production ABI change required.
- **Status**: BLOCKED_BY_PRODUCTION_CODE
