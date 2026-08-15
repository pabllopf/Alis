# Result: ImGuiP4.cs

File: `1_Presentation/Extension/Graphic/Ui/src/ImGuiP4.cs`
CoverageBefore: 0.0% (SonarCloud; local coverlet 320/428 = 74.8%)
CoverageAfter: 87.8% (376/428 lines, local coverlet)
TestsAdded: 2 (CalcTextSize_AllOverloads_Execute, InputText_IntPtrOverloads_ExecuteInsideWindow)
Commit: test: coverage ImGuiP4.cs
Status: PARTIALLY_REMEDIATED

## Summary

ImGuiP4.cs is an `ImGui` partial (69 complexity / 384 LOC per SonarCloud) with the Text family,
TreeNode/TreePush/Pop, VSlider* , Value, UpdatePlatformWindows, TableSetup*, CalcTextSize,
InputText/Multiline/WithHint overloads. The committed `ImGuiP4ExecutionTests.cs` (real cimgui
contexts, framed windows, `[MacOsOnly]`) already covered 320/428 lines (74.8%).

Added two tests that cover another 56 lines (74.8% → 87.8%):

1. `CalcTextSize_AllOverloads_Execute` — calls all 11 `CalcTextSize` overloads (the
   expression-bodied `=> CalcTextSizeImpl(...)` lines 802-903). They only need a live ImGui
   context; the bare context measures text as (0,0) because no display font is loaded, so the
   tests assert nothing on the value and just exercise the managed bodies.
2. `InputText_IntPtrOverloads_ExecuteInsideWindow` — calls the 4 `InputText(IntPtr buf, ...)`
   overloads (delegate lines 932/947/964 + full body 983-993) against a real
   `Marshal.AllocHGlobal(256)` buffer filled with text; the pointer is passed through to
   `igInputText` and ImGui writes into it normally.

Full suite: 7597 passed, 0 failed, 14 platform-gated skipped.

## Remaining uncovered lines (26) — BLOCKED_BY_PRODUCTION_CODE

All 26 remaining lines belong to the `InputText` overloads that pass `IntPtr.Zero` as the
native buffer pointer instead of the caller's buffer:

- 502, 517, 534 (delegate `=>` lines) and 553-563 (full body) of the `byte[] buf` overloads:
  the body calls `ImGuiNative.igInputText(GetBytes(label), IntPtr.Zero, bufSize, flags,
  callback, userData)` with a NULL `buf` — ImGui would dereference it and crash.
- 575, 589, 605 (delegate `=>` lines) and 624-634 (full body) of the `ref string input`
  overloads: same defect, `IntPtr.Zero` is passed as `buf` (the ref string is never marshalled
  into a buffer).

`InputTextMultiline` and `InputTextWithHint` are fine (they marshal the input bytes into a real
buffer), which is why those families are fully covered. The bare `InputText` wrappers drop the
buffer and hand native a NULL pointer — a production interop bug in `src/` (calling them from a
test crashes the native host). Not coverable from managed tests without a `src/` fix.

## Verification

- Full Ui suite (net8.0, Debug): 7597 passed, 0 failed, 14 skipped.
- Local coverlet: ImGuiP4.cs 376/428 lines (87.8%); 26 unique uncovered lines, all in the
  NULL-buffer `InputText` overloads.
- New tests pass in isolation (11/11 ImGuiP4ExecutionTests) and in the full run.
