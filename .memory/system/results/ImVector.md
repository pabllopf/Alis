# Result: ImVector.cs

File: `1_Presentation/Extension/Graphic/Ui/src/ImVector.cs`
CoverageBefore: 0.0% (SonarCloud)
CoverageAfter: All observable public API exercised — default values, the (int, int, IntPtr) constructor, Size/Capacity/Data property round-trips, and the Ref<T> / Address<T> methods against allocated memory; 11/11 ImVectorTests pass
TestsAdded: 11
Commit: test: ImVector.cs
Status: COMPLETED

## Summary
ImVector is a plain struct exposing Size, Capacity, and Data auto-properties plus a three-argument constructor and the Ref<T>/Address<T> marshaling helpers. New ImVectorTests.cs covers the default (zero-initialized) state, constructor assignments, mutable property round-trips, and both pointer-based accessors using Marshal.AllocHGlobal/FreeHGlobal without any cimgui/native calls. All 11 tests pass on net8.0 Debug.

## Verification
- `dotnet build Alis.Extension.Graphic.Ui.Test.csproj -c Debug` → build succeeded (0 errors, 0 warnings)
- `dotnet test Alis.Extension.Graphic.Ui.Test.csproj --filter "FullyQualifiedName~ImVectorTests" -c Debug -f net8.0` → Passed: 11, Failed: 0, Skipped: 0
