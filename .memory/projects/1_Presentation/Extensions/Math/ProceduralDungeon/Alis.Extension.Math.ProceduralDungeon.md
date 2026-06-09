---
title: Alis.Extension.Math.ProceduralDungeon
tags: [presentation,application,extension,documentation]
---


## Overview

The **Alis.Extension.Math.ProceduralDungeon** project provides a robust procedural dungeon generation system for ALIS games, enabling automatic creation of randomized dungeon layouts with rooms, corridors, and structured board generation.

**Type**: Extension  
**Framework**: net8.0/netstandard2.0  
**Files**: 25 source files

## Purpose

This extension implements a facade-based procedural generation system that creates balanced, playable dungeon layouts with configurable parameters for room count, board size, and generation complexity.

## Architecture

### Design Pattern

Implements **Facade Pattern** for simplified dungeon generation:

```csharp
public class Dungeon : IDisposable
{
    private readonly IDungeonGenerator _generator;
    private readonly IRandomNumberGenerator _randomNumberGenerator;
    
    public DungeonData Generate() => _generator.Generate();
}
```

### Factory Pattern

Uses factories for creating dungeon components:

```csharp
private static IDungeonGenerator CreateGenerator(
    DungeonConfiguration configuration,
    IRandomNumberGenerator randomNumberGenerator)
{
    IRoomFactory roomFactory = new RoomFactory();
    ICorridorFactory corridorFactory = new CorridorFactory(randomNumberGenerator);
    IBoardBuilder boardBuilder = new BoardBuilder();

    return new DungeonGenerator(configuration, roomFactory, corridorFactory, boardBuilder);
}
```

### Layered Architecture

```
┌─────────────────────────────────────┐
│         Facade Layer                │
│           Dungeon                   │
├─────────────────────────────────────┤
│       Generator Layer               │
│      DungeonGenerator               │
├─────────────────────────────────────┤
│        Factory Layer                │
│   RoomFactory | CorridorFactory     │
├─────────────────────────────────────┤
│        Builder Layer                │
│        BoardBuilder                 │
├─────────────────────────────────────┤
│         Model Layer                 │
│   Position | Dimensions | RoomData  │
└─────────────────────────────────────┘
```

## Components

### Core Classes

| Class | Description | Lines |
|-------|-------------|-------|
| `Dungeon` | Main facade class | 184 |
| `DungeonGenerator` | Dungeon generation logic | - |
| `BoardBuilder` | Board layout builder | - |

### Models

| Class | Description |
|-------|-------------|
| `DungeonData` | Generated dungeon result |
| `DungeonConfiguration` | Generation settings |
| `RoomData` | Individual room info |
| `CorridorData` | Corridor connection info |
| `Position` | 2D position vector |
| `Dimensions` | Board dimensions |

### Services

| Class | Description |
|-------|-------------|
| `RoomFactory` | Room creation service |
| `CorridorFactory` | Corridor generation service |
| `BoardBuilder` | Board assembly service |
| `CryptoRandomNumberGenerator` | Secure RNG implementation |

### Interfaces

| Interface | Description |
|-----------|-------------|
| `IDungeonGenerator` | Generator contract |
| `IRoomFactory` | Room factory contract |
| `ICorridorFactory` | Corridor factory contract |
| `IBoardBuilder` | Board builder contract |
| `IRandomNumberGenerator` | RNG contract |

## Public API

### Basic Generation

```csharp
// Default configuration (150x150 board, 4 rooms)
var dungeon = new Dungeon();
DungeonData data = dungeon.Generate();

// Access generated data
foreach (var room in data.Rooms)
{
    Logger.Info($"Room at {room.Position} with size {room.Dimensions}");
}

foreach (var corridor in data.Corridors)
{
    Logger.Info($"Corridor from {corridor.Start} to {corridor.End}");
}
```

### Custom Configuration

```csharp
var config = new DungeonConfiguration
{
    BoardWidth = 200,
    BoardHeight = 150,
    NumberOfRooms = 8,
    MinRoomWidth = 10,
    MaxRoomWidth = 25,
    MinRoomHeight = 8,
    MaxRoomHeight = 20,
    HasBossRoom = true,
    HasEntranceRoom = true
};

var dungeon = new Dungeon(config);
DungeonData data = dungeon.Generate();
```

### Advanced Configuration

```csharp
var config = new DungeonConfiguration
{
    BoardWidth = 300,
    BoardHeight = 300,
    NumberOfRooms = 12,
    MinRoomWidth = 15,
    MaxRoomWidth = 30,
    MinRoomHeight = 12,
    MaxRoomHeight = 25,
    HasBossRoom = true,
    HasEntranceRoom = true,
    CorridorWidth = 5,
    MaxRoomOverlap = 2,
    ValidationAttempts = 100
};

var dungeon = new Dungeon(config);
DungeonData data = dungeon.Generate();

// Validate dungeon
if (data.IsValid)
{
    // Use generated dungeon
}
```

### Board Access

```csharp
var dungeon = new Dungeon();
DungeonData data = dungeon.Generate();

// Access board squares
for (int y = 0; y < data.BoardHeight; y++)
{
    for (int x = 0; x < data.BoardWidth; x++)
    {
        BoardSquare square = data.GetSquare(x, y);
        switch (square.Type)
        {
            case BoardSquareType.Room:
                // Draw room tile
                break;
            case BoardSquareType.Corridor:
                // Draw corridor tile
                break;
            case BoardSquareType.Wall:
                // Draw wall tile
                break;
        }
    }
}
```

## Dependencies

```xml
<Project Sdk="Microsoft.NET.Sdk">
    <Import Project="$(SolutionDir).config/Config.props"/>
</Project>
```

**Internal Dependencies**:
- None (pure algorithmic generation)

**External Dependencies**:
- None

## Configuration Options

### DungeonConfiguration Properties

| Property | Type | Default | Description |
|----------|------|---------|-------------|
| `BoardWidth` | int | 150 | Board width in tiles |
| `BoardHeight` | int | 150 | Board height in tiles |
| `NumberOfRooms` | int | 4 | Target room count |
| `MinRoomWidth` | int | 5 | Minimum room width |
| `MaxRoomWidth` | int | 15 | Maximum room width |
| `MinRoomHeight` | int | 5 | Minimum room height |
| `MaxRoomHeight` | int | 12 | Maximum room height |
| `HasBossRoom` | bool | true | Include boss room |
| `HasEntranceRoom` | bool | true | Include entrance room |
| `CorridorWidth` | int | 3 | Corridor width in tiles |
| `MaxRoomOverlap` | int | 2 | Max room overlap |
| `ValidationAttempts` | int | 100 | Generation retries |

## Usage Example

```csharp
// Create dungeon with custom config
var config = new DungeonConfiguration
{
    BoardWidth = 100,
    BoardHeight = 80,
    NumberOfRooms = 6,
    MinRoomWidth = 8,
    MaxRoomWidth = 15,
    MinRoomHeight = 6,
    MaxRoomHeight = 12,
    HasBossRoom = true,
    HasEntranceRoom = true,
    CorridorWidth = 3
};

using (var dungeon = new Dungeon(config))
{
    DungeonData data = dungeon.Generate();
    
    // Validate generation
    if (!data.IsValid)
    {
        Logger.Warning("Dungeon generation failed validation");
        return;
    }
    
    // Access rooms
    foreach (var room in data.Rooms)
    {
        Logger.Info($"Room: {room.Position} x {room.Dimensions}");
    }
    
    // Access corridors
    foreach (var corridor in data.Corridors)
    {
        Logger.Info($"Corridor: {corridor.Start} -> {corridor.End}");
    }
    
    // Access board for rendering
    RenderBoard(data.Board);
}

// Helper method to render board
void RenderBoard(BoardSquare[,] board)
{
    for (int y = 0; y < board.GetLength(1); y++)
    {
        for (int x = 0; x < board.GetLength(0); x++)
        {
            char c = board[x, y].Type switch
            {
                BoardSquareType.Wall => '#',
                BoardSquareType.Room => '.',
                BoardSquareType.Corridor => '-',
                BoardSquareType.Entrance => 'E',
                BoardSquareType.BossRoom => 'B',
                _ => ' '
            };
            Console.Write(c);
        }
        Console.WriteLine();
    }
}
```

## Testing

**Test Project**: `Alis.Extension.Math.ProceduralDungeon.Test`  
**Sample Project**: `Alis.Extension.Math.ProceduralDungeon.Sample`

## Performance Characteristics

| Metric | Value |
|--------|-------|
| Generation Time | O(n²) where n = board size |
| Memory Usage | O(w × h) for board storage |
| Room Placement | O(r²) where r = room count |

## Status

| Aspect | Status |
|--------|--------|
| Implementation | ✓ Complete |
| Documentation | ✓ Documented |
| Tests | ✓ Unit tests exist |
| Samples | Pending |

## Related Projects

- [[Alis.Extension.Math.HighSpeedPriorityQueue]] - Priority queue for pathfinding
- [[Alis.Core.Ecs]] - ECS engine for rendering

## TODO

- [ ] Add dungeon validation improvements
- [ ] Implement room connectivity checks
- [ ] Add support for nested dungeons
- [ ] Create visual dungeon editor sample
