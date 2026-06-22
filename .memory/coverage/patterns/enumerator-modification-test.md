# Enumerator Modification Test Pattern

## When to Use
When a collection type has custom enumerator with generation stamp/version checking, and the explicit `IEnumerator<T>.Current` throw path is not covered.

## Problem
SonarCloud tracks branch coverage separately for:
1. Public `Current` property
2. Explicit `IEnumerator<T>.Current` implementation
3. Explicit `IEnumerator.Current` (non-generic)

Each has its own branch coverage, even if the code is identical.

## Pattern
```csharp
[Fact]
public void EnumeratorGenericCurrent_WhenCollectionModified_ThrowsInvalidOperation()
{
    // Arrange
    Body body = new Body();
    FixtureCollection collection = new FixtureCollection(body);
    IEnumerator<Fixture> enumerator = ((IEnumerable<Fixture>)collection).GetEnumerator();

    // Act - modify collection to bump generation stamp
    collection.List.Add(new Fixture(new CircleShape(0.3f, 1.0f)));
    collection.GenerationStamp++;

    // Assert
    Assert.Throws<InvalidOperationException>(() => enumerator.Current);
}
```

## Key Insight
Cast to `IEnumerable<T>` to get `GetEnumerator()` returning `IEnumerator<T>`.

## Related Patterns
- `NonGenericEnumerator_Current_WhenCollectionModified_ThrowsInvalidOperation` (cast to `IEnumerator`)
- `Enumerator_MoveNext_WhenCollectionModified_ThrowsInvalidOperation`
