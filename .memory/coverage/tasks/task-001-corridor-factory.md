# COVERAGE TASK

## File
1_Presentation/Extension/Math/ProceduralDungeon/src/Services/CorridorFactory.cs

## Coverage
64.3%

## Uncovered Lines
Switch cases for East (lines ~82-85), South (~77-80), West (~87-90) and default (~93-95) in CreateCorridorFromRoom

## Method
CreateCorridorFromRoom (private, called via CreateFirstCorridor and CreateCorridor)

## Existing Tests
CorridorFactoryTest.cs - 7 tests covering: constructor null check, CreateFirstCorridor North direction, CreateFirstCorridor zero width, CreateFirstCorridor negative height, CreateCorridor zero width, CreateCorridor negative height, CreateCorridor avoids opposite direction, CreateCorridor retries on opposite

## Source Code
```csharp
private static CorridorData CreateCorridorFromRoom(int width, int height, RoomData room, Direction direction)
{
    int xPos, yPos, corridorWidth, corridorHeight;

    switch (direction)
    {
        case Direction.North:
            // tested
            break;
        case Direction.South:
            // UNCOVERED
            break;
        case Direction.East:
            // UNCOVERED
            break;
        case Direction.West:
            // UNCOVERED
            break;
        default:
            // UNCOVERED
            break;
    }

    return new CorridorData(xPos, yPos, corridorWidth, corridorHeight, direction);
}
```

## Strategy
Add tests using MockRandomNumberGenerator with values 2 (East), 3 (South), 4 (West) for both CreateFirstCorridor and CreateCorridor. No Moq needed - MockRandomNumberGenerator accepts value parameter.
