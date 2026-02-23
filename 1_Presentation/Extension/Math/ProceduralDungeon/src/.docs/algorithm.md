# Dungeon Generation Algorithm

## Overview

This document explains the algorithm used to generate procedural dungeons in 2D. The process is deterministic (given the same random seed) and produces connected dungeons with varied layouts.

## Generation Process

The dungeon generation follows a multi-phase approach:

### Phase 1: Configuration Validation

Before generation begins, the configuration is validated to ensure all parameters are within acceptable ranges:

- Board dimensions must be positive
- At least 2 rooms are required (including boss room)
- All room and corridor dimensions must be positive

### Phase 2: Room and Corridor Generation

#### Step 1: Create First Room

The first room is placed at the center of the board:

```
Position = (BoardWidth / 2, BoardHeight / 2)
Size = (FirstRoomWidth, FirstRoomHeight)
Direction = North
```

This room serves as the starting point for the dungeon layout.

#### Step 2: Create First Corridor

A corridor is created extending from the first room in a random direction:

```
Direction = Random(North, South, East, West)
Position = Calculated based on room position and direction
Size = (CorridorWidth, CorridorHeight)
```

#### Step 3: Generate Intermediate Rooms and Corridors

For each remaining room (except the boss room):

1. Create a room at the end of the previous corridor
2. Create a new corridor extending from the new room
3. The corridor direction is chosen randomly but avoids going back (opposite direction)

This creates a winding path through the dungeon.

#### Step 4: Create Boss Room

The final room is marked as the boss room:

```
Position = End of last corridor
Size = (BossRoomWidth, BossRoomHeight)
IsBossRoom = true
```

### Phase 3: Board Construction

#### Step 1: Initialize Empty Board

Create a 2D array of BoardSquare objects, all initialized to `Empty`:

```
Board[width, height] = All squares set to BoardSquareType.Empty
```

#### Step 2: Place Rooms

For each room, set all squares within the room bounds to `Floor`:

```
For x from room.XPos to room.XPos + room.Width:
    For y from room.YPos to room.YPos + room.Height:
        Board[x, y].Type = Floor
```

#### Step 3: Place Corridors

Similar to rooms, set all corridor squares to `Floor`:

```
For x from corridor.XPos to corridor.XPos + corridor.Width:
    For y from corridor.YPos to corridor.YPos + corridor.Height:
        Board[x, y].Type = Floor
```

### Phase 4: Wall and Corner Generation

This phase uses a multi-pass algorithm to detect and set appropriate wall and corner types.

#### Pass 1: Generate Walls

For each floor tile, check adjacent tiles:

```
If Board[x, y] == Floor:
    If Board[x, y-1] == Empty: Board[x, y] = WallDown
    If Board[x-1, y] == Empty: Board[x, y] = WallLeft
    If Board[x+1, y] == Empty: Board[x, y] = WallRight
    If Board[x, y+1] == Empty: Board[x, y] = WallTop
```

#### Pass 2: Generate Outer Corners

For non-empty tiles adjacent to two empty perpendicular directions:

```
If Board[x, y] != Empty:
    If Board[x-1, y] == Empty AND Board[x, y-1] == Empty:
        Board[x, y] = CornerLeftDown
    If Board[x+1, y] == Empty AND Board[x, y-1] == Empty:
        Board[x, y] = CornerRightDown
    If Board[x-1, y] == Empty AND Board[x, y+1] == Empty:
        Board[x, y] = CornerLeftUp
    If Board[x+1, y] == Empty AND Board[x, y+1] == Empty:
        Board[x, y] = CornerRightUp
```

#### Pass 3: Generate Inner Corners

For floor tiles with diagonal empty spaces:

```
If Board[x, y] == Floor:
    If Board[x-1, y-1] == Empty: Board[x, y] = CornerInternalLeftDown
    If Board[x+1, y-1] == Empty: Board[x, y] = CornerInternalRightDown
    If Board[x-1, y+1] == Empty: Board[x, y] = CornerInternalLeftUp
    If Board[x+1, y+1] == Empty: Board[x, y] = CornerInternalRightUp
```

## Direction Calculation

### Room Positioning

When creating a room from a corridor, the position depends on the corridor's direction:

**North**:
```
Room.X = Corridor.X + (Corridor.Width / 2) - (Room.Width / 2)
Room.Y = Corridor.Y + Corridor.Height
Room.Width = Width
Room.Height = Height
```

**South**:
```
Room.X = Corridor.X + (Corridor.Width / 2) - (Room.Width / 2)
Room.Y = Corridor.Y - Height
Room.Width = Width
Room.Height = Height
```

**East**:
```
Room.X = Corridor.X - Height
Room.Y = Corridor.Y + (Corridor.Height / 2) - (Height / 2)
Room.Width = Height (swapped)
Room.Height = Width (swapped)
```

**West**:
```
Room.X = Corridor.X + Corridor.Width
Room.Y = Corridor.Y + (Corridor.Height / 2) - (Height / 2)
Room.Width = Height (swapped)
Room.Height = Width (swapped)
```

Note: East and West directions swap width and height to maintain proper alignment.

### Corridor Positioning

Similar logic applies when creating corridors from rooms, ensuring proper connection points.

## Random Direction Selection

### Avoiding Backtracking

When generating corridors after the first one, the algorithm avoids the opposite direction:

```
1. Get opposite of previous room's direction
2. Generate random direction
3. If direction equals opposite, regenerate
4. Repeat until valid direction found
```

This ensures dungeons progress forward rather than doubling back unnecessarily.

### Direction Opposite Calculation

The opposite direction is calculated using modular arithmetic:

```
OppositeValue = ((CurrentValue + 2 - 1) % 4) + 1

Where:
North (1) → South (3)
East (2) → West (4)
South (3) → North (1)
West (4) → East (2)
```

## Randomization

### Cryptographic Randomization

The system uses `CryptoRandomNumberGenerator` which provides secure random numbers:

- Based on `System.Security.Cryptography.RandomNumberGenerator`
- Provides truly random values (not pseudorandom)
- Suitable for procedural generation requiring unpredictability

### Testable Randomization

For testing purposes, the `IRandomNumberGenerator` interface allows mock implementations with predictable sequences.

## Boundary Conditions

### Board Boundaries

All room and corridor placements are bounded by the board dimensions:

```
If x < 0: x = 0
If x >= BoardWidth: Skip
If y < 0: y = 0
If y >= BoardHeight: Skip
```

This ensures generated content stays within the board.

### Wall Generation Boundaries

Wall and corner generation only processes internal squares (not edges):

```
For x from 1 to Width - 2:
    For y from 1 to Height - 2:
        Process square
```

This prevents array index out of bounds errors.

## Complexity Analysis

### Time Complexity

- Room/Corridor Generation: O(n) where n = number of rooms
- Board Initialization: O(w × h) where w = width, h = height
- Room/Corridor Placement: O(n × r) where r = average room/corridor size
- Wall Generation: O(w × h)

Overall: **O(w × h)** dominated by board operations

### Space Complexity

- Board: O(w × h)
- Rooms: O(n)
- Corridors: O(n)

Overall: **O(w × h)** dominated by the board array

## Algorithm Characteristics

### Advantages

1. **Guaranteed Connectivity**: All rooms are connected through corridors
2. **Predictable Layout**: Linear progression from start to boss room
3. **Efficient**: Single-pass generation with no backtracking
4. **Configurable**: All parameters can be adjusted
5. **Deterministic**: Same seed produces same dungeon

### Limitations

1. **Linear Structure**: Dungeons are essentially linear paths
2. **No Branching**: No side rooms or alternate paths
3. **No Loops**: Cannot create circular or interconnected room networks
4. **Fixed Boss Room**: Boss room is always at the end

## Potential Enhancements

### Multi-Path Generation

Add branch points where dungeons split into multiple paths:

```
At certain rooms, create 2-3 corridors instead of 1
Continue generation on each branch
```

### Room Variety

Add different room shapes and types:

- Circular rooms
- L-shaped rooms
- Large open areas
- Treasure rooms
- Trap rooms

### Loop Creation

Connect rooms to create loops:

```
After main generation, randomly connect distant rooms
Ensures multiple paths between areas
```

### Organic Placement

Use cellular automata or noise functions for more natural-looking dungeons:

```
Generate noise map
Place rooms in high-value areas
Connect with A* pathfinding
```

## Implementation Notes

### Immutability

- `RoomData` and `CorridorData` are immutable structs
- Once created, their properties cannot change
- Ensures thread safety and predictability

### Separation of Concerns

- Room/corridor creation is separate from board building
- Data generation is separate from visualization
- Easy to extend or modify individual components

### Interface-Based Design

- All major components use interfaces
- Easy to swap implementations
- Facilitates testing and extension

