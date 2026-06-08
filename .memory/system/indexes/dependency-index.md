# Dependency Index — ALIS

## Project Dependencies Map

### Alis.App.Engine
- Alis.App.Core
- Alis.Core
- Alis.Extension.* (selected)

### Alis.App.Hub
- Alis.App.Core
- Alis.Extension.Network
- Alis.Extension.Updater

### Alis.App.Installer
- Alis.App.Core
- Alis.Extension.Updater

### Alis.Benchmark
- Alis.Core
- Alis.Core.Ecs
- Alis.Core.Graphic

### Extensions (all)
- Alis.App.Core (most)
- Alis.Core.Graphic (Graphic.* extensions)

### Game Samples (all)
- Alis.App.Core
- Alis.Core

### Alis.App.Core
- Alis.Core
- Alis.Core.Ecs
- Alis.Core.Graphic
- Alis.Core.Audio
- Alis.Core.Physic

### Alis.Core
- Alis.Core.Ecs
- Alis.Core.Graphic
- Alis.Core.Audio
- Alis.Core.Physic

### Alis.Core.Ecs (src)
- Alis.Core.Aspect

### Alis.Core.Graphic (src)
- Alis.Core.Aspect

### Alis.Core.Audio (src)
- Alis.Core.Aspect

### Alis.Core.Physic (src)
- Alis.Core.Aspect

### Alis.Core.Aspect
- (None — aggregator only)

### Ideation Aspects (all)
- Alis.Core.Aspect

## Reverse Dependency Index

### Alis.Core.Aspect (most depended upon)
- Alis.Core.Ecs (src)
- Alis.Core.Graphic (src)
- Alis.Core.Audio (src)
- Alis.Core.Physic (src)
- All Ideation aspects

### Alis.Core (most depended upon)
- Alis.App.Core
- All game samples

### Alis.App.Core
- Alis.App.Engine
- Alis.App.Hub
- Alis.App.Installer
- All extensions (most)
- All game samples
