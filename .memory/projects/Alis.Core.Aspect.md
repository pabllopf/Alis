---
title: Alis.Core.Aspect
tags:
  - project
  - aspect
  - declaration
  - layer-5
status: Draft
license: GPLv3
---

# Alis.Core.Aspect

## Overview

Core aspect-oriented programming framework serving as Layer 5 (Declaration). Provides the foundational contract layer for all cross-cutting concerns.

## Properties

| Property | Value |
|---|---|
| **Layer** | 5 - Declaration |
| **Project Path** | `5_Declaration/Aspect/src/` |
| **Test Project** | `Alis.Core.Aspect.Test` |
| **Generator** | None (no generator project) |
| **Has Samples** | Yes (`Alis.Core.Aspect.Sample`) |

## Dependencies

- **Upstream**: Depends on [[Alis.Core.Aspect.Data]], [[Alis.Core.Aspect.Fluent]], [[Alis.Core.Aspect.Logging]], [[Alis.Core.Aspect.Math]], [[Alis.Core.Aspect.Memory]], [[Alis.Core.Aspect.Time]] (Layer 6)

## Architecture

- Empty `src/` directory - only contains `.csproj`
- In Debug builds, references Layer 6 projects via `Config.props`
- In Release builds, compiles Layer 6 source files directly via `<Compile Include="...">`

## Testing

- Test project: `Alis.Core.Aspect.Test`
- Located at `5_Declaration/Aspect/test/`

## Related

- [[Aspect-Oriented Design]]
- [[Layered Architecture]]
- [[Projects Index]]
- [[Dependency Index]]
