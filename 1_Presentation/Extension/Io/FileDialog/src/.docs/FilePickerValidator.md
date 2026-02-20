# FilePickerValidator Class Documentation

## Overview

`FilePickerValidator` is a static utility class providing comprehensive validation functionality for file picker operations. It validates configuration options, file paths, file extensions, and picker operation results.

## Namespace

```csharp
using Alis.Extension.Io.FileDialog;
```

## Class Definition

```csharp
public static class FilePickerValidator
{
    public static void ValidateOptions(FilePickerOptions options);
    public static bool IsValidFilePath(string filePath);
    public static bool IsValidDirectoryPath(string directoryPath);
    public static bool IsFileExtensionAllowed(string filePath, FilePickerOptions options);
    public static bool IsResultValid(FilePickerResult result, FilePickerOptions options);
}
```

## Methods

### ValidateOptions(FilePickerOptions options)

**Signature:**
```csharp
public static void ValidateOptions(FilePickerOptions options)
```

**Description:**
Validates that the picker options are properly configured for dialog execution.

**Parameters:**
- `options` - The `FilePickerOptions` to validate (required)

**Exceptions:**
- `ArgumentNullException` - Thrown if `options` is null
- `ArgumentException` - Thrown if options contain invalid values

**Validation Rules:**
1. Options cannot be null
2. Title must not be null or empty
3. If `DefaultPath` is specified, it must exist
4. `SaveFile` dialogs cannot have `AllowMultiple = true`
5. `AllowDirectories` can only be true for `SelectFolder` dialogs

**Remarks:**
- Called automatically by `FilePickerFactory.CreateFilePickerWithOptions()`
- Logs all validation steps for debugging
- Exceptions include descriptive messages

**Example:**
```csharp
var options = new FilePickerOptions("Open File");

try
{
    FilePickerValidator.ValidateOptions(options);
    Console.WriteLine("Options are valid");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Invalid options: {ex.Message}");
}
```

---

### IsValidFilePath(string filePath)

**Signature:**
```csharp
public static bool IsValidFilePath(string filePath)
```

**Description:**
Checks if a file path exists and is accessible.

**Parameters:**
- `filePath` - The file path to validate

**Returns:**
- `bool` - `true` if the file exists, `false` otherwise

**Remarks:**
- Returns `false` for null or empty paths
- Returns `false` if the file doesn't exist
- Returns `false` if access is denied
- Never throws exceptions
- Logs warnings for invalid paths

**Example:**
```csharp
if (FilePickerValidator.IsValidFilePath("/path/to/file.txt"))
{
    Console.WriteLine("File exists");
}
else
{
    Console.WriteLine("File not found");
}
```

---

### IsValidDirectoryPath(string directoryPath)

**Signature:**
```csharp
public static bool IsValidDirectoryPath(string directoryPath)
```

**Description:**
Checks if a directory path exists and is accessible.

**Parameters:**
- `directoryPath` - The directory path to validate

**Returns:**
- `bool` - `true` if the directory exists, `false` otherwise

**Remarks:**
- Returns `false` for null or empty paths
- Returns `false` if the directory doesn't exist
- Returns `false` if access is denied
- Never throws exceptions
- Logs warnings for invalid paths

**Example:**
```csharp
if (FilePickerValidator.IsValidDirectoryPath("/home/user/Documents"))
{
    Console.WriteLine("Directory exists");
}
else
{
    Console.WriteLine("Directory not found");
}
```

---

### IsFileExtensionAllowed(string filePath, FilePickerOptions options)

**Signature:**
```csharp
public static bool IsFileExtensionAllowed(string filePath, FilePickerOptions options)
```

**Description:**
Validates that a file's extension matches the allowed filters in the options.

**Parameters:**
- `filePath` - The file path to check
- `options` - The `FilePickerOptions` containing allowed filters

**Returns:**
- `bool` - `true` if extension is allowed, `false` otherwise

**Remarks:**
- Returns `true` if no filters are specified (all extensions allowed)
- Returns `false` for null or empty paths
- Comparison is case-insensitive
- Returns `false` if file has no extension
- Logs validation results for debugging

**Example:**
```csharp
var options = new FilePickerOptions("Open")
    .WithFilter(new FilePickerFilter("Images", "jpg", "png"));

bool allowed = FilePickerValidator.IsFileExtensionAllowed(
    "/path/image.jpg",
    options
);

if (allowed)
{
    Console.WriteLine("File extension is allowed");
}
else
{
    Console.WriteLine("File extension is not in the filter list");
}
```

---

### IsResultValid(FilePickerResult result, FilePickerOptions options)

**Signature:**
```csharp
public static bool IsResultValid(FilePickerResult result, FilePickerOptions options)
```

**Description:**
Validates that an operation result is consistent with the dialog options.

**Parameters:**
- `result` - The `FilePickerResult` to validate
- `options` - The `FilePickerOptions` used for the operation

**Returns:**
- `bool` - `true` if result is valid, `false` otherwise

**Validation Rules:**
1. Result cannot be null
2. For successful results:
   - Must have selected paths
   - Path count must not exceed 1 if `AllowMultiple` is false
   - For `OpenFile`: Selected files must exist
   - For `OpenFile`: File extensions must match filters
   - For `SelectFolder`: Selected directories must exist
3. For failed results:
   - Always valid (no paths to check)

**Remarks:**
- Returns `true` for cancelled or error results
- Validates that selected files actually exist
- Validates extension filtering was respected
- Logs all validation steps

**Example:**
```csharp
var options = new FilePickerOptions("Select");
FilePickerResult result = picker.PickFile(options);

if (FilePickerValidator.IsResultValid(result, options))
{
    // Result is consistent with options
}
else
{
    Logger.Warning("Result doesn't match expected criteria");
}
```

---

## Complete Usage Examples

### Example 1: Pre-Dialog Validation

```csharp
public FilePickerResult SelectFile()
{
    var options = new FilePickerOptions("Open Document")
        .WithDefaultPath("/home/user/Documents")
        .WithFilter(new FilePickerFilter("PDF Files", "pdf"))
        .WithFilter(new FilePickerFilter("Word Docs", "doc", "docx"));
    
    try
    {
        // Validate before creating picker
        FilePickerValidator.ValidateOptions(options);
        
        IFilePicker picker = FilePickerFactory.CreateFilePicker();
        return picker.PickFile(options);
    }
    catch (ArgumentException ex)
    {
        Logger.Error($"Invalid options: {ex.Message}");
        return FilePickerResult.CreateError(ex.Message);
    }
}
```

### Example 2: Post-Dialog Result Validation

```csharp
public void ProcessSelectedFiles()
{
    var options = new FilePickerOptions("Select Images")
        .WithFilter(new FilePickerFilter("Images", "jpg", "png", "gif"))
        .WithMultipleSelection();
    
    FilePickerResult result = picker.PickFiles(options);
    
    // Validate result matches options
    if (FilePickerValidator.IsResultValid(result, options))
    {
        Logger.Info("Result validation passed");
        ProcessFiles(result.SelectedPaths);
    }
    else
    {
        Logger.Warning("Result validation failed");
    }
}
```

### Example 3: Individual Path Validation

```csharp
public void ValidatePaths(List<string> paths)
{
    foreach (var path in paths)
    {
        if (FilePickerValidator.IsValidFilePath(path))
        {
            Console.WriteLine($"Valid file: {path}");
        }
        else
        {
            Console.WriteLine($"Invalid or missing: {path}");
        }
    }
}
```

### Example 4: Extension Filtering Validation

```csharp
public bool IsFileAllowed(string filePath, FilePickerOptions options)
{
    // First check if file exists
    if (!FilePickerValidator.IsValidFilePath(filePath))
    {
        Logger.Warning($"File not found: {filePath}");
        return false;
    }
    
    // Then check extension
    if (!FilePickerValidator.IsFileExtensionAllowed(filePath, options))
    {
        Logger.Warning($"File extension not allowed: {filePath}");
        return false;
    }
    
    Logger.Info($"File is valid: {filePath}");
    return true;
}
```

### Example 5: Comprehensive Validation Pipeline

```csharp
public class FileImportService
{
    private readonly IFilePicker _picker;
    
    public FileImportService()
    {
        _picker = FilePickerFactory.CreateFilePicker();
    }
    
    public bool ImportFiles()
    {
        // Step 1: Configure options
        var options = new FilePickerOptions("Import Data", FileDialogType.OpenFile)
            .WithDefaultPath(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments))
            .WithFilter(new FilePickerFilter("Data Files", "csv", "json", "xml"))
            .WithFilter(new FilePickerFilter("Excel", "xlsx", "xls"))
            .WithMultipleSelection();
        
        // Step 2: Validate options
        try
        {
            FilePickerValidator.ValidateOptions(options);
        }
        catch (ArgumentException ex)
        {
            Logger.Error($"Configuration error: {ex.Message}");
            return false;
        }
        
        // Step 3: Open dialog
        FilePickerResult result = _picker.PickFiles(options);
        
        if (!result.IsSuccess)
        {
            if (result.IsCancelled)
            {
                Logger.Info("Import cancelled by user");
            }
            else
            {
                Logger.Error($"Dialog error: {result.ErrorMessage}");
            }
            return false;
        }
        
        // Step 4: Validate result
        if (!FilePickerValidator.IsResultValid(result, options))
        {
            Logger.Error("Result validation failed");
            return false;
        }
        
        // Step 5: Process files
        int importedCount = 0;
        foreach (var filePath in result.SelectedPaths)
        {
            // Double-check paths are still valid
            if (!FilePickerValidator.IsValidFilePath(filePath))
            {
                Logger.Warning($"File no longer exists: {filePath}");
                continue;
            }
            
            // Double-check extensions
            if (!FilePickerValidator.IsFileExtensionAllowed(filePath, options))
            {
                Logger.Warning($"Extension no longer allowed: {filePath}");
                continue;
            }
            
            if (ImportFile(filePath))
            {
                importedCount++;
            }
        }
        
        Logger.Info($"Successfully imported {importedCount}/{result.SelectedPaths.Count} files");
        return importedCount == result.SelectedPaths.Count;
    }
    
    private bool ImportFile(string filePath)
    {
        try
        {
            // Import logic here
            Logger.Info($"Imported: {filePath}");
            return true;
        }
        catch (Exception ex)
        {
            Logger.Error($"Failed to import {filePath}: {ex.Message}");
            return false;
        }
    }
}
```

---

## Best Practices

1. **Always validate options early:**
   ```csharp
   try
   {
       FilePickerValidator.ValidateOptions(options);
   }
   catch (ArgumentException ex)
   {
       // Handle configuration error
   }
   ```

2. **Validate results after dialog:**
   ```csharp
   if (FilePickerValidator.IsResultValid(result, options))
   {
       // Safe to use result
   }
   ```

3. **Check paths exist before processing:**
   ```csharp
   foreach (var path in result.SelectedPaths)
   {
       if (FilePickerValidator.IsValidFilePath(path))
       {
           ProcessFile(path);
       }
   }
   ```

4. **Use validators before business logic:**
   ```csharp
   // Validate inputs
   if (!IsValidated(path, options))
       return false;
   
   // Then proceed with business logic
   ProcessFile(path);
   ```

5. **Log validation failures:**
   ```csharp
   if (!FilePickerValidator.IsFileExtensionAllowed(path, options))
   {
       Logger.Warning($"Extension not allowed: {path}");
   }
   ```

---

## Related Classes

- `FilePickerOptions` - Validated by this class
- `FilePickerResult` - Validated by this class
- `IFilePicker` - Should use results validated by this class

---

**Last Updated:** February 22, 2026

