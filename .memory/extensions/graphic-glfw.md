---
Extension: Graphic.Glfw
tags: [extension,plugin,graphic,glfw,rendering,documentation]
---



## Overview

| Property | Value |
|----------|-------|
| **Namespace** | `Alis.Extension.Graphic.Glfw` |
| **Version** | 1.0.0 |
| **License** | GPLv3 |
| **Author** | Pablo Perdomo Falcón |
| **Layer** | 4_Operation |
| **Dependencies** | Alis.Core, GlfwNet bindings |

## Purpose

The GLFW extension provides cross-platform windowing and OpenGL context management. It's the foundation for OpenGL/Vulkan rendering in Alis.

## Architecture

```
┌─────────────────────────────────────────┐
│           Application Layer             │
├─────────────────────────────────────────┤
│        Alis.Extension.Graphic.Glfw      │
├─────────────────────────────────────────┤
│             GLFW Binding                │
├─────────────────────────────────────────┤
│     OpenGL / Vulkan Context             │
└─────────────────────────────────────────┘
```

## Core Components

### GlfwWindow

```csharp
public class GlfwWindow : IWindow
```

Window management using GLFW.

**Features:**
- Cross-platform windowing
- OpenGL/Vulkan context creation
- Input handling (keyboard, mouse, gamepad)
- Monitor management
- Cursor management

### OpenGLContext

```csharp
public class OpenGLContext : IGraphicsContext
```

OpenGL rendering context wrapper.

**Features:**
- OpenGL 3.3+ core profile
- Shader compilation and linking
- Framebuffer objects
- Texture management
- VAO/VBO management

## Supported OpenGL Versions

| Version | Profile | Status |
|---------|---------|--------|
| OpenGL 3.3 | Core | ✅ Supported |
| OpenGL 4.0 | Core | ✅ Supported |
| OpenGL 4.1 | Core | ✅ Supported |
| OpenGL 4.5 | Core | ✅ Supported |
| OpenGL 4.6 | Core | ✅ Supported |

## Platform Support

| Platform | Status | Notes |
|----------|--------|-------|
| Windows | ✅ | Primary target |
| Linux | ✅ | X11/Wayland |
| macOS | ✅ | Deprecated OpenGL |

## Window Configuration

```csharp
var config = new GlfwConfig
{
    Width = 1920,
    Height = 1080,
    Title = "My Game",
    Resizable = true,
    Visible = true,
    OpenGLVersion = (3, 3),
    OpenGLProfile = OpenGLProfile.Core
};

var window = new GlfwWindow(config);
```

## Input System

```csharp
// Keyboard input
window.OnKey += (key, scancode, action, mods) =>
{
    if (key == Key.Escape && action == InputAction.Press)
    {
        window.Close();
    }
};

// Mouse input
window.OnMouseButton += (button, action, mods) =>
{
    if (button == MouseButton.Left && action == InputAction.Press)
    {
        HandleClick(window.CursorPosition);
    }
};

// Gamepad input
window.OnGamepadButton += (gamepad, button, action) =>
{
    HandleGamepadInput(button, action);
};
```

## OpenGL Integration

```csharp
// Initialize OpenGL context
var context = new OpenGLContext(window);
context.MakeCurrent();

// Compile shaders
var vertexShader = context.CompileShader(ShaderType.Vertex, vertexSource);
var fragmentShader = context.CompileShader(ShaderType.Fragment, fragmentSource);
var program = context.CreateProgram(vertexShader, fragmentShader);

// Render loop
while (window.IsOpen)
{
    context.Clear();
    
    // Use shader program
    context.UseProgram(program);
    
    // Draw geometry
    context.DrawArrays(PrimitiveType.Triangles, 0, 3);
    
    window.SwapBuffers();
    Glfw.PollEvents();
}
```

## Monitor Support

```csharp
// Get all monitors
var monitors = window.GetMonitors();

// Handle fullscreen
window.SetMonitor(monitor, 0, 0, mode.Width, mode.Height, refreshRate);

// Monitor events
window.OnMonitorConnected += (monitor, connectionState) =>
{
    Console.WriteLine($"Monitor {monitor.Name}: {connectionState}");
};
```

## Memory Management

- Automatic cleanup of OpenGL resources
- Proper context disposal
- Native handle release on window close

## Performance Characteristics

- Direct OpenGL access for maximum performance
- Low-level input handling
- Minimal abstraction overhead
- VSync support

## Related

- [[extensions/graphic-sdl2|SDL2 Extension]]
- [[extensions/graphic-sfml|SFML Extension]]
- [[extensions/index|Extensions Index]]
