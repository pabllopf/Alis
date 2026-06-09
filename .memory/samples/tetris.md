---
title: Tetris
tags:
  - sample
  - game
  - example

status: draft
---


## Overview

| Property | Value |
|----------|-------|
| **Genre** | Puzzle |
| **Platforms** | Desktop, Web |
| **Features** | Grid, rotation, line clearing |

## Description

Classic Tetris game with modern features including hold piece, next piece preview, ghost piece, and scoring system.

## Gameplay

- Rotate and place falling tetrominoes
- Complete horizontal lines to clear them
- Clear multiple lines for bonus points
- Game speeds up as level increases
- Game over when pieces stack to top

## Architecture

```
Tetris/
├── Program.cs
├── TetrisGame.cs
├── States/
│   ├── MenuState.cs
│   ├── PlayState.cs
│   ├── PauseState.cs
│   └── GameOverState.cs
├── Components/
│   ├── BoardComponent.cs
│   ├── PieceComponent.cs
│   ├── ScoreComponent.cs
│   └── GameConfig.cs
├── Systems/
│   ├── InputSystem.cs
│   ├── MovementSystem.cs
│   ├── RotationSystem.cs
│   ├── CollisionSystem.cs
│   ├── LineClearSystem.cs
│   └── ScoringSystem.cs
└── Content/
    └── Sprites/
```

## Key Components

### Board Component

```csharp
public struct BoardComponent
{
    public Cell[,] Grid;
    public int Width;
    public int Height;
    public int VisibleHeight; // Top rows hidden
}

public struct Cell
{
    public bool IsOccupied;
    public Color Color;
}
```

### Piece Component

```csharp
public struct PieceComponent
{
    public TetrominoType Type;
    public int[,] Shape;
    public int Rotation;
    public Vector2 Position;
    public Color Color;
}

public enum TetrominoType
{
    I, O, T, S, Z, J, L
}
```

### Score Component

```csharp
public struct ScoreComponent
{
    public int Score;
    public int Level;
    public int LinesCleared;
    public int Combo;
    public int HighScore;
}
```

## Tetromino Shapes

| Type | Shape | Color |
|------|-------|-------|
| I | ████ | Cyan |
| O | ██<br>██ | Yellow |
| T | ███<br> █ | Purple |
| S | ██<br>██ | Green |
| Z | ██<br>██ | Red |
| J | █<br>███ | Blue |
| L | █<br>███ | Orange |

## Board Logic

```csharp
public class BoardSystem : ISystem
{
    public void Update(IWorld world, float deltaTime)
    {
        var board = world.GetSingleton<BoardComponent>();
        var piece = world.GetSingleton<PieceComponent>();
        
        // Move piece down
        piece.Position.Y += 1;
        
        // Check collision
        if (CheckCollision(board, piece))
        {
            // Lock piece
            LockPiece(board, piece);
            
            // Clear lines
            int linesCleared = ClearLines(board);
            
            // Update score
            var score = world.GetSingleton<ScoreComponent>();
            UpdateScore(score, linesCleared);
            
            // Spawn new piece
            SpawnNewPiece(piece);
            
            // Check game over
            if (CheckGameOver(board, piece))
            {
                GameOver(world);
            }
        }
    }
    
    private bool CheckCollision(BoardComponent board, PieceComponent piece)
    {
        for (int y = 0; y < piece.Shape.GetLength(0); y++)
        {
            for (int x = 0; x < piece.Shape.GetLength(1); x++)
            {
                if (piece.Shape[y, x] == 1)
                {
                    int boardX = (int)piece.Position.X + x;
                    int boardY = (int)piece.Position.Y + y;
                    
                    // Check bounds
                    if (boardX < 0 || boardX >= board.Width ||
                        boardY >= board.Height)
                    {
                        return true;
                    }
                    
                    // Check occupied cells
                    if (boardY >= 0 && board.Grid[boardX, boardY].IsOccupied)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
    
    private int ClearLines(BoardComponent board)
    {
        int linesCleared = 0;
        
        for (int y = board.Height - 1; y >= 0; y--)
        {
            bool lineFull = true;
            for (int x = 0; x < board.Width; x++)
            {
                if (!board.Grid[x, y].IsOccupied)
                {
                    lineFull = false;
                    break;
                }
            }
            
            if (lineFull)
            {
                // Remove line
                for (int yy = y; yy > 0; yy--)
                {
                    for (int x = 0; x < board.Width; x++)
                    {
                        board.Grid[x, yy] = board.Grid[x, yy - 1];
                    }
                }
                
                // Clear top line
                for (int x = 0; x < board.Width; x++)
                {
                    board.Grid[x, 0] = new Cell();
                }
                
                linesCleared++;
                y++; // Check same row again
            }
        }
        
        return linesCleared;
    }
}
```

## Rotation System

```csharp
public class RotationSystem : ISystem
{
    public void Rotate(IWorld world, bool clockwise)
    {
        var piece = world.GetSingleton<PieceComponent>();
        var board = world.GetSingleton<BoardComponent>();
        
        int[,] rotatedShape = RotateShape(piece.Shape, clockwise);
        
        // Try basic rotation
        PieceComponent rotated = piece;
        rotated.Shape = rotatedShape;
        rotated.Rotation = (rotated.Rotation + (clockwise ? 1 : 3)) % 4;
        
        if (!CheckCollision(board, rotated))
        {
            piece.Shape = rotatedShape;
            piece.Rotation = rotated.Rotation;
            return;
        }
        
        // Wall kick tests
        Vector2[] kicks = GetWallKicks(piece.Type, piece.Rotation, rotated.Rotation);
        foreach (var kick in kicks)
        {
            rotated.Position = piece.Position + kick;
            if (!CheckCollision(board, rotated))
            {
                piece.Shape = rotatedShape;
                piece.Rotation = rotated.Rotation;
                piece.Position = rotated.Position;
                return;
            }
        }
    }
    
    private int[,] RotateShape(int[,] shape, bool clockwise)
    {
        int size = shape.GetLength(0);
        int[,] rotated = new int[size, size];
        
        for (int y = 0; y < size; y++)
        {
            for (int x = 0; x < size; x++)
            {
                if (clockwise)
                {
                    rotated[x, size - 1 - y] = shape[y, x];
                }
                else
                {
                    rotated[size - 1 - x, y] = shape[y, x];
                }
            }
        }
        
        return rotated;
    }
}
```

## Scoring

| Action | Points |
|--------|--------|
| Single line | 100 × level |
| Double | 300 × level |
| Triple | 500 × level |
| Tetris (4 lines) | 800 × level |
| Soft drop | 1 per cell |
| Hard drop | 2 per cell |
| Combo | 50 × combo × level |

## Level Speed

| Level | Frames per cell |
|-------|-----------------|
| 1 | 48 |
| 2 | 43 |
| 3 | 38 |
| 4 | 33 |
| 5 | 28 |
| 10 | 18 |
| 15 | 10 |
| 20 | 5 |

## Controls

| Input | Action |
|-------|--------|
| Left/Right Arrow | Move piece |
| Up Arrow | Rotate clockwise |
| Z | Rotate counter-clockwise |
| Down Arrow | Soft drop |
| Space | Hard drop |
| C | Hold piece |
| Escape | Pause |

## Features

- **Hold Piece**: Store one piece for later use
- **Next Piece Preview**: See next 3 pieces
- **Ghost Piece**: Shows where piece will land
- **Hard Drop**: Instantly drop piece
- **Soft Drop**: Faster falling

## Related

- [[samples/index|Samples Index]]
- [[samples/snake|Snake Sample]]
- [[samples/breakout|Breakout Sample]]
