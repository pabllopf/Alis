# FilePickerOptions Class Documentation

## Overview

`FilePickerOptions` is a configuration class that encapsulates all the options and settings for file picker dialogs. It implements the Fluent API pattern, allowing method chaining for intuitive configuration.

## Namespace

```csharp
using Alis.Extension.Io.FileDialog;
```

## Class Definition

```csharp
public class FilePickerOptions
{
    public string Title { get; set; }
    public string DefaultPath { get; set; }
    public List<FilePickerFilter> Filters { get; set; }
    public bool AllowMultiple { get; set; }
    public bool AllowDirectories { get; set; }
    public FileDialogType DialogType { get; set; }
    
    public FilePickerOptions();
    public FilePickerOptions(string title, FileDialogType dialogType = FileDialogType.OpenFile);
    
    public FilePickerOptions WithFilter(FilePickerFilter filter);
    public FilePickerOptions WithDefaultPath(string path);
    public FilePickerOptions WithMultipleSelection();
    public bool IsDirectoryDialog();
}
```

## Properties

### Title

**Type:** `string`

**Description:**
The title displayed in the file picker dialog window.

**Default Value:** `"Select a file"`

**Remarks:**
- Cannot be null or empty after validation
- Should be user-friendly and descriptive
- Used by platform-specific dialog implementations
- Maximum length depends on the platform

**Example:**
```csharp
var options = new FilePickerOptions();
options.Title = "Choose an Image File";
```

---

### DefaultPath

**Type:** `string`

**Description:**
The default directory path where the dialog will start browsing. If not set, the system default is used.

**Default Value:** `null`

**Remarks:**
- If set, the path must exist
- Can be null (uses system default)
- Supports both absolute and relative paths (relative paths are converted to absolute)
- Platform-specific behavior:
  - Windows: Sets `InitialDirectory` in OpenFileDialog
  - macOS: Sets `default location` in AppleScript
  - Linux: Used with zenity `--filename` option

**Example:**
```csharp
var options = new FilePickerOptions("Open Document")
    .WithDefaultPath("/home/user/Documents");
```

---

### Filters

**Type:** `List<FilePickerFilter>`

**Description:**
A collection of file type filters that appear in the dialog's filter dropdown.

**Default Value:** Empty `List<FilePickerFilter>`

**Remarks:**
- Can contain zero or more filters
- Each filter specifies a display name and file extensions
- Order matters - first filter is usually selected by default
- Filters are optional - empty list means all files are allowed
- Add filters using `WithFilter()` method

**Example:**
```csharp
var options = new FilePickerOptions("Open");
options.Filters.Add(new FilePickerFilter("Text Files", "txt"));
options.Filters.Add(new FilePickerFilter("Documents", "doc", "docx"));
```

---

### AllowMultiple

**Type:** `bool`

**Description:**
Indicates whether the user can select multiple files in a single dialog operation.

**Default Value:** `false`

**Remarks:**
- When `true`, users can select multiple files
- When `false`, only one file can be selected
- Automatically set to `true` when using `PickFiles()` method
- Cannot be `true` for `SaveFile` dialog type

**Example:**
```csharp
var options = new FilePickerOptions("Select Images")
    .WithMultipleSelection();

// options.AllowMultiple is now true
```

---

### AllowDirectories

**Type:** `bool`

**Description:**
Indicates whether the dialog should allow selecting directories/folders.

**Default Value:** `false`

**Remarks:**
- Only meaningful for `SelectFolder` dialog type
- Cannot be `true` for `OpenFile` or `SaveFile` dialog types
- Automatically handled by `PickFolder()` method

**Example:**
```csharp
var options = new FilePickerOptions("Select Folder", FileDialogType.SelectFolder)
    .WithDefaultPath("/home");
// AllowDirectories is true for SelectFolder dialogs
```

---

### DialogType

**Type:** `FileDialogType`

**Description:**
Specifies the type of dialog to display.

**Default Value:** `FileDialogType.OpenFile`

**Valid Values:**
- `FileDialogType.OpenFile` - Select existing file
- `FileDialogType.SaveFile` - Save file with validation
- `FileDialogType.SelectFolder` - Select directory

**Remarks:**
- Determines the dialog's behavior and appearance
- Different platforms may have different appearances for the same type
- Some options are restricted based on dialog type

**Example:**
```csharp
// Open existing file
var openOptions = new FilePickerOptions("Open File", FileDialogType.OpenFile);

// Save new file
var saveOptions = new FilePickerOptions("Save File", FileDialogType.SaveFile);

// Select folder
var folderOptions = new FilePickerOptions("Select Folder", FileDialogType.SelectFolder);
```

---

## Constructors

### FilePickerOptions()

**Signature:**
```csharp
public FilePickerOptions()
```

**Description:**
Creates a new instance with default values.

**Remarks:**
- All properties are initialized to their default values
- `Title` defaults to `"Select a file"`
- `DialogType` defaults to `FileDialogType.OpenFile`
- `Filters` is initialized as an empty list

**Example:**
```csharp
var options = new FilePickerOptions();
options.Title = "My Custom Dialog";
options.WithDefaultPath("/home/user");
```

---

### FilePickerOptions(string title, FileDialogType dialogType = FileDialogType.OpenFile)

**Signature:**
```csharp
public FilePickerOptions(string title, FileDialogType dialogType = FileDialogType.OpenFile)
```

**Description:**
Creates a new instance with specified title and dialog type.

**Parameters:**
- `title` - The dialog window title (required, cannot be null or empty)
- `dialogType` - The type of dialog (optional, defaults to `FileDialogType.OpenFile`)

**Exceptions:**
- `ArgumentNullException` - Thrown if `title` is null or empty

**Remarks:**
- Preferred constructor for most use cases
- Enables fluent API chaining immediately
- Title validation occurs at construction time

**Example:**
```csharp
var options = new FilePickerOptions("Open Image File", FileDialogType.OpenFile)
    .WithDefaultPath("/home/user/Pictures")
    .WithFilter(new FilePickerFilter("PNG Images", "png"))
    .WithFilter(new FilePickerFilter("JPEG Images", "jpg", "jpeg"));
```

---

## Methods

### WithFilter(FilePickerFilter filter)

**Signature:**
```csharp
public FilePickerOptions WithFilter(FilePickerFilter filter)
```

**Description:**
Adds a file type filter to the dialog options. Supports fluent API chaining.

**Parameters:**
- `filter` - A `FilePickerFilter` object defining a file type (required, cannot be null)

**Returns:**
- `FilePickerOptions` - Returns `this` for method chaining

**Exceptions:**
- `ArgumentNullException` - Thrown if `filter` is null

**Remarks:**
- Multiple filters can be chained
- Filters appear in the dialog in the order they are added
- The first filter is typically selected by default
- Empty filter list means no type restrictions

**Example:**
```csharp
var options = new FilePickerOptions("Open")
    .WithFilter(new FilePickerFilter("All Documents", "doc", "docx", "pdf", "txt"))
    .WithFilter(new FilePickerFilter("Word Documents", "doc", "docx"))
    .WithFilter(new FilePickerFilter("PDF Files", "pdf"))
    .WithFilter(new FilePickerFilter("All Files", "*"));
```

---

### WithDefaultPath(string path)

**Signature:**
```csharp
public FilePickerOptions WithDefaultPath(string path)
```

**Description:**
Sets the default directory path for the dialog. Supports fluent API chaining.

**Parameters:**
- `path` - The directory path to use as default (optional, can be null)

**Returns:**
- `FilePickerOptions` - Returns `this` for method chaining

**Remarks:**
- If `null`, the system default directory is used
- Path should exist (validation happens later)
- Platform-specific handling:
  - Windows: Sets `InitialDirectory`
  - macOS: Sets AppleScript default location
  - Linux: Used with zenity `--filename`
- Common defaults:
  - Documents: `Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments))`
  - Pictures: `Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures))`
  - Home: `Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)`

**Example:**
```csharp
var options = new FilePickerOptions("Select Image")
    .WithDefaultPath(
        Environment.GetFolderPath(Environment.SpecialFolder.MyPictures))
    .WithFilter(new FilePickerFilter("Images", "jpg", "png", "gif"));
```

---

### WithMultipleSelection()

**Signature:**
```csharp
public FilePickerOptions WithMultipleSelection()
```

**Description:**
Enables multiple file selection. Supports fluent API chaining.

**Returns:**
- `FilePickerOptions` - Returns `this` for method chaining

**Remarks:**
- Sets `AllowMultiple` to `true`
- Only for `OpenFile` dialog type
- Cannot be used with `SaveFile` dialogs
- Automatically enabled when using `PickFiles()` method
- When enabled, returns multiple paths in `result.SelectedPaths`

**Example:**
```csharp
var options = new FilePickerOptions("Select Multiple Files")
    .WithDefaultPath("/home/user/Downloads")
    .WithMultipleSelection()
    .WithFilter(new FilePickerFilter("All Files", "*"));

// User can now select multiple files at once
```

---

### IsDirectoryDialog()

**Signature:**
```csharp
public bool IsDirectoryDialog()
```

**Description:**
Determines whether this dialog is configured for directory selection.

**Returns:**
- `bool` - `true` if `DialogType == FileDialogType.SelectFolder`, `false` otherwise

**Remarks:**
- Helper method for checking dialog type
- Returns `true` only for folder selection dialogs
- File type filters are ignored for directory dialogs
- Multiple selection is typically not allowed for directory dialogs

**Example:**
```csharp
var options = new FilePickerOptions("Select", FileDialogType.SelectFolder);

if (options.IsDirectoryDialog())
{
    Console.WriteLine("This is a directory selection dialog");
    Console.WriteLine("Filters will be ignored");
}
```

---

## Fluent API Usage

The class supports method chaining for intuitive configuration:

```csharp
var options = new FilePickerOptions("Complex Configuration")
    .WithDefaultPath("/home/user/Projects")
    .WithFilter(new FilePickerFilter("C# Projects", "csproj", "sln"))
    .WithFilter(new FilePickerFilter("Visual Studio", "sln"))
    .WithFilter(new FilePickerFilter("All Files", "*"))
    .WithMultipleSelection();

// All configuration is fluently set in one statement
```

## Complete Usage Examples

### Example 1: Simple File Opening

```csharp
var options = new FilePickerOptions("Open File");
var result = picker.PickFile(options);
```

### Example 2: Save Document with Filters

```csharp
var options = new FilePickerOptions("Save Document", FileDialogType.SaveFile)
    .WithDefaultPath(
        Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments))
    .WithFilter(new FilePickerFilter("Word Documents", "doc", "docx"))
    .WithFilter(new FilePickerFilter("PDF Files", "pdf"))
    .WithFilter(new FilePickerFilter("Text Files", "txt"));

FilePickerResult result = picker.PickFile(options);
```

### Example 3: Select Multiple Images

```csharp
var options = new FilePickerOptions("Import Images")
    .WithDefaultPath(
        Environment.GetFolderPath(Environment.SpecialFolder.MyPictures))
    .WithFilter(new FilePickerFilter("Images", "jpg", "jpeg", "png", "gif", "bmp"))
    .WithFilter(new FilePickerFilter("JPEG Only", "jpg", "jpeg"))
    .WithFilter(new FilePickerFilter("PNG Only", "png"))
    .WithMultipleSelection();

FilePickerResult result = picker.PickFiles(options);

if (result.IsSuccess)
{
    foreach (var imagePath in result.SelectedPaths)
    {
        Console.WriteLine($"Selected: {imagePath}");
    }
}
```

### Example 4: Select Project Folder

```csharp
var options = new FilePickerOptions("Select Project", FileDialogType.SelectFolder)
    .WithDefaultPath(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));

FilePickerResult result = picker.PickFolder(options);

if (result.IsSuccess)
{
    string projectPath = result.SelectedPath;
    Console.WriteLine($"Project folder: {projectPath}");
}
```

### Example 5: Custom Configuration Builder

```csharp
public static class FilePickerOptionsBuilder
{
    public static FilePickerOptions ForImageImport()
    {
        return new FilePickerOptions("Import Images")
            .WithDefaultPath(
                Environment.GetFolderPath(Environment.SpecialFolder.MyPictures))
            .WithFilter(new FilePickerFilter("All Images", 
                "jpg", "jpeg", "png", "gif", "bmp", "tiff", "webp"))
            .WithFilter(new FilePickerFilter("JPEG Images", "jpg", "jpeg"))
            .WithFilter(new FilePickerFilter("PNG Images", "png"))
            .WithMultipleSelection();
    }
    
    public static FilePickerOptions ForSourceCodeOpen()
    {
        return new FilePickerOptions("Open Source File")
            .WithDefaultPath(
                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile))
            .WithFilter(new FilePickerFilter("C# Files", "cs"))
            .WithFilter(new FilePickerFilter("All Source", "cs", "cpp", "h", "hpp", "js", "ts"))
            .WithFilter(new FilePickerFilter("All Files", "*"));
    }
    
    public static FilePickerOptions ForProjectOpen()
    {
        return new FilePickerOptions("Open Project", FileDialogType.SelectFolder)
            .WithDefaultPath(
                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));
    }
}

// Usage:
var imageOptions = FilePickerOptionsBuilder.ForImageImport();
var codeOptions = FilePickerOptionsBuilder.ForSourceCodeOpen();
var projectOptions = FilePickerOptionsBuilder.ForProjectOpen();
```

---

## Best Practices

1. **Always set a meaningful title:**
   ```csharp
   // Good
   new FilePickerOptions("Select Image to Import")
   
   // Avoid
   new FilePickerOptions("Choose File")
   ```

2. **Provide sensible default paths:**
   ```csharp
   .WithDefaultPath(
       Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments))
   ```

3. **Order filters by likelihood of use:**
   ```csharp
   .WithFilter(new FilePickerFilter("My Format", "myext"))  // Most likely
   .WithFilter(new FilePickerFilter("All Files", "*"))       // Fallback
   ```

4. **Be specific with file type filters:**
   ```csharp
   // Good - specific filter names
   .WithFilter(new FilePickerFilter("Excel Spreadsheets", "xlsx", "xls"))
   
   // Avoid - vague names
   .WithFilter(new FilePickerFilter("Files", "xlsx", "xls"))
   ```

5. **Chain methods for clean configuration:**
   ```csharp
   var options = new FilePickerOptions("Title")
       .WithDefaultPath(path)
       .WithFilter(filter1)
       .WithFilter(filter2)
       .WithMultipleSelection();
   ```

---

## Related Classes

- `IFilePicker` - Consumes options
- `FilePickerFactory` - Creates pickers
- `FilePickerFilter` - File type filters
- `FilePickerResult` - Operation result
- `FilePickerValidator` - Validates options
- `FileDialogType` - Dialog type enumeration

---

**Last Updated:** February 22, 2026

