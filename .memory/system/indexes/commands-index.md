# Commands Index

## ECS Commands

| Command | Purpose | Parameters |
|---|---|---|
| Create | Create new entity | Components array |
| Destroy | Remove entity | Entity ID |
| AddComponent | Add component to entity | Entity ID, Component type |
| RemoveComponent | Remove component from entity | Entity ID, Component type |

## Scene Commands

| Command | Purpose | Parameters |
|---|---|---|
| Update | Update all entities | Update type |
| Query | Query entities | Rule, Component types |
| BatchCreate | Create multiple entities | Count, Components |

## Related

- [[queries-index]] — Query commands
- [[events-index]] — Event commands
- [[handlers-index]] — Command handlers
- [[apis-index]] — Command APIs
- [[Alis.Core.Ecs]] — ECS command docs
- [[entity-component-system-ecs]] — ECS overview
- [[architecture-index]] — Command pattern
- [[indexes-summary]] — All indexes
