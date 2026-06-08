# Solution Composition

Alis uses 8 modular `.slnx` solution files for different build targets, enabling focused compilation:

## Solution Files

| File | Contents |
|------|----------|
| `alis.slnx` | Full solution — all projects (apps, samples, core, aspects, extensions) |
| `alis.core.slnx` | Core libraries only (no tests, samples, presentation) |
| `alis.apps.slnx` | Applications + core dependencies (Installer, Engine, Hub) |
| `alis.extensions.slnx` | All extensions + core dependencies |
| `alis.test.slnx` | Test projects across all layers |
| `alis.samples.slnx` | Sample games + core samples |
| `alis.core.aspect.slnx` | Aspect layer only (5_Declaration + 6_Ideation) |
| `alis.benchmark.slnx` | Benchmark project only |

## Build Commands
```bash
dotnet build alis.slnx        # Full build
dotnet build alis.core.slnx   # Core only
dotnet test alis.test.slnx    # Run tests
```

## See Also
- [[Layered Architecture]]
