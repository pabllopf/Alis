# Coverage Task 007 - Archetype.cs

## Status
Completed

## Commit
7f1f82e89 - test: coverage Archetype.cs

## Date
2026-07-09

## File
`4_Operation/Ecs/src/Kernel/Archetypes/Archetype.cs`

## Original Coverage
87.2% (Line: 89.1%, Branch: 76.6%)
74 uncovered lines, 29 uncovered branches

## Tests Added
`4_Operation/Ecs/test/Kernel/Archetypes/ArchetypeCoverage007Test.cs` (14 tests)

### Targets
1. **Multi-generic archetypes (4-8 components)**: Entities with 4, 5, 6, 7, 8 component types to exercise `Archetype<T1..T4>` through `Archetype<T1..T8>`
2. **ResolveDeferredEntityCreations overflow**: 3+ deferred entities in fresh scene trigger `deltaFromMaxDeferredInPlace > 0` branch with component buffer copy loop
3. **ResolveDeferredEntityCreations with many entities**: 50 deferred entities to fully exercise the copy loop in `ResolveDeferredEntityCreations`
4. **ResolveDeferredEntityCreations entity table reference update**: Exercises entity table reference loop after deferred resolution
5. **ModifyComponentLocationTable resize**: 17+ unique archetype combinations to force `ComponentTagLocationTable` resize
6. **GetHash with odd component count**: 3 component types exercises both h1 and h2 hash loops
7. **GetComponentIndex with ComponentId**: Non-generic overload coverage
8. **EnsureCapacity pool resize after deletions**: `FastestArrayPool.ResizeArrayFromPool` path
9. **GetArchetypeId cache miss**: New component combinations create new archetype entries
10. **Archetype transition graph**: Multiple add/remove cycles exercise `GetAdjacentArchetypeLookup`/`GetAdjacentArchetypeCold` with both edge types

## Result
All 14 tests pass.
