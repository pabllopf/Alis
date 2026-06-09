---
title: Platformer
tags:
  - sample
  - game
  - example

status: draft
---


## Overview

| Property | Value |
|----------|-------|
| **Genre** | Action |
| **Platforms** | Desktop, Web |
| **Features** | Character controller, levels, physics |

## Description

2D platformer featuring smooth character movement, multiple levels, enemies, and collectibles. Demonstrates tile-based level design and collision detection.

## Gameplay

- Run, jump, and dash through levels
- Defeat enemies with jump attacks
- Collect coins and power-ups
- Reach the flag at end of level
- Multiple worlds with unique themes

## Architecture

```
Platformer/
├── Program.cs
├── PlatformerGame.cs
├── States/
│   ├── MenuState.cs
│   ├── PlayState.cs
│   ├── PauseState.cs
│   └── LevelCompleteState.cs
├── Entities/
│   ├── Player.cs
│   ├── Enemy.cs
│   ├── Coin.cs
│   ├── PowerUp.cs
│   └── Flag.cs
├── Systems/
│   ├── PhysicsSystem.cs
│   ├── CollisionSystem.cs
│   ├── EnemyAISystem.cs
│   └── AnimationSystem.cs
├── Levels/
│   ├── Level1.tmx
│   ├── Level2.tmx
│   └── Level3.tmx
└── Content/
    ├── Tilesets/
    ├── Sprites/
    └── Audio/
```

## Key Components

### Player Component

```csharp
public struct PlayerComponent
{
    public float MoveSpeed;
    public float JumpForce;
    public float DashSpeed;
    public float DashDuration;
    public int Health;
    public int MaxHealth;
    public bool IsGrounded;
    public bool CanDoubleJump;
    public bool IsDashing;
    public float DashCooldown;
}
```

### Enemy Component

```csharp
public struct EnemyComponent
{
    public EnemyType Type;
    public float MoveSpeed;
    public int Health;
    public int Damage;
    public bool IsActive;
    public AIState State;
}

public enum EnemyType
{
    Walker,
    Flyer,
    Shooter,
    Boss
}

public enum AIState
{
    Patrol,
    Chase,
    Attack,
    Dead
}
```

### Tilemap Component

```csharp
public struct TilemapComponent
{
    public int[,] Tiles;
    public int TileSize;
    public int Width;
    public int Height;
}

public enum TileType
{
    Empty = 0,
    Ground = 1,
    Platform = 2,
    Spike = 3,
    Coin = 4,
    EnemySpawn = 5,
    PlayerSpawn = 6,
    Flag = 7
}
```

## Character Controller

```csharp
public class PlayerSystem : ISystem
{
    public void Update(IWorld world, float deltaTime)
    {
        var players = world.GetEntitiesWith<PlayerComponent, TransformComponent>();
        
        foreach (var player in players)
        {
            ref var transform = ref player.Get<TransformComponent>();
            ref var playerComp = ref player.Get<PlayerComponent>();
            
            // Horizontal movement
            float moveInput = Input.GetAxis("Horizontal");
            if (!playerComp.IsDashing)
            {
                transform.Velocity.X = moveInput * playerComp.MoveSpeed;
            }
            
            // Jump
            if (Input.IsButtonDown("Jump") && playerComp.IsGrounded)
            {
                transform.Velocity.Y = -playerComp.JumpForce;
                playerComp.IsGrounded = false;
            }
            
            // Double jump
            if (Input.IsButtonDown("Jump") && !playerComp.IsGrounded && 
                playerComp.CanDoubleJump)
            {
                transform.Velocity.Y = -playerComp.JumpForce * 0.8f;
                playerComp.CanDoubleJump = false;
            }
            
            // Dash
            if (Input.IsButtonDown("Dash") && playerComp.DashCooldown <= 0)
            {
                playerComp.IsDashing = true;
                playerComp.DashCooldown = 1.0f;
                transform.Velocity.X = Math.Sign(transform.Velocity.X) * playerComp.DashSpeed;
            }
            
            // Apply gravity
            if (!playerComp.IsGrounded)
            {
                transform.Velocity.Y += Gravity * deltaTime;
            }
            
            // Update cooldowns
            if (playerComp.DashCooldown > 0)
            {
                playerComp.DashCooldown -= deltaTime;
            }
        }
    }
}
```

## Collision Detection

```csharp
public class CollisionSystem : ISystem
{
    public void Update(IWorld world, float deltaTime)
    {
        var players = world.GetEntitiesWith<PlayerComponent, TransformComponent>();
        var tiles = world.GetSingleton<TilemapComponent>();
        
        foreach (var player in players)
        {
            ref var transform = ref player.Get<TransformComponent>();
            ref var playerComp = ref player.Get<PlayerComponent>();
            
            // Check tile collisions
            playerComp.IsGrounded = false;
            
            // Check horizontal collision
            if (CheckTileCollision(transform, tiles, Direction.Left) ||
                CheckTileCollision(transform, tiles, Direction.Right))
            {
                transform.Velocity.X = 0;
            }
            
            // Check vertical collision
            if (CheckTileCollision(transform, tiles, Direction.Top))
            {
                transform.Velocity.Y = 0;
                playerComp.IsGrounded = true;
                playerComp.CanDoubleJump = true;
            }
            
            if (CheckTileCollision(transform, tiles, Direction.Bottom))
            {
                transform.Velocity.Y = 0;
            }
            
            // Check hazard collision
            if (CheckTileCollision(transform, tiles, Direction.All))
            {
                var tile = GetTileAt(transform.Position, tiles);
                if (tile == TileType.Spike)
                {
                    DamagePlayer(player, 1);
                }
            }
        }
    }
}
```

## Enemy AI

```csharp
public class EnemyAISystem : ISystem
{
    public void Update(IWorld world, float deltaTime)
    {
        var enemies = world.GetEntitiesWith<EnemyComponent, TransformComponent>();
        var players = world.GetEntitiesWith<PlayerComponent, TransformComponent>();
        
        foreach (var enemy in enemies)
        {
            ref var transform = ref enemy.Get<TransformComponent>();
            ref var enemyComp = ref enemy.Get<EnemyComponent>();
            
            var player = players.First();
            ref var playerTransform = ref player.Get<TransformComponent>();
            
            float distanceToPlayer = Vector2.Distance(
                transform.Position, playerTransform.Position);
            
            switch (enemyComp.State)
            {
                case AIState.Patrol:
                    // Move back and forth
                    transform.Position.X += enemyComp.MoveSpeed * deltaTime * 
                        Math.Sign(transform.Scale.X);
                    
                    // Check for walls or edges
                    if (CheckWallCollision(transform) || CheckEdge(transform))
                    {
                        transform.Scale.X *= -1; // Reverse direction
                    }
                    
                    // Switch to chase if player is close
                    if (distanceToPlayer < DetectionRange)
                    {
                        enemyComp.State = AIState.Chase;
                    }
                    break;
                    
                case AIState.Chase:
                    // Move towards player
                    float direction = Math.Sign(playerTransform.Position.X - 
                        transform.Position.X);
                    transform.Position.X += enemyComp.MoveSpeed * 1.5f * deltaTime * direction;
                    
                    // Switch back to patrol if player is far
                    if (distanceToPlayer > DetectionRange * 1.5f)
                    {
                        enemyComp.State = AIState.Patrol;
                    }
                    break;
            }
        }
    }
}
```

## Level Themes

| World | Theme | Enemies | Hazards |
|-------|-------|---------|---------|
| 1 | Grassland | Walkers | Spikes, pits |
| 2 | Underground | Walkers, Shooters | Lava, moving platforms |
| 3 | Sky | Flyers | Wind, falling blocks |

## Controls

| Input | Action |
|-------|--------|
| A/D or Left/Right | Move |
| Space | Jump |
| Left Shift | Dash |
| Escape | Pause |

## Power-ups

| Power-up | Effect | Duration |
|----------|--------|----------|
| Speed Boost | 1.5x move speed | 10 seconds |
| Double Jump | Enable double jump | Level |
| Shield | Absorb one hit | Until hit |
| Magnet | Attract coins | 15 seconds |

## Related

- [[samples/index|Samples Index]]
- [[samples/shooter|Shooter Sample]]
- [[samples/rpg|RPG Sample]]
