# Result: ImGuiPlatformIO.cs

File: `1_Presentation/Extension/Graphic/Ui/src/ImGuiPlatformIO.cs`
CoverageBefore: 0.0% (SonarCloud)
CoverageAfter: 100% (line-rate 1, branch-rate 1; local coverlet, ImGuiPlatformIOTests filter)
TestsAdded: 26 (ImGuiPlatformIOTests.cs)
Commit: 77907f1f0fa078b08e5580a54a148268c0e63b96
Status: COMPLETED

## Summary

ImGuiPlatformIO.cs is a plain struct of 23 `IntPtr` auto-property handles (platform/renderer callback pointers) plus `Monitors` and `Viewports` `ImVector` values. It requires no native context: every member is an observable auto-property, so 26 pure public-API tests were written covering default zero values and a set/get round-trip for each public property. No pointer is invoked or dereferenced. Local coverlet reports 100% line and branch coverage.

## Verification

- dotnet build 1_Presentation/Extension/Graphic/Ui/test/Alis.Extension.Graphic.Ui.Test.csproj -c Debug -> PASS (0 warnings, 0 errors)
- dotnet test ... --filter FullyQualifiedName~ImGuiPlatformIO -c Debug -f net8.0 -> PASS (66 passed, 0 failed, 0 skipped; 26 new + pre-existing)
- dotnet test ... --filter FullyQualifiedName~ImGuiPlatformIOTests --collect "XPlat Code Coverage" -> ImGuiPlatformIO.cs 100% lines (line-rate 1), branch-rate 1
