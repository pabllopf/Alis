## COVERAGE TASK

### File
`4_Operation/Physic/src/Dynamics/ContactManager.cs`

### Coverage
65.8%

### Uncovered Lines
114

### Uncovered Conditions
51

### Existing Tests
- ContactManagerTest.cs (7 tests)
- ContactManagerCoverageTest.cs (8 tests)

### New Tests
- ContactManagerUncoveredPathsTest.cs (10 tests)

### Key Paths Covered
- NotifySeparation with all 4 handlers set
- BeforeCollision returning false (fixture A and B)
- TryResolveContactFilter with ContactFilter returning false
- PassesCollisionFilters with body ShouldCollide failing
- CollisionGroup zero falling through to category check
- Individual fixture OnSeparation handlers
