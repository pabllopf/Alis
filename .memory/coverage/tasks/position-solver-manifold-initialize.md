## COVERAGE TASK

### File

`4_Operation/Physic/src/Dynamics/Contacts/PositionSolverManifold.cs`

### Coverage

42.9% (before)

### Uncovered Lines

21 (before)

### Method

`Initialize` — Circles/FaceA/FaceB/default branches, zero normal handling, separation computation

### Added Tests

| Test | What it covers |
|------|---------------|
| `Initialize_WithCirclesType_ComputesContactData` | ManifoldType.Circles path |
| `Initialize_WithCirclesType_WhenPointsIdentical_HandlesZeroNormal` | Zero normal branch (normal == Vector2F.Zero) |
| `Initialize_WithFaceAType_ComputesContactData` | ManifoldType.FaceA path |
| `Initialize_WithFaceBType_ComputesContactData` | ManifoldType.FaceB path + normal negation |
| `Initialize_WithUnknownType_ReturnsZeros` | Default switch case |
| `Initialize_WithCirclesType_ComputesCorrectSeparation` | Separation formula verification |

### Commit

`cc4c2b338`

### Status

Done
