---
title: Component Architecture
tags:
  - domain
  - api
  - reference
  - documentation

status: draft

license: GPLv3
---


## Main Pipeline

```mermaid
graph TB
    subgraph Client
        A[Client Code]
    end
    
    subgraph JsonNativeAot[JsonNativeAot Facade]
        B[Serialize<T>]
        C[Deserialize<T>]
        D[ParseJsonToDictionary]
        E[SerializeToFile<T>]
        F[DeserializeFromFile<T>]
    end
    
    subgraph Serialization[Serialization Layer]
        G[IJsonSerializer]
        H[JsonSerializer]
        I[GetSerializableProperties]
    end
    
    subgraph Deserialization[Deserialization Layer]
        J[IJsonDeserializer]
        K[JsonDeserializer]
        L[CreateFromProperties]
    end
    
    subgraph Parsing[Parsing Layer]
        M[IJsonParser]
        N[JsonParser]
        O[IEscapeSequenceHandler]
    end
    
    subgraph FileOps[File Operations]
        P[IJsonFileHandler]
        Q[JsonFileHandler]
    end
    
    A --> B
    A --> C
    A --> D
    A --> E
    A --> F
    
    B --> G
    G --> H
    H --> I
    
    C --> J
    J --> K
    K --> M
    K --> L
    
    D --> N
    N --> O
    
    E --> Q
    Q --> P
    P --> G
    P --> J
    
    style JsonNativeAot fill:#e1f5fe
    style Serialization fill:#f3e5f5
    style Deserialization fill:#e8f5e9
    style Parsing fill:#fff3e0
    style FileOps fill:#ffebee
```

## Serialization Flow

```mermaid
sequenceDiagram
    participant Client
    participant JsonNativeAot
    participant JsonSerializer
    participant Object
    
    Client->>JsonNativeAot: Serialize(obj)
    JsonNativeAot->>JsonSerializer: Serialize(obj)
    JsonSerializer->>Object: GetSerializableProperties()
    Object-->>JsonSerializer: IEnumerable<(string, string)>
    JsonSerializer-->>JsonNativeAot: JSON string
    JsonNativeAot-->>Client: string
```

## Deserialization Flow

```mermaid
sequenceDiagram
    participant Client
    participant JsonNativeAot
    participant JsonDeserializer
    participant JsonParser
    participant Object
    
    Client->>JsonNativeAot: Deserialize<T>(json)
    JsonNativeAot->>JsonDeserializer: Deserialize<T>(json)
    JsonDeserializer->>JsonParser: ParseToDictionary(json)
    JsonParser-->>JsonDeserializer: Dictionary<string, string>
    JsonDeserializer->>new T(): CreateFromProperties(dict)
    Object-->>JsonDeserializer: T instance
    JsonDeserializer-->>JsonNativeAot: T
    JsonNativeAot-->>Client: T
```

## File Operations Flow

```mermaid
graph LR
    A[Client] --> B[JsonNativeAot.SerializeToFile]
    B --> C[JsonFileHandler]
    C --> D[JsonSerializer]
    C --> E[File System]
    
    F[Client] --> G[JsonNativeAot.DeserializeFromFile]
    G --> H[JsonFileHandler]
    H --> I[JsonDeserializer]
    H --> J[File System]
    
    style B fill:#ffebee
    style G fill:#e8f5e9
```

## Component Relationships

```mermaid
graph TD
    subgraph Core
        A[JsonNativeAot]
    end
    
    subgraph Serialization
        B[IJsonSerializer]
        C[JsonSerializer]
    end
    
    subgraph Deserialization
        D[IJsonDeserializer]
        E[JsonDeserializer]
    end
    
    subgraph Parsing
        F[IJsonParser]
        G[JsonParser]
        H[IEscapeSequenceHandler]
    end
    
    subgraph FileOps
        I[IJsonFileHandler]
        J[JsonFileHandler]
    end
    
    A --> B
    A --> D
    A --> F
    A --> I
    
    B --> C
    D --> E
    F --> G
    F --> H
    I --> J
    
    style A fill:#fff9c4
    style B fill:#e1f5fe
    style D fill:#e8f5e9
    style F fill:#fff3e0
    style I fill:#f3e5f5
```

## Related

- [[Architecture]] - Architecture patterns
- [[Dependencies]] - Dependency graph
