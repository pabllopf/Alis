# Context Management

Diagrams illustrating context handling and state management.

## Context Flow

```mermaid
flowchart TD
    subgraph "Context Sources"
        S1[User Prompt]
        S2[Session History]
        S3[Memory Artifacts]
    end
    
    subgraph "Context Processing"
        P1[Parse Input]
        P2[Retrieve History]
        P3[Generate Context]
    end
    
    subgraph "Output"
        O1[Enhanced Response]
        O2[Updated Memory]
    end
    
    S1 --> P1
    S2 --> P2
    S3 --> P3
    
    P1 --> P3
    P2 --> P3
    
    P3 --> O1
    P3 --> O2
    
    style P3 fill:#e8f5e9
```

## Context Categories

| Category | Description | Status |
|----------|-------------|--------|
| User Prompt | Current request context | ✅ Active |
| Session History | Previous session data | ✅ Archived |
| Memory Artifacts | Persistent knowledge | ✅ Indexed |

## See Also
- [[Onboarding]]
- [[Project Map]]
