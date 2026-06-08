# Alis.Core.Aspect

## Overview
Aspect-oriented programming system. Zero hand-written code — pure aggregator for generated aspects.

## Project Details
- **Layer**: 5_Declaration
- **Type**: Aggregator Library (Aspect System)
- **Framework**: netstandard2.0
- **Purpose**: Aspect declarations and aggregations

## Dependencies
- (None — aggregator only, receives generated code from 6_Ideation generators)

## Key Files
- (No hand-written .cs files — aggregator only)

## Notes
- Receives generated code from Ideation layer generators
- Aggregator pattern: re-exports all aspect types
- Pure structural project — no business logic
