# FilePickerExecutor Class Documentation

## Overview

`FilePickerExecutor` is a static utility class for executing system commands required for file dialogs. It handles process execution, error handling, and command availability detection across platforms.

## Namespace

```csharp
using Alis.Extension.Io.FileDialog;
```

## Class Definition

```csharp
public static class FilePickerExecutor
{
    public static string ExecuteCommand(string fileName, string arguments, int timeoutMs = 30000);
    public static bool CommandExists(string command);
}
```

## Methods

### ExecuteCommand(string fileName, string arguments, int timeoutMs = 30000)

**Signature:**
```csharp
public static string ExecuteCommand(string fileName, string arguments, int timeoutMs = 30000)
```

**Description:**
Executes a system command and returns its standard output. Used internally to execute dialog commands on each platform.

**Parameters:**
- `fileName` - Name or path of the executable to run (required)
- `arguments` - Command-line arguments to pass to the executable
- `timeoutMs` - Maximum time to wait for the command in milliseconds (optional, default: 30000)

**Returns:**
- `string` - The standard output from the command

**Exceptions:**
- `ArgumentException` - Thrown if `fileName` is null or empty
- `InvalidOperationException` - Thrown if the executable cannot be found or executed
- `OperationCanceledException` - Thrown if the command exceeds the timeout

**Remarks:**
- Redirects standard output for capture
- Redirects standard error for logging
- Runs in a separate process with no window
- Uses `UseShellExecute = false` for security
- Automatic process cleanup (Dispose)
- Logs all execution steps at Trace level
- Logs errors at Warning level

**Execution Details:**
- Standard output is captured and returned
- Standard error is logged if exit code is non-zero
- Process waits for completion up to timeout
- Process is forcefully killed if timeout exceeded
- Thread-safe across multiple calls

**Example:**
```csharp
try
{
    string output = FilePickerExecutor.ExecuteCommand(
        "powershell",
        "-Command \"Write-Output 'Hello'\"",
        timeoutMs: 10000
    );
    Console.WriteLine($"Output: {output}");
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Execution failed: {ex.Message}");
}
```

---

### CommandExists(string command)

**Signature:**
```csharp
public static bool CommandExists(string command)
```

**Description:**
Checks whether a command exists and is executable on the current system.

**Parameters:**
- `command` - Name of the command to check (e.g., "zenity", "powershell")

**Returns:**
- `bool` - `true` if the command exists and is executable, `false` otherwise

**Remarks:**
- Uses platform-specific commands:
  - Windows: `where command`
  - Unix/Linux/macOS: `which command`
- Returns `false` for null or empty command names
- Never throws exceptions
- Logs all checks at Trace level
- Useful for availability detection

**Platform-Specific Behavior:**
- **Windows**: Uses `where` command to find executables
- **macOS/Linux**: Uses `which` command to find executables

**Example:**
```csharp
if (FilePickerExecutor.CommandExists("zenity"))
{
    Console.WriteLine("zenity is available");
}
else
{
    Console.WriteLine("zenity is not installed");
}
```

---

## Internal Usage

These methods are used internally by platform-specific implementations:

### Windows Implementation
```csharp
// Executes PowerShell for Windows dialogs
string output = FilePickerExecutor.ExecuteCommand(
    "powershell",
    "-NoProfile -NonInteractive -Command \"...script...\""
);
```

### macOS Implementation
```csharp
// Executes osascript for macOS dialogs
string output = FilePickerExecutor.ExecuteCommand(
    "osascript",
    "/path/to/script.applescript"
);
```

### Linux Implementation
```csharp
// Executes zenity for Linux dialogs (with kdialog fallback)
if (FilePickerExecutor.CommandExists("zenity"))
{
    string output = FilePickerExecutor.ExecuteCommand(
        "zenity",
        "--file-selection --title=\"Open File\""
    );
}
else if (FilePickerExecutor.CommandExists("kdialog"))
{
    string output = FilePickerExecutor.ExecuteCommand(
        "kdialog",
        "--getopenfilename"
    );
}
```

---

## Complete Usage Examples

### Example 1: Simple Command Execution

```csharp
try
{
    string result = FilePickerExecutor.ExecuteCommand(
        "echo",
        "Hello, World!"
    );
    Console.WriteLine($"Result: {result}");
}
catch (InvalidOperationException ex)
{
    Logger.Error($"Command execution failed: {ex.Message}");
}
```

### Example 2: Checking Command Availability

```csharp
public class DialogToolChecker
{
    public string GetAvailableDialogTool()
    {
        if (FilePickerExecutor.CommandExists("zenity"))
        {
            return "zenity";
        }
        
        if (FilePickerExecutor.CommandExists("kdialog"))
        {
            return "kdialog";
        }
        
        Logger.Error("No dialog tool available");
        return null;
    }
}
```

### Example 3: Cross-Platform Command Detection

```csharp
public class SystemChecker
{
    public void CheckSystemTools()
    {
        string[] tools = { "zenity", "kdialog", "powershell", "osascript" };
        
        foreach (var tool in tools)
        {
            bool exists = FilePickerExecutor.CommandExists(tool);
            Logger.Info($"{tool}: {(exists ? "available" : "not available")}");
        }
    }
}
```

### Example 4: Timeout Handling

```csharp
try
{
    // Short timeout for testing
    string output = FilePickerExecutor.ExecuteCommand(
        "sleep",  // On Unix
        "10",     // Sleep 10 seconds
        timeoutMs: 2000  // But timeout after 2 seconds
    );
}
catch (OperationCanceledException ex)
{
    Logger.Warning($"Command timed out: {ex.Message}");
}
```

### Example 5: Error Handling in Picker Implementation

```csharp
public class CustomFilePicker
{
    public FilePickerResult SelectFile(string dialogScript)
    {
        // Check if required tool exists
        if (!FilePickerExecutor.CommandExists("zenity"))
        {
            Logger.Error("zenity is not installed");
            return FilePickerResult.CreateError(
                "File dialog tool (zenity) is not installed");
        }
        
        try
        {
            // Write script to temporary file
            string scriptFile = Path.GetTempFileName();
            File.WriteAllText(scriptFile, dialogScript);
            
            try
            {
                // Execute the script
                string output = FilePickerExecutor.ExecuteCommand(
                    "zenity",
                    $"--file-selection",
                    timeoutMs: 30000
                );
                
                if (string.IsNullOrWhiteSpace(output))
                {
                    return FilePickerResult.CreateCancelled();
                }
                
                return new FilePickerResult(output.Trim());
            }
            finally
            {
                // Clean up temp file
                try { File.Delete(scriptFile); }
                catch { /* ignore cleanup errors */ }
            }
        }
        catch (InvalidOperationException ex)
        {
            Logger.Error($"Dialog execution failed: {ex.Message}");
            return FilePickerResult.CreateError(ex.Message);
        }
    }
}
```

---

## Best Practices

1. **Check command availability before execution:**
   ```csharp
   if (FilePickerExecutor.CommandExists("zenity"))
   {
       // Safe to execute
   }
   ```

2. **Handle execution exceptions:**
   ```csharp
   try
   {
       var output = FilePickerExecutor.ExecuteCommand(...);
   }
   catch (InvalidOperationException ex)
   {
       Logger.Error($"Command failed: {ex.Message}");
   }
   ```

3. **Set reasonable timeouts:**
   ```csharp
   // 30 seconds is good for user interaction
   const int dialogTimeoutMs = 30000;
   ```

4. **Handle null or empty output:**
   ```csharp
   string output = FilePickerExecutor.ExecuteCommand(...);
   if (string.IsNullOrWhiteSpace(output))
   {
       // User cancelled or no selection
   }
   ```

5. **Clean up temporary files:**
   ```csharp
   string tempFile = Path.GetTempFileName();
   try
   {
       FilePickerExecutor.ExecuteCommand(...);
   }
   finally
   {
       File.Delete(tempFile);
   }
   ```

---

## Platform-Specific Tools

### Windows
- **Primary Tool:** `powershell` (built-in)
- **Requirements:** .NET Framework System.Windows.Forms
- **No external dependencies required**

### macOS
- **Primary Tool:** `osascript` (built-in)
- **Uses:** AppleScript
- **No external dependencies required**

### Linux
- **Primary Tool:** `zenity` (GNOME)
  ```bash
  sudo apt-get install zenity  # Ubuntu/Debian
  sudo dnf install zenity      # Fedora/RHEL
  ```
- **Fallback Tool:** `kdialog` (KDE)
  ```bash
  sudo apt-get install kdialog  # Ubuntu/Debian
  sudo dnf install kdialog      # Fedora/RHEL
  ```

---

## Related Classes

- `WindowsFilePicker` - Uses this to execute PowerShell
- `MacFilePicker` - Uses this to execute osascript
- `LinuxFilePicker` - Uses this to execute zenity/kdialog

---

**Last Updated:** February 22, 2026

