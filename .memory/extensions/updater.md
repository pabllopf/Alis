---
Extension: Updater
tags:
  - extension
  - plugin
  - updater
  - update
  - maintenance
  - documentation

status: Draft

license: GPLv3

license: GPLv3

---



## Overview

| Property | Value |
|----------|-------|
| **Namespace** | `Alis.Extension.Updater` |
| **Version** | 1.0.0 |
| **License** | GPLv3 |
| **Author** | Pablo Perdomo Falcón |
| **Layer** | 4_Operation |
| **Dependencies** | Alis.Core, System.Net.Http, System.IO.Compression |

## Purpose

The Updater extension provides automatic update functionality for Alis applications. It enables desktop applications to check for updates, download new versions, and apply them seamlessly.

## Core Components

### UpdateManager

```csharp
public class UpdateManager : IDisposable
```

Central manager that coordinates the entire update lifecycle.

**Responsibilities:**
- Check for available updates from remote sources
- Download update packages
- Verify update integrity
- Apply updates to the application
- Rollback on failure

**Key Methods:**
- `CheckForUpdatesAsync()` — Queries update server for latest version
- `DownloadUpdateAsync(UpdateInfo info)` — Downloads update package
- `ApplyUpdateAsync(UpdatePackage package)` — Installs update
- `RollbackUpdate()` — Reverts to previous version if update fails

### UpdateInfo

```csharp
public record UpdateInfo
{
    public string Version { get; init; }
    public string DownloadUrl { get; init; }
    public string Changelog { get; init; }
    public string Checksum { get; init; }
    public DateTime ReleaseDate { get; init; }
    public bool IsCritical { get; init; }
}
```

Immutable data structure containing update metadata.

### UpdatePackage

```csharp
public class UpdatePackage : IDisposable
{
    public UpdateInfo Info { get; }
    public string ExtractedPath { get; }
    public bool IsVerified { get; }
    
    public Task<bool> VerifyIntegrityAsync();
    public Task ApplyAsync(string targetDirectory);
}
```

Represents a downloaded update ready for installation.

## Update Flow

```
┌─────────────────┐
│ Check for Update │
└────────┬────────┘
         │
         ▼
┌─────────────────┐    No Update    ┌─────────────┐
│ Update Available │───────────────▶│  Up to Date │
└────────┬────────┘                └─────────────┘
         │ Yes
         ▼
┌─────────────────┐
│ Download Package │
└────────┬────────┘
         │
         ▼
┌─────────────────┐
│ Verify Checksum  │
└────────┬────────┘
         │
         ▼
┌─────────────────┐
│  Extract Files   │
└────────┬────────┘
         │
         ▼
┌─────────────────┐
│  Apply Update    │
└────────┬────────┘
         │
         ▼
┌─────────────────┐
│   Restart App    │
└─────────────────┘
```

## Configuration

```csharp
var updater = new UpdateManager(new UpdateConfig
{
    UpdateUrl = "https://api.example.com/updates",
    CheckInterval = TimeSpan.FromHours(6),
    AutoDownload = false,
    AutoApply = false,
    BackupDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "backups"),
    MaxBackupCount = 3
});
```

## Security Considerations

- All updates are verified via SHA-256 checksums
- HTTPS required for update downloads
- Rollback mechanism prevents corrupted updates
- Backup creation before applying updates

## Thread Safety

- `UpdateManager` is thread-safe for concurrent access
- Download operations use `CancellationToken` for cancellation
- File operations use async I/O to avoid blocking

## Error Handling

```csharp
try
{
    var update = await updateManager.CheckForUpdatesAsync();
    if (update != null)
    {
        await updateManager.ApplyUpdateAsync(update);
    }
}
catch (UpdateException ex)
{
    Logger.Error($"Update failed: {ex.Message}");
    updateManager.RollbackUpdate();
}
```

## Related

- [[extensions/index|Extensions Index]]
- [[architecture/repository-overview|Repository Overview]]
- [[system/indexes/projects-index|Projects Index]]
