# Result: ImNodes.cs

File: `1_Presentation/Extension/Graphic/Ui/src/Extras/Node/ImNodes.cs`
CoverageBefore: 3.3% (SonarCloud; stale artifact)
CoverageAfter: 83.0% (332/400, local coverlet)
TestsAdded: 0 (already remediated in commit 99c54b57b)
Commit: test: coverage ImNodes.cs
Status: BLOCKED_BY_PRODUCTION_CODE

## Summary

ImNodes.cs is the ImNodes wrapper (105 complexity / 513 LOC). Committed suite
(ImNodesTest.cs + ImNodesRemainingCoverageTests.cs, 34 tests: 31 native execution + 3
StyleColors marshaling guards) covers 332/400 lines (83.0%).

## Remaining uncovered (68) — BLOCKED_BY_PRODUCTION_CODE

- `MiniMap` (5 overloads): node-hovering callback delegate unmarshalable → MarshalDirectiveException at JIT.
- `StyleColors*` (6 overloads): backing struct has an array field → TypeLoadException at JIT.
- `SaveCurrentEditorStateToIniFile` / `SaveEditorStateToIniFile`: forbidden filesystem side effects.
- `LoadEditorStateFromIniFile` / `LoadEditorStateFromIniString` / `EditorContextFree` (empty
  struct): wrapper forwards struct by value as garbage pointer → native deref (process abort).
- Closing braces behind the above JIT/abort paths.

## Verification

- `dotnet test Alis.Extension.Graphic.Ui.Test.csproj -c Debug -f net8.0 --filter
  "FullyQualifiedName~ImNodes"`: 118 passed, 8 skipped, 0 failed.
- Local coverlet (XPlat Code Coverage, cobertura): `ImNodes.cs` 332/400 = 83.0%, identical to
  the committed result.
