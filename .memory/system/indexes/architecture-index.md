# Architecture Index

## Architectural Patterns

1. **ECS (Entity Component System)** - Core game logic architecture
2. **AOP (Aspect-Oriented Programming)** - Cross-cutting concerns
3. **Layered Architecture** - Clear separation of concerns
4. **Plugin System** - Extension-based modularity

## Layer Boundaries

- **Core (3_Structuration)**: Base abstractions
- **Operation (4_Operation)**: Engine systems (ECS, Graphic, Audio, Physic)
- **Ideation (6_Ideation)**: Advanced aspects
- **Presentation (1_Presentation)**: User-facing applications

## Key Components

| Component | Purpose | Projects |
|---|---|---|
| Scene Manager | Entity and component management | Alis.Core.Ecs |
| Graphics Renderer | 2D/3D rendering | Alis.Core.Graphic |
| Asset Registry | Embedded asset management | Alis.Core.Aspect.Memory |
| Query System | ECS query filtering | Alis.Core.Ecs |

## Architecture Decisions

1. **Pure ECS**: No inheritance-based entity hierarchy
2. **Value Types**: Heavy use of structs for performance
3. **Unsafe Code**: Direct memory manipulation for speed
4. **Multi-targeting**: Support multiple .NET versions
