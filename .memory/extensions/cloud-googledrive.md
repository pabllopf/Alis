# Extension: Cloud.GoogleDrive

tags:
  - extension,plugin,add-on

## Overview

| Property | Value |
|----------|-------|
| **Namespace** | `Alis.Extension.Cloud.GoogleDrive` |
| **Version** | 1.0.0 |
| **License** | GPLv3 |
| **Author** | Pablo Perdomo Falcón |
| **Layer** | 4_Operation |
| **Dependencies** | Alis.Core, Google.Apis.Drive.v3 |

## Purpose

The Google Drive extension provides cloud storage integration, enabling Alis applications to upload, download, and sync files with Google Drive.

## Core Components

### GoogleDriveCloudManager

```csharp
public class GoogleDriveCloudManager
```

Manages Google Drive API operations.

**Responsibilities:**
- Authenticate with Google Drive API
- Upload files to Drive
- Download files from Drive
- List and search files
- Manage folders

**Key Methods:**
- `Authenticate(string credentialsPath)` — Initialize with service account
- `UploadFileAsync(string localPath, string remotePath)` — Upload file
- `DownloadFileAsync(string remoteId, string localPath)` — Download file
- `ListFilesAsync(string folderId)` — List files in folder
- `SearchFilesAsync(string query)` — Search for files
- `DeleteFileAsync(string fileId)` — Delete file
- `CreateFolderAsync(string name, string parentId)` — Create folder

### DriveFile

```csharp
public record DriveFile
{
    public string Id { get; init; }
    public string Name { get; init; }
    public string MimeType { get; init; }
    public long Size { get; init; }
    public DateTime CreatedTime { get; init; }
    public DateTime ModifiedTime { get; init; }
    public string WebViewLink { get; init; }
}
```

Metadata for a file stored in Google Drive.

## Authentication

```csharp
// Service account authentication
var manager = new GoogleDriveCloudManager();
manager.Authenticate("credentials.json");

// OAuth2 authentication
manager.AuthenticateOAuth("client_id", "client_secret", redirectUri);
```

## File Operations

### Upload

```csharp
// Upload with progress
var file = await manager.UploadFileAsync(
    localPath: "savegame.dat",
    remotePath: "Alis/Saves/savegame.dat",
    onProgress: (bytesUploaded, totalBytes) =>
    {
        var percent = (double)bytesUploaded / totalBytes * 100;
        Console.WriteLine($"Upload progress: {percent:F1}%");
    }
);

Console.WriteLine($"Uploaded: {file.Id}");
```

### Download

```csharp
// Download file
await manager.DownloadFileAsync(
    remoteId: "1abc123...",
    localPath: "downloads/savegame.dat"
);

// Download with progress
await manager.DownloadFileAsync(
    remoteId: "1abc123...",
    localPath: "downloads/savegame.dat",
    onProgress: (bytesDownloaded, totalBytes) =>
    {
        Console.WriteLine($"Download: {bytesDownloaded}/{totalBytes}");
    }
);
```

### List Files

```csharp
// List all files in folder
var files = await manager.ListFilesAsync("folder_id");
foreach (var file in files)
{
    Console.WriteLine($"{file.Name} ({file.Size} bytes)");
}

// Search for files
var results = await manager.SearchFilesAsync("name contains 'save'");
```

## Use Cases

| Use Case | Description |
|----------|-------------|
| Cloud Saves | Sync game saves to Google Drive |
| Asset Storage | Store game assets in cloud |
| Leaderboards | Store leaderboard data |
| Settings Sync | Sync settings across devices |

## Platform Support

| Platform | Status | Notes |
|----------|--------|-------|
| Windows | ✅ | Full support |
| Linux | ✅ | Full support |
| macOS | ✅ | Full support |
| Web (WASM) | ⚠️ | Limited (CORS) |

## Security Considerations

- Credentials should not be committed to source control
- Use environment variables or secure storage for API keys
- Implement proper error handling for authentication failures

## Error Handling

```csharp
try
{
    var file = await manager.UploadFileAsync(localPath, remotePath);
}
catch (GoogleApiException ex)
{
    Logger.Error($"Google Drive API error: {ex.Message}");
}
catch (Exception ex)
{
    Logger.Error($"Upload failed: {ex.Message}");
}
```

## Related

- [[extensions/index|Extensions Index]]
- [[extensions/updater|Updater Extension]]
- [[architecture/repository-overview|Repository Overview]]
