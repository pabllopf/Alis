## COVERAGE TASK

### File
2_Application/Alis/src/Core/Ecs/Components/Render/Animator.cs

### Coverage
98.9%

### Uncovered Lines
1

### Methods Targeted
- GetCurrentFrame on default struct
- Play on default struct
- NextFrame on default struct
- OnStart after OnExit (clock restart)
- OnUpdate with high speed multiple updates
- AddAnimation ordering

### Existing Tests
- AnimatorTest.cs

### Changes
1. Added Animator_GetCurrentFrame_OnDefaultStruct_ThrowsNullReference
2. Added Animator_Play_OnDefaultStruct_ThrowsNullReference
3. Added Animator_NextFrame_OnDefaultStruct_ThrowsNullReference
4. Added Animator_OnStart_AfterOnExit_ClockRestarts
5. Added Animator_OnUpdate_WithHighSpeed_MultipleUpdates
6. Added Animator_AddAnimation_WithMultipleAnimations_OrdersCorrectly

### Status
COMPLETED

### Commit
c5837536f
