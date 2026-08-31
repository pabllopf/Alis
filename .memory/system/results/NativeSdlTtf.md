# Result: NativeSdlTtf.cs

File: `1_Presentation/Extension/Graphic/Sdl2/src/Sdl2Ttf/NativeSdlTtf.cs`
CoverageBefore: 0.0% (SonarCloud; existing tests skipped)
CoverageAfter: 100.0% (1/1 instrumented line, local coverlet)
TestsAdded: 1 (NativeSdlTtfCoverageTests.cs)
Commit: test: coverage NativeSdlTtf.cs
Status: REMEDIATED

## Summary

NativeSdlTtf.cs is an `internal static` wrapper class. Every member is either the `NativeLibName`
const or a `[ExcludeFromCodeCoverage]` `internal static extern` DllImport P/Invoke stub — none of
those are coverable. The sole coverable member is `public static Version InternalGetTtfVersion()`
(line 512), an inline expression-bodied member returning `new Version(2, 0, 16)`.

SonarCloud reported 0.0% because the pre-existing `NativeSdlTtfTest.cs` class annotates every test
(including `ShouldReturnCompiledVersion`, which already exercises this exact method) with the
custom `[RequireSdl2ImageFact]` attribute. That attribute skips when the native `sdl2_image`
library cannot be resolved by name via `NativeLibrary.TryLoad`, so on this host the test was
skipped and the line stayed uncovered.

`InternalGetTtfVersion()` needs no native interop — it is a pure managed allocation. A new
`NativeSdlTtfCoverageTests.cs` class uses a plain `[Fact]` (always run) to call it and assert the
major/minor/patch values via the Sdl2 `Structs.Version` fields.

## Verification

- NativeSdlTtfCoverageTests filter (net8.0, Debug): 1 passed, 0 failed, 0 skipped.
- Coverlet cobertura: `NativeSdlTtf` class line-rate=1, branch-rate=1; `InternalGetTtfVersion` line 512 hit 1 time.
