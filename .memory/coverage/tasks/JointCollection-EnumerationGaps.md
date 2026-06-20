## COVERAGE TASK

### File
4_Operation/Physic/src/Dynamics/JointCollection.cs

### Existing Tests
JointCollectionTest.cs — 3 tests: add+contains, read-only, enumerate 2 joints

### Gap
Missing: Contains (missing), CopyTo, IndexOf, Count, indexer, enumerator edge cases, non-generic Current, Reset, Dispose, generic/non-generic IEnumerable

### Approach
Add 6+ tests following the FixtureCollection pattern
