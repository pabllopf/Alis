# ImNodes.cs — Coverage Remediation Report

## Baseline (this session, pre-change)
- 332/400 instrumentable lines covered (83%); 68 missed

## Change
- Added `CurrentContextSaveFile_Executes` to `1_Presentation/Extension/Graphic/Ui/test/Extras/Node/ImNodesRemainingCoverageTests.cs`
- Exercises the non-null branch of `SaveCurrentEditorStateToIniFile(string)` against the default editor context (writes `/tmp/alis_imnodes_current_save.ini`)
- Result: 339/400 covered (84.8%), +7 lines (src 830-836)

## Remaining 61 lines — PARTIAL_BLOCKED_BY_PRODUCTION_CODE

### Evidence of host in-safety (each family was attempted and aborts the test host)
- `EditorContextFree` (206-208), editor-variant load/save (`LoadEditorStateFromIni*` 641-651, 660-670; `SaveEditorStateToIniFile` 888-898), and `Save*ToIniString` return conversions (854, 860, 874, 880, 909-910, 922-923)
  - Root cause: `ImNodesEditorContext` is an EMPTY struct. `ImNodes_EditorContextCreate()` P/Invoke returns a pointer but the wrapper discards it (`new ImNodesEditorContext()`), so the binding can never supply a real editor handle; native paths assert on `editor == NULL`.
- Null-string ini branches (612-614 load-file, 630-632 load-string, 837-839 save-file null branch): null `byte[]` reaches `fopen((const char*)NULL)` / null-size load → native abort.

### Marshal-throw (existing tests already assert these exceptions)
- MiniMap overload closers (682, 694, 706, 718, 730): `ImNodes_MiniMap` delegate parameter is unmarshalable → MarshalDirectiveException/TypeLoadException before the closing brace.
- StyleColors Classic/Dark/Light overload closers (1017, 1026, 1034, 1043, 1051, 1060): struct with array field is unmarshalable → TypeLoadException before the closing brace.

## TestsAdded
- 1 (`CurrentContextSaveFile_Executes`)

## Commit
- (pending commit: test: coverage ImNodes.cs)