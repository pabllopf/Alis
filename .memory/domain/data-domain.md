---
title: Data Domain
tags:
  - domain
  - data
  - serialization
  - json
status: Draft
license: GPLv3
---

# Data Domain

## Overview

The Data domain provides serialization and deserialization capabilities, primarily focused on JSON processing. Implemented in [[Alis.Core.Aspect.Data]].

## Architecture

```mermaid
flowchart LR
    subgraph "Data Module"
        Json[JSON Engine] --> Serializer[Serializer]
        Json --> Deserializer[Deserializer]
        Json --> Parser[Parser]
    end
    
    subgraph "Source Generator"
        Gen[Data Generator] --> CodeGen[Generated Code]
        CodeGen --> Serializer
        CodeGen --> Deserializer
    end
```

## Key Features

- JSON serialization/deserialization
- Source-generated serialization code for AOT compatibility
- No runtime reflection for serialization
- Customizable parsing options

## Module Structure

- `src/Json/` - JSON processing engine
- `generator/` - Roslyn source generator for serialization code

## Related

- [[Alis.Core.Aspect.Data]]
- [[Alis.Core.Aspect.Data.Generator]]
- [[Serialization Pattern]]
- [[Projects Index]]
