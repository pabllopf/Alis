## COVERAGE TASK

### File
4_Operation/Ecs/src/Redifinition/Gen2GcCallback.cs

### Coverage
37.0% → ~75% (estimated pending SonarCloud sync)

### Uncovered Lines
24 lines (finalizer body, GCHandle management, static constructor lambda)

### Methods Covered
- `~Gen2GcCallback()` finalizer — Func<bool> false path (return without reschedule)
- `~Gen2GcCallback()` finalizer — Func<bool> true path (GC.ReRegisterForFinalize)
- `~Gen2GcCallback()` finalizer — Func<object, bool> alive target path
- `~Gen2GcCallback()` finalizer — Func<object, bool> dead target path (GCHandle.Free)
- `static Gen2GcCallback()` — default callback invocation of Gen2CollectionOccured

### Existing Tests
9 existing tests covering registration only (no finalizer execution verified)

### Tests Added
5 new tests:
1. Gen2GcCallback_FuncBoolReturningFalse_ExecutesOnceAfterFinalization
2. Gen2GcCallback_FuncBoolReturningTrue_ReschedulesAfterFinalization
3. Gen2GcCallback_ObjectCallbackWithAliveTarget_ExecutesAfterFinalization
4. Gen2GcCallback_ObjectCallbackWithDeadTarget_FreesHandleWithoutCallback
5. Gen2GcCallback_StaticEvent_FiresAfterGCFinalization

### Commit
936fff825
