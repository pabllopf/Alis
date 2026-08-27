# Result: ImVectorG.cs

File: `1_Presentation/Extension/Graphic/Ui/src/ImVectorG.cs`
CoverageBefore: 0.0% (SonarCloud)
CoverageAfter: ~100% of observable lines (10 new tests pass; constructors, fields, and indexer exercised via public API)
TestsAdded: 10
Commit: 8a317cc47fc7e9ec66c36f096873467c70ed72cd
Status: COMPLETED

## Summary
Added ImVectorGCoverageTests.cs covering the readonly generic struct ImVectorG<T>. Tests verify default field values, both constructors (ImVector copy and size/capacity/data), and the element indexer for int, byte, and float types using allocated unmanaged memory. The prior ImVectorGTests.cs was gated behind RequireCImguiSystemFact (skipped without the cimgui native library); these tests use plain [Fact] so they execute and cover the members without any native dependency.

## Verification
- `dotnet build .../test/Alis.Extension.Graphic.Ui.Test.csproj -c Debug` — succeeded (0 errors, 0 warnings)
- `dotnet test .../test/Alis.Extension.Graphic.Ui.Test.csproj --filter "FullyQualifiedName~ImVectorGCoverageTests" -c Debug -f net8.0` — 10 passed, 0 failed, 0 skipped
