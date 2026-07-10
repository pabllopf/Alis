## TEST RECORD

### File Under Test
`4_Operation/Ecs/src/Updating/SingleComponentUpdateFilter.cs`

### Test File
`4_Operation/Ecs/test/Updating/SingleComponentUpdateFilterCoverageTest.cs`

### Pattern
Deferred creation pattern via `scene.EnterDisallowState()` / `scene.ExitDisallowState(filter, true)` to trigger `UpdateSubset` internally.

### Key Insights
- `UpdateSubset` is called from `Scene.ResolveUpdateDeferredCreationEntities` when `ExitDisallowState` is invoked with `updateDeferredEntities=true`
- The method processes only newly created entities during disallow state using `initalEntityCount` to skip existing entities
- When an archetype does not contain the filter's component, `componentIndex == 0` and the archetype is safely skipped

### Passing
✅ All 4 tests pass
