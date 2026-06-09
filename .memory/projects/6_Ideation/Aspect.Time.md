---
title: Alis.Core.Aspect.Time
tags:
  - ideation
  - aspect
  - library
  - documentation

status: Draft

license: GPLv3

---


## Overview
High-level Time aspect definition with source generator. Provides Time-oriented programming capabilities.

## Project Details
- **Layer**: 6_Ideation
- **Type**: Aspect Definition + Source Generator
- **Framework**: netstandard2.0
- **Purpose**: Time aspect engine

## Sub-projects
- src/ — Aspect definition and generator implementation
- test/ — Unit tests for generator output
- sample/ — Usage examples
- Generator/ — Roslyn source generator

## Dependencies
- Alis.Core.Aspect (5_Declaration)

## Key Files
- `*.cs` — Aspect definition
- `*Generator.cs` — Roslyn source generator
- `*.generated.cs` — Generated output (in Declaration layer)

## Notes
- Source generator outputs to Alis.Core.Aspect (Declaration layer)
- Generator cascades: Ideation → Declaration → Operation → Structuration → Application → Presentation
- Each aspect follows src/test/sample/generator pattern
