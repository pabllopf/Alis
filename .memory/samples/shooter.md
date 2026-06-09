---
title: Shooter
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
| **Genre** | Action |
| **Platforms** | Desktop, Web |
| **Features** | Projectiles, enemies, waves |

## Description

Top-down shooter with waves of enemies, power-ups, and boss fights. Demonstrates projectile systems, enemy spawning, and score tracking.

## Gameplay

- Move player ship with WASD/arrow keys
- Aim and shoot with mouse
- Destroy enemies to earn points
- Collect power-ups for upgrades
- Survive increasingly difficult waves
- Fight boss every 5 waves

## Architecture

```
Shooter/
├── Program.cs
├── ShooterGame.cs
├── States/
│   ├── MenuState.cs
│   ├── PlayState.cs
│   ├── PauseState.cs
│   └── GameOverState.cs
├── Entities/
│   ├── Player.cs
│   ├── Enemy.cs
│   ├── Projectile.cs
│   ├── PowerUp.cs
│   └── Boss.cs
├── Systems/
│   ├── MovementSystem.cs
│   ├── ShootingSystem.cs
│   ├── EnemySpawnSystem.cs
│   ├── CollisionSystem.cs
│   └── WaveSystem.cs
└── Content/
    ├── Sprites/
    └── Audio/
```

## Key Components

### Player Component

```csharp
public struct PlayerComponent
{
    public float MoveSpeed;
    public int Health;
    public int MaxHealth;
    public int Score;
    public WeaponType CurrentWeapon;
    public float FireRate;
    public float FireCooldown;
}
```

### Enemy Component

```csharp
public struct EnemyComponent
{
    public EnemyType Type;
    public int Health;
    public int MaxHealth;
    public int Damage;
    public float MoveSpeed;
    public int Points;
    public AIState State;
}

public enum EnemyType
{
    Grunt,
    Fast,
    Tank,
    Shooter,
    Boss
}
```

### Projectile Component

```csharp
public struct ProjectileComponent
{
    public Vector2 Velocity;
    public int Damage;
    public float Lifetime;
    public bool IsPlayerProjectile;
    public ProjectileType Type;
}

public enum ProjectileType
{
    Normal,
    Spread,
    Homing,
    Piercing
}
```

## Wave System

```csharp
public class WaveSystem : ISystem
{
    private int currentWave = 0;
    private float waveTimer = 0;
    private bool waveActive = false;
    
    public void Update(IWorld world, float deltaTime)
    {
        var enemies = world.GetEntitiesWith<EnemyComponent>();
        var players = world.GetEntitiesWith<PlayerComponent>();
        
        // Check if wave is complete
        if (waveActive && enemies.Count() == 0)
        {
            waveActive = false;
            waveTimer = 3.0f; // Delay between waves
        }
        
        // Spawn new wave
        if (!waveActive && waveTimer <= 0)
        {
            currentWave++;
            SpawnWave(world, currentWave);
            waveActive = true;
        }
        
        // Update wave timer
        if (waveTimer > 0)
        {
            waveTimer -= deltaTime;
        }
    }
    
    private void SpawnWave(IWorld world, int wave)
    {
        int enemyCount = 5 + (wave * 2);
        bool isBossWave = wave % 5 == 0;
        
        if (isBossWave)
        {
            SpawnBoss(world, wave);
        }
        else
        {
            for (int i = 0; i < enemyCount; i++)
            {
                SpawnEnemy(world, GetRandomEnemyType(), wave);
            }
        }
    }
}
```

## Shooting System

```csharp
public class ShootingSystem : ISystem
{
    public void Update(IWorld world, float deltaTime)
    {
        var players = world.GetEntitiesWith<PlayerComponent, TransformComponent>();
        
        foreach (var player in players)
        {
            ref var playerComp = ref player.Get<PlayerComponent>();
            ref var transform = ref player.Get<TransformComponent>();
            
            // Update fire cooldown
            if (playerComp.FireCooldown > 0)
            {
                playerComp.FireCooldown -= deltaTime;
            }
            
            // Shoot if mouse button held and cooldown ready
            if (Input.IsMouseButtonHeld(MouseButton.Left) && playerComp.FireCooldown <= 0)
            {
                Vector2 mousePos = Input.GetMousePosition();
                Vector2 direction = Vector2.Normalize(mousePos - transform.Position);
                
                switch (playerComp.CurrentWeapon)
                {
                    case WeaponType.Normal:
                        SpawnProjectile(world, transform.Position, direction, 
                            damage: 10, speed: 500);
                        break;
                        
                    case WeaponType.Spread:
                        for (int i = -2; i <= 2; i++)
                        {
                            float angle = (float)Math.Atan2(direction.Y, direction.X) + 
                                i * 0.2f;
                            Vector2 spreadDir = new Vector2((float)Math.Cos(angle), 
                                (float)Math.Sin(angle));
                            SpawnProjectile(world, transform.Position, spreadDir, 
                                damage: 8, speed: 500);
                        }
                        break;
                        
                    case WeaponType.Homing:
                        var nearestEnemy = FindNearestEnemy(world, transform.Position);
                        if (nearestEnemy != null)
                        {
                            Vector2 homingDir = Vector2.Normalize(
                                nearestEnemy.Position - transform.Position);
                            SpawnProjectile(world, transform.Position, homingDir, 
                                damage: 15, speed: 400, type: ProjectileType.Homing);
                        }
                        break;
                }
                
                playerComp.FireCooldown = 1.0f / playerComp.FireRate;
            }
        }
    }
}
```

## Enemy Spawning

```csharp
public class EnemySpawnSystem : ISystem
{
    private Random random = new Random();
    
    public void Update(IWorld world, float deltaTime)
    {
        // Spawning handled by WaveSystem
    }
    
    public void SpawnEnemy(IWorld world, EnemyType type, int wave)
    {
        var enemy = world.CreateEntity();
        
        // Random spawn position (outside screen)
        Vector2 spawnPos = GetRandomSpawnPosition();
        
        enemy.Set(new TransformComponent
        {
            Position = spawnPos,
            Scale = Vector2.One
        });
        
        enemy.Set(new EnemyComponent
        {
            Type = type,
            Health = GetHealth(type, wave),
            MaxHealth = GetHealth(type, wave),
            Damage = GetDamage(type),
            MoveSpeed = GetSpeed(type),
            Points = GetPoints(type),
            State = AIState.Patrol
        });
        
        enemy.Set(new SpriteComponent
        {
            Texture = GetEnemyTexture(type)
        });
    }
}
```

## Weapons

| Weapon | Fire Rate | Damage | Special |
|--------|-----------|--------|---------|
| Normal | 5 shots/sec | 10 | None |
| Spread | 3 shots/sec | 8 | 5-way spread |
| Homing | 2 shots/sec | 15 | Seeks enemies |
| Piercing | 4 shots/sec | 12 | Goes through enemies |

## Power-ups

| Power-up | Effect | Duration |
|----------|--------|----------|
| Health | Restore 1 health | Permanent |
| Speed | 1.5x move speed | 10 seconds |
| Fire Rate | 2x fire rate | 8 seconds |
| Shield | Absorb one hit | Until hit |
| Weapon | Upgrade weapon | Level |

## Wave Types

| Wave | Enemies | Special |
|------|---------|---------|
| 1-4 | Grunts only | Easy intro |
| 5-9 | Grunts + Fast | Introduce speed |
| 10-14 | All types | Mixed challenges |
| 15-19 | Heavy shooters | Ranged focus |
| 20+ | All types + bosses | Maximum difficulty |

## Controls

| Input | Action |
|-------|--------|
| WASD/Arrows | Move |
| Mouse | Aim |
| Left Click | Shoot |
| Space | Dash |
| E | Use power-up |
| Escape | Pause |

## Related

- [[samples/index|Samples Index]]
- [[samples/platformer|Platformer Sample]]
- [[samples/space-invaders|Space Invaders Sample]]
