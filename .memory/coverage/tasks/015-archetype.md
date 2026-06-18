## COVERAGE TASK

### File
4_Operation/Ecs/src/Kernel/Archetypes/Archetype.cs

### Coverage
85.8% (before), 84 uncovered lines, 30 uncovered conditions

### Uncovered Lines
Lines covering: GetComponentSpan<T>(), GetComponentDataReference<T>(), DeleteEntity(), DeleteEntityFromStorage(), EnsureCapacity(), GetEntitySpan(), GetEntityDataReference(), GetComponentIndex<T>(), ReleaseArrays(), Update(Scene, int, int), GetHash(), CreateOrGetExistingArchetype (both branches), GetAdjacentArchetypeLookup (cache hit/cold), ModifyComponentLocationTable, GetArchetypeId exception paths

### Method
Archetype class — entity storage, component spans, archetype creation/transitions

### Existing Tests
- ArchetypeExtendedTest.cs (12 tests)
- ArchetypeOperationsTest.cs (8 tests)
- ArchetypeDataTest.cs
- ArchetypeEdgeKeyTest.cs
- ArchetypeEdgeTypeTest.cs

### Source Code
Archetype.cs — 1486 lines, 448 statements, complexity 109
