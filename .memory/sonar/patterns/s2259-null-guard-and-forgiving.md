## Pattern: S2259 Null Guard + Null-Forgiving

**Rule:** csharpsquid:S2259 - NullReferenceException possible
**Symptom:** Parameter used after null-validating method call, but analyzer doesn't track the throw guarantee.

### Fix

1. Add explicit null guard before the try block
2. Use `options!.` (null-forgiving operator) at the usage site

### Template

```csharp
public FilePickerResult SomeMethod(FilePickerOptions options)
{
    Logger.Trace($"Called with options - Title: {options?.Title}");

    if (options == null)
    {
        return FilePickerResult.CreateError("Options cannot be null.");
    }

    try
    {
        FilePickerValidator.ValidateOptions(options);
        options!.SomeProperty = value;
        // ...
    }
    catch (Exception ex)
    {
        return FilePickerResult.CreateError($"Error: {ex.Message}");
    }
}
```

### Applied to

- LinuxFilePicker.cs (PickFile, PickFiles, PickFolder)
- MacFilePicker.cs (PickFile, PickFiles, PickFolder)
- WindowsFilePicker.cs (PickFile, PickFiles, PickFolder)
