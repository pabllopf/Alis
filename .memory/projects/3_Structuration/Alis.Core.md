# Alis.Core

## Overview
Core structuration library for ALIS game engine. Provides foundational testing infrastructure and sample applications.

**Author**: Pablo Perdomo Falcón  
**License**: GNU General Public License v3.0

## Project Details
- **Layer**: 3_Structuration
- **Type**: Library (Core Infrastructure)
- **Framework**: net8.0, netstandard2.0
- **Output Type**: Class Library

## Purpose
Provides core structuration infrastructure including:
- Testing framework setup
- Sample applications for demonstration
- Source generator integration points
- Quality improvement and validation infrastructure

## Key Components

### Testing Infrastructure
- **DefaultTest** - Base test class for unit tests
- Test assembly configuration

### Sample Applications
- **Core.Sample** - Sample application demonstrating core features

### Source Generators (Referenced)
- **Alis.Core.Ecs.Generator** - ECS component registry generator
- **Alis.Core.Aspect.Memory.Generator** - Memory aspect resource accessor generator

## Dependencies
- [[Alis.Core.Ecs]] (4_Operation) - ECS systems
- [[Alis.Core.Aspect.Memory]] (6_Ideation) - Memory aspect
- xUnit testing framework

## Build Configuration
- **LangVersion**: 13
- **Nullable**: enabled
- **Multi-targeting**: net8.0, netstandard2.0

## Quality Plan
See QualityPlan.md for improvement goals:
1. Code quality analysis and improvements
2. Unit test coverage expansion
3. Sample program enhancement
4. Architecture compliance validation

## Testing Status
- **Unit Tests**: Present (Alis.Core.Test)
- **Sample Apps**: Included (Alis.Core.Sample)

## Architecture Notes
1. Minimal source code - focuses on infrastructure
2. Source generator integration points
3. Testing and sample project templates
4. Quality improvement tracking

## Related Projects
- [[Alis.Core.Ecs.Generator]] (4_Operation) - ECS generator
- [[Alis.Core.Aspect.Memory.Generator]] (6_Ideation) - Memory generator
- [[Alis]] (2_Application) - Core application

## Documentation Version
Auto-generated from source code analysis. Last updated: 2026-06-08
