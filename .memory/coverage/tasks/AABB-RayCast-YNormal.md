## COVERAGE TASK

### File
4_Operation/Physic/src/Collisions/AABB.cs

### Coverage
97.8% (3 uncovered lines, 1 uncovered condition)

### Uncovered Lines
419-421 (normal.Y = s;)

### Method
ProcessAxis (private, used by RayCast)

### Existing Tests
AabbTest.cs — covers constructors, properties, quadrants, IsValid, Combine, Contains (AABB & point), TestOverlap, RayCast (hit, miss, interior check, negative direction, max fraction, on-boundary)

### Gap
No test covers the Y-axis normal assignment branch (`normal.Y = s;`) in ProcessAxis. All existing RayCast tests enter/exit through X-axis faces.

### Approach
Add RayCast test with shallow diagonal ray from below-left, where Y-axis t1 determines entry, forcing normal.Y assignment.

### Source Diff
```csharp
+ RayCast_WithShallowDiagonal_ShouldSetNormalY
```
