# Result: Touch.cs

File: `1_Presentation/Extension/Graphic/Sfml/src/Windows/Touch.cs`
CoverageBefore: 0.0% (SonarCloud stale; local coverlet 12/16 = 75.0%)
CoverageAfter: 100.0% (16/16 lines, local coverlet; +25.0%)
TestsAdded: 1 (main-thread worker step exercising Touch.GetPosition(finger, Window))
Commit: test: coverage Touch.cs
Status: COMPLETE

## Summary

Touch.cs is the SFML touch-input static wrapper (4 complexity / 28 LOC per SonarCloud). The
committed suite covered 12/16 lines; the two-argument `GetPosition(uint finger, Window
relativeTo)` non-null branch (lines 72-73) was not exercised because it requires a live `Window`
reference, which on macOS must be created on the process main thread.

## Work performed

Added a `TouchHelperGet` step to the main-thread `RenderWindowMainThreadWorker` (the committed
startup-hook pattern used for RenderWindow.cs) that calls `Touch.GetPosition(0, window)` against
the persistent bootstrap window, recording `TouchHelperPositionExecuted`; added a
`GetPosition_WithWindow_MainThreadWorkerSucceeded` test in `TouchTest.cs` that asserts the
recorded result (guarded no-op when the hook is not installed). Hook-enabled run: 23 passed /
0 failed.

Note: hook-enabled runs with coverlet collection occasionally abort at process shutdown with
`BadImageFormatException: Bad IL range` in GC finalizers — reproduced with the baseline
(unmodified) worker too, so it is pre-existing host flakiness, not caused by this change; the
cobertura report is still produced and tests pass.

## Verification

- Hook-enabled run: 23 passed / 0 failed (net8.0).
- Local coverlet (hook-enabled): Touch.cs 16/16 lines (100.0%).
- No-hook (CI-equivalent) run: Touch-filtered tests pass as guarded no-ops.
