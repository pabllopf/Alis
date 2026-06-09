---
title: Breakout 3D
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
| **Genre** | Arcade |
| **Platforms** | Desktop, Web |
| **Features** | 3D physics, cameras |

## Description

3D version of Breakout with perspective camera, 3D models, and lighting. Demonstrates 3D rendering and physics in Alis.

## Gameplay

- Control paddle to bounce ball
- Break 3D brick formations
- Camera orbits around play area
- Multiple levels with 3D layouts
- Power-ups affect 3D space

## Architecture

```
Breakout3D/
├── Program.cs
├── Breakout3DGame.cs
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
│   ├── CameraSystem.cs
│   └── LightingSystem.cs
├── Models/
│   ├── paddle.obj
│   ├── ball.obj
│   └── brick.obj
└── Content/
    ├── Textures/
    ├── Shaders/
    └── Audio/
```

## Key Components

### 3D Paddle Component

```csharp
public struct Paddle3DComponent
{
    public float Width;
    public float Height;
    public float Depth;
    public float Speed;
    public Vector3 MoveBounds;
}
```

### 3D Ball Component

```csharp
public struct Ball3DComponent
{
    public Vector3 Velocity;
    public float Speed;
    public float Radius;
    public bool IsActive;
}
```

### 3D Brick Component

```csharp
public struct Brick3DComponent
{
    public int Health;
    public int Points;
    public Vector3 Size;
    public BrickType3D Type;
    public Color Tint;
}

public enum BrickType3D
{
    Normal,
    Indestructible,
    Moving,
    Exploding
}
```

### Camera Component

```csharp
public struct Camera3DComponent
{
    public CameraType Type;
    public float Distance;
    public float Height;
    public float Angle;
    public float FOV;
    public Vector3 Target;
}

public enum CameraType
{
    Orbit,
    Follow,
    Fixed,
    Free
}
```

## 3D Physics System

```csharp
public class Physics3DSystem : ISystem
{
    public void Update(IWorld world, float deltaTime)
    {
        var balls = world.GetEntitiesWith<Ball3DComponent, TransformComponent>();
        var paddles = world.GetEntitiesWith<Paddle3DComponent, TransformComponent>();
        
        foreach (var ball in balls)
        {
            ref var transform = ref ball.Get<TransformComponent>();
            ref var ballComp = ref ball.Get<Ball3DComponent>();
            
            // Apply velocity
            transform.Position += ballComp.Velocity * ballComp.Speed * deltaTime;
            
            // Wall collisions (X and Z axes)
            if (Math.Abs(transform.Position.X) > PlayAreaSize / 2)
            {
                ballComp.Velocity.X *= -1;
                transform.Position.X = Math.Sign(transform.Position.X) * PlayAreaSize / 2;
            }
            
            if (Math.Abs(transform.Position.Z) > PlayAreaSize / 2)
            {
                ballComp.Velocity.Z *= -1;
                transform.Position.Z = Math.Sign(transform.Position.Z) * PlayAreaSize / 2;
            }
            
            // Bottom collision (lose ball)
            if (transform.Position.Y < -10)
            {
                ballComp.IsActive = false;
                // Lose life
            }
            
            // Paddle collision
            foreach (var paddle in paddles)
            {
                ref var paddleTransform = ref paddle.Get<TransformComponent>();
                ref var paddleComp = ref paddle.Get<Paddle3DComponent>();
                
                if (CheckPaddleCollision3D(transform, ballComp, paddleTransform, paddleComp))
                {
                    // Reflect ball
                    float hitPos = (transform.Position.X - paddleTransform.Position.X) / 
                        (paddleComp.Width / 2);
                    
                    ballComp.Velocity.X = hitPos;
                    ballComp.Velocity.Y = (float)Math.Sqrt(1 - hitPos * hitPos);
                    ballComp.Velocity.Z = Random.NextFloat(-0.2f, 0.2f);
                    
                    // Normalize
                    ballComp.Velocity = Vector3.Normalize(ballComp.Velocity);
                }
            }
        }
    }
    
    private bool CheckPaddleCollision3D(TransformComponent ball, Ball3DComponent ballComp,
        TransformComponent paddle, Paddle3DComponent paddleComp)
    {
        // AABB vs sphere collision
        Vector3 closest = new Vector3(
            MathHelper.Clamp(ball.Position.X, 
                paddle.Position.X - paddleComp.Width / 2,
                paddle.Position.X + paddleComp.Width / 2),
            MathHelper.Clamp(ball.Position.Y,
                paddle.Position.Y - paddleComp.Height / 2,
                paddle.Position.Y + paddleComp.Height / 2),
            MathHelper.Clamp(ball.Position.Z,
                paddle.Position.Z - paddleComp.Depth / 2,
                paddle.Position.Z + paddleComp.Depth / 2)
        );
        
        float distance = Vector3.Distance(ball.Position, closest);
        return distance < ballComp.Radius;
    }
}
```

## Camera System

```csharp
public class Camera3DSystem : ISystem
{
    public void Update(IWorld world, float deltaTime)
    {
        var camera = world.GetSingleton<Camera3DComponent>();
        var ball = world.GetEntitiesWith<Ball3DComponent, TransformComponent>()
            .FirstOrDefault();
        
        if (camera.Type == CameraType.Orbit)
        {
            // Orbit around play area
            camera.Angle += deltaTime * 0.1f;
            
            camera.Position = new Vector3(
                (float)Math.Cos(camera.Angle) * camera.Distance,
                camera.Height,
                (float)Math.Sin(camera.Angle) * camera.Distance
            );
            
            camera.Target = Vector3.Zero;
        }
        else if (camera.Type == CameraType.Follow)
        {
            // Follow ball
            if (ball != null)
            {
                ref var ballTransform = ref ball.Get<TransformComponent>();
                
                camera.Target = ballTransform.Position;
                camera.Position = ballTransform.Position + 
                    new Vector3(0, camera.Height, camera.Distance);
            }
        }
        
        // Update view matrix
        camera.ViewMatrix = Matrix4x4.CreateLookAt(
            camera.Position,
            camera.Target,
            Vector3.UnitY
        );
        
        // Update projection matrix
        camera.ProjectionMatrix = Matrix4x4.CreatePerspectiveFieldOfView(
            camera.FOV,
            ScreenWidth / (float)ScreenHeight,
            0.1f,
            1000.0f
        );
    }
}
```

## Lighting System

```csharp
public class LightingSystem : ISystem
{
    public void Update(IWorld world, float deltaTime)
    {
        var lights = world.GetEntitiesWith<LightComponent>();
        var camera = world.GetSingleton<Camera3DComponent>();
        
        // Set up light uniforms
        foreach (var lightEntity in lights)
        {
            ref var light = ref lightEntity.Get<LightComponent>();
            ref var lightTransform = ref lightEntity.Get<TransformComponent>();
            
            shader.SetVector3("lightPosition", lightTransform.Position);
            shader.SetVector3("lightColor", light.Color.ToVector3());
            shader.SetFloat("lightIntensity", light.Intensity);
        }
        
        // Set camera uniforms
        shader.SetMatrix4("view", camera.ViewMatrix);
        shader.SetMatrix4("projection", camera.ProjectionMatrix);
        shader.SetVector3("cameraPosition", camera.Position);
    }
}
```

## 3D Rendering Pipeline

```csharp
public class Render3DSystem : ISystem
{
    public void Update(IWorld world, float deltaTime)
    {
        var camera = world.GetSingleton<Camera3DComponent>();
        var meshes = world.GetEntitiesWith<MeshComponent, TransformComponent>();
        
        // Clear screen
        Graphics.Clear(Color.Black);
        
        // Render each mesh
        foreach (var entity in meshes)
        {
            ref var mesh = ref entity.Get<MeshComponent>();
            ref var transform = ref entity.Get<TransformComponent>();
            
            // Calculate MVP matrix
            Matrix4x4 model = Matrix4x4.CreateScale(transform.Scale) *
                Matrix4x4.CreateRotationY(transform.Rotation.Y) *
                Matrix4x4.CreateTranslation(transform.Position);
            
            Matrix4x4 mvp = model * camera.ViewMatrix * camera.ProjectionMatrix;
            
            // Set shader uniforms
            shader.SetMatrix4("model", model);
            shader.SetMatrix4("mvp", mvp);
            shader.SetVector3("tint", mesh.Tint.ToVector3());
            
            // Bind texture
            if (mesh.Texture != null)
            {
                shader.SetBool("hasTexture", true);
                mesh.Texture.Bind();
            }
            else
            {
                shader.SetBool("hasTexture", false);
            }
            
            // Draw mesh
            mesh.VAO.Bind();
            Graphics.DrawElements(PrimitiveType.Triangles, mesh.IndexCount);
        }
    }
}
```

## Brick Types

| Type | Behavior | Visual |
|------|----------|--------|
| Normal | 1 hit | Colored |
| Indestructible | Cannot be destroyed | Gray/Metal |
| Moving | Moves side to side | Animated |
| Exploding | Destroys adjacent | Glowing |

## 3D Power-ups

| Power-up | Effect | Visual |
|----------|--------|--------|
| Wide Paddle | Paddle 2x width | Green glow |
| Multi-ball | 3 balls | Blue particles |
| Fireball | Penetrates bricks | Orange trail |
| Magnet | Ball sticks | Purple aura |

## Camera Modes

| Mode | Description |
|------|-------------|
| Orbit | Rotates around play area |
| Follow | Follows ball |
| Fixed | Static camera |
| Free | WASD + mouse control |

## Shader Example

```glsl
#version 330 core

layout (location = 0) in vec3 aPos;
layout (location = 1) in vec2 aTexCoord;
layout (location = 2) in vec3 aNormal;

uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;
uniform mat4 mvp;

out vec2 TexCoord;
out vec3 Normal;
out vec3 FragPos;

void main()
{
    gl_Position = mvp * vec4(aPos, 1.0);
    FragPos = vec3(model * vec4(aPos, 1.0));
    Normal = mat3(transpose(inverse(model))) * aNormal;
    TexCoord = aTexCoord;
}
```

## Controls

| Input | Action |
|-------|--------|
| Mouse X | Move paddle (X axis) |
| Mouse Y | Move paddle (Z axis) |
| Left Click | Launch ball |
| C | Change camera mode |
| Space | Pause |
| Escape | Menu |

## Related

- [[samples/index|Samples Index]]
- [[samples/breakout|Breakout Sample]]
- [[architecture/repository-overview|Repository Overview]]
