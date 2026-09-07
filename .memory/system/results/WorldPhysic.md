# WorldPhysic.cs

## Summary
- File: `4_Operation/Physic/src/Dynamics/WorldPhysic.cs`
- Lines: ~1985
- Complexity: 244

## SonarCloud
- Line: 97.5%, Branch: 95.6%
- Uncovered: 23 lines, 13 branches

## Local (after remediation)
- Line: 98.29%, Branch: 96.64%
- Uncovered: 15 lines (deduplicated across TFMs)
- Partially-covered branches: 9 conditions <100%

## Tests Added
- `WorldPhysicJointFilterCoverageTest.cs` (6 tests)

## Unreachable / Blocked Lines

| Lines | Reason |
|---|---|
| 646–647 | `_stepComplete` initialized `true`, only assigned `true` (line 561); never `false` → guard dead |
| 729–730 | `ToiFlag` is only ever assigned `false` (lines 577, 629, 659); never `true` → early-return dead |
| 1717 | `CreateRoundedRectangle` always produces ≥8 verts; `MaxPolygonVertices` = 8 → `>=` always true; fallback `CreatePolygon` dead |
| 1711 (50%) | Same: `verts.Count >= MaxPolygonVertices` always true; false-side dead |
| 581–587 | SolveToi: `!minContact.Enabled \|\| !minContact.IsTouching` after `Advance(minAlpha)` + `Update()`; requires a contact to become disabled/non-touching mid-TOI. Defensive algorithm branch; not triggerable deterministically. |
| 830–833 | ProcessToiContact: `!contact.Enabled` after `other.Advance(minAlpha)` + `Update()`; same scenario as 581–587. |
| 580 (50%) | Related: `!minContact.Enabled \|\| !minContact.IsTouching` — true/false branches for the two OR operands partially uncovered |
| 645 (50%) | `_stepComplete` false-side — dead (same as 646-647) |
| 728 (50%) | `c.ToiFlag` false-side — dead (ToiFlag never true) |
| 800 (75%) | `BodyCount == Capacity \|\| ContactCount == Capacity` — one side needs island capacity saturation |
| 816 (75%) | `FixtureA.GetIsSensor \|\| FixtureB.GetIsSensor` — sensor fixture during TOI; one side not triggered |
| 829 (50%) | `!contact.Enabled` — contact disabled during ProcessToiContact; same scenario as 830-833 |
| 1959 (75%) | `_stepComplete && (step.Dt > 0.0f)` — `_stepComplete` false-side dead |
| 1969 (75%) | `SettingEnv.ContinuousPhysics && (step.Dt > 0.0f)` — config flag always true; false-side dead |

## Tests

| Test | What it covers |
|---|---|
| `AddNonCollideJoint_OverlappingBodies_FlagsExistingContact` | Joint filtering loop (1841–1849) |
| `RemoveNonCollideJoint_OverlappingBodies_FlagsContacts` | Joint filtering loop (1924–1932) |
| `Step_WithZeroDeltaTime_DoesNotThrow` | `dt <= 0` ternary (line 1187) |
| `Bullet_HittingSensorBody_ProcessesToiSensorContact` | TOI contact with sensor fixture |

## Status
**PARTIAL_BLOCKED_BY_ALGORITHM_INHERENTLY_DEAD_CODE** — 15 lines remain uncovered; all are dead code by construction (constant-true conditions, never-assigned flags) or algorithm-inherent defensive branches (TOI contact expiration during continuous collision).
