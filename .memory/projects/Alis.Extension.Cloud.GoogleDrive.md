---
title: Alis.Extension.Cloud.GoogleDrive
tags:
  - project
  - cloud
  - google-drive
  - storage
  - layer-1
status: Draft
license: GPLv3
---

# Alis.Extension.Cloud.GoogleDrive

## Overview

Google Drive cloud storage integration (Layer 1 - Extension). Provides cloud file management and synchronization through Google Drive API.

## Properties

| Property | Value |
|---|---|
| **Layer** | 1 - Presentation (Extension) |
| **Project Path** | `1_Presentation/Extension/Cloud/GoogleDrive/src/` |
| **Test Project** | `Alis.Extension.Cloud.GoogleDrive.Test` |
| **Has Samples** | Yes (`Alis.Extension.Cloud.GoogleDrive.Sample`) |

## Dependencies

- **Depends On**: [[Alis]] (Layer 2 - Application)
- **NuGet**: Google.Apis.Drive.v3 v1.68.0.3601

## Architecture

- Flat file structure in `src/`
- Key types: `GoogleDriveCloudManager`, `ICloudManager`

## Related

- [[Alis.Extension.Cloud.DropBox]]
- [[Projects Index]]
