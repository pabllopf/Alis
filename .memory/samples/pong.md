# Sample: Pong

tags:
  - sample,game,example

## Overview

| Property | Value |
|----------|-------|
| **Genre** | Sports |
| **Platforms** | Desktop, Web |
| **Features** | 2-player, AI, physics |

## Description

Classic pong game with 2-player support and AI opponent. Features smooth paddle movement, ball physics, and scoring system.

## Gameplay

- Two paddles on opposite sides
- Ball bounces off paddles and walls
- Score when ball passes opponent
- First to 11 points wins
- AI opponent for single-player

## Architecture

```
Pong/
├── Program.cs
├── PongGame.cs
├── States/
│   ├── MenuState.cs
│   ├── PlayState.cs
│   ├── PauseState.cs
│   └── GameOverState.cs
├── Entities/
│   ├── Paddle.cs
│   ├── Ball.cs
│   └── Score.cs
├── Systems/
│   ├── PhysicsSystem.cs
│   ├── CollisionSystem.cs
│   └── AISystem.cs
└── Content/
    ├── Sprites/
    └── Audio/
```

## Key Components

### Paddle Component

```csharp
public struct PaddleComponent
{
    public float Speed;
    public bool IsAI;
    public float AIReactionSpeed;
    public float AIPredictionError;
}
```

### Ball Component

```csharp
public struct BallComponent
{
    public Vector2 Velocity;
    public float BaseSpeed;
    public float CurrentSpeed;
    public int BounceCount;
}
```

### Score Component

```csharp
public struct ScoreComponent
{
    public int Player1Score;
    public int Player2Score;
    public int WinScore;
}
```

## AI System

```csharp
public class AISystem : ISystem
{
    public void Update(IWorld world, float deltaTime)
    {
        var paddles = world.GetEntitiesWith<PaddleComponent, TransformComponent>();
        var balls = world.GetEntitiesWith<BallComponent, TransformComponent>();
        
        foreach (var paddle in paddles)
        {
            ref var paddleComp = ref paddle.Get<PaddleComponent>();
            if (!paddleComp.IsAI) continue;
            
            ref var paddleTransform = ref paddle.Get<TransformComponent>();
            var ball = balls.First();
            ref var ballTransform = ref ball.Get<TransformComponent>();
            
            // Predict ball position
            float predictionTime = Math.Abs(
                paddleTransform.Position.X - ballTransform.Position.X
            ) / ball.Get<BallComponent>().CurrentSpeed;
            
            float predictedY = ballTransform.Position.Y +
                ball.Get<BallComponent>().Velocity.Y * predictionTime * paddleComp.AIReactionSpeed;
            
            // Add some error
            predictedY += Random.NextFloat(-paddleComp.AIPredictionError, paddleComp.AIPredictionError);
            
            // Move towards predicted position
            float diff = predictedY - paddleTransform.Position.Y;
            if (Math.Abs(diff) > 5)
            {
                paddleTransform.Position.Y += Math.Sign(diff) * paddleComp.Speed * deltaTime;
            }
        }
    }
}
```

## Ball Physics

```csharp
public class PhysicsSystem : ISystem
{
    public void Update(IWorld world, float deltaTime)
    {
        var balls = world.GetEntitiesWith<BallComponent, TransformComponent>();
        var paddles = world.GetEntitiesWith<PaddleComponent, TransformComponent>();
        
        foreach (var ball in balls)
        {
            ref var transform = ref ball.Get<TransformComponent>();
            ref var ballComp = ref ball.Get<BallComponent>();
            
            // Move ball
            transform.Position += ballComp.Velocity * ballComp.CurrentSpeed * deltaTime;
            
            // Wall collision (top/bottom)
            if (transform.Position.Y <= BallRadius || 
                transform.Position.Y >= ScreenHeight - BallRadius)
            {
                ballComp.Velocity.Y *= -1;
            }
            
            // Paddle collision
            foreach (var paddle in paddles)
            {
                ref var paddleTransform = ref paddle.Get<TransformComponent>();
                ref var paddleComp = ref paddle.Get<PaddleComponent>();
                
                if (CheckPaddleCollision(transform, paddleTransform, paddleComp))
                {
                    ballComp.Velocity.X *= -1;
                    ballComp.BounceCount++;
                    
                    // Increase speed slightly
                    ballComp.CurrentSpeed *= 1.05f;
                    
                    // Adjust angle based on where ball hit paddle
                    float hitPos = (transform.Position.Y - paddleTransform.Position.Y) / 
                                   (PaddleHeight / 2);
                    ballComp.Velocity.Y = hitPos;
                }
            }
            
            // Score detection
            if (transform.Position.X < 0)
            {
                // Player 2 scores
                world.GetSingleton<ScoreComponent>().Player2Score++;
                ResetBall(ball);
            }
            else if (transform.Position.X > ScreenWidth)
            {
                // Player 1 scores
                world.GetSingleton<ScoreComponent>().Player1Score++;
                ResetBall(ball);
            }
        }
    }
}
```

## Controls

### Player 1 (Left)

| Input | Action |
|-------|--------|
| W | Move up |
| S | Move down |

### Player 2 (Right)

| Input | Action |
|-------|--------|
| Up Arrow | Move up |
| Down Arrow | Move down |

### Both Players

| Input | Action |
|-------|--------|
| Space | Start/Pause |
| Escape | Return to menu |

## Game Modes

| Mode | Description |
|------|-------------|
| vs Player | 2-player local |
| vs AI | Single-player vs AI |
| Practice | No scoring, practice mode |

## Related

- [[samples/index|Samples Index]]
- [[samples/breakout|Breakout Sample]]
- [[samples/platformer|Platformer Sample]]
