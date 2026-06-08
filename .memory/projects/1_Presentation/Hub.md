# Alis.App.Hub

## Overview
Game hub/launcher application for managing and launching ALIS games. Includes Editor and Installer integration.

## Project Details
- **Layer**: 1_Presentation
- **Type**: Application (Desktop)
- **Framework**: net8.0
- **Output Type**: Exe
- **Output Dir**: `bin/$(Configuration)/$(RuntimeIdentifier)/lib/`

## Dependencies
- [[Alis]] (2_Application) — Core application library
- [[Alis.Extension.Graphic.Ui]] — UI framework
- [[Alis.Extension.Updater]] — Application update mechanism
- [[Alis.Extension.Io.FileDialog]] — Cross-platform file dialogs
- All generators from 3_Structuration, 4_Operation, 5_Declaration, 6_Ideation

## Build Configuration
- **LangVersion**: 13
- **Nullable**: disable
- **AllowUnsafeBlocks**: false
- **SonarQubeExclude**: true
- **WarningLevel**: 0

## Auto-Build Targets (Hub-specific)
- `BuildAndCopyEngineOutput` — Builds Engine and copies to Hub's Editor directory
- `BuildAndCopyInstallerOutput` — Builds Installer and copies to Hub's Installer directory

## Platform-Specific Bundle Targets (Release only)
- **macOS**: `CreateMacOsBundle` — Creates .app bundle with dmg generation
  - Structure: `Alis.app/Contents/MacOS/`, `Alis.app/Contents/Resources/`
  - Copies Info.plist and logo.png
  - Generates DMG with retry logic (3 attempts for Spotlight issues)
- **Linux**: `CreateLinuxBundle` — Creates zip distribution
- **Windows**: `CreateWindowsBundle` — Creates zip distribution

## Asset Pipeline
- Uses [[#Asset Pack System]] for resource management
- SHA256 hash-based change detection
- Incremental build via manifest file

## Key Build Targets
- `_PrepareAssetPackManifest` — Generates asset manifest with SHA256 hashes
- `ZipAssets` — Zips assets and encodes to base64
- `BuildAndCopyEngineOutput` — Auto-builds Engine dependency
- `BuildAndCopyInstallerOutput` — Auto-builds Installer dependency
- `CreateMacOsBundle` — Creates macOS .app + DMG (Release only)
- `CreateLinuxBundle` — Creates Linux zip (Release only)
- `CreateWindowsBundle` — Creates Windows zip (Release only)

## Platform Detection
- **LINUX**: Defined when RuntimeIdentifier contains 'linux' or matches distro patterns
- **OSX**: Defined when RuntimeIdentifier contains 'osx'
- **WIN**: Defined when RuntimeIdentifier contains 'win'

## Notes
- Hub is the central application that orchestrates Engine and Installer
- macOS bundle includes Editor subdirectory if present
- DMG creation has retry logic for Spotlight-related issues
