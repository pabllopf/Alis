# Alis.Extension.Graphic.Sdl2

## Overview
Cross-platform game development library using SDL2 (Simple DirectMedia Layer).

**Author**: Pablo Perdomo Falcón  
**License**: GNU General Public License v3.0  
**Total Lines of Code**: ~2,859 lines

## Project Details
- **Layer**: 1_Presentation
- **Type**: Library (Graphics Extension)
- **Framework**: net8.0
- **Output Type**: Class Library

## Purpose
Provides C# bindings for SDL2 library, offering cross-platform window management, input handling, and multimedia capabilities. Alternative to GLFW with broader feature set including audio, joystick, and image loading.

## Key Components

### Core Interfaces
- **IWindow** - Window management interface
  - Background color control
  - Resolution management (Vector2F)
  - Resizability control
  
- **IMouse** - Mouse input handling
- **IKeyboard** - Keyboard input handling  
- **IJoystick** - Game controller support

### Mapping Classes
- **SdlScancode** - Keyboard scancode mappings
- **SdlInputConst** - Input constants
- **KeyCodes** - Keyboard key codes

### Enums
- **PackedLayout** - Memory layout options
- **WindowFlags** - Window creation flags

## Dependencies
- [[Alis.Core.Aspect.Math]] (6_Ideation) - Vector2F, Color types
- [[Alis]] (2_Application) - Core framework

## Build Configuration
- **LangVersion**: 13
- **Nullable**: enabled
- **AllowUnsafeBlocks**: true (SDL2 P/Invoke)

## Platform Support
- Windows
- macOS  
- Linux
- Android (planned)
- iOS (planned)

## Testing Status
- **Unit Tests**: Present (Alis.Extension.Graphic.Sdl2.Test)
- **Sample Apps**: Included

## Architecture Notes
1. Interface-based design for testability
2. Uses Vector2F from Math aspect for coordinates
3. SDL2 native library bindings via P/Invoke
4. Input abstraction layer for multiple devices

## Known Limitations
- Native SDL2 library required per platform
- Mobile platform support still experimental

## Related Projects
- [[Alis.Extension.Graphic.Glfw]] - GLFW alternative
- [[Alis.Extension.Graphic.Sfml]] - SFML alternative
- [[Alis.Core.Audio]] (4_Operation) - Audio subsystem

## Documentation Version
Auto-generated from source code analysis. Last updated: 2026-06-08
