# Naming Conventions

Diagrams illustrating naming patterns and coding standards.

## Naming Convention Flow

```mermaid
flowchart TD
    subgraph "Naming Patterns"
        N1[Classes: PascalCase<br/>✅]
        N2[Methods: PascalCase<br/>✅]
        N3[Properties: PascalCase<br/>✅]
        N4[Variables: camelCase<br/>✅]
        N5[Constants: PascalCase<br/>✅]
    end
    
    subgraph "File Naming"
        F1[Classes: PascalCase.cs<br/>✅]
        F2[Interfaces: IClassName.cs<br/>✅]
        F3[Extensions: ExtensionName.cs<br/>✅]
    end
    
    N1 --> F1
    N2 --> F1
    N3 --> F1
    
    style N1 fill:#e8f5e9
    style N2 fill:#e8f5e9
    style N3 fill:#e8f5e9
```

## Coding Standards

| Standard | Status | Description |
|----------|--------|-------------|
| XML Documentation | ✅ Required | All public APIs |
| No Inline Comments | ✅ Enforced | Only XML docs |
| C# 13 Features | ✅ Used | Modern syntax |
| Multi-Targeting | ✅ Required | 15+ frameworks |

## Dependency Constraints

| Constraint | Status |
|------------|--------|
| Layer Order | ✅ Enforced |
| No External NuGet | ✅ Verified |
| AOT Compatibility | ✅ Checked |

## See Also
- [[Coding Conventions]]
- [[Dependency Constraints]]
