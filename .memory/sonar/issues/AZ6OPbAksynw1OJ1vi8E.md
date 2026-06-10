# Issue: AZ6OPbAksynw1OJ1vi8E

- **Rule**: csharpsquid:S2696, csharpsquid:S2325
- **File**: 1_Presentation/Installer/src/Installer.cs
- **Line**: 70, 64
- **Severity**: CRITICAL
- **Status**: OPEN
- **Message**: Make the enclosing instance method 'static' or remove this set on the 'static' field. / Make 'Run' a static method.
- **CleanCodeAttribute**: COMPLETE
- **Impacts**: MAINTAINABILITY (HIGH)

## Code Context

```csharp
private static INativePlatform _platform;

public void Run(string[] args)
{
    _platform = GetPlatform();
    // ...
}
```

## Resolution

- Made `Run` method static
- Updated call site in Program.cs from `new Installer().Run(args)` to `Installer.Run(args)`
- All other members in Installer class are already static
