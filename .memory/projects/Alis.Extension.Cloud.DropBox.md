---
title: Alis.Extension.Cloud.DropBox
tags:
  - project
  - cloud
  - dropbox
  - storage
  - layer-1
status: Draft
license: GPLv3
---

# Alis.Extension.Cloud.DropBox

## Overview

Dropbox cloud storage integration (Layer 1 - Extension). Provides cloud file management and synchronization through Dropbox API.

## Properties

| Property | Value |
|---|---|
| **Layer** | 1 - Presentation (Extension) |
| **Project Path** | `1_Presentation/Extension/Cloud/DropBox/src/` |
| **Test Project** | `Alis.Extension.Cloud.DropBox.Test` |
| **Has Samples** | Yes (`Alis.Extension.Cloud.DropBox.Sample`) |

## Dependencies

- **Depends On**: [[Alis]] (Layer 2 - Application)
- **NuGet**: Dropbox.Api v7.0.0

## Architecture

- Flat file structure in `src/`
- Key types: `DropBoxCloudManager`, `ICloudManager`

## Related

- [[Alis.Extension.Cloud.GoogleDrive]]
- [[Projects Index]]
