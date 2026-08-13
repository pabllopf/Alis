# Sound.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Audios/Sound.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 0% (0/53 — unreachable)
- **Tests Added**: 0 (probes removed — every ctor SIGBUSes the host)
- **Uncovered Lines**: all — sfSound_create declared parameterless vs CSFML 3.0 sfSound_create(const sfSoundBuffer*) (native ctor derefs garbage x0); sfSound_copy same mismatch. Production ABI change required.
- **Status**: BLOCKED_BY_PRODUCTION_CODE
