# FileDialogType Enumeration Documentation

## Overview

`FileDialogType` is an enumeration that specifies the type of file dialog to be displayed. It determines the dialog's behavior, appearance, and available options.

## Namespace

```csharp
using Alis.Extension.Io.FileDialog;
```

## Enumeration Definition

```csharp
public enum FileDialogType
{
    OpenFile = 0,
    SaveFile = 1,
    SelectFolder = 2
}
```

## Values

### OpenFile

**Value:** `0`

**Description:**
Dialog for selecting an existing file to open. This is the standard file selection dialog.

**Characteristics:**
- User can only select files that exist
- Single or multiple file selection available
- File type filters are fully supported
- Default action is typically "Open"
- User cannot create new files from this dialog

**Platform Appearance:**
- **Windows:** Windows File Open Dialog
- **macOS:** macOS Finder Open dialog
- **Linux:** GNOME Files dialog via zenity

**Usage Example:**
```csharp
var options = new FilePickerOptions(
    "Select a file to open",
    FileDialogType.OpenFile
);
```

**Related IFilePicker Methods:**
- `PickFile(FilePickerOptions)` - Single file selection
- `PickFiles(FilePickerOptions)` - Multiple file selection

---

### SaveFile

**Value:** `1`

**Description:**
Dialog for saving a file with a new name or location. User can specify where and with what name to save the file.

**Characteristics:**
- Allows creating new files or overwriting existing ones
- Only single file selection allowed (multiple selection disabled)
- File type filters are supported
- User specifies both directory and filename
- May show overwrite confirmation for existing files
- Default action is typically "Save"

**Platform Appearance:**
- **Windows:** Windows File Save Dialog
- **macOS:** macOS Finder Save dialog
- **Linux:** GNOME Files dialog via zenity with save mode

**Usage Example:**
```csharp
var options = new FilePickerOptions(
    "Save document as",
    FileDialogType.SaveFile
)
    .WithDefaultPath(Environment.GetFolderPath(
        Environment.SpecialFolder.MyDocuments))
    .WithFilter(new FilePickerFilter("Word Documents", "docx"))
    .WithFilter(new FilePickerFilter("PDF Files", "pdf"));
```

**Related IFilePicker Methods:**
- `PickFile(FilePickerOptions)` - Single file save location selection

**Restrictions:**
- Cannot use `AllowMultiple = true` with SaveFile dialogs
- Cannot use `AllowDirectories = true` with SaveFile dialogs

---

### SelectFolder

**Value:** `2`

**Description:**
Dialog for selecting an existing folder/directory. Typically used when users need to choose where to save files or which folder to process.

**Characteristics:**
- User can only select directories (folders)
- File type filters are ignored
- Single folder selection only (multiple not supported)
- All directory navigation is available
- Default action is typically "Select" or "OK"
- Cannot select files, only folders

**Platform Appearance:**
- **Windows:** Windows Folder Browser Dialog
- **macOS:** macOS Finder Folder selection dialog
- **Linux:** GNOME Files dialog in folder-select mode

**Usage Example:**
```csharp
var options = new FilePickerOptions(
    "Select folder to backup",
    FileDialogType.SelectFolder
)
    .WithDefaultPath(
        Environment.GetFolderPath(
            Environment.SpecialFolder.UserProfile));

FilePickerResult result = picker.PickFolder(options);

if (result.IsSuccess)
{
    string selectedFolder = result.SelectedPath;
    DirectoryInfo dirInfo = new DirectoryInfo(selectedFolder);
    Console.WriteLine($"Selected: {dirInfo.Name}");
}
```

**Related IFilePicker Methods:**
- `PickFolder(FilePickerOptions)` - Folder selection

**Special Considerations:**
- `AllowDirectories = true` is implicit for this type
- File filters are not applicable and are ignored
- Multiple selection is not available

---

## Usage in FilePickerOptions

The dialog type is specified when creating `FilePickerOptions`:

```csharp
// Open file dialog
var openOptions = new FilePickerOptions("Open", FileDialogType.OpenFile);

// Save file dialog
var saveOptions = new FilePickerOptions("Save", FileDialogType.SaveFile);

// Select folder dialog
var folderOptions = new FilePickerOptions("Select", FileDialogType.SelectFolder);
```

---

## Dialog Type Selection Guide

### Choose OpenFile when:
- ✅ Allowing user to select existing files
- ✅ Implementing an "Open File" feature
- ✅ Importing data from user-selected files
- ✅ Need single or multiple file selection
- ✅ Want to restrict by file type with filters

**Example:**
```csharp
var options = new FilePickerOptions("Import Images", FileDialogType.OpenFile)
    .WithFilter(new FilePickerFilter("Images", "jpg", "png", "gif"))
    .WithMultipleSelection();
```

### Choose SaveFile when:
- ✅ Allowing user to specify save location and name
- ✅ Implementing a "Save As" feature
- ✅ Exporting data to user-specified file
- ✅ Creating new files with user-chosen names
- ✅ Single file save operation

**Example:**
```csharp
var options = new FilePickerOptions("Export Report", FileDialogType.SaveFile)
    .WithDefaultPath(
        Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments))
    .WithFilter(new FilePickerFilter("Excel Files", "xlsx"))
    .WithFilter(new FilePickerFilter("PDF Files", "pdf"))
    .WithFilter(new FilePickerFilter("CSV Files", "csv"));
```

### Choose SelectFolder when:
- ✅ Allowing user to select a folder
- ✅ Implementing a "Select Folder" feature
- ✅ Choosing backup destination
- ✅ Selecting project folder
- ✅ Choosing batch processing directory
- ❌ NOT when you need to select files (use OpenFile instead)

**Example:**
```csharp
var options = new FilePickerOptions("Select Output Folder", FileDialogType.SelectFolder)
    .WithDefaultPath(
        Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));
```

---

## Restrictions by Dialog Type

| Feature | OpenFile | SaveFile | SelectFolder |
|---------|----------|----------|--------------|
| Select Files | ✅ | ✅ | ❌ |
| Select Folders | ❌ | ❌ | ✅ |
| Multiple Selection | ✅ | ❌ | ❌ |
| File Type Filters | ✅ | ✅ | ❌ |
| Create New Files | ❌ | ✅ | ❌ |
| Overwrite Confirmation | ❌ | ✅ | ❌ |

---

## Complete Usage Examples

### Example 1: Open Image Files

```csharp
private void OpenImages()
{
    var options = new FilePickerOptions("Open Images", FileDialogType.OpenFile)
        .WithDefaultPath(
            Environment.GetFolderPath(Environment.SpecialFolder.MyPictures))
        .WithFilter(new FilePickerFilter("Images", "jpg", "jpeg", "png", "gif"))
        .WithMultipleSelection();
    
    FilePickerResult result = picker.PickFiles(options);
    
    if (result.IsSuccess)
    {
        foreach (var imagePath in result.SelectedPaths)
        {
            LoadImage(imagePath);
        }
    }
}
```

### Example 2: Save Document

```csharp
private void SaveDocument()
{
    var options = new FilePickerOptions("Save Document", FileDialogType.SaveFile)
        .WithDefaultPath(
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments))
        .WithFilter(new FilePickerFilter("Word Documents", "docx"))
        .WithFilter(new FilePickerFilter("PDF Files", "pdf"))
        .WithFilter(new FilePickerFilter("Text Files", "txt"));
    
    FilePickerResult result = picker.PickFile(options);
    
    if (result.IsSuccess)
    {
        string savePath = result.SelectedPath;
        // Ensure correct extension
        if (!Path.HasExtension(savePath))
        {
            savePath += ".docx";
        }
        SaveToFile(savePath);
    }
}
```

### Example 3: Select Project Folder

```csharp
private void SelectProject()
{
    var options = new FilePickerOptions("Select Project Folder", FileDialogType.SelectFolder)
        .WithDefaultPath(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));
    
    FilePickerResult result = picker.PickFolder(options);
    
    if (result.IsSuccess)
    {
        string projectPath = result.SelectedPath;
        LoadProject(projectPath);
    }
}
```

### Example 4: Application Dialog Dispatcher

```csharp
public class DialogDispatcher
{
    private readonly IFilePicker _picker;
    
    public DialogDispatcher()
    {
        _picker = FilePickerFactory.CreateFilePicker();
    }
    
    public FilePickerResult OpenFile(string title, string defaultPath = null)
    {
        var options = new FilePickerOptions(title, FileDialogType.OpenFile);
        if (defaultPath != null)
            options.WithDefaultPath(defaultPath);
        return _picker.PickFile(options);
    }
    
    public FilePickerResult SaveFile(string title, string defaultPath = null)
    {
        var options = new FilePickerOptions(title, FileDialogType.SaveFile);
        if (defaultPath != null)
            options.WithDefaultPath(defaultPath);
        return _picker.PickFile(options);
    }
    
    public FilePickerResult SelectFolder(string title, string defaultPath = null)
    {
        var options = new FilePickerOptions(title, FileDialogType.SelectFolder);
        if (defaultPath != null)
            options.WithDefaultPath(defaultPath);
        return _picker.PickFolder(options);
    }
}
```

### Example 5: Type-Safe Dialog Configuration

```csharp
public abstract class DialogConfigBase
{
    protected readonly FilePickerOptions Options;
    
    protected DialogConfigBase(string title, FileDialogType type)
    {
        Options = new FilePickerOptions(title, type);
    }
    
    public FilePickerOptions Build() => Options;
}

public class OpenFileDialog : DialogConfigBase
{
    public OpenFileDialog(string title) : base(title, FileDialogType.OpenFile) { }
    
    public OpenFileDialog WithFilter(FilePickerFilter filter)
    {
        Options.WithFilter(filter);
        return this;
    }
    
    public OpenFileDialog EnableMultiple()
    {
        Options.WithMultipleSelection();
        return this;
    }
}

public class SaveFileDialog : DialogConfigBase
{
    public SaveFileDialog(string title) : base(title, FileDialogType.SaveFile) { }
    
    public SaveFileDialog WithFilter(FilePickerFilter filter)
    {
        Options.WithFilter(filter);
        return this;
    }
}

public class SelectFolderDialog : DialogConfigBase
{
    public SelectFolderDialog(string title) : base(title, FileDialogType.SelectFolder) { }
}

// Usage:
var openOptions = new OpenFileDialog("Open Document")
    .WithFilter(new FilePickerFilter("All Documents", "doc", "docx", "pdf"))
    .Build();

var saveOptions = new SaveFileDialog("Save Document")
    .WithFilter(new FilePickerFilter("Word Documents", "docx"))
    .Build();

var folderOptions = new SelectFolderDialog("Select Project").Build();
```

---

## Platform Implementation Details

### Windows
- Uses different `System.Windows.Forms.FileDialog` implementations:
  - `OpenFileDialog` for `FileDialogType.OpenFile`
  - `SaveFileDialog` for `FileDialogType.SaveFile`
  - `FolderBrowserDialog` for `FileDialogType.SelectFolder`
- Full native Windows appearance
- Supports all features natively

### macOS
- Uses AppleScript via osascript:
  - `choose file` for `FileDialogType.OpenFile`
  - `choose file name` for `FileDialogType.SaveFile`
  - `choose folder` for `FileDialogType.SelectFolder`
- Native Finder-based dialogs
- Familiar macOS look and feel

### Linux
- Uses zenity or kdialog:
  - `--file-selection` for `FileDialogType.OpenFile`
  - `--file-selection --save` for `FileDialogType.SaveFile`
  - `--file-selection --directory` for `FileDialogType.SelectFolder`
- GNOME/KDE native dialogs
- Automatic fallback if zenity unavailable

---

## Best Practices

1. **Match dialog type to operation:**
   ```csharp
   // Good - dialog type matches operation
   var openOptions = new FilePickerOptions("Open", FileDialogType.OpenFile);
   
   // Avoid - confusing mismatch
   var openOptions = new FilePickerOptions("Save File", FileDialogType.OpenFile);
   ```

2. **Provide default paths matching dialog type:**
   ```csharp
   // For opening files, default to Documents
   var openOptions = new FilePickerOptions("Open", FileDialogType.OpenFile)
       .WithDefaultPath(
           Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
   
   // For saving, default to same location
   var saveOptions = new FilePickerOptions("Save", FileDialogType.SaveFile)
       .WithDefaultPath(
           Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
   ```

3. **Use filters only for file dialogs:**
   ```csharp
   // Good - filters only with file dialogs
   var openOptions = new FilePickerOptions("Open", FileDialogType.OpenFile)
       .WithFilter(new FilePickerFilter("Documents", "doc", "docx"));
   
   // Avoid - filters with folder dialog (they're ignored anyway)
   var folderOptions = new FilePickerOptions("Folder", FileDialogType.SelectFolder)
       .WithFilter(new FilePickerFilter("Documents", "doc"));
   ```

4. **Check allowed options based on type:**
   ```csharp
   // Good - appropriate for SaveFile
   var saveOptions = new FilePickerOptions("Save", FileDialogType.SaveFile);
   // AllowMultiple would be false anyway
   
   // Avoid - SaveFile with multiple selection doesn't make sense
   var saveOptions = new FilePickerOptions("Save", FileDialogType.SaveFile)
       .WithMultipleSelection(); // This will fail validation
   ```

---

## Related Classes

- `FilePickerOptions` - Uses this enumeration
- `IFilePicker` - Methods related to dialog types
- `FilePickerValidator` - Validates type constraints

---

**Last Updated:** February 22, 2026

