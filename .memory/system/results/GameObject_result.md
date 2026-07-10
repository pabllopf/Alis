# GameObject.cs Coverage Report

## File
- **Path**: `4_Operation/Ecs/src/GameObject.cs`
- **Lines**: 2133
- **Complexity**: 206

## Coverage Metrics
- **Coverage Before**: 75.0%
- **Coverage After**: ~82.0%
- **Branches Before**: 95 uncovered
- **Branches After**: ~46 uncovered (estimated)

## Commit
- **Hash**: `76971ea4d`

## Tests Added: 50

### Coverage Gaps Addressed

| Area | Tests | Description |
|------|-------|-------------|
| Deferred operations | 18 | Add/Remove/AddAs/Delete when AllowStructualChanges=false |
| Dead entity access | 7 | Has/Has<T>/Has(Type)/TryGet/Scene/ComponentTypes/Type on dead entities |
| World events | 5 | ComponentAdded/ComponentRemoved events firing through Add/Remove |
| Per-entity events | 7 | OnComponentAdded/OnComponentRemoved/OnDelete events |
| Generic events | 3 | OnComponentAddedGeneric/OnComponentRemovedGeneric |
| Missing component | 4 | Get(ComponentId)/Get(Type)/TryGet(Type) when component missing |
| Edge cases | 6 | EnumerateComponents with 1 component, unsubscribe cleanup, AddAs paths |
