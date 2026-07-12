---
title: Alis.Core
tags:
  - structuration
  - core
  - abstractions
status: Draft
license: GPLv3
---

# Alis.Core

**Layer:** 3_Structuration
**Path:** `3_Structuration/Core/src/Alis.Core.csproj`

## Purpose

Core abstractions and foundational types serving as the bridge between the Application layer (2) and Operation layer (4). Provides re-exports and type forwarding from lower layers.

## Architecture

This project provides centralized type forwarding from the Operation (4) and Declaration (5) layers to the Application (2) layer. It ensures the dependency chain:

```
Application → Core → Operation → Declaration → Ideation
```

## Dependencies

- Alis.Core.Audio (4_Operation)
- Alis.Core.Ecs (4_Operation)
- Alis.Core.Graphic (4_Operation)
- Alis.Core.Physic (4_Operation)
- Alis.Core.Aspect (5_Declaration)

## Upstream Dependents

- Alis (2_Application)

## Source Generator

**Path:** `3_Structuration/Core/generator/`

Generates code for core abstractions.

## Testing

**Path:** `3_Structuration/Core/test/`

Standard test suite with unit and integration tests.

## Related Documents

- [[Alis.Core.Aspect]]
- [[Alis.Core.Ecs]]
- [[Alis.Core.Physic]]
- [[layer-architecture]]
