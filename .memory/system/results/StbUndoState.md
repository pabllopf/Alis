# Result: StbUndoState.cs

File: `1_Presentation/Extension/Graphic/Ui/src/StbUndoState.cs`
CoverageBefore: 0.0% (SonarCloud)
CoverageAfter: 100.0% (local coverlet: line-rate 1.0, branch-rate 1.0; all 104 previously-uncovered lines exercised)
TestsAdded: 104
Commit: 807b0b51ab266e2f5b2be240b21a7633db3ec5b2
Status: COMPLETED

## Summary

StbUndoState is a plain data struct (208 complexity / 111 LOC) holding 99 StbUndoRecord undo slots (UndoRec0..UndoRec98), a `List<ushort>` UndoChar buffer and four undo/redo point fields. The new StbUndoStateTests suite (plain `[Fact]`, no cimgui dependency) covers every public member via public API: set/get round-trips for all 99 UndoRecN records, the UndoChar list, UndoPoint/RedoPoint/UndoCharPoint/RedoCharPoint, and the default-value state. The pre-existing StbUndoStateTest/StbUndoStateRemainingCoverageTests suites were gated behind `[RequireCImguiSystemFact]` and skipped, which is why SonarCloud reported 0.0%; the new `[Fact]` tests run unconditionally. Local coverlet reports StbUndoState.cs and its StbUndoRecord dependency at 100% lines / 100% branches.

## Verification

- `dotnet build Alis.Extension.Graphic.Ui.Test.csproj -c Debug`: succeeded, 0 warnings / 0 errors.
- `dotnet test Alis.Extension.Graphic.Ui.Test.csproj --filter "FullyQualifiedName~StbUndoState" -c Debug -f net8.0`: 348 passed, 0 failed, 0 skipped.
- Local coverlet (XPlat Code Coverage, cobertura, filter `FullyQualifiedName~StbUndoState`): `StbUndoState.cs` line-rate 1.0 / branch-rate 1.0; `StbUndoRecord.cs` line-rate 1.0 / branch-rate 1.0. Generated coverage artifacts removed after measurement (not committed).
