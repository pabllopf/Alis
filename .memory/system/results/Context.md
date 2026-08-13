# Context.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Windows/Context.cs`
- **Coverage Before**: 0.0% (SonarCloud stale)
- **Coverage After**: 85% (17/20)
- **Tests Added**: 2 (ContextExecutionTests.cs — finalizer coverage via GC.Collect)
- **Uncovered Lines**: 96-98 — finalizer catch block: sfContext_destroy (void DllImport) never throws a managed exception while the lib is loaded; invalid pointer would SIGSEGV (uncatchable). Production/GC constraint.
- **Status**: BLOCKED_BY_PRODUCTION_CODE
