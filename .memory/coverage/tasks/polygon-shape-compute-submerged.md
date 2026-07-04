## COVERAGE TASK

### File

`4_Operation/Physic/src/Collisions/Shapes/PolygonShape.cs`

### Coverage

80.6% (before)

### Uncovered Lines

49 (estimated, before)

### Method

`ComputeSubmergedArea` — fully submerged and partially submerged branches (diveCount = 0 with lastSubmerged = true, diveCount = 1 with into/outo transitions)

### Existing Tests

`PolygonShapeTest.cs` (401 lines) — had basic constructor, CompareTo, Clone, TestPoint, RayCast, ComputeAabb, and ComputeSubmergedArea (above water only)

### Added Tests

| Test | What it covers |
|------|---------------|
| `ComputeSubmergedArea_FullySubmerged_ReturnsFullArea` | diveCount=0, lastSubmerged=true — returns area > 0 |
| `ComputeSubmergedArea_PartiallySubmerged_ReturnsPartialArea` | diveCount=1 with into/outo transitions — returns partial area |
| `ComputeSubmergedArea_PartiallySubmerged_InvertedNormal_ReturnsNonNegative` | Inverted normal direction — returns >= 0 |
| `ComputeSubmergedArea_FullySubmerged_ReturnsNonZeroCenter` | Verifies sc (submerged center) is non-zero when fully submerged |
| `ComputeSubmergedArea_WithRotatedTransform_ReturnsValidArea` | Non-identity transform — returns area > 0 |

### Commit

`c36c21d6e`

### Status

Done
