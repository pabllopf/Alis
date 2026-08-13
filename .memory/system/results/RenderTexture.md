# RenderTexture.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Render/RenderTexture.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 2.2% (2/93 — only EntryPointNotFoundException paths)
- **Tests Added**: 2 (RenderTextureExecutionTests.cs)
- **Uncovered Lines**: all instance members — wrapper declares CSFML 2.x ABI `sfRenderTexture_create(uint,uint,bool)` vs installed CSFML 3.0 `sfRenderTexture_create(sfVector2u,sfBool)` (height lands in ContextSettings* register → SIGSEGV); no (IntPtr) ctor to work around. Production ABI change required.
- **Status**: BLOCKED_BY_PRODUCTION_CODE
