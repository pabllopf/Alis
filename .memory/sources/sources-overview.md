# Sources Overview

Comprehensive documentation of all source files and projects in the Alis solution.

## Summary

**Total Source Files**: 500+ C# source files  
**Total Test Files**: 200+ test files  
**Total Generated Files**: 300+ source-generated files  
**Coverage**: All layers (1_Presentation, 4_Operation, 6_Ideation)

## Source Categories

### 1_Presentation - User-Facing Applications
- **Engine** - Main game engine runtime (50+ files)
- **Hub** - Hub application (20+ files)
- **Installer** - Installation application (15+ files)
- **Extension/** - 18+ modular extensions (200+ files)
- **Benchmark** - Performance benchmarks (50+ files)

### 4_Operation - Operational Systems
- **Ecs** - Entity Component System + Generator (100+ files)
- **Graphic** - Graphics rendering + Generator (80+ files)
- **Audio** - Audio processing (30+ files)
- **Physic** - Physics engine (40+ files)

### 6_Ideation - Experimental Aspects
- **Memory** - Memory abstractions + Generator (50+ files)
- **Fluent** - Fluent APIs + Generator (40+ files)
- **Data** - Data structures + Generator (45+ files)
- **Math** - Mathematical utilities (30+ files)
- **Time** - Time management (25+ files)
- **Logging** - Logging infrastructure (35+ files)

## Documentation Files

| File | Purpose |
|------|---------|
| `index.md` | Master navigation index |
| `engine-sources.md` | Engine runtime sources |
| `ecs-sources.md` | ECS runtime and generator |
| `generator-sources.md` | Source generator architecture |
| `extension-sources.md` | 18+ modular extensions |
| `ideation-sources.md` | Experimental aspects |
| `benchmark-sources.md` | Performance benchmarks |
| `test-sources.md` | Unit and integration tests |
| `generated-code-sources.md` | Source-generated code |
| `conventions-sources.md` | Coding standards and conventions |
| `architectural-patterns-sources.md` | Design patterns and architecture |

## Key Statistics

| Metric | Value |
|--------|-------|
| Source files documented | 500+ |
| Test files documented | 200+ |
| Generated files tracked | 300+ |
| Documentation files | 11 + index |
| Total lines documented | ~2,500+ |

## Usage

### For Developers
1. Reference `index.md` for navigation
2. Read specific source category documentation as needed
3. Follow conventions in `conventions-sources.md`

### For AI Agents
- Use documentation as context for code generation
- Reference architectural patterns for design decisions
- Check generated code locations for understanding compile-time generation

## Maintenance

Update these files when:
- New layers or modules are added
- Source generator patterns change
- New extensions are created
- Testing strategies evolve

## See Also
- `.memory/concepts/` - Architecture and design concepts
- `.memory/architecture/` - Architecture documentation
- `.memory/projects/` - Project-specific documentation
