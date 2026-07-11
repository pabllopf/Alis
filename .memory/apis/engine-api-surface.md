---
title: Engine API Surface
tags:
  - api
  - surface
  - public-api
status: Draft
license: GPLv3
---

# Engine API Surface

## VideoGame API

The main entry point for game creation is the `VideoGame` fluent builder:

```csharp
// Minimal bootstrap
VideoGame.Create().Run();

// Full configuration
VideoGame.Create()
    .Settings(s => s
        .General(g => g
            .Name("My Game")
            .Author("Developer")
            .Resolution(1920, 1080))
        .Audio(a => a
            .Volume(75))
        .Graphic(g => g
            .Backend(GraphicBackend.OpenGL))
        .Physic(p => p
            .Gravity(0, -9.81f)))
    .World(w => w
        .AddScene("Main", scene => scene
            .AddGameObject("player", obj => obj
                .WithComponent<Sprite>()
                .WithComponent<BoxCollider>())))
    .Run();
```

## Core Engine Namespaces

| Namespace | Project | Purpose |
|---|---|---|
| `Alis.Core.Ecs` | Alis.Core.Ecs | ECS types (GameObject, Scene, World) |
| `Alis.Core.Graphic` | Alis.Core.Graphic | Graphics types (Image, Sprite) |
| `Alis.Core.Physic` | Alis.Core.Physic | Physics types (BoxCollider, BodyType) |
| `Alis.Core.Audio` | Alis.Core.Audio | Audio types (AudioSource, Player) |
| `Alis.Core.Aspect.Data` | Alis.Core.Aspect.Data | JSON serialization |
| `Alis.Core.Aspect.Logging` | Alis.Core.Aspect.Logging | Logger, LoggerFactory |
| `Alis.Core.Aspect.Math` | Alis.Core.Aspect.Math | Vector, Matrix, Shape types |
| `Alis.Core.Aspect.Time` | Alis.Core.Aspect.Time | Clock |
| `Alis.Core.Aspect.Memory` | Alis.Core.Aspect.Memory | AssetRegistry |
| `Alis.Core.Aspect.Fluent` | Alis.Core.Aspect.Fluent | Builder interfaces |

## Extension Namespaces

| Namespace | Project | Purpose |
|---|---|---|
| `Alis.Extension.Network` | Alis.Extension.Network | WebSocket client/server |
| `Alis.Extension.Security` | Alis.Extension.Security | Secure types |
| `Alis.Extension.Profile` | Alis.Extension.Profile | Profiler |
| `Alis.Extension.Updater` | Alis.Extension.Updater | Auto-update |
| `Alis.Extension.Thread` | Alis.Extension.Thread | Thread management |
| `Alis.Extension.Graphic.Sdl2` | Alis.Extension.Graphic.Sdl2 | SDL2 bindings |
| `Alis.Extension.Graphic.Sfml` | Alis.Extension.Graphic.Sfml | SFML bindings |
| `Alis.Extension.Graphic.Glfw` | Alis.Extension.Graphic.Glfw | GLFW bindings |
| `Alis.Extension.Graphic.Ui` | Alis.Extension.Graphic.Ui | ImGui bindings |
| `Alis.Extension.Io.FileDialog` | Alis.Extension.Io.FileDialog | File dialogs |
| `Alis.Extension.Media.FFmpeg` | Alis.Extension.Media.FFmpeg | Media processing |
| `Alis.Extension.Cloud.GoogleDrive` | Alis.Extension.Cloud.GoogleDrive | Google Drive |
| `Alis.Extension.Cloud.DropBox` | Alis.Extension.Cloud.DropBox | Dropbox |
| `Alis.Extension.Payment.Stripe` | Alis.Extension.Payment.Stripe | Stripe payments |
| `Alis.Extension.Ads.GoogleAds` | Alis.Extension.Ads.GoogleAds | Google Ads |
| `Alis.Extension.Language.Dialogue` | Alis.Extension.Language.Dialogue | Dialogue system |
| `Alis.Extension.Language.Translator` | Alis.Extension.Language.Translator | Translation |
| `Alis.Extension.Math.HighSpeedPriorityQueue` | Alis.Extension.Math.HighSpeedPriorityQueue | Priority queues |

## Key Engine Types

### VideoGame
- `VideoGame.Create()` - Static factory
- `.Settings(Action<SettingsBuilder>)` - Configuration
- `.World(Action<WorldBuilder>)` - Scene setup
- `.Run()` - Start game loop
- `.Save()` - Save game state

### GameObject
- `.AddComponent<T>()` - Add component
- `.GetComponent<T>()` - Get component
- `.RemoveComponent<T>()` - Remove component
- `.SetParent(GameObject)` - Hierarchy
- `.Transform` - Transform access

### Scene
- `.AddGameObject(string, Action<GameObjectBuilder>)` - Add entity
- `.GetGameObject(string)` - Find entity
- `.RemoveGameObject(GameObject)` - Remove entity

## Related

- [[APIs Index]]
- [[Engine Services Overview]]
- [[Projects Index]]
