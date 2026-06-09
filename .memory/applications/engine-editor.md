---
title: Alis.App.Engine
tags:
  - application
  - software
  - tool

status: draft

license: GPLv3
---


## Overview

| Property | Value |
|----------|-------|
| **Namespace** | `Alis.App.Engine` |
| **Version** | 1.0.0 |
| **License** | GPLv3 |
| **Author** | Pablo Perdomo Falcón |
| **Layer** | 1_Presentation |
| **Dependencies** | Alis.Core, Alis.Extension.Graphic.Glfw, ImGui.NET |

## Purpose

Alis.App.Engine is the primary game editor for the Alis game engine. It provides a comprehensive visual development environment using ImGui for the interface, supporting scene editing, asset management, and runtime debugging.

## Architecture

```
┌─────────────────────────────────────────────────────────┐
│                    Alis.App.Engine                       │
├─────────────┬─────────────┬─────────────┬───────────────┤
│  Windows    │   Menus     │   Demos     │   Services    │
├─────────────┼─────────────┼─────────────┼───────────────┤
│ Console     │ File        │ Pong        │ FontService   │
│ Game        │ Edit        │ Breakout    │ ImGuiService  │
│ Scene       │ View        │ Platformer  │ WindowService │
│ Inspector   │ Tools       │ RPG         │               │
│ Assets      │ Help        │ Shooter     │               │
│ AudioPlayer │             │             │               │
│ Solution    │             │             │               │
│ Project     │             │             │               │
│ Settings    │             │             │               │
│ Demos       │             │             │               │
└─────────────┴─────────────┴─────────────┴───────────────┘
```

## Editor Windows

### Console Window

```csharp
public class ConsoleWindow : IWindow
```

Displays log messages, warnings, and errors.

**Features:**
- Color-coded log levels (Info, Warning, Error)
- Search and filter
- Auto-scroll
- Clear history

### Game Window

```csharp
public class GameWindow : IWindow
```

Renders the game viewport.

**Features:**
- Real-time game rendering
- Camera controls (pan, zoom)
- Play/Pause/Stop controls
- Resolution selector

### Scene Window

```csharp
public class SceneWindow : IWindow
```

Displays the scene hierarchy.

**Features:**
- Entity tree view
- Drag-and-drop reordering
- Multi-select
- Create/delete entities

### Inspector Window

```csharp
public class InspectorWindow : IWindow
```

Shows properties of selected entity.

**Features:**
- Component list
- Property editing
- Add/remove components
- Value validation

### Assets Window

```csharp
public class AssetsWindow : IWindow
```

File browser for project assets.

**Features:**
- Folder tree
- Thumbnail previews
- Import settings
- Drag-and-drop to scene

### AudioPlayer Window

```csharp
public class AudioPlayerWindow : IWindow
```

Audio preview and mixing.

**Features:**
- Play/stop/pause
- Volume control
- Spatial audio preview
- Audio bus visualization

### Solution Window

```csharp
public class SolutionWindow : IWindow
```

Project file management.

**Features:**
- Solution tree view
- Add/remove projects
- Build configuration
- NuGet package management

### Project Window

```csharp
public class ProjectWindow : IWindow
```

Project settings and configuration.

**Features:**
- Build settings
- Player settings
- Quality settings
- Input settings

### Settings Window

```csharp
public class SettingsWindow : IWindow
```

Editor preferences.

**Features:**
- Theme selection
- Key bindings
- Grid settings
- Auto-save options

### Demos Window

```csharp
public class DemosWindow : IWindow
```

Built-in demo scenes.

**Features:**
- Demo gallery
- One-click launch
- Performance metrics

## Menu System

### File Menu

| Item | Action | Shortcut |
|------|--------|----------|
| New Scene | Create empty scene | Ctrl+N |
| Open Scene | Open existing scene | Ctrl+O |
| Save Scene | Save current scene | Ctrl+S |
| Save As | Save with new name | Ctrl+Shift+S |
| Import Asset | Import file to project | Ctrl+I |
| Exit | Close editor | Alt+F4 |

### Edit Menu

| Item | Action | Shortcut |
|------|--------|----------|
| Undo | Undo last action | Ctrl+Z |
| Redo | Redo last action | Ctrl+Y |
| Cut | Cut selection | Ctrl+X |
| Copy | Copy selection | Ctrl+C |
| Paste | Paste clipboard | Ctrl+V |
| Delete | Delete selection | Del |

### View Menu

| Item | Action |
|------|--------|
| Console | Toggle console window |
| Game | Toggle game window |
| Scene | Toggle scene window |
| Inspector | Toggle inspector window |
| Assets | Toggle assets window |

### Tools Menu

| Item | Action |
|------|--------|
| Build | Build project |
| Run | Run game |
| Profiler | Open profiler |
| Debugger | Attach debugger |

## Demo Scenes

| Demo | Description |
|------|-------------|
| Pong | Classic 2-player pong |
| Breakout | Brick-breaking game |
| Platformer | 2D platformer example |
| RPG | Top-down RPG demo |
| Shooter | Space shooter demo |

## ImGui Integration

```csharp
// Initialize ImGui
var imGuiService = new ImGuiService(window);
imGuiService.Initialize();

// Render loop
while (window.IsOpen)
{
    imGuiService.NewFrame();
    
    // Render editor windows
    consoleWindow.Draw();
    gameWindow.Draw();
    sceneWindow.Draw();
    inspectorWindow.Draw();
    
    imGuiService.Render();
    window.SwapBuffers();
}
```

## Font Management

```csharp
public class FontService
{
    // Load fonts
    public ImFontPtr LoadFont(string path, float size);
    
    // Built-in fonts
    public ImFontPtr DefaultFont { get; }
    public ImFontPtr MonoFont { get; }
    public ImFontPtr BoldFont { get; }
}
```

## Configuration

```json
{
  "editor": {
    "width": 1920,
    "height": 1080,
    "theme": "dark",
    "autoSave": true,
    "autoSaveInterval": 300,
    "gridSnap": true,
    "gridSize": 0.1
  }
}
```

## Platform Support

| Platform | Status | Notes |
|----------|--------|-------|
| Windows | ✅ | Primary target |
| Linux | ✅ | Full support |
| macOS | ✅ | Full support |

## Performance

- ImGui rendering at 60+ FPS
- Minimal CPU usage when idle
- Efficient asset loading
- Lazy widget updates

## Related

- [[applications/hub|Hub Application]]
- [[applications/installer|Installer]]
- [[extensions/graphic-glfw|GLFW Extension]]
- [[architecture/repository-overview|Repository Overview]]
