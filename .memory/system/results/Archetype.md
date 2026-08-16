# Result: Archetype.cs

File: `4_Operation/Ecs/src/Kernel/Archetypes/Archetype.cs`
CoverageBefore: 90.2% (SonarCloud); local coverlet baseline 98.7% line (1390/1409)
CoverageAfter: 100.0% line / 100.0% branch (local coverlet, net8.0)
TestsAdded: 3 (ArchetypeSameComponentsCoverageTests.cs)
Commit: test: coverage Archetype.cs
Status: REMEDIATED

## Summary

Archetype.cs (1409 LOC, ECS archetype registry). The committed suite (14 test files) covered
98.7%; the only remaining lines were the two defensive `SameComponents` mismatch branches
(733-734 length mismatch, 740-741 element mismatch) — a hash-collision guard for
`ExistingArchetypes` lookups that is practically unreachable through the public API without
constructing an actual HashCode collision.

## Work performed

Added 3 tests to `ArchetypeSameComponentsCoverageTests.cs` (xUnit, net8.0) that invoke the
private `SameComponents` method directly via `MethodInfo.CreateDelegate` (ReadOnlySpan
parameters cannot be boxed for `Invoke`):
- `SameComponents_WithDifferentLengths_ReturnsFalse` — covers 733-734.
- `SameComponents_WithDifferentElements_ReturnsFalse` — covers 740-741.
- `SameComponents_WithEqualContent_ReturnsTrue` — the positive path (737-745).

## Verification

- Targeted run: 3 passed / 0 failed (net8.0).
- Merged suite (Archetype filter): all pass.
- Local coverlet: Archetype.cs 100.0% line / 100.0% branch; zero uncovered lines.
