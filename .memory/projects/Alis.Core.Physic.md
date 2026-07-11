---
title: Alis.Core.Physic
tags:
  - project
  - physic
  - collision
  - dynamics
  - layer-4
status: Draft
license: GPLv3
---

# Alis.Core.Physic

## Overview

Physics simulation library (Layer 4 - Operation). Provides collision detection, rigid body dynamics, and physics constraint solving.

## Properties

| Property | Value |
|---|---|
| **Layer** | 4 - Operation |
| **Project Path** | `4_Operation/Physic/src/` |
| **Test Project** | `Alis.Core.Physic.Test` |
| **Generator** | `Alis.Core.Physic.Generator` |
| **Has Samples** | Yes (`Alis.Core.Physic.Sample`) |

## Dependencies

- **Depends On**: [[Alis.Core.Aspect]] (via Layer 3/5 chain)
- **Depends On**: [[Alis.Core.Aspect.Math]]
- **Used By**: [[Alis.App.Engine]]

## Architecture

- `src/Collisions/` - Collision detection algorithms (broadphase, narrowphase)
- `src/Common/` - Common physics utilities
- `src/Controllers/` - Physics controllers
- `src/Dynamics/` - Rigid body dynamics, joints, contacts

## Source Structure

```
src/
  Collisions/
  Common/
  Controllers/
  Dynamics/
```

## Testing

- Test project: `Alis.Core.Physic.Test`
- Located at `4_Operation/Physic/test/`

## Related

- [[Alis.Core.Aspect.Math]]
- [[Alis.App.Engine]]
- [[Projects Index]]
