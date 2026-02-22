# FilePickerFactory Class Documentation

## Overview

`FilePickerFactory` is a static factory class responsible for creating platform-specific file picker instances. It automatically detects the current operating system and returns the appropriate implementation.

## Namespace

```csharp
using Alis.Extension.Io.FileDialog;
```

## Class Definition

```csharp
public static class FilePickerFactory
{
    public static IFilePicker CreateFilePicker();
    public static IFilePicker CreateFilePickerWithOptions(FilePickerOptions options);
    public static string GetPlatformName();
    public static bool IsPlatformSupported();
}
```

## Methods

### CreateFilePicker()

**Signature:**
```csharp
public static IFilePicker CreateFilePicker()
```

**Description:**
Creates and returns the appropriate file picker implementation for the current operating system without validating options.

**Returns:**
- `IFilePicker` - A platform-specific implementation:
  - `WindowsFilePicker` if running on Windows
  - `MacFilePicker` if running on macOS
  - `LinuxFilePicker` if running on Linux

**Exceptions:**
- `NotSupportedException` - Thrown if the current platform is not supported.

**Remarks:**
- This is the primary method for creating picker instances.
- Automatically detects the operating system using `RuntimeInformation.IsOSPlatform()`.
- No options validation is performed by this method.
- Each call creates a new instance (no caching).
- Thread-safe method.

**Example:**
```csharp
try
{
    IFilePicker picker = FilePickerFactory.CreateFilePicker();
    Logger.Info($"Created picker: {picker.GetType().Name}");
}
catch (NotSupportedException ex)
{
    Logger.Error($"Current platform not supported: {ex.Message}");
}
```

---

### CreateFilePickerWithOptions(FilePickerOptions options)

**Signature:**
```csharp
public static IFilePicker CreateFilePickerWithOptions(FilePickerOptions options)
```

**Description:**
Creates a file picker instance with pre-validated options. This method validates options before creating the picker.

**Parameters:**
- `options` - `FilePickerOptions` object containing dialog configuration to be validated.

**Returns:**
- `IFilePicker` - A platform-specific implementation (same as `CreateFilePicker()`).

**Exceptions:**
- `ArgumentNullException` - Thrown if `options` is null.
- `ArgumentException` - Thrown if options contain invalid values:
  - Empty or null title
  - Invalid default path
  - SaveFile with multiple selection enabled
  - AllowDirectories true on non-SelectFolder dialogs
- `NotSupportedException` - Thrown if the current platform is not supported.

**Remarks:**
- Combines factory creation with validation in one call.
- Automatically calls `FilePickerValidator.ValidateOptions()`.
- Preferred when options are being validated early.
- Still creates a new instance each call.
- Thread-safe method.

**Example:**
```csharp
try
{
    var options = new FilePickerOptions("Open File")
        .WithDefaultPath("/home/user");
    
    IFilePicker picker = FilePickerFactory.CreateFilePickerWithOptions(options);
    // Options are guaranteed to be valid at this point
}
catch (ArgumentException ex)
{
    Logger.Warning($"Invalid options: {ex.Message}");
}
catch (NotSupportedException ex)
{
    Logger.Error($"Platform not supported: {ex.Message}");
}
```

---

### GetPlatformName()

**Signature:**
```csharp
public static string GetPlatformName()
```

**Description:**
Returns a human-readable name of the current operating system platform.

**Returns:**
- `string` - One of the following values:
  - `"Windows"` - if running on Windows
  - `"macOS"` - if running on macOS
  - `"Linux"` - if running on Linux
  - `"Unknown"` - if platform cannot be determined

**Remarks:**
- Always returns a non-null, non-empty string.
- Useful for logging and debugging.
- Does not indicate whether the platform is supported.
- Use `IsPlatformSupported()` to check support.

**Example:**
```csharp
string platform = FilePickerFactory.GetPlatformName();
Logger.Info($"Running on: {platform}");

if (platform == "Windows")
{
    Logger.Info("Using PowerShell for dialogs");
}
else if (platform == "macOS")
{
    Logger.Info("Using AppleScript for dialogs");
}
else if (platform == "Linux")
{
    Logger.Info("Using zenity/kdialog for dialogs");
}
```

---

### IsPlatformSupported()

**Signature:**
```csharp
public static bool IsPlatformSupported()
```

**Description:**
Checks whether the current operating system platform is supported by the FileDialog module.

**Returns:**
- `bool` - `true` if the platform is supported (Windows, macOS, or Linux), `false` otherwise.

**Remarks:**
- Returns `true` only for Windows, macOS, and Linux.
- Useful for feature detection and graceful degradation.
- Does not throw exceptions - always returns a boolean result.
- Can be used to determine whether to offer file dialog functionality.

**Example:**
```csharp
if (!FilePickerFactory.IsPlatformSupported())
{
    Logger.Warning("File dialogs not supported on this platform");
    return false; // Disable file dialog feature
}

IFilePicker picker = FilePickerFactory.CreateFilePicker();
// Continue with file dialog functionality
```

---

## Platform Support Matrix

| Platform | Supported | Implementation | Dialog Tool |
|----------|-----------|-----------------|-------------|
| Windows | ✅ Yes | WindowsFilePicker | PowerShell + WinForms |
| macOS | ✅ Yes | MacFilePicker | AppleScript (osascript) |
| Linux | ✅ Yes | LinuxFilePicker | zenity (fallback: kdialog) |
| Other | ❌ No | N/A | N/A |

---

## Design Pattern: Factory Pattern

This class implements the Factory pattern, which provides:

1. **Encapsulation** - Platform detection logic is hidden from the client
2. **Loose Coupling** - Clients depend only on the `IFilePicker` interface
3. **Extensibility** - New platforms can be added by modifying only this class
4. **Single Responsibility** - This class handles only object creation

## Complete Usage Examples

### Example 1: Basic File Selection

```csharp
public static void SelectFile()
{
    // Check platform support first
    if (!FilePickerFactory.IsPlatformSupported())
    {
        Logger.Error("File dialogs not supported on this platform");
        return;
    }
    
    // Create picker
    IFilePicker picker = FilePickerFactory.CreateFilePicker();
    
    // Use picker
    var options = new FilePickerOptions("Select a file");
    FilePickerResult result = picker.PickFile(options);
    
    if (result.IsSuccess)
    {
        Logger.Info($"Selected: {result.SelectedPath}");
    }
}
```

### Example 2: Application Initialization with Logging

```csharp
public class Application
{
    public static void Initialize()
    {
        // Log platform information
        string platform = FilePickerFactory.GetPlatformName();
        bool supported = FilePickerFactory.IsPlatformSupported();
        
        Logger.Info($"Platform: {platform}");
        Logger.Info($"File Dialogs Supported: {supported}");
        
        if (!supported)
        {
            Logger.Warning("File dialog features will be disabled");
        }
    }
}
```

### Example 3: Conditional Feature Availability

```csharp
public class FileManager
{
    private IFilePicker _filePicker;
    private bool _supportsFileDialogs;
    
    public FileManager()
    {
        _supportsFileDialogs = FilePickerFactory.IsPlatformSupported();
        
        if (_supportsFileDialogs)
        {
            _filePicker = FilePickerFactory.CreateFilePicker();
        }
    }
    
    public void OpenFile()
    {
        if (!_supportsFileDialogs)
        {
            throw new InvalidOperationException(
                "File dialogs are not supported on this platform");
        }
        
        var options = new FilePickerOptions("Open File");
        FilePickerResult result = _filePicker.PickFile(options);
        
        // Handle result...
    }
}
```

### Example 4: Cross-Platform Awareness

```csharp
public class PlatformAwareFilePicker
{
    public static void SelectAndProcessFile()
    {
        string platform = FilePickerFactory.GetPlatformName();
        Logger.Info($"File picker will use {platform} native dialog");
        
        try
        {
            IFilePicker picker = FilePickerFactory.CreateFilePicker();
            var options = new FilePickerOptions("Select Document");
            FilePickerResult result = picker.PickFile(options);
            
            if (result.IsSuccess)
            {
                Logger.Info($"[{platform}] File selected: {result.SelectedPath}");
            }
        }
        catch (NotSupportedException ex)
        {
            Logger.Error($"[{platform}] File dialogs not available: {ex.Message}");
        }
    }
}
```

### Example 5: Feature Fallback Strategy

```csharp
public class FileImporter
{
    public async Task<string> GetImportPath()
    {
        // Try using native file dialog
        if (FilePickerFactory.IsPlatformSupported())
        {
            try
            {
                IFilePicker picker = FilePickerFactory.CreateFilePicker();
                var options = new FilePickerOptions("Select file to import")
                    .WithFilter(new FilePickerFilter("CSV Files", "csv", "txt"));
                
                FilePickerResult result = picker.PickFile(options);
                
                if (result.IsSuccess)
                {
                    return result.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                Logger.Warning($"Native file dialog failed: {ex.Message}");
            }
        }
        
        // Fallback to manual path entry
        Logger.Info("Using manual path entry as fallback");
        return await GetPathFromUserInput();
    }
    
    private Task<string> GetPathFromUserInput()
    {
        // Implement fallback mechanism
        return Task.FromResult(string.Empty);
    }
}
```

---

## Best Practices

1. **Check platform support** - Always verify platform support before attempting to use file dialogs:
   ```csharp
   if (!FilePickerFactory.IsPlatformSupported())
   {
       // Handle unsupported platform gracefully
   }
   ```

2. **Log platform information** - Help with debugging by logging platform details:
   ```csharp
   Logger.Info($"Using {FilePickerFactory.GetPlatformName()} file picker");
   ```

3. **Validate options early** - Use `CreateFilePickerWithOptions()` when options should be validated immediately:
   ```csharp
   try
   {
       var picker = FilePickerFactory.CreateFilePickerWithOptions(options);
   }
   catch (ArgumentException ex)
   {
       Logger.Error($"Invalid options: {ex.Message}");
   }
   ```

4. **Cache picker instance** - Create once and reuse if opening multiple dialogs:
   ```csharp
   private IFilePicker _picker = FilePickerFactory.CreateFilePicker();
   ```

5. **Handle NotSupportedException** - Always catch platform support exceptions:
   ```csharp
   try
   {
       IFilePicker picker = FilePickerFactory.CreateFilePicker();
   }
   catch (NotSupportedException ex)
   {
       Logger.Error($"Platform not supported: {ex.Message}");
   }
   ```

---

## Related Classes

- `IFilePicker` - Interface that picker instances implement
- `WindowsFilePicker` - Windows implementation
- `MacFilePicker` - macOS implementation
- `LinuxFilePicker` - Linux implementation
- `FilePickerOptions` - Configuration for dialogs
- `FilePickerValidator` - Validates options

---

**Last Updated:** February 22, 2026

