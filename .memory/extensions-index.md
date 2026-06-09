---
title: Extensions Index
tags:
  - extension
  - plugin
  - add-on
  - documentation
lastUpdated: 2026-06-09

status: Draft

license: GPLv3

---



## Overview

Alis provides 11 extensions that add functionality to the core engine. Each extension is in the `4_Operation` layer and depends on `Alis.Core`.

## Extensions by Category

### Graphics Backends

| Extension | Purpose | Platform |
|-----------|---------|----------|
| [[graphic-sfml\|Graphic.Sfml]] | SFML graphics/audio/windowing | Windows, Linux, macOS |
| [[graphic-glfw\|Graphic.Glfw]] | GLFW windowing + OpenGL | Windows, Linux, macOS |
| [[graphic-sdl2\|Graphic.Sdl2]] | SDL2 graphics/audio/windowing | All platforms |
| [[graphic-ui\|Graphic.Ui]] | Immediate-mode GUI framework | All platforms |

### Language & Dialogue

| Extension | Purpose | Features |
|-----------|---------|----------|
| [[translator\|Language.Translator]] | Internationalization (i18n) | Runtime language switching |
| [[dialogue\|Language.Dialogue]] | Dialogue scripting system | Branching conversations |

### Media & Performance

| Extension | Purpose | Features |
|-----------|---------|----------|
| [[ffmpeg\|Media.FFmpeg]] | Media processing | Video/audio encoding |
| [[thread\|Thread]] | Threading utilities | Thread pools, synchronization |
| [[profile\|Profile]] | Performance profiling | CPU/memory/frame timing |

### Cloud & Updates

| Extension | Purpose | Features |
|-----------|---------|----------|
| [[cloud-googledrive\|Cloud.GoogleDrive]] | Cloud storage integration | File sync/backup |
| [[updater\|Updater]] | Auto-update system | Check/download/apply updates |

## Extension Architecture

```
┌─────────────────────────────────────────────────────────┐
│                    Application Layer                     │
├─────────────────────────────────────────────────────────┤
│                   Operation Layer (4)                    │
├─────────────┬─────────────┬─────────────┬───────────────┤
│  Graphics   │  Language   │   Media     │   Services    │
├─────────────┼─────────────┼─────────────┼───────────────┤
│ SFML        │ Translator  │ FFmpeg      │ Updater       │
│ GLFW        │ Dialogue    │             │ Thread        │
│ SDL2        │             │             │ Profile       │
│ UI          │             │             │ GoogleDrive   │
└─────────────┴─────────────┴─────────────┴───────────────┘
```

## Extension Dependencies

```
Alis.Extension.Graphic.Ui
    └── Alis.Core

Alis.Extension.Language.Dialogue
    └── Alis.Extension.Language.Translator
        └── Alis.Core

Alis.Extension.Media.FFmpeg
    └── Alis.Core
    └── FFmpeg.AutoGen (native)

Alis.Extension.Graphic.Sfml
    └── Alis.Core
    └── SFML.NET

Alis.Extension.Graphic.Glfw
    └── Alis.Core
    └── GlfwNet

Alis.Extension.Graphic.Sdl2
    └── Alis.Core
    └── SDL2-CS

Alis.Extension.Thread
    └── Alis.Core
    └── System.Threading

Alis.Extension.Profile
    └── Alis.Core

Alis.Extension.Cloud.GoogleDrive
    └── Alis.Core
    └── Google.Apis.Drive.v3

Alis.Extension.Updater
    └── Alis.Core
    └── System.Net.Http
```

## Usage Patterns

### Graphics Backend Selection

```csharp
// Choose based on platform/needs
#if SFML
    var graphics = new SFMLGraphics();
#elif GLFW
    var graphics = new OpenGLContext();
#elif SDL2
    var graphics = new SDL2Renderer();
#endif
```

### Internationalization

```csharp
// Load translations
var translator = new TranslationManager();
translator.LoadTranslations("translations");
translator.SetLanguage("es");

// Use in UI
string greeting = translator.GetTranslation("ui.greeting");
```

### Dialogue System

```csharp
// Load and play dialogue
var dialogManager = new DialogManager();
dialogManager.LoadDialogue("dialogues/intro.json");
dialogManager.StartDialogue("intro");

// Handle choices
dialogManager.OnNodeEntered += (sender, node) =>
{
    Console.WriteLine($"{node.Speaker}: {node.Text}");
};
```

### Threading

```csharp
// Parallel work
var threadManager = new ThreadManager();
threadManager.ParallelFor(0, 1000, (i) =>
{
    results[i] = ProcessItem(data[i]);
});
threadManager.WaitForAll();
```

### Profiling

```csharp
// Profile code sections
var profiler = new ProfilerService();
profiler.Start();

using (profiler.BeginSection("Render"))
{
    renderer.Draw(scene);
}

var report = profiler.GetReport();
```

## Related

- [[architecture/repository-overview|Repository Overview]]
- [[projects-index|Projects Index]]
- [[onboarding/getting-started|Getting Started]]

## Cross-References

- [[applications-index|Applications Index]] - Applications using extensions
- [[concepts-index|Concepts Index]] - Patterns implemented in extensions
- [[glossary-index|Glossary Index]] - Terms related to extensions
