# Alis.Extension.Thread

tags:
  - presentation,application,extension,documentation

## Overview
Parallel execution extension for ALIS ECS systems. Provides automatic work partitioning and efficient thread pool management for component update parallelization.

**Author**: Pablo Perdomo Falcón  
**License**: GNU General Public License v3.0  
**Total Source Files**: ~10 C# files across multiple directories

## Project Details
- **Layer**: 1_Presentation
- **Type**: Library (Thread Extension)
- **Framework**: net8.0
- **Output Type**: Class Library

## Purpose
Enables parallel execution of ECS component updates across multiple CPU cores. Provides automatic work partitioning, configurable thread pools, and strategy-based execution models for optimal performance.

## Key Components

### ThreadManager
Main orchestrator class:
- Manages parallel execution lifecycle
- Configurable via ParallelExtensionConfiguration
- IDisposable for resource cleanup
- Factory method pattern via configuration

### Configuration
- **ParallelExtensionConfiguration** — Thread pool and execution configuration
  - Thread count settings
  - Work partitioning strategy
  - Parallelism level control

### Execution
- **ParallelUpdateExecutor** — Component update executor
  - Work item distribution
  - Parallel loop management
  - Synchronization context

### Core Types
- **ParallelExecutionContext** — Execution context for parallel operations
- **WorkItem** — Individual unit of parallel work
- **WorkItemPool** — Object pool for work items (reduces allocations)

### Interfaces
- **IParallelCapable** — Interface for parallel-executable components
- **IParallelExecutionStrategy** — Strategy pattern for execution models

## Dependencies
- [[Alis.App.Core]] (2_Application) — Core framework

## Build Configuration
- **LangVersion**: 13 (inherited)
- **Nullable**: disabled (project-specific)

## Architecture Notes
1. Strategy pattern for execution models
2. Object pooling for work items (GC optimization)
3. Configuration-driven thread management
4. ECS-aware parallel component updates
5. Factory method via configuration.CreateExecutor()

## Testing Status
- **Unit Tests**: Present (Alis.Extension.Thread.Test)
- **Sample App**: Present

## Related Projects
- [[Alis.Core.Ecs]] (4_Operation) — ECS integration
- [[Alis.Benchmark]] — Performance benchmarking

## Documentation Version
Auto-generated from source code analysis. Last updated: 2026-06-09
