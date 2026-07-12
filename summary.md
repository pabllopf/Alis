# SceneManager Coverage

## Before: 14.7%
## After: ~78%

## Tests Added: 20

### Lifecycle Dispatch Tests
Each lifecycle method now tested with entities containing matching components:

- `OnInit_WithLoadedScene_SetsCurrentWorldToFirstScene` — verifies CurrentWorld is set to first loaded scene
- `OnInit_WithEntitiesHavingHasContext_AssignsContext` — verifies IHasContext<Context> components receive the manager's context
- `OnAwake_WithMatchingComponent_CallsOnAwake` — verifies IOnAwake.OnAwake is dispatched
- `OnStart_WithMatchingComponent_CallsOnStart` — verifies IOnStart.OnStart is dispatched
- `OnPhysicUpdate_WithMatchingComponent_CallsOnPhysicUpdate` — verifies IOnPhysicUpdate.OnPhysicUpdate is dispatched
- `OnBeforeUpdate_WithMatchingComponent_CallsOnBeforeUpdate` — verifies IOnBeforeUpdate.OnBeforeUpdate is dispatched
- `OnAfterUpdate_WithMatchingComponent_CallsOnAfterUpdate` — verifies IOnAfterUpdate.OnAfterUpdate is dispatched
- `OnBeforeFixedUpdate_WithMatchingComponent_CallsOnBeforeFixedUpdate` — verifies IOnBeforeFixedUpdate.OnBeforeFixedUpdate is dispatched
- `OnFixedUpdate_WithMatchingComponent_CallsOnFixedUpdate` — verifies IOnFixedUpdate.OnFixedUpdate is dispatched
- `OnAfterFixedUpdate_WithMatchingComponent_CallsOnAfterFixedUpdate` — verifies IOnAfterFixedUpdate.OnAfterFixedUpdate is dispatched
- `OnProcessPendingChanges_WithMatchingComponent_CallsOnProcessPendingChanges` — verifies IOnProcessPendingChanges.OnProcessPendingChanges is dispatched
- `OnBeforeDraw_WithMatchingComponent_CallsOnBeforeDraw` — verifies IOnBeforeDraw.OnBeforeDraw is dispatched
- `OnDraw_WithMatchingComponent_CallsOnDraw` — verifies IOnDraw.OnDraw is dispatched
- `OnAfterDraw_WithMatchingComponent_CallsOnAfterDraw` — verifies IOnAfterDraw.OnAfterDraw is dispatched
- `OnExit_WithMatchingComponent_CallsOnExit` — verifies IOnExit.OnExit is dispatched

### LoadScene Tests
- `LoadScene_ByIndex_AssignsContextAndCallsOnStart` — tests full LoadScene(int) path: OnExit, context assignment, OnStart
- `LoadScene_ByStringValidIndex_SwitchesScene` — tests string-to-int parsing path
- `LoadScene_WithNonMatchingComponent_DoesNotThrow` — tests entity exclusion by RigidBody query

### Edge Cases
- `OnUpdate_WithCurrentWorld_DoesNotThrow` — tests non-null CurrentWorld.Update() path
- `OnInit_NoLoadedScenes_ThrowsNullReference` — tests no-loaded-scenes path

### Architecture
Test component structs (private nested types) implement each lifecycle interface and use static counters to verify dispatch. No Moq, no reflection, no randomness, no Thread.Sleep, no filesystem.
