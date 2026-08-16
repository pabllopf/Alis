# Result: DungeonData.cs

File: `1_Presentation/Extension/Math/ProceduralDungeon/src/Models/DungeonData.cs`
CoverageBefore: 92.2% (SonarCloud); local coverlet baseline 91.3% line (198/217)
CoverageAfter: 100.0% line / 100.0% branch (local coverlet, net8.0)
TestsAdded: 3 (DungeonDataValidateCoverageTests.cs)
Commit: test: coverage DungeonData.cs
Status: REMEDIATED

## Summary

DungeonData.cs (217 LOC, procedural dungeon model). The remaining 6 uncovered lines were the
null-guard throws of the three private validators (ValidateBoard/Rooms/Corridors). Those
guards are only reachable with null private fields — impossible through the public property
setters (which throw ArgumentNullException) but reachable after deserialization, which the
public `Validate()` entry point documents.

## Work performed

Added 3 tests to `DungeonDataValidateCoverageTests.cs` (xUnit, net8.0) that set the private
fields to null via reflection (simulating a partial deserialization) and assert the
`InvalidOperationException` guards:
- `Validate_WithNullBoard_ThrowsInvalidOperationException` — 155-156.
- `Validate_WithNullRooms_ThrowsInvalidOperationException` — 172-173 (with a valid board set
  first so ValidateBoard passes).
- `Validate_WithNullCorridors_ThrowsInvalidOperationException` — 198-199 (same setup).

## Verification

- Targeted run: 3 passed / 0 failed (net8.0).
- Merged suite (DungeonData filter): all pass.
- Local coverlet: DungeonData.cs 100.0% line / 100.0% branch; zero uncovered lines.
