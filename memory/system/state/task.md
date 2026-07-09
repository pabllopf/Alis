# BoxCollider Coverage Task

- **Commit**: 2026-07-09
- **Timestamp**: 2026-07-09T00:00:00Z
- **File**: `pabllopf-official_alis:2_Application/Alis/src/Core/Ecs/Components/Collider/BoxCollider.cs`
- **Methods Covered**: 
  - `OnStart(IGameObject)` — no-op path when GameObject lacks Transform
  - `OnUpdate(IGameObject)` — full path when GameObject has Transform AND Body is not null (syncs Position/Rotation)
  - `OnUpdate(IGameObject)` — no-op path when GameObject lacks Transform
  - `OnUpdate(IGameObject)` — no-op path when Body is null
  - `OnExit(IGameObject)` — no-op path when Body is null
  - `OnExit(IGameObject)` — throws NullReferenceException when Body is not null but Context is null
- **Test File**: `2_Application/Alis/test/Core/Ecs/Components/Collider/BoxColliderOnStartOnUpdateOnExitTests.cs`
- **Estimated Coverage Improvement**: ~12-15% (6 new tests covering OnStart/OnUpdate/OnExit execution paths)
- **Notes**: 
  - Full OnStart path (with Transform + GameObject cast) skipped — requires real GameObject inheritance which is impractical for unit tests
  - Full OnExit path (removing body from world) skipped — requires Context with proper PhysicManager setup
  - All tests use only public APIs; no internal members accessed
