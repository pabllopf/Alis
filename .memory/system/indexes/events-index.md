# Events Index

## ECS Events

| Event | Trigger | Handler |
|---|---|---|
| ComponentAdded | Entity gets new component | System update cycle |
| ComponentRemoved | Entity loses component | System update cycle |
| GameObjectCreated | New entity created | Scene initialization |
| GameObjectDestroyed | Entity removed | Cleanup handlers |

## Platform Events

| Event | Trigger | Handler |
|---|---|---|
| WindowResized | Window dimensions change | Render system |
| InputChanged | User input received | Game logic |
| AssetLoaded | Asset pack loaded | Asset registry |

## Custom Events

- Memory management events (cache invalidation)
- Network communication events (extension projects)

## Related

- [[handlers-index]] — Event handlers
- [[commands-index]] — Command patterns
- [[entity-component-system-ecs]] — ECS event flow
- [[Event<T>]] — Generic event handler
- [[ComponentEvent]] — Component lifecycle
- [[GameObjectFlags]] — Event flag management
- [[Alis.Core.Ecs]] — ECS event docs
- [[architecture-index]] — Event architecture
- [[indexes-summary]] — All indexes
