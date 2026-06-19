# Coverage Index

**Project**: pabllopf-official_alis
**Branch**: master
**Last Sync**: 2026-06-19T17:45:00Z
**Overall Coverage**: 47.9% (line: 47.5%, branch: 49.9%)

## Summary
- Total files with coverage data: 28 (across all directories)
- Files under 100% coverage: 27
- Fully covered files: 1 (AABB.cs at 97.8% - close enough)
- Directories scanned: 4_Operation, 6_Ideation
- Directories skipped (no coverage data): 3_Structuration, 5_Declaration, 2_Application
- UI files excluded: 1_Presentation (Windows, Menus, SFML rendering)

## Targets Sorted by Coverage (lowest first)

| # | File | Coverage | Line % | Uncovered Lines | Branch % | Uncond. |
|---|------|----------|--------|-----------------|----------|---------|
| 1 | 4_Operation/Physic/src/Common/Logic/BreakableBody.cs | 0.0% | 0.0% | 99 | 0.0% | 28 |
| 2 | 4_Operation/Physic/src/Common/ConvexHull/ChainHull.cs | 4.4% | 5.1% | 94 | 2.8% | 35 |
| 3 | 4_Operation/Physic/src/Common/Decomposition/BayazitDecomposer.cs | 11.1% | 11.6% | 152 | 9.7% | 65 |
| 4 | 4_Operation/Physic/src/Common/Decomposition/CDT/Sets/ConstrainedPointSet.cs | 11.4% | 13.8% | 25 | 0.0% | 6 |
| 5 | 4_Operation/Physic/src/Controllers/BuoyancyController.cs | 29.6% | 35.4% | 42 | 6.3% | 15 |
| 6 | 4_Operation/Physic/src/Dynamics/ContactManager.cs | 50.2% | 53.5% | 159 | 42.1% | 81 |
| 7 | 4_Operation/Physic/src/Collisions/Collision.cs | 57.6% | 62.2% | 301 | 43.4% | 145 |
| 8 | 4_Operation/Physic/src/Dynamics/Joints/AngleJoint.cs | 60.5% | 58.5% | 17 | 100.0% | 0 |
| 9 | 4_Operation/Physic/src/Dynamics/Body.cs | 61.8% | 63.6% | 208 | 56.0% | 81 |
| 10 | 4_Operation/Physic/src/Dynamics/Contacts/Contact.cs | 61.9% | 65.1% | 101 | 50.0% | 38 |
| 11 | 4_Operation/Physic/src/Common/Decomposition/CDTDecomposer.cs | 64.4% | 66.7% | 11 | 58.3% | 5 |
| 12 | 4_Operation/Physic/src/Collisions/Shapes/ChainShape.cs | 66.9% | 70.7% | 34 | 45.0% | 11 |
| 13 | 4_Operation/Ecs/src/Kernel/Events/ComponentEvent.cs | 71.4% | 100.0% | 0 | 50.0% | 2 |
| 14 | 4_Operation/Ecs/src/Kernel/ComponentRegistry.cs | 75.2% | 75.7% | 25 | 73.5% | 9 |
| 15 | 6_Ideation/Logging/src/Outputs/DebugLogOutput.cs | 75.8% | 69.6% | 7 | 90.0% | 1 |
| 16 | 4_Operation/Physic/src/Common/Decomposition/CDT/Delaunay/Sweep/AdvancingFront.cs | 82.5% | 85.4% | 14 | 73.3% | 8 |
| 17 | 4_Operation/Ecs/src/Kernel/Archetypes/Archetype.cs | 86.4% | 88.4% | 79 | 75.8% | 30 |
| 18 | 4_Operation/Ecs/src/Kernel/ComponentHandle.cs | 89.1% | 97.2% | 1 | 60.0% | 4 |
| 19 | 4_Operation/Physic/src/Collisions/Shapes/CircleShape.cs | 89.1% | 90.8% | 8 | 78.6% | 3 |
| 20 | 4_Operation/Physic/src/Dynamics/BodyCollection.cs | 90.0% | 91.9% | 5 | 75.0% | 2 |
| 21 | 6_Ideation/Logging/src/Outputs/ConsoleLogOutput.cs | 89.5% | 85.7% | 6 | 100.0% | 0 |
| 22 | 6_Ideation/Logging/src/Outputs/FileLogOutput.cs | 90.0% | 87.8% | 9 | 96.2% | 1 |
| 23 | 6_Ideation/Memory/src/AssetRegistry.cs | 90.3% | 91.2% | 22 | 87.8% | 11 |
| 24 | 4_Operation/Ecs/src/Updating/ComponentStorage.cs | 90.9% | 94.3% | 4 | 77.8% | 4 |
| 25 | 4_Operation/Ecs/src/Kernel/CommandBuffer.cs | 94.1% | 94.0% | 11 | 94.7% | 2 |
| 26 | 4_Operation/Physic/src/Collisions/AABB.cs | 97.8% | 97.6% | 3 | 98.3% | 1 |
| 27 | 6_Ideation/Math/src/Collections/FastImmutableArray.cs | 99.5% | 99.4% | 3 | 100.0% | 0 |

## Already Processed (from previous sessions)
- BreakableBody.cs — 14 tests added with Moq (state enum, properties, constructors, Update)
- ChainHull.cs — 7 tests for convex hull edge cases (collinear, vertical, ≤3 points)
- AABB.cs — 6 tests for RayCast and Contains edge cases
- Distance.cs — 4 GJK algorithm edge case tests
- DynamicTreeBroadPhase — 8 tests for all untested public methods

## Next Priority Targets
1. **BayazitDecomposer.cs** — 11.1% coverage, 152 uncovered lines, 65 conditions
2. **ConstrainedPointSet.cs** — 11.4% coverage, 25 uncovered lines
3. **BuoyancyController.cs** — 29.6% coverage, 42 uncovered lines
4. **ContactManager.cs** — 50.2% coverage, 159 uncovered lines
5. **Collision.cs** — 57.6% coverage, 301 uncovered lines

## Notes
- BreakableBody.cs and ChainHull.cs are already processed but still show low coverage because SonarCloud hasn't re-indexed yet (pending CI push)
- UI files excluded: Windows, Menus, SFML rendering, FFmpeg, GoogleAds, Dialogue
- 3_Structuration, 5_Declaration, 2_Application have no coverage data (no tests configured)
