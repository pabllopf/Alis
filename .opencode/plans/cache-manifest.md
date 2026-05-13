# Alis Solution - Cache Manifest

## Purpose
This manifest tracks the state and versioning of all cached information files in `.info/`. It enables fast context reconstruction when resuming work on the Alis solution without re-scanning the codebase.

## Cache Version
| Property | Value |
|----------|-------|
| **Manifest Version** | 2.0 |
| **Solution Version** | 1.0.6 |
| **Total Projects** | 142 csproj files |
| **Total .cs Files** | ~6,253 source files |
| **Repository Size** | ~15GB |

## Cache Files Inventory

### Core Cache (Existing - v1)
| File | Purpose | Status |
|------|---------|--------|
| `index.md` | Master index with quick stats, entry points, key files | Active |
| `architecture.md` | Full architecture overview, layers, patterns | Active |
| `projects.md` | Complete project inventory with paths | Active |
| `dependencies.md` | Dependency graph, build order, cross-refs | Active |
| `namespaces.md` | Complete namespace hierarchy | Active |
| `symbols.md` | Key types, classes, interfaces by module | Active |
| `plan.md` | Navigation guide and common tasks | Active |

### Enhanced Cache (New - v2)
| File | Purpose | Status |
|------|---------|--------|
| `cache-manifest.md` | This file - cache versioning and metadata | Active |
| `cache-solution-files.md` | All solution files (.slnx) and their project scope | Active |
| `cache-config.md` | Build configuration, TFMs, RIDs, analyzers, compiler flags | Active |
| `cache-extensions.md` | Complete extension catalog with categories, dependencies, file counts | Active |
| `cache-generators.md` | Source generator projects and their code generation targets | Active |
| `cache-ci-cd.md` | GitHub Actions workflows, CI/CD pipeline structure | Active |
| `cache-nuget.md` | NuGet package map with versions, dependencies, external SDKs | Active |
| `cache-patterns.md` | Code patterns, naming conventions, architecture decisions | Active |
| `cache-quickref.md` | Quick reference cards for common tasks and lookups | Active |

## Cache Usage Guidelines

### For AI Agents
When asked about the Alis solution:
1. **Always read `cache-manifest.md` first** to understand cache state
2. **Read relevant cache files** based on the query topic
3. **Cross-reference with existing `.info/` files** for deeper context
4. **Never re-scan the codebase** unless cache is incomplete or outdated

### Cache Refresh Triggers
Refresh the cache when:
- New projects are added/removed from solution files
- Dependency graphs change (new project references)
- Configuration files are modified (TFMs, analyzers)
- New extensions or sample games are added
- After major refactoring of core modules

### Cache Update Procedure
1. Update `cache-manifest.md` version and last updated date
2. Re-scan affected cache files
3. Update the manifest's file inventory if new files are added
4. Verify consistency across all cache files

## File Size and Complexity Leaders

### Largest Projects by Source File Count
| Rank | Project | Category | Est. .cs Files |
|------|---------|----------|----------------|
| 1 | Extension.Network | 1_Presentation | 303 |
| 2 | Extension.Media.FFmpeg | 1_Presentation | 276 |
| 3 | Extension.Graphic.Ui | 1_Presentation | 251 |
| 4 | Core.Physic | 4_Operation | 239 |
| 5 | Extension.Math.ProceduralDungeon | 1_Presentation | 215 |
| 6 | Benchmark | 1_Presentation | 210 |
| 7 | Core.Graphic | 4_Operation | 195 |
| 8 | Extension.Graphic.Sdl2 | 1_Presentation | 179 |
| 9 | Core.Aspect.Fluent | 6_Ideation | 178 |
| 10 | Alis (app core) | 2_Application | 163 |

### Module File Distribution
| Module | csproj | .cs Files | % of Total |
|--------|--------|-----------|------------|
| 1_Presentation | 71 | 3,330 | 53.2% |
| 2_Application | 30 | 485 | 7.8% |
| 3_Structuration | 3 | 264 | 4.2% |
| 4_Operation | 14 | 1,264 | 20.2% |
| 5_Declaration | 3 | 59 | 0.9% |
| 6_Ideation | 21 | 851 | 13.6% |

## Cross-Reference Map

### Which cache file to read for what
| Query Type | Primary Cache File | Secondary Cache File |
|------------|-------------------|---------------------|
| "What projects exist?" | `projects.md` | `cache-solution-files.md` |
| "How do modules depend on each other?" | `dependencies.md` | `cache-config.md` |
| "What's the architecture?" | `architecture.md` | `cache-patterns.md` |
| "Find a specific class/interface" | `symbols.md` | `namespaces.md` |
| "How to build/test?" | `plan.md` | `cache-ci-cd.md` |
| "What NuGet packages are used?" | - | `cache-nuget.md` |
| "What extensions exist?" | `projects.md` | `cache-extensions.md` |
| "Source generators?" | - | `cache-generators.md` |
| "Build configuration?" | - | `cache-config.md` |
| "Quick lookup for common tasks" | `plan.md` | `cache-quickref.md` |

## Solution File Map

The repository contains multiple solution files for different scopes:
- `alis.slnx` - Main solution (all projects)
- `alis.apps.slnx` - Application projects only
- `alis.benchmark.slnx` - Benchmark projects only
- `alis.core.slnx` - Core library projects
- `alis.extensions.slnx` - Extension projects only
- `alis.samples.slnx` - Sample projects only
- `alis.test.slnx` - Test projects only

See `cache-solution-files.md` for complete project-to-solution mapping.
