---
title: Glossary Terms
tags:
  - glossary
  - definitions
  - terminology
status: Draft
license: GPLv3
---

# Glossary Terms

## A

### Aspect
Cross-cutting concern in the Alis aspect-oriented framework (Layer 5/6). Provides reusable abstractions for logging, data, math, time, memory, and fluent APIs.

### Archetype
An ECS concept - a unique combination of component types that defines a group of entities sharing the same structural layout.

## B

### Bounded Context
A logical boundary within the architecture where a particular domain model applies. Alis uses 6 architectural layers as bounded contexts.

## C

### Component
Data-only struct or class in the ECS architecture that holds state for entities. Components contain no logic.

### CQRS
Command Query Responsibility Segregation - pattern used in the aspect framework for separating read and write operations.

## D

### Data-Oriented Design
Performance-oriented design philosophy prioritizing cache efficiency, sequential memory access, and minimal indirection.

## E

### ECS (Entity-Component-System)
Architectural pattern separating entities (IDs), components (data), and systems (logic) for cache-friendly game object management.

### Entity
A lightweight identifier in the ECS that represents a game object. Entities have no behavior or data themselves.

## G

### Generator
A Roslyn source generator project that produces C# code at compile time. Used extensively for boilerplate reduction.

## I

### Ideation Layer
Layer 6 of the architecture - foundational utility modules (Data, Fluent, Logging, Math, Memory, Time).

## L

### Layer
One of the 6 architectural tiers: Presentation, Application, Structuration, Operation, Declaration, Ideation.

## M

### Multi-Framework
The ability to compile the same source code for 15+ different .NET framework targets simultaneously.

### Multi-Platform
Support for Windows, macOS, Linux, Web (WASM), Android, and iOS from a single codebase.

## N

### Native Binding
P/Invoke or interop code that calls native C/C++ libraries (SDL2, SFML, GLFW, FFmpeg, ImGui).

## O

### Operation Layer
Layer 4 of the architecture - runtime systems (ECS, Audio, Graphic, Physic).

### opcode
The repository's AI/development agent system for automated code generation and analysis.

## P

### Presentation Layer
Layer 1 of the architecture - user-facing applications, extensions, and benchmarks.

## R

### Runtime Identifier (RID)
MSBuild concept identifying target platform (e.g., `osx-arm64`, `linux-x64`, `win-x64`).

## S

### Source Generator
A Roslyn component that analyzes code during compilation and generates additional source files.

### Structuration Layer
Layer 3 of the architecture - bridges Application and Operation layers.

### System
In ECS context, a system contains the logic that operates on entities with specific component combinations.

## T

### Target Framework Moniker (TFM)
.NET framework identifier (e.g., `net8.0`, `netstandard2.0`, `net461`).

## Related

- [[Glossary Index]]
- [[Concepts Index]]
- [[Knowledge Graph Index]]
