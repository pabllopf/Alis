# Layer Index — ALIS

## Layer 1: Presentation (1_Presentation)
- **Purpose**: User-facing applications and extensions
- **Projects**: 23
- **Dependencies**: References 2_Application
- **Key Projects**: Engine, Hub, Installer, 19 Extensions

## Layer 2: Application (2_Application)
- **Purpose**: Application layer with game samples
- **Projects**: 14
- **Dependencies**: References 3_Structuration
- **Key Projects**: App.Core, 13 Game Samples

## Layer 3: Structuration (3_Structuration)
- **Purpose**: Core engine aggregation
- **Projects**: 5
- **Dependencies**: References 4_Operation
- **Key Projects**: Core (aggregator), Ecs, Graphic, Audio, Physic

## Layer 4: Operation (4_Operation)
- **Purpose**: Core engine operations
- **Projects**: 16 (including test/sample/Generator)
- **Dependencies**: References 5_Declaration
- **Key Projects**: Ecs, Graphic, Audio, Physic (each with src/test/sample/Generator)

## Layer 5: Declaration (5_Declaration)
- **Purpose**: Aspect-oriented programming system
- **Projects**: 1
- **Dependencies**: None (aggregator only)
- **Key Projects**: Core.Aspect (aggregator)

## Layer 6: Ideation (6_Ideation)
- **Purpose**: High-level aspect definitions with source generators
- **Projects**: 24 (6 aspects × 4 sub-projects)
- **Dependencies**: References 5_Declaration
- **Key Projects**: Memory, Fluent, Math, Time, Data, Logging (each with src/test/sample/Generator)

## Related

- [[project-index]] — All projects by layer
- [[architecture-index]] — Architecture patterns
- [[dependency-index]] — Dependency rules
- [[domains-index]] — Bounded contexts
- [[Layered Architecture]] — Layer structure concept
- [[adr-001-layered-architecture]] — Layer architecture decision
- [[adr-002-aggregator-pattern]] — Aggregator pattern
- [[architecture/repository-overview]] — Architecture overview
- [[architecture/dependency-graph]] — Layer dependencies
- [[projects/Architecture]] — Project architecture
- [[indexes-summary]] — All indexes
