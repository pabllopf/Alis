# TASK 3: Coverage Tests for SeparationFunction.cs

## File
`4_Operation/Physic/src/Collisions/SeparationFunction.cs`

## Current Coverage
50.4% — 59 uncovered lines, 10 uncovered conditions

## Missing Coverage (SonarCloud)
- `Set` — FaceB branch (`cache.IndexA[0] == cache.IndexA[1]`) not exercised
- `Set` — FaceA axis flip (`s < 0.0f`) not exercised
- `Set` — FaceB axis flip (`s < 0.0f`) not exercised
- `FindMinSeparation` — FaceA switch case not directly tested
- `FindMinSeparation` — FaceB switch case not tested
- `Evaluate` — FaceB switch case not tested
- `Evaluate` — Points switch case not tested

## Planned Tests (6)
1. `FindMinSeparation_WithFaceAMode_ShouldComputeFiniteSeparation`
2. `FindMinSeparation_WithFaceBMode_ShouldComputeFiniteSeparation`
3. `Set_WithFaceAMode_ShouldFlipAxis_WhenPointBIsAbovePointA`
4. `Set_WithFaceBMode_ShouldFlipAxis_WhenPointAIsAbovePointB`
5. `Evaluate_WithFaceBMode_ShouldReturnFiniteSeparation`
6. `Evaluate_WithPointsMode_ShouldReturnFiniteSeparation`

## Expected Impact
~15-20 uncovered lines, ~6 uncovered conditions
