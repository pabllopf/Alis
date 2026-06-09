---
title: Glossary Index
tags:
  - glossary
  - terminology
  - reference
lastUpdated: 2026-06-09

status: draft

license: GPLv3
---


## Core Architecture Terms

- [[Entity Component System (ECS)]] - Game development architecture pattern
- [[GameObject]] - Lightweight entity identifier in ECS
- [[Scene]] - Central container for entities and systems
- [[Component]] - Data-only struct attached to entities
- [[System]] - Logic processor for components with specific attributes
- [[Archetype]] - Component type combination optimization structure

## Design Patterns

- [[Fluent Interface]] - Method chaining pattern for object configuration
- [[Builder Pattern]] - Object construction via fluent API
- [[Generic Entity Descriptor]] - Type-safe entity wrapper

## Data Structures

- [[FastestTable]] - High-performance lookup table
- [[FastestStack]] - Memory-efficient stack implementation
- [[ChunkTuple]] - Batch entity creation result container
- [[GameObjectEnumerator]] - Entity iteration enumerator

## ECS Concepts

- [[Component Storage]] - Typed component data storage
- [[Query]] - Entity filtering and iteration
- [[Rule]] - Component presence/absence constraint
- [[Update Type Attribute]] - Execution timing marker

## Memory Management

- [[ZipCacheEntry]] - Compressed cache entry
- [[AssetRegistry]] - Resource management registry
- [[ZipEntryInfo]] - Archive entry metadata

## Performance Patterns

- [[Struct Layout Pack=1]] - Memory-packed struct optimization
- [[Unsafe Context]] - Pointer-based high-performance operations
- [[Span<T>]] - Memory slice for zero-copy operations
- [[Ref<T>]] - Reference wrapper for component access

## Event System

- [[Event<T>]] - Generic event handler
- [[GameObjectFlags]] - Bitwise entity state flags
- [[ComponentEvent]] - Component lifecycle events

## Layer Architecture

See [[Layer Dependency Order]] for project organization.

## Related

- [[Alis Architecture Overview]]
- [[Layered Architecture]]
- [[Aspect-Oriented Design]]
- [[ECS Implementation Details]]
- [[Memory Management Strategies]]

## Cross-References

- [[concepts-index|Concepts Index]] - Core architectural concepts
- [[applications-index|Applications Index]] - Application terminology
- [[samples-index|Samples Index]] - Sample game terminology
- [[extensions-index|Extensions Index]] - Extension-related terms
- [[sources-index|Sources Index]] - Source code terminology
