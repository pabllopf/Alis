---
title: Flappy Bird
tags: [sample,game,example]
---


## Overview

| Property | Value |
|----------|-------|
| **Genre** | Arcade |
| **Platforms** | Desktop, Web |
| **Features** | Physics, obstacles |

## Description

Flappy Bird clone where the player taps to make a bird fly through gaps in pipes. Features simple controls but challenging gameplay.

## Gameplay

- Tap space/click to flap
- Navigate through pipe gaps
- Score increases with each pipe passed
- Game over on collision with pipes or ground
- Beat your high score

## Architecture

```
FlappyBird/
├── Program.cs
├── FlappyBirdGame.cs
├── States/
│   ├── MenuState.cs
│   ├── PlayState.cs
│   ├── PauseState.cs
│   └── GameOverState.cs
├── Components/
│   ├── BirdComponent.cs
│   ├── PipeComponent.cs
│   ├── ScoreComponent.cs
│   └── BackgroundComponent.cs
├── Systems/
│   ├── InputSystem.cs
│   ├── PhysicsSystem.cs
│   ├── PipeSystem.cs
│   ├── CollisionSystem.cs
│   └── ScoringSystem.cs
└── Content/
    └── Sprites/
```

## Key Components

### Bird Component

```csharp
public struct BirdComponent
{
    public float Gravity;
    public float FlapForce;
    public float Velocity;
    public float MaxVelocity;
    public float Rotation;
    public bool IsAlive;
    public BirdState State;
}

public enum BirdState
{
    Ready,
    Flying,
    Falling,
    Dead
}
```

### Pipe Component

```csharp
public struct PipeComponent
{
    public float X;
    public float GapY;
    public float GapSize;
    public float Width;
    public float Speed;
    public bool IsScored;
}
```

### Score Component

```csharp
public struct ScoreComponent
{
    public int Score;
    public int HighScore;
    public bool IsNewHighScore;
}
```

## Physics System

```csharp
public class PhysicsSystem : ISystem
{
    public void Update(IWorld world, float deltaTime)
    {
        var bird = world.GetSingleton<BirdComponent>();
        
        if (bird.State == BirdState.Dead) return;
        
        // Apply gravity
        bird.Velocity += bird.Gravity * deltaTime;
        
        // Clamp velocity
        bird.Velocity = MathHelper.Clamp(bird.Velocity, -bird.MaxVelocity, bird.MaxVelocity);
        
        // Update position (handled by transform component)
        
        // Update rotation based on velocity
        bird.Rotation = MathHelper.Clamp(bird.Velocity * 3f, -90f, 30f);
        
        // Check ground collision
        var transform = world.GetSingleton<TransformComponent>();
        if (transform.Position.Y >= GroundY)
        {
            Die(world);
        }
        
        // Check ceiling collision
        if (transform.Position.Y <= 0)
        {
            transform.Position.Y = 0;
            bird.Velocity = 0;
        }
    }
    
    private void Flap(IWorld world)
    {
        var bird = world.GetSingleton<BirdComponent>();
        var transform = world.GetSingleton<TransformComponent>();
        
        if (bird.State == BirdState.Dead) return;
        
        if (bird.State == BirdState.Ready)
        {
            bird.State = BirdState.Flying;
        }
        
        bird.Velocity = -bird.FlapForce;
        
        // Play flap sound
        AudioManager.PlaySound("flap");
    }
}
```

## Pipe System

```csharp
public class PipeSystem : ISystem
{
    private float pipeTimer = 0;
    private float pipeInterval = 2.0f;
    
    public void Update(IWorld world, float deltaTime)
    {
        var pipes = world.GetEntitiesWith<PipeComponent>();
        var score = world.GetSingleton<ScoreComponent>();
        
        // Move pipes
        foreach (var pipeEntity in pipes)
        {
            ref var pipe = ref pipeEntity.Get<PipeComponent>();
            pipe.X -= pipe.Speed * deltaTime;
            
            // Check if pipe passed bird
            var bird = world.GetSingleton<BirdComponent>();
            var birdTransform = world.GetSingleton<TransformComponent>();
            
            if (!pipe.IsScored && pipe.X + pipe.Width < birdTransform.Position.X)
            {
                pipe.IsScored = true;
                score.Score++;
                
                // Play score sound
                AudioManager.PlaySound("score");
            }
            
            // Remove off-screen pipes
            if (pipe.X + pipe.Width < 0)
            {
                pipeEntity.Destroy();
            }
        }
        
        // Spawn new pipes
        pipeTimer += deltaTime;
        if (pipeTimer >= pipeInterval)
        {
            pipeTimer = 0;
            SpawnPipe(world);
        }
    }
    
    private void SpawnPipe(IWorld world)
    {
        var random = new Random();
        
        // Random gap position
        float minGapY = 100;
        float maxGapY = ScreenHeight - 100 - GapSize;
        float gapY = (float)random.NextDouble() * (maxGapY - minGapY) + minGapY;
        
        var pipe = world.CreateEntity();
        pipe.Set(new PipeComponent
        {
            X = ScreenWidth,
            GapY = gapY,
            GapSize = 150,
            Width = 80,
            Speed = 200,
            IsScored = false
        });
    }
}
```

## Collision System

```csharp
public class CollisionSystem : ISystem
{
    public void Update(IWorld world, float deltaTime)
    {
        var bird = world.GetSingleton<BirdComponent>();
        if (bird.State == BirdState.Dead) return;
        
        var birdTransform = world.GetSingleton<TransformComponent>();
        var pipes = world.GetEntitiesWith<PipeComponent>();
        
        // Bird hitbox (smaller than sprite for fairness)
        Rectangle birdRect = new Rectangle(
            (int)birdTransform.Position.X - 10,
            (int)birdTransform.Position.Y - 10,
            20,
            20
        );
        
        foreach (var pipeEntity in pipes)
        {
            ref var pipe = ref pipeEntity.Get<PipeComponent>();
            
            // Top pipe
            Rectangle topPipeRect = new Rectangle(
                (int)pipe.X,
                0,
                (int)pipe.Width,
                (int)pipe.GapY
            );
            
            // Bottom pipe
            Rectangle bottomPipeRect = new Rectangle(
                (int)pipe.X,
                (int)(pipe.GapY + pipe.GapSize),
                (int)pipe.Width,
                ScreenHeight - (int)(pipe.GapY + pipe.GapSize)
            );
            
            if (birdRect.Intersects(topPipeRect) || 
                birdRect.Intersects(bottomPipeRect))
            {
                Die(world);
                return;
            }
        }
    }
}
```

## Visual Effects

```csharp
public class VisualSystem : ISystem
{
    public void Update(IWorld world, float deltaTime)
    {
        var bird = world.GetSingleton<BirdComponent>();
        var transform = world.GetSingleton<TransformComponent>();
        
        // Wing animation
        if (bird.State == BirdState.Flying)
        {
            bird.WingTimer += deltaTime * 10;
            bird.WingAngle = (float)Math.Sin(bird.WingTimer) * 20;
        }
        
        // Screen shake on death
        if (bird.State == BirdState.Dead)
        {
            if (shakeTimer > 0)
            {
                shakeTimer -= deltaTime;
                shakeIntensity *= 0.9f;
            }
        }
    }
}
```

## Difficulty Progression

| Pipes Passed | Speed Increase | Gap Decrease |
|--------------|----------------|--------------|
| 0 | Base | Base |
| 10 | +5% | -2% |
| 20 | +10% | -5% |
| 30 | +15% | -8% |
| 40+ | +20% | -10% |

## Scoring

| Action | Points |
|--------|--------|
| Pass pipe | 1 |
| Bonus (every 10) | +5 |

## Controls

| Input | Action |
|-------|--------|
| Space | Flap |
| Left Click | Flap |
| Enter | Start game |
| Escape | Pause |

## Tips

1. **Timing is key**: Don't spam flap, time your taps
2. **Look ahead**: Watch the next gap, not the current one
3. **Stay centered**: Try to keep the bird in the middle of the screen
4. **Practice**: Muscle memory is crucial for success

## Related

- [[samples/index|Samples Index]]
- [[samples/breakout|Breakout Sample]]
- [[samples/asteroids|Asteroids Sample]]
