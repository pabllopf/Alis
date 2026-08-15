# ImGuiIO.cs

- **File**: `1_Presentation/Extension/Graphic/Ui/src/ImGuiIO.cs`
- **Coverage Before**: 12.7% (SonarCloud stale)
- **Coverage After**: 100.0% (1482/1482 lines, line-rate 1.0 / branch-rate 1.0, measured via XPlat Code Coverage, net8.0)
- **Tests Added**: 645 (ImGuiIoKeysDataCoverageTests.cs — `KeysData2..KeysData651` get/set round-trip, skipping already-covered `KeysData0/1/100/294/295/407/408`)
- **Status**: COMPLETED

`ImGuiIo` is a plain managed `[StructLayout(LayoutKind.Sequential)]` struct with auto-properties and inline-array fields; it has no methods or explicit constructors, so all behavior is property get/set and field access. The struct's 652 `ImGuiKeyData` properties were the uncovered bulk; each new test assigns a distinct `ImGuiKeyData` (index-derived durations) and asserts the round-trip of `Down`, `DownDuration`, `DownDurationPrev` and `AnalogValue`. Struct-layout/marshal behavior (fields `KeyMap`, `KeysDown`, `MouseDown`, ...) was already covered by existing array tests and would require live native memory to verify. No methods requiring an ImGui context exist on this struct (those live on `ImGuiIoPtr`). Full Ui test project: 7587 passed / 0 failed / 14 skipped (pre-existing skips).
