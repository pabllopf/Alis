# Alis.Core

## Overview
Core engine aggregation project. Zero hand-written code — pure aggregator that exposes all engine subsystems.

## Project Details
- **Layer**: 3_Structuration
- **Type**: Aggregator Library
- **Framework**: net8.0 / netstandard2.0
- **Purpose**: Central engine facade

## Dependencies
- Alis.Core.Ecs (4_Operation)
- Alis.Core.Graphic (4_Operation)
- Alis.Core.Audio (4_Operation)
- Alis.Core.Physic (4_Operation)

## Key Files
- (No hand-written .cs files — aggregator only)

## Notes
- Aggregator pattern: re-exports types from lower layers
- Provides single reference for application projects
- No business logic — purely structural
