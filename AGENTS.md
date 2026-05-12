# AGENTS.md — Alis

## Project map
- Alis is a layered .NET multimedia/game framework with strict downward dependencies:
  `1_Presentation → 2_Application → 3_Structuration → 4_Operation → 5_Declaration → 6_Ideation`.
- Keep changes inside the owning layer; never add upward or cross-layer references.
- Modules are conventionally split into `src/`, `test/`, `sample/`, and sometimes `generator/` trees, as seen in `4_Operation/Ecs/` and `6_Ideation/Memory/`.

## Read first
- `alis.sln` for the project map.
- `.config/Config.props` for TFMs, RIDs, analyzers, pack rules, and layer-based `ProjectReference` wiring.
- `readme.md` for the public package map and platform scope.
- `.github/copilot-instructions.md` and `CLAUDE.md` for existing agent workflow rules.

## What matters technically
- The repo targets many frameworks and runtimes; use only APIs that stay compatible with the configured TFMs in `.config/Config.props`.
- Release builds enable packing, documentation generation, SourceLink, and deterministic output; treat warnings as errors.
- Generator projects are first-class and are referenced as analyzers, e.g. `4_Operation/Ecs/generator/Alis.Core.Ecs.Generator.csproj`.
- Native/runtime assets are packed from `runtimes/` and specific modules may carry local `Config/` or `Data/` folders.

## Build and test
- Restore: `dotnet restore alis.sln`
- Build: `dotnet build alis.sln -c Debug`
- Test: `dotnet test alis.sln`
- macOS full-test script: `docs/scripts/macos/run_tests.sh` runs Debug + Release across non-template projects.
- Packaging scripts: `docs/scripts/macos/build_all.sh` and `docs/scripts/macos/pack_all.sh`.

## Coding conventions to preserve
- Follow `.editorconfig`: UTF-8, LF, 4 spaces, block-scoped namespaces, predefined types, and required accessibility modifiers.
- Keep code deterministic and AOT-safe; avoid runtime code generation and reflection-heavy shortcuts.
- Do not add external NuGet packages or new projects unless explicitly requested.
- Avoid editing `.csproj` files unless the task requires it.

## Where to look for examples
- Core application entry: `2_Application/Alis/src/Alis.csproj`
- Operation layer ECS: `4_Operation/Ecs/src/Alis.Core.Ecs.csproj`
- Source generator layout: `4_Operation/Ecs/generator/Alis.Core.Ecs.Generator.csproj`
- Presentation extension pattern: `1_Presentation/Extension/Graphic/Sdl2/src/Alis.Extension.Graphic.Sdl2.csproj`
- Public package description and supported platforms: `readme.md`

