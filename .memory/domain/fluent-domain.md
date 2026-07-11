---
title: Fluent Domain
tags:
  - domain
  - fluent
  - builder
  - api
status: Draft
license: GPLv3
---

# Fluent Domain

## Overview

The Fluent domain provides builder pattern abstractions for constructing objects using a fluent interface. Implemented in [[Alis.Core.Aspect.Fluent]].

## Architecture

| Directory | Purpose |
|---|---|
| `Components/` | Fluent component builders |
| `Words/` | Fluent API word definitions |

## Key Types

| Type | Purpose |
|---|---|
| `IBuild` | Builder interface contract |
| `IHasBuilder` | Builder accessor interface |
| `KeyEventInfo` | Keyboard event information |

## Usage Pattern

```csharp
// Fluent builder pattern
var result = new Builder()
    .WithProperty(value)
    .WithOption(option)
    .Build();
```

## Related

- [[Alis.Core.Aspect.Fluent]]
- [[Alis.Core.Aspect.Fluent.Generator]]
- [[Builder Pattern]]
