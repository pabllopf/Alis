## COVERAGE TASK

### File
`4_Operation/Ecs/src/Updating/Runners/GameObjectUpdate.cs`

### Coverage Before
51.5%

### Uncovered Lines
78-96 (entire Run(Scene, Archetype, int, int) overload)

### Method
`Run(Scene scene, Archetype b, int start, int length)`

### Existing Tests
`GameObjectUpdateTest.cs` — 7 tests covering the first `Run` overload (via scene.Update()).  
`GameObjectUpdateCoverageTest.cs` — broken tests fixed, now 2 tests (non-matching archetype no-op).

### Tests Added
`GameObjectUpdateRangeRunTest.cs` — 3 tests:
- `RunRange_ThroughUpdateSubset_UpdatesOnlyNewEntities`
- `RunRange_ThroughUpdateSubset_UpdatesComponentData`
- `RunRange_ThroughUpdateSubset_MultipleDeferredEntities`

### Key Technique
Used `SingleComponentUpdateFilter` + `EnterDisallowState`/`ExitDisallowState(filter, true)` pattern to trigger `UpdateSubset`, which calls the range-based `Run` overload on `GameObjectUpdate<TComp, TArg>`.

### Commit
6c50547d6

### Status
✅ Complete
