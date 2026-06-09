---
title: Sources Index
tags:
  - source
  - reference
  - documentation
lastUpdated: 2026-06-09

status: Draft

license: GPLv3

---


Comprehensive index of all source files and projects in the Alis solution.

## Source Categories

### 1_Presentation - User-Facing Applications

| Project | Type | Files | Purpose |
|---------|------|-------|---------|
| **Engine** | Runtime | 50+ | Main game engine runtime |
| **Hub** | Application | 20+ | Hub application for management |
| **Installer** | Application | 15+ | Installation application |
| **Extension/** | Extensions | 200+ | 18+ modular extensions |
| **Benchmark** | Benchmarks | 30+ | Performance benchmarks |

### 4_Operation - Operational Systems

| Project | Type | Files | Purpose |
|---------|------|-------|---------|
| **Ecs** | ECS Runtime | 100+ | Entity Component System + Generator |
| **Graphic** | Graphics | 80+ | Graphics rendering + Generator |
| **Audio** | Audio | 30+ | Audio processing |
| **Physic** | Physics | 40+ | Physics engine |

### 6_Ideation - Experimental Aspects

| Project | Type | Files | Purpose |
|---------|------|-------|---------|
| **Memory** | Memory | 50+ | Memory abstractions + Generator |
| **Fluent** | Fluent APIs | 40+ | Fluent APIs + Generator |
| **Data** | Data Structures | 45+ | Data structures + Generator |
| **Math** | Math Utilities | 30+ | Mathematical utilities |
| **Time** | Time Management | 25+ | Time management |
| **Logging** | Logging | 35+ | Logging infrastructure |

## Source File Types

| Type | Count | Description |
|------|-------|-------------|
| `.cs` source files | 500+ | Main C# source code |
| `.cs` test files | 200+ | Unit and integration tests |
| `.cs` generated | 300+ | Source-generated code |
| `.cs` benchmarks | 50+ | Performance benchmarks |

## Key Source Files

### Engine Core
- `Engine/src/` - Main engine runtime
- `Engine/src/Core/` - Core engine functionality

### ECS System
- `4_Operation/Ecs/src/Entity.cs` - Entity definition
- `4_Operation/Ecs/src/System.cs` - System base class
- `4_Operation/Ecs/src/Query.cs` - Component queries
- `4_Operation/Ecs/generator/` - ECS source generator

### Extensions
- `1_Presentation/Extension/Graphic.*` - Graphics extensions
- `1_Presentation/Extension/Cloud.*` - Cloud storage extensions
- `1_Presentation/Extension/Payment.*` - Payment processing

### Aspects
- `6_Ideation/Memory/src/` - Memory abstractions
- `6_Ideation/Fluent/src/` - Fluent APIs
- `6_Ideation/Data/src/` - Data structures

## See Also

- [[Alis Architecture Overview]]
- [[Layered Architecture]]
- [[Generator Pattern]]

## Cross-References

- [[concepts-index|Concepts Index]] - Concepts implemented in source
- [[projects-index|Projects Index]] - Project organization
- [[glossary-index|Glossary Index]] - Terminology for source files
