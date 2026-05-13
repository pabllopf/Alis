# Alis - Source Generator Cache

## Overview
Source generators in Alis produce compile-time code generation for ECS, Graphic, and Aspect modules. They target netstandard2.0 and are injected as Roslyn analyzers.

## Generator Projects

### ECS Generator
| Property | Value |
|----------|-------|
| **Project** | `4_Operation/Ecs/generator/Alis.Core.Ecs.Generator.csproj` |
| **Namespace** | `Alis.Core.Ecs.Generator` |
| **Target Framework** | netstandard2.0 |
| **Injection** | Injected into 1_Presentation, 2_Application, 3_Structuration, 4_Operation |

**Generated Code Structure:**
- `Generator/Collections/` - Collection generators
- `Generator/Models/` - Model generators
- `Generator/Structures/` - Structure generators

**Purpose:** Generates ECS archetype code, component accessors, and query enumerators at compile time.

### Graphic Generator
| Property | Value |
|----------|-------|
| **Project** | `4_Operation/Graphic/generator/Alis.Core.Graphic.Generator.csproj` |
| **Namespace** | `Alis.Core.Graphic.Generator` |
| **Target Framework** | netstandard2.0 |
| **Injection** | Injected into 1_Presentation, 2_Application, 3_Structuration, 4_Operation |

**Purpose:** Generates graphic pipeline code, shader bindings, and rendering abstractions.

### Memory Generator
| Property | Value |
|----------|-------|
| **Project** | `6_Ideation/Memory/generator/Alis.Core.Aspect.Memory.Generator.csproj` |
| **Namespace** | `Alis.Core.Aspect.Memory.Generator` |
| **Target Framework** | netstandard2.0 |
| **Injection** | Injected into 1_Presentation through 5_Declaration |

**Purpose:** Generates memory management code, allocation tracking, and pool implementations.

### Fluent Generator
| Property | Value |
|----------|-------|
| **Project** | `6_Ideation/Fluent/generator/Alis.Core.Aspect.Fluent.Generator.csproj` |
| **Namespace** | `Alis.Core.Aspect.Fluent.Generator` |
| **Target Framework** | netstandard2.0 |
| **Injection** | Injected into 1_Presentation through 5_Declaration |

**Purpose:** Generates fluent API builder code, component builders, and chainable configuration.

### Data Generator
| Property | Value |
|----------|-------|
| **Project** | `6_Ideation/Data/generator/Alis.Core.Aspect.Data.Generator.csproj` |
| **Namespace** | `Alis.Core.Aspect.Data.Generator` |
| **Target Framework** | netstandard2.0 |
| **Injection** | Injected into 1_Presentation through 5_Declaration |

**Purpose:** Generates JSON serialization/deserialization code, data mappers, and validators.

## Generator Injection Mechanism

### How Generators Are Injected
Generators are injected as Roslyn analyzers via ProjectReference in Config.props:

```xml
<ProjectReference Include="**/generator/**/*.Generator.csproj"
                  OutputItemType="Analyzer"
                  PrivateAssets="all"
                  ReferenceOutputAssembly="false">
    <Properties>TargetFramework=netstandard2.0</Properties>
</ProjectReference>
```

### Injection Scope by Layer
| Layer | Generators Injected |
|-------|-------------------|
| 1_Presentation | All 5 generators (Ecs, Graphic, Memory, Fluent, Data) |
| 2_Application | All 5 generators |
| 3_Structuration | Ecs, Graphic, Memory, Fluent, Data |
| 4_Operation | Memory, Fluent, Data |
| 5_Declaration | Data |

### Build-Time Behavior (Release Mode)
In Release builds, generator DLLs are packaged as analyzers:
- Output path: `analyzers/dotnet/cs/{GeneratorName}.dll`
- Also packages `.pdb` and `.deps.json`
- Packaged into NuGet packages under `analyzers/dotnet/cs/`

## Generator External Dependencies
| Dependency | Purpose |
|------------|---------|
| Microsoft.CodeAnalysis.CSharp | Roslyn API for source generation |
| Microsoft.CodeAnalysis.Analyzers | Analyzer base classes and rules |

## Generator Output Examples

### ECS Generator Output
- Archetype-specific component accessors
- Query enumerator implementations
- Component type registration code

### Graphic Generator Output
- Shader program bindings
- Render state configuration code
- Texture format converters

### Fluent Generator Output
- Builder method implementations
- Component configuration chains
- Scene composition helpers

### Data Generator Output
- JSON serializer/deserializer implementations
- Data validation code
- Type converter implementations

### Memory Generator Output
- Object pool implementations
- Memory allocation tracking code
- Buffer management utilities
