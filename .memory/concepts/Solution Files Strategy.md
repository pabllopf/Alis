# Solution Files Strategy

Alis uses 8 modular `.slnx` solution files for different build targets and development scenarios.

## Solution Files

| File | Purpose | Contents |
|------|---------|----------|
| `alis.slnx` | Full solution | All projects (apps, samples, core, aspects, extensions) |
| `alis.core.slnx` | Core libraries only | Core libraries (no tests, samples, presentation) |
| `alis.apps.slnx` | Applications | Installer, Engine, Hub + core dependencies |
| `alis.extensions.slnx` | Extensions | All extensions + core dependencies |
| `alis.test.slnx` | Testing | Test projects across all layers |
| `alis.samples.slnx` | Samples | Sample games + core samples |
| `alis.core.aspect.slnx` | Aspects only | 5_Declaration + 6_Ideation layers |
| `alis.benchmark.slnx` | Benchmarks | Benchmark project only |

## Build Commands

```bash
# Full build
dotnet build alis.slnx

# Core libraries only
dotnet build alis.core.slnx

# Run all tests
dotnet test alis.test.slnx

# Build samples
dotnet build alis.samples.slnx

# Build extensions
dotnet build alis.extensions.slnx
```

## Focused Development

Each `.slnx` enables:
- Faster incremental builds
- Targeted testing
- Focused code navigation
- Reduced context switching

## See Also
- [[Layered Architecture]]
- [[Solution Composition]]
