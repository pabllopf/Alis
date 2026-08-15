# Result: ImPlotP22.cs

File: `1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP22.cs`
CoverageBefore: 0.0% (SonarCloud stale; local coverlet 310/330 = 93.9%)
CoverageAfter: 97.6% (322/330 lines, local coverlet; +3.7%)
TestsAdded: 3 (null-label overload probes for the flags/offset/stride `ref short` PlotLine overloads)
Commit: test: coverage ImPlotP22.cs
Status: PARTIAL_BLOCKED_BY_PRODUCTION_CODE

## Summary

ImPlotP22.cs is the `ImPlot` partial holding the 59 `PlotLine` overloads (short/ushort/int/
uint/long/ulong value arrays and ref float/double/sbyte/byte/short/ushort pairs, 55 complexity /
227 LOC per SonarCloud). The committed suite (`ImPlotP22Tests.cs`, `ImPlotP22ExecutionTests.cs`
with real native ImGui+ImPlot contexts, `ImPlotP22RemainingCoverageTests.cs`) already covered
310/330 lines; the three `ref short` overloads with flags/offset/stride (lines 719-735, 747-750)
were not exercised by any test.

## Work performed

Added 3 null-label tests to `ImPlotP22Tests.cs` following the existing
`PlotLine_RefShort_WithNullLabel_ShouldThrowArgumentNullException` convention. Each overload
calls `Encoding.UTF8.GetBytes(labelId)` first, so a null label throws ArgumentNullException at
the call site — the wrapper body is entered and the P/Invoke call line is covered without
entering native code (no crash risk, no external state). Targeted run: 81 passed / 0 failed on
`Alis.Extension.Graphic.Ui.Test` (net8.0).

## Remaining uncovered lines (4) — BLOCKED_BY_PRODUCTION_CODE

- 708, 721, 735, 750 — the closing braces of the four `ref short xs, ref short ys` overloads
  (lines 705, 719, 733, 748). These pass `xs, ys` **by value** to
  `ImPlotNative.ImPlot_PlotLine_S16PtrS16Ptr` whose DllImport declares `short xs, short ys`
  (ImPlotNative.cs:2219), while the native side expects `const short*` pointers. The marshaller
  forwards the literal value as the pointer address — same defect family as ImPlot.cs PlotStems
  `ref int`/`ref uint` (ImPlot.cs lines 93-224). A successful return is impossible, so the
  closing brace can never be reached without modifying `src/` interop signatures.

## Verification

- Targeted run: 81 passed / 0 failed (net8.0).
- Local coverlet: ImPlotP22.cs partial 322/330 lines (97.6%).
