---
title: Service Registration & Discovery
tags:
  - concept
  - theory
  - documentation

status: Draft

license: GPLv3

---


Service registration and discovery provide compile-time service registry via source generators, enabling type-safe dependency injection without runtime reflection.

## Core Concept

### Compile-Time Service Registry
- **Pattern**: Generate service lookup code at compile-time
- **Location**: `*/generator/ComponentRegistryGenerator.cs`
- **Benefits**: AOT compatibility, type safety, no runtime reflection

## Implementation Example

### Service Attribute

```csharp
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
public class GenerateServiceAttribute : Attribute
{
    public Type ServiceType { get; }
    public Type? ImplementationType { get; }
    
    public GenerateServiceAttribute(Type serviceType)
    {
        ServiceType = serviceType;
        ImplementationType = null;
    }
    
    public GenerateServiceAttribute(Type serviceType, Type implementationType)
    {
        ServiceType = serviceType;
        ImplementationType = implementationType;
    }
}
```

### Service Registration Generator

```csharp
[Generator]
public class ServiceRegistryGenerator : ISourceGenerator
{
    public void Initialize(GeneratorInitializationContext context)
    {
        context.RegisterForPostGeneration(new CodeGenerator());
    }
    
    public void Execute(GeneratorExecutionContext context)
    {
        var registry = new StringBuilder();
        
        foreach (var service in FindServices(context))
        {
            registry.AppendLine($$"""
                services.AddScoped<{{service.ServiceType}}>(sp => 
                    new {{service.ImplementationType}}());
            """);
        }
        
        context.AddSource("ServiceRegistry.g.cs", registry.ToString());
    }
}

// Generated code:
public static partial class ServiceRegistry
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        // ECS services
        services.AddScoped<IEntityManager, EntityManager>();
        services.AddScoped<ISystemManager, SystemManager>();
        
        // Graphics services
        services.AddScoped<IGraphicsRenderer, SfmlGraphicsRenderer>();
        
        // Memory services
        services.AddScoped<IResourceLoader, ResourceLoader>();
        
        return services;
    }
}
```

### Usage Pattern

```csharp
public class Program
{
    public static void Main()
    {
        var services = new ServiceCollection();
        
        // Register all services via generated code
        services.RegisterServices();
        
        // Build container
        var provider = services.BuildServiceProvider();
        
        // Resolve services
        var entityManager = provider.GetRequiredService<IEntityManager>();
        var graphicsRenderer = provider.GetRequiredService<IGraphicsRenderer>();
        
        // Run application
        var game = new Game(entityManager, graphicsRenderer);
        game.Run();
    }
}
```

## Benefits

| Benefit | Description |
|---------|-------------|
| **Type Safety** | Compile-time checking of service types |
| **AOT Compatible** | No runtime reflection, full Native AOT support |
| **Performance** | Direct constructor injection, no lookup overhead |
| **Diagnostic Support** | ALIS0xxx errors for missing services |

## Service Lifecycle Patterns

### Singleton Services

```csharp
[GenerateService(typeof(ILoggingService), typeof(FileLogger))]
public class FileLogger : ILoggingService
{
    public void Log(string message) { /* ... */ }
}

// Generated:
services.AddSingleton<ILoggingService, FileLogger>();
```

### Scoped Services

```csharp
[GenerateService(typeof(IDialogueSystem), typeof(DialogueSystem))]
public class DialogueSystem : IDialogueSystem
{
    public void StartDialogue(string nodeId) { /* ... */ }
}

// Generated:
services.AddScoped<IDialogueSystem, DialogueSystem>();
```

### Transient Services

```csharp
[GenerateService(typeof(IResourceLoader), typeof(ResourceLoader))]
public class ResourceLoader : IResourceLoader
{
    public async Task<T> LoadAsync<T>(string path) { /* ... */ }
}

// Generated:
services.AddTransient<IResourceLoader, ResourceLoader>();
```

## When to Use Service Registration

### Suitable For
- Dependency injection containers
- Plugin architectures
- Testable architectures
- Modular applications

### Not Suitable For
- Simple applications without DI
- Performance-critical tight loops
- Low-frequency service resolution

## See Also
- [`.memory/concepts/compile-time-polymorphism.md`] - Compile-Time Polymorphism
