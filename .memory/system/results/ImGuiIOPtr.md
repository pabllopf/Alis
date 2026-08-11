# ImGuiIOPtr.cs

- **File**: `1_Presentation/Extension/Graphic/Ui/src/ImGuiIOPtr.cs`
- **Coverage Before**: 95.4% (local) / 0.0% (SonarCloud — native libs absent on CI)
- **Coverage After**: 95.7% (local)
- **Tests Added**: 2 (IniFilename, LogFilename getters)
- **Uncovered Lines**: Dead code (925-936, 973-984, 1293-1304) — `Marshal.OffsetOf<ImGuiIo>("KeysData")` etc. always throw: managed `ImGuiIo` has auto-property fields `KeysData0..N`, no marshaled member named `KeysData`. Requires production change to cover.
- **Status**: BLOCKED_BY_PRODUCTION_CODE
