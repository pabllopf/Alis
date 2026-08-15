# Result: ImFontAtlasPtr.cs

File: `1_Presentation/Extension/Graphic/Ui/src/ImFontAtlasPtr.cs`
CoverageBefore: 0.0% (SonarCloud; stale artifact)
CoverageAfter: 95.1% (173/182 lines, local coverlet; unchanged)
TestsAdded: 0 (9 lines of the broken `out byte[]` GetTexDataAsAlpha8/Rgba32 overloads)
Commit: test: coverage ImFontAtlasPtr.cs
Status: BLOCKED_BY_PRODUCTION_CODE

## Summary

ImFontAtlasPtr.cs (a cimgui `ImFontAtlas*` wrapper, 71 complexity / 243 LOC per SonarCloud) is
already covered at 95.1% (173/182 lines) by the committed test suite:
`ImFontAtlasPtrTest.cs`, `ImFontAtlasPtrExecutionTests.cs`,
`ImFontAtlasPtrNativeCoverageTests.cs` and `ImFontAtlasPtrRemainingCoverageTests.cs` (real
headless contexts, AddFontDefault + Build, framed glyph ranges). Full ImFontAtlasPtr filter:
227 passed, 0 failed.

## Remaining uncovered lines (9) — BLOCKED_BY_PRODUCTION_CODE

Lines 589-591, 601-603 (GetTexDataAsAlpha8 `out byte[]` overloads) and 636-638
(GetTexDataAsRgba32 `out byte[]` overload) are unreachable on a machine with cimgui present:

- The committed `ImFontAtlasPtrRemainingCoverageTests.cs` DllNotFoundException tests for the
  byte[] overloads are gated behind `if (!CanLoadCImguiLibrary())` and skip on this macOS host.
- Direct execution probes (one test class per overload, fresh context, AddFontDefault + Build +
  GetTexData) each crashed the test host (`Se ha anulado la serie de pruebas activa. Motivo:
  Proceso de host de pruebas bloqueado`). The P/Invoke declaration
  `ImGuiNative.ImFontAtlas_GetTexDataAsAlpha8(IntPtr self, out byte[] outPixels, ...)` at
  ImGuiNative.cs:4421/4443 marshals a native `unsigned char**` as `out byte[]` with no size;
  the CLR reads garbage as the array length and segfaults. The working `out IntPtr` overloads
  (lines 611-625, 646-660) are fully covered by the execution tests.

Covering these lines requires fixing the production P/Invoke signatures (e.g. route the
byte[] overloads through the IntPtr ones with a sized Marshal.Copy), which is out of scope.

## Verification

- Full ImFontAtlasPtr test filter (net8.0, Debug): 227 passed, 0 failed, 0 skipped.
- Local coverlet: ImFontAtlasPtr.cs 173/182 lines (95.1%); only the 9 byte[] overload lines
  uncovered.
- Native crash reproduced for all three byte[] overloads in isolated probe runs.
