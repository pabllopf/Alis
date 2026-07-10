---
status: Active
updated: 2026-07-10T09:15:00Z
---

# Coverage Index

## Project
**Name:** Alis
**Key:** pabllopf-official_alis
**Branch:** master

## Current Coverage
- **Overall:** 63.3%
- **Line Coverage:** 62.4%
- **Branch Coverage:** 67.7%
- **Uncovered Lines:** 21,607
- **Uncovered Conditions:** 3,862
- **NCLOC:** 92,007

## Delta from Last Index (2026-07-08)
- **Overall:** +1.5% (was 61.8%)
- **Uncovered Lines:** -806 (was 22,413)
- **Uncovered Conditions:** -217 (was 4,079)

## Targets (Sorted by Priority)

| # | File | Coverage | UL | UC | Layer | Status |
|---|------|----------|----|----|-------|--------|
| 1 | 4_Operation/Graphic/src/Ui/Font.cs | 0.0% | 228 | - | Operation | ⬜ Blocked (Native/UI) |
| 2 | 4_Operation/Ecs/src/Kernel/Archetypes/Fields.cs | 0.0% | 5 | - | Operation | ✅ |
| 3 | 4_Operation/Ecs/src/Redifinition/Gen2GcCallback.cs | 37.0% | 24 | - | Operation | ⬅ ACTIVE |
| 4 | 4_Operation/Ecs/src/Updating/Runners/GameObjectUpdate.cs | 51.5% | 14 | - | Operation | ⬜ |
| 5 | 2_Application/Alis/src/Core/Ecs/Systems/Scope/ContextHandler.cs | 26.9% | 120 | - | Application | ⬜ |
| 6 | 2_Application/Alis/src/Core/Ecs/Systems/Manager/Graphic/GraphicManager.cs | 24.2% | 151 | - | Application | ⬜ Blocked (OpenGL) |
| 7 | 2_Application/Alis/src/Core/Ecs/Components/Collider/BoxCollider.cs | 41.7% | 151 | - | Application | ⬜ Blocked (OpenGL + ECS) |

## Processed Files

| File | Tests Added | Lines Added | Commit |
|------|------------|-------------|--------|
| SingleComponentUpdateFilter.cs | 4 | 132 | PENDING |
| DistanceJoint.cs | 13 | 282 | a4e02bafd |
| FrictionJoint.cs | 13 | 199 | e547ea826 |
| GearJoint.cs | 12 | 299 | d53583d51 |
| ContactManager.cs | 8 | 258 | d5fefccb9 |
| GravityController.cs | 9 | 213 | c6c7cde5d |
| ContactManager.cs (Evaluate/handlers) | 15 | 478 | c1ee01ea5 |
| GraphicManager.cs (lifecycle) | 3 | 89 | 692039671 |
| Body.cs (simulation paths) | 6 | 165 | afdda294d |
| Body.cs (wake/sleep, exceptions, ref overloads) | 14 | 228 | b4b2cfbf0 |

## Notes

- **GraphicManager/BoxCollider**: Remaining uncovered paths require OpenGL context or full ECS infrastructure. Integration tests with headless OpenGL or interface refactoring needed.
- **Gen2GcCallback**: ACTIVE target. Public registration API covered, missing finalizer/GCHandle paths.
- **Fields.cs**: 0.0% coverage - only method is `internal`, needs InternalsVisibleTo or indirect testing.
