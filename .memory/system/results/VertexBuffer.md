# VertexBuffer.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Render/VertexBuffer.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 90% (36/40, local — 37 existing tests pass)
- **Tests Added**: 0 (existing suite authoritative)
- **Uncovered Lines**: 160-164 — Draw switch cases for RenderWindow and RenderTexture: sfRenderWindow_drawVertexBuffer SIGSEGVs on live window (CSFML 3.0 sfRenderStates layout shift); RenderTexture ctor ABI-broken. Production change required.
- **Status**: BLOCKED_BY_PRODUCTION_CODE
