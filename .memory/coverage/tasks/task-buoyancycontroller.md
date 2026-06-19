# Task: BuoyancyController.Update() Coverage

**Target**: 4_Operation/Physic/src/Controllers/BuoyancyController.cs
**Coverage**: 29.6% → ~70% estimated
**Uncovered Lines**: 42 (lines 193-257 — the Update method body)
**Branch Coverage**: 6.3% (15 conditions uncovered)
**Status**: ✅ COMPLETED (commit 708bc65ab)

## Existing Tests
File: `4_Operation/Physic/test/Controllers/BuoyancyControllerTest.cs` (9 tests)
- Constructor initialization
- Container property getter/setter
- Velocity property
- Update with empty world (no bodies)
- Zero/negative density edge cases
- Inheritance check

## Uncovered Code (lines 193-257)
The `Update(float dt)` method body — the entire buoyancy simulation logic:

1. **QueryAabb** — querying fixtures within container AABB
2. **Body filtering** — skipping static and sleeping bodies
3. **Unique body deduplication**
4. **Fixture type filtering** — Polygon and Circle only (skip others)
5. **ComputeSubmergedArea** — per-fixture submerged area calculation
6. **Buoyancy force application** — `F = -density * area * gravity`
7. **Linear drag** — relative to fluid velocity
8. **Angular drag** — proportional to angular velocity
9. **Division by zero guard** — `area < SettingEnv.Epsilon`

## Test Strategy
- Create WorldPhysic with bodies inside and outside the container AABB
- Add polygon and circle fixtures to test submerged area computation
- Test Update with bodies fully above, fully below, and partially submerged
- Test that static and sleeping bodies are skipped
- Test that non-polygon/circle fixtures are skipped (edge shapes)
- Verify force application by checking body velocity changes

## Test Project
`4_Operation/Physic/test/Alis.Core.Physic.Test.csproj` (net8.0)

## Dependencies
- WorldPhysic — already tested extensively
- Aabb — already tested (AabbTest.cs)
- Body — already tested (BodyTest.cs)  
- Fixture — already tested (FixtureTest.cs)
- PolygonShape, CircleShape — already tested
- Vector2F — core type

## Priority
HIGH (pure physics algorithm, no UI dependencies, high ROI)
