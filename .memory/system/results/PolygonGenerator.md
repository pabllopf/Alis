# PolygonGenerator.cs

## Summary
- File: `4_Operation/Physic/src/Common/Decomposition/CDT/Util/PolygonGenerator.cs`
- Lines: ~135
- Complexity: 10
- Access: `internal static class`

## SonarCloud
- Line: 100.0%, Branch: 87.5%
- Uncovered: 0 lines, 2 branches

## Local (verified by existing committed suite)
- Line: 100.0%
- Branch: 87.5%

## Tests Added
- None — existing `PolygonGeneratorTest.cs` already covers 100% of lines
  - `RandomCircleSweep` / `RandomCircleSweep2` with valid/many/fewer-than-3 vertices
  - `Rng` static field access

## Unreachable / Blocked Branches

| Line | Reason |
|---|---|
| 85 | `while (radius < scale/10 \|\| radius > scale/2)` true-side — `radius` is clamped via `Math.Min(Math.Max(radius, scale/10), scale/2)` on line 84, so it can never leave `[scale/10, scale/2]`. The do-while always exits on first iteration. Dead by construction. |
| 124 | Same loop-exit condition in `RandomCircleSweep2` — `radius` clamped on line 123. Dead by construction. |

The two uncovered branches are the loop-continuation arms of the do-while in both sweep methods. Because the radius is always clamped into range immediately before the condition, the condition is provably always false — both methods always execute their body exactly once. The branch-true path (re-entering the loop) is unreachable through any input.

## Status
**BLOCKED_BY_ALGORITHM_INHERENTLY_DEAD_CODE** — 100% line coverage; the 2 residual branches are loop-continuation arms made unreachable by the preceding clamp.
