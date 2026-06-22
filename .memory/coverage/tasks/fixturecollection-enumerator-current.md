## COVERAGE TASK

### File
4_Operation/Physic/src/Dynamics/FixtureCollection.cs

### Coverage
97.1%

### Uncovered Lines
1 (IEnumerator<Fixture>.Current throw path)

### Uncovered Conditions
1

### Method
FixtureEnumerator.IEnumerator<Fixture>.Current (explicit interface implementation)

### Existing Tests
FixtureCollectionTest.cs — 19 tests covering:
- Collection construction
- Generic IEnumerable.GetEnumerator
- Non-generic IEnumerable.GetEnumerator
- Typed enumerator Current (modified + unmodified)
- IEnumerator.Current (non-generic, modified + unmodified)
- MoveNext (modified + unmodified)
- Dispose
- Reset
- Contains
- CopyTo
- IndexOf
- ICollection.Add/Clear/Remove throw
- IList.Insert/RemoveAt/SetIndexer throw

### Gap
The explicit `IEnumerator<Fixture>.Current` throw path when collection is modified during enumeration is not tested. When accessed through the `IEnumerator<Fixture>` interface after a generation change, the throw branch is not covered.

### Source Code
```csharp
Fixture IEnumerator<Fixture>.Current
{
    get
    {
        if (_generationStamp == _collection.GenerationStamp)
        {
            return _list[i];
        }
        throw new InvalidOperationException("Collection was modified.");
    }
}
```

### Test to Add
- EnumeratorGenericCurrent_WhenCollectionModified_ThrowsInvalidOperation
