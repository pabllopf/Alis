# Dependency Management

Alis follows strict dependency rules with no external NuGet packages, using only standard .NET libraries and native APIs.

## Dependency Rules

### No External Packages
- **No NuGet packages** except:
  - Microsoft.SourceLink.GitHub (for Source Link)
  - xUnit and related testing packages
  - Moq for mocking

### Standard .NET Libraries Only
- System.* namespaces
- Microsoft.Extensions.* (if available in target frameworks)
- Native platform APIs

### Dependency Direction (strict, never reverse)

```
1_Presentation → 2_Application → 3_Structuration → 4_Operation → 5_Declaration → 6_Ideation
```

Lower layers never depend on higher layers.

## Project Dependencies

### 1_Presentation
Depends on: 2_Application, 3_Structuration, 4_Operation, 5_Declaration, 6_Ideation

### 2_Application
Depends on: 3_Structuration, 4_Operation, 5_Declaration, 6_Ideation

### 3_Structuration
Depends on: None (foundation layer)

### 4_Operation
Depends on: 3_Structuration, 5_Declaration, 6_Ideation

### 5_Declaration
Depends on: 3_Structuration

### 6_Ideation
Depends on: 3_Structuration, 5_Declaration

## External API Usage

### Native APIs
- OpenGL (graphics)
- SDL2 (multimedia)
- GLFW (window management)
- FFmpeg (media processing)
- Stripe API (payments)
- Dropbox/Google Drive APIs (cloud storage)

## See Also
- [[Layered Architecture]]
- [[Build System Configuration]]
- [[Multi-Targeting Strategy]]

## Related
- [[dependency-graph]] — Layer dependency diagram
- [[build-system]] — Build configuration
- [[Repository Structure]] — Directory layout
- [[Solution Files Strategy]] — Solution organization
- [[projects/3_Structuration]] — Foundation layer
- [[projects/4_Operation]] — Operation layer
- [[projects/5_Declaration]] — Declaration layer
- [[projects/6_Ideation]] — Ideation layer
- [[architecture-index]] — Patterns index
- [[Alis Architecture Overview]] — Full architecture
