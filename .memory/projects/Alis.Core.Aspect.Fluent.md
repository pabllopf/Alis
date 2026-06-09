---
title: Alis.Core.Aspect.Fluent
tags:
  - project
  - documentation
  - reference

status: draft

license: GPLv3
---


**Status**: ✅ Documented  
**Type**: Game Entity System / Fluent Builder  
**Layer**: 6_Ideation  
**Target Frameworks**: 15+ (netstandard2.0–2.1, netcoreapp2.0–3.1, net5.0–10.0, net461–481)

## Overview

Fluent game entity component system with AOT-compatible builder patterns. Provides O(1) component access and lifecycle hooks.

## Key Features

- ✅ AOT-compatible (no reflection)
- ✅ Multi-targeted to 15+ frameworks
- ✅ Fluent builder pattern
- ✅ O(1) component access
- ✅ 80+ builder "words"
- ✅ 20+ lifecycle hooks

## Public API

| Type | Purpose |
|---|---|
| `IComponentBase` | Marker interface for components |
| `IGameObject` | Entity handle with component access |
| `IAction<T>` | Fluent action delegates (1-8 args) |
| `IBuild<T>` | Terminal build operation |
| `IRun` | Execute builder pipeline |
| `IOnAwake` - `IOnDestroy` | Lifecycle hooks |
| `IWithName`, `IPosition2D`, etc. | Builder "words" |

## Documentation

- [[Domain/Fluent/Overview]] - Complete overview
- [[Domain/Fluent/Components/Component-System]] - Component architecture
- [[Domain/Fluent/Builders/Fluent-Builders]] - Builder pattern
- [[Domain/Fluent/Words/Words-Index]] - All builder words
- [[Domain/Fluent/Lifecycle/Lifecycle-Hooks]] - Lifecycle methods

## File Structure

```
6_Ideation/Fluent/src/
├── IBuild.cs
├── IHasBuilder.cs
├── Components/
│   ├── IComponentBase.cs
│   ├── IGameObject.cs
│   ├── IAction.cs (partial, 1-8 args)
│   └── Lifecycle hooks (20+ interfaces)
└── Words/
    ├── IRun.cs
    ├── IWithName.cs
    └── 80+ builder interfaces
```

## Tests

See: `6_Ideation/Fluent/test/Alis.Core.Aspect.Fluent.Test.csproj`

## Related Projects

- [[Alis.Core.Aspect.Data]] - JSON persistence
- [[Alis.Core.Aspect.Memory]] - Memory management
- [[Alis.Core.Aspect.Time]] - Time system
- [[Alis.Core.Aspect.Logging]] - Debug logging

## License

GNU GPL v3.0

## Author

Pablo Perdomo Falcón
