# Result: Archetype.cs

File: `4_Operation/Ecs/src/Kernel/Archetypes/Archetype.cs`
CoverageBefore: 90.2% (SonarCloud; Line: 91.3%, Branch: 84.2%)
CoverageAfter: 98.7% (616/624, local coverlet, full Ecs suite)
TestsAdded: 1 (ArchetypeOverflowCoverageTests.cs: max-archetype-count overflow guard)
Commit: test: coverage Archetype.cs
Status: PARTIALLY_REMEDIATED

## Summary

Archetype.cs is the ECS archetype manager (104 complexity / 786 LOC). The committed suite
(ArchetypeCoverageTest / ArchetypeCoverage007Test etc.) covers the archetype creation,
transition and query paths; the `ushort.MaxValue` overflow guard of `GetArchetypeId` and the
hash-collision branches of `SameComponents` were uncovered.

## Tests added (ArchetypeOverflowCoverageTests.cs)

`GetArchetypeId_WhenExceedingMaxArchetypeCount_Throws`: creates 65535+ unique archetypes via
synthesized `ComponentId` triples (raw indices 0..127 keep the component-tag buffer at 128
bytes/slot — single-component ids would balloon the per-id tag tables into gigabytes), drives
`NextArchetypeId` past `ushort.MaxValue` and asserts the
`InvalidOperationException("Exceeded maximum unique archetype count of 65535")`. The global
`NextArchetypeId` counter and `ComponentTagTableBufferSize` are restored afterwards; the
`ExistingArchetypes` dictionary retains the synthetic entries (opaque keys, a few MB) and the
test was verified not to change the Ecs suite's pre-existing failure set.

## Remaining uncovered lines (4) — BLOCKED_BY_PRODUCTION_CODE

- 733-734, 740-741 — `SameComponents` length-mismatch and element-mismatch branches: only
  reached when `ExistingArchetypes.TryGetValue` hits a key whose 64-bit hash (two combined
  `HashCode` halves, process-randomized seed) collides with a different component set.
  Astronomically unlikely and not deterministically constructible.

## Verification

- Filtered run: 1 passed (50 ms).
- Full Ecs suite: passes with the same pre-existing order-dependent failure set as without
  the new test (CommandBufferCoverageTest.AddComponent_BoxedNoType_PlaybackAddsComponent).
- Local coverlet: Archetype.cs 616/624 = 98.7% (before: 91.3% line).
