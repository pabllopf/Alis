# Engine Sources

tags:
  - source,reference,documentation

Main game engine runtime sources in `1_Presentation/Engine/`.

## Engine Structure

```
1_Presentation/Engine/
├── src/              ← Main engine source code
├── test/             ← Engine tests
└── sample/           ← Engine samples
```

## Key Source Files

### Core Engine
| File | Purpose |
|------|---------|
| `Engine/src/Engine.cs` | Main engine entry point |
| `Engine/src/Core/` | Core engine functionality |
| `Engine/src/Runtime/` | Runtime execution logic |
| `Engine/src/Services/` | Engine services |

### Lifecycle Management
- **Startup** - Engine initialization
- **Update** - Game loop execution
- **Render** - Frame rendering
- **Shutdown** - Cleanup procedures

### Component Integration
- ECS integration
- Graphics system binding
- Audio system integration
- Input handling

## Source Code Patterns

### Engine Interface
```csharp
public interface IEngine
{
    void Initialize();
    void Start();
    void Update(float deltaTime);
    void Render();
    void Shutdown();
}
```

### Service Registration
```csharp
services.AddEngine<DefaultEngine>();
services.AddGraphics<GraphicExtension>();
services.AddAudio<AudioExtension>();
```

## See Also
- [[Layered Architecture]]
- [[Extension System]]
- [[Entity Component System]]
