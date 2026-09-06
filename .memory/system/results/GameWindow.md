# Result: GameWindow.cs

File: `1_Presentation/Extension/Graphic/Glfw/src/GameWindow.cs`
CoverageBefore: 0.0% (SonarCloud; stale artifact)
CoverageAfter: 100.0% (10/10, local coverlet, hook-enabled run)
TestsAdded: 0 (already remediated in commit ba1e711e6)
Commit: test: coverage GameWindow.cs
Status: ALREADY_REMEDIATED

## Summary

GameWindow.cs is the GLFW game-window wrapper (3 complexity / 17 LOC). Committed
`GameWindowTests.cs` + `GameWindowExecutionTests.cs` + `GameWindowCreationTests.cs` (bootstrap
GameWindow instances via the main-thread hook pattern) cover 10/10 lines = 100.0%.

## Verification

- Hook-enabled run (`ALIS_GLFW_HOOK=1` + scratch reflection `DOTNET_STARTUP_HOOKS`): 5 passed,
  0 failed; `GameWindow.cs` 10/10 = 100.0%.
## Re-verification (2026-09-06, auto loop)
Re-issued by SonarCloud (40%, stale CI delta). No-hook GameWindow filter: 5/5 pass + 3 guarded skips,
clean. Hook-enabled run of the GameWindow filter SIGSEGVs (exit 139, no output) — machine instability
documented in NativeWindow.md (hook+GLFW init). Committed hook-run coverage 10/10 (100%) stands.
