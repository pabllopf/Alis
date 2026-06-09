# Alis.Extension.Graphic.Glfw

tags:
  - presentation,application,extension,documentation

## Overview
Cross-platform OpenGL context management and windowing library using GLFW 3.

**Author**: Pablo Perdomo Falcón  
**License**: GNU General Public License v3.0  
**Total Lines of Code**: ~9,000 lines across multiple source files

## Project Details
- **Layer**: 1_Presentation
- **Type**: Library (Graphics Extension)
- **Framework**: net8.0
- **Output Type**: Class Library

## Purpose
Provides a simplified C# interface for creating and managing OpenGL windows across Windows, macOS, and Linux using GLFW 3 native library. Wraps unmanaged GLFW functions with managed .NET types and events.

## Key Components

### Core Classes
- **NativeWindow** - Main window class providing managed wrapper around GLFW windows
  - Supports window creation, resizing, positioning, and destruction
  - Event-driven architecture for user interactions
  - Full-screen and windowed mode support
  
- **Window** - Low-level GLFW window wrapper
  - Native handle management via SafeHandleZeroOrMinusOneIsInvalid
  - Callback registration and management
  
- **Vulkan** - Vulkan API support integration
  - Vulkan loader detection
  - Instance creation for Vulkan rendering

### Callback Delegates
- WindowMaximizedCallback
- PositionCallback
- SizeCallback
- IconifyCallback
- JoystickCallback
- FileDropCallback

### Enums & Structs
- **ModifierKeys** - Keyboard modifier states
- **Monitor** - Display monitor information
- **Window** - Window handle and properties

## Dependencies
- [[Alis]] (2_Application) - Core application framework
- [[Alis.Core.Graphic]] (4_Operation) - Graphics primitives

## Build Configuration
- **LangVersion**: 13
- **Nullable**: enabled
- **AllowUnsafeBlocks**: true (required for P/Invoke)
- **SonarQubeExclusions**: S3897, S4035 (inherited SafeHandle fields)

## Platform Support
- Windows (x64, x86)
- macOS (Intel, ARM64)
- Linux (x64, arm64, arm)

## Testing Status
- **Unit Tests**: Present (Alis.Extension.Graphic.Glfw.Test)
- **SonarQube**: Excluded from analysis (native interop complexity)
- **Sample Apps**: Included for demonstration

## Architecture Notes
1. Uses P/Invoke for native GLFW library calls
2. Implements SafeHandle pattern for proper resource cleanup
3. Callback pinning prevents GC collection of delegates
4. Event-based design for UI interactions

## Known Limitations
- Native library dependencies required per platform
- No automatic resource leak detection in managed layer
- Platform-specific build configurations needed

## Related Projects
- [[Alis.Extension.Graphic.Sdl2]] - SDL2 binding alternative
- [[Alis.Extension.Graphic.Sfml]] - SFML binding alternative  
- [[Alis.Extension.Graphic.Ui]] - UI component framework

## Documentation Version
Auto-generated from source code analysis. Last updated: 2026-06-08
