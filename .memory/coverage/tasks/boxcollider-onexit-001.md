# Coverage Task: BoxCollider OnExit

| Field | Value |
|-------|-------|
| **Task ID** | boxcollider-onexit-001 |
| **File** | `2_Application/Alis/src/Core/Ecs/Components/Collider/BoxCollider.cs` |
| **SonarCloud Key** | `pabllopf-official_alis:2_Application/Alis/src/Core/Ecs/Components/Collider/BoxCollider.cs` |
| **Coverage (before)** | 27.6% |
| **Uncovered Lines** | 192 |
| **Priority** | 1 (lowest coverage file) |
| **Status** | ✅ COMPLETED |
| **Commit** | `f7be0f1ad` |
| **Date** | 2026-07-02 |

## Methods Covered

- `BoxCollider.OnExit(IGameObject)` — Body != null branch
  - `Context.PhysicManager.WorldPhysic.Remove(Body)` call
  - `Body = null` assignment

## Tests Added

- `BoxColliderOnExitCoverageTest` (4 tests)
  - `BoxCollider_OnExit_WhenBodyIsNotNull_AndContextIsSet_ShouldRemoveBodyFromWorld`
  - `BoxCollider_OnExit_WhenBodyIsNotNull_ShouldSetBodyToNull`
  - `BoxCollider_OnExit_MultipleBodies_ShouldRemoveOnlyOwnBody`
  - `BoxCollider_OnExit_AfterBodyRemoved_ShouldHandleSubsequentCalls`

## Remaining Gaps (documented, require engine infrastructure)

- `OnStart` full execution (~30 lines) — requires Scene + Transform component + ECS infrastructure
- `OnUpdate` with transform present + body not null (~10 lines) — requires ref-return Get<Transform>()
- Private methods (OnCollision, OnSeparation, InitializeShaders, RenderBoxCollider) (~130 lines) — OpenGL-dependent

## Pattern Learned

- Use `WorldPhysic.CreateRectangle` to create test bodies
- Use `Context()` to get a fully initialized PhysicManager with WorldPhysic
- Mock<IGameObject> suffices when OnExit's Body != null branch doesn't use the IGameObject parameter
- Use fully qualified `global::Alis.Core.Physic.Dynamics.Body` to avoid namespace shadowing
