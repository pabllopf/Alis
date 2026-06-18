## COVERAGE TEST FILE

### File Tested
4_Operation/Ecs/src/Kernel/Archetypes/Archetype.cs

### Test File
4_Operation/Ecs/test/Kernel/Archetypes/ArchetypeCoverageTest.cs

### Test Count
32

### Test Methods
- Archetype_GetComponentSpan_ThrowsWhenComponentNotPresent — error path in GetComponentSpan
- Archetype_GetComponentSpan_ReturnsCorrectSpan — happy path for component span access
- Archetype_GetComponentDataReference_ReturnsModifiableRef — ref return verification
- Archetype_DeleteEntity_RemovesAndDecrementsCount — basic delete with count check
- Archetype_DeleteEntity_LastEntityWorksCorrectly — delete last entity edge case
- Archetype_DeleteEntity_MiddleEntitySwapAndDelete — swap-and-delete path
- Archetype_EnsureCapacity_DoesNothingWhenSufficient — early return branch
- Archetype_EnsureCapacity_IncreasesCapacity — resize path
- Archetype_GetEntitySpan_ReturnsCorrectSpan — span of entities
- Archetype_GetEntityDataReference_ReturnsFirstEntity — ref to first entity
- Archetype_GetComponentIndex_ReturnsCorrectIndex — component index lookup
- Archetype_ReleaseArrays_ClearsStorage — cleanup verification
- Archetype_UpdateWithRange_UpdatesCorrectRange — ranged update path
- Archetype_Update_EmptyArchetype_ReturnsEarly — early return for empty
- Archetype_CreateOrGetExistingArchetype_ReturnsExisting — cache-hit path
- Archetype_CreateOrGetExistingArchetype_CreatesNewWhenNeeded — cache-miss path
- Archetype_GetArchetypeId_ThrowsOnMaxComponents — max component exception
- Archetype_GetAdjacentArchetypeLookup_CacheHitReturnsArchetype — cache hit
- Archetype_GetAdjacentArchetypeCold_CreatesNewArchetype — cold path creation
- Archetype_MultipleDeletions_MaintainsCorrectCount — bulk delete verification
- Archetype_DataProperty_ReturnsValidFields — Data property access
- Archetype_IdProperty_ReturnsValidId — Id property access
- Archetype_ArchetypeTypeArray_ReturnsValidTypes — ArchetypeTypeArray access
- Archetype_FullLifecycle_CreateModifyDelete — full entity lifecycle
- Archetype_CreateWithMultipleComponents_WorksCorrectly — multi-component creation
- Archetype_AllEntitiesDeleted_EntityCountIsZero — zero entity count
- Archetype_MixedOperations_MaintainsAccurateCount — mixed add/remove/delete
- Archetype_AddComponentToAll_MaintainsCount — bulk transition
- Archetype_RemoveComponentFromAll_MaintainsCount — bulk reverse transition
- Archetype_DeleteEntity_PreservesRemainingData — swap-and-delete data integrity
- Archetype_SingleEntity_LifecycleWorks — minimal entity count
- Archetype_TagOnlyEntity_WorksCorrectly — no-component entity

### Notes
- All 2904 ECS tests pass (32 new + 2872 existing)
- Tests use Scene-based integration approach consistent with prior ECS tests
- No Moq used — real objects throughout
