# Glossary — ALIS

## Terms

### Aspect
A high-level programming construct defined in the Ideation layer (6_Ideation). Aspects are processed by source generators that output code to the Declaration layer (5_Declaration). Examples: Memory, Fluent, Math, Time, Data, Logging.

### Aggregator Project
A project that contains zero hand-written code and exists solely to aggregate and re-export types from other projects. Examples: Alis.Core, Alis.Core.Aspect.

### Bounded Context
A logical boundary around a set of related functionality. In ALIS, bounded contexts align with architectural layers and engine subsystems (ECS, Graphic, Audio, Physic).

### Declaration Layer
Layer 5 of the architecture. Contains the aspect-oriented programming system. Receives generated code from Ideation layer generators. Zero hand-written code.

### Engine Subsystem
A core engine component in the Operation layer (4_Operation). Examples: ECS, Graphic, Audio, Physic. Each has src/test/sample/Generator sub-projects.

### Generator
A Roslyn source generator (implementing ISourceGenerator) that produces code at compile time. Generators in ALIS cascade from Ideation → Declaration → Operation → Structuration → Application → Presentation.

### Ideation Layer
Layer 6 of the architecture (topmost). Contains aspect definitions and source generators. Each aspect has src/test/sample/Generator sub-projects.

### Operation Layer
Layer 4 of the architecture. Contains core engine operations (ECS, Graphic, Audio, Physic). Implements low-level engine functionality.

### Presentation Layer
Layer 1 of the architecture (outermost). Contains user-facing applications (Engine, Hub, Installer) and extensions.

### Screaming Architecture
An architecture where the folder structure "screams" the purpose of each component. ALIS uses numbered layers (1_Presentation through 6_Ideation) to make dependencies explicit.

### Source Generator
A Roslyn-based code generation tool that runs at compile time. ALIS uses source generators extensively for aspect-oriented programming and boilerplate reduction.

### Structuration Layer
Layer 3 of the architecture. Contains the core engine aggregator (Alis.Core) that re-exports all engine subsystems.

### Test Project
A project containing unit and integration tests. Follows naming convention `{ProjectName}.Test`. Excluded from SonarQube analysis.

### Extension
A modular add-on to the ALIS engine. Extensions live in 1_Presentation/Extension and provide additional functionality (Ads, Security, Payment, Network, Cloud, etc.).

### Game Sample
A reference game implementation demonstrating ALIS engine capabilities. Lives in 2_Application/Alis/Sample and serves as educational material for game developers.
