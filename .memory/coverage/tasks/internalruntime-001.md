## COVERAGE TASK

### File
2_Application/Alis/src/Core/Ecs/Systems/Execution/InternalRuntime.cs

### Coverage
62.1%

### Uncovered Lines
11 (OnPhysicUpdate, OnProcessPendingChanges, OnBeforeFixedUpdate, OnFixedUpdate, OnAfterFixedUpdate, OnDispatchEvents, OnCalculate, OnBeforeDraw, OnAfterDraw, OnRenderPresent, OnGui)

### Method
Multiple lifecycle forwarding methods

### Existing Tests
InternalRuntimeTest.cs — tests for ~18 of ~29 lifecycle methods

### Source Code
```csharp
public void OnPhysicUpdate() => runtimes.ForEach(x => x.OnPhysicUpdate());
public void OnProcessPendingChanges() => runtimes.ForEach(x => x.OnProcessPendingChanges());
public void OnBeforeFixedUpdate() => runtimes.ForEach(x => x.OnBeforeFixedUpdate());
public void OnFixedUpdate() => runtimes.ForEach(x => x.OnFixedUpdate());
public void OnAfterFixedUpdate() => runtimes.ForEach(x => x.OnAfterFixedUpdate());
public void OnDispatchEvents() => runtimes.ForEach(x => x.OnDispatchEvents());
public void OnCalculate() => runtimes.ForEach(x => x.OnCalculate());
public void OnBeforeDraw() => runtimes.ForEach(x => x.OnBeforeDraw());
public void OnAfterDraw() => runtimes.ForEach(x => x.OnAfterDraw());
public void OnRenderPresent() => runtimes.ForEach(x => x.OnRenderPresent());
public void OnGui() => runtimes.ForEach(x => x.OnGui());
```

### Plan
1. Add overrides for these 11 methods in TestRuntime class
2. Add [Fact] tests for each method following existing patterns
3. Build and run tests
