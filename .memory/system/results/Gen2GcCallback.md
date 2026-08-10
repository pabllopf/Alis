# Gen2GcCallback.cs

- **File**: `4_Operation/Ecs/src/Redifinition/Gen2GcCallback.cs`
- **Coverage Before**: 43.8%
- **Coverage After**: ~55.0% (combined with existing tests; ceiling)
- **Tests Added**: 4
- **Uncovered Lines**: Finalizer paths unreachable in tests — static `_registeredCallbacks` holds strong references so instances never collect (by class design)
- **Status**: COMPLETED
