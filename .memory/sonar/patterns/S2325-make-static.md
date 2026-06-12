# Pattern: S2325 - Make Method Static

- **Rule**: csharpsquid:S2325
- **Description**: Methods that don't access any instance members should be static
- **Remediation**: Change `private void MethodName()` to `private static void MethodName()`

## Applicability Checklist

- [ ] No `this.` references in method body
- [ ] No instance field accesses
- [ ] No instance property accesses (e.g., `SpaceWork`)
- [ ] Only uses static methods or static classes
- [ ] Call site works without qualification (C# allows static calls from instance methods)

## Files Fixed

- BottomMenu.cs — RenderMenuContent
- TopMenu.cs — RenderFileMenu, RenderEditMenu, RenderAssetsMenu, RenderGameObjectMenu, RenderComponentMenu, RenderToolsMenu, RenderWindowMenu, RenderHelpMenu

## Verification

After making static, run `dotnet build alis.slnx` to verify compilation.
