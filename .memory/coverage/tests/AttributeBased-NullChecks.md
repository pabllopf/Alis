## COVERAGE TEST PATTERN

### Target
AttributeBasedExecutionStrategy.cs — null-guard branches

### Pattern
Add null-parameter tests for public methods with null-guard clauses.

```csharp
[Fact]
public void CanExecuteInParallel_NullType_ReturnsFalse()
{
    AttributeBasedExecutionStrategy strategy = new AttributeBasedExecutionStrategy();
    bool result = strategy.CanExecuteInParallel(null);
    Assert.False(result);
}

[Fact]
public void GetMinimumBatchSize_NullType_ReturnsDefault()
{
    AttributeBasedExecutionStrategy strategy = new AttributeBasedExecutionStrategy();
    int batchSize = strategy.GetMinimumBatchSize(null);
    Assert.Equal(128, batchSize);
}
```

### Key Insight
Null-guard branches are common uncovered lines. Always test the defensive `if (param == null) return default` paths.

### Related Files
- `1_Presentation/Extension/Thread/src/Strategies/AttributeBasedExecutionStrategy.cs` (lines 87-89, 118-121)
- `1_Presentation/Extension/Thread/test/AttributeBasedExecutionStrategyTest.cs`
