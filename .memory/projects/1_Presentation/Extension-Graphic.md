---
title: Graphic Extensions
tags:
  - presentation
  - application
  - extension
  - documentation

status: Draft

license: GPLv3

---


## Alis.Extension.Graphic.Ui
- **Path**: `1_Presentation/Extension/Graphic/Ui/src/`
- **Type**: UI framework library
- **Purpose**: Provides UI components and rendering for ALIS applications

## Alis.Extension.Graphic.Shader
- **Path**: `1_Presentation/Extension/Graphic/Shader/src/`
- **Type**: Shader management library
- **Purpose**: Shader compilation, loading, and management for graphics pipeline

## Common Pattern
Both Graphic extensions follow the standard extension pattern:
- src/ — Main library
- test/ — Unit tests (SonarQube excluded)
- sample/ — Sample applications

## Dependencies
- [[Alis]] (2_Application)
- All generators from 3_Structuration, 4_Operation, 5_Declaration, 6_Ideation

## Related
- [[projects/1_Presentation/Extension]] — Extension overview
- [[projects/1_Presentation/Alis.Extension.Graphic.Ui]] — UI extension
- [[projects/1_Presentation/Alis.Extension.Graphic.Sfml]] — SFML extension
- [[projects/1_Presentation/Alis.Extension.Graphic.Glfw]] — GLFW extension
- [[projects/1_Presentation/Alis.Extension.Graphic.Sdl2]] — SDL2 extension
- [[Extension System]] — Concept overview
- [[Multi-Platform Samples]] — Graphic samples
- [[projects/Index]] — All project docs
