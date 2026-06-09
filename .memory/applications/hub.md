---
title: Alis.App.Hub
tags: [application,software,tool]
---


## Overview

| Property | Value |
|----------|-------|
| **Namespace** | `Alis.App.Hub` |
| **Version** | 1.0.0 |
| **License** | GPLv3 |
| **Author** | Pablo Perdomo Falcón |
| **Layer** | 1_Presentation |
| **Dependencies** | Alis.Core, Alis.Extension.Graphic.Sdl2 |

## Purpose

Alis.App.Hub is a standalone launcher application for managing Alis projects, accessing documentation, and community resources. It serves as the central entry point for users.

## Architecture

```
┌─────────────────────────────────────────────────────────┐
│                     Alis.App.Hub                        │
├─────────────┬─────────────┬─────────────┬───────────────┤
│   Sections  │   Widgets   │   Services  │   Config      │
├─────────────┼─────────────┼─────────────┼───────────────┤
│ Projects    │ ProjectCard │ HubService  │ HubConfig     │
│ Releases    │ ReleaseCard │ UpdateService│ ProjectManager│
│ Community   │ NewsCard    │ LinkService │               │
│ Learn       │ TutorialCard│             │               │
│ Editor      │             │             │               │
│ Installation│             │             │               │
└─────────────┴─────────────┴─────────────┴───────────────┘
```

## Sections

### Projects Section

```csharp
public class ProjectsSection : ISection
```

Manages Alis projects.

**Features:**
- List all projects
- Create new project
- Open existing project
- Import project
- Delete project
- Project templates

**UI Elements:**
- Project cards with thumbnails
- Search and filter
- Sort by name/date/size

### Releases Section

```csharp
public class ReleasesSection : ISection
```

Shows available Alis releases.

**Features:**
- List stable releases
- List beta releases
- View release notes
- Download updates
- Changelog viewer

### Community Section

```csharp
public class CommunitySection : ISection
```

Community resources and social links.

**Features:**
- Discord server link
- GitHub repository
- Forum link
- Twitter feed
- Community showcase

### Learn Section

```csharp
public class LearnSection : ISection
```

Documentation and tutorials.

**Features:**
- Getting started guide
- Video tutorials
- API documentation
- Sample projects
- FAQ

### Editor Installation Section

```csharp
public class EditorInstallationSection : ISection
```

Editor installation and configuration.

**Features:**
- Install editor
- Update editor
- Configure editor path
- Install extensions

## Core Components

### HubService

```csharp
public class HubService
```

Central service for hub operations.

**Responsibilities:**
- Manage sections
- Handle navigation
- Load/save configuration
- Coordinate services

### ProjectManager

```csharp
public class ProjectManager
```

Project lifecycle management.

**Methods:**
- `GetProjects()` — List all projects
- `CreateProject(string name, string template)` — Create new project
- `OpenProject(string path)` — Open existing project
- `DeleteProject(string path)` — Delete project
- `ImportProject(string path)` — Import external project

### UpdateService

```csharp
public class UpdateService
```

Handles hub and editor updates.

**Methods:**
- `CheckForUpdates()` — Check for new versions
- `DownloadUpdate(ReleaseInfo info)` — Download update
- `ApplyUpdate()` — Install update

## Project Templates

| Template | Description | Includes |
|----------|-------------|----------|
| Empty | Blank project | Basic structure |
| 2D Game | 2D game template | Sprite, input, physics |
| 3D Game | 3D game template | Meshes, camera, lighting |
| Platformer | Platformer game | Player, enemies, levels |
| RPG | RPG template | Inventory, dialogues, quests |
| Shooter | Shooter template | Weapons, enemies, projectiles |

## UI Widgets

### ProjectCard

```csharp
public class ProjectCard
{
    public string Name { get; set; }
    public string Path { get; set; }
    public string ThumbnailPath { get; set; }
    public DateTime LastModified { get; set; }
    public string EngineVersion { get; set; }
}
```

Displays project information in a card format.

### ReleaseCard

```csharp
public class ReleaseCard
{
    public string Version { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string Channel { get; set; } // stable, beta, alpha
    public bool IsInstalled { get; set; }
    public bool UpdateAvailable { get; set; }
}
```

Displays release information.

## Configuration

```json
{
  "hub": {
    "width": 1200,
    "height": 800,
    "theme": "dark",
    "defaultSection": "projects",
    "editorPath": null,
    "recentProjects": [],
    "autoCheckUpdates": true
  }
}
```

## Navigation

```csharp
// Navigate to section
hub.NavigateTo("projects");

// Navigate with parameters
hub.NavigateTo("learn", new Dictionary<string, object>
{
    ["topic"] = "getting-started"
});

// Back navigation
hub.GoBack();
```

## Platform Support

| Platform | Status | Notes |
|----------|--------|-------|
| Windows | ✅ | Primary target |
| Linux | ✅ | Full support |
| macOS | ✅ | Full support |

## Performance

- Lazy loading of sections
- Cached project thumbnails
- Background update checks
- Responsive UI

## Related

- [[applications/engine-editor|Engine Editor]]
- [[applications/installer|Installer]]
- [[extensions/index|Extensions Index]]
- [[architecture/repository-overview|Repository Overview]]
