# Result: Window.cs

File: `1_Presentation/Extension/Graphic/Sfml/src/Windows/Window.cs`
CoverageBefore: 0.0% (SonarCloud; stale artifact)
CoverageAfter: 50.9% (86/169 lines, local coverlet, hook-enabled run)
TestsAdded: 16 (WindowExecutionTests.cs + WindowMainThreadWorker.cs wired into SfmlTestBootstrap)
Commit: test: coverage Window.cs
Status: PARTIALLY_REMEDIATED

## Summary

Window.cs is the base SFML window wrapper (934 LOC; 169 instrumented lines). The committed
`WindowTest.cs` / `WindowRemainingCoverageTests.cs` were reflection-only (32.0% = 54/169, the
no-hook reading). This session added `WindowMainThreadWorker.cs` (a second main-thread worker
that creates a plain non-render `Window` from a native handle via the existing
`NativeWindowFactory`, so the base virtual implementations are exercised directly) and
`WindowExecutionTests.cs` (16 assertions). The worker is invoked from
`SfmlTestBootstrap.Initialize()` after the RenderWindow worker. With the startup hook,
coverage rises to 86/169 = 50.9%; full Window filter: 414 passed, 0 failed.

## Remaining uncovered lines (83) — BLOCKED_BY_PRODUCTION_CODE

- 52-90 — VideoMode/title constructors: CSFML 3.0 `sfWindow_create(mode, title, style,
  state, settings)` has an extra `sfWindowState` parameter the wrapper (CSFML 2.x ABI) does not
  pass; creation reads garbage state → broken window. Same family as RenderWindow.
- 223-234 — SetIcon: ObjC NSException on the main-thread worker (see RenderWindow analysis).
- 358-364 (WaitAndDispatchEvents) and 426 (WaitEvent): block indefinitely in a hidden window.
- 447-449 — InternalSetMousePosition: would move the OS cursor (machine side effect).
- 485-582 — internal event pump (CallEventHandler + native event callbacks): only reachable
  with real OS input events, not drivable deterministically.

## Verification

- Window filter (net8.0, Debug, hook enabled): 414 passed, 0 failed, 0 skipped.
- Local coverlet (hook-enabled): Window.cs 86/169 lines (50.9%); before the added worker the
  reading was 54/169 (32.0%).
