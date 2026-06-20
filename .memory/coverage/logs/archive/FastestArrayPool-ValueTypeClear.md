## COVERAGE TEST PATTERN

### Target
FastestArrayPool.cs — Return with clearArray=true and value type parameter

### Pattern
Exercise the `clearArray && RuntimeHelpers.IsReferenceOrContainsReferences<T>()` branch where `IsReferenceOrContainsReferences<int>()` returns false.

```csharp
[Fact]
public void Return_WithClearArrayAndValueType_DoesNotClear()
{
    FastestArrayPool<int> pool = FastestArrayPool<int>.Instance;
    int[] array = pool.Rent(100);
    array[0] = 42;

    pool.Return(array, clearArray: true);

    Assert.Equal(42, array[0]);
}
```

### Key Insight
SonarCloud's condition coverage tracks each condition in a compound `&&` expression separately. The `IsReferenceOrContainsReferences<int>() == false` branch with `clearArray=true` was uncovered because no test used `clearArray=true` with a pure value type.

### Related Files
- `4_Operation/Ecs/src/Collections/FastestArrayPool.cs` (line 127)
- `4_Operation/Ecs/test/Collections/FastestArrayPoolReturnTest.cs`
