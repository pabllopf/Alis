# SfmlText.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Render/SfmlText.cs`
- **Coverage Before**: 0.0% (SonarCloud stale) / 95.2% (existing tests)
- **Coverage After**: 95.2% (80/84, local — 38 existing tests pass)
- **Tests Added**: 0 (existing suite authoritative)
- **Uncovered Lines**: 263-264, 266-267 — Draw switch cases for RenderWindow and RenderTexture: sfRenderWindow_drawText SIGSEGVs on live window (CSFML 3.0 sfRenderStates layout shift, same as RenderWindow.Draw); RenderTexture ctor ABI-broken. Production change required.
- **Status**: BLOCKED_BY_PRODUCTION_CODE
