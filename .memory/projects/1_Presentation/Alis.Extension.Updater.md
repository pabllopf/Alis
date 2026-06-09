---
title: Alis.Extension.Updater
tags:
  - presentation
  - application
  - extension
  - documentation

status: draft

license: GPLv3
---


## Overview
Self-update mechanism for ALIS applications. Downloads, verifies, and installs application updates from GitHub releases.

**Author**: Pablo Perdomo Falcón  
**License**: GNU General Public License v3.0  
**Total Source Files**: ~10 files (932 lines in UpdateManager.cs alone)

## Project Details
- **Layer**: 1_Presentation
- **Type**: Library (Updater Extension)
- **Framework**: net8.0
- **Output Type**: Class Library

## Purpose
Provides an automatic update system for ALIS applications. Connects to GitHub Releases API to download, verify, and install the latest version of the application. Supports cross-platform package formats (.zip and .dmg) with rollback safety via automatic backups.

## Key Components

### UpdateManager
Main orchestrator class handling the complete update workflow:
- GitHub API integration for release discovery
- Platform detection (win/linux/osx) and architecture detection
- Package download with progress reporting
- Safe extraction with zip bomb protection (threshold: 10k entries, 1GB size, 70:1 compression ratio)
- Automatic backup before installation
- Rollback safety with old backup cleanup (keeps last 2)
- Cancellation support via CancellationToken
- Event-driven progress reporting

### Event System
- **UpdateProgressEventHandler** — Progress and status event delegate

### Services
- **GitHubApiService** — GitHub API communication
- **FileService** — File management operations

## Dependencies
- [[Alis.Core.Aspect.Logging]] (6_Ideation) — Logging
- **System.Net.Http** — HTTP communication
- **System.IO.Compression** — Zip extraction

## Build Configuration
- **LangVersion**: 13 (inherited)
- **Nullable**: disabled (project-specific)

## Platform Support
- Windows (win-x64)
- macOS (osx-x64, .dmg packages)
- Linux (linux-x64)

## Architecture Notes
1. GitHub-first release management strategy
2. Platform-arch aware asset selection
3. Zip bomb protection thresholds
4. Backup-before-replace safety pattern
5. macOS .dmg mount/copy/unmount workflow
6. Single-file async download with HttpClient

## Security Considerations
- Path traversal protection in zip extraction
- Compression ratio validation (zip bomb protection)
- Entry count and total size limits
- Backup preservation for rollback

## Testing Status
- **Unit Tests**: Present (Alis.Extension.Updater.Test)
- **Sample App**: Present

## Related Projects
- [[Alis.Extension.Cloud.DropBox]] — Cloud storage integration
- [[Alis.Extension.Cloud.GoogleDrive]] — Cloud storage integration

## Documentation Version
Auto-generated from source code analysis. Last updated: 2026-06-09
