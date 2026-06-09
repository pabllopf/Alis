---
title: Alis.Extension.Cloud.DropBox
tags:
  - presentation
  - application
  - extension
  - documentation

status: Draft

license: GPLv3

---


## Overview

The **Alis.Extension.Cloud.DropBox** project provides Dropbox integration for file storage, synchronization, and backup capabilities within ALIS applications.

**Type**: Extension  
**Framework**: net8.0/netstandard2.0  
**Files**: 2 source files (DropBox + interface)

## Purpose

This extension enables seamless integration with Dropbox API for cloud storage operations including file upload, download, listing, and management.

## Components

### Core Classes

| Class | Description | Lines |
|-------|-------------|-------|
| `DropBoxCloudManager` | Main Dropbox integration manager | 347 |
| `ICloudManager` | Cloud manager interface | - |

### Supporting Types

- `DropboxClient` - Official Dropbox SDK wrapper
- `FileMetadata` - File information from Dropbox
- `Metadata` - General file/folder metadata

## Architecture

### Design Pattern

Implements the **Manager Pattern** with **Dependency Injection**:

```csharp
public class DropBoxCloudManager : AManager, ICloudManager, IDisposable
{
    private DropboxClient _dropboxClient;
    private string _accessToken;
}
```

### Lifecycle Management

Implements `IDisposable` pattern for proper resource cleanup:

```csharp
public void Dispose()
{
    Dispose(true);
    GC.SuppressFinalize(this);
}
```

### Async/Await Pattern

All operations are asynchronous to prevent UI blocking:

```csharp
public async Task<FileMetadata> UploadFileAsync(string localFilePath, string dropboxPath)
public async Task DownloadFileAsync(string dropboxPath, string localFilePath)
```

## Public API

### Initialization

```csharp
var dropboxManager = new DropBoxCloudManager(context);
await dropboxManager.InitializeAsync(accessToken);
```

### File Operations

| Method | Description |
|--------|-------------|
| `UploadFileAsync(localPath, dropboxPath)` | Upload file to Dropbox |
| `DownloadFileAsync(dropboxPath, localPath)` | Download file from Dropbox |
| `ListFilesAsync(folderPath, recursive)` | List files in folder |
| `DeleteAsync(dropboxPath)` | Delete file/folder |
| `GetMetadataAsync(dropboxPath)` | Get file metadata |

### Status Checks

```csharp
bool IsInitialized => dropboxClient != null && !string.IsNullOrEmpty(accessToken);
```

## Usage Example

```csharp
// Initialize with access token
var dropboxManager = new DropBoxCloudManager(gameContext);
await dropboxManager.InitializeAsync(userAccessToken);

// Upload a save file
await dropboxManager.UploadFileAsync(
    "/local/saves/game.sav",
    "/ALIS/Saves/game.sav"
);

// Download user settings
await dropboxManager.DownloadFileAsync(
    "/ALIS/Settings/user.json",
    "/local/config.json"
);

// List all saves
var files = await dropboxManager.ListFilesAsync("/ALIS/Saves");
foreach (var file in files)
{
    Console.WriteLine(file.Name);
}

// Delete old save
await dropboxManager.DeleteAsync("/ALIS/Saves/old.sav");
```

## Dependencies

```xml
<Project Sdk="Microsoft.NET.Sdk">
    <Import Project="$(SolutionDir).config/Config.props"/>
</Project>
```

**External Dependencies**:
- `Dropbox.Api` - Official Dropbox SDK

**Internal Dependencies**:
- `Alis.Core.Aspect.Logging` - Logging aspect
- `Alis.Core.Ecs.Systems.Manager` - Manager base class

## Error Handling

### Exceptions

| Exception | Trigger |
|-----------|---------|
| `InvalidOperationException` | Not initialized, invalid path |
| `ArgumentException` | Null/empty parameters |
| `FileNotFoundException` | Local file not found |
| `DropboxApiException` | Dropbox API errors |

### Logging

All operations log to ALIS logger:

```csharp
Logger.Info($"File uploaded successfully to DropBox: {dropboxPath}");
Logger.Error($"Failed to upload file to DropBox: {ex.Message}");
```

## Testing

**Test Project**: `Alis.Extension.Cloud.DropBox.Test`  
**Sample Project**: `Alis.Extension.Cloud.DropBox.Sample`

## Security Considerations

⚠️ **Access Token Management**:
- Store tokens securely (never in plain text)
- Use OAuth2 flow for user authentication
- Refresh tokens before expiration

⚠️ **Path Validation**:
- All paths must start with `/`
- Path traversal attacks prevented by SDK

## Status

| Aspect | Status |
|--------|--------|
| Implementation | ✓ Complete |
| Documentation | ✓ Documented |
| Tests | ✓ Unit tests exist |
| Samples | Pending |

## Related Projects

- [[Alis.Extension.Cloud.GoogleDrive]] - Google Drive integration
- [[projects/1_Presentation/Alis.Extension.Security]] - Secure data handling
- [[Alis.Core.Aspect.Logging]] - Logging system

## TODO

- [ ] Add integration tests with mock Dropbox
- [ ] Create sample file manager application
- [ ] Implement folder creation operations
- [ ] Add batch file operations
