# Alis.Extension.Graphic.Sfml

## Overview
Simple and Fast Multimedia Library (SFML) bindings for C#.

**Author**: Pablo Perdomo Falcón  
**License**: GNU General Public License v3.0  
**Total Lines of Code**: ~1,082 lines

## Project Details
- **Layer**: 1_Presentation
- **Type**: Library (Graphics/Multimedia Extension)
- **Framework**: net8.0
- **Output Type**: Class Library

## Purpose
Provides C# bindings for SFML library, offering a simple and object-oriented multimedia API. Supports graphics, audio, window creation, and input handling with focus on simplicity and performance.

## Key Components

### Audio Subsystem
- **Chunk** - Audio sample buffer structure
  - Native pointer to audio samples
  - Sample count tracking
  
- **Sound** - Single sound playback
- **SoundStream** - Streaming audio support
- **AudioDevice** - Audio output management

### Graphics (inferred from SFML)
- Window creation and management
- 2D graphics rendering
- Sprite and texture handling
- Font and text rendering

## Dependencies
- [[Alis]] (2_Application) - Core framework
- SFML native libraries (platform-specific)

## Build Configuration
- **LangVersion**: 13
- **Nullable**: enabled
- **AllowUnsafeBlocks**: true (SFML P/Invoke)

## Platform Support
- Windows
- macOS
- Linux

## Testing Status
- **Unit Tests**: Present (Alis.Extension.Graphic.Sfml.Test)
- **Sample Apps**: Included

## Architecture Notes
1. SFML C API bindings via P/Invoke
2. Audio-focused implementation (Chunk structure)
3. Managed wrapper around native SFML library
4. Event-driven audio playback

## Known Limitations
- Native SFML libraries required per platform
- Smaller codebase than GLFW/SDL2 alternatives

## Related Projects
- [[Alis.Extension.Graphic.Glfw]] - GLFW binding alternative
- [[Alis.Extension.Graphic.Sdl2]] - SDL2 binding alternative
- [[Alis.Core.Audio]] (4_Operation) - Audio subsystem

## Documentation Version
Auto-generated from source code analysis. Last updated: 2026-06-08
