# APIs Index

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
