# Sprite.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Render/Sprite.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 0% (0/43 — uninstantiable)
- **Tests Added**: 0 (15 probes removed — every ctor SIGSEGVs the host)
- **Uncovered Lines**: all — installed CSFML 3.0 misbinds sfSprite_create to a create-from-texture implementation (derefs nonexistent arg → SIGSEGV); no (IntPtr) ctor to wrap a correct native pointer. Production change required.
- **Status**: BLOCKED_BY_PRODUCTION_CODE
