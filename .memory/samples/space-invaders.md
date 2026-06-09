---
title: Sample: Space Invaders
tags: [sample,game,example]
---


## Overview

| Property | Value |
|----------|-------|
| **Genre** | Shooter |
| **Platforms** | Desktop, Web |
| **Features** | Enemies, waves, shields |

## Description

Classic Space Invaders game with rows of alien enemies that move and shoot. Features shields, power-ups, and increasing difficulty.

## Gameplay

- Move ship left/right
- Shoot to destroy aliens
- Aliens move side-to-side and down
- Destroy all aliens to advance
- Protect shields from alien fire

## Architecture

```
SpaceInvaders/
├── Program.cs
├── SpaceInvadersGame.cs
├── States/
│   ├── MenuState.cs
│   ├── PlayState.cs
│   ├── PauseState.cs
│   └── GameOverState.cs
├── Components/
│   ├── PlayerComponent.cs
│   ├── AlienComponent.cs
│   ├── ProjectileComponent.cs
│   ├── ShieldComponent.cs
│   └── ScoreComponent.cs
├── Systems/
│   ├── InputSystem.cs
│   ├── MovementSystem.cs
│   ├── ShootingSystem.cs
│   ├── CollisionSystem.cs
│   ├── WaveSystem.cs
│   └── AlienAISystem.cs
└── Content/
    └── Sprites/
```

## Key Components

### Player Component

```csharp
public struct PlayerComponent
{
    public float MoveSpeed;
    public float FireRate;
    public float FireCooldown;
    public int Lives;
    public bool IsInvincible;
    public float InvincibleTimer;
}
```

### Alien Component

```csharp
public struct AlienComponent
{
    public AlienType Type;
    public int Health;
    public int Points;
    public float MoveSpeed;
    public float ShootChance;
    public AlienRow Row;
}

public enum AlienType
{
    Squid,    // Top row - 30 points
    Crab,     // Middle rows - 20 points
    Octopus   // Bottom rows - 10 points
}

public enum AlienRow
{
    Top,
    Middle,
    Bottom
}
```

### Shield Component

```csharp
public struct ShieldComponent
{
    public bool[,] Pixels;
    public int Width;
    public int Height;
    public int Health;
}
```

## Alien AI System

```csharp
public class AlienAISystem : ISystem
{
    private float moveTimer = 0;
    private float moveInterval = 1.0f;
    private int moveDirection = 1;
    
    public void Update(IWorld world, float deltaTime)
    {
        var aliens = world.GetEntitiesWith<AlienComponent, TransformComponent>();
        
        moveTimer += deltaTime;
        
        if (moveTimer >= moveInterval)
        {
            moveTimer = 0;
            
            // Check bounds
            bool hitEdge = false;
            foreach (var alien in aliens)
            {
                ref var transform = ref alien.Get<TransformComponent>();
                if ((transform.Position.X >= ScreenWidth - 50 && moveDirection > 0) ||
                    (transform.Position.X <= 50 && moveDirection < 0))
                {
                    hitEdge = true;
                    break;
                }
            }
            
            if (hitEdge)
            {
                // Move down and reverse direction
                foreach (var alien in aliens)
                {
                    ref var transform = ref alien.Get<TransformComponent>();
                    transform.Position.Y += 20;
                }
                moveDirection *= -1;
            }
            else
            {
                // Move horizontally
                foreach (var alien in aliens)
                {
                    ref var transform = ref alien.Get<TransformComponent>();
                    transform.Position.X += moveDirection * 20;
                }
            }
            
            // Increase speed as aliens are destroyed
            int alienCount = aliens.Count();
            moveInterval = Math.Max(0.1f, 1.0f * (alienCount / 55.0f));
        }
        
        // Alien shooting
        foreach (var alien in aliens)
        {
            ref var alienComp = ref alien.Get<AlienComponent>();
            ref var transform = ref alien.Get<TransformComponent>();
            
            if (Random.NextFloat() < alienComp.ShootChance * deltaTime)
            {
                SpawnAlienProjectile(world, transform.Position, alienComp.Type);
            }
        }
    }
}
```

## Shield System

```csharp
public class ShieldSystem : ISystem
{
    public void Update(IWorld world, float deltaTime)
    {
        var shields = world.GetEntitiesWith<ShieldComponent>();
        var projectiles = world.GetEntitiesWith<ProjectileComponent>();
        
        foreach (var shieldEntity in shields)
        {
            ref var shield = ref shieldEntity.Get<ShieldComponent>();
            ref var shieldTransform = ref shieldEntity.Get<TransformComponent>();
            
            foreach (var projEntity in projectiles)
            {
                ref var proj = ref projEntity.Get<ProjectileComponent>();
                ref var projTransform = ref projEntity.Get<TransformComponent>();
                
                // Check if projectile hits shield
                if (CheckShieldCollision(shield, shieldTransform, projTransform))
                {
                    // Damage shield pixels
                    DamageShield(shield, projTransform.Position, shieldTransform.Position);
                    
                    // Destroy projectile
                    projEntity.Destroy();
                    break;
                }
            }
        }
    }
    
    private void DamageShield(ShieldComponent shield, Vector2 hitPos, Vector2 shieldPos)
    {
        int localX = (int)(hitPos.X - shieldPos.X);
        int localY = (int)(hitPos.Y - shieldPos.Y);
        
        // Destroy pixels in radius
        int radius = 3;
        for (int y = -radius; y <= radius; y++)
        {
            for (int x = -radius; x <= radius; x++)
            {
                int px = localX + x;
                int py = localY + y;
                
                if (px >= 0 && px < shield.Width &&
                    py >= 0 && py < shield.Height)
                {
                    if (x * x + y * y <= radius * radius)
                    {
                        shield.Pixels[px, py] = false;
                    }
                }
            }
        }
    }
}
```

## Wave System

```csharp
public class WaveSystem : ISystem
{
    private int currentWave = 0;
    
    public void Update(IWorld world, float deltaTime)
    {
        var aliens = world.GetEntitiesWith<AlienComponent>();
        
        // Check if wave complete
        if (aliens.Count() == 0)
        {
            currentWave++;
            SpawnWave(world, currentWave);
        }
    }
    
    private void SpawnWave(IWorld world, int wave)
    {
        int rows = 5;
        int columns = 11;
        
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                var alien = world.CreateEntity();
                
                AlienType type = row switch
                {
                    0 => AlienType.Squid,
                    1 or 2 => AlienType.Crab,
                    _ => AlienType.Octopus
                };
                
                int health = type switch
                {
                    AlienType.Squid => 1 + (wave / 5),
                    AlienType.Crab => 1 + (wave / 3),
                    AlienType.Octopus => 1 + (wave / 2),
                    _ => 1
                };
                
                alien.Set(new AlienComponent
                {
                    Type = type,
                    Health = health,
                    Points = GetPoints(type),
                    MoveSpeed = 1.0f + (wave * 0.1f),
                    ShootChance = 0.01f + (wave * 0.002f),
                    Row = (AlienRow)row
                });
                
                alien.Set(new TransformComponent
                {
                    Position = new Vector2(
                        100 + col * 60,
                        100 + row * 50
                    )
                });
            }
        }
    }
}
```

## Alien Types

| Type | Row | Points | Health | Special |
|------|-----|--------|--------|---------|
| Squid | Top | 30 | 1 | Rare shooter |
| Crab | Middle | 20 | 1 | Medium shooter |
| Octopus | Bottom | 10 | 1 | Frequent shooter |

## Power-ups

| Power-up | Effect | Drop Source |
|----------|--------|-------------|
| Extra Life | +1 life | Rare alien |
| Triple Shot | 3-way fire | Random |
| Speed Boost | 2x fire rate | Random |
| Shield | Temporary invincibility | Random |

## Scoring

| Alien Type | Points |
|------------|--------|
| Squid | 30 |
| Crab | 20 |
| Octopus | 10 |
| Bonus UFO | 100-300 |

## Shields

- 4 shields at start
- Each pixel can be destroyed
- Regenerate between waves
- Different shapes per version

## Controls

| Input | Action |
|-------|--------|
| Left/Right Arrow | Move ship |
| Space | Shoot |
| P | Pause |
| Escape | Menu |

## Related

- [[samples/index|Samples Index]]
- [[samples/shooter|Shooter Sample]]
- [[samples/asteroids|Asteroids Sample]]
