# Result: ImGuiInputTextCallbackData.cs

File: `1_Presentation/Extension/Graphic/Ui/src/ImGuiInputTextCallbackData.cs`
CoverageBefore: 0.0% (SonarCloud; stale artifact — existing tests gated behind RequireCImguiSystemFact skipped when native cimgui absent)
CoverageAfter: 100.0% executable lines (all 12 property accessors); cobertura disabled per pipeline rules.
TestsAdded: 2 (ImGuiInputTextCallbackDataCoverageTests.cs: default-zero + all-properties round-trip)
Commit: test: coverage ImGuiInputTextCallbackData.cs
Status: REMEDIATED

## Summary
ImGuiInputTextCallbackData is a pure managed value-type struct (no native interop; all properties are auto-properties over value-type fields). Added a plain-[Fact] suite (ImGuiInputTextCallbackDataCoverageTests.cs) that runs without the native cimgui library, so SonarCloud/CI now exercise every property accessor. Mirrors the existing gated ImGuiInputTextCallbackDataTest.cs but un-gated.

## Verification
- dotnet build 1_Presentation/Extension/Graphic/Ui/test/Alis.Extension.Graphic.Ui.Test.csproj -c Debug -f net8.0 -> PASS (0 warnings, 0 errors)
- dotnet test ... --filter FullyQualifiedName~ImGuiInputTextCallbackDataCoverageTests -c Debug -f net8.0 -> PASS (2 passed, 0 failed, 0 skipped)
