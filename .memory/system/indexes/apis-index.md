# APIs Index

tags:
  - index,catalog,reference

## Public APIs

### Alis.Core.Ecs

- `Scene.Create<TComponent>()` - Create entity with component
- `Scene.Query()` - Query entities by component type
- `Scene.Update<TUpdate>()` - Update all entities with specific update type

### Alis.Core.Graphic

- `Window.Create()` - Create graphics window
- `Renderer.Render()` - Render scene to window
- `Texture.Load()` - Load texture from file

### Alis.Core.Aspect.Memory

- `AssetRegistry.RegisterAssembly()` - Register asset pack
- `AssetRegistry.GetResourceMemoryStreamByName()` - Get resource as stream
- `AssetRegistry.GetResourcePathByName()` - Extract resource to temp file

## Internal APIs

- Memory pooling and allocation
- Custom collection types (SparseSet, FastestTable)
- Platform-specific native bindings

## Related

- [[handlers-index]] — Handler APIs
- [[commands-index]] — Command APIs
- [[queries-index]] — Query APIs
- [[services-index]] — Service APIs
- [[project-index]] — Public API projects
- [[Alis.Core.Ecs]] — ECS API docs
- [[Alis.Core.Graphic]] — Graphic API docs
- [[Alis.Core.Aspect.Memory]] — Memory API docs
- [[indexes-summary]] — All indexes
