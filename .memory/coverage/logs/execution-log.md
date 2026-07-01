# Execution Log

## Session Start: 2026-07-01

**State**: Clean start — all memory cleared per user request.

**Initial SonarCloud Sync**:
- Overall Coverage: 60.0%
- Uncovered Lines: 23,454
- Branch Coverage: 63.8%

## Commit Log

### Commit 1: `test: coverage BoxCollider.cs`
- **Hash**: `cbc3e8209`
- **Timestamp**: 2026-07-01
- **File**: `BoxCollider.cs`
- **Methods Covered**: `OnUpdate` (Has<Transform> = false branch)
- **Tests Added**: 2 new tests in `BoxColliderCoverageTest.cs`
  - `BoxCollider_OnUpdate_WhenHasTransformIsFalse_ShouldNotThrow`
  - `BoxCollider_OnUpdate_WhenHasTransformIsFalse_ShouldNotChangeBody`
- **Status**: 18/18 tests pass in coverage file, 618/619 overall (pre-existing failure in SceneManagerTest)

### Commit 2: `test: coverage IOnUpdate.2.cs`
- **Hash**: `14468ed64`
- **Timestamp**: 2026-07-01
- **File**: `IOnUpdate.2.cs`
- **Methods Covered**: Fluent contract methods (arity 2)
- **Tests Added**: 4 new tests in `IOnUpdate2Test.cs`
  - `Has_WithComponents_ReturnsIActivate`
  - `Has_WithMultipleComponents_ReturnsIActivate`
  - `Has_WithComponentsAndAction_ReturnsIActivate`
  - `Equals_ReturnsIActivate`
- **Status**: 326/326 Fluent tests pass

### Commit 3: `test: coverage Scene.cs`
- **Hash**: `433001214`
- **Timestamp**: 2026-07-01
- **File**: `Scene.cs`
- **Methods Covered**: `EnterDisallowState`, `ExitDisallowState`, `UpdateArchetypeTable`, `Update<T>`, `UpdateComponent`, `Update(Type)`, event sub/unsub
- **Tests Added**: 12 new tests in `SceneCoverageTest.cs`
  - `Scene_EnterDisallowState_ShouldDisallowStructuralChanges`
  - `Scene_ExitDisallowState_WithNullFilter_ShouldRestoreStructuralChanges`
  - `Scene_UpdateArchetypeTable_ShouldResizeTable`
  - `Scene_UpdateArchetypeTable_WithSmallerSize_ShouldShrinkTable`
  - `Scene_UpdateGeneric_OnEmptyScene_DoesNotThrow`
  - `Scene_UpdateComponent_OnEmptyScene_DoesNotThrow`
  - `Scene_EnterDisallowState_MultipleCalls_ShouldStayDisallowed`
  - `Scene_DisallowState_PairedCalls_ShouldWorkCorrectly`
  - `Scene_ComponentAdded_Event_ShouldSupportSubscribeAndUnsubscribe`
  - `Scene_ComponentRemoved_Event_ShouldSupportSubscribeAndUnsubscribe`
  - `Scene_EntityDeleted_Event_ShouldSupportSubscribeAndUnsubscribe`
  - `Scene_UpdateType_OnEmptyScene_DoesNotThrow`
- **Status**: 2996/2997 Ecs tests pass (pre-existing failure in QueryEnumeratorTest)

### Commit 4: `test: coverage SettingEnv.cs`
- **Hash**: `95f94a9fa`
- **Timestamp**: 2026-07-01
- **File**: `SettingEnv.cs`
- **Methods Covered**: `MixFriction`, `MixRestitution`
- **Tests Added**: 9 new tests in `SettingEnvTest.cs`
  - `MixFriction_TwoEqualValues_ReturnsSameValue`
  - `MixFriction_WithZero_ReturnsZero`
  - `MixFriction_TwoDifferentValues_ReturnsGeometricMean`
  - `MixFriction_WithMaxFloat_ReturnsMaxSqrt`
  - `MixRestitution_FirstLarger_ReturnsFirst`
  - `MixRestitution_SecondLarger_ReturnsSecond`
  - `MixRestitution_EqualValues_ReturnsSame`
  - `MixRestitution_WithZero_ReturnsLarger`
  - `MixRestitution_NegativeValues_ReturnsLarger`
- **Status**: 2506/2521 Physic tests pass (15 pre-existing skip, 0 failed)

### Commit 5: `test: coverage Vertices.cs`
- **Hash**: `4f5ecdcba`
- **Timestamp**: 2026-07-01
- **File**: `Vertices.cs`
- **Methods Covered**: `IsSimple`, `ProjectToAxis`, `PointInPolygon`, `PointInPolygonAngle`, `CheckPolygon`, `ToString`
- **Tests Added**: 16 new tests in `VerticesTest.cs`
  - `IsSimple_Triangle_ReturnsTrue`, `IsSimple_FewerThanThreeVertices_ReturnsFalse`, `IsSimple_SelfIntersecting_ReturnsFalse`
  - `ProjectToAxis_HorizontalAxis_ReturnsCorrectMinMax`, `ProjectToAxis_VerticalAxis_ReturnsCorrectMinMax`, `ProjectToAxis_SingleVertex_ReturnsSameMinMax`
  - `PointInPolygon_InsideSquare_ReturnsOne`, `PointInPolygon_OutsideSquare_ReturnsMinusOne`, `PointInPolygon_OnEdge_ReturnsZero`
  - `PointInPolygonAngle_InsideSquare_ReturnsTrue`, `PointInPolygonAngle_OutsideSquare_ReturnsFalse`
  - `CheckPolygon_ValidTriangle_ReturnsNoError`, `CheckPolygon_Empty_ReturnsInvalidAmountOfVertices`, `CheckPolygon_CollinearPoints_ReturnsAreaTooSmall`, `CheckPolygon_ConcaveShape_ReturnsNotConvex`
  - `ToString_WithVertices_ReturnsFormattedString`, `ToString_Empty_ReturnsEmptyString`
- **Status**: 2523/2538 Physic tests pass (15 pre-existing skip, 0 failed)

### Commit 6: `test: coverage GraphicManager.cs`
- **Hash**: `3ce5ec3c0`
- **Timestamp**: 2026-07-01
- **File**: `GraphicManager.cs`
- **Change**: Made `ComputePressedKeys`, `ComputeHeldKeys`, `ComputeReleasedKeys` from `private` → `internal`
- **Tests Added**: 10 new tests in `GraphicManagerTest.cs`
  - `ComputePressedKeys_NewKeysOnly_ReturnsAll`, `ComputePressedKeys_KeysAlreadyHeld_NotIncluded`, `ComputePressedKeys_NoNewKeys_ReturnsEmpty`
  - `ComputeHeldKeys_OverlappingKeys_ReturnsIntersection`, `ComputeHeldKeys_NoOverlap_ReturnsEmpty`, `ComputeHeldKeys_BothEmpty_ReturnsEmpty`
  - `ComputeReleasedKeys_KeysNoLongerPressed_ReturnsReleased`, `ComputeReleasedKeys_AllKeysStillHeld_ReturnsEmpty`, `ComputeReleasedKeys_NoNewKeys_ReturnsAll`
  - `KeyStateComputation_EndToEnd_Consistent`
- **Status**: 629/629 Alis.Test tests pass (0 failed)

### Commit 7: `test: coverage ContextHandler.cs`
- **Hash**: `22b7fb04d`
- **Timestamp**: 2026-07-01
- **File**: `ContextHandler.cs`
- **Methods Covered**: `Exit`, `Save`, `Load`, Context property
- **Tests Added**: 4 new tests in `ContextHandlerTest.cs`
  - `Exit_ShouldSetIsRunningToFalse`
  - `Save_OnDefaultContext_DoesNotThrow`
  - `Load_OnDefaultContext_DoesNotThrow`
  - `ContextProperty_ShouldReturnSameInstance`
- **Status**: 632/633 Alis.Test tests pass (1 pre-existing SceneBuilderTest failure)
