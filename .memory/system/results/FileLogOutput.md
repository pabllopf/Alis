# Result: FileLogOutput.cs

File: `6_Ideation/Logging/src/Outputs/FileLogOutput.cs`
CoverageBefore: 94.0% (SonarCloud; Line: 91.9%, Branch: 100.0%, 6 uncovered lines)
CoverageAfter: 91.9% (136/148, local coverlet, full Logging suite; unchanged)
TestsAdded: 0 (existing suite covers every reachable line)
Commit: test: coverage FileLogOutput.cs
Status: BLOCKED_BY_PRODUCTION_CODE

## Summary

FileLogOutput.cs is the file-backed log output (20 complexity / 100 LOC). The committed suite
covers construction, Name, IsEnabled, Write (including the throwing-formatter swallow path),
Flush and Dispose (including the double-dispose guard).

## Remaining uncovered lines (6) — BLOCKED_BY_PRODUCTION_CODE

- 168-174 — the `Flush()` swallow catch around `_writer.Flush()`.
- 200-206 — the `Dispose()` swallow catch around `_writer?.Flush()/Dispose()`.

The `StreamWriter` is `private` (no injection point), created with `AutoFlush = true` over a
`FileStream` opened with `FileShare.Read`; open failures are already swallowed by the
constructor's own catch (IsEnabled=false), and no deterministic input makes `Flush()` throw
after a successful write (`/dev/full` is unavailable on this macOS). Defensive catches,
unreachable without production changes.

## Verification

- Full Logging suite: 760 passed / 16 platform skips / 0 failed (net8.0).
- Local coverlet: FileLogOutput.cs 136/148 = 91.9% (matches SonarCloud line metric).
