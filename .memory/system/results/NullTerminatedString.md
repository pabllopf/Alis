# Result: NullTerminatedString.cs

File: `1_Presentation/Extension/Graphic/Ui/src/NullTerminatedString.cs`
CoverageBefore: 0.0% (SonarCloud)
CoverageAfter: All observable public API exercised — both ctors (IntPtr, byte[]), Data field, ToString empty/terminator/ascii/unicode paths, implicit string operator; 33/33 NullTerminatedString-filtered tests pass
TestsAdded: 9 (NullTerminatedStringCoreTests.cs)
Commit: 107e6f874dd0b9fafd17ac8feb5f376f3a45d4ec
Status: COMPLETED

## Summary
NullTerminatedString is a pure managed readonly struct wrapping a Marshal.AllocHGlobal buffer. Existing tests were gated behind RequireCImguiSystemFact (skipped when the native cimgui lib is absent, explaining the 0% SonarCloud figure), so a new CoreTests file with plain [Fact] attributes was added to guarantee execution. The 9 tests cover the IntPtr ctor, the byte[] ctor (allocation, copy, null-termination, empty-array case with cleanup via Marshal.FreeHGlobal), ToString for zero/immediate-terminator/ascii/unicode buffers, and the implicit operator to string.

## Verification
- `dotnet build 1_Presentation/Extension/Graphic/Ui/test/Alis.Extension.Graphic.Ui.Test.csproj -c Debug` — PASS (0 errors)
- `dotnet test 1_Presentation/Extension/Graphic/Ui/test/Alis.Extension.Graphic.Ui.Test.csproj --filter FullyQualifiedName~NullTerminatedString -c Debug -f net8.0` — PASS (33 passed, 0 failed, 0 skipped)
