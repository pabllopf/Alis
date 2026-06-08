# Alis.Core.Aspect.Memory

## Overview
Memory and asset management library for ALIS game engine. Provides asset packaging, caching, and registry functionality.

**Author**: Pablo Perdomo Falcón  
**License**: GNU General Public License v3.0

## Project Details
- **Layer**: 6_Ideation
- **Type**: Library (Memory Aspect)
- **Framework**: net8.0
- **Output Type**: Class Library

## Purpose
Provides comprehensive asset management system including:
- Asset packaging (assets.pack format)
- Zip archive handling and extraction
- Memory caching for fast repeated access
- Asset registry and resolution
- Thread-safe asset management

## Key Components

### ZipCacheEntry Class
- Caches raw byte content of extracted assets.pack archives
- Pre-built lookup dictionaries for O(1) access
- Maps entry paths and file names to ZipEntryInfo metadata

### AssetRegistry Class
- Registers assembly-level embedded asset packages (.pack/.zip)
- Resolves embedded resource paths by name
- Provides in-memory stream resolution
- Thread-safe caches for zip indexes
- Minimizes redundant I/O across assemblies

### ZipEntryInfo Struct
- Metadata for individual zip entries
- Path, name, and offset information

## Dependencies
- System.IO.Compression - Zip handling
- System.Security.Cryptography - Hash calculations

## Build Configuration
- **LangVersion**: 13
- **Nullable**: enabled
- **AllowUnsafeBlocks**: false

## Performance Features
1. Memory-mapped asset access
2. Concurrent dictionary for thread safety
3. Cached zip indexes
4. Minimal redundant I/O

## Testing Status
- **Unit Tests**: Present (Alis.Core.Aspect.Memory.Test)
- **Sample Apps**: Included (Alis.Core.Aspect.Memory.Sample)

## Architecture Notes
1. Static registry pattern for asset management
2. Embedded resource handling
3. SHA256 hash-based change detection
4. Cross-platform path handling (forward slashes)

## Related Projects
- [[Alis.App.Engine]] (1_Presentation) - Uses asset pack system
- [[Alis.Core.Aspect.Data]] (6_Ideation) - Data persistence

## Documentation Version
Auto-generated from source code analysis. Last updated: 2026-06-08
