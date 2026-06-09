---
title: Alis.Sample.Empty
tags:
  - application
  - sample
  - documentation

status: draft
---


## Overview
Empty/skeleton project built on the ALIS engine. Minimal bootstrap with `VideoGame.Create().Run()` — serves as the starting template for new ALIS game projects.

## Project Details
- **Layer**: 2_Application
- **Type**: Template/Skeleton Project
- **Framework**: `net10.0`
- **Platforms**: Desktop, Web
- **Purpose**: Project template — minimum viable ALIS game

## Platform Variants
| Platform | Project File |
|---|---|
| Desktop | `Alis.Sample.Empty.Desktop.csproj` |
| Web | `Alis.Sample.Empty.Web.csproj` |

## Dependencies
- [[projects/2_Application/Alis]] (Core application library)
- `Alis.Core.Ecs.Systems` — VideoGame

## Notes
- Intended as the starter template for new game projects
- Provides Desktop + Web dual-targeting out of the box
- No configuration, no scene setup — completely clean slate
- Ideal starting point for understanding ALIS project structure
