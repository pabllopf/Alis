## COVERAGE TEST PATTERN

### Target
ControllerCollection.cs — non-generic IEnumerable.GetEnumerator()

### Pattern
Cast ControllerCollection to the non-generic `System.Collections.IEnumerable` interface and verify `GetEnumerator()` returns a `ControllerEnumerator`.

```csharp
[Fact]
public void Collection_NonGenericEnumerable_GetEnumerator_ReturnsControllerEnumerator()
{
    WorldPhysic world = new WorldPhysic(Vector2F.Zero);
    ControllerCollection collection = world.ControllerList;
    System.Collections.IEnumerable nonGeneric = collection;

    System.Collections.IEnumerator result = nonGeneric.GetEnumerator();

    Assert.IsType<ControllerEnumerator>(result);
}
```

### Key Insight
When `ControllerCollection` is used through `IEnumerable` (non-generic), the explicit interface implementation on line 130 is called instead of the public typed `GetEnumerator()`. The foreach loop in C# prefers the typed `GetEnumerator()` (duck-typing pattern), so the non-generic interface branch is only exercised when the caller explicitly casts to `IEnumerable`.

### Related Files
- `4_Operation/Physic/src/Dynamics/ControllerCollection.cs` (line 130)
- `4_Operation/Physic/test/Dynamics/ControllerCollectionTest.cs` (line 294)
