## COVERAGE TASK

### File
4_Operation/Ecs/src/Collections/FastestArrayPool.cs

### Coverage
95.3% (2 uncovered lines, 3 uncovered conditions)

### Uncovered Condition
Line 127: `if (clearArray && RuntimeHelpers.IsReferenceOrContainsReferences<T>())`

Covered states:
- `clearArray=false, IsRef=true` → default return with ref type
- `clearArray=false, IsRef=false` → default return with value type  
- `clearArray=true, IsRef=true` → Return_WithClearArrayAndReferenceType_ClearsContent

Missing state:
- `clearArray=true, IsRef=false` → Return with clearArray=true but T is a value type (e.g., int)

### Existing Tests
FastestArrayPoolTest.cs, FastestArrayPoolSimpleTest.cs, FastestArrayPoolReturnTest.cs, FastestArrayPoolExtendedTest.cs — comprehensive coverage of Rent, Return, ResizeArrayFromPool, oversize, reference type clear.

### Gap
No test exercises Return with `clearArray=true` and a value type parameter, leaving the `IsReferenceOrContainsReferences<T>() == false` branch with `clearArray=true` uncovered.
