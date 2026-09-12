# State — Logger.cs coverage

Target: 6_Ideation/Logging/src/Logger.cs
Project: 6_Ideation/Logging/src/Alis.Core.Aspect.Logging.csproj
Test project: 6_Ideation/Logging/test/Alis.Core.Aspect.Logging.Test.csproj
Agent: opencode-logger-coverage-1
Baseline commit: 308f02743f8aab3e717d9509b41194bfe26757ef
Initial line coverage: 100.0% (48/48 sequence points)
Initial branch coverage: 62.5% (10/16 branch points)
Current line coverage: 100.0% (48/48)
Current branch coverage: 100.0% (16/16)
Tests before: 776 total (760 passed, 16 skipped)
Tests after: 777 total (761 passed, 16 skipped)
Files modified: 6_Ideation/Logging/test/LoggerNullConditionalCoverageTest.cs (new)
Tests added: LogMethods_WhenDefaultLoggerIsResetConcurrently_DoNotThrow
Commits: 4a38dd506 test: cover null-conditional reset paths of Logger.cs
Remaining uncovered lines: none
Remaining uncovered branches: none
Status: COMPLETED
Last update: 2026-09-12

## Analysis

All 48 sequence points covered at baseline. The 6 uncovered branch points are
the null-receiver exits of `_defaultLogger?.LogX(message)` in Trace/Info/
Warning/Error/Debug/Exception.

IL (Debug net8.0, monodis) for Logger.Trace:
```
IL_0007: ldsfld  _defaultLogger
IL_000c: dup
IL_000d: brtrue.s IL_0012   (path 1, covered: call LogTrace)
IL_000f: pop
IL_0010: br.s   IL_0019     (path 0, uncovered: silent return)
```

`EnsureInitialized()` unconditionally guarantees `_defaultLogger != null` on
return, so the null path is only reachable when another thread executes
`SetDefaultLogger(null)` between the `EnsureInitialized()` call and the
`ldsfld _defaultLogger` read. This transient is exactly what the
null-conditional operator is defending against; it is reachable through the
public API via concurrency (see attempt 001).
