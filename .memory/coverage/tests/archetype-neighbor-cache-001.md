# Tests for ArchetypeNeighborCache

## File
4_Operation/Ecs/test/Collections/ArchetypeNeighborCacheRemainingCoverageTests.cs

## Test Count
16

## Test Details

| Test | Target |
|------|--------|
| Traverse_Empty_Returns32 | Traverse on empty cache |
| Traverse_FindsKeyInSlot0 | Traverse match in slot 0 |
| Traverse_FindsKeyInSlot1 | Traverse match in slot 1 |
| Traverse_FindsKeyInSlot2 | Traverse match in slot 2 |
| Traverse_FindsKeyInSlot3 | Traverse match in slot 3 |
| Traverse_Miss_Returns32 | Traverse miss on full cache |
| TraverseArchetype_Empty_ReturnsNull | TraverseArchetype on empty cache |
| TraverseArchetype_Miss_ReturnsNull | TraverseArchetype miss |
| Lookup_ReturnsValuesForAllSlots | Lookup each slot |
| Lookup_IndexOutOfRange_ReturnsSlot3 | Lookup default case (index > 3) |
| Set_UshortOnly_SetsNullArchetype | Set(ushort, ushort) clears Archetype ref |
| RoundRobin_WrapsAround | Round-robin wrapping after 8 inserts |
| RoundRobin_EvictsOldEntries | Old entries evicted after wrap |
| WorksWithZeroKey | Key = 0 |
| WorksWithMaxKey | Key = ushort.MaxValue |
| SameKeyOverwritesSlot | Same key overwrites after round-robin |

## Status
All 16 tests pass.
