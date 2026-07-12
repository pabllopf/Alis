---
title: Alis.App.Hub
tags:
  - presentation
  - hub
  - launcher
status: Draft
license: GPLv3
---

# Alis.App.Hub

**Layer:** 1_Presentation
**Path:** `1_Presentation/Hub/src/Alis.App.Hub.csproj`

## Purpose

Hub/launcher application for managing Alis installations, projects, and community resources.

## Features

- Gallery of installed games/examples
- Project management
- Learning resources
- Community section
- Editor installation management
- GitHub releases integration

## Architecture

- `HubEngine.cs` — Main hub class
- `Windows/` — Window management (Hub main window, sections)
- `Entity/` — Data models (Gallery, GalleryItem, InstalledVersion, LearningResource, Project)
- `Core/` — Runtime abstractions
- `Utils/` — Utilities (ImageLoader)

## Dependencies

- Alis (2_Application)

## Related Documents

- [[Alis]]
- [[Alis.App.Engine]]
