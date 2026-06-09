# Application Composition

Alis organizes applications and samples across multiple layers with clear separation of concerns.

## Application Layers

### 1_Presentation
User-facing applications:
- **Engine** - Main runtime engine
- **Hub** - Hub application
- **Installer** - Installation application

### 2_Application
Main application and samples:
- **Alis/src** - Main application entry point
- **samples/** - 12 sample games (Web + Desktop variants)

## Sample Games

| Sample | Type | Platforms |
|--------|------|-----------|
| King.Platform | Platformer | Web, Desktop |
| Flappy.Bird | Arcade | Web, Desktop |
| Space.Simulator | Simulation | Web, Desktop |
| Dino | Runner | Web, Desktop |
| Empty | Template | Web, Desktop |
| Pong | Arcade | Web, Desktop |
| SplitCamera | Camera Demo | Web, Desktop |
| Asteroid | Shooter | Web, Desktop, iOS, Android |
| Rogue | Roguelike | Web, Desktop |
| Snake | Arcade | Web, Desktop |
| RuinsOfTartarus | RPG Demo | Web, Desktop |
| Egg | Abstract | Web, Desktop |
| Inefable | Abstract | Web, Desktop |

## Platform Variants

Each sample includes:
- `web/` - Blazor WebAssembly version
- `desktop/` - Desktop application version
- Some include mobile variants (iOS, Android)

## See Also
- [[Multi-Platform Samples]]
- [[Layered Architecture]]
