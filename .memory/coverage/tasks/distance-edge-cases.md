---
status: Done
---

## COVERAGE TASK

### File

4_Operation/Physic/src/Collisions/Distance.cs

### Coverage

83.3% → ~87%+ (est., pending SonarCloud rescan)

### Uncovered Lines

12 → ~6-7 (est.)

### Methods Covered

- ComputeDistance: full overlap (simplex.Count==3), Y-axis separation, far-apart convergence
- ApplyRadii: subtract radii branch (far apart), collapse branch (touching)

### Tests Added

- DistanceTest.cs (4 new facts)

### Status

Done
