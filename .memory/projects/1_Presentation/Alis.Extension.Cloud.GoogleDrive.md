---
title: Alis.Extension.Cloud.GoogleDrive
tags:
  - presentation
  - application
  - extension
  - documentation

status: draft

license: GPLv3
---


## Overview
Google Drive cloud storage integration for ALIS applications. Provides file upload, download, and management via Google Drive API v3.

**Author**: Pablo Perdomo Falcón  
**License**: GNU General Public License v3.0  
**Total Source Files**: ~3 C# files

## Project Details
- **Layer**: 1_Presentation
- **Type**: Library (Cloud Extension)
- **Framework**: net8.0
- **Output Type**: Class Library

## Purpose
Integrates Google Drive cloud storage into ALIS applications. Enables cloud save/load for game data, asset synchronization, and backup management using OAuth 2.0 authentication.

## Key Components

### GoogleDriveCloudManager
Main cloud management class:
- OAuth 2.0 authentication flow
- File upload/download operations
- File listing and search
- Folder management
- Progress tracking for transfers
- Integration with ALIS ECS manager system

### ICloudManager
Cloud storage abstraction interface:
- UploadAsync / DownloadAsync
- ListFilesAsync / DeleteAsync
- CreateFolderAsync

## Dependencies
- [[Alis.Core.Aspect.Logging]] (6_Ideation) — Logging
- [[Alis.Core.Ecs]] (4_Operation) — ECS manager integration
- **Google.Apis.Drive.v3** — Google Drive API client
- **Google.Apis.Auth** — OAuth 2.0 authentication

## Build Configuration
- **LangVersion**: 13 (inherited)
- **Nullable**: disabled (project-specific)

## Architecture Notes
1. OAuth 2.0 token-based authentication
2. Async-first API for all operations
3. ECS integration via AManager base class
4. IDisposable pattern for resource cleanup
5. Google Drive API v3 integration

## Testing Status
- **Unit Tests**: Present (Alis.Extension.Cloud.GoogleDrive.Test)
- **Sample App**: Present

## Related Projects
- [[Alis.Extension.Cloud.DropBox]] — DropBox cloud storage
- [[Alis.Extension.Updater]] — Update download system
- [[Alis.Core.Ecs]] — ECS integration

## Documentation Version
Auto-generated from source code analysis. Last updated: 2026-06-09
