---
title: Alis.Core.Physic
tags:
  - operation
  - runtime
  - implementation
  - documentation

status: draft

license: GPLv3
---


## Overview
Core engine Physic subsystem. Provides low-level Physic functionality for the game engine.

## Project Details
- **Layer**: 4_Operation
- **Type**: Engine Subsystem
- **Framework**: net8.0 / netstandard2.0
- **Purpose**: Physic engine operations

## Sub-projects
- src/ — Main implementation
- test/ — Unit tests
- sample/ — Usage examples
- Generator/ — Source generator (where applicable)

## Dependencies
- Alis.Core.Aspect (5_Declaration)

## Key Files
- `*.cs` — Physic implementation
- `*.Generator.cs` — Generated code (from Roslyn generator)

## Notes
- Uses source generators for boilerplate reduction
- Generator outputs to Alis.Core.Aspect (Declaration layer)
- Exposed through Alis.Core aggregator
