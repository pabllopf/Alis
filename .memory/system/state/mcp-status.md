---
title: MCP Status
tags:
  - system
  - state
  - tracking
  - management

status: draft
---


External MCP provider integration status for enhanced repository understanding.

## MCP Providers

| Provider | Status | Last Sync | Notes |
|----------|--------|-----------|-------|
| **Context7** | Connected | Latest | Active - Technical context resolution |
| **Engram** | Connected | Latest | Active - Semantic memory building |
| **SSD** | Connected | Latest | Active - Persistence layer validation |

## Context7 MCP Usage

### When to Use
- Resolving ambiguous architecture patterns
- Mapping framework-specific behavior (.NET, EF Core, MediatR, CQRS)
- Understanding external library usage
- Clarifying design decisions
- Validating best practices

### Technical Context Resolution
- Framework behavior mapping
- Library dependency analysis
- Design pattern validation
- API interpretation

## Engram MCP Usage

### When to Use
- Building long-term semantic memory of the repository
- Connecting concepts across projects
- Detecting duplicated or semantically similar implementations
- Enriching knowledge graph links
- Improving cross-project reasoning

### Semantic Memory Building
- Cross-project concept connections
- Behavioral pattern identification
- Conceptual drift detection
- Persistent semantic indexing

## SSD MCP Usage

### When to Use
- Maintaining cross-session state consistency
- Validating incremental documentation integrity
- Synchronizing execution checkpoints
- Reconstructing partial analysis sessions
- Resolving incomplete work queues

### Persistence Layer Validation
- Execution checkpoint synchronization
- State recovery and reconstruction
- Commit boundary verification
- Long-running operation stabilization

## MCP Integration Benefits

1. **Enhanced Context** - External knowledge augmentation
2. **Semantic Enrichment** - Cross-project relationship mapping
3. **State Consistency** - Multi-session continuity
4. **Faster Resolution** - Pre-computed context retrieval

## Fallback Behavior

If MCP providers are unavailable:
- Continue with local analysis
- Mark layer as "degraded"
- Log degradation in execution log
- SSD remains authoritative fallback

## See Also
- [[Build System Configuration]]
- [[Layered Architecture]]
