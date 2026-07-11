---
title: Aspect-Oriented Design Concept
tags:
  - concept
  - aspect
  - aop
  - cross-cutting
status: Draft
license: GPLv3
---

# Aspect-Oriented Design Concept

## Overview

Aspect-Oriented Programming (AOP) is used in Alis to manage cross-cutting concerns through the `Alis.Core.Aspect` framework (Layer 5-6).

## Aspects

Each aspect is a self-contained module providing a cross-cutting capability:

| Aspect | Module | Layer | Concern |
|---|---|---|---|
| Data | [[Alis.Core.Aspect.Data]] | 6 | Serialization |
| Fluent | [[Alis.Core.Aspect.Fluent]] | 6 | Builder APIs |
| Logging | [[Alis.Core.Aspect.Logging]] | 6 | Diagnostics |
| Math | [[Alis.Core.Aspect.Math]] | 6 | Computation |
| Memory | [[Alis.Core.Aspect.Memory]] | 6 | Resource management |
| Time | [[Alis.Core.Aspect.Time]] | 6 | Timing |

## Architecture

```mermaid
flowchart BT
    subgraph "Applications"
        Engine[Alis.App.Engine]
        Samples[Sample Games]
    end
    
    subgraph "Aspect Framework"
        Aspect[Alis.Core.Aspect<br/>(Layer 5 - Declaration)]
        Data[Data Aspect]
        Logging[Logging Aspect]
        Math[Math Aspect]
        Time[Time Aspect]
        Memory[Memory Aspect]
        Fluent[Fluent Aspect]
    end
    
    Engine --> Aspect
    Samples --> Aspect
    Aspect --> Data
    Aspect --> Fluent
    Aspect --> Logging
    Aspect --> Math
    Aspect --> Memory
    Aspect --> Time
```

## Consumption Pattern

All upper-layer projects consume aspect services through:
1. Direct project reference in Debug mode
2. Source file merging in Release mode
3. Generated code from aspect-specific source generators

## Related

- [[Alis.Core.Aspect]]
- [[Layered Architecture]]
- [[Source Generators]]
- [[Projects Index]]
