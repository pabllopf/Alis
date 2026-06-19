---
status: In Progress
---

## COVERAGE TASK

### File

4_Operation/Physic/src/Dynamics/BodyCollection.cs

### Coverage

72.9%

### Uncovered Lines (estimated)

14

### Methods needing coverage

- `BodyEnumerator.MoveNext()` — exhausted (return false after full iteration)
- `BodyEnumerator.MoveNext()` — `InvalidOperationException` when generation stamp changes
- `BodyEnumerator.Current` (generic) — `InvalidOperationException` on modified collection
- `BodyEnumerator.Current` (non-generic) — `InvalidOperationException` on modified collection
- `BodyEnumerator.Reset()`
- `BodyEnumerator.Dispose()`
- `IndexOf` for non-existing item
- `get_Item` with out-of-range index

### Existing Tests

`4_Operation/Physic/test/Dynamics/BodyCollectionTest.cs` (247 lines, 15 tests)

### Pattern

Reuse FixtureCollection enumerator edge-case pattern (FixtureCollectionTest.cs lines 217-310)
