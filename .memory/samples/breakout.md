---
title: Breakout
tags: [sample,game,example]
---


## Overview

| Property | Value |
|----------|-------|
| **Genre** | Arcade |
| **Platforms** | Desktop, Web |
| **Features** | Physics, collision, power-ups |

## Description

Classic breakout game where the player controls a paddle to bounce a ball and break bricks. Includes power-ups, multiple levels, and scoring system.

## Gameplay

- Control paddle with mouse or keyboard
- Ball bounces off paddle and walls
- Break all bricks to complete level
- Collect power-ups for special abilities
- Multiple lives system

## Power-ups

| Power-up | Effect | Duration |
|----------|--------|----------|
| Multi-ball | Splits into 3 balls | Until lost |
| Wide paddle | Paddle 2x wider | 10 seconds |
| Sticky paddle | Ball sticks to paddle | Next hit |
| Fireball | Ball destroys bricks without bouncing | 5 seconds |
| Extra life | Adds one life | Permanent |

## Architecture

```
Breakout/
├── Program.cs
├── BreakoutGame.cs
├── States/
│   ├── MenuState.cs
│   ├── PlayState.cs
│   ├── PauseState.cs
│   └── GameOverState.cs
├── Entities/
│   ├── Paddle.cs
│   ├── Ball.cs
│   ├── Brick.cs
│   └── PowerUp.cs
├── Systems/
│   ├── PhysicsSystem.cs
│   ├── CollisionSystem.cs
│   └── PowerUpSystem.cs
└── Content/
    ├── Sprites/
    └── Audio/
```

## Key Components

### Paddle Component

```csharp
public struct PaddleComponent
{
    public float Width;
    public float Speed;
    public bool IsSticky;
}
```

### Ball Component

```csharp
public struct BallComponent
{
    public Vector2 Velocity;
    public float Speed;
    public bool IsActive;
    public bool IsFireball;
}
```

### Brick Component

```csharp
public struct BrickComponent
{
    public int Health;
    public int Points;
    public BrickType Type;
    public PowerUpType? PowerUp;
}
```

## Physics System

```csharp
public class PhysicsSystem : ISystem
{
    public void Update(IWorld world, float deltaTime)
    {
        // Move ball
        var balls = world.GetEntitiesWith<BallComponent, TransformComponent>();
        foreach (var ball in balls)
        {
            ref var transform = ref ball.Get<TransformComponent>();
            ref var ballComp = ref ball.Get<BallComponent>();
            
            transform.Position += ballComp.Velocity * ballComp.Speed * deltaTime;
            
            // Wall collision
            if (transform.Position.X <= 0 || transform.Position.X >= ScreenWidth)
            {
                ballComp.Velocity.X *= -1;
            }
            if (transform.Position.Y <= 0)
            {
                ballComp.Velocity.Y *= -1;
            }
        }
    }
}
```

## Scoring

| Brick Color | Points |
|-------------|--------|
| Red | 100 |
| Orange | 75 |
| Yellow | 50 |
| Green | 25 |
| Blue | 10 |

## Levels

1. **Level 1**: Basic brick layout
2. **Level 2**: Indestructible bricks added
3. **Level 3**: Moving bricks
4. **Level 4**: Multiple balls from start
5. **Level 5**: Boss brick with high health

## Controls

| Input | Action |
|-------|--------|
| Mouse/Arrow Keys | Move paddle |
| Space | Launch ball |
| P | Pause game |
| Escape | Return to menu |

## Related

- [[samples/index|Samples Index]]
- [[samples/pong|Pong Sample]]
- [[architecture/repository-overview|Repository Overview]]
