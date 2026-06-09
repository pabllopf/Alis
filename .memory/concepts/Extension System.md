# Extension System

Alis provides 18+ modular extensions organized under `1_Presentation/Extension/`.

## Extension Categories

### Graphics
- `Graphic.Ui` - UI framework
- `Graphic.Sfml` - Simple Fast Multimedia Library wrapper
- `Graphic.Glfw` - OpenGL context management
- `Graphic.Sdl2` - Simple DirectMedia Layer 2

### Cloud & Storage
- `Cloud.DropBox` - Dropbox integration
- `Cloud.GoogleDrive` - Google Drive integration

### Payment & Security
- `Payment.Stripe` - Stripe payment processing
- `Security` - Security abstractions

### Network & Communication
- `Network` - Network layer abstractions

### I/O Operations
- `Io.FileDialog` - File dialog interface

### Media Processing
- `Media.FFmpeg` - FFmpeg multimedia framework wrapper

### Math & Algorithms
- `Math.ProceduralDungeon` - Procedural dungeon generation
- `Math.HighSpeedPriorityQueue` - High-performance priority queue

### Communication & Localization
- `Thread` - Threading abstractions
- `Language.Translator` - Translation services
- `Language.Dialogue` - Dialogue system

### System Management
- `Updater` - Application update mechanism
- `Profile` - User profile management

### Advertising
- `Ads.GoogleAds` - Google Ads integration

## Extension Architecture

Each extension follows a consistent pattern:
1. Abstraction layer (interface definitions)
2. Implementation layer (platform-specific code)
3. Integration with main engine

## See Also
- [[Layered Architecture]]
- [[Solution Composition]]
