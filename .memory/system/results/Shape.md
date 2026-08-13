# Shape.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Render/Shape.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 85% (51/60, local — 115 existing tests pass)
- **Tests Added**: 0 (existing suite authoritative)
- **Uncovered Lines**: 159-172 — Draw switch cases for RenderWindow and RenderTexture: sfRenderWindow_drawShape SIGSEGVs on live window (CSFML 3.0 sfRenderStates layout shift, same as SfmlText.Draw); RenderTexture ctor ABI-broken. Production change required.
- **Status**: BLOCKED_BY_PRODUCTION_CODE
