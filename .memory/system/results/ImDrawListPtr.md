File: 1_Presentation/Extension/Graphic/Ui/src/ImDrawListPtr.cs
CoverageBefore: 7.0% (SonarCloud, master)
CoverageAfter: 7.0% (local coverlet, filtered run)
TestsAdded: 21
Commit: test: coverage ImDrawListPtr.cs
Status: COMPLETED

## Summary

Added `ImDrawListPtrManagedCoverageTests.cs` exercising every purely-managed
member of `ImDrawListPtr` without requiring cimgui. Tests cover both
constructors (IntPtr and ImDrawList), both implicit operator conversions,
NativePtr property, and all 14 marshal-based read-only properties
(Flags, VtxCurrentIdx, Data, OwnerName, IdxWritePtr, FringeScale,
CmdBuffer, IdxBuffer, VtxBuffer, ClipRectStack, TextureIdStack, Path,
CmdHeader, Splitter, VtxWritePtr). Tests use pure managed marshal
operations (Marshal.AllocHGlobal/StructureToPtr/PtrToStructure) and free
memory in finally blocks.

All 21 tests pass. The remaining ~93% of the file consists of 80+ native
P/Invoke wrappers (ImGuiNative.ImDrawList_*) that require cimgui and a
live ImGui context; these cannot be tested in a pure managed environment.
