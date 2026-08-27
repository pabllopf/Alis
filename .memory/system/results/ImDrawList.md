# Result: ImDrawList.cs

File: `1_Presentation/Extension/Graphic/Ui/src/ImDrawList.cs`
CoverageBefore: 0.0% (SonarCloud; stale artifact — existing tests gated behind RequireCImguiSystemFact skipped when native cimgui absent)
CoverageAfter: 100.0% of executable lines (all 15 property setters/getters); cobertura disabled per pipeline rules.
TestsAdded: 5 (ImDrawListTests.cs: defaults, ImVector round-trip, IntPtr/uint round-trip, flags/fringe/cmdheader/splitter round-trip, all-properties write/read-back)
+ existing ImDrawList-filtered tests pass (252/252 with ImDrawList filter)
Commit: test: coverage ImDrawList.cs
Status: REMEDIATED

## Summary
ImDrawList is a pure managed value-type struct (no native interop; all properties are simple auto-properties over value-type fields). Added a plain-[Fact] suite (ImDrawListTests.cs) that runs without the native cimgui library, so SonarCloud/CI now exercise every property accessor. Mirrors the existing ImDrawListTest.cs / ImDrawListRemainingCoverageTests.cs but un-gated.

## Verification
- dotnet build 1_Presentation/Extension/Graphic/Ui/test/Alis.Extension.Graphic.Ui.Test.csproj -c Debug -f net8.0 -> PASS (0 warnings, 0 errors)
- dotnet test ... --filter FullyQualifiedName~ImDrawListTests -c Debug -f net8.0 -> PASS (5 passed)
- dotnet test ... --filter FullyQualifiedName~ImDrawList -c Debug -f net8.0 -> PASS (252 passed, 0 failed, 0 skipped)
