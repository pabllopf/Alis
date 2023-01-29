# World Class

## Creating a World

First, we define the gravity vector.

```csharp
    Vector2F gravity = new Vector2F(x: 0.0f, y: 9.8f);
```

Now we create the world object.

```csharp
    World myWorld = new World(gravity: gravity);
```