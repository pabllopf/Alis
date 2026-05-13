# Alis — Layer 5: Declaration (Projects, Dependencies, Key Types)

## Overview

- **Directory**: `5_Declaration/`
- **Total .cs files**: ~5 (src: 6 via glob, but likely includes sample/test)
- **Total projects**: 3 (1 src, 1 sample, 1 test)
- **Build target**: Multi-target via Config.props
- **Outputs**: Library (Aspect), EXE (sample)

## Projects

| Project | Path | Type | Namespace |
|---------|------|------|-----------|
| Alis.Core.Aspect | `5_Declaration/Aspect/src/` | Library | `Alis.Core.Aspect.*` |
| Alis.Core.Aspect.Sample | `5_Declaration/Aspect/sample/` | Executable | `Alis.Core.Aspect.Sample` |
| Alis.Core.Aspect.Test | `5_Declaration/Aspect/test/` | Test (xunit) | `Alis.Core.Aspect.Test` |

## Purpose

This layer provides meta-programming plumbing and aspect-oriented programming infrastructure. It sits between the ideology utilities (Layer 6) and the core abstractions (Layer 3).

## Dependencies

### Alis.Core.Aspect depends on:
- `6_Ideation/Data`
- `6_Ideation/Fluent`
- `6_Ideation/Logging`
- `6_Ideation/Math`
- `6_Ideation/Memory`
- `6_Ideation/Time`

All 6 Ideation aspects are dependencies of the Aspect layer, confirming Layer 5 is the "glue" that coordinates aspects.

### Alis.Core.Aspect.Test depends on:
- Conditional references to 1_Presentation, 2_Application, 3_Structuration, 4_Operation (shared test template pattern)
- This itself (Alis.Core.Aspect)

## Key Types

The namespace `Alis.Core.Aspect.*` suggests:
- Aspect-oriented programming abstractions
- Cross-cutting concern orchestration
- Meta-programming infrastructure
- Coordination of Ideation layer aspects

## Build Notes

- Uses Config.props multi-targeting
- Sample targets `net10.0`
- Test targets `net8.0`
- `SonarQubeExclude` — excluded from SonarQube
