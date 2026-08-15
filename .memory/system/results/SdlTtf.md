# SdlTtf.cs

- **File**: `1_Presentation/Extension/Graphic/Sdl2/src/Sdl2Ttf/SdlTtf.cs`
- **Coverage Before**: 2.2% (SonarCloud stale)
- **Coverage After**: 100.0% (180/180 executable lines, XPlat Code Coverage)
- **Tests Added**: 7 (Sdl2TtfBehaviorTests.cs — value assertions on font metrics, glyph/size queries, attribute round-trips, all render modes, missing-file error path)
- **Status**: COMPLETED
- **Note**: Native tests use the existing `RequireSdl2TtfFact` attribute and skip automatically when libSDL2_ttf is unavailable (CI without `brew install sdl2_ttf`). `GlyphIsProvided` returns the FreeType glyph index (not boolean 1) on SDL_ttf 2.20+, so the assertion is non-zero.
