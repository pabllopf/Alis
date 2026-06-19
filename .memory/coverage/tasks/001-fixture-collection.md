## COVERAGE TASK

### File

4_Operation/Physic/src/Dynamics/FixtureCollection.cs

### Coverage

58.6%

### Uncovered Lines (estimated)

24

### Priority

1 (Public methods with uncovered lines)

### Methods needing coverage

- `IList<Fixture>.Insert(int, Fixture)` — NotSupportedException path
- `IList<Fixture>.RemoveAt(int)` — NotSupportedException path
- `IList<Fixture>.this[int].set` — NotSupportedException path
- `ICollection<Fixture>.Remove(Fixture)` — NotSupportedException path
- `CopyTo(Fixture[], int)` — normal operation
- `IndexOf(Fixture)` — normal operation (not found, found)
- `GetEnumerator()` — typed enumerator
- `FixtureEnumerator.MoveNext()` — iteration complete, after modification
- `FixtureEnumerator.Current` — typed and IEnumerator
- `FixtureEnumerator.Reset()`
- `FixtureEnumerator.Dispose()`

### Existing Tests

`4_Operation/Physic/test/Dynamics/FixtureCollectionTest.cs` (93 lines, 3 tests)

### Source Code

See `4_Operation/Physic/src/Dynamics/FixtureCollection.cs`
