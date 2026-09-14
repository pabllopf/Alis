File: 1_Presentation/Extension/Graphic/Ui/src/ImFontConfigPtr.cs
CoverageBefore: 4.3% (SonarCloud, master)
CoverageAfter: 100% (local coverlet, filtered run)
TestsAdded: 33
Commit: test: coverage ImFontConfigPtr.cs
Status: COMPLETED

## Summary

Added `ImFontConfigPtrManagedCoverageTests.cs` exercising every member of
`ImFontConfigPtr` without requiring cimgui. Tests use pure managed marshal
operations (`Marshal.AllocHGlobal`/`StructureToPtr`/`PtrToStructure`) over
`ImFontConfig` native buffers and free memory in `finally` blocks.

All 33 tests pass; filtered coverlet run reports line-rate = 1 and
branch-rate = 1 for `ImFontConfigPtr.cs`.