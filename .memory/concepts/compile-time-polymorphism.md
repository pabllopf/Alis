# Compile-Time Polymorphism

tags:
  - concept,theory,documentation

Compile-time polymorphism uses source generators and static dispatch instead of virtual method calls, enabling AOT compatibility and better compiler optimizations.

## Core Concept

### Static Dispatch vs Virtual Dispatch

| Aspect | Virtual (Runtime) | Static (Compile-Time) |
|--------|-------------------|----------------------|
| **Dispatch** | Virtual table lookup | Direct method call |
| **Performance** | Indirect, unpredictable | Direct, optimized |
| **AOT Support** | Limited | Full support |
| **Reflection** | Required for discovery | None needed |

## Implementation via Source Generators

### Component Registry Pattern

```csharp
[GenerateComponent(typeof(Position))]
[GenerateComponent(typeof(Velocity))]
public partial class GameModule { }

// Generated at compile-time:
public static partial class AlisComponentRegistry
{
    public static void RegisterComponents(UpdateRegistry registry)
    {
        registry.Register<Position>();
        registry.Register<Velocity>();
        // No runtime reflection, no virtual dispatch
    }
}
```

### System Registration

```csharp
[GenerateSystem(typeof(MovementSystem))]
[GenerateSystem(typeof(RenderingSystem))]
public partial class GameSystems { }

// Generated:
public static partial class SystemRegistry
{
    public static void Initialize(SystemManager manager)
    {
        manager.Add(new MovementSystem());
        manager.Add(new RenderingSystem());
        // All resolved at compile-time
    }
}
```

## Benefits in Alis

| Benefit | Description |
|---------|-------------|
| **AOT Compatibility** | Full Native AOT support, no reflection |
| **Performance** | Direct calls, better inlining, no vtable lookup |
| **Type Safety** | Compile-time errors instead of runtime failures |
| **Diagnostic Support** | ALIS0xxx error codes for invalid configurations |

## Source Generator Diagnostics

| ID | Severity | Description |
|----|----------|-------------|
| ALIS001 | Error | Invalid component attribute |
| ALIS002 | Error | Missing required interface |
| ALIS003 | Warning | Unused generated type |
| ALIS004 | Error | Circular dependency detected |

## When to Use Compile-Time Polymorphism

### Suitable For
- ECS system registration
- Plugin architectures
- Dependency injection containers
- Code generation scenarios

### Not Suitable For
- Dynamic plugin loading
- Runtime type discovery
- Reflection-based frameworks

## See Also
- [`.memory/concepts/service-registration-discovery.md`] - Service Registration & Discovery
- [`.memory/sources/ecs-sources.md`] - Entity Component System
