# Coverage Index

> Generated: 2026-07-04T13:05:00Z
> Source: SonarCloud (project: pabllopf-official_alis, branch: master)

## Project Summary

| Metric | Value |
|--------|-------|
| Overall Coverage | 60.1% |
| Line Coverage | 59.3% |
| Branch Coverage | 63.9% |
| Uncovered Lines | 23,392 |
| Uncovered Conditions | 4,322 |
| Conditions to Cover | 11,979 |
| Total Files | 1,471 |
| Files with Uncovered Lines | 265 |

## Priority Queue

| # | File | Coverage | UncovLines | UncovCond | Layer |
|---|------|----------|-----------|-----------|-------|
| 1 | `4_Operation/Ecs/src/GameObject.cs` | 74.4% | 213 | 97 | 4_Operation |
| 2 | `4_Operation/Physic/src/Collisions/Collision.cs` | 61.7% | 267 | 136 | 4_Operation |
| 3 | `4_Operation/Physic/src/Common/Decomposition/CDT/Delaunay/Sweep/DTSweep.cs` | 48.9% | 333 | 109 | 4_Operation |
| 4 | `4_Operation/Physic/src/Dynamics/ContactManager.cs` | 53.1% | 149 | 77 | 4_Operation |
| 5 | `4_Operation/Physic/src/Dynamics/Contacts/ContactSolver.cs` | 61.5% | 218 | 64 | 4_Operation |
| 6 | `4_Operation/Physic/src/Dynamics/WorldPhysic.cs` | 65.9% | 308 | 112 | 4_Operation |
| 7 | `4_Operation/Graphic/src/Image.cs` | 46.9% | 178 | 68 | 4_Operation |
| 8 | `4_Operation/Graphic/src/OpenGL/Gl.cs` | 8.4% | 193 | 13 | 4_Operation |
| 9 | `2_Application/Alis/src/Core/Ecs/Systems/Manager/Scene/SceneManager.cs` | 16.9% | 208 | 86 | 2_Application |
| 10 | `2_Application/Alis/src/Core/Ecs/Components/Collider/BoxCollider.cs` | 28.2% | 190 | 44 | 2_Application |

## Processed Tasks

| # | File | Method | Commit | Status |
|---|------|--------|--------|--------|
| 1 | `PolygonShape.cs` | `ComputeSubmergedArea` — fully/partially submerged branches | `c36c21d6e` | Done |
| 2 | `PositionSolverManifold.cs` | `Initialize` — Circles/FaceA/FaceB/default branches + zero normal + separation | `cc4c2b338` | Done |
| 3 | `SeparationFunction.cs` | `Set` (FaceB + axis flips), `FindMinSeparation` (FaceA, FaceB), `Evaluate` (FaceB, Points) | `dd4520ed3` | Done |
| 4 | `TimeOfImpact.cs` | Overlapped state, diagnostics counters | `d5477552b` | Done |
| 5 | `FixedMouseJoint.cs` | SolvePositionConstraints, Init/SolveVelocityConstraints (WarmStarting branches) | `ea89d8266` | Done |

## Delta Tracking

| Date | Coverage Delta | Lines Covered | Files Processed |
|------|---------------|---------------|-----------------|
| 2026-07-04 | Baseline | 0 | 0 |
| 2026-07-04 | +5 tests for ComputeSubmergedArea | ~15-20 estimated | 1 |
| 2026-07-04 | +6 tests for PositionSolverManifold.Initialize | ~20-25 estimated | 2 |
| 2026-07-04 | +6 tests for SeparationFunction | ~15-20 estimated | 3 |
| 2026-07-04 | +3 tests for TimeOfImpact | ~10-15 estimated | 4 |
| 2026-07-04 | +4 tests for FixedMouseJoint (solver paths) | ~15-20 estimated | 5 |

## Notes

- Initial baseline established from SonarCloud
- Excluded native/PInvoke wrappers from priority due to testability constraints
- Priority given to 4_Operation and 2_Application layers with existing test projects
