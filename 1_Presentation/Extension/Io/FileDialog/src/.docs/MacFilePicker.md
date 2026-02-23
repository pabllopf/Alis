# MacFilePicker Class Documentation

## Overview

`MacFilePicker` is the macOS-specific implementation of the `IFilePicker` interface. It uses AppleScript via `osascript` to provide native macOS Finder dialogs.

## Namespace

```csharp
using Alis.Extension.Io.FileDialog;
```

## Class Definition

```csharp
public class MacFilePicker : IFilePicker
{
    public string ChooseFile();
    public FilePickerResult PickFile(FilePickerOptions options);
    public FilePickerResult PickFiles(FilePickerOptions options);
    public FilePickerResult PickFolder(FilePickerOptions options);
}
```

## Implementation Details

### Dialog Tools
- **Primary Tool:** `osascript` (built-in on macOS)
- **Language:** AppleScript
- **Availability:** Built-in on all macOS systems (10.5+)
- **No external dependencies required**

### AppleScript Commands
- `choose file` - Single/multiple file selection
- `choose folder` - Folder selection
- `POSIX path` - Convert Mac paths to Unix format

---

## Methods

### ChooseFile()

**Signature:**
```csharp
public string ChooseFile()
```

**Description:**
Opens a file picker dialog for selecting a single file (legacy method).

**Returns:**
- `string` - Full POSIX path to selected file, or `null` if cancelled

**Remarks:**
- Uses default dialog title
- No configuration options available
- Internally uses `PickFile()` with default options

**Example:**
```csharp
IFilePicker picker = new MacFilePicker();
string file = picker.ChooseFile();

if (file != null)
{
    Console.WriteLine($"Selected: {file}");
}
```

---

### PickFile(FilePickerOptions options)

**Signature:**
```csharp
public FilePickerResult PickFile(FilePickerOptions options)
```

**Description:**
Opens a file selection dialog for a single file with custom options.

**Parameters:**
- `options` - Configuration object for the dialog

**Returns:**
- `FilePickerResult` - Result containing selected file path or error information

**Features:**
- ✅ Custom dialog title
- ✅ Default path navigation
- ✅ File type filtering (via UTI)
- ✅ Native Finder appearance
- ✅ Complete error handling and logging

**AppleScript Implementation:**
Uses `choose file` command:
```applescript
on run
  set selectedFile to choose file with prompt "Select a file:"
  POSIX path of selectedFile
end run
```

**Example:**
```csharp
var options = new FilePickerOptions("Open Document")
    .WithDefaultPath(Environment.GetFolderPath(
        Environment.SpecialFolder.MyDocuments))
    .WithFilter(new FilePickerFilter("Word Files", "doc", "docx"))
    .WithFilter(new FilePickerFilter("PDF", "pdf"));

FilePickerResult result = picker.PickFile(options);

if (result.IsSuccess)
{
    Console.WriteLine($"File: {result.SelectedPath}");
}
```

---

### PickFiles(FilePickerOptions options)

**Signature:**
```csharp
public FilePickerResult PickFiles(FilePickerOptions options)
```

**Description:**
Opens a file selection dialog allowing multiple file selection.

**Parameters:**
- `options` - Configuration object (AllowMultiple is set to true)

**Returns:**
- `FilePickerResult` - Result containing all selected file paths

**Features:**
- ✅ Multiple file selection (Cmd+Click)
- ✅ Default path navigation
- ✅ File type filtering
- ✅ Native Finder appearance with multiple selection support

**AppleScript Implementation:**
Uses `choose file` with `multiple selections allowed`:
```applescript
set selectedItems to choose file with prompt "Select files:" multiple selections allowed true
repeat with selectedItem in selectedItems
  log POSIX path of selectedItem
end repeat
```

**Example:**
```csharp
var options = new FilePickerOptions("Import Images")
    .WithFilter(new FilePickerFilter("Images", "jpg", "png", "gif"))
    .WithMultipleSelection();

FilePickerResult result = picker.PickFiles(options);

if (result.IsSuccess)
{
    foreach (var file in result.SelectedPaths)
    {
        Console.WriteLine($"Selected: {file}");
    }
}
```

---

### PickFolder(FilePickerOptions options)

**Signature:**
```csharp
public FilePickerResult PickFolder(FilePickerOptions options)
```

**Description:**
Opens a folder selection dialog.

**Parameters:**
- `options` - Configuration object with DialogType.SelectFolder

**Returns:**
- `FilePickerResult` - Result containing selected folder path

**Features:**
- ✅ Folder/Directory selection only
- ✅ Native Finder folder browser appearance
- ✅ Custom dialog title
- ✅ Default path navigation

**AppleScript Implementation:**
Uses `choose folder` command:
```applescript
set selectedFolder to choose folder with prompt "Select a folder:"
POSIX path of selectedFolder
```

**Example:**
```csharp
var options = new FilePickerOptions("Select Project", FileDialogType.SelectFolder)
    .WithDefaultPath(Environment.GetFolderPath(
        Environment.SpecialFolder.UserProfile));

FilePickerResult result = picker.PickFolder(options);

if (result.IsSuccess)
{
    Console.WriteLine($"Folder: {result.SelectedPath}");
}
```

---

## Path Handling

### POSIX Paths
All paths returned are in POSIX format (Unix-style):
- Format: `/Users/username/path/to/file.txt`
- Spaces in paths: Properly escaped and handled
- Symbolic links: Resolved to actual paths

### Path Conversion
Paths from AppleScript are automatically converted:
```
AppleScript: alias "Macintosh HD:Users:John:Documents:file.txt"
↓
POSIX Path: /Users/John/Documents/file.txt
↓
Returned: "/Users/John/Documents/file.txt"
```

---

## File Type Filtering

macOS uses UTI (Uniform Type Identifier) for file filtering:

**Filter Example:**
```csharp
var filter = new FilePickerFilter("Images", "jpg", "jpeg", "png", "gif");
// UTI Format: "jpg,jpeg,png,gif"
```

**Common UTI Types:**
```
public.image           // Any image format
public.audio           // Any audio format
public.video           // Any video format
public.plain-text      // Text files
com.apple.application  // macOS applications
```

---

## Complete Usage Examples

### Example 1: Basic File Selection

```csharp
var picker = new MacFilePicker();
var options = new FilePickerOptions("Select a File");
FilePickerResult result = picker.PickFile(options);

if (result.IsSuccess)
{
    Console.WriteLine($"You selected: {result.SelectedPath}");
}
```

### Example 2: Filter by File Type

```csharp
var options = new FilePickerOptions("Open Xcode Project")
    .WithDefaultPath(Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
        "Projects"))
    .WithFilter(new FilePickerFilter("Xcode Projects", "xcodeproj"))
    .WithFilter(new FilePickerFilter("All Files", "*"));

FilePickerResult result = picker.PickFile(options);
```

### Example 3: Select Multiple Photos

```csharp
var options = new FilePickerOptions("Import Photos")
    .WithDefaultPath(Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
        "Pictures"))
    .WithFilter(new FilePickerFilter("Images", "jpg", "jpeg", "png", "gif", "webp"))
    .WithMultipleSelection();

FilePickerResult result = picker.PickFiles(options);

if (result.IsSuccess)
{
    Console.WriteLine($"Selected {result.SelectedPaths.Count} photos");
}
```

### Example 4: Select Downloads Folder

```csharp
var options = new FilePickerOptions("Select Folder", FileDialogType.SelectFolder)
    .WithDefaultPath(Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
        "Downloads"));

FilePickerResult result = picker.PickFolder(options);

if (result.IsSuccess)
{
    var files = Directory.GetFiles(result.SelectedPath);
    Console.WriteLine($"Contains {files.Length} files");
}
```

### Example 5: Batch Processing Documents

```csharp
var options = new FilePickerOptions("Select Documents to Process")
    .WithDefaultPath(Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
        "Documents"))
    .WithFilter(new FilePickerFilter("Word Documents", "doc", "docx"))
    .WithFilter(new FilePickerFilter("PDF Files", "pdf"))
    .WithFilter(new FilePickerFilter("All Documents", "doc", "docx", "pdf", "txt"))
    .WithMultipleSelection();

FilePickerResult result = picker.PickFiles(options);

if (result.IsSuccess)
{
    foreach (var doc in result.SelectedPaths)
    {
        ProcessDocument(doc);
    }
}
```

---

## Native macOS Experience

The `MacFilePicker` provides authentic macOS experience:

- ✅ **Finder Integration** - Uses native Finder dialogs
- ✅ **Favorites** - Quick access to favorite folders
- ✅ **Spotlight Search** - Search functionality available
- ✅ **Quick Look** - File preview support
- ✅ **Keyboard Navigation** - Cmd, Option, Control keys work
- ✅ **Drag & Drop** - Drag files to and from other apps
- ✅ **Sidebar** - Favorites and recent folders
- ✅ **Column View** - Apple's default column browser

---

## Performance Characteristics

- **Startup Time:** ~200-500ms (AppleScript interpreter)
- **Memory Usage:** ~30MB (minimal)
- **UI Responsiveness:** Non-blocking, responsive
- **Cancellation:** Immediate dialog closure

---

## osascript Execution

Internally uses `osascript` command:
```bash
osascript /path/to/script.applescript
```

**AppleScript File Handling:**
- Scripts are written to secure temporary files
- Random filename generation using `Path.GetRandomFileName()`
- Cryptographically safe temporary file creation (csharpsquid:S5445 compliant)
- Executed via `osascript` with isolated execution context
- Temporary files are securely cleaned up after execution
- Output is parsed and normalized
- Error handling ensures cleanup even if execution fails

**Security Measures:**
- ✅ **Secure Temp File Generation:** Uses `Path.GetRandomFileName()` instead of `Path.GetTempFileName()`
- ✅ **Unique File Names:** Cryptographically random names prevent collision attacks
- ✅ **Proper Cleanup:** Files are always deleted in `finally` block
- ✅ **Isolated Execution:** AppleScript runs in isolated `osascript` process
- ✅ **Input Validation:** All user input is properly escaped in AppleScript strings

---

## Error Handling

```csharp
try
{
    var options = new FilePickerOptions("Open File");
    FilePickerResult result = picker.PickFile(options);
    
    if (result.IsSuccess)
    {
        // Use result
    }
    else if (result.IsCancelled)
    {
        // User cancelled
    }
    else
    {
        Logger.Error($"Error: {result.ErrorMessage}");
    }
}
catch (Exception ex)
{
    Logger.Error($"Unexpected error: {ex.Message}");
}
```

---

## macOS Compatibility

- **Supported Versions:** macOS 10.5 (Leopard) and later
- **Tested On:** macOS 10.15+, 11, 12, 13, 14, 15
- **Monterey+:** Full Notarization support
- **Big Sur+:** Universal Binary (Intel/Apple Silicon) support

---

## Best Practices

1. **Use standard macOS folder locations:**
   ```csharp
   .WithDefaultPath(Path.Combine(
       Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
       "Documents"))
   ```

2. **Respect user's Finder preferences:**
   - Default views are preserved
   - Sidebar configuration is respected
   - Favorites are available

3. **Handle spaces in filenames:**
   ```csharp
   // Automatically handled
   string path = result.SelectedPath; // e.g., "/Users/John Doe/My File.txt"
   ```

4. **Use descriptive filter names:**
   ```csharp
   new FilePickerFilter("Microsoft Office", "doc", "docx", "xls", "xlsx")
   ```

5. **Always check result status:**
   ```csharp
   if (result.IsSuccess)
   {
       // Safe to use path
   }
   ```

---

## Related Classes

- `IFilePicker` - Interface that this class implements
- `FilePickerFactory` - Creates instances of this class
- `FilePickerOptions` - Configures the dialog
- `FilePickerResult` - Encapsulates the result

---

**Last Updated:** February 22, 2026

