# Result: Events.cs

File: `1_Presentation/Extension/Network/src/Internal/Events.cs`
CoverageBefore: 89.1% (SonarCloud; Line: 83.7%, Branch: 100.0%, 39 uncovered lines)
CoverageAfter: 83.7% (400/478, local coverlet, full Network suite; unchanged)
TestsAdded: 0 (WriteEvent paths not enable-able on this runtime; existing suite covers all reachable lines)
Commit: test: coverage Events.cs
Status: BLOCKED_BY_PRODUCTION_CODE

## Summary

Events.cs is the `Ninja-WebSockets` EventSource logging facade (98 complexity / 333 LOC) with
~100 `[Event]`-attributed methods, each `if (IsEnabled()) { WriteEvent(...); }`. The committed
suite (EventsTest / EventsRemainingCoverageTests / EventsAdditionalCoverageTest) covers the
if-check and closing-brace lines of every method; the 39 remaining uncovered lines are the
`WriteEvent` call lines, which only execute when the EventSource is enabled.

## Attempted (not committed)

- `EventListener.EnableEvents(Events.Log, EventLevel.Verbose, EventKeywords.All)` (via a
  TestEventListener constructed before the calls) — `IsEnabled()` stays false on this runtime;
  verified in both a standalone console probe and the testhost. The source's internal flag
  field is `m_traits`/`m_channelData` on .NET 8 (no `m_eventSourceEnabled`), so the repo's
  committed reflection-based `CallSafely` helper is also inert here (it was written for the
  .NET Framework layout). WriteEvent lines therefore remain unreachable in this environment.
- A `CallSafely`-style reflection toggle was also tried and reverted.

## Remaining uncovered lines (39) — BLOCKED_BY_PRODUCTION_CODE

The `WriteEvent(id, ...)` call lines (61, 76, 89, ..., 609 — one per method). Enablement of
the EventSource is a runtime/platform capability that does not function on the installed
.NET 8/10 runtime; requires either a .NET Framework target or a working ETW/EventSource
session to cover.

## Verification

- Full Network suite: 1101 passed / 0 failed (net8.0).
- Local coverlet: Events.cs 400/478 (83.7% line); the 39 WriteEvent lines are the only
  uncovered lines.
