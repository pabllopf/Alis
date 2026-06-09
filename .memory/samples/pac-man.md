# Sample: Pac-Man

## Overview

| Property | Value |
|----------|-------|
| **Genre** | Maze |
| **Platforms** | Desktop, Web |
| **Features** | AI, mazes, collectibles |

## Description

Classic Pac-Man game with ghost AI, maze navigation, and power pellets. Features authentic ghost behavior and multiple levels.

## Gameplay

- Navigate maze eating dots
- Avoid ghosts or eat them with power pellets
- Clear all dots to advance
- Score points for dots and ghosts
- Extra lives at 10,000 points

## Architecture

```
PacMan/
├── Program.cs
├── PacManGame.cs
├── States/
│   ├── MenuState.cs
│   ├── PlayState.cs
│   ├── PauseState.cs
│   └── GameOverState.cs
├── Components/
│   ├── PacManComponent.cs
│   ├── GhostComponent.cs
│   ├── MazeComponent.cs
│   └── ScoreComponent.cs
├── Systems/
│   ├── InputSystem.cs
│   ├── MovementSystem.cs
│   ├── GhostAISystem.cs
│   ├── CollisionSystem.cs
│   └── PowerPelletSystem.cs
├── Maze/
│   └── maze.json
└── Content/
    └── Sprites/
```

## Key Components

### PacMan Component

```csharp
public struct PacManComponent
{
    public float MoveSpeed;
    public int Lives;
    public bool IsPoweredUp;
    public float PowerTimer;
    public PacManState State;
}

public enum PacManState
{
    Alive,
    Dying,
    Respawning
}
```

### Ghost Component

```csharp
public struct GhostComponent
{
    public GhostType Type;
    public GhostState State;
    public Vector2 HomePosition;
    public Vector2 ScatterTarget;
    public float MoveSpeed;
    public bool IsFrightened;
    public float FrightenedTimer;
}

public enum GhostType
{
    Blinky, // Red - chaser
    Pinky,  // Pink - ambusher
    Inky,   // Cyan - fickle
    Clyde   // Orange - random
}

public enum GhostState
{
    Scatter,
    Chase,
    Frightened,
    Eaten,
    Returning
}
```

### Maze Component

```csharp
public struct MazeComponent
{
    public MazeCell[,] Grid;
    public int Width;
    public int Height;
    public Vector2 PacManSpawn;
    public Vector2 GhostSpawn;
    public Vector2[] GhostHouse;
}

public enum MazeCell
{
    Empty,
    Wall,
    Dot,
    PowerPellet,
    GhostHouse,
    Tunnel
}
```

## Ghost AI System

```csharp
public class GhostAISystem : ISystem
{
    public void Update(IWorld world, float deltaTime)
    {
        var ghosts = world.GetEntitiesWith<GhostComponent, TransformComponent>();
        var pacMan = world.GetSingleton<PacManComponent>();
        var pacManTransform = world.GetSingleton<TransformComponent>();
        var maze = world.GetSingleton<MazeComponent>();
        
        foreach (var ghostEntity in ghosts)
        {
            ref var ghost = ref ghostEntity.Get<GhostComponent>();
            ref var transform = ref ghostEntity.Get<TransformComponent>();
            
            if (ghost.IsFrightened)
            {
                // Random movement when frightened
                MoveRandomly(ghost, transform, maze);
                
                ghost.FrightenedTimer -= deltaTime;
                if (ghost.FrightenedTimer <= 0)
                {
                    ghost.IsFrightened = false;
                    ghost.State = GhostState.Chase;
                }
            }
            else if (ghost.State == GhostState.Eaten)
            {
                // Return to ghost house
                MoveTowardsTarget(ghost, transform, ghost.HomePosition, maze);
                
                if (Vector2.Distance(transform.Position, ghost.HomePosition) < 10)
                {
                    ghost.State = GhostState.Scatter;
                }
            }
            else
            {
                // Normal AI based on type
                Vector2 target = GetTarget(ghost, pacMan, pacManTransform, ghosts);
                MoveTowardsTarget(ghost, transform, target, maze);
            }
        }
    }
    
    private Vector2 GetTarget(GhostComponent ghost, PacManComponent pacMan,
        TransformComponent pacManTransform, IEnumerable<Entity> ghosts)
    {
        return ghost.Type switch
        {
            GhostType.Blinky => pacManTransform.Position, // Direct chase
            
            GhostType.Pinky => pacManTransform.Position + 
                pacMan.Direction * 4 * maze.CellSize, // Ambush ahead
            
            GhostType.Inky => CalculateInkyTarget(ghost, pacManTransform, ghosts),
            
            GhostType.Clyde => Vector2.Distance(transform.Position, pacManTransform.Position) > 
                8 * maze.CellSize ? pacManTransform.Position : ghost.ScatterTarget,
            
            _ => pacManTransform.Position
        };
    }
    
    private Vector2 CalculateInkyTarget(GhostComponent ghost, 
        TransformComponent pacManTransform, IEnumerable<Entity> ghosts)
    {
        // Inky uses Blinky's position for targeting
        var blinky = ghosts.FirstOrDefault(e => 
            e.Get<GhostComponent>().Type == GhostType.Blinky);
        
        if (blinky == null) return pacManTransform.Position;
        
        Vector2 blinkyPos = blinky.Get<TransformComponent>().Position;
        Vector2 pivot = pacManTransform.Position + pacMan.Direction * 2 * maze.CellSize;
        
        return pivot + (pivot - blinkyPos);
    }
    
    private void MoveTowardsTarget(GhostComponent ghost, TransformComponent transform,
        Vector2 target, MazeComponent maze)
    {
        // Get possible directions
        List<Vector2> possibleDirections = GetPossibleDirections(transform.Position, maze);
        
        // Choose direction closest to target
        Vector2 bestDirection = possibleDirections[0];
        float bestDistance = float.MaxValue;
        
        foreach (var dir in possibleDirections)
        {
            Vector2 nextPos = transform.Position + dir * maze.CellSize;
            float dist = Vector2.Distance(nextPos, target);
            
            if (dist < bestDistance)
            {
                bestDistance = dist;
                bestDirection = dir;
            }
        }
        
        transform.Position += bestDirection * ghost.MoveSpeed * deltaTime;
    }
}
```

## Ghost Behaviors

| Ghost | Personality | Target Selection |
|-------|-------------|------------------|
| Blinky | Chaser | Directly targets Pac-Man |
| Pinky | Ambusher | Targets 4 tiles ahead of Pac-Man |
| Inky | Fickle | Uses Blinky's position to calculate target |
| Clyde | Random | Chases when far, scatters when close |

## Ghost States

| State | Behavior |
|-------|----------|
| Scatter | Moves to home corner |
| Chase | Uses targeting algorithm |
| Frightened | Random movement, vulnerable |
| Eaten | Returns to ghost house |

## Power Pellets

- 4 power pellets per maze
- Activate ghost frightened mode
- Duration decreases per level
- Score doubles for each ghost eaten
- Ghost score: 200, 400, 800, 1600

## Maze Layout

```
################
#..............#
#.#.##.###.##.#.#
#o..............o#
#.#.##.#.##.#.#.#
#......##......##
##.##.#....#.##.##
  #.#..##...#.#  
##.#.#.####.#.#.##
#......##......##
#.#.##.#.##.#.#.#
#o..............o#
#.#.##.###.##.#.#
#..............#
################
```

Legend:
- `#` = Wall
- `.` = Dot
- `o` = Power Pellet
- ` ` = Ghost house

## Scoring

| Action | Points |
|--------|--------|
| Dot | 10 |
| Power Pellet | 50 |
| Ghost 1 | 200 |
| Ghost 2 | 400 |
| Ghost 3 | 800 |
| Ghost 4 | 1600 |
| Fruit (cherry) | 100 |
| Extra Life | 10,000 |

## Levels

| Level | Speed | Frightened Time |
|-------|-------|-----------------|
| 1 | Slow | 6 seconds |
| 2 | Medium | 5 seconds |
| 3 | Fast | 4 seconds |
| 4+ | Very Fast | 3 seconds |

## Controls

| Input | Action |
|-------|--------|
| Arrow Keys | Change direction |
| P | Pause |
| Escape | Menu |

## Related

- [[samples/index|Samples Index]]
- [[samples/snake|Snake Sample]]
- [[samples/platformer|Platformer Sample]]
