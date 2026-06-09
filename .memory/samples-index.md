---
title: Game Samples Index
tags:
  - sample
  - game
  - example
lastUpdated: 2026-06-09

status: draft
---


## Overview

Alis provides 13 game samples demonstrating various game types and engine features. Each sample is available in both Desktop and Web (WASM) versions.

## Sample Games

| Game | Genre | Features Demonstrated | Desktop | Web |
|------|-------|----------------------|---------|-----|
| [[breakout\|Breakout]] | Arcade | Physics, collision, power-ups | ✅ | ✅ |
| [[pong\|Pong]] | Sports | 2-player, AI, physics | ✅ | ✅ |
| [[platformer\|Platformer]] | Action | Character controller, levels | ✅ | ✅ |
| [[shooter\|Shooter]] | Action | Projectiles, enemies, waves | ✅ | ✅ |
| [[rpg\|RPG]] | RPG | Inventory, dialogues, quests | ✅ | ✅ |
| [[tetris\|Tetris]] | Puzzle | Grid, rotation, line clearing | ✅ | ✅ |
| [[snake\|Snake]] | Arcade | Grid movement, growth | ✅ | ✅ |
| [[flappy-bird\|Flappy Bird]] | Arcade | Physics, obstacles | ✅ | ✅ |
| [[space-invaders\|Space Invaders]] | Shooter | Enemies, waves, shields | ✅ | ✅ |
| [[pac-man\|Pac-Man]] | Maze | AI, mazes, collectibles | ✅ | ✅ |
| [[asteroids\|Asteroids]] | Shooter | Rotation, thrust, splitting | ✅ | ✅ |
| [[breakout-3d\|Breakout 3D]] | Arcade | 3D physics, cameras | ✅ | ✅ |
| [[demo\|Demo]] | Demo | Engine features showcase | ✅ | ✅ |

## Platform Build Targets

### Desktop

```
Samples.Desktop/
├── Breakout.Desktop/
├── Pong.Desktop/
├── Platformer.Desktop/
├── Shooter.Desktop/
├── Rpg.Desktop/
├── Tetris.Desktop/
├── Snake.Desktop/
├── FlappyBird.Desktop/
├── SpaceInvaders.Desktop/
├── PacMan.Desktop/
├── Asteroids.Desktop/
├── Breakout3D.Desktop/
└── Demo.Desktop/
```

### Web (WASM)

```
Samples.Web/
├── Breakout.Web/
├── Pong.Web/
├── Platformer.Web/
├── Shooter.Web/
├── Rpg.Web/
├── Tetris.Web/
├── Snake.Web/
├── FlappyBird.Web/
├── SpaceInvaders.Web/
├── PacMan.Web/
├── Asteroids.Web/
├── Breakout3D.Web/
└── Demo.Web/
```

## Common Patterns

All samples follow these patterns:

1. **Entry Point**: `Program.cs` with `static void Main()`
2. **Game Class**: Inherits from `Game` or `Game<GameState>`
3. **State Management**: Uses `GameState` for scene management
4. **Input Handling**: Uses `InputManager` for keyboard/mouse/gamepad
5. **Rendering**: Uses `GraphicsManager` for 2D/3D rendering

## Sample Structure

```csharp
public class MyGame : Game<MyGameState>
{
    protected override void Initialize()
    {
        // Setup window, input, content
    }

    protected override void Update(GameTime gameTime)
    {
        // Game logic
    }

    protected override void Draw(GameTime gameTime)
    {
        // Rendering
    }
}
```

## Running Samples

### Desktop

```bash
# Run specific sample
dotnet run --project Samples.Desktop/Breakout.Desktop

# Run all samples
dotnet run --project Samples.Desktop
```

### Web (WASM)

```bash
# Build for Web
dotnet build Samples.Web/Breakout.Web -c Release

# Serve locally
dotnet serve -p 8080 -w Samples.Web/Breakout.Web/bin/Release/net8.0/browser-wasm/AppBundle
```

## Feature Coverage

| Feature | Games Using It |
|---------|----------------|
| 2D Sprites | All |
| Tilemaps | Platformer, RPG, Pac-Man |
| Physics | Breakout, Pong, Flappy Bird |
| Audio | All |
| UI | RPG, Demo |
| AI | Space Invaders, Pac-Man |
| Particles | Breakout, Shooter |
| Screen Effects | Demo |

## Related

- [[onboarding/getting-started|Getting Started]]
- [[architecture/repository-overview|Repository Overview]]
- [[applications-index|Applications Index]] - Engine and tools

## Cross-References

- [[applications-index|Applications Index]] - Game applications
- [[extensions-index|Extensions Index]] - Extensions used in samples
- [[concepts-index|Concepts Index]] - Patterns used in samples
