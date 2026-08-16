# Result: StreamAdaptor.cs

File: `1_Presentation/Extension/Graphic/Sfml/src/Systems/StreamAdaptor.cs`
CoverageBefore: 93.9% (SonarCloud; Line: 93.6%, Branch: 100.0%, 3 uncovered lines)
CoverageAfter: 93.6% (88/94, local coverlet, full Sfml suite; unchanged)
TestsAdded: 0 (existing suite covers every reachable line)
Commit: test: coverage StreamAdaptor.cs
Status: BLOCKED_BY_PRODUCTION_CODE

## Summary

StreamAdaptor.cs is the SFML stream adapter (10 complexity / 64 LOC). The committed suite
(StreamAdaptorTests + the SFML suites, 1660 tests, 0 failed) covers construction, read/write,
position, length, and Dispose(true).

## Remaining uncovered lines (3) — BLOCKED_BY_PRODUCTION_CODE

- 108-110 — the `~StreamAdaptor()` finalizer's `catch { }` block. Only reachable when
  `Dispose(false)` throws inside a GC finalizer; with the committed implementation it cannot
  throw deterministically, and forcing it requires corrupting instance state via reflection
  (forbidden by AOT rules). Same unreachable-finalizer-catch family as the documented
  Context.cs / BufferPool.cs cases.

## Verification

- Full Sfml suite: 1660 passed / 0 failed (net8.0).
- Local coverlet: StreamAdaptor.cs 88/94 = 93.6% (matches SonarCloud line metric).
