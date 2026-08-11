# Gen2GcCallback.cs

- **File**: `4_Operation/Ecs/src/Redifinition/Gen2GcCallback.cs`
- **Coverage**: 52% (ceiling)
- **Tests Added**: 0
- **Uncovered Lines**: finalizer (165-201) + static-ctor callback lambda (105-112) — instances are held forever by `_registeredCallbacks` (no removal API), so the finalizer can never run
- **Status**: BLOCKED_BY_PRODUCTION_CODE (dead finalizer path)
