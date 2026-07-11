---
title: Logging Domain
tags:
  - domain
  - logging
  - diagnostics
status: Draft
license: GPLv3
---

# Logging Domain

## Overview

The Logging domain provides configurable logging infrastructure with filter pipelines, message formatting, and multiple output targets. Implemented in [[Alis.Core.Aspect.Logging]].

## Architecture

```mermaid
flowchart LR
    subgraph "Logging Pipeline"
        Logger[Logger] --> Filter[Filter Pipeline]
        Filter --> Formatter[Message Formatter]
        Formatter --> Output[Output Target]
    end
    
    subgraph "Outputs"
        Output --> Console[Console]
        Output --> File[File]
        Output --> Debug[Debug]
    end
```

## Module Structure

| Directory | Purpose |
|---|---|
| `Abstractions/` | Logging interfaces and contracts |
| `Core/` | Core logging engine (Logger, LoggerFactory) |
| `Filters/` | Log level and content filtering |
| `Formatters/` | Message formatting strategies |
| `Outputs/` | Log output destinations |

## Related

- [[Alis.Core.Aspect.Logging]]
- [[Alis.Core.Aspect.Logging.Generator]]
- [[Projects Index]]
