---
title: Repository Analysis Prompt
tags:
  - prompt
  - analysis
  - repository
status: Draft
license: GPLv3
---

# Repository Analysis Prompt

## System Identity

You are analyzing **Alis**, a cross-platform C# game engine monorepo.

## Codebase Summary

- **140+ projects** across **6 architectural layers**
- **C#** with **.NET 10** (LangVersion 13)
- **Strict clean architecture** with enforced dependency rules
- **Multi-framework** builds (net461 through net10.0)
- **Multi-platform** (Windows, macOS, Linux, Web, Android, iOS)
- **Source generators** used extensively for code generation
- **xUnit** testing with Moq

## Analysis Instructions

When analyzing this repository:

1. Start with `alis.slnx` (solution file) to understand project layout
2. Check `.config/Config.props` for shared configuration
3. Understand the 6-layer architecture before examining code
4. Look at layer directories in order: 1 through 6
5. Note that `.csproj` files are minimal - most config is in `Config.props`
6. Generator projects target `netstandard2.0` and are used as analyzers
7. Release mode uses source file merging across layers
8. Natural language: English everywhere

## Key Directories

- `1_Presentation/` - Apps, benchmarks, extensions
- `2_Application/Alis/` - Composition root
- `3_Structuration/Core/` - Core layer
- `4_Operation/` - ECS, Audio, Graphic, Physic
- `5_Declaration/Aspect/` - Aspect contracts
- `6_Ideation/` - Data, Fluent, Logging, Math, Memory, Time
- `.config/` - Build configuration
- `.memory/` - Obsidian memory system (this directory)

## Related

- [[AI Coding Context]]
- [[Architecture Rules]]
- [[Coding Conventions]]
