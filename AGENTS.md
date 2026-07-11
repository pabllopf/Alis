# AGENTS.md — Alis

Cross-platform C# game framework. .NET monorepo with strict 6-layer architecture.

## Architecture

Dependency direction (enforced via `.config/Config.props` MSBuild rules):
```
1_Presentation → 2_Application → 3_Structuration → 4_Operation → 5_Declaration → 6_Ideation
```
Reverse cross-layer deps are forbidden. Never create new `.csproj` or solutions.

## Commands

```sh
dotnet restore alis.slnx
dotnet build alis.slnx -c Debug
dotnet test alis_design.sln -c Release -f net8.0     # CI runs this; use `net8.0` for quick results
```

Full per-project test run: `docs/scripts/macos/run_tests.sh` (Debug + Release, skips Template projects).  
Build for packaging: `docs/scripts/macos/build_all.sh` (skips Template/App/Test/Benchmark/Sample/Generator projects).

SDK: .NET 10 (`global.json`), roll forward allowed. `LangVersion` 13, `Nullable` disabled.

**Use the solution files with `_design` or specific area for focused builds** (e.g., `alis.core.slnx`, `alis.extensions.slnx`). The full `alis.slnx` includes everything.

## Coding rules

- **Only `.cs` files** may be created or edited. No `.md`, `.json`, `.txt`, `.xml`, `.yaml`, etc.
- **Comments forbidden** — only XML doc comments (`///`). No `//` or `/* */`.
- **Mandatory file header** on every `.cs` file (see `.editorconfig` for the exact template).
- **No `var`** for built-in types or when type is apparent.
- **Expression-bodied members** preferred for methods, constructors, destructors, local functions.
- **Private instance fields**: `_camelCase`. Private `static readonly`/`const`: `PascalCase`.
- **Block-scoped namespaces** (`namespace Foo { }`).
- **Max line length**: 392.
- **All English** — code, docs, tests, comments.

## Dependencies

Third-party NuGet deps are **strictly forbidden** in core. Exceptions (only in `.config/Config.props`):
- `Alis.Extension.Payment.Stripe` → Stripe.net
- `Alis.Extension.Ads.GoogleAds` → Google.Ads.Common
- `Alis.Extension.Cloud.GoogleDrive` → Google.Apis.Drive.v3
- `Alis.Extension.Cloud.DropBox` → Dropbox.Api
- SourceLink (all projects), System.* compat packages (legacy TFM only)

## Source generators

Generators live in `<module>/generator/` directories, target `netstandard2.0`, referenced as `OutputItemType="Analyzer"`. Must produce **AOT-safe, deterministic code**. Build them first if running full solution build fails.

## Testing

- **xUnit** + **Moq** + **Xunit.StaFact** + **coverlet**.
- **TDD required** — write failing test first.
- Test results land in `.test/<TargetFramework>/`.
- Test projects auto-reference `../src/<Name>.csproj` via convention.
- Some tests need platform libs: `brew install sdl2 sdl2_image sdl2_ttf ffmpeg` (macOS).
- CI triggers on commit messages containing `test: pro`.

## Multi-targeting

Projects build for {Debug → `netcoreapp2.0;net5.0;net8.0;net10.0;netstandard2.0;net461`} and {Release → all 19+ TFMs}. Use conditional compilation for APIs unavailable on older targets. `DefineConstants` auto-include `WIN`/`OSX`/`LINUX` based on `RuntimeIdentifier`.

## Performance

- No LINQ in hot paths, no boxing, no reflection, no runtime emit.
- Prefer `Span<T>`, data-oriented design, SIMD, allocation-free paths.
- AOT compatibility is mandatory (no `Reflection.Emit`, no runtime codegen).

## Repo conventions

- **Year-0.0.0 build metadata** (`.config/Config.props`: `<AssemblyVersion>1.0.8</AssemblyVersion>` — update carefully).
- **Asset packing** is a build-time MSBuild target (`.config/default/default_test_csproj.props`: `ZipAssets`, generates `obj/assets.pack`).
- **OpenCode commands** at `.opencode/commands/` for common tasks (coverage, smells, memory updates).
- **Memory system** at `.memory/` — structured project knowledge base.
- **Comprehensive rulebook**: `.github/copilot-instructions.md` (894 lines) — read for detailed rules on naming, style, and architecture.
- **GitHub agent**: `.github/agents/alis-solution-agent.agent.md` — scoped agent for Alis work.

## What NOT to do

- Do not add external NuGet dependencies.
- Do not create new projects or solutions.
- Do not change `Config.props`, `Directory.Build.props`, or shared MSBuild infra without explicit request.
- Do not use platform-specific APIs in shared code without conditional compilation and abstraction.
