---
title: Alis.App.Hub
tags:
  - project
  - hub
  - launcher
  - layer-1
status: Draft
license: GPLv3
---

# Alis.App.Hub

## Overview

Application hub/launcher (Layer 1 - Presentation). Acts as the main distribution and update hub for the Alis game engine.

## Properties

| Property | Value |
|---|---|
| **Layer** | 1 - Presentation |
| **Project Path** | `1_Presentation/Hub/src/` |
| **Test Project** | `Alis.App.Hub.Test` |
| **Generator** | Referenced from lower layers |
| **Has Samples** | No |

## Dependencies

- **Depends On**: [[Alis]] (Layer 2 - Application)

## Architecture

- `src/Assets/` - Hub assets
- `src/Core/` - Hub core logic
- `src/Entity/` - Entity definitions
- `src/Properties/` - Build properties (Info.plist, logo)
- `src/Utils/` - Utility classes
- `src/Windows/` - Window management

## Build Integration

The Hub orchestrates the build of Engine and Installer projects via MSBuild targets:
1. After its own build, triggers Engine and Installer builds
2. Copies Engine output to `Editor/` subdirectory
3. Copies Installer output to `Installer/` subdirectory

## Testing

- Test project: `Alis.App.Hub.Test`
- Located at `1_Presentation/Hub/test/`

## Related

- [[Alis.App.Engine]]
- [[Alis.App.Installer]]
- [[Alis]]
- [[Projects Index]]
