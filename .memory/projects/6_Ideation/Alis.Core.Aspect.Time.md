# Alis.Core.Aspect.Time

## Overview
Time measurement library for ALIS game engine. Provides high-resolution timing utilities similar to stopwatch functionality.

**Author**: Pablo Perdomo Falcón  
**License**: GNU General Public License v3.0

## Project Details
- **Layer**: 6_Ideation
- **Type**: Library (Time Aspect)
- **Framework**: net8.0
- **Output Type**: Class Library

## Purpose
Provides high-resolution time measurement utilities for game development including:
- Elapsed time tracking
- Start/stop/reset/restart operations
- High-resolution timing for performance measurement
- Game loop timing management

## Key Components

### Clock Class
- High-resolution time measurement utility
- Similar to Stopwatch functionality
- Uses DateTime.UtcNow as underlying time source
- Start, stop, reset, and restart operations
- Elapsed time accumulation

### Features
- Elapsed time tracking (TimeSpan)
- Accurate timing for game loops
- Performance measurement utilities

## Dependencies
- System - DateTime operations

## Build Configuration
- **LangVersion**: 13
- **Nullable**: enabled
- **AllowUnsafeBlocks**: false

### Thread Safety
- **Not thread-safe** - Instances should not be shared across threads without external synchronization
- Accumulates elapsed time until stopped

## Testing Status
- **Unit Tests**: Present (Alis.Core.Aspect.Time.Test)
- **Sample Apps**: Included (Alis.Core.Aspect.Time.Sample)

## Architecture Notes
1. Simple, focused timing utility
2. No external dependencies
3. Clear API for time measurement
4. Game loop integration ready

## Related Projects
- [[Alis.Core.Ecs]] (4_Operation) - Uses timing for update loops
- [[Alis]] (2_Application) - Core application uses Clock

## Documentation Version
Auto-generated from source code analysis. Last updated: 2026-06-08
