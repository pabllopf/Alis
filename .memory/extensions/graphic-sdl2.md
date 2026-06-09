---
Extension: Graphic.Sdl2
tags:
  - extension
  - plugin
  - graphic
  - sdl2
  - rendering
  - documentation

status: draft
---



## Overview

| Property | Value |
|----------|-------|
| **Namespace** | `Alis.Extension.Graphic.Sdl2` |
| **Version** | 1.0.0 |
| **License** | GPLv3 |
| **Author** | Pablo Perdomo Falcón |
| **Layer** | 4_Operation |
| **Dependencies** | Alis.Core, SDL2-CS bindings |

## Purpose

The SDL2 extension provides cross-platform windowing, graphics, audio, and input support via Simple DirectMedia Layer 2. It's the most feature-complete graphics backend in Alis.

## Architecture

```
┌─────────────────────────────────────────┐
│           Application Layer             │
├─────────────────────────────────────────┤
│        Alis.Extension.Graphic.Sdl2      │
├──────────────┬──────────────┬───────────┤
│   Window     │   Renderer   │   Audio   │
├──────────────┼──────────────┼───────────┤
│   SDL2       │  SDL2 GPU    │  SDL2     │
│   Windowing  │  Rendering   │  Mixer    │
└──────────────┴──────────────┴───────────┘
```

## Core Components

### SDL2Window

```csharp
public class SDL2Window : IWindow
```

Full-featured windowing implementation.

**Features:**
- Multiple window support
- Fullscreen modes (exclusive, desktop, borderless)
- Window resizing and positioning
- High DPI support
- Vulkan/OpenGL context creation

### SDL2Renderer

```csharp
public class SDL2Renderer : IRenderer
```

Hardware-accelerated 2D rendering.

**Features:**
- Texture-based rendering
- Sprite batching
- Render targets
- Blend modes
- Scaling and rotation

### SDL2Audio

```csharp
public class SDL2Audio : IAudio
```

Audio playback via SDL2_mixer.

**Features:**
- Multiple audio channels
- Music streaming
- Sound effects
- Spatial audio
- Audio format support (WAV, MP3, OGG, FLAC)

### SDL2Input

```csharp
public class SDL2Input : IInput
```

Comprehensive input handling.

**Features:**
- Keyboard input
- Mouse input with relative mode
- Gamepad/controller support
- Haptic feedback (rumble)
- Touch input (mobile)

## Rendering Backends

| Backend | Status | Notes |
|---------|--------|-------|
| SDL2_Renderer | ✅ | Hardware-accelerated 2D |
| OpenGL | ✅ | Via SDL2 OpenGL context |
| Vulkan | ✅ | Via SDL2 Vulkan support |
| Direct3D 11 | ✅ | Windows only |

## Platform Support

| Platform | Status | Notes |
|----------|--------|-------|
| Windows | ✅ | Full support |
| Linux | ✅ | Full support |
| macOS | ✅ | Full support |
| iOS | ⚠️ | Partial |
| Android | ⚠️ | Partial |
| Web | ⚠️ | Via Emscripten |

## Window Configuration

```csharp
var config = new SDL2Config
{
    Width = 1920,
    Height = 1080,
    Title = "My Game",
    Flags = WindowFlags.Shown | WindowFlags.Resizable | WindowFlags.OpenGL,
    X = SDL2.WINDOWPOS_CENTERED,
    Y = SDL2.WINDOWPOS_CENTERED
};

var window = new SDL2Window(config);
```

## Rendering Pipeline

```csharp
// Initialize renderer
var renderer = new SDL2Renderer(window, new RendererConfig
{
    Type = RendererType.Hardware,
    VSync = true,
    TargetTexture = true
});

// Game loop
while (window.IsOpen)
{
    // Handle events
    SDL2.PollEvents(out var events);
    foreach (var e in events)
    {
        input.HandleEvent(e);
    }

    // Clear screen
    renderer.Clear(new Color(0, 0, 0, 255));

    // Render sprites
    renderer.Copy(texture, srcRect, dstRect, rotation, flip);

    // Present
    renderer.Present();
}
```

## Texture Management

```csharp
// Load texture from file
var texture = renderer.LoadTexture("sprite.png");

// Create texture from surface
var surface = SDL2.LoadBMP("image.bmp");
var texture = renderer.CreateTextureFromSurface(surface);
SDL2.FreeSurface(surface);

// Render texture with properties
renderer.CopyEx(
    texture,
    srcRect: null,
    dstRect: new SDL_Rect(100, 100, 64, 64),
    angle: 45.0,
    center: new SDL_Point(32, 32),
    flip: SDL_RendererFlip.FlipHorizontal
);
```

## Audio System

```csharp
// Initialize audio
var audio = new SDL2Audio(new AudioConfig
{
    Frequency = 44100,
    Format = AudioFormat.S16,
    Channels = 2,
    ChunkSize = 2048
});

// Load and play music
var music = audio.LoadMusic("theme.mp3");
music.Play(-1); // Loop indefinitely

// Load and play sound effect
var sfx = audio.LoadSound("explosion.wav");
sfx.Play(channel: 0);
```

## Gamepad Support

```csharp
// Detect gamepads
var gamepads = SDL2Input.GetGamepads();
Console.WriteLine($"Found {gamepads.Count} gamepads");

// Handle gamepad input
input.OnGamepadAxis += (gamepad, axis, value) =>
{
    if (axis == GamepadAxis.LeftX)
    {
        player.Velocity.X = value / 32767.0f;
    }
};

input.OnGamepadButton += (gamepad, button, pressed) =>
{
    if (button == GamepadButton.A && pressed)
    {
        player.Jump();
    }
};
```

## Performance Characteristics

- Hardware-accelerated rendering
- Efficient sprite batching
- Low-latency audio
- Minimal CPU usage for idle windows

## Memory Management

- Automatic texture cleanup
- Proper SDL resource disposal
- Native handle release

## Related

- [[extensions/graphic-glfw|GLFW Extension]]
- [[extensions/graphic-sfml|SFML Extension]]
- [[extensions/index|Extensions Index]]
- [[architecture/repository-overview|Repository Overview]]
