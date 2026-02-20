# IFilePicker Interface Documentation

## Overview

`IFilePicker` is the core interface that defines the contract for file and folder picker implementations across all supported platforms (Windows, macOS, and Linux).

## Namespace

```csharp
using Alis.Extension.Io.FileDialog;
```

## Interface Definition

```csharp
public interface IFilePicker
{
    string ChooseFile();
    FilePickerResult PickFile(FilePickerOptions options);
    FilePickerResult PickFiles(FilePickerOptions options);
    FilePickerResult PickFolder(FilePickerOptions options);
}
```

## Methods

### ChooseFile()

**Signature:**
```csharp
string ChooseFile();
```

**Description:**
Opens a file picker dialog to select a single file using the legacy approach. This method maintains backward compatibility with existing code.

**Returns:**
- `string` - The full path of the selected file, or `null` if the dialog was cancelled.

**Exceptions:**
- `Exception` - May throw if the dialog cannot be opened or the system command fails.

**Remarks:**
- This is a legacy method maintained for backward compatibility.
- No configuration options are available.
- Uses default dialog title "Select a file".
- Better practice is to use `PickFile(FilePickerOptions)` for more control.

**Example:**
```csharp
IFilePicker picker = FilePickerFactory.CreateFilePicker();
string selectedFile = picker.ChooseFile();

if (!string.IsNullOrEmpty(selectedFile))
{
    Console.WriteLine($"File selected: {selectedFile}");
}
else
{
    Console.WriteLine("No file selected");
}
```

---

### PickFile(FilePickerOptions options)

**Signature:**
```csharp
FilePickerResult PickFile(FilePickerOptions options);
```

**Description:**
Opens a file picker dialog with advanced options to select a single file. This is the preferred method for single file selection with customization.

**Parameters:**
- `options` - `FilePickerOptions` object containing dialog configuration.

**Returns:**
- `FilePickerResult` - An object containing the selection result (success/cancellation/error status and selected path).

**Exceptions:**
- `ArgumentNullException` - Thrown if `options` is null.
- `ArgumentException` - Thrown if options contain invalid values.
- `InvalidOperationException` - Thrown if the platform is not supported.

**Remarks:**
- Returns a `FilePickerResult` object which indicates success, cancellation, or error.
- Always check `result.IsSuccess` before using `result.SelectedPath`.
- Supports file type filters, default paths, and dialog customization.
- Does not allow multiple file selection (even if `AllowMultiple` is true in options).

**Example:**
```csharp
var options = new FilePickerOptions("Open a Document")
    .WithDefaultPath("/home/user/Documents")
    .WithFilter(new FilePickerFilter("PDF Files", "pdf"))
    .WithFilter(new FilePickerFilter("Word Documents", "doc", "docx"));

FilePickerResult result = picker.PickFile(options);

if (result.IsSuccess)
{
    Console.WriteLine($"Selected: {result.SelectedPath}");
}
else if (result.IsCancelled)
{
    Console.WriteLine("Dialog cancelled by user");
}
else
{
    Console.WriteLine($"Error: {result.ErrorMessage}");
}
```

---

### PickFiles(FilePickerOptions options)

**Signature:**
```csharp
FilePickerResult PickFiles(FilePickerOptions options);
```

**Description:**
Opens a file picker dialog that allows the user to select multiple files at once. This method automatically enables multiple selection mode.

**Parameters:**
- `options` - `FilePickerOptions` object containing dialog configuration.

**Returns:**
- `FilePickerResult` - An object containing all selected file paths (available in `result.SelectedPaths`).

**Exceptions:**
- `ArgumentNullException` - Thrown if `options` is null.
- `ArgumentException` - Thrown if options contain invalid values.
- `InvalidOperationException` - Thrown if the platform is not supported.

**Remarks:**
- Automatically sets `AllowMultiple` to `true` regardless of the options configuration.
- Returns all selected paths in `result.SelectedPaths` collection.
- `result.SelectedPath` returns the first selected file for convenience.
- Returns `result.IsCancelled = true` if the user doesn't select any files.
- Works consistently across all three platforms.

**Example:**
```csharp
var options = new FilePickerOptions("Select Images")
    .WithDefaultPath("/home/user/Pictures")
    .WithFilter(new FilePickerFilter("JPEG Images", "jpg", "jpeg"))
    .WithFilter(new FilePickerFilter("PNG Images", "png"))
    .WithFilter(new FilePickerFilter("All Images", "jpg", "jpeg", "png", "gif", "bmp"));

FilePickerResult result = picker.PickFiles(options);

if (result.IsSuccess)
{
    Console.WriteLine($"Selected {result.SelectedPaths.Count} files:");
    for (int i = 0; i < result.SelectedPaths.Count; i++)
    {
        Console.WriteLine($"  {i + 1}. {result.SelectedPaths[i]}");
    }
}
else if (result.IsCancelled)
{
    Console.WriteLine("No files selected");
}
else
{
    Console.WriteLine($"Error: {result.ErrorMessage}");
}
```

---

### PickFolder(FilePickerOptions options)

**Signature:**
```csharp
FilePickerResult PickFolder(FilePickerOptions options);
```

**Description:**
Opens a folder/directory picker dialog allowing the user to select a single directory. The dialog type should be set to `FileDialogType.SelectFolder`.

**Parameters:**
- `options` - `FilePickerOptions` object configured for folder selection (with `DialogType = FileDialogType.SelectFolder`).

**Returns:**
- `FilePickerResult` - An object containing the selected folder path (available in `result.SelectedPath`).

**Exceptions:**
- `ArgumentNullException` - Thrown if `options` is null.
- `ArgumentException` - Thrown if options contain invalid values.
- `InvalidOperationException` - Thrown if the platform is not supported.

**Remarks:**
- Should be used with `FileDialogType.SelectFolder` in options.
- Returns the selected directory path in `result.SelectedPath`.
- The returned path can be used to enumerate files or navigate further.
- File filters are ignored for folder selection dialogs.
- Multiple folder selection is not supported (use with `AllowMultiple = false`).

**Example:**
```csharp
var options = new FilePickerOptions("Select Project Folder", FileDialogType.SelectFolder)
    .WithDefaultPath("/home/user");

FilePickerResult result = picker.PickFolder(options);

if (result.IsSuccess)
{
    string folderPath = result.SelectedPath;
    Console.WriteLine($"Selected folder: {folderPath}");
    
    // Example: List files in selected folder
    string[] files = Directory.GetFiles(folderPath);
    Console.WriteLine($"Contains {files.Length} files");
}
else if (result.IsCancelled)
{
    Console.WriteLine("Folder selection cancelled");
}
else
{
    Console.WriteLine($"Error: {result.ErrorMessage}");
}
```

---

## Implementation Classes

The interface is implemented by three platform-specific classes:

1. **WindowsFilePicker** - Uses PowerShell and System.Windows.Forms
2. **MacFilePicker** - Uses AppleScript via osascript
3. **LinuxFilePicker** - Uses zenity or kdialog

## Creating an Instance

Use `FilePickerFactory` to create the appropriate implementation:

```csharp
// Automatic platform detection
IFilePicker picker = FilePickerFactory.CreateFilePicker();

// This will return:
// - WindowsFilePicker on Windows
// - MacFilePicker on macOS
// - LinuxFilePicker on Linux
```

## Error Handling Pattern

```csharp
try
{
    var options = new FilePickerOptions("Select File");
    FilePickerResult result = picker.PickFile(options);
    
    if (result.IsSuccess)
    {
        // Use result.SelectedPath
    }
    else if (result.IsCancelled)
    {
        // Handle user cancellation
    }
    else
    {
        Logger.Error($"Dialog error: {result.ErrorMessage}");
    }
}
catch (ArgumentException ex)
{
    Logger.Error($"Invalid options: {ex.Message}");
}
catch (InvalidOperationException ex)
{
    Logger.Error($"Platform not supported: {ex.Message}");
}
```

## Complete Usage Example

```csharp
using Alis.Extension.Io.FileDialog;
using Alis.Core.Aspect.Logging;

public class FileSelectionExample
{
    public static void SelectMultipleImages()
    {
        try
        {
            // Create picker
            IFilePicker picker = FilePickerFactory.CreateFilePicker();
            
            // Configure options with fluent API
            var options = new FilePickerOptions("Select Images to Process")
                .WithDefaultPath(Environment.GetFolderPath(Environment.SpecialFolder.Pictures))
                .WithFilter(new FilePickerFilter("JPEG Images", "jpg", "jpeg"))
                .WithFilter(new FilePickerFilter("PNG Images", "png"))
                .WithFilter(new FilePickerFilter("All Images", "jpg", "jpeg", "png", "gif", "bmp", "tiff"))
                .WithFilter(new FilePickerFilter("All Files", "*"));
            
            // Execute dialog - automatically handles platform differences
            FilePickerResult result = picker.PickFiles(options);
            
            // Handle result
            if (result.IsSuccess)
            {
                Logger.Info($"Processing {result.SelectedPaths.Count} images...");
                
                foreach (var imagePath in result.SelectedPaths)
                {
                    ProcessImage(imagePath);
                }
            }
            else if (result.IsCancelled)
            {
                Logger.Info("User cancelled image selection");
            }
            else
            {
                Logger.Error($"Failed to select images: {result.ErrorMessage}");
            }
        }
        catch (Exception ex)
        {
            Logger.Error($"Unexpected error: {ex.Message}");
        }
    }
    
    private static void ProcessImage(string imagePath)
    {
        // Process image file
        Logger.Info($"Processing image: {imagePath}");
    }
}
```

## Best Practices

1. **Always use FilePickerFactory** to create instances - it handles platform detection.

2. **Validate options before passing** - Use `FilePickerValidator.ValidateOptions()` if needed.

3. **Check result status** - Always check `IsSuccess` or `IsCancelled` before using paths.

4. **Handle cancellation gracefully** - Cancellation is a normal user action, not an error.

5. **Use appropriate dialog types** - Use `SelectFolder` for directory selection.

6. **Configure meaningful filters** - Make filter names user-friendly.

7. **Provide sensible defaults** - Set `DefaultPath` to a relevant location.

8. **Log important operations** - Use logging for debugging and auditing.

## Related Classes

- `FilePickerFactory` - Creates instances
- `FilePickerOptions` - Configures dialog behavior
- `FilePickerResult` - Encapsulates operation results
- `FilePickerValidator` - Validates options and results
- `FileDialogType` - Enumeration of dialog types

---

**Last Updated:** February 22, 2026

