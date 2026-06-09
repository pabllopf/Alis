---
title: Extension Projects
tags: [presentation,application,extension,documentation]
---


## Overview
The 1_Presentation layer contains all Extension projects — reusable libraries that provide cross-cutting capabilities to ALIS applications. Extensions are organized into subdirectories by domain.

## Extension Directory Structure
```
1_Presentation/Extension/
├── Graphic/
│   ├── Ui/          — UI framework (Alis.Extension.Graphic.Ui)
│   └── Shader/      — Shader management (Alis.Extension.Graphic.Shader)
├── Io/
│   ├── FileDialog/  — Cross-platform file dialogs (Alis.Extension.Io.FileDialog)
│   └── FilePicker/  — File picker (Alis.Extension.Io.FilePicker)
├── Language/
│   ├── Translator/  — Translation service (Alis.Extension.Language.Translator)
│   └── Dialogue/    — Dialogue system (Alis.Extension.Language.Dialogue)
├── Math/
│   ├── ProceduralDungeon/  — Dungeon generation (Alis.Extension.Math.ProceduralDungeon)
│   └── HighSpeedPriorityQueue/ — Priority queue (Alis.Extension.Math.HighSpeedPriorityQueue)
├── Media/
│   └── FFmpeg/      — FFmpeg integration (Alis.Extension.Media.FFmpeg)
├── Network/
│   ├── Client/      — Network client (Alis.Extension.Network.Client)
│   └── Server/      — Network server (Alis.Extension.Network.Server)
├── Profile/         — User profile management (Alis.Extension.Profile)
├── Thread/          — Threading utilities (Alis.Extension.Thread)
└── Updater/         — Application update mechanism (Alis.Extension.Updater)
```

## Extension Project Structure
Each extension follows a consistent 3-project pattern:
- **src/** — Main library project (Alis.Extension.*)
- **test/** — Unit test project (Alis.Extension*.Test)
- **sample/** — Sample/demo application (Alis.Extension*.Sample)

## Extension Dependencies
All extensions depend on:
- [[Alis]] (2_Application) — Core application library
- All generators from 3_Structuration, 4_Operation, 5_Declaration, 6_Ideation

## Extension Build Configuration
- **LangVersion**: 13
- **Nullable**: disable
- **AllowUnsafeBlocks**: false
- **SonarQubeExclude**: true (test projects)

## Extension Asset Pipeline
All extensions use the same asset pipeline:
- SHA256 hash-based change detection
- Incremental build via manifest file
- Base64-encoded zip archives

## Key Build Targets (All Extensions)
- `_PrepareAssetPackManifest` — Generates asset manifest with SHA256 hashes
- `ZipAssets` — Zips assets and encodes to base64

## Notes
- Extensions are the primary way to add functionality to ALIS applications
- Each extension is independently buildable and testable
- Sample projects demonstrate usage patterns

## Related

- [[projects/Index]] — All project documentation
- [[projects/Architecture]] — Layer architecture
- [[projects/Build-System]] — Build system docs
- [[projects/Generators]] — Generator references
- [[projects/Cross-Cutting-Concerns]] — Build config
- [[Multi-Platform Samples]] — Sample details
- [[adr-001-layered-architecture]] — Layer decision
- [[testing/analysis]] — Extension testing
- [[code-review-checklist]] — Extension review
- [[Alis Architecture Overview]] — Architecture concept

### Individual Extension Docs
- [[Alis.Extension.Graphic.Ui]]
- [[Alis.Extension.Graphic.Sfml]]
- [[Alis.Extension.Graphic.Glfw]]
- [[Alis.Extension.Graphic.Sdl2]]
- [[Alis.Extension.Network]]
- [[Alis.Extension.Io.FileDialog]]
- [[Alis.Extension.Security]]
- [[Alis.Extension.Payment.Stripe]]
- [[Alis.Extension.Cloud.DropBox]]
- [[Alis.Extension.Language.Translator]]
- [[Alis.Extension.Language.Dialogue]]
- [[Alis.Extension.Math.ProceduralDungeon]]
- [[Alis.Extension.Math.HighSpeedPriorityQueue]]
- [[Alis.Extension.Profile]]
- [[Alis.Extension.Thread]]
- [[Alis.Extension.Media.FFmpeg]]
- [[Alis.Extension.Updater]]
