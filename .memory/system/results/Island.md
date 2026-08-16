# Result: Island.cs

File: `4_Operation/Physic/src/Dynamics/Island.cs`
CoverageBefore: 94.6% (SonarCloud; Line: 94.9%, Branch: 93.1%, 20 uncovered lines)
CoverageAfter: 94.9% (772/792, local coverlet, Island-filtered run; unchanged)
TestsAdded: 0 (remaining lines unreachable with standard fixtures)
Commit: test: coverage Island.cs
Status: BLOCKED_BY_PRODUCTION_CODE

## Summary

Island.cs is the Box2D-style island solver (86 complexity / 456 LOC). The committed suite
(IslandTests + physics suites, 56 Island-filtered tests) covers island building, solve
velocity/position/TOI paths, sleep-state updates and reporting.

## Remaining uncovered lines (10) — BLOCKED_BY_PRODUCTION_CODE

- 515-516 — `UpdateSleepState` early-return when `!SettingEnv.AllowSleep`: `AllowSleep` is a
  `public static readonly bool = true` — never writable → unreachable.
- 606-609, 613-616 — the TOI velocity/rotation clamp branches in `SolveTOI` (translation² >
  MaxTranslationSquared / rotation² > MaxRotationSquared). Only reachable inside the TOI
  solver's per-body clamp loop, which requires a swept TOI contact event; a fast dynamic body
  (linear velocity up to 2,000,000) + static target with ContinuousPhysics enabled does not
  produce the TOI event with this engine's `FindMinAlphaContact` detection for the tested
  geometries (and the committed Island suites reach the same result). Not deterministically
  constructible with standard fixtures.

## Verification

- Island-filtered run: 57 passed / 0 failed (net8.0).
- Local coverlet: Island.cs 772/792 = 94.9% (matches SonarCloud line metric).
