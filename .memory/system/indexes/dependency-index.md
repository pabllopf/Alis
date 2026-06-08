# Dependency Index

## Project Dependencies

### Core Dependencies

| Dependency | Projects | Purpose |
|---|---|---|
| Alis.Core | All projects | Base abstractions |
| System.Memory | ECS, Graphic | Span<T>, Memory<T> |
| System.Runtime.CompilerServices.Unsafe | ECS | Low-level memory ops |

### Platform Dependencies

| Dependency | Projects | Purpose |
|---|---|---|
| SFML | Graphic | Cross-platform graphics |
| GLFW | Graphic | Window management |
| SDL2 | Graphic | Graphics/audio backend |
| OpenGL | Graphic, ECS | 3D rendering |

### Extension Dependencies

| Dependency | Projects | Purpose |
|---|---|---|
| Stripe SDK | Payment.Stripe | Payment processing |
| Dropbox SDK | Cloud.DropBox | Cloud storage |
| Google Drive API | Cloud.GoogleDrive | Cloud storage |

## Dependency Graph

See: [[dependencies/dependency-graph]]

## Violations

- None detected - Architecture well-separated
