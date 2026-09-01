# Result: ImGuiIOPtr.cs

File: `1_Presentation/Extension/Graphic/Ui/src/ImGuiIOPtr.cs`
CoverageBefore: 0.0% (SonarCloud; 690 uncovered lines)
CoverageAfter: 89.1% (1230/1380, local coverlet, ImGuiIOPtrTests-filtered run)
TestsAdded: 101 (ImGuiIOPtrTests.cs, plain [Fact])
Commit: test: coverage ImGuiIOPtr.cs
Status: REMEDIATED

## Summary

ImGuiIOPtr.cs is a native pointer wrapper around the `ImGuiIo` struct. It marshals the
struct to/from our own `Marshal.AllocHGlobal` memory, exposing ~90 managed properties and
15 `List<T>` accessors. None of that needs the cimgui library.

The committed suite (`ImGuiIoPtrTest.cs`, `ImGuiIOPtrTests.cs` pre-existing) all use
`[RequireCImguiSystemFact]`, which skips when cimgui is absent (CI/SonarCloud), hence 0.0%.

Added `ImGuiIOPtrTests.cs` (101 plain `[Fact]`, namespace Alis.Extension.Graphic.Ui.Test):
set/get round trip through allocated native memory for every scalar/IntPtr/bool/Vector2F/
ImVectorG property, all `List<T>` accessors (KeyMap, KeysDown, NavInputs, MouseDown, and the
11 offset-typed Mouse arrays), NullTerminatedString/wrapper getters, the `IntPtr`/`ImGuiIo`
constructors, both implicit operators, and the three `Marshal.OffsetOf` getters that throw
`ArgumentException` for the absent aggregate fields.

## Remaining uncovered (BLOCKED_BY_PRODUCTION_CODE)

- Lines 1440-1583 — the 12 `ImGuiNative.ImGuiIO_*` methods (AddFocusEvent, AddInputCharacter,
  AddInputCharactersUtf8, AddInputCharacterUtf16, AddKeyAnalogEvent, AddKeyEvent,
  AddMouseButtonEvent, AddMousePosEvent, AddMouseViewportEvent, AddMouseWheelEvent,
  ClearInputCharacters, ClearInputKeys, SetAppAcceptingEvents). These require the native
  cimgui library present at test runtime; forcing them raises unavailable-entry-point
  exceptions. Environment-dependent; cannot be covered deterministically.
- Lines 927-936, 975-984, 1295-1304 — dead/aggregate branches in the `KeysData`,
  `MouseClickedPos`, `MouseDragMaxDistanceAbs` getters. The `ImGuiIo` struct exposes only
  `KeysData0`-`KeysData651`, `MouseClickedPos0`-`MouseClickedPos4`,
  `MouseDragMaxDistanceAbs0`-`MouseDragMaxDistanceAbs4`; `Marshal.OffsetOf` for the absent
  aggregate (`KeysData`) field throws before those lines execute. Unreachable given the
  current public struct shape.

## Verification

- ImGuiIOPtrTests-filtered run: 101 passed / 0 failed (net8.0).
- Local coverlet: ImGuiIOPtr.cs 89.1% (1230/1380 instrumented lines).