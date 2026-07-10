# Update.cs Coverage Report

## Summary
- **File**: `4_Operation/Ecs/src/Updating/Runners/Update.cs`
- **Coverage Before**: 70.7%
- **Coverage After**: ~72.5% (estimated)
- **Tests Added**: 8

## What Was Added
- `UpdateRemainingCoverageTests.cs` targeting:
  - **Zero-length range branch** (`length <= 0` early return) for arities 0, 2, 3, 4
  - **Range-based Run(Scene, Archetype, int, int)** for arities 0, 2, 3, 4 via deferred entity creation
  - Each test verifies the correct behaviour: no-op when length=0, and correct mutation when processing deferred entities

## Test Details
| Test | Arity | What It Covers |
|------|-------|----------------|
| `Update_Arity0_RangeZeroLength_DoesNotThrow` | 0 | `UpdateLoop.Run` early exit when `length <= 0` |
| `Update_Arity2_RangeZeroLength_DoesNotThrow` | 2 | Same for arity 2 |
| `Update_Arity3_RangeZeroLength_DoesNotThrow` | 3 | Same for arity 3 |
| `Update_Arity4_RangeZeroLength_DoesNotThrow` | 4 | Same for arity 4 |
| `Update_Arity0_RangeRun_ProcessesDeferredEntities` | 0 | `Update<TComp>.Run(Scene, Archetype, int, int)` range path |
| `Update_Arity2_RangeRun_ProcessesDeferredEntitiesAndMutates` | 2 | `Update<TComp,TArg1,TArg2>.Run(Scene, Archetype, int, int)` range path |
| `Update_Arity3_RangeRun_ProcessesDeferredEntitiesAndMutates` | 3 | `Update<TComp,TArg1,TArg2,TArg3>.Run(Scene, Archetype, int, int)` range path |
| `Update_Arity4_RangeRun_ProcessesDeferredEntitiesAndMutates` | 4 | `Update<TComp,TArg1,TArg2,TArg3,TArg4>.Run(Scene, Archetype, int, int)` range path |

## Notes
- Arities 6, 7, 8 range-based tests could not be added due to a static constructor ordering issue (`TypeInitializationException`) when multiple `Archetype<N>` generic types are loaded in the same test run. These arities already have full-scene-update coverage in `UpdateAllClassesTest.cs` and `UpdateTest.cs`.
- All 8 tests pass in isolation and when run together (the static cctor issue only manifests when combining with other test classes that use different Archetype arities).
