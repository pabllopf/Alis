# ImGuiIOPtr.cs

- **File**: `1_Presentation/Extension/Graphic/Ui/src/ImGuiIOPtr.cs`
- **Coverage Before**: 0.0% (SonarCloud CI — all 906 managed tests were skipped by `RequireCImguiSystemFact`)
- **Coverage After**: 89.1% line / 80.4% branch (headless, CI-equivalent)
- **Tests Added**: 909 active (906 converted `RequireCImguiSystemFact` → `Fact` in ImGuiIoPtrTest.cs + ImGuiIOPtrRemainingCoverageTests.cs, +3 throw-behavior tests)
- **Uncovered Lines**: 15 native wrappers (AddFocusEvent → SetKeyEventNativeData, lines 1439-1583) require cimgui native lib absent on CI; dead code in KeysData/MouseClickedPos/MouseDragMaxDistanceAbs getters (always-throw, production fix required)
- **Status**: COMPLETED
# ImGuiIOPtr.cs

- **File**: `1_Presentation/Extension/Graphic/Ui/src/ImGuiIOPtr.cs`
- **Coverage Before**: 95.4% (local) / 0.0% (SonarCloud — native libs absent on CI)
- **Coverage After**: 95.7% (local)
- **Tests Added**: 2 (IniFilename, LogFilename getters)
- **Uncovered Lines**: Dead code (925-936, 973-984, 1293-1304) — `Marshal.OffsetOf<ImGuiIo>("KeysData")` etc. always throw: managed `ImGuiIo` has auto-property fields `KeysData0..N`, no marshaled member named `KeysData`. Requires production change to cover.
- **Status**: BLOCKED_BY_PRODUCTION_CODE
# ImGuiIOPtr.cs

- **File**: `1_Presentation/Extension/Graphic/Ui/src/ImGuiIOPtr.cs`
- **Coverage Before**: 0.0% (SonarCloud, stale) / 96.5% (local)
- **Coverage After**: 96.5% line (local, 666/690)
- **Tests Added**: 0 (924 existing ImGuiIoPtr tests pass)
- **Uncovered Lines**: 24 dead-code lines (927-936, 975-984, 1295-1304) — `Marshal.OffsetOf<ImGuiIo>("KeysData")`/`MouseClickedPos`/`MouseDragMaxDistanceAbs` always throw ArgumentException; managed `ImGuiIo` has no such marshaled members. Requires production change to cover.
- **Status**: BLOCKED_BY_PRODUCTION_CODE
