---
title: Alis.App.Installer
tags:
  - project
  - installer
  - setup
  - layer-1
status: Draft
license: GPLv3
---

# Alis.App.Installer

## Overview

Installation and setup application (Layer 1 - Presentation). Provides cross-platform installation experience for the Alis engine.

## Properties

| Property | Value |
|---|---|
| **Layer** | 1 - Presentation |
| **Project Path** | `1_Presentation/Installer/src/` |
| **Test Project** | `Alis.App.Installer.Test` |
| **Generator** | Referenced from lower layers |
| **Has Samples** | No |

## Dependencies

- **Depends On**: [[Alis]] (Layer 2 - Application)

## Architecture

- `src/Assets/` - Installer assets
- Flat file structure with installer logic

## Build Integration

Built as part of the Hub build pipeline, bundled into the installer directory.

## Testing

- Test project: `Alis.App.Installer.Test`
- Located at `1_Presentation/Installer/test/`

## Related

- [[Alis.App.Hub]]
- [[Alis.App.Engine]]
- [[Projects Index]]
