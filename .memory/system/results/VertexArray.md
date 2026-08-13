# VertexArray.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Render/VertexArray.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 91.3% (42/46, local — 38 existing tests pass)
- **Tests Added**: 0 (existing suite authoritative)
- **Uncovered Lines**: 147-151 — Draw switch cases for RenderWindow and RenderTexture: sfRenderWindow_drawVertexArray SIGSEGVs on live window (CSFML 3.0 sfRenderStates layout shift, same as SfmlText.Draw); RenderTexture ctor ABI-broken. Production change required.
- **Status**: BLOCKED_BY_PRODUCTION_CODE
