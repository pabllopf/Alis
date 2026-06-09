---
title: Asteroids
tags:
  - sample
  - game
  - example

status: draft

license: GPLv3
---


## Overview

| Property | Value |
|----------|-------|
| **Genre** | Shooter |
| **Platforms** | Desktop, Web |
| **Features** | Rotation, thrust, splitting |

## Description

Classic Asteroids game with vector graphics style. Navigate ship, shoot asteroids, and avoid collisions. Asteroids split when shot.

## Gameplay

- Rotate and thrust ship
- Shoot to destroy asteroids
- Large asteroids split into smaller ones
- Score increases with each asteroid destroyed
- Game gets harder as more asteroids spawn

## Architecture

```
Asteroids/
├── Program.cs
├── AsteroidsGame.cs
├── States/
│   ├── MenuState.cs
│   ├── PlayState.cs
│   ├── PauseState.cs
│   └── GameOverState.cs
├── Components/
│   ├── ShipComponent.cs
│   ├── AsteroidComponent.cs
│   ├── ProjectileComponent.cs
│   └── ScoreComponent.cs
├── Systems/
│   ├── InputSystem.cs
│   ├── MovementSystem.cs
│   ├── ShootingSystem.cs
│   ├── CollisionSystem.cs
│   ├── AsteroidSystem.cs
│   └── WrapAroundSystem.cs
└── Content/
    └── Sprites/
```

## Key Components

### Ship Component

```csharp
public struct ShipComponent
{
    public float ThrustPower;
    public float RotationSpeed;
    public float MaxSpeed;
    public float Friction;
    public float FireRate;
    public float FireCooldown;
    public int Lives;
    public bool IsInvincible;
    public float InvincibleTimer;
}
```

### Asteroid Component

```csharp
public struct AsteroidComponent
{
    public AsteroidSize Size;
    public float RotationSpeed;
    public int Health;
    public int Points;
    public Vector2 Velocity;
}

public enum AsteroidSize
{
    Large,  // Radius 40, 1 HP, 20 points
    Medium, // Radius 20, 1 HP, 50 points
    Small   // Radius 10, 1 HP, 100 points
}
```

### Projectile Component

```csharp
public struct ProjectileComponent
{
    public Vector2 Velocity;
    public float Lifetime;
    public int Damage;
}
```

## Movement System

```csharp
public class MovementSystem : ISystem
{
    public void Update(IWorld world, float deltaTime)
    {
        // Update ship
        var ship = world.GetSingleton<ShipComponent>();
        var shipTransform = world.GetSingleton<TransformComponent>();
        
        // Rotation
        if (Input.IsKeyDown(Keys.Left))
        {
            shipTransform.Rotation -= ship.RotationSpeed * deltaTime;
        }
        if (Input.IsKeyDown(Keys.Right))
        {
            shipTransform.Rotation += ship.RotationSpeed * deltaTime;
        }
        
        // Thrust
        if (Input.IsKeyDown(Keys.Up))
        {
            Vector2 thrust = new Vector2(
                (float)Math.Cos(shipTransform.Rotation),
                (float)Math.Sin(shipTransform.Rotation)
            ) * ship.ThrustPower;
            
            shipTransform.Velocity += thrust * deltaTime;
            
            // Clamp speed
            if (shipTransform.Velocity.Length() > ship.MaxSpeed)
            {
                shipTransform.Velocity = Vector2.Normalize(shipTransform.Velocity) * 
                    ship.MaxSpeed;
            }
        }
        
        // Friction
        shipTransform.Velocity *= (1 - ship.Friction * deltaTime);
        
        // Update position
        shipTransform.Position += shipTransform.Velocity * deltaTime;
        
        // Wrap around screen
        WrapPosition(shipTransform);
        
        // Update asteroids
        var asteroids = world.GetEntitiesWith<AsteroidComponent, TransformComponent>();
        foreach (var asteroid in asteroids)
        {
            ref var asteroidTransform = ref asteroid.Get<TransformComponent>();
            ref var asteroidComp = ref asteroid.Get<AsteroidComponent>();
            
            asteroidTransform.Position += asteroidComp.Velocity * deltaTime;
            asteroidTransform.Rotation += asteroidComp.RotationSpeed * deltaTime;
            
            WrapPosition(asteroidTransform);
        }
        
        // Update projectiles
        var projectiles = world.GetEntitiesWith<ProjectileComponent, TransformComponent>();
        foreach (var proj in projectiles)
        {
            ref var projTransform = ref proj.Get<TransformComponent>();
            ref var projComp = ref proj.Get<ProjectileComponent>();
            
            projTransform.Position += projComp.Velocity * deltaTime;
            projComp.Lifetime -= deltaTime;
            
            if (projComp.Lifetime <= 0)
            {
                proj.Destroy();
            }
        }
    }
    
    private void WrapPosition(TransformComponent transform)
    {
        if (transform.Position.X < 0)
            transform.Position.X = ScreenWidth;
        else if (transform.Position.X > ScreenWidth)
            transform.Position.X = 0;
            
        if (transform.Position.Y < 0)
            transform.Position.Y = ScreenHeight;
        else if (transform.Position.Y > ScreenHeight)
            transform.Position.Y = 0;
    }
}
```

## Asteroid Splitting

```csharp
public class AsteroidSystem : ISystem
{
    public void Update(IWorld world, float deltaTime)
    {
        var asteroids = world.GetEntitiesWith<AsteroidComponent, TransformComponent>();
        
        foreach (var asteroid in asteroids)
        {
            ref var asteroidComp = ref asteroid.Get<AsteroidComponent>();
            
            if (asteroidComp.Health <= 0)
            {
                // Split asteroid
                if (asteroidComp.Size != AsteroidSize.Small)
                {
                    AsteroidSize newSize = asteroidComp.Size == AsteroidSize.Large ? 
                        AsteroidSize.Medium : AsteroidSize.Small;
                    
                    for (int i = 0; i < 2; i++)
                    {
                        SpawnAsteroid(world, asteroid.Get<TransformComponent>().Position, 
                            newSize);
                    }
                }
                
                // Update score
                var score = world.GetSingleton<ScoreComponent>();
                score.Score += asteroidComp.Points;
                
                // Play explosion sound
                AudioManager.PlaySound("explosion");
                
                asteroid.Destroy();
            }
        }
    }
    
    private void SpawnAsteroid(IWorld world, Vector2 position, AsteroidSize size)
    {
        var asteroid = world.CreateEntity();
        
        float radius = size switch
        {
            AsteroidSize.Large => 40,
            AsteroidSize.Medium => 20,
            AsteroidSize.Small => 10
        };
        
        int points = size switch
        {
            AsteroidSize.Large => 20,
            AsteroidSize.Medium => 50,
            AsteroidSize.Small => 100
        };
        
        // Random velocity
        float angle = Random.NextFloat(0, MathF.PI * 2);
        float speed = Random.NextFloat(50, 150);
        Vector2 velocity = new Vector2(
            (float)Math.Cos(angle),
            (float)Math.Sin(angle)
        ) * speed;
        
        asteroid.Set(new AsteroidComponent
        {
            Size = size,
            RotationSpeed = Random.NextFloat(-2, 2),
            Health = 1,
            Points = points,
            Velocity = velocity
        });
        
        asteroid.Set(new TransformComponent
        {
            Position = position + Random.insideUnitCircle * radius,
            Scale = Vector2.One * (radius / 40f)
        });
        
        asteroid.Set(new ColliderComponent
        {
            Radius = radius
        });
    }
}
```

## Collision Detection

```csharp
public class CollisionSystem : ISystem
{
    public void Update(IWorld world, float deltaTime)
    {
        var ship = world.GetSingleton<ShipComponent>();
        var shipTransform = world.GetSingleton<TransformComponent>();
        var asteroids = world.GetEntitiesWith<AsteroidComponent, TransformComponent>();
        var projectiles = world.GetEntitiesWith<ProjectileComponent, TransformComponent>();
        
        if (ship.IsInvincible) return;
        
        // Ship vs Asteroids
        foreach (var asteroid in asteroids)
        {
            ref var asteroidTransform = ref asteroid.Get<TransformComponent>();
            ref var asteroidComp = ref asteroid.Get<AsteroidComponent>();
            
            float distance = Vector2.Distance(shipTransform.Position, 
                asteroidTransform.Position);
            float collisionDist = 20 + asteroidComp.Size switch
            {
                AsteroidSize.Large => 40,
                AsteroidSize.Medium => 20,
                AsteroidSize.Small => 10
            };
            
            if (distance < collisionDist)
            {
                // Ship destroyed
                ship.Lives--;
                ship.IsInvincible = true;
                ship.InvincibleTimer = 3.0f;
                
                // Reset ship position
                shipTransform.Position = new Vector2(ScreenWidth / 2, ScreenHeight / 2);
                shipTransform.Velocity = Vector2.Zero;
                
                AudioManager.PlaySound("death");
                
                if (ship.Lives <= 0)
                {
                    GameOver(world);
                }
            }
        }
        
        // Projectiles vs Asteroids
        foreach (var proj in projectiles)
        {
            ref var projTransform = ref proj.Get<TransformComponent>();
            ref var projComp = ref proj.Get<ProjectileComponent>();
            
            foreach (var asteroid in asteroids)
            {
                ref var asteroidTransform = ref asteroid.Get<TransformComponent>();
                ref var asteroidComp = ref asteroid.Get<AsteroidComponent>();
                
                float distance = Vector2.Distance(projTransform.Position, 
                    asteroidTransform.Position);
                
                if (distance < asteroidComp.Size switch
                {
                    AsteroidSize.Large => 40,
                    AsteroidSize.Medium => 20,
                    AsteroidSize.Small => 10
                })
                {
                    asteroidComp.Health -= projComp.Damage;
                    proj.Destroy();
                    break;
                }
            }
        }
    }
}
```

## Ship Visual

```
     /\
    /  \
   /    \
  /------\
  \      /
   \    /
    \  /
     \/
```

The ship points in the direction of rotation.

## Asteroid Shapes

Each asteroid has a random polygon shape for visual variety.

## Scoring

| Asteroid Size | Points |
|---------------|--------|
| Large | 20 |
| Medium | 50 |
| Small | 100 |

## Difficulty Progression

| Wave | Asteroids | Speed |
|------|-----------|-------|
| 1 | 4 | Slow |
| 2 | 5 | Medium |
| 3 | 6 | Fast |
| 4+ | 7+ | Very Fast |

## Lives

- Start with 3 lives
- Extra life every 10,000 points
- Invincibility after death (3 seconds)

## Controls

| Input | Action |
|-------|--------|
| Left/Right Arrow | Rotate ship |
| Up Arrow | Thrust |
| Space | Shoot |
| P | Pause |
| Escape | Menu |

## Related

- [[samples/index|Samples Index]]
- [[samples/space-invaders|Space Invaders Sample]]
- [[samples/shooter|Shooter Sample]]
