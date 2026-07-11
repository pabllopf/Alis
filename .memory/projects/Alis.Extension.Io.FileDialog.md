---
title: Alis.Extension.Io.FileDialog
tags:
  - project
  - io
  - file-dialog
  - file-picker
  - layer-1
status: Draft
license: GPLv3
---

# Alis.Extension.Io.FileDialog

## Overview

Cross-platform file dialog extension (Layer 1 - Extension). Provides native file open/save dialog support across Windows, macOS, and Linux.

## Properties

| Property | Value |
|---|---|
| **Layer** | 1 - Presentation (Extension) |
| **Project Path** | `1_Presentation/Extension/Io/FileDialog/src/` |
| **Test Project** | `Alis.Extension.Io.FileDialog.Test` |
| **Has Samples** | Yes (`Alis.Extension.Io.FileDialog.Sample`) |

## Dependencies

- **Depends On**: [[Alis]] (Layer 2 - Application)

## Architecture

- Flat file structure in `src/`
- Platform-specific implementations: `MacFilePicker`, `WindowsFilePicker`, `LinuxFilePicker`
- Factory pattern: `FilePickerFactory`

## Related

- [[Alis.App.Engine]]
- [[Projects Index]]
