# LinuxFilePicker Class Documentation

## Overview

`LinuxFilePicker` is the Linux-specific implementation of the `IFilePicker` interface. It uses `zenity` (GNOME) with automatic fallback to `kdialog` (KDE) for file dialogs.

## Namespace

```csharp
using Alis.Extension.Io.FileDialog;
```

## Class Definition

```csharp
public class LinuxFilePicker : IFilePicker
{
    public string ChooseFile();
    public FilePickerResult PickFile(FilePickerOptions options);
    public FilePickerResult PickFiles(FilePickerOptions options);
    public FilePickerResult PickFolder(FilePickerOptions options);
}
```

## Implementation Details

### Dialog Tools

#### Primary: zenity (GNOME)
- **Availability:** Default on GNOME desktop environments
- **Installation:** `sudo apt-get install zenity` (Ubuntu/Debian)
- **Advantages:** Modern interface, consistent with GNOME

#### Fallback: kdialog (KDE)
- **Availability:** Default on KDE desktop environments
- **Installation:** `sudo apt-get install kdialog`
- **Advantages:** KDE integration, lightweight

**Automatic Selection:**
```
1. Check if zenity is available
2. If not, check if kdialog is available
3. If neither, return error
```

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
- `string` - Full path to selected file, or `null` if cancelled

**Remarks:**
- Uses default dialog title
- No configuration options
- Internally uses `PickFile()` with default options

**Example:**
```csharp
IFilePicker picker = new LinuxFilePicker();
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
- ✅ File type filters
- ✅ Native desktop environment integration
- ✅ Automatic tool selection

**Zenity Command:**
```bash
zenity --file-selection --title="Open File" \
  --filename="/path" \
  --file-filter="Text Files | *.txt" \
  --file-filter="All Files | *"
```

**Kdialog Command:**
```bash
kdialog --getopenfilename /path "Text Files (*.txt)|*.txt|All Files (*)|*" --title "Open File"
```

**Example:**
```csharp
var options = new FilePickerOptions("Open Document")
    .WithDefaultPath(
        Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments))
    .WithFilter(new FilePickerFilter("Text Files", "txt"))
    .WithFilter(new FilePickerFilter("PDFs", "pdf"));

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
- ✅ Multiple file selection (Ctrl+Click)
- ✅ File type filters
- ✅ Default path navigation
- ✅ Path separator handling (pipes for output)

**Zenity Multiple Selection:**
```bash
zenity --file-selection --multiple --separator="|" \
  --title="Select Files" \
  --filename="/path" \
  --file-filter="Images | *.jpg;*.png"
```

**Kdialog Multiple Selection:**
```bash
kdialog --getopenfilenames /path "Images (*.jpg *.png)|*.jpg *.png"
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
- ✅ Custom dialog title
- ✅ Default path navigation
- ✅ Desktop environment integration

**Zenity Folder Selection:**
```bash
zenity --file-selection --directory --title="Select Folder" \
  --filename="/path"
```

**Kdialog Folder Selection:**
```bash
kdialog --getexistingdirectory /path --title "Select Folder"
```

**Example:**
```csharp
var options = new FilePickerOptions("Select Project", FileDialogType.SelectFolder)
    .WithDefaultPath(
        Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));

FilePickerResult result = picker.PickFolder(options);

if (result.IsSuccess)
{
    Console.WriteLine($"Folder: {result.SelectedPath}");
}
```

---

## File Type Filters

### zenity Filter Format
```bash
--file-filter="Text Files | *.txt;*.log"
--file-filter="All Files | *"
```

### kdialog Filter Format
```bash
"Text Files (*.txt *.log)|*.txt *.log|All Files (*)|*"
```

**Filter Conversion:**
The implementation automatically converts between formats based on the available tool.

---

## Complete Usage Examples

### Example 1: Basic File Selection

```csharp
var picker = new LinuxFilePicker();
var options = new FilePickerOptions("Select a File");
FilePickerResult result = picker.PickFile(options);

if (result.IsSuccess)
{
    Console.WriteLine($"You selected: {result.SelectedPath}");
}
```

### Example 2: Select Source Code

```csharp
var options = new FilePickerOptions("Open C# File")
    .WithDefaultPath(
        Environment.GetFolderPath(Environment.SpecialFolder.UserProfile))
    .WithFilter(new FilePickerFilter("C# Source", "cs"))
    .WithFilter(new FilePickerFilter("All Source", "cs", "cpp", "h", "hpp", "java"))
    .WithFilter(new FilePickerFilter("All Files", "*"));

FilePickerResult result = picker.PickFile(options);
```

### Example 3: Import Multiple Documents

```csharp
var options = new FilePickerOptions("Import Documents")
    .WithDefaultPath(
        Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments))
    .WithFilter(new FilePickerFilter("Documents", "doc", "docx", "odt", "pdf", "txt"))
    .WithFilter(new FilePickerFilter("PDF Only", "pdf"))
    .WithMultipleSelection();

FilePickerResult result = picker.PickFiles(options);

if (result.IsSuccess)
{
    Console.WriteLine($"Selected {result.SelectedPaths.Count} files");
    foreach (var doc in result.SelectedPaths)
    {
        ProcessDocument(doc);
    }
}
```

### Example 4: Select Build Directory

```csharp
var options = new FilePickerOptions("Select Build Folder", FileDialogType.SelectFolder)
    .WithDefaultPath(
        Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));

FilePickerResult result = picker.PickFolder(options);

if (result.IsSuccess)
{
    var buildFiles = Directory.GetFiles(
        result.SelectedPath,
        "Makefile");
    Console.WriteLine($"Found {buildFiles.Length} Makefiles");
}
```

### Example 5: Batch Media Import

```csharp
var options = new FilePickerOptions("Import Media")
    .WithDefaultPath(Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
        "Downloads"))
    .WithFilter(new FilePickerFilter(
        "All Media",
        "jpg", "jpeg", "png", "gif",   // Images
        "mp3", "wav", "flac", "aac",   // Audio
        "mp4", "mkv", "avi", "mov"))   // Video
    .WithFilter(new FilePickerFilter("Images", "jpg", "jpeg", "png", "gif"))
    .WithFilter(new FilePickerFilter("Audio", "mp3", "wav", "flac", "aac"))
    .WithFilter(new FilePickerFilter("Video", "mp4", "mkv", "avi", "mov"))
    .WithMultipleSelection();

FilePickerResult result = picker.PickFiles(options);

if (result.IsSuccess)
{
    int images = 0, audio = 0, video = 0;
    
    foreach (var file in result.SelectedPaths)
    {
        string ext = Path.GetExtension(file).ToLower();
        if (ext == ".jpg" || ext == ".jpeg" || ext == ".png" || ext == ".gif")
            images++;
        else if (ext == ".mp3" || ext == ".wav" || ext == ".flac" || ext == ".aac")
            audio++;
        else
            video++;
    }
    
    Console.WriteLine($"Images: {images}, Audio: {audio}, Video: {video}");
}
```

---

## Desktop Environment Detection

The implementation automatically detects and uses the appropriate tool:

```csharp
// Checks in order:
1. $XDG_CURRENT_DESKTOP environment variable
2. Available commands (zenity, kdialog)
3. GNOME vs KDE session detection
```

**Environment Variables:**
```bash
echo $XDG_CURRENT_DESKTOP
# Output: GNOME, KDE, XFCE, Unity, etc.
```

---

## Installation Requirements

### Ubuntu/Debian
```bash
# For GNOME desktop
sudo apt-get install zenity

# For KDE desktop
sudo apt-get install kdialog

# Or install both for compatibility
sudo apt-get install zenity kdialog
```

### Fedora/RHEL
```bash
sudo dnf install zenity kdialog
```

### Arch
```bash
sudo pacman -S zenity kdialog
```

---

## Native Linux Experience

The `LinuxFilePicker` provides authentic Linux desktop experience:

- ✅ **GNOME Integration** - Native GNOME Files dialog
- ✅ **KDE Integration** - Native KDE dialog  
- ✅ **File Browsing** - Standard Linux file browser
- ✅ **Bookmarks** - Quick access to bookmarks
- ✅ **Recent Files** - Recent files sidebar
- ✅ **Keyboard Shortcuts** - Standard Linux shortcuts work
- ✅ **Type Ahead** - Quick file filtering
- ✅ **Hidden Files** - Ctrl+H to toggle

---

## Performance Characteristics

- **Startup Time:** ~150-300ms (tool initialization)
- **Memory Usage:** ~20MB (minimal)
- **UI Responsiveness:** Non-blocking
- **Cancellation:** Immediate dialog closure

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

## Path Handling

### Multiple Path Separation
For `PickFiles()`, multiple paths are separated by pipe (`|`):
```
/path/one.txt|/path/two.txt|/path/three.txt
```

The implementation automatically splits and normalizes these paths.

---

## Linux Distribution Compatibility

- ✅ Ubuntu 18.04+
- ✅ Debian 10+
- ✅ Fedora 30+
- ✅ openSUSE 15+
- ✅ Arch Linux
- ✅ Linux Mint
- ✅ Elementary OS
- ✅ CentOS 8+

---

## Best Practices

1. **Check tool availability:**
   ```csharp
   // Automatically handled, but you can check:
   if (FilePickerExecutor.CommandExists("zenity"))
   {
       Console.WriteLine("zenity is available");
   }
   ```

2. **Use standard XDG directories:**
   ```csharp
   // Common Linux paths
   string documents = Path.Combine(
       Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
       "Documents");
   ```

3. **Provide meaningful filters:**
   ```csharp
   .WithFilter(new FilePickerFilter("Source Code", "c", "h"))
   .WithFilter(new FilePickerFilter("Build Output", "o", "a"))
   ```

4. **Handle missing tools gracefully:**
   ```csharp
   if (!result.IsSuccess && !result.IsCancelled)
   {
       // Tool not available or execution error
       Logger.Error(result.ErrorMessage);
   }
   ```

5. **Always validate paths:**
   ```csharp
   if (result.IsSuccess &&
       FilePickerValidator.IsResultValid(result, options))
   {
       // Use path
   }
   ```

---

## Related Classes

- `IFilePicker` - Interface that this class implements
- `FilePickerFactory` - Creates instances of this class
- `FilePickerExecutor` - Executes zenity/kdialog commands
- `FilePickerOptions` - Configures the dialog
- `FilePickerResult` - Encapsulates the result

---

**Last Updated:** February 22, 2026

