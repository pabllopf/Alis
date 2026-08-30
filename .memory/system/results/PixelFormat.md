# Result: PixelFormat.cs

File: `1_Presentation/Extension/Graphic/Sdl2/src/Structs/PixelFormat.cs`
CoverageBefore: 0.0% (SonarCloud; 2 uncovered lines)
CoverageAfter: 100.0% (2/2 instrumented lines, local coverlet, PixelFormat-filtered run)
TestsAdded: 3 (PixelFormatCoverageTests.cs, plain [Fact])
Commit: test: coverage PixelFormat.cs
Status: REMEDIATED

## Summary

PixelFormat.cs is a sequential-layout struct with 2 `IntPtr` auto-properties (`Palette`,
`Next`) plus 16 readonly fields (`format`, `BitsPerPixel`, `BytesPerPixel`, masks, losses,
shifts, `refCount`). The readonly fields have no initializer, so only the two property
setter/getter lines are instrumented.

Committed `PixelFormatTest.cs` (3 tests) already covered the type but all use
`[RequireSdl2ImageFact]`, which skips when `libsdl2_image` cannot be resolved
(CI/SonarCloud run), hence 0.0%.

Added `PixelFormatCoverageTests.cs` (3 plain `[Fact]`): default (zeroed) field values,
set/store round trip on the auto-properties, and value-type copy independence.

## Verification

- PixelFormatCoverageTests-filtered run: 3 passed / 0 failed (net8.0).
- Local coverlet: PixelFormat.cs 100.0% (2/2 instrumented lines, line-rate 1.0).