# TASK 4: Coverage Tests for TimeOfImpact.cs

## File
`4_Operation/Physic/src/Collisions/TimeOfImpact.cs`

## Current Coverage
40.0% — 84 uncovered lines, 21 uncovered conditions

## Missing Coverage
- `TryHandleDistanceResult`: Overlapped branch (distance ≤ 0) not exercised
- `CalculateTimeOfImpact`: EnableDiagnostics counters not tested
- `RecordRootIteration`/`RecordMaxRootIters`: diagnostic paths not exercised
- `TryPushBackIterations`: root-finding convergence branches

## Planned Tests
1. `Overlapped` state when shapes start at the same position
2. `EnableDiagnostics` counters increment correctly
3. `TryPushBackIterations` with EnableDiagnostics

## Expected Impact
~15-25 uncovered lines, ~6-8 uncovered conditions
