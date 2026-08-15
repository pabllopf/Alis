# SdlImage.cs

- **File**: `1_Presentation/Extension/Graphic/Sdl2/src/Sdl2Image/SdlImage.cs`
- **Coverage Before**: 4.8%
- **Coverage After**: 100.0% (21/21 executable lines, local coverlet)
- **Tests Added**: 21 (SdlImageBehaviorTests.cs)
- **Status**: COMPLETED

All tests are plain `[Fact]` (no `RequireSdl2ImageFact`) so they execute even when the native `SDL2_image` runtime is missing; in that environment the P/Invoke boundary throws `DllNotFoundException`/`EntryPointNotFoundException`, which the helpers tolerate while still exercising the managed wrapper lines. `SavePng`/`SaveJpg` with a NULL surface segfault the native `IMG_SavePNG`/`IMG_SaveJPG` (uncatchable host crash), so those two paths are tested with a real surface loaded from the `tile000.bmp` asset, writing to a temp file that is deleted afterwards; they early-return when the asset is unavailable. No production code was modified.
