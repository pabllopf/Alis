File: 1_Presentation/Extension/Graphic/Sdl2/src/Sdl.cs
CoverageBefore: 8.4%
CoverageAfter: 100% (local coverlet, 1670/1670 Sdl.cs sequence points hit; whole Sdl2/src scope 100%)
TestsAdded: 7 (SdlRemainingCoverageTests.cs) + 24 (SdlManagedCoverageTests.cs)
Status: COMPLETED

Notes:
- Earlier remediation reached 100% locally but SonarCloud still reported 8.4% on master because the
  native-gated tests SKIP on CI. The main SonarCloud workflow runs on macos-15-intel and does not
  install SDL2; local runs passed only because Homebrew SDL2 was present.
- Root cause: RequireSdl2FactAttribute.TryLoadSdl2Library and RequireSdl2TtfFactAttribute only probed
  assemblyDir/{name}, assemblyDir/lib{name}, lib{name}.dylib and lib{name}.so. The redistributed
  runtimes/osx-x64|arm64/native/{name}.dylib copied into the test output directory (bin/.../lib) was
  never probed, so the skip gate fired before the bundled library could be used. The DllImport
  resolver (Sdl2NativeDllResolver) already resolved the bundled copy, so only the gate was wrong.
- Fix (test/** only, no production changes): add the bare {name}.dylib and {name}.so candidates to
  both attributes. assemblyDir is searched before Homebrew/system dirs, so the bundled copy wins.
  Sdl2Image already probed {name}.dylib and needed no change.
- Verified: dotnet test ... -f net8.0 => 735 passed, 0 failed, 0 skipped. Coverlet: Sdl.cs 1670/1670,
  SdlImage.cs 42/42, SdlTtf.cs 360/360.
- Residual: Sdl2Image/Sdl2Ttf still require loadable native deps; their redistributed dylibs carry
  transitive Homebrew references, so those two files may stay skipped on CI until CI installs
  sdl2_image/sdl2_ttf (shared workflow change, out of scope).
