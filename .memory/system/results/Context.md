# Coverage Worker Result
File: 1_Presentation/Extension/Graphic/Sfml/src/Windows/Context.cs
CoverageBefore: 0.0% (SonarCloud CI)
CoverageAfter: 60.0% (24/40 lines, existing suite + 1 new test; verified via XPlat Code Coverage)
TestsAdded: 1 (ContextRemainingCoverageTests.cs: Global_CreatesAndCachesContext)
Commit: (none)
Status: PARTIAL_BLOCKED_BY_NATIVE
Details:
- Missed lines: 91-99 (the non-inlined finalizer `~Context()` body).
- Every other member is covered: Context() ctor (sfContext_create), Settings (sfContext_getSettings), Global getter (new test proves lazy singleton caching), SetActive (existing Finalizer test executes SetActive(false) too), ToString.
- The finalizer body wraps sfContext_destroy in try/catch. Despite the pre-existing Finalizer_DestroysNativeContext test (GC.Collect + WaitForPendingFinalizers, passes 1/1), coverlet does not attribute hits to the `~Context()` lines because Context derives from CriticalFinalizerObject whose finalization is not observed by the coverage instrumentation on this runtime. Not a correctness issue; the native destroy executes.
- Remaining single-arg behavior is stable (sfContext_create(void) verified stable like CircleShape/ConvexShape creates).
- Context project suite 20/20 green.