# Result: TimeOfImpact.cs

File: `4_Operation/Physic/src/Collisions/TimeOfImpact.cs`
CoverageBefore: 86.9% (SonarCloud); local coverlet baseline 90.5% line / 85.7% branch
CoverageAfter: 90.5% line / 85.7% branch (local coverlet, net8.0 — unchanged)
TestsAdded: 0 (14 probe scenarios verified to add zero coverage; not committed)
Commit: test: coverage TimeOfImpact.cs
Status: BLOCKED_BY_PRODUCTION_CODE

## Summary

TimeOfImpact.cs (369 LOC, conservative-advancement continuous collision solver). The
committed suite (TimeOfImpactTest/CoverageTests/RemainingCoverageTests) covers 90.5% locally.
The remaining 14 uncovered lines are the solver's numerical non-convergence branches:
- 163-167 — `iter == kMaxIterations` → `Failed` state: 20 conservative-advancement iterations
  without convergence.
- 239-242 — push-back loop `s1 < target - tolerance` → `Failed` state.
- 257-258 — push-back loop iteration cap (`MaxPolygonVertices`).
- 300-301, 305-306 — root-find 50-iteration bisection cap and its final return.

## Analysis

All branches are defensive exits for degenerate/non-converging float dynamics. 14 deterministic
probe scenarios were attempted across the configuration space (tiny/huge circles, near-parallel
sweeps, tangent contact, perpendicular graze, identical offset sweeps, slow approach with big
gaps, high-speed punch-through, rotation) — all passed but none reached the non-convergence
branches. Hitting them requires precisely degenerate numerical inputs that could not be
constructed deterministically; the probes were removed to keep the repo coverage-honest.

## Verification

- Targeted run: existing TimeOfImpact suite all pass (net8.0).
- Local coverlet: 90.5% line / 85.7% branch; 14 lines remaining, all non-convergence exits.
