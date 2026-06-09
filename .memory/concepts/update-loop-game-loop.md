---
title: Update Loop & Game Loop Pattern
tags:
  - concept
  - theory
  - documentation

status: draft

license: GPLv3
---


The game loop is the heart of any real-time application, providing fixed timestep simulation with delta time for frame-rate independence and deterministic behavior.

## Core Concept

### Fixed Timestep Game Loop
- **Pattern**: Separate update and render loops
- **Location**: `1_Presentation/Engine/src/GameLoop.cs`
- **Benefits**: Deterministic simulation, frame-rate independence

### Delta Time Calculation
- **Purpose**: Normalize time across different refresh rates
- **Formula**: `deltaTime = currentTime - previousTime`

## Implementation Example

```csharp
public class GameLoop
{
    private const float FixedTimestep = 1f / 60f; // 60 Hz physics
    private float _accumulator = 0f;
    private float _lastTime = 0f;
    
    public void Run()
    {
        while (!ShouldQuit)
        {
            float currentTime = GetTime();
            float deltaTime = currentTime - _lastTime;
            _lastTime = currentTime;
            
            _accumulator += deltaTime;
            
            // Fixed timestep updates
            while (_accumulator >= FixedTimestep)
            {
                Update(FixedTimestep);
                _accumulator -= FixedTimestep;
            }
            
            // Variable timestep rendering
            float interpolation = _accumulator / FixedTimestep;
            Render(interpolation);
        }
    }
    
    private void Update(float deltaTime)
    {
        // Physics update
        _physicsSystem.Update(deltaTime);
        
        // ECS systems
        foreach (var system in _systems)
        {
            system.Update(deltaTime);
        }
        
        // AI updates
        _aiSystem.Update(deltaTime);
    }
    
    private void Render(float interpolation)
    {
        // Render with interpolation for smooth animation
        foreach (var entity in _world.Query<Position, Renderable>())
        {
            var prevPosition = entity.Position - (entity.Velocity * (_accumulator / FixedTimestep));
            DrawEntity(entity, prevPosition, interpolation);
        }
    }
}
```

### Delta Time Usage

```csharp
public class MovementSystem : ISystem
{
    public void Update(float deltaTime)
    {
        var query = _world.Query<Position, Velocity>();
        
        foreach (var entity in query)
        {
            // Frame-rate independent movement
            entity.Position.X += entity.Velocity.X * deltaTime;
            entity.Position.Y += entity.Velocity.Y * deltaTime;
            
            // Time-based animations
            entity.AnimationTimer += deltaTime;
            if (entity.AnimationTimer >= 1f)
            {
                entity.AnimationTimer = 0f;
                PlayAnimationFrame();
            }
        }
    }
}
```

## Benefits

| Benefit | Description |
|---------|-------------|
| **Frame-Rate Independence** | Same simulation speed on any monitor |
| **Deterministic** | Reproducable results |
| **Smooth Animation** | Interpolation between fixed steps |
| **Input Handling** | Consistent input processing |

## Advanced Patterns

### Sub-Stepping

```csharp
// Multiple physics updates per frame for stability
int subSteps = 4;
float subStepTime = FixedTimestep / subSteps;

for (int i = 0; i < subSteps; i++)
{
    _physicsSystem.Update(subStepTime);
}
```

### Time Scaling

```csharp
public class TimeManager
{
    private float _timeScale = 1f;
    
    public void SetTimeScale(float scale)
    {
        _timeScale = Math.Clamp(scale, 0f, 10f);
    }
    
    public float GetDeltaTime() => _deltaTime * _timeScale;
    
    public float GetFixedDeltaTime() => _fixedDeltaTime * _timeScale;
}

// Usage: Slow motion effect
timeManager.SetTimeScale(0.5f); // 50% speed
```

## Performance Considerations

| Metric | Value |
|--------|-------|
| Update loop overhead | ~50ns per frame |
| Fixed timestep (60Hz) | 16.67ms |
| Interpolation cost | ~100ns per entity |
| Memory per frame | ~64 bytes |

## When to Use Game Loop Pattern

### Suitable For
- Game engines
- Real-time simulations
- Interactive applications
- Animation systems

### Not Suitable For
- Batch processing
- Offline calculations
- One-time operations

## See Also
- [`.memory/sources/ecs-sources.md`] - Entity Component System
