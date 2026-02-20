# FilePickerResult Class Documentation

## Overview

`FilePickerResult` is a result class that encapsulates the outcome of a file picker dialog operation. It indicates whether the operation was successful, cancelled, or resulted in an error, and provides access to selected file paths.

## Namespace

```csharp
using Alis.Extension.Io.FileDialog;
```

## Class Definition

```csharp
public class FilePickerResult
{
    public bool IsSuccess { get; private set; }
    public bool IsCancelled { get; private set; }
    public List<string> SelectedPaths { get; private set; }
    public string ErrorMessage { get; private set; }
    public string SelectedPath { get; }
    
    public FilePickerResult(List<string> selectedPaths);
    public FilePickerResult(string selectedPath);
    
    public static FilePickerResult CreateCancelled();
    public static FilePickerResult CreateError(string errorMessage);
}
```

## Properties

### IsSuccess

**Type:** `bool`

**Access:** Read-only

**Description:**
Indicates whether the file picker operation completed successfully.

**Remarks:**
- `true` when one or more files/folders were selected
- `false` when the operation was cancelled or an error occurred
- Check this before accessing `SelectedPath` or `SelectedPaths`

**Example:**
```csharp
if (result.IsSuccess)
{
    // Safe to use result.SelectedPath or result.SelectedPaths
}
```

---

### IsCancelled

**Type:** `bool`

**Access:** Read-only

**Description:**
Indicates whether the user cancelled the dialog without making a selection.

**Remarks:**
- `true` when the user closed the dialog or clicked Cancel
- `false` when the operation succeeded or an error occurred
- Cancellation is a normal user action, not an error condition
- Both `IsCancelled` and error conditions have `IsSuccess = false`

**Example:**
```csharp
if (result.IsCancelled)
{
    Console.WriteLine("User cancelled the dialog");
}
```

---

### SelectedPaths

**Type:** `List<string>`

**Access:** Read-only

**Description:**
A collection of all selected file/folder paths.

**Remarks:**
- Only populated when `IsSuccess = true`
- Empty list when `IsSuccess = false` or `IsCancelled = true`
- Count is 1 for single-selection dialogs
- Count can be > 1 for multi-selection dialogs
- Each path is guaranteed to be non-null and non-empty

**Example:**
```csharp
if (result.IsSuccess)
{
    foreach (var path in result.SelectedPaths)
    {
        Console.WriteLine($"Path: {path}");
    }
}
```

---

### SelectedPath

**Type:** `string`

**Access:** Read-only

**Description:**
The first selected file/folder path. Provides convenient access for single-selection scenarios.

**Remarks:**
- Returns the first item from `SelectedPaths`
- Returns `null` if no paths are selected
- Equivalent to `SelectedPaths.FirstOrDefault()`
- Useful for single-file selection dialogs

**Example:**
```csharp
if (result.IsSuccess)
{
    string singleFile = result.SelectedPath;
    Console.WriteLine($"File: {singleFile}");
}
```

---

### ErrorMessage

**Type:** `string`

**Access:** Read-only

**Description:**
Contains the error message if the operation failed.

**Remarks:**
- `null` or empty when `IsSuccess = true` or `IsCancelled = true`
- Contains descriptive error text when an error occurred
- Useful for logging and user notification

**Example:**
```csharp
if (!result.IsSuccess && !result.IsCancelled)
{
    Logger.Error($"Dialog error: {result.ErrorMessage}");
}
```

---

## Constructors

### FilePickerResult(List<string> selectedPaths)

**Signature:**
```csharp
public FilePickerResult(List<string> selectedPaths)
```

**Description:**
Creates a successful result with a list of selected paths.

**Parameters:**
- `selectedPaths` - List of selected file/folder paths (required, cannot be null or empty)

**Exceptions:**
- `ArgumentNullException` - Thrown if `selectedPaths` is null
- `ArgumentException` - Thrown if `selectedPaths` is empty

**Remarks:**
- Sets `IsSuccess = true`, `IsCancelled = false`
- Clears `ErrorMessage`
- Initializes `SelectedPaths` with a copy of the input list
- Preferred for multiple-selection results

**Example:**
```csharp
var paths = new List<string> 
{ 
    "/path/to/file1.txt",
    "/path/to/file2.txt"
};
var result = new FilePickerResult(paths);

// result.IsSuccess == true
// result.SelectedPaths.Count == 2
```

---

### FilePickerResult(string selectedPath)

**Signature:**
```csharp
public FilePickerResult(string selectedPath)
```

**Description:**
Creates a successful result with a single selected path.

**Parameters:**
- `selectedPath` - The selected file/folder path (required, cannot be null or empty)

**Exceptions:**
- `ArgumentException` - Thrown if `selectedPath` is null or empty

**Remarks:**
- Sets `IsSuccess = true`, `IsCancelled = false`
- Clears `ErrorMessage`
- Initializes `SelectedPaths` with a list containing the single path
- Preferred for single-selection results
- Equivalent to passing `new List<string> { selectedPath }`

**Example:**
```csharp
var result = new FilePickerResult("/path/to/file.txt");

// result.IsSuccess == true
// result.SelectedPath == "/path/to/file.txt"
// result.SelectedPaths.Count == 1
```

---

## Static Factory Methods

### CreateCancelled()

**Signature:**
```csharp
public static FilePickerResult CreateCancelled()
```

**Description:**
Creates a result representing user cancellation of the dialog.

**Returns:**
- `FilePickerResult` - A cancelled result

**Remarks:**
- Sets `IsSuccess = false`, `IsCancelled = true`
- `SelectedPaths` is empty
- `ErrorMessage` = "User cancelled the dialog."
- Use this when the user closes or cancels the dialog

**Example:**
```csharp
// In a picker implementation when user clicks Cancel
if (userCancelledDialog)
{
    return FilePickerResult.CreateCancelled();
}

// Handling the cancelled result
if (result.IsCancelled)
{
    Console.WriteLine("User cancelled the dialog");
}
```

---

### CreateError(string errorMessage)

**Signature:**
```csharp
public static FilePickerResult CreateError(string errorMessage)
```

**Description:**
Creates a result representing an error during the dialog operation.

**Parameters:**
- `errorMessage` - Description of the error (required, cannot be null or empty)

**Returns:**
- `FilePickerResult` - An error result

**Exceptions:**
- `ArgumentException` - Thrown if `errorMessage` is null or empty

**Remarks:**
- Sets `IsSuccess = false`, `IsCancelled = false`
- `SelectedPaths` is empty
- `ErrorMessage` contains the provided error text
- Use this for exceptions and invalid states

**Example:**
```csharp
// In a picker implementation when an error occurs
try
{
    // Execute dialog
}
catch (Exception ex)
{
    return FilePickerResult.CreateError(
        $"Failed to open dialog: {ex.Message}");
}

// Handling the error result
if (!result.IsSuccess && !result.IsCancelled)
{
    Logger.Error($"Dialog error: {result.ErrorMessage}");
}
```

---

## Result Status Patterns

### Pattern 1: Success Check

```csharp
FilePickerResult result = picker.PickFile(options);

if (result.IsSuccess)
{
    // Safe to use SelectedPath or SelectedPaths
    ProcessFile(result.SelectedPath);
}
else if (result.IsCancelled)
{
    Logger.Info("User cancelled");
}
else
{
    Logger.Error($"Error: {result.ErrorMessage}");
}
```

### Pattern 2: Null Check

```csharp
// Using SelectedPath for single selection
if (!string.IsNullOrEmpty(result.SelectedPath))
{
    ProcessFile(result.SelectedPath);
}
```

### Pattern 3: Collection Iteration

```csharp
// Using SelectedPaths for multiple selection
foreach (var path in result.SelectedPaths)
{
    ProcessFile(path);
}
```

### Pattern 4: Error Handling

```csharp
if (!result.IsSuccess)
{
    string message = result.IsCancelled 
        ? "Operation cancelled"
        : $"Error: {result.ErrorMessage}";
    
    Logger.Warning(message);
}
```

---

## Complete Usage Examples

### Example 1: Single File Selection

```csharp
var options = new FilePickerOptions("Open Document");
FilePickerResult result = picker.PickFile(options);

if (result.IsSuccess)
{
    string filePath = result.SelectedPath;
    FileInfo info = new FileInfo(filePath);
    Console.WriteLine($"File: {info.Name}, Size: {info.Length} bytes");
}
else if (result.IsCancelled)
{
    Console.WriteLine("File selection cancelled");
}
else
{
    Console.WriteLine($"Failed: {result.ErrorMessage}");
}
```

### Example 2: Multiple File Processing

```csharp
var options = new FilePickerOptions("Select Images")
    .WithMultipleSelection()
    .WithFilter(new FilePickerFilter("Images", "jpg", "png", "gif"));

FilePickerResult result = picker.PickFiles(options);

if (result.IsSuccess)
{
    Console.WriteLine($"Processing {result.SelectedPaths.Count} files:");
    
    int processed = 0;
    foreach (var path in result.SelectedPaths)
    {
        try
        {
            ProcessImage(path);
            processed++;
        }
        catch (Exception ex)
        {
            Logger.Warning($"Failed to process {path}: {ex.Message}");
        }
    }
    
    Console.WriteLine($"Successfully processed {processed} files");
}
```

### Example 3: Folder Selection with Validation

```csharp
var options = new FilePickerOptions("Select Project", FileDialogType.SelectFolder);
FilePickerResult result = picker.PickFolder(options);

if (result.IsSuccess)
{
    string folderPath = result.SelectedPath;
    
    if (!Directory.Exists(folderPath))
    {
        Logger.Error($"Selected path no longer exists: {folderPath}");
        return;
    }
    
    var files = Directory.GetFiles(folderPath);
    Console.WriteLine($"Selected folder contains {files.Length} files");
}
else if (result.IsCancelled)
{
    Logger.Info("Folder selection cancelled");
}
else
{
    Logger.Error(result.ErrorMessage);
}
```

### Example 4: Async File Processing

```csharp
public async Task<bool> ImportFilesAsync()
{
    var options = new FilePickerOptions("Import Data Files")
        .WithMultipleSelection()
        .WithFilter(new FilePickerFilter("Data", "csv", "json", "xml"));
    
    FilePickerResult result = picker.PickFiles(options);
    
    if (!result.IsSuccess)
    {
        return result.IsCancelled; // false if error, true if cancelled
    }
    
    // Process files asynchronously
    var tasks = result.SelectedPaths
        .Select(path => ImportFileAsync(path))
        .ToList();
    
    bool[] importResults = await Task.WhenAll(tasks);
    
    int successCount = importResults.Count(r => r);
    Console.WriteLine($"Imported {successCount}/{importResults.Length} files");
    
    return successCount == importResults.Length;
}
```

### Example 5: Validation and Logging

```csharp
public void SelectAndValidateFile()
{
    var options = new FilePickerOptions("Open Configuration");
    FilePickerResult result = picker.PickFile(options);
    
    // Log the result
    if (result.IsSuccess)
    {
        Logger.Info($"File selected: {result.SelectedPath}");
        
        // Validate the result
        bool isValid = FilePickerValidator.IsResultValid(result, options);
        Logger.Info($"Validation: {(isValid ? "PASSED" : "FAILED")}");
    }
    else if (result.IsCancelled)
    {
        Logger.Trace("User cancelled file selection");
    }
    else
    {
        Logger.Error($"Selection failed: {result.ErrorMessage}");
    }
}
```

---

## Best Practices

1. **Always check IsSuccess before using paths:**
   ```csharp
   if (result.IsSuccess)
   {
       // Safe to use result.SelectedPath
   }
   ```

2. **Handle cancellation as a normal case:**
   ```csharp
   if (result.IsCancelled)
   {
       // User cancelled - not an error condition
   }
   ```

3. **Distinguish between cancellation and errors:**
   ```csharp
   if (!result.IsSuccess)
   {
       if (result.IsCancelled)
           // Handle cancellation
       else
           // Handle error
   }
   ```

4. **Use SelectedPath for single selection:**
   ```csharp
   // For single file selection
   string file = result.SelectedPath;
   ```

5. **Use SelectedPaths for multiple selection:**
   ```csharp
   // For multiple file selection
   foreach (var file in result.SelectedPaths)
   ```

6. **Log error messages for debugging:**
   ```csharp
   if (!result.IsSuccess && !result.IsCancelled)
   {
       Logger.Error(result.ErrorMessage);
   }
   ```

---

## Related Classes

- `IFilePicker` - Produces results
- `FilePickerValidator` - Validates results
- `FilePickerResult` - This class

---

**Last Updated:** February 22, 2026

