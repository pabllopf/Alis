# Result: Style.cs

File: `1_Presentation/Extension/Graphic/Ui/src/Extras/Node/Style.cs`
CoverageBefore: 0.0% (SonarCloud)
CoverageAfter: 100% locally (line-rate 1.0, branch-rate 1.0, coverlet net8.0)
TestsAdded: 18
Commit: d0054e6d9
Status: COMPLETED

## Summary
Style.cs is a plain C# struct with 15 auto-property floats, a StyleFlags enum property and a uint[] Colors property. The pre-existing StyleTest.cs used [RequireCImguiSystemFact], which skips all tests when the native cimgui library is unavailable, leaving coverage at 0.0%. Converted the tests to plain xUnit [Fact] and added default-value and full round-trip tests, covering 100% of the struct's lines.

## Verification
- `dotnet build Alis.Extension.Graphic.Ui.Test.csproj -c Debug` — succeeded (0 errors).
- `dotnet test Alis.Extension.Graphic.Ui.Test.csproj --filter "FullyQualifiedName~Style" -c Debug -f net8.0` — 632 passed, 0 failed, 7 skipped (pre-existing skips).
- `dotnet test ... --filter "FullyQualifiedName~Extras.Node.StyleTest" -c Debug -f net8.0` — 18/18 passed.
- Local coverlet: Style.cs line-rate 1.0 (100%).