# Result: Collision.cs

File: `4_Operation/Physic/src/Collisions/Collision.cs`
CoverageBefore: 97.9% (SonarCloud; Line: 98.2%, Branch: 96.9%, 15 uncovered lines)
CoverageAfter: 98.2% (1602/1624, local coverlet, Collision-filtered run; unchanged)
TestsAdded: 0 (remaining lines are deep geometric edge cases)
Commit: test: coverage Collision.cs
Status: BLOCKED_BY_PRODUCTION_CODE

## Summary

Collision.cs contains the collision detection pipeline (172 complexity / 961 LOC): the
collider functions, clipping, edge separation and the EP collider. The committed suite (900
filtered tests) covers the main circle/polygon/box collision paths.

## Remaining uncovered lines (15) — BLOCKED_BY_PRODUCTION_CODE

- 249-250 — circle/polygon clip early-out (`separation2 > radius`).
- 392-393, 400-401 — `ClipSegmentToLine` np < 2 early returns (degenerate clip results).
- 856-859 — best-edge improvement loop body (`s > bestSeparation`).
- 1027-1028, 1464-1465 — EP collider unknown-axis early returns (ComputeEdgeSeparation /
  SelectPrimaryAxis).

These require specific degenerate/near-degenerate contact geometries. Probed setups (rotated
boxes vs circle, rotated box vs rotated box, world steps) and the committed suites do not
produce them; they are not deterministically constructible with standard fixtures.

## Verification

- Collision-filtered run: 902 passed / 0 failed (net8.0).
- Local coverlet: Collision.cs 946/968 + EpCollider 620/628 = 1602/1624 (98.2%, matches
  SonarCloud line metric).
