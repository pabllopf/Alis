# FileDialog Extension Module - Technical Documentation

## Overview

The FileDialog extension module provides a robust, cross-platform solution for managing file and folder selection dialogs across Windows, macOS, and Linux. This documentation covers all classes, interfaces, and their functionality.

## Table of Contents

1. [Core Interfaces](#core-interfaces)
2. [Factory Classes](#factory-classes)
3. [Implementation Classes](#implementation-classes)
4. [Configuration Classes](#configuration-classes)
5. [Result Classes](#result-classes)
6. [Utility Classes](#utility-classes)
7. [Model Classes](#model-classes)
8. [Enumerations](#enumerations)

---

## Core Interfaces

### IFilePicker
**Location:** `src/IFilePicker.cs`

The main interface that defines the contract for file picker implementations across all platforms.

**Key Methods:**
- `ChooseFile()` - Legacy method for single file selection
- `PickFile(FilePickerOptions)` - Select a single file with options
- `PickFiles(FilePickerOptions)` - Select multiple files
- `PickFolder(FilePickerOptions)` - Select a folder/directory

[View Documentation](./IFilePicker.md)

---

## Factory Classes

### FilePickerFactory
**Location:** `src/FilePickerFactory.cs`

Factory class responsible for creating the appropriate file picker implementation based on the operating system.

**Key Methods:**
- `CreateFilePicker()` - Creates platform-specific picker instance
- `CreateFilePickerWithOptions()` - Creates picker with validated options
- `GetPlatformName()` - Returns current platform name
- `IsPlatformSupported()` - Checks if platform is supported

[View Documentation](./FilePickerFactory.md)

---

## Implementation Classes

### WindowsFilePicker
**Location:** `src/WindowsFilePicker.cs`

Windows-specific implementation using PowerShell and System.Windows.Forms.

**Supported Features:**
- Single and multiple file selection
- Folder selection
- File type filters
- Default path navigation
- PowerShell-based dialog execution

[View Documentation](./WindowsFilePicker.md)

### MacFilePicker
**Location:** `src/MacFilePicker.cs`

macOS-specific implementation using AppleScript via osascript.

**Supported Features:**
- Single and multiple file selection
- Folder selection
- Default path navigation
- Native Finder dialogs
- AppleScript-based execution

[View Documentation](./MacFilePicker.md)

### LinuxFilePicker
**Location:** `src/LinuxFilePicker.cs`

Linux-specific implementation using zenity (with kdialog fallback).

**Supported Features:**
- Single and multiple file selection
- Folder selection
- File type filters
- zenity/kdialog dialog tools
- Automatic fallback mechanism

[View Documentation](./LinuxFilePicker.md)

---

## Configuration Classes

### FilePickerOptions
**Location:** `src/FilePickerOptions.cs`

Configuration class for file picker dialog options using the Fluent API pattern.

**Key Properties:**
- `Title` - Dialog window title
- `DefaultPath` - Initial browsing path
- `Filters` - File type filters
- `AllowMultiple` - Enable multi-file selection
- `AllowDirectories` - Allow folder selection
- `DialogType` - Type of dialog (OpenFile, SaveFile, SelectFolder)

**Key Methods:**
- `WithFilter()` - Add file type filter (Fluent)
- `WithDefaultPath()` - Set default path (Fluent)
- `WithMultipleSelection()` - Enable multi-selection (Fluent)
- `IsDirectoryDialog()` - Check if dialog is for directories

[View Documentation](./FilePickerOptions.md)

---

## Result Classes

### FilePickerResult
**Location:** `src/FilePickerResult.cs`

Encapsulates the result of a file picker operation.

**Key Properties:**
- `IsSuccess` - Operation success status
- `IsCancelled` - User cancellation status
- `SelectedPath` - First selected file/folder path
- `SelectedPaths` - All selected paths
- `ErrorMessage` - Error message if applicable

**Factory Methods:**
- `CreateCancelled()` - Create a cancelled result
- `CreateError()` - Create an error result

[View Documentation](./FilePickerResult.md)

---

## Utility Classes

### FilePickerValidator
**Location:** `src/FilePickerValidator.cs`

Static utility class for validating picker options, paths, and results.

**Key Methods:**
- `ValidateOptions()` - Validate picker options
- `IsValidFilePath()` - Check if file path exists
- `IsValidDirectoryPath()` - Check if directory path exists
- `IsFileExtensionAllowed()` - Validate file extension against filters
- `IsResultValid()` - Validate operation result

[View Documentation](./FilePickerValidator.md)

### FilePickerPathConverter
**Location:** `src/FilePickerPathConverter.cs`

Static utility class for cross-platform path conversion and normalization.

**Key Methods:**
- `NormalizePath()` - Remove whitespace and newlines
- `SplitMultiplePaths()` - Split concatenated path strings
- `ConvertPathSeparators()` - Convert to platform-specific separators
- `GetDirectoryName()` - Extract directory from path
- `GetFileName()` - Extract filename from path
- `IsValidPath()` - Validate path format and existence

[View Documentation](./FilePickerPathConverter.md)

### FilePickerExecutor
**Location:** `src/FilePickerExecutor.cs`

Static utility class for executing system commands for dialogs.

**Key Methods:**
- `ExecuteCommand()` - Execute system command and capture output
- `CommandExists()` - Check if command is available on system

[View Documentation](./FilePickerExecutor.md)

---

## Model Classes

### FilePickerFilter
**Location:** `src/FilePickerFilter.cs`

Model class representing a file type filter for dialogs.

**Key Properties:**
- `DisplayName` - User-friendly filter name
- `Extensions` - List of file extensions

**Key Methods:**
- `GetFormattedExtensions()` - Get Windows-style format (*.txt;*.doc)
- `GetUtiFormat()` - Get macOS UTI format (txt,doc)

[View Documentation](./FilePickerFilter.md)

---

## Enumerations

### FileDialogType
**Location:** `src/FileDialogType.cs`

Enumeration defining the types of file dialogs available.

**Values:**
- `OpenFile` - Select existing file
- `SaveFile` - Save file with validation
- `SelectFolder` - Select directory/folder

[View Documentation](./FileDialogType.md)

---

## Architecture Overview

### Design Patterns Used

1. **Factory Pattern** - FilePickerFactory creates platform-specific instances
2. **Strategy Pattern** - Each platform implements IFilePicker differently
3. **Fluent API** - FilePickerOptions uses method chaining
4. **Result Pattern** - FilePickerResult encapsulates operation outcome

### Dependency Flow

```
FilePickerFactory
    ↓
IFilePicker (interface)
    ↓
Windows/Mac/Linux Implementation
    ↓
FilePickerOptions (configuration)
FilePickerValidator (validation)
FilePickerPathConverter (path handling)
FilePickerExecutor (command execution)
    ↓
FilePickerResult (result)
```

---

## Platform Support

| Feature | Windows | macOS | Linux |
|---------|---------|-------|-------|
| Single File | ✅ | ✅ | ✅ |
| Multiple Files | ✅ | ✅ | ✅ |
| Folder Selection | ✅ | ✅ | ✅ |
| File Filters | ✅ | ⚠️ | ✅ |
| Default Path | ✅ | ✅ | ✅ |
| Native Dialogs | ✅ | ✅ | ✅ |

---

## Error Handling

All classes implement comprehensive error handling:

- **ArgumentNullException** - For null required parameters
- **ArgumentException** - For invalid parameter values
- **InvalidOperationException** - For platform/tool availability issues
- **Logging** - All errors are logged with appropriate levels

---

## Logging Integration

The module integrates with `Alis.Core.Aspect.Logging`:

- **Trace** - Method entry/exit and details
- **Info** - User actions and successful operations
- **Warning** - Invalid inputs and recoverable errors
- **Error** - Exceptions and critical failures

---

## Testing

Comprehensive test coverage:
- 103 unit tests across 7 test classes
- 100% pass rate on all platforms
- Tests for all public methods
- Edge case and error scenario coverage

---

## Usage Quick Start

```csharp
using Alis.Extension.Io.FileDialog;

// Create picker
IFilePicker picker = FilePickerFactory.CreateFilePicker();

// Configure options
var options = new FilePickerOptions("Select a file")
    .WithDefaultPath("/home/user")
    .WithFilter(new FilePickerFilter("Text Files", "txt"))
    .WithMultipleSelection();

// Execute dialog
FilePickerResult result = picker.PickFiles(options);

// Handle result
if (result.IsSuccess)
{
    foreach (var path in result.SelectedPaths)
    {
        Console.WriteLine($"Selected: {path}");
    }
}
else if (result.IsCancelled)
{
    Console.WriteLine("User cancelled");
}
else
{
    Console.WriteLine($"Error: {result.ErrorMessage}");
}
```

---

## Best Practices

1. **Always validate options** before opening dialogs
2. **Check result status** before accessing selected paths
3. **Use appropriate dialog types** for the task
4. **Handle cancellation gracefully** as a normal user action
5. **Log important operations** for debugging
6. **Provide meaningful filter names** to users

---

## Version Information

- **Version:** 2.0 (Completely Refactored)
- **Release Date:** February 2026
- **Status:** Production Ready
- **Target Framework:** .NET 5.0+

---

## Related Documentation

For detailed information about specific classes, see the individual documentation files in this directory.

Each class documentation file includes:
- Purpose and responsibility
- Public API reference
- Usage examples
- Exception information
- Best practices and tips

---

**Last Updated:** February 22, 2026
**Documentation Version:** 1.0

