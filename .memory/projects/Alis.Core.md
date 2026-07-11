---
title: Alis.Core
tags:
  - project
  - core
  - structuration
  - layer-3
status: Draft
license: GPLv3
---

# Alis.Core

## Overview

Core structuration layer (Layer 3 - Structuration). Acts as the structural foundation that bridges Application and Operation layers.

## Properties

| Property | Value |
|---|---|
| **Layer** | 3 - Structuration |
| **Project Path** | `3_Structuration/Core/src/` |
| **Test Project** | `Alis.Core.Test` |
| **Generator** | `Alis.Core.Generator` |
| **Has Samples** | Yes (`Alis.Core.Sample`) |

## Dependencies

- **Depends On**: [[Alis.Core.Audio]], [[Alis.Core.Graphic]], [[Alis.Core.Physic]], [[Alis.Core.Ecs]] (Layer 4 - Operation)
- **Used By**: [[Alis]] (Layer 2 - Application)

## Architecture

- Empty `src/` directory - only contains `.csproj`
- In Debug builds, references Layer 4 projects via `Config.props`
- In Release builds, compiles Layer 4 source files directly via `<Compile Include="...">`

## Build Mode Notes

- **Debug Mode**: Standard ProjectReference chain to Layer 4
- **Release Mode**: Source files from Layer 4 are compiled directly into Alis.Core assembly using `<Compile Include="$(SolutionDir)4_Operation/**/src/**/*.cs">`

## Testing

- Test project: `Alis.Core.Test`
- Located at `3_Structuration/Core/test/`

## Related

- [[Alis]]
- [[Alis.Core.Ecs]]
- [[Alis.Core.Graphic]]
- [[Alis.Core.Physic]]
- [[Alis.Core.Audio]]
- [[Projects Index]]
