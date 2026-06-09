---
title: Alis.App.Installer
tags:
  - application
  - software
  - tool

status: draft
---


## Overview

| Property | Value |
|----------|-------|
| **Namespace** | `Alis.App.Installer` |
| **Version** | 1.0.0 |
| **License** | GPLv3 |
| **Author** | Pablo Perdomo Falcón |
| **Layer** | 1_Presentation |
| **Dependencies** | Alis.Core |

## Purpose

Alis.App.Installer provides installation, update, and uninstallation capabilities for the Alis game engine and related components.

## Architecture

```
┌─────────────────────────────────────────────────────────┐
│                  Alis.App.Installer                     │
├─────────────────┬─────────────────┬─────────────────────┤
│    Pages        │   Services      │   Configuration     │
├─────────────────┼─────────────────┼─────────────────────┤
│ WelcomePage     │ InstallService  │ InstallerConfig     │
│ LicensePage     │ UpdateService   │ InstallManifest     │
│ ComponentsPage  │ UninstallService│ ComponentInfo       │
│ LocationPage    │ RegistryService │                     │
│ ProgressPage    │ FileService     │                     │
│ FinishPage      │                 │                     │
└─────────────────┴─────────────────┴─────────────────────┘
```

## Installer Pages

### WelcomePage

```csharp
public class WelcomePage : IInstallerPage
```

Welcome screen with introduction.

**Elements:**
- Welcome message
- Version information
- Next/Cancel buttons

### LicensePage

```csharp
public class LicensePage : IInstallerPage
```

License agreement display.

**Elements:**
- License text (GPLv3)
- Accept/Decline radio buttons
- Next button (enabled when accepted)

### ComponentsPage

```csharp
public class ComponentsPage : IInstallerPage
```

Component selection.

**Components:**
| Component | Description | Default |
|-----------|-------------|---------|
| Core Engine | Alis.Core runtime | ✅ Required |
| Editor | Alis.App.Engine | ✅ |
| Hub | Alis.App.Hub | ✅ |
| Extensions | All extensions | ✅ |
| Samples | Sample projects | ⚠️ Optional |
| Documentation | Offline docs | ⚠️ Optional |

### LocationPage

```csharp
public class LocationPage : IInstallerPage
```

Installation directory selection.

**Elements:**
- Install path input
- Browse button
- Disk space calculator
- Minimum requirements check

### ProgressPage

```csharp
public class ProgressPage : IInstallerPage
```

Installation progress display.

**Elements:**
- Progress bar
- Current operation text
- Cancel button
- Log output

### FinishPage

```csharp
public class FinishPage : IInstallerPage
```

Installation complete screen.

**Elements:**
- Success message
- Launch editor checkbox
- View readme checkbox
- Finish button

## Core Components

### InstallService

```csharp
public class InstallService
```

Handles installation operations.

**Methods:**
- `InstallAsync(InstallConfig config)` — Perform installation
- `GetInstalledVersion()` — Check if installed
- `GetInstallPath()` — Get installation directory
- `VerifyInstallation()` — Check installation integrity

### UpdateService

```csharp
public class UpdateService
```

Handles update operations.

**Methods:**
- `CheckForUpdates()` — Check for new version
- `DownloadUpdateAsync(UpdateInfo info)` — Download update
- `ApplyUpdateAsync()` — Apply update
- `RollbackUpdate()` — Revert update

### UninstallService

```csharp
public class UninstallService
```

Handles uninstallation.

**Methods:**
- `UninstallAsync()` — Remove installation
- `RemoveUserData(bool confirm)` — Remove user data
- `CleanupRegistry()` — Remove registry entries
- `GetUninstallSize()` — Calculate removal size

### RegistryService

```csharp
public class RegistryService
```

Windows registry management.

**Methods:**
- `AddUninstallEntry()` — Add to Programs and Features
- `RemoveUninstallEntry()` — Remove entry
- `SetFileAssociations()` — Associate file types
- `RemoveFileAssociations()` — Remove associations

## Installation Flow

```
┌─────────────────┐
│    Welcome      │
└────────┬────────┘
         │ Next
         ▼
┌─────────────────┐
│     License     │
└────────┬────────┘
         │ Accept
         ▼
┌─────────────────┐
│   Components    │
└────────┬────────┘
         │ Next
         ▼
┌─────────────────┐
│    Location     │
└────────┬────────┘
         │ Next
         ▼
┌─────────────────┐
│   Progress      │
│ [████████░░░░]  │
└────────┬────────┘
         │ Complete
         ▼
┌─────────────────┐
│     Finish      │
└─────────────────┘
```

## InstallManifest

```json
{
  "version": "1.0.6",
  "components": [
    {
      "name": "core",
      "version": "1.0.6",
      "files": [...],
      "size": 10485760
    },
    {
      "name": "editor",
      "version": "1.0.6",
      "files": [...],
      "size": 52428800
    }
  ],
  "dependencies": [],
  "minDiskSpace": 209715200
}
```

## Platform Support

| Platform | Status | Notes |
|----------|--------|-------|
| Windows | ✅ | Full support, registry |
| Linux | ✅ | Desktop entries |
| macOS | ✅ | App bundle |

## Error Handling

```csharp
try
{
    await installService.InstallAsync(config);
}
catch (InsufficientSpaceException ex)
{
    ShowError($"Not enough disk space. Need {ex.Required} bytes.");
}
catch (AccessDeniedException ex)
{
    ShowError("Please run installer as administrator.");
}
catch (FileCorruptedException ex)
{
    ShowError($"Downloaded file is corrupt: {ex.FileName}");
}
```

## Rollback Support

```csharp
// On installation failure, automatically rollback
installService.OnProgress += (sender, args) =>
{
    if (args.IsError)
    {
        installService.Rollback();
        ShowError("Installation failed. Changes have been reverted.");
    }
};
```

## Related

- [[applications/engine-editor|Engine Editor]]
- [[applications/hub|Hub Application]]
- [[extensions/updater|Updater Extension]]
- [[architecture/repository-overview|Repository Overview]]
