---
title: Multi-Platform Samples
tags:
  - concept
  - theory
  - documentation

status: draft
---


Alis includes 12+ sample games, each targeting multiple platforms demonstrating cross-platform capabilities.

## Sample Games

| Sample | Type | Platforms | Description |
|--------|------|-----------|-------------|
| King.Platform | Platformer | Web, Desktop | Platformer game mechanics |
| Flappy.Bird | Arcade | Web, Desktop | Flappy Bird clone |
| Space.Simulator | Simulation | Web, Desktop | Space simulation |
| Dino | Runner | Web, Desktop | Dino runner game |
| Empty | Template | Web, Desktop | Minimal template project |
| Pong | Arcade | Web, Desktop | Pong clone |
| SplitCamera | Camera Demo | Web, Desktop | Camera system demonstration |
| Asteroid | Shooter | Web, Desktop, iOS, Android | Asteroids clone with mobile support |
| Rogue | Roguelike | Web, Desktop | Roguelike game |
| Snake | Arcade | Web, Desktop | Snake clone |
| RuinsOfTartarus | RPG Demo | Web, Desktop | RPG demo |
| Egg | Abstract | Web, Desktop | Abstract game |
| Inefable | Abstract | Web, Desktop | Abstract game |

## Platform Support

### Desktop Platforms
- **Windows**: x64, x86
- **Linux**: x64, arm64, arm
- **macOS**: x64, arm64

### Web Platform
- **Blazor WebAssembly**: browser-wasm runtime

### Mobile Platforms
- **Android**: arm64, x64
- **iOS**: arm64, simulator-arm64, simulator-x64

## Platform Variants

Each sample includes:
- `web/` - Blazor WebAssembly version for browsers
- `desktop/` - Desktop application version
- Some samples include mobile variants (iOS, Android)

## Platform-Specific Code

Samples use conditional compilation:
```csharp
#if browserwasm
// WebAssembly-specific code
#elif winx64
// Windows x64-specific code
#elif linuxx64
// Linux x64-specific code
#endif
```

## See Also
- [[Multi-Targeting Strategy]]
- [[Platform-Specific Build Constants]]
- [[Application Composition]]
- [[Layered Architecture]]
