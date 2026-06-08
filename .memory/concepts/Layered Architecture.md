# Layered Architecture

Alis uses a 6-layer numbered directory structure that progresses from concrete to abstract:

## Layers

| # | Layer | Purpose |
|---|-------|---------|
| 1 | **Presentation** | User-facing apps (Installer, Engine, Hub) and Extensions (Graphic, Network, Cloud, etc.) |
| 2 | **Application** | Main application + sample games (12 samples, each Web/Desktop) |
| 3 | **Structuration** | Core library — foundational abstractions |
| 4 | **Operation** | Ecs, Graphic, Audio, Physic — operational systems |
| 5 | **Declaration** | Core.Aspect — declarative foundation |
| 6 | **Ideation** | Experimental aspects (Memory, Fluent, Math, Time, Data, Logging) |

## Project structure per module
Each module typically contains: `src/`, `test/`, `sample/`, and optionally `generator/`

## See Also
- [[Aspect-Oriented Design]]
- [[Solution Composition]]
- [[Generator Pattern]]
