# Procedural Dungeon Generator - Architecture Overview

## Table of Contents
1. [Introduction](#introduction)
2. [Architecture](#architecture)
3. [Design Patterns](#design-patterns)
4. [Core Components](#core-components)
5. [Usage Examples](#usage-examples)

## Introduction

The Procedural Dungeon Generator is a robust, maintainable, and testable system for generating 2D dungeons procedurally. It follows SOLID principles and modern software design patterns to ensure code quality and extensibility.

### Key Features
- **Fully testable architecture** with dependency injection
- **Immutable data structures** for thread safety
- **Separation of concerns** with clear boundaries
- **No singletons** - all dependencies are injected
- **Configurable generation** parameters
- **Clean, documented code** following best practices

## Architecture Overview

## Introduction

The Procedural Dungeon Generator 2D module is designed to create random dungeon layouts with rooms and corridors. It follows modern software engineering principles including SOLID, Clean Code, and well-established design patterns.

## Design Patterns

### 1. Factory Pattern

The module uses the Factory pattern extensively to create dungeon components:

- **IRoomFactory / RoomFactory**: Creates different types of rooms (first room, standard room, boss room)
- **ICorridorFactory / CorridorFactory**: Creates corridors that connect rooms

**Benefits**:
- Encapsulates object creation logic
- Makes the code more maintainable and testable
- Allows for easy extension with new room/corridor types

### 2. Builder Pattern

- **IBoardBuilder / BoardBuilder**: Constructs complex board structures step by step

**Benefits**:
- Separates the construction of complex objects from their representation
- Allows for different representations using the same construction process
- Provides better control over the construction process

### 3. Facade Pattern

- **Dungeon**: Provides a simplified interface to the complex subsystem of generators, factories, and builders

**Benefits**:
- Simplifies the client interface
- Reduces coupling between the client and subsystem
- Makes the library easier to use

### 4. Strategy Pattern (Implicit)

- **IRandomNumberGenerator**: Allows different random number generation strategies (CryptoRandomNumberGenerator)

**Benefits**:
- Makes the algorithm interchangeable
- Improves testability by allowing mock implementations
- Enables different randomization strategies

## SOLID Principles

### Single Responsibility Principle (SRP)

Each class has a single, well-defined responsibility:

- `DungeonGenerator`: Orchestrates dungeon generation
- `RoomFactory`: Creates rooms
- `CorridorFactory`: Creates corridors
- `BoardBuilder`: Builds the board layout
- `DirectionHelper`: Provides direction-related utilities
- `BoardSquareTypeHelper`: Provides board square type utilities

### Open/Closed Principle (OCP)

The system is open for extension but closed for modification:

- New room types can be added without modifying existing code
- New random number generators can be implemented without changing the core logic
- Board building strategies can be extended through the interface

### Liskov Substitution Principle (LSP)

All implementations can be substituted for their interfaces:

- Any `IRandomNumberGenerator` implementation can replace another
- Any `IRoomFactory` implementation works with the system
- Interfaces define clear contracts that implementations must follow

### Interface Segregation Principle (ISP)

Interfaces are small and focused:

- `IDungeonGenerator`: Single method for generation
- `IRoomFactory`: Only room creation methods
- `ICorridorFactory`: Only corridor creation methods
- `IBoardBuilder`: Only board-related operations

### Dependency Inversion Principle (DIP)

High-level modules depend on abstractions, not concretions:

- `DungeonGenerator` depends on interfaces (`IRoomFactory`, `ICorridorFactory`, `IBoardBuilder`)
- `CorridorFactory` depends on `IRandomNumberGenerator`, not a concrete implementation
- Dependencies are injected through constructors

## Architecture Layers

### 1. Models Layer

Contains data structures and value objects:

- `DungeonData`: Complete dungeon information
- `RoomData`: Room information (immutable struct)
- `CorridorData`: Corridor information (immutable struct)
- `DungeonConfiguration`: Configuration settings
- `Position`: 2D coordinate (immutable struct)
- `Dimensions`: Size information (immutable struct)
- `BoardSquare`: Single square on the board
- `BoardSquareType`: Enumeration of square types
- `Direction`: Enumeration of directions

### 2. Interfaces Layer

Defines contracts for services:

- `IDungeonGenerator`
- `IRoomFactory`
- `ICorridorFactory`
- `IBoardBuilder`
- `IRandomNumberGenerator`

### 3. Services Layer

Implements business logic:

- `DungeonGenerator`: Main generation orchestrator
- `RoomFactory`: Room creation implementation
- `CorridorFactory`: Corridor creation implementation
- `BoardBuilder`: Board construction implementation
- `CryptoRandomNumberGenerator`: Secure random number generation

### 4. Helpers Layer

Provides utility functions:

- `DirectionHelper`: Direction-related operations
- `BoardSquareTypeHelper`: Square type classification

### 5. Facade Layer

Simplifies client interaction:

- `Dungeon`: Main entry point for dungeon generation

## Data Flow

```
Client
  ↓
Dungeon (Facade)
  ↓
DungeonGenerator
  ↓
  ├─→ RoomFactory → RoomData
  ├─→ CorridorFactory → CorridorData
  └─→ BoardBuilder → BoardSquare[,]
  ↓
DungeonData (returned to client)
```

## Key Design Decisions

### Immutability

- Value types like `RoomData`, `CorridorData`, `Position`, and `Dimensions` are immutable
- Prevents accidental modifications
- Makes the code thread-safe
- Improves predictability

### Dependency Injection

- All dependencies are injected through constructors
- No singleton pattern (as requested)
- Improves testability and flexibility

### Clear Separation of Concerns

- Data structures separated from behavior
- Validation logic centralized in configuration
- Helper classes for cross-cutting concerns

### Testability

- Interface-based design enables easy mocking
- Pure functions in helpers simplify testing
- Clear separation enables unit testing of individual components

## Extension Points

The architecture supports extension in several ways:

1. **New Room Types**: Implement new creation methods in `IRoomFactory`
2. **New Board Building Strategies**: Implement `IBoardBuilder` with different algorithms
3. **Different Random Strategies**: Implement `IRandomNumberGenerator`
4. **New Square Types**: Add to `BoardSquareType` enum and update helpers
5. **Post-Processing**: Add new services that operate on `DungeonData`

## Performance Considerations

- Structs for small, frequently-created objects (`Position`, `Dimensions`)
- Minimal allocations during generation
- Efficient array-based board representation
- Readonly structs prevent defensive copying

The system is organized into several layers:

```
┌─────────────────────────────────────────────────────────┐
│                    Presentation Layer                    │
│                  (Dungeon Class - Facade)                │
└────────────────────┬────────────────────────────────────┘
                     │
┌────────────────────▼────────────────────────────────────┐
│                     Service Layer                        │
│  ┌──────────────┐  ┌──────────────┐  ┌──────────────┐  │
│  │   Dungeon    │  │     Room     │  │   Corridor   │  │
│  │  Generator   │  │   Factory    │  │   Factory    │  │
│  └──────────────┘  └──────────────┘  └──────────────┘  │
│  ┌──────────────┐  ┌──────────────────────────────────┐ │
│  │    Board     │  │        Random Number            │ │
│  │   Builder    │  │         Generator               │ │
│  └──────────────┘  └──────────────────────────────────┘ │
└────────────────────┬────────────────────────────────────┘
                     │
┌────────────────────▼────────────────────────────────────┐
│                     Model Layer                          │
│  ┌──────────────┐  ┌──────────────┐  ┌──────────────┐  │
│  │  DungeonData │  │   RoomData   │  │ CorridorData │  │
│  └──────────────┘  └──────────────┘  └──────────────┘  │
│  ┌──────────────┐  ┌──────────────┐                    │
│  │ BoardSquare  │  │Configuration │                    │
│  └──────────────┘  └──────────────┘                    │
└─────────────────────────────────────────────────────────┘
```

## Design Patterns

### 1. Factory Pattern
**Used in:** `RoomFactory`, `CorridorFactory`

The Factory pattern is used to encapsulate the creation logic for rooms and corridors. This allows for:
- Easy addition of new room/corridor types
- Centralized creation logic
- Better testability

```csharp
// Example usage
IRoomFactory roomFactory = new RoomFactory();
RoomData firstRoom = roomFactory.CreateFirstRoom(75, 75, 8, 8);
```

### 2. Builder Pattern
**Used in:** `BoardBuilder`

The Builder pattern constructs complex board structures step by step:
- Creates empty boards
- Places rooms and corridors
- Generates walls and corners

```csharp
// Example usage
IBoardBuilder boardBuilder = new BoardBuilder();
BoardSquare[,] board = boardBuilder.CreateEmptyBoard(150, 150);
boardBuilder.PlaceRooms(board, rooms);
boardBuilder.GenerateWallsAndCorners(board);
```

### 3. Facade Pattern
**Used in:** `DungeonGenerator`

The Facade pattern provides a simple interface to the complex dungeon generation subsystem:

```csharp
// Simple interface hides complexity
IDungeonGenerator generator = new DungeonGenerator(config, roomFactory, corridorFactory, boardBuilder);
DungeonData dungeon = generator.Generate();
```

### 4. Strategy Pattern
**Used in:** `IRandomNumberGenerator`

The Strategy pattern allows different random number generation strategies:
- Cryptographic random for production
- Deterministic random for testing

### 5. Dependency Injection
All services receive their dependencies through constructors, enabling:
- Easy testing with mocks
- Loose coupling
- Better maintainability

## Core Components

### Models (Data Layer)

#### DungeonData
The complete representation of a generated dungeon.

**Properties:**
- `Board`: 2D array of board squares
- `Rooms`: Read-only list of rooms
- `Corridors`: Read-only list of corridors
- `Width`: Board width
- `Height`: Board height

#### RoomData (Immutable Struct)
Represents a single room in the dungeon.

**Properties:**
- `XPos`, `YPos`: Position on the board
- `Width`, `Height`: Dimensions
- `Direction`: Entry direction
- `IsBossRoom`: Boss room flag

#### CorridorData (Immutable Struct)
Represents a corridor connecting rooms.

**Properties:**
- `XPos`, `YPos`: Position on the board
- `Width`, `Height`: Dimensions
- `Direction`: Corridor direction

#### DungeonConfiguration
Configuration parameters for dungeon generation.

**Key Settings:**
- Board dimensions
- Number of rooms
- Room sizes (first, standard, boss)
- Corridor dimensions

### Services (Business Logic Layer)

#### DungeonGenerator
Main orchestrator for dungeon generation.

**Responsibilities:**
- Coordinate all generation steps
- Manage the generation pipeline
- Return complete dungeon data

**Key Method:**
```csharp
DungeonData Generate()
```

#### RoomFactory
Creates rooms based on specifications.

**Key Methods:**
```csharp
RoomData CreateFirstRoom(int x, int y, int w, int h)
RoomData CreateRoom(int w, int h, CorridorData corridor)
RoomData CreateBossRoom(int w, int h, CorridorData corridor)
```

#### CorridorFactory
Creates corridors connecting rooms.

**Key Methods:**
```csharp
CorridorData CreateFirstCorridor(int w, int h, RoomData room)
CorridorData CreateCorridor(int w, int h, RoomData room)
```

#### BoardBuilder
Constructs the physical board representation.

**Key Methods:**
```csharp
BoardSquare[,] CreateEmptyBoard(int w, int h)
void PlaceRooms(BoardSquare[,] board, IReadOnlyList<RoomData> rooms)
void PlaceCorridors(BoardSquare[,] board, IReadOnlyList<CorridorData> corridors)
void GenerateWallsAndCorners(BoardSquare[,] board)
```

#### CryptoRandomNumberGenerator
Provides cryptographically secure random numbers.

**Key Methods:**
```csharp
int Next(int minValue, int maxValue)
int Next(int maxValue)
byte NextByte()
```

## Usage Examples

### Basic Usage

```csharp
// 1. Create configuration
var config = new DungeonConfiguration
{
    BoardWidth = 150,
    BoardHeight = 150,
    NumberOfRooms = 4,
    FirstRoomWidth = 8,
    FirstRoomHeight = 8,
    RoomWidth = 5,
    RoomHeight = 5,
    BossRoomWidth = 7,
    BossRoomHeight = 7,
    CorridorWidth = 4,
    CorridorHeight = 4
};

// 2. Create dependencies
IRandomNumberGenerator rng = new CryptoRandomNumberGenerator();
IRoomFactory roomFactory = new RoomFactory();
ICorridorFactory corridorFactory = new CorridorFactory(rng);
IBoardBuilder boardBuilder = new BoardBuilder();

// 3. Create generator
IDungeonGenerator generator = new DungeonGenerator(
    config, 
    roomFactory, 
    corridorFactory, 
    boardBuilder);

// 4. Generate dungeon
DungeonData dungeon = generator.Generate();

// 5. Use the dungeon
Console.WriteLine($"Generated dungeon: {dungeon.Width}x{dungeon.Height}");
Console.WriteLine($"Rooms: {dungeon.Rooms.Count}");
Console.WriteLine($"Corridors: {dungeon.Corridors.Count}");
```

### Custom Configuration

```csharp
// Create a larger dungeon with more rooms
var customConfig = new DungeonConfiguration(
    boardWidth: 200,
    boardHeight: 200,
    numberOfRooms: 8,
    firstRoomWidth: 10,
    firstRoomHeight: 10,
    roomWidth: 6,
    roomHeight: 6,
    bossRoomWidth: 12,
    bossRoomHeight: 12,
    corridorWidth: 5,
    corridorHeight: 5
);

var dungeon = new DungeonGenerator(customConfig, roomFactory, corridorFactory, boardBuilder)
    .Generate();
```

### Testing with Mock Random Generator

```csharp
// Create a predictable random generator for testing
public class MockRandomGenerator : IRandomNumberGenerator
{
    private int _value;
    
    public int Next(int minValue, int maxValue) => _value;
    public int Next(int maxValue) => _value;
    public byte NextByte() => (byte)_value;
    
    public void SetValue(int value) => _value = value;
}

// Use in tests
var mockRng = new MockRandomGenerator();
mockRng.SetValue(1); // Always return Direction.North
var corridorFactory = new CorridorFactory(mockRng);
```

## Benefits of This Architecture

1. **Testability**: All components can be tested in isolation
2. **Maintainability**: Clear separation of concerns
3. **Extensibility**: Easy to add new features
4. **Readability**: Clean, well-documented code
5. **Reliability**: Immutable data structures prevent bugs
6. **Flexibility**: Configurable generation parameters

## Next Steps

- Implement additional room types
- Add dungeon themes
- Implement room connections validation
- Add obstacle generation
- Implement treasure placement algorithms

