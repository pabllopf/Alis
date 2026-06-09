# Extension: Graphic.Sfml

tags:
  - extension,plugin,add-on

## Overview

| Property | Value |
|----------|-------|
| **Namespace** | `Alis.Extension.Graphic.Sfml` |
| **Version** | 1.0.0 |
| **License** | GPLv3 |
| **Author** | Pablo Perdomo Falcón |
| **Layer** | 4_Operation |
| **Dependencies** | Alis.Core, SFML.NET bindings |

## Purpose

The SFML extension provides graphics, audio, and windowing support via SFML (Simple and Fast Multimedia Library). It serves as an alternative rendering backend for platforms where SFML is preferred.

## Architecture

```
┌─────────────────────────────────────────┐
│           Application Layer             │
├─────────────────────────────────────────┤
│        Alis.Extension.Graphic.Sfml      │
├──────────────┬──────────────┬───────────┤
│   Window     │   Graphics   │   Audio   │
├──────────────┼──────────────┼───────────┤
│  SFML.NET    │  SFML.NET    │  SFML.NET │
└──────────────┴──────────────┴───────────┘
```

## Core Components

### SFMLWindow

```csharp
public class SFMLWindow : IWindow
```

Window management implementation using SFML.

**Features:**
- Fullscreen and windowed modes
- Resizable windows
- VSync support
- Multi-monitor support
- Input handling (keyboard, mouse, joystick)

### SFMLGraphics

```csharp
public class SFMLGraphics : IGraphics
```

2D graphics rendering implementation.

**Features:**
- Sprite rendering
- Texture management
- Shape drawing (circles, rectangles, polygons)
- Text rendering with TrueType fonts
- Render textures for off-screen rendering

### SFMLAudio

```csharp
public class SFMLAudio : IAudio
```

Audio playback implementation.

**Features:**
- Music streaming
- Sound effects with spatial audio
- Volume control
- Playback state management

## Supported Features

| Feature | Support | Notes |
|---------|---------|-------|
| Window Creation | ✅ Full | Multiple windows supported |
| 2D Rendering | ✅ Full | Hardware accelerated |
| Textures | ✅ Full | PNG, JPG, BMP, TGA |
| Fonts | ✅ Full | TrueType (.ttf) |
| Audio (Music) | ✅ Full | OGG, WAV, FLAC |
| Audio (SFX) | ✅ Full | OGG, WAV |
| Input | ✅ Full | Keyboard, Mouse, Joystick |
| OpenGL | ⚠️ Partial | Via SFML's context |

## Platform Support

| Platform | Status | Notes |
|----------|--------|-------|
| Windows | ✅ | Primary target |
| Linux | ✅ | Requires SFML libs |
| macOS | ✅ | Requires SFML libs |

## Configuration

```csharp
var config = new SFMLConfig
{
    VideoMode = new VideoMode(1920, 1080),
    Title = "My Game",
    Style = Styles.Default,
    VerticalSyncEnabled = true,
    FramerateLimit = 60
};

var window = new SFMLWindow(config);
```

## Integration Pattern

```csharp
// Initialize SFML backend
var graphics = new SFMLGraphics();
var audio = new SFMLAudio();
var window = new SFMLWindow(config);

// Game loop
while (window.IsOpen)
{
    window.ProcessEvents();
    
    // Update game logic
    gameState.Update();
    
    // Render
    graphics.Clear();
    graphics.Draw(sprite);
    graphics.Display();
}
```

## Memory Management

- Textures are cached and reused
- Audio resources are pooled
- Proper disposal of native SFML objects

## Performance Characteristics

- Hardware-accelerated 2D rendering
- Low-latency audio playback
- Efficient sprite batching
- Minimal CPU overhead for simple scenes

## Related

- [[extensions/graphic-glfw|GLFW Extension]]
- [[extensions/graphic-sdl2|SDL2 Extension]]
- [[extensions/index|Extensions Index]]
- [[architecture/repository-overview|Repository Overview]]
