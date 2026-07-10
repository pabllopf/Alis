---
status: Active
created: 2026-07-10T12:30:00Z
worker: local-agent
---

## COVERAGE TASK

### File
1_Presentation/Extension/Io/FileDialog/src/FilePickerFactory.cs

### Coverage
62.7%

### Uncovered Lines
~15

### Uncovered Conditions
10

### Method
Multiple (CreateFilePicker, CreateFilePickerWithOptions, GetPlatformName, IsPlatformSupported)

### Existing Tests
FilePickerFactoryTest.cs (152 total in project, ~8 in FactoryTest)

### Source Code
```csharp
public static class FilePickerFactory
{
    public static IFilePicker CreateFilePicker()
    {
        Logger.Trace("Creating FilePicker for the current operating system...");
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            Logger.Info("Creating WindowsFilePicker.");
            return new WindowsFilePicker();
        }
        if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            Logger.Info("Creating MacFilePicker.");
            return new MacFilePicker();
        }
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            Logger.Info("Creating LinuxFilePicker.");
            return new LinuxFilePicker();
        }
        Logger.Error("Operating system is not supported.");
        throw new NotSupportedException(...);
    }

    public static IFilePicker CreateFilePickerWithOptions(FilePickerOptions options)
    {
        Logger.Trace("Creating FilePicker with custom options...");
        if (options == null)
        {
            Logger.Warning("FilePickerOptions is null.");
            throw new ArgumentNullException(nameof(options), "Options cannot be null.");
        }
        FilePickerValidator.ValidateOptions(options);
        return CreateFilePicker();
    }

    public static string GetPlatformName()
    {
        Logger.Trace("Getting current platform name...");
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) return "Windows";
        if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) return "macOS";
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) return "Linux";
        return "Unknown";
    }

    public static bool IsPlatformSupported()
    {
        Logger.Trace("Checking if current platform is supported...");
        bool isSupported = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
                           || RuntimeInformation.IsOSPlatform(OSPlatform.OSX)
                           || RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
        Logger.Info($"Platform {GetPlatformName()} is {(isSupported ? "supported" : "not supported")}.");
        return isSupported;
    }
}
```

### Strategy
- FilePickerFactory uses RuntimeInformation.IsOSPlatform() which is platform-dependent
- On current platform (macOS), only OSX branches are exercised
- Add tests for edge cases: CreateFilePickerWithOptions with valid options covering all dialog types
- Add tests for IsPlatformSupported logging behavior
- Platform-specific branches (Windows, Linux, Unknown) can only be covered on respective platforms via CI matrix
