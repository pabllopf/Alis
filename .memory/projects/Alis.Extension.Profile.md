---
title: Alis.Extension.Profile
tags:
  - project
  - profile
  - debugging
  - diagnostics
  - layer-1
status: Draft
license: GPLv3
---

# Alis.Extension.Profile

## Overview

Performance profiling extension (Layer 1 - Extension). Provides code profiling and performance measurement capabilities.

## Properties

| Property | Value |
|---|---|
| **Layer** | 1 - Presentation (Extension) |
| **Project Path** | `1_Presentation/Extension/Profile/src/` |
| **Test Project** | `Alis.Extension.Profile.Test` |
| **Has Samples** | Yes (`Alis.Extension.Profile.Sample`) |

## Dependencies

- **Depends On**: [[Alis]] (Layer 2 - Application)

## Architecture

- `src/Builders/` - Profiler builders
- `src/Factories/` - Profiler factories
- `src/Helpers/` - Profiling helpers
- `src/Implementations/` - Profiler implementations
- `src/Interfaces/` - Profiler interfaces
- `src/Models/` - Profile data models
- `src/Utilities/` - Profiling utilities

## Related

- [[Projects Index]]
