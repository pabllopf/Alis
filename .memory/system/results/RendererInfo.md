# Result: RendererInfo.cs

File: `1_Presentation/Extension/Graphic/Sdl2/src/Structs/RendererInfo.cs`
CoverageBefore: 0.0% (SonarCloud; 2 uncovered lines)
CoverageAfter: 100.0% (4/4, local coverlet, RendererInfo-filtered run)
TestsAdded: 4 (RendererInfoCoverageTests.cs, plain [Fact])
Commit: test: coverage RendererInfo.cs
Status: REMEDIATED

## Summary

RendererInfo.cs is a sequential-layout struct with an `IntPtr Name` auto-property, uint/int
public fields (flags, texture formats, max dimensions) and a `GetName()` that marshals the
pointer with `Marshal.PtrToStringAnsi`.

Committed `RendererInfoTest.cs` already covered the type but all tests use
`[RequireSdl2ImageFact]`, which skips when `libsdl2_image` cannot be resolved
(CI/SonarCloud run), hence 0.0%.

Added `RendererInfoCoverageTests.cs` (4 plain `[Fact]`): default (zeroed) values across the
property, fields and GetName null path; set/store round trip; value-type copy independence;
and GetName returning null when Name is IntPtr.Zero.

## Verification

- RendererInfo-filtered run: 4 passed / 0 failed (net8.0).
- Local coverlet: RendererInfo.cs 100.0% (4/4 instrumented lines,
  line-rate 1.0, branch-rate 1.0).