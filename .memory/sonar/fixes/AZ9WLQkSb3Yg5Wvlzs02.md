## Fix: AZ9WLQkSb3Yg5Wvlzs02 / AZ9WLQkSb3Yg5Wvlzs03

- File: 1_Presentation/Extension/Io/FileDialog/src/LinuxFilePicker.cs
- Rule: csharpsquid:S2259
- Severity: MAJOR
- Date: 2026-07-13

### Change

Added null guard before the try block and `options!.` to assert non-null.

### Before

```csharp
public FilePickerResult PickFile(FilePickerOptions options)
{
    Logger.Trace($"PickFile() called with options - Title: {options?.Title}");
    try
    {
        FilePickerValidator.ValidateOptions(options);
        options.AllowMultiple = false;
```

### After

```csharp
public FilePickerResult PickFile(FilePickerOptions options)
{
    Logger.Trace($"PickFile() called with options - Title: {options?.Title}");
    if (options == null)
        return FilePickerResult.CreateError("Options cannot be null.");
    try
    {
        FilePickerValidator.ValidateOptions(options);
        options!.AllowMultiple = false;
```
