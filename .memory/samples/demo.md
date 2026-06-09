---
title: Demo
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
| **Genre** | Demo |
| **Platforms** | Desktop, Web |
| **Features** | Engine features showcase |

## Description

Comprehensive demo showcasing Alis engine features including rendering, audio, input, physics, particles, and UI systems. Serves as both a learning tool and feature demonstration.

## Features Demonstrated

### Rendering
- 2D sprites and animations
- 3D meshes and models
- Tilemaps
- Particle systems
- Screen effects (bloom, blur, etc.)
- Multiple cameras

### Audio
- Music playback
- Sound effects
- Spatial audio
- Audio buses

### Input
- Keyboard input
- Mouse input
- Gamepad input
- Touch input (mobile)

### Physics
- Rigid body physics
- Collision detection
- Triggers
- Joints

### UI
- Buttons, sliders, text boxes
- Layouts (horizontal, vertical, grid)
- Theming
- Scrolling

### ECS
- Entity creation
- Component management
- System execution
- Queries

## Architecture

```
Demo/
├── Program.cs
├── DemoGame.cs
├── States/
│   ├── MenuState.cs
│   ├── RenderingDemo.cs
│   ├── AudioDemo.cs
│   ├── InputDemo.cs
│   ├── PhysicsDemo.cs
│   ├── ParticleDemo.cs
│   ├── UIDemo.cs
│   └── ECSDemo.cs
├── DemoScenes/
│   ├── SpriteScene.cs
│   ├── MeshScene.cs
│   ├── TilemapScene.cs
│   ├── ParticleScene.cs
│   ├── PhysicsScene.cs
│   └── UIScene.cs
└── Content/
    ├── Sprites/
    ├── Models/
    ├── Audio/
    └── Fonts/
```

## Demo Scenes

### Rendering Demo

```csharp
public class RenderingDemo : IState
{
    public void Enter()
    {
        // Load assets
        spriteSheet = Content.Load<Texture2D>("spritesheet");
        model = Content.Load<Model>("model");
        tilemap = Content.Load<Tilemap>("level");
        
        // Setup cameras
        camera2D = new Camera2D();
        camera3D = new Camera3D();
    }
    
    public void Update(GameTime gameTime)
    {
        // 2D Sprites
        spriteBatch.Begin(camera2D);
        spriteBatch.Draw(spriteSheet, position, sourceRect, Color.White, 
            rotation, origin, scale, effects, layerDepth);
        spriteBatch.End();
        
        // 3D Model
        foreach (var mesh in model.Meshes)
        {
            foreach (var effect in mesh.Effects)
            {
                effect.World = worldMatrix;
                effect.View = camera3D.ViewMatrix;
                effect.Projection = camera3D.ProjectionMatrix;
            }
            mesh.Draw();
        }
        
        // Tilemap
        tilemapRenderer.Draw(tilemap, camera2D);
    }
}
```

### Audio Demo

```csharp
public class AudioDemo : IState
{
    private Music music;
    private SoundEffect sfx;
    private SoundEffectInstance sfxInstance;
    
    public void Enter()
    {
        music = Content.Load<Music>("music");
        sfx = Content.Load<SoundEffect>("sfx");
        
        // Start music
        music.Play();
        
        // Create sound instance
        sfxInstance = sfx.CreateInstance();
    }
    
    public void Update(GameTime gameTime)
    {
        // Play SFX
        if (Input.IsKeyPressed(Keys.Space))
        {
            sfx.Play();
        }
        
        // Adjust volume
        if (Input.IsKeyDown(Keys.Up))
        {
            Music.Volume = Math.Min(1.0f, Music.Volume + 0.01f);
        }
        if (Input.IsKeyDown(Keys.Down))
        {
            Music.Volume = Math.Max(0.0f, Music.Volume - 0.01f);
        }
        
        // Spatial audio
        sfxInstance.Position = new Vector3(
            player.Position.X, 0, player.Position.Y
        );
    }
}
```

### Input Demo

```csharp
public class InputDemo : IState
{
    private Vector2 position = Vector2.Zero;
    private Color color = Color.White;
    
    public void Update(GameTime gameTime)
    {
        // Keyboard
        if (Input.IsKeyDown(Keys.W)) position.Y -= 100 * deltaTime;
        if (Input.IsKeyDown(Keys.S)) position.Y += 100 * deltaTime;
        if (Input.IsKeyDown(Keys.A)) position.X -= 100 * deltaTime;
        if (Input.IsKeyDown(Keys.D)) position.X += 100 * deltaTime;
        
        // Mouse
        if (Input.IsMouseButtonDown(MouseButton.Left))
        {
            color = Color.Red;
            position = Input.MousePosition;
        }
        else
        {
            color = Color.White;
        }
        
        // Gamepad
        var gamepad = Input.GetGamepad(GamepadIndex.One);
        if (gamepad.IsConnected)
        {
            position.X += gamepad.LeftStick.X * 100 * deltaTime;
            position.Y += gamepad.LeftStick.Y * 100 * deltaTime;
            
            if (gamepad.IsButtonDown(GamepadButton.A))
            {
                color = Color.Blue;
            }
        }
        
        // Touch
        if (Input.TouchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.State == TouchState.Pressed)
            {
                position = touch.Position;
            }
        }
    }
}
```

### Physics Demo

```csharp
public class PhysicsDemo : IState
{
    private PhysicsWorld world;
    
    public void Enter()
    {
        world = new PhysicsWorld(new Vector2(0, 9.81f));
        
        // Create ground
        var ground = new RigidBody(BodyType.Static);
        ground.AddFixture(FixtureFactory.CreateRectangle(800, 20, 
            new Vector2(400, 580)));
        world.Add(ground);
        
        // Create boxes
        for (int i = 0; i < 10; i++)
        {
            var box = new RigidBody(BodyType.Dynamic);
            box.AddFixture(FixtureFactory.CreateRectangle(50, 50, 
                new Vector2(200 + i * 50, 100)));
            world.Add(box);
        }
    }
    
    public void Update(GameTime gameTime)
    {
        // Step physics
        world.Step(deltaTime);
        
        // Render bodies
        foreach (var body in world.Bodies)
        {
            foreach (var fixture in body.Fixtures)
            {
                if (fixture.Shape is PolygonShape polygon)
                {
                    // Draw polygon
                    DrawPolygon(body.Position, body.Rotation, polygon.Vertices, 
                        body.IsStatic ? Color.Gray : Color.Yellow);
                }
            }
        }
    }
}
```

### Particle Demo

```csharp
public class ParticleDemo : IState
{
    private ParticleEmitter emitter;
    
    public void Enter()
    {
        emitter = new ParticleEmitter(new ParticleConfig
        {
            MaxParticles = 1000,
            EmissionRate = 100,
            Lifetime = 2.0f,
            StartColor = Color.Orange,
            EndColor = Color.Red,
            StartSize = 10,
            EndSize = 0,
            Speed = 100,
            SpeedVariance = 20,
            Gravity = new Vector2(0, 100),
            Angle = 0,
            AngleVariance = 180
        });
    }
    
    public void Update(GameTime gameTime)
    {
        // Update emitter position
        emitter.Position = Input.MousePosition;
        
        // Emit particles
        emitter.Update(deltaTime);
        
        // Draw particles
        foreach (var particle in emitter.Particles)
        {
            DrawCircle(particle.Position, particle.Size, particle.Color);
        }
    }
}
```

### UI Demo

```csharp
public class UIDemo : IState
{
    private UIManager ui;
    
    public void Enter()
    {
        ui = new UIManager();
        
        // Create widgets
        var button = new Button("Click Me");
        button.OnClick += () => Console.WriteLine("Clicked!");
        
        var slider = new Slider(0, 100, 50);
        slider.OnValueChanged += (value) => Console.WriteLine($"Value: {value}");
        
        var textBox = new TextBox("Enter text...");
        
        // Layout
        ui.Add(new VerticalLayout
        {
            button,
            slider,
            textBox
        });
    }
    
    public void Update(GameTime gameTime)
    {
        // Update UI
        ui.Update(deltaTime);
        
        // Draw UI
        ui.Draw();
    }
}
```

### ECS Demo

```csharp
public class ECSDemo : IState
{
    private World world;
    
    public void Enter()
    {
        world = new World();
        
        // Create entities
        for (int i = 0; i < 100; i++)
        {
            var entity = world.CreateEntity();
            entity.Set(new PositionComponent
            {
                X = Random.Next(0, ScreenWidth),
                Y = Random.Next(0, ScreenHeight)
            });
            entity.Set(new VelocityComponent
            {
                X = Random.NextFloat(-100, 100),
                Y = Random.NextFloat(-100, 100)
            });
            entity.Set(new SpriteComponent
            {
                Texture = Content.Load<Texture2D>("dot")
            });
        }
        
        // Add systems
        world.AddSystem(new MovementSystem());
        world.AddSystem(new RenderSystem());
    }
    
    public void Update(GameTime gameTime)
    {
        world.Update(deltaTime);
    }
}
```

## Navigation

| Key | Action |
|-----|--------|
| 1 | Rendering Demo |
| 2 | Audio Demo |
| 3 | Input Demo |
| 4 | Physics Demo |
| 5 | Particle Demo |
| 6 | UI Demo |
| 7 | ECS Demo |
| Escape | Back to Menu |

## Controls

| Input | Action |
|-------|--------|
| WASD | Move player |
| Mouse | Interact |
| Space | Action |
| Number Keys | Switch demo |
| Escape | Menu |

## Related

- [[samples/index|Samples Index]]
- [[onboarding/getting-started|Getting Started]]
- [[architecture/repository-overview|Repository Overview]]
