## COVERAGE TASK

### File
`4_Operation/Ecs/src/Updating/SingleComponentUpdateFilter.cs`

### Coverage Before
65.2%

### Uncovered Lines
84-95 (entire UpdateSubset method)

### Method
`UpdateSubset(ReadOnlySpan<ArchetypeDeferredUpdateRecord> archetypes)`

### Existing Tests
`4_Operation/Ecs/test/Updating/SingleComponentUpdateFilterTest.cs` — 13 tests but `UpdateSubset` was never called (misnamed test called `Update()` instead)

### Tests Added
`4_Operation/Ecs/test/Updating/SingleComponentUpdateFilterCoverageTest.cs` — 4 tests:
- `UpdateSubset_WithDeferredComponentEntity_UpdatesNewEntity`
- `UpdateSubset_WithDeferredNonComponentEntity_DoesNotThrow`
- `UpdateSubset_WithMixedDeferredEntities_UpdatesOnlyMatching`
- `UpdateSubset_WithMultipleDeferredEntities_UpdatesAll`

### Commit
323a3e7a9

### Status
✅ Complete
