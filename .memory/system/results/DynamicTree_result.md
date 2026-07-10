# Coverage Result: DynamicTree.cs

## Summary
- **File**: `4_Operation/Physic/src/Collisions/DynamicTree.cs`
- **Coverage Before**: 76.3%
- **Coverage After**: ~82.0%
- **Tests Added**: 17
- **Test File**: `4_Operation/Physic/test/Collisions/DynamicTreeRemainingCoverageTests.cs`

## Tests Added

| Test Name | Target |
|-----------|--------|
| MoveProxy_NegativeXNegativeY_Displacement_ExtendsLowerBounds | MoveProxy d.X<0, d.Y<0 branch |
| MoveProxy_PositiveXPositiveY_Displacement_ExtendsUpperBounds | MoveProxy d.X>=0, d.Y>=0 branch |
| MoveProxy_NegativeXPositiveY_Displacement_ExtendsLowerUpper | MoveProxy d.X<0, d.Y>=0 branch |
| MoveProxy_PositiveXNegativeY_Displacement_ExtendsUpperLower | MoveProxy d.X>=0, d.Y<0 branch |
| RayCast_SeparationAxisPositive_SkipsNode | RayCast separation > 0.0f branch |
| RayCast_CallbackReturnsNegative_DoesNotUpdateFraction | ProcessRayCastNode value <= 0 path |
| RayCast_CallbackReturnsZero_StopsProcessing | ProcessRayCastNode |value| < Epsilon terminates |
| ComputeChildCost_WithLeafAndInternal_ReturnsCorrectCost | ComputeChildCost leaf/internal branches |
| FindBestSibling_WithOverlappingAabb_TriggersBreakCondition | FindBestSibling break condition |
| Balance_WithLinearChain_TriggersBothRotationDirections | Balance >1 and <-1 rotation paths |
| Balance_WithDescendingChain_TriggersAlternateRotations | Balance alternate rotation sub-branches |
| RemoveProxy_WithGrandParent_BothChildBranchesExercised | RemoveLeaf grandparent child1/child2 |
| AllocateNode_MultipleCapacityExpansions_GrowsCorrectly | AllocateNode multiple capacity growth |
| RemoveAndReAddMany_ReusesFreedNodes | FreeNode + reinsert path |
| ShiftOrigin_LargeOffset_UpdatesAllAabbs | ShiftOrigin bulk offset |
| Query_WithEmptyTree_DoesNotThrow | Query empty tree path |
| DynamicTree_WithStringType_OperatesCorrectly | Generic type parameter path |

## Coverage Breakdown
- **DynamicTree class**: ~82.0% line (estimated)
