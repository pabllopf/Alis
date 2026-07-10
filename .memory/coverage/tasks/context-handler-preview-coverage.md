## COVERAGE TASK

### File
2_Application/Alis/src/Core/Ecs/Systems/Scope/ContextHandler.cs

### Coverage Before
26.9%

### Uncovered Lines
120

### Methods Covered
- Preview() - time calculations, lifecycle dispatch, fixed-update loop, OnCalculate, OnBeforeDraw
- InitPreview() - preview mode setting, timing initialization
- Run() - early exit path (IsRunning = false at entry)

### Existing Tests
- Exit_ShouldSetIsRunningToFalse
- Save_OnDefaultContext_DoesNotThrow
- Load_OnDefaultContext_DoesNotThrow
- ContextProperty_ShouldReturnSameInstance
- Save_WithFilePath_DoesNotThrow
- InitPreview_WhenCalled_SetsPreviewMode
- Run_WhenAlreadyStopped_ExitsImmediately
- LoadAndRun_WhenAlreadyStopped_ExitsImmediately

### Tests Added
- Preview_AfterInitPreview_ThrowsInvalidOperationException
- Preview_WithoutInitPreview_ThrowsInvalidOperationException
- InitPreview_SetsPreviewMode_AndAllowsPreviewToStart

### Blocked Lines
- OnDraw, OnAfterDraw, OnGui, OnRenderPresent - require OpenGL context
- SmoothDeltaTime calculation and Thread.Sleep - require completing render pipeline

### Status
Completed (partial - Preview lines before OnDraw covered)
