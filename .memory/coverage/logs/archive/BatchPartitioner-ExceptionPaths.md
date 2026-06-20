## COVERAGE TASK

### File
1_Presentation/Extension/Thread/src/Scheduling/BatchPartitioner.cs

### Coverage
86.7% (4 uncovered lines)

### Uncovered Lines
80-82: totalCount <= 0 guard
85-87: partitionCount <= 0 guard

### Existing Tests
4 tests — standard partition creation and balanced partition creation

### Gap
No test exercises the validation guard clauses for zero/negative parameters.

### Fix
Add 4 tests for the ArgumentOutOfRangeException guard clauses (zero and negative for each parameter).
Plus 1 test for partitionCount > totalCount (Math.Min branch).
