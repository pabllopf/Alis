## COVERAGE TEST PATTERN

### Target
CorridorFactory.cs — while-loop branch in GetRandomDirectionAvoidingOpposite

### Pattern
Use Moq's `SetupSequence` to make the RNG return the opposite direction on first call (forcing loop iteration) and a valid direction on second call.

```csharp
[Fact]
public void CreateCorridor_WhenRandomIsOpposite_ShouldRetryUntilValid()
{
    Direction roomDirection = Direction.East;
    Direction opposite = Direction.West;
    Mock<IRandomNumberGenerator> mockRng = new Mock<IRandomNumberGenerator>();
    mockRng.SetupSequence(m => m.Next(1, 5))
        .Returns((int)opposite)
        .Returns((int)Direction.North);

    CorridorFactory factory = new CorridorFactory(mockRng.Object);
    RoomData room = new RoomData(10, 10, 8, 8, roomDirection);

    CorridorData corridor = factory.CreateCorridor(4, 4, room);

    Assert.Equal(Direction.North, corridor.Direction);
    mockRng.Verify(m => m.Next(1, 5), Times.Exactly(2));
}
```

### Key Insight
The `while (newDirection == oppositeDirection)` branch that re-enters the loop was only tested through its exit path. Moq `SetupSequence` forces the first RNG call to return the opposite direction, exercising the loop body a second time.

### Related Files
- `1_Presentation/Extension/Math/ProceduralDungeon/src/Services/CorridorFactory.cs` (line 155-165, removed dead code on 166)
- `1_Presentation/Extension/Math/ProceduralDungeon/test/Services/CorridorFactoryTest.cs`
