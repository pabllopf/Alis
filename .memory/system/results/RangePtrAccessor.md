# Result: RangePtrAccessor.cs

File: `1_Presentation/Extension/Graphic/Ui/src/RangePtrAccessor.cs`
CoverageBefore: 0.0% (SonarCloud)
CoverageAfter: 100% locally (17/17 lines, branch-rate 1.0, coverlet net8.0)
TestsAdded: 13 (RangePtrAccessorTests.cs)
Commit: e85b52523
Status: COMPLETED

## Summary
RangePtrAccessor is a readonly generic struct wrapping an unmanaged range (IntPtr Data + int Count) with a bounds-checked indexer that marshals elements out of native memory. New RangePtrAccessorTests.cs covers the default value, both constructor-set fields, int/byte/float element reads, non-zero offset reads, reads reflecting direct native buffer writes, and every out-of-range branch (negative index, index == count, index > count, zero count) using plain [Fact] tests with Marshal.AllocHGlobal/FreeHGlobal in try/finally. No cimgui/native context is required since the indexer performs pure managed marshaling, so all tests execute on net8.0 instead of being skipped.

## Verification
- `dotnet build Alis.Extension.Graphic.Ui.Test.csproj -c Debug` → build succeeded (0 errors, 0 warnings)
- `dotnet test Alis.Extension.Graphic.Ui.Test.csproj --filter FullyQualifiedName~RangePtrAccessorTests -c Debug -f net8.0` → Passed: 13, Failed: 0, Skipped: 0
- `dotnet test ... --collect:"XPlat Code Coverage"` → RangePtrAccessor.cs line-rate 1, branch-rate 1 (17/17 lines covered)
