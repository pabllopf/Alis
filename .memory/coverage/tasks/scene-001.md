## COVERAGE TASK

### File

4_Operation/Ecs/src/Scene.cs

### Coverage

86.5%

### Uncovered Lines

~105 lines (estimated, SonarCloud)

### Methods

1. `Create()` — no-parameter overload
2. `CreateEntityWithoutEvent()`
3. `InvokeEntityCreated(GameObject)`
4. `CreateFromObjects(ReadOnlySpan<object>)`
5. `EnsureCapacity(GameObjectType, int)`
6. `EnsureCapacityCore(Archetype, int)` — validation path
7. `Update()` — parameterless update

### Existing Tests

- `Scene_CanBeCreated`
- `Scene_HasUniqueId`
- `Scene_StartsWithZeroEntities`
- `Scene_CanCreateEntityWithComponent`
- `Scene_EntityCountIncreasesWhenCreatingEntities`
- `Scene_CanCreateMultipleEntities`
- `Scene_HasDefaultArchetype`
- `Scene_HasDefaultWorldGameObject`
- `Scene_AllowStructuralChangesReturnsTrueByDefault`
- `Scene_CanBeDisposed`
- `Scene_EntityCreatedEventIsInvoked`
- `Scene_RecycledEntityIdsStackExists`
- `Scene_CommandBufferExists`
- `Scene_EntityTableIsInitialized`
- `Scene_ArchetypeGraphEdgesIsInitialized`
- `Scene_QueryCacheIsInitialized`
- `Scene_SharedCountdownIsInitialized`
- `Scene_CanCreateEntityWithMultipleComponents`
- `CreateMany_WithZeroCount_ThrowsException`
- `CreateMany_WithNegativeCount_ThrowsException`
- `Scene_CanHandleLargeNumberOfEntities`
- `Scene_WorldEventFlagsStartsAsNone`

### Plan

Add tests covering:
- `Create()` without components → verifies entity creation with DefaultArchetype
- `CreateEntityWithoutEvent()` → verifies no EntityCreated event fires
- `InvokeEntityCreated()` → verifies event fires when explicitly invoked
- `CreateFromObjects()` → verifies creation from runtime span of objects
- `EnsureCapacity()` with zero count → verifies early return
- `EnsureCapacityCore()` with zero count → verifies ArgumentOutOfRangeException
- `Update()` → verifies no-throw on empty scene
