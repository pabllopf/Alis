# Layer Index — ALIS

## Layer 1: Presentation (1_Presentation)

- **Purpose**: User-facing applications, extensions, and benchmarks
- **Project Count**: ~60
- **Dependencies**: References 2_Application; receives generators from 3–6
- **Key Projects**:
  - **Alis.App.Engine** — Main game engine/editor application
  - **Alis.App.Hub** — Project management hub
  - **Alis.App.Installer** — Installation wizard
  - **Alis.Benchmark** — Performance benchmarking
  - **19 Extensions** — Platform bindings, integrations, utilities

### Extension Categories

| Category | Extensions |
|----------|-----------|
| Graphics | Graphic.Ui, Graphic.Sfml, Graphic.Glfw, Graphic.Sdl2 |
| Cloud | Cloud.DropBox, Cloud.GoogleDrive |
| Language | Language.Translator, Language.Dialogue |
| Math | Math.ProceduralDungeon, Math.HighSpeedPriorityQueue |
| System | Updater, Profile, Thread |
| Payment | Payment.Stripe |
| Security | Security |
| Ads | Ads.GoogleAds |
| I/O | Io.FileDialog |
| Network | Network |
| Media | Media.FFmpeg |

---

## Layer 2: Application (2_Application)

- **Purpose**: Core application framework and game samples
- **Project Count**: ~30
- **Dependencies**: References 3_Structuration; receives generators from 3–6
- **Key Projects**:
  - **Alis** — Core application framework
  - **14 Game Samples** — Each with Desktop + Web targets (28 projects total)
  - **Special**: Asteroid has iOS and Android targets (4 platforms — most multi-platform sample)

---

## Layer 3: Structuration (3_Structuration)

- **Purpose**: Core engine aggregation (zero hand-written code)
- **Project Count**: 3
- **Dependencies**: References 4_Operation; receives generators from 4–6
- **Key Projects**:
  - **Alis.Core** — Aggregator that re-exports all 4_Operation types
  - **Alis.Core.Test** — Tests
  - **Alis.Core.Sample** — Usage examples

---

## Layer 4: Operation (4_Operation)

- **Purpose**: Core engine subsystems
- **Project Count**: 14 (4 subsystems × {src, test, sample} + 2 generators)
- **Dependencies**: References 5_Declaration; receives generators from 5–6
- **Key Subsystems**:

| Subsystem | Source Files | Description |
|-----------|-------------|-------------|
| **Ecs** | ~108 | Entity Component System — archetype-based, cache-optimized |
| **Graphic** | ~147 | Graphics rendering — shaders, textures, meshes, materials |
| **Audio** | ~7 | Cross-platform audio playback |
| **Physic** | ~194 | 2D physics engine — collisions, controllers, joints |

Each subsystem follows the `src/test/sample/Generator` project structure.

---

## Layer 5: Declaration (5_Declaration)

- **Purpose**: Aspect system aggregation (zero hand-written code)
- **Project Count**: 3
- **Dependencies**: References 6_Ideation; receives generators from 6
- **Key Projects**:
  - **Alis.Core.Aspect** — Aggregator that re-exports all 6_Ideation types
  - **Alis.Core.Aspect.Test** — Tests
  - **Alis.Core.Aspect.Sample** — Usage examples

---

## Layer 6: Ideation (6_Ideation)

- **Purpose**: Aspect definitions with source generators
- **Project Count**: ~24 (6 aspects × {src, test, sample} + 4 generators)
- **Dependencies**: None (leaf layer)
- **Key Aspects**:

| Aspect | Source Files | Purpose |
|--------|-------------|---------|
| **Memory** | ~3 | ZIP-based asset management with dual-cache (in-memory + disk) |
| **Fluent** | ~128 | Fluent builder API with 120+ marker interfaces |
| **Data** | ~18 | Custom JSON parser (AOT-compatible) |
| **Math** | ~29 | Value-type vectors, matrices, shapes (zero GC) |
| **Time** | ~1 | High-resolution clock |
| **Logging** | ~24 | Structured logging with pluggable pipeline |

---

## Cross-Layer Relationships

```mermaid
graph TB
    subgraph "Layer 1: Presentation"
        L1[Engine, Hub, Installer, 19 Extensions, Benchmark]
    end
    subgraph "Layer 2: Application"
        L2[Alis Core App, 13 Game Samples]
    end
    subgraph "Layer 3: Structuration"
        L3[Alis.Core Aggregator]
    end
    subgraph "Layer 4: Operation"
        L4a[ECS]
        L4b[Graphic]
        L4c[Audio]
        L4d[Physic]
    end
    subgraph "Layer 5: Declaration"
        L5[Alis.Core.Aspect Aggregator]
    end
    subgraph "Layer 6: Ideation"
        L6a[Memory]
        L6b[Fluent]
        L6c[Math]
        L6d[Time]
        L6e[Data]
        L6f[Logging]
    end

    L1 --> L2
    L2 --> L3
    L3 --> L4a
    L3 --> L4b
    L3 --> L4c
    L3 --> L4d
    L4a --> L5
    L4b --> L5
    L4c --> L5
    L4d --> L5
    L5 --> L6a
    L5 --> L6b
    L5 --> L6c
    L5 --> L6d
    L5 --> L6e
    L5 --> L6f
```

---

## Related Documentation

- [[system/indexes/projects-index]] — Complete project inventory
- [[system/indexes/dependency-index]] — Dependencies
- [[architecture/repository-overview]] — Architecture overview
