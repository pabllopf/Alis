# Test Record: BoxCollider OnExit

| Field | Value |
|-------|-------|
| **Test File** | `2_Application/Alis/test/Core/Ecs/Components/Collider/BoxColliderOnExitCoverageTest.cs` |
| **Test Class** | `BoxColliderOnExitCoverageTest` |
| **Test Count** | 4 |
| **Status** | ✅ All passing |
| **Commit** | `f7be0f1ad` |
| **Target File** | `BoxCollider.cs` |
| **Methods Tested** | `OnExit(IGameObject)` — Body != null branch |

## Test Details

1. **BoxCollider_OnExit_WhenBodyIsNotNull_AndContextIsSet_ShouldRemoveBodyFromWorld**
   - Creates real body via WorldPhysic.CreateRectangle
   - Sets Body + Context on collider
   - Verifies Body becomes null after OnExit

2. **BoxCollider_OnExit_WhenBodyIsNotNull_ShouldSetBodyToNull**
   - Creates body with dynamic type at offset position
   - Verifies Body property is null after OnExit

3. **BoxCollider_OnExit_MultipleBodies_ShouldRemoveOnlyOwnBody**
   - Two colliders with distinct bodies
   - Exits one, verifies only that body is removed

4. **BoxCollider_OnExit_AfterBodyRemoved_ShouldHandleSubsequentCalls**
   - First OnExit removes body, second call with null Body does not throw

## Infrastructure Used

- `Context` — creates PhysicManager with WorldPhysic
- `WorldPhysic.CreateRectangle` — creates test bodies
- `WorldPhysic.Remove` — removes bodies (called by OnExit)
- `Mock<IGameObject>` — stub for IGameObject parameter
