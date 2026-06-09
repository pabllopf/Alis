---
title: Snake
tags:
  - sample
  - game
  - example

status: Draft

license: GPLv3

---


## Overview

| Property | Value |
|----------|-------|
| **Genre** | Arcade |
| **Platforms** | Desktop, Web |
| **Features** | Grid movement, growth |

## Description

Classic snake game where you guide a growing snake to eat food while avoiding walls and yourself. Features multiple difficulty levels and game modes.

## Gameplay

- Control snake direction with arrow keys
- Eat food to grow longer
- Avoid hitting walls or yourself
- Score increases with each food eaten
- Game speeds up as snake grows

## Architecture

```
Snake/
├── Program.cs
├── SnakeGame.cs
├── States/
│   ├── MenuState.cs
│   ├── PlayState.cs
│   ├── PauseState.cs
│   └── GameOverState.cs
├── Components/
│   ├── BoardComponent.cs
│   ├── SnakeComponent.cs
│   ├── FoodComponent.cs
│   └── ScoreComponent.cs
├── Systems/
│   ├── InputSystem.cs
│   ├── MovementSystem.cs
│   ├── CollisionSystem.cs
│   └── GrowthSystem.cs
└── Content/
    └── Sprites/
```

## Key Components

### Board Component

```csharp
public struct BoardComponent
{
    public CellType[,] Grid;
    public int Width;
    public int Height;
    public int CellSize;
}

public enum CellType
{
    Empty,
    Wall,
    Snake,
    Food,
    PowerUp
}
```

### Snake Component

```csharp
public struct SnakeComponent
{
    public List<Vector2> Segments;
    public Vector2 Direction;
    public Vector2 NextDirection;
    public float MoveTimer;
    public float MoveInterval;
    public bool IsAlive;
    public bool IsInvincible;
}
```

### Food Component

```csharp
public struct FoodComponent
{
    public Vector2 Position;
    public FoodType Type;
    public int Points;
    public float Lifetime;
}

public enum FoodType
{
    Normal,
    Bonus,
    Speed,
    Slow,
    Invincible
}
```

## Movement System

```csharp
public class MovementSystem : ISystem
{
    public void Update(IWorld world, float deltaTime)
    {
        var snake = world.GetSingleton<SnakeComponent>();
        var board = world.GetSingleton<BoardComponent>();
        
        if (!snake.IsAlive) return;
        
        // Update move timer
        snake.MoveTimer += deltaTime;
        
        if (snake.MoveTimer >= snake.MoveInterval)
        {
            snake.MoveTimer = 0;
            
            // Update direction
            snake.Direction = snake.NextDirection;
            
            // Calculate new head position
            Vector2 newHead = snake.Segments[0] + snake.Direction;
            
            // Check wall collision
            if (newHead.X < 0 || newHead.X >= board.Width ||
                newHead.Y < 0 || newHead.Y >= board.Height)
            {
                Die(world);
                return;
            }
            
            // Check self collision
            if (snake.Segments.Contains(newHead))
            {
                Die(world);
                return;
            }
            
            // Check food collision
            var food = world.GetSingleton<FoodComponent>();
            if (newHead == food.Position)
            {
                EatFood(world, food);
            }
            else
            {
                // Remove tail
                snake.Segments.RemoveAt(snake.Segments.Count - 1);
            }
            
            // Add new head
            snake.Segments.Insert(0, newHead);
            
            // Update grid
            UpdateGrid(board, snake);
        }
    }
    
    private void EatFood(IWorld world, FoodComponent food)
    {
        var snake = world.GetSingleton<SnakeComponent>();
        var score = world.GetSingleton<ScoreComponent>();
        
        // Apply food effect
        switch (food.Type)
        {
            case FoodType.Normal:
                score.Score += 10;
                break;
                
            case FoodType.Bonus:
                score.Score += 50;
                break;
                
            case FoodType.Speed:
                snake.MoveInterval *= 0.9f;
                break;
                
            case FoodType.Slow:
                snake.MoveInterval *= 1.1f;
                break;
                
            case FoodType.Invincible:
                snake.IsInvincible = true;
                break;
        }
        
        // Spawn new food
        SpawnFood(world);
    }
}
```

## Input System

```csharp
public class InputSystem : ISystem
{
    public void Update(IWorld world, float deltaTime)
    {
        var snake = world.GetSingleton<SnakeComponent>();
        
        // Prevent 180-degree turns
        if (Input.IsKeyPressed(Keys.Up) && snake.Direction != Vector2.Down)
        {
            snake.NextDirection = Vector2.Up;
        }
        else if (Input.IsKeyPressed(Keys.Down) && snake.Direction != Vector2.Up)
        {
            snake.NextDirection = Vector2.Down;
        }
        else if (Input.IsKeyPressed(Keys.Left) && snake.Direction != Vector2.Right)
        {
            snake.NextDirection = Vector2.Left;
        }
        else if (Input.IsKeyPressed(Keys.Right) && snake.Direction != Vector2.Left)
        {
            snake.NextDirection = Vector2.Right;
        }
    }
}
```

## Food Spawning

```csharp
private void SpawnFood(IWorld world)
{
    var board = world.GetSingleton<BoardComponent>();
    var snake = world.GetSingleton<SnakeComponent>();
    var food = world.GetSingleton<FoodComponent>();
    
    // Find empty cells
    List<Vector2> emptyCells = new List<Vector2>();
    for (int x = 0; x < board.Width; x++)
    {
        for (int y = 0; y < board.Height; y++)
        {
            if (board.Grid[x, y] == CellType.Empty &&
                !snake.Segments.Contains(new Vector2(x, y)))
            {
                emptyCells.Add(new Vector2(x, y));
            }
        }
    }
    
    // Random position
    Vector2 foodPos = emptyCells[random.Next(emptyCells.Count)];
    
    // Random type (90% normal, 10% special)
    FoodType type = random.Next(10) == 0 ? 
        (FoodType)random.Next(1, 5) : FoodType.Normal;
    
    food.Position = foodPos;
    food.Type = type;
    food.Points = type == FoodType.Normal ? 10 : 50;
    food.Lifetime = type == FoodType.Normal ? -1 : 10; // Special food disappears
}
```

## Game Modes

| Mode | Description |
|------|-------------|
| Classic | Traditional snake game |
| Speed | Starts fast, gets faster |
| Maze | Walls and obstacles |
| Portal | Teleport portals |

## Power-ups

| Power-up | Effect | Duration |
|----------|--------|----------|
| Speed | Increase speed | 5 seconds |
| Slow | Decrease speed | 5 seconds |
| Invincible | Pass through walls/self | 10 seconds |
| Double Points | 2x score | 15 seconds |

## Scoring

| Action | Points |
|--------|--------|
| Normal food | 10 |
| Bonus food | 50 |
| Speed food | 25 |
| Slow food | 25 |
| Invincible food | 100 |
| Length bonus | 5 × length |

## Difficulty Levels

| Level | Speed | Walls | Obstacles |
|-------|-------|-------|-----------|
| Easy | Slow | Yes | No |
| Medium | Medium | Yes | Few |
| Hard | Fast | Yes | Many |
| Insane | Very Fast | Wrap | Many |

## Controls

| Input | Action |
|-------|--------|
| Arrow Keys | Change direction |
| Space | Pause |
| Escape | Return to menu |

## Related

- [[samples/index|Samples Index]]
- [[samples/tetris|Tetris Sample]]
- [[samples/pac-man|Pac-Man Sample]]
