# FilePickerFilter Class Documentation

## Overview

`FilePickerFilter` represents a file type filter that appears in file picker dialogs. It associates a user-friendly display name with a set of file extensions.

## Namespace

```csharp
using Alis.Extension.Io.FileDialog;
```

## Class Definition

```csharp
public class FilePickerFilter
{
    public string DisplayName { get; set; }
    public List<string> Extensions { get; set; }
    
    public FilePickerFilter(string displayName, params string[] extensions);
    
    public string GetFormattedExtensions();
    public string GetUtiFormat();
}
```

## Properties

### DisplayName

**Type:** `string`

**Description:**
The user-friendly name displayed in the file picker dialog's filter dropdown.

**Remarks:**
- Cannot be null or empty
- Should be descriptive (e.g., "JPEG Images" not "jpg")
- Appears as the label in the filter dropdown
- Example values: "Text Files", "JPEG Images", "All Documents"

**Example:**
```csharp
var filter = new FilePickerFilter("Word Documents", "doc", "docx");
// DisplayName = "Word Documents"
```

---

### Extensions

**Type:** `List<string>`

**Description:**
A list of file extensions (without leading dots) that this filter matches.

**Remarks:**
- Extensions are stored without leading dots
- Leading dots are automatically removed if provided
- Case is preserved as provided
- Empty list is not allowed (enforced by constructor)

**Example:**
```csharp
var filter = new FilePickerFilter("Images", "jpg", "png", "gif");
// Extensions = { "jpg", "png", "gif" }
```

---

## Constructor

### FilePickerFilter(string displayName, params string[] extensions)

**Signature:**
```csharp
public FilePickerFilter(string displayName, params string[] extensions)
```

**Description:**
Creates a new file filter with specified display name and file extensions.

**Parameters:**
- `displayName` - User-friendly name (required, cannot be null or empty)
- `extensions` - One or more file extensions (required, at least one must be provided)

**Exceptions:**
- `ArgumentException` - Thrown if `displayName` is null or empty
- `ArgumentException` - Thrown if `extensions` is null or empty

**Remarks:**
- Leading dots in extensions are automatically removed
- Extensions are case-sensitive for storage but matching may be case-insensitive
- At least one extension is required
- Supports special extension "*" to represent all files

**Example:**
```csharp
// Single extension
var textFilter = new FilePickerFilter("Text Files", "txt");

// Multiple extensions
var docFilter = new FilePickerFilter("Documents", "doc", "docx", "pdf", "txt");

// Extensions with dots (dots are removed)
var codeFilter = new FilePickerFilter("Code", ".cs", ".cpp", ".js");
// Stored as: { "cs", "cpp", "js" }

// All files filter
var allFilter = new FilePickerFilter("All Files", "*");
```

---

## Methods

### GetFormattedExtensions()

**Signature:**
```csharp
public string GetFormattedExtensions()
```

**Description:**
Returns the extensions formatted for Windows file dialogs (e.g., "*.txt;*.doc").

**Returns:**
- `string` - Semicolon-separated list of extensions in Windows format

**Remarks:**
- Adds asterisks and dots to extensions
- Separates multiple extensions with semicolons
- Used for Windows dialog filter strings
- Format: "*.ext1;*.ext2;*.ext3"

**Example:**
```csharp
var filter = new FilePickerFilter("Documents", "doc", "docx", "pdf");

string formatted = filter.GetFormattedExtensions();
// Returns: "*.doc;*.docx;*.pdf"
```

---

### GetUtiFormat()

**Signature:**
```csharp
public string GetUtiFormat()
```

**Description:**
Returns the extensions formatted for macOS UTI (Uniform Type Identifier) format.

**Returns:**
- `string` - Comma-separated list of extensions

**Remarks:**
- Extensions are separated by commas
- No asterisks or dots added
- Used for macOS AppleScript file type specification
- Format: "ext1,ext2,ext3"
- UTI is used in macOS to specify file types

**Example:**
```csharp
var filter = new FilePickerFilter("Images", "jpg", "jpeg", "png");

string utiFormat = filter.GetUtiFormat();
// Returns: "jpg,jpeg,png"
```

---

## Platform-Specific Formatting

### Windows Format (GetFormattedExtensions)

```csharp
var filter = new FilePickerFilter("Audio Files", "mp3", "wav", "flac");
string format = filter.GetFormattedExtensions();
// Output: "*.mp3;*.wav;*.flac"

// Used in OpenFileDialog like:
// dialog.Filter = "Audio Files (*.mp3;*.wav;*.flac)|*.mp3;*.wav;*.flac";
```

### macOS Format (GetUtiFormat)

```csharp
var filter = new FilePickerFilter("Video Files", "mp4", "mov", "avi");
string format = filter.GetUtiFormat();
// Output: "mp4,mov,avi"

// Used in AppleScript like:
// "choose file of type {"mp4", "mov", "avi"}"
```

---

## Complete Usage Examples

### Example 1: Creating Common Filters

```csharp
// Document formats
var documentFilter = new FilePickerFilter(
    "Office Documents",
    "doc", "docx", "xls", "xlsx", "ppt", "pptx"
);

// Image formats
var imageFilter = new FilePickerFilter(
    "Images",
    "jpg", "jpeg", "png", "gif", "bmp", "tiff", "webp"
);

// Source code files
var codeFilter = new FilePickerFilter(
    "C# Source Files",
    "cs"
);

// All files (wildcard)
var allFilter = new FilePickerFilter(
    "All Files",
    "*"
);
```

### Example 2: Using with FilePickerOptions

```csharp
var options = new FilePickerOptions("Open File")
    .WithFilter(new FilePickerFilter("Text Files", "txt", "log", "ini", "cfg"))
    .WithFilter(new FilePickerFilter("All Files", "*"));

// First filter is typically selected by default in the dialog
```

### Example 3: Building Custom Filter List

```csharp
public static class FileFilters
{
    public static FilePickerFilter Documents =>
        new FilePickerFilter("Office Documents", "doc", "docx", "pdf", "odt", "rtf");
    
    public static FilePickerFilter Spreadsheets =>
        new FilePickerFilter("Spreadsheets", "xls", "xlsx", "csv", "ods");
    
    public static FilePickerFilter Presentations =>
        new FilePickerFilter("Presentations", "ppt", "pptx", "odp");
    
    public static FilePickerFilter Images =>
        new FilePickerFilter("Images", "jpg", "jpeg", "png", "gif", "bmp", "webp");
    
    public static FilePickerFilter Audio =>
        new FilePickerFilter("Audio Files", "mp3", "wav", "flac", "aac", "m4a", "ogg");
    
    public static FilePickerFilter Video =>
        new FilePickerFilter("Video Files", "mp4", "mkv", "avi", "mov", "flv", "wmv");
    
    public static FilePickerFilter All =>
        new FilePickerFilter("All Files", "*");
}

// Usage:
var options = new FilePickerOptions("Select Media")
    .WithFilter(FileFilters.Images)
    .WithFilter(FileFilters.Video)
    .WithFilter(FileFilters.Audio)
    .WithFilter(FileFilters.All);
```

### Example 4: Format Inspection

```csharp
var filter = new FilePickerFilter("Web Files", "html", "css", "js");

Console.WriteLine($"Display Name: {filter.DisplayName}");
// Output: Display Name: Web Files

Console.WriteLine($"Extensions: {string.Join(", ", filter.Extensions)}");
// Output: Extensions: html, css, js

Console.WriteLine($"Windows Format: {filter.GetFormattedExtensions()}");
// Output: Windows Format: *.html;*.css;*.js

Console.WriteLine($"macOS Format: {filter.GetUtiFormat()}");
// Output: macOS Format: html,css,js
```

### Example 5: Dynamic Filter Building

```csharp
public static class FilterBuilder
{
    public static FilePickerFilter CreateForExtensions(string displayName, params string[] extensions)
    {
        if (string.IsNullOrWhiteSpace(displayName))
            throw new ArgumentException("Display name required", nameof(displayName));
        
        if (extensions == null || extensions.Length == 0)
            throw new ArgumentException("At least one extension required", nameof(extensions));
        
        return new FilePickerFilter(displayName, extensions);
    }
    
    public static List<FilePickerFilter> CreateStandardSet()
    {
        return new List<FilePickerFilter>
        {
            new FilePickerFilter("All Files", "*"),
            new FilePickerFilter("Text Files", "txt", "log"),
            new FilePickerFilter("Documents", "doc", "docx", "pdf"),
            new FilePickerFilter("Images", "jpg", "jpeg", "png", "gif"),
            new FilePickerFilter("Archives", "zip", "rar", "7z", "tar", "gz"),
        };
    }
}

// Usage:
var customFilter = FilterBuilder.CreateForExtensions("Configuration Files", "json", "yaml", "toml", "ini");
var standardFilters = FilterBuilder.CreateStandardSet();
```

---

## Best Practices

1. **Use descriptive display names:**
   ```csharp
   // Good
   new FilePickerFilter("JPEG Images", "jpg", "jpeg")
   
   // Avoid
   new FilePickerFilter("jpg", "jpg", "jpeg")
   ```

2. **Group related extensions:**
   ```csharp
   // Good - related formats together
   new FilePickerFilter("Image Files", "jpg", "jpeg", "png", "gif", "bmp")
   
   // Avoid - unrelated formats together
   new FilePickerFilter("Files", "jpg", "doc", "mp3", "rar")
   ```

3. **Order common formats first:**
   ```csharp
   // When creating filters, order by likelihood of use
   .WithFilter(new FilePickerFilter("JPEG Images", "jpg", "jpeg"))  // Most common
   .WithFilter(new FilePickerFilter("PNG Images", "png"))            // Also common
   .WithFilter(new FilePickerFilter("Other Formats", "gif", "bmp"))  // Less common
   .WithFilter(new FilePickerFilter("All Files", "*"))               // Fallback
   ```

4. **Consider standard file associations:**
   ```csharp
   // Match OS file type associations
   var csharpFilter = new FilePickerFilter("C# Source Files", "cs");
   var pythonFilter = new FilePickerFilter("Python Files", "py", "pyw");
   ```

5. **Support multiple related extensions:**
   ```csharp
   // Include all variants
   new FilePickerFilter("Word Documents", "doc", "docx", "docm")
   new FilePickerFilter("JPEG Images", "jpg", "jpeg", "jpe")
   ```

6. **Use wildcard for fallback:**
   ```csharp
   // Always provide an "All Files" option
   .WithFilter(/* your specific filters */)
   .WithFilter(new FilePickerFilter("All Files", "*"))
   ```

---

## Error Handling

```csharp
try
{
    var filter = new FilePickerFilter("", "txt");  // Invalid - empty display name
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

try
{
    var filter = new FilePickerFilter("Files");  // Invalid - no extensions
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
```

---

## Related Classes

- `FilePickerOptions` - Consumes filters
- `IFilePicker` - Uses filters in dialogs

---

**Last Updated:** February 22, 2026

