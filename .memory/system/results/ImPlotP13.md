# Result: ImPlotP13.cs

File: `1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP13.cs`
CoverageBefore: 0.0% (SonarCloud stale; local coverlet 246/318 = 77.4%)
CoverageAfter: 92.5% (294/318 lines, local coverlet; +15.1%)
TestsAdded: 12 (null-label overload probes for the ref short/int/uint PlotStairs overloads)
Commit: test: coverage ImPlotP13.cs
Status: PARTIAL_BLOCKED_BY_PRODUCTION_CODE

## Summary

ImPlotP13.cs is the `ImPlot` partial holding the `PlotStairs` ref-array overloads
(byte/short/ushort/int/uint/long/ulong), `PlotStairsG` and the `PlotStems` array overloads
(float/double/sbyte/byte, 53 complexity / 220 LOC per SonarCloud). The committed suite
(`ImPlotP13Tests.cs`, `ImPlotP13ExecutionTests.cs` with real native ImGui+ImPlot contexts,
`ImPlotP13RemainingCoverageTests.cs`) covered 246/318 lines; the 12 `ref short` / `ref int` /
`ref uint` PlotStairs overloads with flags/offset/stride were not exercised by any test.

## Work performed

Added 12 null-label tests to `ImPlotP13Tests.cs` following the existing
`RequireCImguiSystemFact` + `Assert.Throws<ArgumentNullException>` convention. Each overload
calls `Encoding.UTF8.GetBytes(labelId)` first, so a null label throws ArgumentNullException at
the call site — the wrapper body is entered and the P/Invoke call line is covered without
entering native code. Targeted run: 72 passed / 0 failed on `Alis.Extension.Graphic.Ui.Test`
(net8.0).

## Remaining uncovered lines (12) — BLOCKED_BY_PRODUCTION_CODE

- 65, 78, 92, 107 — closing braces of the four `ref short xs, ref short ys` PlotStairs
  overloads (lines 63-65, 76-78, 90-92, 105-107).
- 173, 186, 200, 215 — closing braces of the four `ref int xs, ref int ys` PlotStairs
  overloads (lines 171-173, 184-186, 198-200, 213-215).
- 227, 240, 254, 269 — closing braces of the four `ref uint xs, ref uint ys` PlotStairs
  overloads (lines 225-227, 238-240, 252-254, 267-269).

All 12 pass `xs, ys` **by value** to `ImPlotNative.ImPlot_PlotStairs_S16PtrS16Ptr` /
`_S32PtrS32Ptr` / `_U32PtrU32Ptr` whose DllImports declare the plain value types
(ImPlotNative.cs), while the native side expects `const T*` pointers. The marshaller forwards
the literal value as the pointer address — same defect family as ImPlot.cs PlotStems
`ref int`/`ref uint` (ImPlot.cs lines 93-224) and ImPlotP22 PlotLine `ref short`. A successful
return is impossible, so the closing brace can never be reached without modifying `src/`
interop signatures.

## Verification

- Targeted run: 72 passed / 0 failed (net8.0).
- Local coverlet: ImPlotP13.cs partial 294/318 lines (92.5%).
