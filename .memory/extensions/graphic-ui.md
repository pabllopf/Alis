# Extension: Graphic.Ui

tags:
  - extension,plugin,add-on

## Overview

| Property | Value |
|----------|-------|
| **Namespace** | `Alis.Extension.Graphic.Ui` |
| **Version** | 1.0.0 |
| **License** | GPLv3 |
| **Author** | Pablo Perdomo Falcón |
| **Layer** | 4_Operation |
| **Dependencies** | Alis.Core |

## Purpose

The Ui extension provides an immediate-mode GUI framework for game tools, editors, and debug interfaces. It supports widgets, layouts, themes, and input handling.

## Architecture

```
┌─────────────────────────────────────────┐
│           Application Layer             │
├─────────────────────────────────────────┤
│        Alis.Extension.Graphic.Ui        │
├──────────────┬──────────────┬───────────┤
│    Widgets   │    Layout    │   Theme   │
├──────────────┼──────────────┼───────────┤
│  Button      │  Horizontal  │  Default  │
│  TextBox     │  Vertical    │  Dark     │
│  CheckBox    │  Grid        │  Light    │
│  Slider      │  Dock        │  Custom   │
│  ListBox     │  Split       │           │
│  TreeView    │               │           │
│  Menu        │               │           │
└──────────────┴──────────────┴───────────┘
```

## Core Components

### UiManager

```csharp
public class UiManager
```

Central manager for UI rendering and input.

**Responsibilities:**
- Manage UI state
- Handle input routing
- Render widgets
- Manage layouts

**Key Methods:**
- `Begin()` — Start new UI frame
- `End()` — End UI frame
- `Draw()` — Render all widgets
- `ProcessInput(InputEvent e)` — Handle input events

### Widgets

#### Button

```csharp
if (ui.Button("Click Me"))
{
    // Handle click
}
```

#### TextBox

```csharp
string text = ui.TextBox("Input:", currentValue);
```

#### CheckBox

```csharp
bool enabled = ui.CheckBox("Enable Feature", currentValue);
```

#### Slider

```csharp
float value = ui.Slider("Speed:", currentValue, min: 0f, max: 10f);
```

#### ListBox

```csharp
int selectedIndex = ui.ListBox("Items:", items, currentIndex);
```

#### TreeView

```csharp
var selectedNode = ui.TreeView("Hierarchy:", treeRoot);
```

## Layout System

### Horizontal Layout

```csharp
ui.BeginHorizontal();
ui.Button("Left");
ui.Button("Center");
ui.Button("Right");
ui.EndHorizontal();
```

### Vertical Layout

```csharp
ui.BeginVertical();
ui.Button("Top");
ui.Button("Middle");
ui.Button("Bottom");
ui.EndVertical();
```

### Grid Layout

```csharp
ui.BeginGrid(columns: 3);
ui.Button("Cell 1");
ui.Button("Cell 2");
ui.Button("Cell 3");
ui.Button("Cell 4");
ui.EndGrid();
```

### Dock Layout

```csharp
ui.BeginDock();
ui.DockLeft("Explorer", 200);
ui.DockRight("Properties", 250);
ui.DockFill("Viewport");
ui.EndDock();
```

## Theming

### Default Theme

```csharp
ui.SetTheme(new DefaultTheme());
```

### Dark Theme

```csharp
ui.SetTheme(new DarkTheme());
```

### Custom Theme

```csharp
ui.SetTheme(new UiTheme
{
    BackgroundColor = new Color(30, 30, 30),
    TextColor = new Color(200, 200, 200),
    ButtonColor = new Color(60, 60, 60),
    ButtonHoverColor = new Color(80, 80, 80),
    ButtonActiveColor = new Color(40, 40, 40),
    BorderColor = new Color(100, 100, 100),
    FontSize = 14
});
```

## Input Handling

```csharp
// Route input to UI
ui.ProcessInput(new UiInputEvent
{
    MousePosition = input.MousePosition,
    MouseButtons = input.MouseButtons,
    KeyboardKeys = input.KeyboardKeys,
    TextInput = input.TextInput
});

// Check if UI is consuming input
if (ui.WantCaptureMouse)
{
    // Don't process game input
}

if (ui.WantCaptureKeyboard)
{
    // Don't process game input
}
```

## Window System

```csharp
if (ui.BeginWindow("My Window", ref isOpen))
{
    ui.Text("Window content here");
    
    if (ui.Button("Action"))
    {
        DoSomething();
    }
    
    ui.EndWindow();
}
```

## Menu System

```csharp
if (ui.BeginMainMenuBar())
{
    if (ui.BeginMenu("File"))
    {
        if (ui.MenuItem("New")) { NewFile(); }
        if (ui.MenuItem("Open")) { OpenFile(); }
        if (ui.MenuItem("Save")) { SaveFile(); }
        ui.EndMenu();
    }
    
    if (ui.BeginMenu("Edit"))
    {
        if (ui.MenuItem("Undo")) { Undo(); }
        if (ui.MenuItem("Redo")) { Redo(); }
        ui.EndMenu();
    }
    
    ui.EndMainMenuBar();
}
```

## Styling

```csharp
// Push style
ui.PushStyle(new UiStyle
{
    FontSize = 16,
    ItemSpacing = new Vector2(8, 4)
});

// Widgets use this style
ui.Button("Styled Button");

// Pop style
ui.PopStyle();
```

## Platform Support

| Platform | Status | Notes |
|----------|--------|-------|
| Windows | ✅ | Full support |
| Linux | ✅ | Full support |
| macOS | ✅ | Full support |
| Web (WASM) | ✅ | Via WebGL |

## Performance Characteristics

- Immediate-mode rendering (no retained state)
- Efficient vertex buffer batching
- Minimal memory allocations
- Fast widget creation/destruction

## Related

- [[extensions/index|Extensions Index]]
- [[architecture/repository-overview|Repository Overview]]
- [[system/indexes/services-index|Services Index]]
