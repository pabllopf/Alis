# Result: VideoGameBuilder.cs

File: `pabllopf-official_alis:2_Application/Alis/src/Builder/Core/Ecs/System/VideoGameBuilder.cs`
CoverageBefore: 93.8% (SonarCloud; local coverlet 93.8% line, 104/111)
CoverageAfter: 93.8% line (104/111, local coverlet, net8.0 — unchanged)
TestsAdded: 0 (line 110 is the blocking game-loop entry point; deterministically unreachable)
Commit: none — no tests added, nothing to stage
Status: BLOCKED_BY_PRODUCTION_CODE

## Summary

VideoGameBuilder.cs (fluent game builder: `Settings`, `World`, `Build`, `Run`). The single
uncovered line is 110, `public void Run() => Build().Run();` — the game-loop entry point.

## Analysis

`Run()` delegates to `VideoGame.Run()` -> `ContextHandler.Run()` (ContextHandler.cs:104), which
calls `InternalRuntime.OnInit()/OnAwake()/OnStart()` (GraphicManager.OnInit at GraphicManager.cs:122
creates a real native platform window) and then enters a blocking `while (_context.IsRunning)`
loop. `Context.IsRunning` defaults to `true` (Context.cs:54/73/93) and the setter is `internal`;
there is no `InternalsVisibleTo` for the test assembly, so the loop cannot be skipped or the
context stopped before `Run()` without reflection (forbidden, AOT rules) or editing `src/`.
The game loop has no exit path that returns from `Run()`.

## Verification (net8.0, Debug)

- `VideoGameBuilderRemainingCoverageTests` + `VideoGameBuilderCoverageTests`: 3 tests pass, 9 ms.
- `VideoGameBuilderRunCoverageTests.Run_WithUninitializedBuilder_ThrowsWithoutBlocking`
  (committed in 9c7f910da): HANGS the test host — no results after 75 s; the uninitialized
  context does not fail fast, so `Run()` blocks in the game loop. Committed suites must not be
  modified, so this hanging test remains (flagged for a future session).
- Empirical check (two runs) confirms `Run()` blocks indefinitely, matching the earlier
  session's finding recorded here.

## Conclusion

The only remaining uncovered line (110) cannot be exercised deterministically in an xUnit
test: it requires a controllable `IsRunning` lifecycle or a fail-fast initialization path,
which is a production-code concern. No new tests are possible; state record completed.
