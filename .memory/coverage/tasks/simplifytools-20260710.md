## COVERAGE TASK

### File
4_Operation/Physic/src/Common/PolygonManipulation/SimplifyTools.cs

### Coverage
54.1%

### Uncovered Lines
~77

### Methods Covered by New Tests
- CollinearSimplify (2-pt, 1-pt, all-collinear)
- DouglasPeuckerSimplify (2-pt, 1-pt)
- MergeParallelEdges (2-pt, square result)
- MergeIdenticalPoints (empty)
- ReduceByDistance (2-pt, 1-pt, zero distance)
- ReduceByNth (2-pt, large nth)
- ReduceByArea (2-pt, zero tolerance, mostly-collinear)

### Existing Tests
SimplifyToolsTest.cs (26 existing tests)

### New Tests Added
17 edge-case tests

### Status
COMPLETED - all 43 tests pass
