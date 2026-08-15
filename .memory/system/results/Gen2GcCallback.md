# Gen2GcCallback.cs

- **File**: `4_Operation/Ecs/src/Redifinition/Gen2GcCallback.cs`
- **Coverage Before**: 43.8% (SonarCloud); 52.0% local baseline
- **Coverage After**: 52.0% (39/75 lines — verified ceiling)
- **Tests Added**: 0 (existing Gen2GcCallbackDirectTest/RemainingCoverageTests cover Register paths and the Gen2 collection event)
- **Uncovered Lines**: 105-112 (static-ctor callback lambda) and 165-201 (finalizer) — instances are pinned forever in `_registeredCallbacks` with no removal API, so the finalizer can never run; production change required
- **Status**: BLOCKED_BY_PRODUCTION_CODE
