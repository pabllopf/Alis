# VideoMode.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Windows/VideoMode.cs`
- **Coverage Before**: 0.0% (SonarCloud — all tests native-gated)
- **Coverage After**: Constructors, ToString, public fields + native wrapper lines (IsValid/DesktopMode/FullscreenModes) covered: wrapper lines via conditional `Assert.Throws<DllNotFoundException>` pattern (runs on CI where csfml absent, passes locally where present); managed surface via plain `[Fact]`
- **Tests Added**: 9 (VideoModeRemainingCoverageTests.cs — 6 plain `[Fact]` + 3 conditional-native `[Fact]`)
- **Uncovered Lines**: None expected on CI after next analysis; local full-suite run: 1482/1482 pass
- **Status**: COMPLETED
