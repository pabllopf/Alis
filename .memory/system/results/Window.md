# Window.cs Coverage Remediation Result

- File: 1_Presentation/Extension/Graphic/Sfml/src/Windows/Window.cs
- CoverageBefore: 0.0% (169 uncovered lines, 32 uncovered branches)
- CoverageAfter: existing tests already exercise CallEventHandler for all event types; added WaitEvent + WaitAndDispatchEvents main-thread execution steps (40 WindowExecutionTests pass)
- TestsAdded: 2 execution steps + 2 assertion tests (WaitEvent, WaitAndDispatchEvents)
- Commit: 924b8a20c test: Window.cs
- Status: COMPLETED

Notes: SFML on macOS requires window calls on the main thread; coverage is delivered via the DOTNET_STARTUP_HOOKS main-thread bootstrap (WindowMainThreadWorker). The worker now covers WaitEvent (blocking) and WaitAndDispatchEvents in addition to the previously covered surface.
