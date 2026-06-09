---
title: Alis.Extension.Io.FileDialog
tags: [presentation,application,extension,documentation]
---


## Overview

The **Alis.Extension.Io.FileDialog** project provides cross-platform file picker functionality for ALIS applications, enabling users to select files and folders through native system dialogs.

**Type**: Extension  
**Framework**: net8.0/netstandard2.0  
**Files**: 12 source files

## Purpose

This extension abstracts platform-specific file picker implementations into a unified API, supporting Windows, macOS, and Linux with consistent behavior across all platforms.

## Architecture

### Design Pattern

Implements **Factory Pattern** for platform-specific implementations:

```csharp
public static class FilePickerFactory
{
    public static IFilePicker Create()
    {
        return RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
            ? new WindowsFilePicker()
            : RuntimeInformation.IsOSPlatform(OSPlatform.MacOS)
                ? new MacFilePicker()
                : new LinuxFilePicker();
    }
}
```

### Platform Abstraction

| Platform | Implementation |
|----------|---------------|
| Windows | `WindowsFilePicker` - Uses Shell API |
| macOS | `MacFilePicker` - Uses NSSavePanel/OpenPanel |
| Linux | `LinuxFilePicker` - Uses GTK/zenity |

### Validation Layer

Implements **Validator Pattern** for file selection:

```csharp
public class FilePickerValidator
{
    public ValidationResult Validate(FilePickerOptions options);
}
```

## Components

### Core Classes

| Class | Description | Lines |
|-------|-------------|-------|
| `FilePickerExecutor` | System command executor | 157 |
| `FilePickerFactory` | Platform-aware factory | - |
| `FilePickerExecutor` | Command execution helper | 157 |
| `FilePickerValidator` | Input validation | - |

### Interfaces

| Interface | Description |
|-----------|-------------|
| `IFilePicker` | File picker contract |
| `IFilePickerFactory` | Factory interface |

### Models

| Class | Description |
|-------|-------------|
| `FilePickerOptions` | Picker configuration |
| `FilePickerResult` | Selection result |
| `FilePickerFilter` | File type filter |
| `FileDialogType` | Dialog type enum |

## Public API

### Basic Usage

```csharp
var factory = FilePickerFactory.Create();
var picker = factory.CreateFilePicker();

var options = new FilePickerOptions
{
    DialogType = FileDialogType.Open,
    Title = "Select a file",
    AllowMultiple = false
};

var result = await picker.PickFileAsync(options);

if (result.Success && result.FilePath != null)
{
    Logger.Info($"Selected: {result.FilePath}");
}
```

### File Filters

```csharp
var options = new FilePickerOptions
{
    DialogType = FileDialogType.Open,
    Filters = new List<FilePickerFilter>
    {
        new FilePickerFilter("Images", new[] { ".png", ".jpg", ".gif" }),
        new FilePickerFilter("All Files", new[] { "*.*" })
    }
};

var result = await picker.PickFileAsync(options);
```

### Folder Selection

```csharp
var options = new FilePickerOptions
{
    DialogType = FileDialogType.SelectFolder,
    Title = "Select project directory",
    DefaultPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
};

var result = await picker.PickFolderAsync(options);
```

### Save Dialog

```csharp
var options = new FilePickerOptions
{
    DialogType = FileDialogType.Save,
    Title = "Save game",
    DefaultFileName = "savegame.sav"
};

var result = await picker.PickSaveFileAsync(options);
```

### Command Execution

```csharp
// Execute system file picker command
string output = FilePickerExecutor.ExecuteCommand(
    "xdg-open", 
    "/path/to/file"
);

// Check if command exists
bool hasXdgOpen = FilePickerExecutor.CommandExists("xdg-open");
```

## Dependencies

```xml
<Project Sdk="Microsoft.NET.Sdk">
    <Import Project="$(SolutionDir).config/Config.props"/>
</Project>
```

**Internal Dependencies**:
- `Alis.Core.Aspect.Logging` - Logging aspect

**External Dependencies**:
- None (uses platform APIs via Process execution)

## Platform-Specific Behavior

### Windows

- Uses `ShellExecute` for file dialogs
- Supports drag-and-drop integration
- Native UWP dialog support

### macOS

- Uses `NSSavePanel` and `NSOpenPanel`
- Supports Quick Look preview
- Native sandbox integration

### Linux

- Falls back to `zenity`, `kdialog`, or `gtk3`
- Supports D-Bus file picker portals
- XDG specification compliant

## Usage Example

```csharp
// Cross-platform file picker
var factory = FilePickerFactory.Create();
var picker = factory.CreateFilePicker();

// Load game save
var loadOptions = new FilePickerOptions
{
    DialogType = FileDialogType.Open,
    Title = "Load Game",
    DefaultPath = GamePaths.SavesDirectory,
    Filters = new List<FilePickerFilter>
    {
        new FilePickerFilter("Save Files", new[] { ".sav", ".save" }),
        new FilePickerFilter("All Files", new[] { "*.*" })
    }
};

var loadResult = await picker.PickFileAsync(loadOptions);

if (loadResult.Success && File.Exists(loadResult.FilePath))
{
    var saveData = await File.ReadAllBytesAsync(loadResult.FilePath);
    Game.Load(saveData);
}

// Save game
var saveOptions = new FilePickerOptions
{
    DialogType = FileDialogType.Save,
    Title = "Save Game",
    DefaultFileName = $"save_{DateTime.Now:yyyyMMdd_HHmmss}.sav"
};

var saveResult = await picker.PickSaveFileAsync(saveOptions);

if (saveResult.Success)
{
    var saveData = Game.Save();
    await File.WriteAllBytesAsync(saveResult.FilePath, saveData);
    Logger.Info($"Game saved to {saveResult.FilePath}");
}
```

## Testing

**Test Project**: `Alis.Extension.Io.FileDialog.Test`  
**Sample Project**: `Alis.Extension.Io.FileDialog.Sample`

## Security Considerations

⚠️ **Path Validation**:
- Validate all file paths
- Prevent path traversal attacks

⚠️ **Command Injection**:
- Sanitize all command arguments
- Use ProcessStartInfo properly

⚠️ **File Permissions**:
- Check file read/write permissions
- Handle permission errors gracefully

## Status

| Aspect | Status |
|--------|--------|
| Implementation | ✓ Complete |
| Documentation | ✓ Documented |
| Tests | Pending |
| Samples | Pending |

## Related Projects

- [[projects/1_Presentation/Alis.Extension.Security]] - Secure data handling
- [[Alis.Core.Aspect.Logging]] - Logging system

## TODO

- [ ] Add unit tests for FilePickerExecutor
- [ ] Create file browser sample application
- [ ] Implement drag-and-drop support
- [ ] Add support for cloud storage backends
