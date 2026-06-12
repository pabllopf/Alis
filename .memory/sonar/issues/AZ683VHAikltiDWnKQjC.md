# Issue: AZ683VHAikltiDWnKQjC

- **Rule**: csharpsquid:S2325
- **File**: 1_Presentation/Engine/src/Menus/TopMenu.cs
- **Line**: 97
- **Severity**: MINOR
- **Message**: Make 'RenderFileMenu' a static method.
- **Clean Code Attribute**: INTENTIONAL
- **Status**: committed

## Code Snippet

```csharp
private void RenderFileMenu()
```

## Remediation

Changed `RenderFileMenu` from instance method to `static`. Method only uses static ImGui API calls and `RenderMenuItem()` (already static). No instance members accessed.

## Commit

`84973f303`
