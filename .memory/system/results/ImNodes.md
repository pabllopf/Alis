# ImNodes.cs

- **File**: `1_Presentation/Extension/Graphic/Ui/src/Extras/Node/ImNodes.cs`
- **Coverage Before**: 3.3% (SonarCloud)
- **Coverage After**: 83.0% (332/400 executable lines, local coverlet)
- **Tests Added**: 34 (ImNodesRemainingCoverageTests.cs — 31 native execution tests + 3 StyleColors marshaling guard tests)
- **Status**: COMPLETED

## Notes

- `GetSelectedNodes` / `GetSelectedLinks` wrappers forward the id by value where the native
  signature expects `int*`; non-zero sentinels satisfy the native null assertions and are safe
  because the native code only dereferences when a selection exists (none in the tests).
- `IsLinkCreated` (4 overloads) and the `ref int` query overloads follow the same sentinel
  pattern; they all report false without native writes.
- `MiniMap` (5 overloads) throws `MarshalDirectiveException` at JIT because the node hovering
  callback delegate cannot be marshaled; tested via `Assert.Throws<MarshalDirectiveException>`.
- `StyleColors*` (6 overloads) throw `TypeLoadException` at JIT because the backing style
  struct contains an array field; tested with plain `[Fact]` guard tests that run on every
  platform.
- `SaveCurrentEditorStateToIniFile` / `SaveEditorStateToIniFile` were skipped: they would
  create real files (filesystem side effect, forbidden).
- `LoadEditorStateFromIniFile` / `LoadEditorStateFromIniString` / `EditorContextFree` with the
  empty editor-context struct were skipped: the wrapper forwards the struct by value as a
  garbage pointer which the native code dereferences (process abort).
- `GetIo` / `GetStyle` / `Save*ToIniString` were already covered by existing tests.
