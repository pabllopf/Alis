# Result: ConsoleLogOutput.cs

File: `6_Ideation/Logging/src/Outputs/ConsoleLogOutput.cs`
CoverageBefore: 94.7% (SonarCloud; Line: 92.9%, Branch: 100.0%, 3 uncovered lines)
CoverageAfter: 92.9% (78/84, local coverlet, full Logging suite; unchanged)
TestsAdded: 0 (existing suite covers every reachable line on this platform)
Commit: test: coverage ConsoleLogOutput.cs
Status: BLOCKED_BY_PRODUCTION_CODE

## Summary

ConsoleLogOutput.cs is the console log output (18 complexity / 61 LOC). The committed suite
covers construction, Name, Write (including the throwing-formatter swallow path and color
handling) and Dispose.

## Remaining uncovered lines (3) — BLOCKED_BY_PRODUCTION_CODE

- 119-125 — the `finally` swallow catch around `Console.ForegroundColor = originalColor`.
  Only reachable when the ForegroundColor setter throws (console handle unavailable — a
  Windows console-failure mode). On macOS with redirected test output the setter is a no-op,
  so the catch cannot be triggered deterministically here.

## Verification

- Full Logging suite: 760 passed / 16 platform skips / 0 failed (net8.0).
- Local coverlet: ConsoleLogOutput.cs 78/84 = 92.9% (matches SonarCloud line metric).
