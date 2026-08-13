# Image.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Render/Image.cs`
- **Coverage Before**: 0.0% (SonarCloud stale) / 92.3% (existing tests)
- **Coverage After**: 95.6% (87/91)
- **Tests Added**: 1 (ImageExecutionTests.cs — internal ctor via InternalsVisibleTo)
- **Uncovered Lines**: 73-74, 153-154 — LoadingFailedException throw paths in Image(uint,uint,Color) and Image(uint,uint,byte[]) — CSFML never returns IntPtr.Zero (zero-size accepted, only native OOM produces null); unreachable without production change
- **Status**: BLOCKED_BY_PRODUCTION_CODE
