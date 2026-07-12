---
title: Alis.Core.Aspect
tags:
  - declaration
  - aspect
  - contracts
status: Draft
license: GPLv3
---

# Alis.Core.Aspect

**Layer:** 5_Declaration
**Path:** `5_Declaration/Aspect/src/Alis.Core.Aspect.csproj`

## Purpose

Aspect-oriented contract assembly. Serves as the declaration layer bridging Operation (4) to Ideation (6). Provides type forwarding and contract re-exports from the foundation layer.

## Design

This layer acts as a **facade/proxy** between the Operation modules and the Ideation foundation. It re-exports core types from `Alis.Core.Aspect.*` (Data, Math, Memory, Time, Logging, Fluent) to provide a unified API surface for upstream consumers.

## Dependencies

- Alis.Core.Aspect.Data
- Alis.Core.Aspect.Fluent
- Alis.Core.Aspect.Logging
- Alis.Core.Aspect.Math
- Alis.Core.Aspect.Memory
- Alis.Core.Aspect.Time

## Upstream Dependents

- Alis.Core (3_Structuration)
- Alis.Core.Audio (4_Operation)
- Alis.Core.Ecs (4_Operation)
- Alis.Core.Graphic (4_Operation)
- Alis.Core.Physic (4_Operation)

## Testing

**Path:** `5_Declaration/Aspect/test/`

Minimal test suite — 1 test file (DefaultTest.cs).

## Related Documents

- [[Alis.Core.Aspect.Data]]
- [[Alis.Core.Aspect.Math]]
- [[layer-architecture]]
