# Dependency Graph

## Project Dependencies

### Core Engine Layer

```mermaid
graph TD
    Alis_Core[Alis.Core] --> Alis_Ecs[Alis.Core.Ecs]
    Alis_Core --> Alis_Graphic[Alis.Core.Graphic]
    Alis_Core --> Alis_Audio[Alis.Core.Audio]
    Alis_Core --> Alis_Physic[Alis.Core.Physic]
    
    Alis_Ecs --> Alis_Aspect_Math[Alis.Core.Aspect.Math]
    Alis_Ecs --> Alis_Aspect_Data[Alis.Core.Aspect.Data]
    
    Alis_Graphic --> Alis_Aspect_Memory[Alis.Core.Aspect.Memory]
```

### Ideation Layer

```mermaid
graph TD
    Alis_Aspect_Memory[Alis.Core.Aspect.Memory] --> Alis_Core
    Alis_Aspect_Fluent[Alis.Core.Aspect.Fluent] --> Alis_Core
    Alis_Aspect_Data[Alis.Core.Aspect.Data] --> Alis_Core
    Alis_Aspect_Math[Alis.Core.Aspect.Math] --> Alis_Core
    Alis_Aspect_Time[Alis.Core.Aspect.Time] --> Alis_Core
    Alis_Aspect_Logging[Alis.Core.Aspect.Logging] --> Alis_Core
```

### Extension Layer

```mermaid
graph TD
    Alis_Extension_Network[Alis.Extension.Network] --> Alis_Core
    Alis_Extension_Graphic_Ui[Alis.Extension.Graphic.Ui] --> Alis_Core
    Alis_Extension_Graphic_SFML[Alis.Extension.Graphic.Sfml] --> Alis_Core
    Alis_Extension_Payment_Stripe[Alis.Extension.Payment.Stripe] --> Alis_Core
```

### Application Layer

```mermaid
graph TD
    Alis_App_Engine[Alis.App.Engine] --> Alis_Core_Ecs[Alis.Core.Ecs]
    Alis_App_Engine --> Alis_Core_Graphic[Alis.Core.Graphic]
    Alis_App_Hub[Alis.App.Hub] --> Alis_Core
    Alis_App_Installer[Alis.App.Installer] --> Alis_Core
```

## Layer Violations

- **None detected** - Architecture appears well-separated

## Cyclic Dependencies

- **None detected** - No circular references found

## Infrastructure Coupling

- Heavy use of platform-specific native bindings in Graphic system
- Memory management dependencies across multiple systems

## Key Dependencies

| Dependency | Type | Usage |
|---|---|---|
| System.Memory | Runtime | Span<T>, Memory<T> for performance |
| System.Runtime.CompilerServices.Unsafe | Runtime | Low-level memory operations |
| SFML/OpenGL | Native | Graphics rendering |
| Platform SDKs | Native | macOS, Windows, Linux support |
