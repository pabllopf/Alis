---
title: Alis.Core.Aspect.Fluent
tags:
  - project
  - fluent
  - builder
  - layer-6
status: Draft
license: GPLv3
---

# Alis.Core.Aspect.Fluent

## Overview

Fluent API builder pattern library (Layer 6 - Ideation). Provides builder pattern abstractions for constructing objects using a fluent interface.

## Properties

| Property | Value |
|---|---|
| **Layer** | 6 - Ideation |
| **Project Path** | `6_Ideation/Fluent/src/` |
| **Test Project** | `Alis.Core.Aspect.Fluent.Test` |
| **Generator** | `Alis.Core.Aspect.Fluent.Generator` |
| **Has Samples** | Yes (`Alis.Core.Aspect.Fluent.Sample`) |

## Dependencies

- **Depends On**: [[Alis.Core.Aspect]] (Layer 5 reference chain)

## Architecture

- `src/Components/` - Fluent component builders
- `src/Words/` - Fluent API word definitions

## Source Structure

```
src/
  Components/
  Words/
```

## Testing

- Test project: `Alis.Core.Aspect.Fluent.Test`
- Located at `6_Ideation/Fluent/test/`

## Related

- [[Alis.Core.Aspect]]
- [[Fluent Domain]]
- [[Projects Index]]
