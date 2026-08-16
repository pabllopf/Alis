# Result: ControllerCategories.cs

File: `4_Operation/Physic/src/Common/Logic/ControllerCategories.cs`
CoverageBefore: 0.0% (SonarCloud; constant-only enum artifact)
CoverageAfter: Not measurable (coverlet emits no class for constant-only enums)
TestsAdded: 0 (already covered by committed ControllerCategoriesTest.cs)
Commit: test: coverage ControllerCategories.cs
Status: ALREADY_REMEDIATED

## Summary

`ControllerCategories` is a `[Flags]` enum of compile-time constants. Constant-only enums emit
zero executable IL, so coverlet omits the type and SonarCloud's 1 "uncovered line" is a
measurement artifact (same as KeyCodes). Committed `ControllerCategoriesTest.cs` (13+ tests)
asserts every member value and the bitwise combinations.

## Verification

- `dotnet test Alis.Core.Physic.Test.csproj -c Debug -f net8.0 --filter
  "FullyQualifiedName~ControllerCategories"`: 50 passed, 0 failed, 0 skipped.
- Local coverlet (XPlat Code Coverage, cobertura): no `ControllerCategories` class emitted (no
  executable lines).
