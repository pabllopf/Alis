# FilePickerPathConverter Class Documentation

## Overview

`FilePickerPathConverter` is a static utility class providing cross-platform path conversion, normalization, and validation functions. It handles the differences in path formats between Windows, macOS, and Linux.

## Namespace

```csharp
using Alis.Extension.Io.FileDialog;
```

## Class Definition

```csharp
public static class FilePickerPathConverter
{
    public static string NormalizePath(string path);
    public static string[] SplitMultiplePaths(string pathsString);
    public static string ConvertPathSeparators(string path);
    public static string GetDirectoryName(string filePath);
    public static string GetFileName(string filePath);
    public static bool IsValidPath(string path, bool mustExist = true);
}
```

## Methods

### NormalizePath(string path)

**Signature:**
```csharp
public static string NormalizePath(string path)
```

**Description:**
Normalizes a path by removing leading and trailing whitespace and newlines.

**Parameters:**
- `path` - The path to normalize

**Returns:**
- `string` - The normalized path, or `null` if input is null or empty

**Remarks:**
- Handles newlines from dialog output
- Removes leading and trailing spaces
- Handles Windows newline sequences (`\r\n`)
- Safe to call with null input (returns null)
- Logs the normalization process

**Example:**
```csharp
string dirty = "  /path/to/file.txt\n";
string clean = FilePickerPathConverter.NormalizePath(dirty);
// Result: "/path/to/file.txt"
```

---

### SplitMultiplePaths(string pathsString)

**Signature:**
```csharp
public static string[] SplitMultiplePaths(string pathsString)
```

**Description:**
Splits multiple file paths separated by newlines (common output from Linux/macOS dialogs).

**Parameters:**
- `pathsString` - Concatenated paths separated by newlines

**Returns:**
- `string[]` - Array of individual normalized paths. Empty array if input is null/empty.

**Remarks:**
- Automatically normalizes each path
- Removes empty lines
- Handles both Unix (`\n`) and Windows (`\r\n`) line endings
- Never throws exceptions
- Each returned path is trimmed and non-empty

**Example:**
```csharp
string multiPath = "/path/one.txt\n/path/two.txt\n/path/three.txt";
string[] paths = FilePickerPathConverter.SplitMultiplePaths(multiPath);
// Result: [ "/path/one.txt", "/path/two.txt", "/path/three.txt" ]
```

---

### ConvertPathSeparators(string path)

**Signature:**
```csharp
public static string ConvertPathSeparators(string path)
```

**Description:**
Converts path separators to the platform-specific separator.

**Parameters:**
- `path` - The path with potentially mixed separators

**Returns:**
- `string` - The path with converted separators, or the original if conversion fails

**Remarks:**
- Converts backslashes and forward slashes to the platform default
- On Windows: converts to backslash (`\`)
- On Unix/Linux/macOS: converts to forward slash (`/`)
- Safe for mixed-separator paths (e.g., `C:/Users\user/file`)
- Never throws exceptions

**Example:**
```csharp
// On Unix/Linux/macOS:
string converted = FilePickerPathConverter.ConvertPathSeparators(
    "C:\\Users\\user\\file.txt");
// Result: "C:/Users/user/file.txt"
```

---

### GetDirectoryName(string filePath)

**Signature:**
```csharp
public static string GetDirectoryName(string filePath)
```

**Description:**
Extracts the directory path from a file path.

**Parameters:**
- `filePath` - The file path

**Returns:**
- `string` - The directory path, or `null` if the path is invalid

**Remarks:**
- Returns the parent directory of a file
- Returns `null` for null or empty input
- Never throws exceptions
- Wrapper around `Path.GetDirectoryName()` with error handling

**Example:**
```csharp
string dir = FilePickerPathConverter.GetDirectoryName("/home/user/Documents/file.txt");
// Result: "/home/user/Documents"
```

---

### GetFileName(string filePath)

**Signature:**
```csharp
public static string GetFileName(string filePath)
```

**Description:**
Extracts the filename (with extension) from a file path.

**Parameters:**
- `filePath` - The file path

**Returns:**
- `string` - The filename with extension, or `null` if invalid

**Remarks:**
- Returns only the filename, not the directory
- Includes the file extension
- Returns `null` for null or empty input
- Never throws exceptions
- Wrapper around `Path.GetFileName()` with error handling

**Example:**
```csharp
string filename = FilePickerPathConverter.GetFileName("/home/user/Documents/file.txt");
// Result: "file.txt"
```

---

### IsValidPath(string path, bool mustExist = true)

**Signature:**
```csharp
public static bool IsValidPath(string path, bool mustExist = true)
```

**Description:**
Validates that a path is properly formatted and optionally that it exists.

**Parameters:**
- `path` - The path to validate
- `mustExist` - Whether the path must exist on the filesystem (optional, default: `true`)

**Returns:**
- `bool` - `true` if the path is valid, `false` otherwise

**Remarks:**
- If `mustExist = true`: validates that the path exists
- If `mustExist = false`: only validates path format
- Checks for invalid characters in the path
- Returns `false` for null or empty input
- Never throws exceptions
- Platform-aware character validation

**Example:**
```csharp
// Check format only
bool isValid = FilePickerPathConverter.IsValidPath("/path/to/file.txt", mustExist: false);
// Result: true (valid format)

// Check format and existence
bool exists = FilePickerPathConverter.IsValidPath("/path/to/file.txt", mustExist: true);
// Result: depends on whether file exists
```

---

## Complete Usage Examples

### Example 1: Processing Dialog Output

```csharp
// macOS/Linux dialog returns concatenated paths
string dialogOutput = "/Users/john/image1.jpg\n/Users/john/image2.jpg\n";

// Normalize and split
string[] paths = FilePickerPathConverter.SplitMultiplePaths(dialogOutput);

foreach (var path in paths)
{
    Console.WriteLine($"Processing: {path}");
    string fileName = FilePickerPathConverter.GetFileName(path);
    Console.WriteLine($"  Filename: {fileName}");
}
```

### Example 2: Cross-Platform Path Handling

```csharp
public class CrossPlatformPathHandler
{
    public void ProcessPath(string windowsStylePath)
    {
        // Convert Windows path to current platform format
        string platformPath = FilePickerPathConverter.ConvertPathSeparators(windowsStylePath);
        
        string directory = FilePickerPathConverter.GetDirectoryName(platformPath);
        string filename = FilePickerPathConverter.GetFileName(platformPath);
        
        Console.WriteLine($"Directory: {directory}");
        Console.WriteLine($"Filename: {filename}");
    }
}
```

### Example 3: Validating Picker Output

```csharp
FilePickerResult result = picker.PickFiles(options);

if (result.IsSuccess)
{
    foreach (var rawPath in result.SelectedPaths)
    {
        // Normalize the path
        string cleanPath = FilePickerPathConverter.NormalizePath(rawPath);
        
        // Validate it exists
        if (FilePickerPathConverter.IsValidPath(cleanPath, mustExist: true))
        {
            Console.WriteLine($"Valid: {cleanPath}");
        }
        else
        {
            Console.WriteLine($"Invalid: {cleanPath}");
        }
    }
}
```

### Example 4: Safe Path Operations

```csharp
public class PathOperations
{
    public string GetRelativeFileName(string fullPath)
    {
        // Safe extraction - handles null/invalid gracefully
        string filename = FilePickerPathConverter.GetFileName(fullPath);
        return filename ?? "UNKNOWN";
    }
    
    public string GetSafePath(string path)
    {
        // Normalize and validate
        string normalized = FilePickerPathConverter.NormalizePath(path);
        
        if (normalized == null)
            return null;
        
        if (!FilePickerPathConverter.IsValidPath(normalized, mustExist: false))
            return null;
        
        return normalized;
    }
    
    public void ProcessMultipleSelections(string selectedPaths)
    {
        // Split with safety
        string[] paths = FilePickerPathConverter.SplitMultiplePaths(selectedPaths);
        
        if (paths.Length == 0)
        {
            Console.WriteLine("No valid paths found");
            return;
        }
        
        foreach (var path in paths)
        {
            string safeDir = FilePickerPathConverter.GetDirectoryName(path) ?? "UNKNOWN";
            string fileName = FilePickerPathConverter.GetFileName(path) ?? "UNKNOWN";
            
            Console.WriteLine($"  Directory: {safeDir}");
            Console.WriteLine($"  File: {fileName}");
        }
    }
}
```

### Example 5: Path Validation Pipeline

```csharp
public class PathValidator
{
    public bool IsValidAndAccessible(string path)
    {
        // Step 1: Check format
        if (!FilePickerPathConverter.IsValidPath(path, mustExist: false))
        {
            Logger.Warning($"Invalid path format: {path}");
            return false;
        }
        
        // Step 2: Normalize
        string normalized = FilePickerPathConverter.NormalizePath(path);
        if (normalized == null)
        {
            Logger.Warning($"Cannot normalize path: {path}");
            return false;
        }
        
        // Step 3: Check existence
        if (!FilePickerPathConverter.IsValidPath(normalized, mustExist: true))
        {
            Logger.Warning($"Path does not exist: {normalized}");
            return false;
        }
        
        return true;
    }
}
```

---

## Best Practices

1. **Always normalize dialog output:**
   ```csharp
   string output = /* from dialog */;
   string[] paths = FilePickerPathConverter.SplitMultiplePaths(output);
   ```

2. **Convert separators for consistency:**
   ```csharp
   string path = FilePickerPathConverter.ConvertPathSeparators(inputPath);
   ```

3. **Use safe extraction methods:**
   ```csharp
   string filename = FilePickerPathConverter.GetFileName(path) ?? "UNKNOWN";
   ```

4. **Validate paths before use:**
   ```csharp
   if (FilePickerPathConverter.IsValidPath(path, mustExist: true))
   {
       // Safe to use path
   }
   ```

5. **Handle null returns gracefully:**
   ```csharp
   string dir = FilePickerPathConverter.GetDirectoryName(path);
   if (string.IsNullOrEmpty(dir))
   {
       // Handle invalid path
   }
   ```

---

## Related Classes

- `FilePickerValidator` - Uses this for path validation
- `FilePickerExecutor` - Uses this for path handling in commands

---

**Last Updated:** February 22, 2026

