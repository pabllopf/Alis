# Alis Solution Agent Rules

## Main Commands

```bash
# Restore dependencies
dotnet restore alis.slnx

# Build solution
dotnet build alis.slnx -c Debug

# Run all tests 
dotnet test alis.slnx -c Debug
```

## Solution Architecture

Main solution: `alis.slnx` (335 projects across 6 layers)

**Layer dependency order (strict, never reverse):**
```
1_Presentation → 2_Application → 3_Structuration → 4_Operation → 5_Declaration → 6_Ideation
```

- **1_Presentation**: Engine, extensions, UI, runtime frontends
- **2_Application**: Alis, samples, executable compositions  
- **3_Structuration**: Core abstractions, base infrastructure
- **4_Operation**: Graphics, audio, media, platform operations (many have `generator/` subfolders)
- **5_Declaration**: Contracts, interfaces, metadata
- **6_Ideation**: Experimental modules (many have `generator/` subfolders)

## Critical Rules

- **No new projects/solutions** — repository structure is fixed
- **No external NuGet packages** — only standard .NET, system libraries, native APIs allowed
- **Multi-targeting mandatory** — all Release builds target 15+ frameworks (netstandard2.0–2.1, netcoreapp2.0–3.1, net5.0–10.0, net461–481)
- **AOT compatibility** — no `System.Reflection.Emit`, runtime IL emit, or dynamic method generation
- **Source generators** — must produce AOT-safe code with diagnostics for invalid configurations (ALIS0xxx IDs)
- **Dependency direction** — lower layers never depend on higher layers

## File Rules

- Only `.cs` files for source code — never generate `.md`, `.txt`, `.json`, `.yaml`, `.xml`
- XML documentation only (`///`) — no `//` or `/* */` comments in code
- All public/protected/internal APIs must be documented

## Testing

- xUnit + `Xunit.StaFact` + Moq
- Test output: `.test/<TargetFramework>/`
- Full test suite runs Debug + Release for every non-template `*.csproj`

## Shared Config

- `.config/Config.props` — multi-targeting, runtime identifiers, analyzers
- `.config/default/` — default props for csproj templates

## Platform Targets

Windows (`win-x64/x86/arm64`), Linux (`linux-x64/musl-x64/arm/arm64/musl-arm/musl-arm64`), macOS (`osx-x64/arm64`), Web (`browser-wasm`). Mobile planned but not yet supported.

## Framework Targets

`.NET Core 2.0–3.1`, `.NET 5–10`, `.NET Standard 2.0–2.1`, `.NET Framework 4.61–4.81`

## When in Doubt

1. Check `.config/Config.props` for project defaults
2. Verify layer placement respects dependency order
3. Confirm no external dependencies added
4. Run `dotnet build alis.slnx` and `dotnet test alis.slnx`
5. Validate AOT compatibility for changed code paths
