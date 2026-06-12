# Issue: AZ683VD3ikltiDWnKQi_

- **Rule**: csharpsquid:S1075
- **File**: 1_Presentation/Engine/src/Menus/TopMenuAction.cs
- **Line**: 57
- **Severity**: MINOR
- **Message**: Refactor your code not to use hardcoded absolute paths or URIs.
- **Clean Code Attribute**: CONSISTENT
- **Status**: committed

## Remediation

Extracted all hardcoded URLs into a dedicated `Urls` configuration class (`Urls.cs`). This centralizes external URLs and makes them easy to externalize to configuration sources in the future.

## Commit

`87a911241`
