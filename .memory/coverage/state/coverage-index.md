---
status: Active
updated: 2026-07-08T09:15:00Z
---

# Coverage Index

## Project
**Name:** Alis
**Key:** pabllopf-official_alis
**Branch:** master

## Current Coverage
- **Overall:** 61.8%
- **Line Coverage:** 61.0%
- **Branch Coverage:** 65.9%
- **Uncovered Lines:** 22,413
- **Uncovered Conditions:** 4,079
- **NCLOC:** 92,007

## Targets (Sorted by Priority)

| # | File | Coverage | UL | UC | Layer | Status |
|---|------|----------|----|----|-------|--------|
| 1 | 4_Operation/Physic/src/Dynamics/Joints/DistanceJoint.cs | 19.6% | 117 | 14 | Operation | ✅ |
| 2 | 4_Operation/Physic/src/Dynamics/Joints/FrictionJoint.cs | 20.6% | 94 | 6 | Operation | ✅ |
| 3 | 4_Operation/Physic/src/Dynamics/Joints/GearJoint.cs | 28.1% | 198 | 14 | Operation | ✅ |
| 4 | 4_Operation/Physic/src/Dynamics/ContactManager.cs | 56.8% | 141 | 67 | Operation | ✅ |
| 5 | 4_Operation/Physic/src/Controllers/GravityController.cs | 34.8% | 40 | 33 | Operation | ✅ |
| 6 | 2_Application/Alis/src/Core/Ecs/Systems/Manager/Graphic/GraphicManager.cs | 23.4% | 153 | 50 | Application | ⬜ Blocked (OpenGL) |
| 7 | 2_Application/Alis/src/Core/Ecs/Components/Collider/BoxCollider.cs | 39.3% | 158 | 40 | Application | ⬜ Blocked (OpenGL + ECS) |

## Processed Files

| File | Tests Added | Lines Added | Commit |
|------|------------|-------------|--------|
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
- **ContactManager/Contact**: 15 Step()-based tests cover Evaluate variants (Polygon, Edge, Chain), sensor fixtures, OnCollision/OnSeparation/BeginContact/EndContact/PreSolve delegates, and warm starting.
- **AABB.cs**: Already has 38 tests (pre-existing AabbTest.cs). All public methods covered.
- **Body.cs (simulation)**: 6 Step()-based tests cover FixedRotation, IgnoreGravity, Enabled=false, sleep/wake, CollideConnected joint, world-Rotation setter.
- **Body.cs (uncovered paths)**: 14 additional tests cover GetBodyType same-value, LocalCenter non-dynamic, Inertia offset, duplicate fixture exceptions, Apply*/wake-from-sleep, ref overloads, static-body no-op.
