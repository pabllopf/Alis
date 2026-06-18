## COVERAGE TASK

### File

4_Operation/Ecs/src/Redifinition/BitOperations.cs

### Coverage

31.0%

### Uncovered Lines

~66 (Log2, RoundUpToPowerOf2, RotateLeft methods)

### Method

Log2(uint), RoundUpToPowerOf2(uint), RotateLeft(uint, int)

### Existing Tests

None directly targeting BitOperations.

### Source Code

```csharp
public static class BitOperations
{
    public static int Log2(uint value) { ... }
    public static uint RoundUpToPowerOf2(uint value) { ... }
    public static uint RotateLeft(uint value, int offset) { ... }
}
```
