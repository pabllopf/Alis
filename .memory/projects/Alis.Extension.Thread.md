---
title: Alis.Extension.Thread
tags:
  - project
  - thread
  - parallelism
  - concurrency
  - layer-1
status: Draft
license: GPLv3
---

# Alis.Extension.Thread

## Overview

Threading and parallel execution extension (Layer 1 - Extension). Provides thread management, task scheduling, and parallel execution strategies.

## Properties

| Property | Value |
|---|---|
| **Layer** | 1 - Presentation (Extension) |
| **Project Path** | `1_Presentation/Extension/Thread/src/` |
| **Test Project** | `Alis.Extension.Thread.Test` |
| **Has Samples** | Yes (`Alis.Extension.Thread.Sample`) |

## Dependencies

- **Depends On**: [[Alis]] (Layer 2 - Application)

## Architecture

- `src/Attributes/` - Thread-related attributes
- `src/Builder/` - Thread builder
- `src/Configuration/` - Thread configuration
- `src/Core/` - Core thread management
- `src/Execution/` - Execution strategies
- `src/Integration/` - Integration utilities
- `src/Interfaces/` - Thread interfaces
- `src/Scheduling/` - Task scheduling
- `src/Strategies/` - Execution strategies

## Source Structure

```
src/
  Attributes/
  Builder/
  Configuration/
  Core/
  Execution/
  Integration/
  Interfaces/
  Scheduling/
  Strategies/
```

## Related

- [[Projects Index]]
