# Alis.Core.Aspect.Math

tags:
  - ideation,aspect,library,documentation

## Overview
High-level Math aspect definition with source generator. Provides Math-oriented programming capabilities.

## Project Details
- **Layer**: 6_Ideation
- **Type**: Aspect Definition + Source Generator
- **Framework**: netstandard2.0
- **Purpose**: Math aspect engine

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
