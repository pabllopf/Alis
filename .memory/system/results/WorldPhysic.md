# Result: WorldPhysic.cs

File: `4_Operation/Physic/src/Dynamics/WorldPhysic.cs`
CoverageBefore: 90.1% (SonarCloud); local coverlet baseline 91.7% line (859/937)
CoverageAfter: 93.8% line (879/937, local coverlet, net8.0)
TestsAdded: 10 (WorldPhysicRemainingCoverageTests.cs)
Commit: test: coverage WorldPhysic.cs
Status: PARTIALLY_REMEDIATED

## Summary

WorldPhysic.cs (1984 LOC, physics world). Local coverlet showed 78 uncovered lines across
callback dispatch, body/joint removal, ray/test-point paths and the TOI solver internals.
(Note: the file was concurrently refactored during processing, shifting line numbers; final
numbers are for the current state.)

## Work performed

Added 10 tests to `WorldPhysicRemainingCoverageTests.cs` (xUnit, net8.0, real WorldPhysic
scenarios):
- `Step_WithTimeSpan_StepsWorld` — Step(TimeSpan) overload (1124-1126).
- `Step_WhenLocked_ThrowsInvalidOperationException` — nested Step inside an OnCollision
  callback; covers the locked guard (1156-1157).
- `FixtureAdded_WithMultipleFixtures_DispatchesForEach` — pre-fixtured body added to the world
  with the event wired (917-919).
- `RayCast_ThroughEmptySpace_DoesNotInvokeCallback` — ray starting inside a circle and pointing
  away; the proxy is tested but the shape raycast misses (1313).
- `TestPoint_WithPointFarOutside_ReturnsNull` — query lambda continue path (1409).
- `CreateCapsule_WithFewVertices_CreatesPolygon` + `CreateRoundedRectangle_WithFewSegments_CreatesPolygon`
  — non-decomposed polygon creation.
- `RemoveJoint_WithTwoJoints_RemovesSecondEdge` — mid-list joint edge removal (1896-1898).
- `Remove_BodyWithContacts_RemovesContacts` — body removal contact cleanup (962-966).
- `RemoveJoint_WithTouchingBodies_FiltersContacts` — FlagContactsForJointRemoval loop
  (1925-1932).

## Remaining uncovered lines — BLOCKED_BY_PRODUCTION_CODE

- 581-587, 620-621, 646-647, 729-752, 801-858 — TOI continuous-collision island internals
  (disabled-contact restore, non-dynamic island bodies, CalculateContactAlpha alpha-advance
  branches, ProcessToiContact guard paths). 6 deterministic probe scenarios (fast non-bullet
  crossing static, bullet vs sensor, bullet vs dynamic, two fast non-bullets, bullet graze,
  bouncing bullet) all engaged the TOI main loop (546-619 covered) but never reached these
  branches; the probes were removed to keep the repo coverage-honest.

## Verification

- Targeted run: 10 passed / 0 failed (net8.0).
- Merged suite: 162 passed / 0 failed (net8.0, WorldPhysic filter).
- Local coverlet: 879/937 = 93.8% line (was 91.7%).
