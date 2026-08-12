# VideoMode.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Windows/VideoMode.cs`
- **Coverage Before**: 0.0% (SonarCloud — all tests native-gated)
- **Coverage After**: Constructors, ToString, and public fields covered by plain `[Fact]` (run on CI); `IsValid`/`FullscreenModes`/`DesktopMode` wrapper lines still require csfml native lib (unavailable on SonarCloud CI)
- **Tests Added**: 6 (VideoModeRemainingCoverageTests.cs — plain `[Fact]` for managed surface)
- **Uncovered Lines**: Native P/Invoke wrappers (`sfVideoMode_*` calls) requiring csfml runtime
- **Status**: COMPLETED
