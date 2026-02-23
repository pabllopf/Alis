# Usage Guide

## Getting Started

The Procedural Dungeon Generator 2D module provides a simple API for generating random dungeon layouts. This guide will walk you through the basic usage and advanced scenarios.

## Basic Usage

### Creating a Dungeon with Default Settings

```csharp
using Alis.Extension.Math.ProceduralDungeon;
using Alis.Extension.Math.ProceduralDungeon.Models;

// Create a dungeon with default configuration
using var dungeon = new Dungeon();

// Generate the dungeon
DungeonData data = dungeon.Generate();

// Access dungeon information
Console.WriteLine($"Dungeon size: {data.Width}x{data.Height}");
Console.WriteLine($"Number of rooms: {data.Rooms.Count}");
Console.WriteLine($"Number of corridors: {data.Corridors.Count}");
```

Default configuration creates:
- Board size: 150x150
- Number of rooms: 4
- First room: 8x8
- Standard rooms: 5x5
- Boss room: 7x7
- Corridors: 4x4

## Custom Configuration

### Creating a Custom Dungeon

```csharp
// Create custom configuration
var config = new DungeonConfiguration
{
    BoardWidth = 200,
    BoardHeight = 200,
    NumberOfRooms = 8,
    FirstRoomWidth = 10,
    FirstRoomHeight = 10,
    RoomWidth = 6,
    RoomHeight = 6,
    BossRoomWidth = 12,
    BossRoomHeight = 12,
    CorridorWidth = 5,
    CorridorHeight = 5
};

// Create dungeon with custom configuration
using var dungeon = new Dungeon(config);
DungeonData data = dungeon.Generate();
```

### Configuration Parameters

| Parameter | Description | Default | Constraints |
|-----------|-------------|---------|-------------|
| BoardWidth | Width of the dungeon board | 150 | > 0 |
| BoardHeight | Height of the dungeon board | 150 | > 0 |
| NumberOfRooms | Total number of rooms including boss room | 4 | >= 2 |
| FirstRoomWidth | Width of the starting room | 8 | > 0 |
| FirstRoomHeight | Height of the starting room | 8 | > 0 |
| RoomWidth | Width of standard rooms | 5 | > 0 |
| RoomHeight | Height of standard rooms | 5 | > 0 |
| BossRoomWidth | Width of the boss room | 7 | > 0 |
| BossRoomHeight | Height of the boss room | 7 | > 0 |
| CorridorWidth | Width of corridors | 4 | > 0 |
| CorridorHeight | Height of corridors | 4 | > 0 |

## Working with Dungeon Data

### Accessing Rooms

```csharp
DungeonData data = dungeon.Generate();

// Iterate through rooms
foreach (RoomData room in data.Rooms)
{
    Console.WriteLine($"Room at ({room.XPos}, {room.YPos})");
    Console.WriteLine($"Size: {room.Width}x{room.Height}");
    Console.WriteLine($"Direction: {room.Direction}");
    Console.WriteLine($"Is Boss Room: {room.IsBossRoom}");
}

// Find the boss room
RoomData bossRoom = data.Rooms.Find(r => r.IsBossRoom);
```

### Accessing Corridors

```csharp
// Iterate through corridors
foreach (CorridorData corridor in data.Corridors)
{
    Console.WriteLine($"Corridor at ({corridor.XPos}, {corridor.YPos})");
    Console.WriteLine($"Size: {corridor.Width}x{corridor.Height}");
    Console.WriteLine($"Direction: {corridor.Direction}");
}
```

### Accessing the Board

```csharp
// Get board dimensions
int width = data.Width;
int height = data.Height;

// Access individual squares
for (int x = 0; x < width; x++)
{
    for (int y = 0; y < height; y++)
    {
        BoardSquare square = data.Board[x, y];
        BoardSquareType type = square.Type;
        
        // Process square based on type
        if (type == BoardSquareType.Floor)
        {
            // This is a walkable floor tile
        }
        else if (type == BoardSquareType.WallTop)
        {
            // This is a wall
        }
    }
}
```

## Board Square Types

The board contains different types of squares:

| Type | Description |
|------|-------------|
| Empty | Unoccupied space outside the dungeon |
| Floor | Walkable floor tiles (rooms and corridors) |
| WallTop | Top wall |
| WallBottom | Bottom wall |
| WallLeft | Left wall |
| WallRight | Right wall |
| CornerLeftUp | Outer corner (left-up) |
| CornerRightUp | Outer corner (right-up) |
| CornerLeftDown | Outer corner (left-down) |
| CornerRightDown | Outer corner (right-down) |
| CornerInternalLeftUp | Inner corner (left-up) |
| CornerInternalRightUp | Inner corner (right-up) |
| CornerInternalLeftDown | Inner corner (left-down) |
| CornerInternalRightDown | Inner corner (right-down) |

## Advanced Usage

### Using Helpers

```csharp
using Alis.Extension.Math.ProceduralDungeon.Helpers;

// Working with directions
Direction opposite = DirectionHelper.GetOpposite(Direction.North);
bool isValid = DirectionHelper.IsValid(Direction.East);
bool areOpposite = DirectionHelper.AreOpposite(Direction.North, Direction.South);

// Working with board square types
bool isWall = BoardSquareTypeHelper.IsWall(BoardSquareType.WallTop);
bool isCorner = BoardSquareTypeHelper.IsCorner(BoardSquareType.CornerLeftUp);
bool isWalkable = BoardSquareTypeHelper.IsWalkable(BoardSquareType.Floor);
char displayChar = BoardSquareTypeHelper.GetDisplayCharacter(BoardSquareType.WallTop);
```

### Visualizing the Dungeon

```csharp
public void VisualizeDungeon(DungeonData data)
{
    // Find bounds of actual dungeon content
    int minX = data.Width, maxX = 0, minY = data.Height, maxY = 0;
    
    for (int x = 0; x < data.Width; x++)
    {
        for (int y = 0; y < data.Height; y++)
        {
            if (data.Board[x, y].Type != BoardSquareType.Empty)
            {
                minX = Math.Min(minX, x);
                maxX = Math.Max(maxX, x);
                minY = Math.Min(minY, y);
                maxY = Math.Max(maxY, y);
            }
        }
    }
    
    // Display the dungeon
    for (int y = minY; y <= maxY; y++)
    {
        for (int x = minX; x <= maxX; x++)
        {
            char symbol = BoardSquareTypeHelper.GetDisplayCharacter(
                data.Board[x, y].Type);
            Console.Write(symbol);
        }
        Console.WriteLine();
    }
}
```

### Generating Multiple Dungeons

```csharp
public List<DungeonData> GenerateMultipleDungeons(int count)
{
    var dungeons = new List<DungeonData>();
    
    using (var dungeon = new Dungeon())
    {
        for (int i = 0; i < count; i++)
        {
            dungeons.Add(dungeon.Generate());
        }
    }
    
    return dungeons;
}
```

## Best Practices

### 1. Dispose Resources

Always dispose of the `Dungeon` instance when finished:

```csharp
// Using statement (recommended)
using var dungeon = new Dungeon();
var data = dungeon.Generate();

// Or explicit disposal
var dungeon = new Dungeon();
try
{
    var data = dungeon.Generate();
}
finally
{
    dungeon.Dispose();
}
```

### 2. Validate Configuration

Always validate your configuration:

```csharp
var config = new DungeonConfiguration { /* ... */ };

try
{
    config.Validate();
    using var dungeon = new Dungeon(config);
    var data = dungeon.Generate();
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Invalid configuration: {ex.Message}");
}
```

### 3. Reuse Dungeon Instance

Reuse the same `Dungeon` instance for multiple generations:

```csharp
using var dungeon = new Dungeon();

// Generate multiple different dungeons
var dungeon1 = dungeon.Generate();
var dungeon2 = dungeon.Generate();
var dungeon3 = dungeon.Generate();
```

### 4. Handle Large Dungeons

For very large dungeons, consider memory constraints:

```csharp
// Be careful with very large boards
var config = new DungeonConfiguration
{
    BoardWidth = 1000,  // Creates a 1000x1000 board
    BoardHeight = 1000
};

// This creates a 1,000,000 element array
using var dungeon = new Dungeon(config);
var data = dungeon.Generate();
```

## Error Handling

### Common Exceptions

1. **ArgumentNullException**: Configuration is null
2. **ArgumentException**: Invalid configuration values
3. **ObjectDisposedException**: Using disposed Dungeon instance

```csharp
try
{
    using var dungeon = new Dungeon(configuration);
    var data = dungeon.Generate();
}
catch (ArgumentNullException ex)
{
    Console.WriteLine("Configuration cannot be null");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Invalid configuration: {ex.Message}");
}
catch (ObjectDisposedException ex)
{
    Console.WriteLine("Cannot use disposed dungeon instance");
}
```

## Performance Tips

1. **Reuse instances**: Create one `Dungeon` instance and call `Generate()` multiple times
2. **Reasonable board sizes**: Keep board dimensions appropriate for your needs
3. **Memory management**: Dispose of `Dungeon` instances when done
4. **Configuration validation**: Validate configuration once before multiple generations

## Integration Examples

### Game Engine Integration

```csharp
public class DungeonLevel
{
    private readonly DungeonData _dungeonData;
    
    public DungeonLevel()
    {
        using var dungeon = new Dungeon();
        _dungeonData = dungeon.Generate();
        InitializeGameObjects();
    }
    
    private void InitializeGameObjects()
    {
        // Place player in first room
        RoomData firstRoom = _dungeonData.Rooms[0];
        PlacePlayer(firstRoom.XPos + firstRoom.Width / 2, 
                    firstRoom.YPos + firstRoom.Height / 2);
        
        // Place boss in boss room
        RoomData bossRoom = _dungeonData.Rooms.Find(r => r.IsBossRoom);
        PlaceBoss(bossRoom.XPos + bossRoom.Width / 2,
                  bossRoom.YPos + bossRoom.Height / 2);
        
        // Place enemies in other rooms
        foreach (var room in _dungeonData.Rooms)
        {
            if (!room.IsBossRoom && _dungeonData.Rooms.IndexOf(room) != 0)
            {
                PlaceEnemies(room);
            }
        }
    }
}
```

