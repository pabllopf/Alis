# Result: ImDrawListPtr.cs

File: `1_Presentation/Extension/Graphic/Ui/src/ImDrawListPtr.cs`
CoverageBefore: 0.0% (SonarCloud; 328 uncovered lines, 2 branches)
CoverageAfter: 3.5% (23/656 instrumented lines, local coverlet, ImDrawListPtrTests run)
TestsAdded: 14 (ImDrawListPtrTests.cs, plain [Fact], Marshal-based, no native deps)
Commit: test: coverage ImDrawListPtr.cs
Status: PARTIAL_BLOCKED_BY_PRODUCTION_CODE

## Summary

ImDrawListPtr.cs is a `public class ImDrawListPtr` Marshal-based pointer wrapper over the
`ImDrawList` struct. Unlike the ImGui native partials, this class has NO static container and its
value surface is testable without cimgui:

- `ImDrawListPtr(IntPtr nativePtr)` and `ImDrawListPtr(ImDrawList nativePtr)` ctors.
- Implicit operators `IntPtr -> ImDrawListPtr` and `ImDrawListPtr -> IntPtr`.
- 15 read-only properties that read fields via `Marshal.PtrToStructure<ImDrawList>(NativePtr)`:
  `CmdBuffer`, `IdxBuffer`, `VtxBuffer`, `Flags`, `VtxCurrentIdx`, `Data`, `OwnerName`,
  `VtxWritePtr`, `IdxWritePtr`, `ClipRectStack`, `TextureIdStack`, `Path`, `CmdHeader`,
  `Splitter`, `FringeScale`.

Added `ImDrawListPtrTests.cs` (14 plain `[Fact]`, deterministic on every platform): builds a
source `ImDrawList` with populated fields, marshals it through `new ImDrawListPtr(src)`
(which does `Marshal.AllocHGlobal` + `StructureToPtr`), then round-trips the ctor, operators,
and every property. `VtxWritePtr` is backed by `Marshal.AllocHGlobal(Marshal.SizeOf<ImDrawVert>())`
so the nested `Marshal.PtrToStructure<ImDrawVert>(...VtxWritePtr)` dereference succeeds.
The six buffer/stack properties produce `ImVectorG<T>` wrappers via the `ImVectorG(ImVector)` ctor.

## Remaining uncovered (BLOCKED_BY_PRODUCTION_CODE)

- Lines ~155-1224 (~600+ lines): 93 instance methods that are single pass-through calls to
  `ImGuiNative.ImDrawList_*` / `ImGuiNative.ImDrawList__*` (P/Invoke into native cimgui), plus the
  two pure `ImGuiNative` calls `_CalcCircleAutoSegmentCount` and `ClearFreeMemory` etc. Invoking
  them requires the native library at runtime; environment-dependent, not coverable
  deterministically under plain `[Fact]`.

## Verification

- ImDrawListPtrTests-filtered run: 14 passed / 0 failed (net8.0).
- Full project build (Debug): 0 warnings / 0 errors.
- Local coverlet: ImDrawListPtr.cs 3.5% (23/656 instrumented lines).